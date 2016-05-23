using Mines.Manager.LogManager;
using Mines.Manager.PlayerManager;
using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerseusCommon.Manager.AssemblyManager
{
    public class PlayerManager
    {
        #region SingleTon

        private static PlayerManager instance = new PlayerManager();

        public static PlayerManager Instance { get { return PlayerManager.instance; } }

        #endregion

        #region Assembly Doc

        public string PlayerInfo { private set; get; }

        #endregion

        #region Assembly Container

        private Dictionary<string, PlayerGenerator> players;

        public Dictionary<string, PlayerGenerator> Players { get { return players; } }

        #endregion

        private readonly string assemblyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Player");

        private PlayerManager()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            LoadAssemblyFiles();
        }

        private void LoadAssemblyFiles()
        {
            players = new Dictionary<string, PlayerGenerator>();

            if (!Directory.Exists(assemblyFilePath))
            {
                Directory.CreateDirectory(assemblyFilePath);
            }
            else
            {
                var strBuilder = new StringBuilder();

                foreach (var file in new DirectoryInfo(assemblyFilePath).GetFiles())
                {
                    strBuilder.AppendFormat("{0}\n", file.Name);

                    try
                    {
                        foreach (var type in Assembly.LoadFile(file.FullName).GetTypes())
                        {
                            try
                            {
                                strBuilder.AppendFormat("\t{0}\n", type.Name);
                                var dllInstance = Activator.CreateInstance(type) as IPlayer;

                                if (dllInstance != null)
                                {
                                    players.Add(file.Name + ":" + dllInstance.GetName(), new PlayerGenerator(type));
                                }
                            }
                            catch (Exception e)
                            {
                                // note : can't create instance
                                strBuilder.Append("TypeLoadError - [FileName] : " + file.Name + " [TypeName] : " + type.Name + " [Error] : " + e.Message);
                                LogManager.Instance.WriteLog("TypeLoadError - [FileName] : " + file.Name + " [TypeName] : " + type.Name + " [Error] : " + e.Message);
                            }
                        }

                        strBuilder.Append('\n');
                    }
                    catch (Exception e)
                    {
                        // note : is not assembly
                        strBuilder.Append("FileLoadError - [FileName] : " + file.Name + e.Message);
                        LogManager.Instance.WriteLog("FileLoadError - [FileName] : " + file.Name + e.Message);
                    }
                }

                PlayerInfo = strBuilder.ToString();
            }
        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var searchResult = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, args.Name.Split(',').First() + ".dll", SearchOption.AllDirectories);

            if (searchResult.Count() > 0)
                return Assembly.LoadFrom(searchResult.First());

            return null;
        }
    }
}