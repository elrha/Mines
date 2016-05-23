using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerseusCommon.Manager.AssemblyManager
{
    static class PlayerDocHelper
    {
        public static string GetMethodFullString(MethodInfo methodInfo)
        {
            StringBuilder parametersString = new StringBuilder("");

            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                if (parametersString.Length > 0)
                {
                    parametersString.Append(",");
                }

                parametersString.Append(parameterInfo.ParameterType.FullName);
            }

            return String.Format("{0} {1}({2})", methodInfo.ReturnParameter.ParameterType.Name, methodInfo.Name, parametersString.ToString());
        }
    }
}
