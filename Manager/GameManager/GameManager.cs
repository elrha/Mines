using Mines.Helper;
using Mines.Renderer;
using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mines.Manager.GameManager
{
    class GameManager
    {
        private static GameManager instance = new GameManager();
        public static GameManager Instance { get { return instance; } }

        private MainRenderer mainRenderer;
        private PlayerRenderer player1Renderer;
        private PlayerRenderer player2Renderer;

        private bool playFlag;
        private Thread mainThread;

        public GameManager()
        {
            this.playFlag = false;
        }

        public void Initialize(MainRenderer mainRenderer, PlayerRenderer player1Renderer, PlayerRenderer player2Renderer, IPlayer player1, IPlayer player2)
        {
            this.StopGame();

            this.mainRenderer = mainRenderer;
            this.player1Renderer = player1Renderer;
            this.player2Renderer = player2Renderer;

            var gameContext = new GameContext()
            {
                CurrentPlayer = (new Random()).Next(2),
                Players = new IPlayer[2] { player1, player2 },
                Score = new int[2],
                ExceptionCount = new int[2],
                ChickenCount = new int[2],
                WinFlag = new bool[2],
                OriginField = MapHelper.SetNumbers(MapHelper.SetMines(MapHelper.CreateFields())),
                PlayField = MapHelper.CreateFields()
            };

            this.startGame(gameContext);
        }

        public void StopGame()
        {
            if (this.playFlag)
            {
                this.playFlag = false;
                this.mainThread.Join();
            }
        }

        private void startGame(GameContext gameContext)
        {
            this.playFlag = true;
            this.mainThread = new Thread(GameProc);
            this.mainThread.Start(gameContext);
        }

        private void GameProc(object obj)
        {
            var gameContext = obj as GameContext;
            if (gameContext == null) return;

            while (this.playFlag)
            {
                calculatePosition(gameContext);
                renderScreen(gameContext);

                if (gameContext.WinFlag[0] || gameContext.WinFlag[1])
                    this.playFlag = false;

                Thread.Sleep(ConfigManager.ConfigManager.Instance.MainThreadSleep);
            }
        }

        private void checkField(GameContext gameContext, int index, HashSet<int> newSet, HashSet<int> oldSet)
        {
            if (index >= 0 && index < gameContext.OriginField.Count())
            {
                if (MineType.NUMBER_0 <= gameContext.OriginField[index] && gameContext.OriginField[index] <= MineType.NUMBER_8)
                {
                    gameContext.PlayField[index] = gameContext.OriginField[index];

                    if(gameContext.OriginField[index] == MineType.NUMBER_0 && !oldSet.Contains(index))
                        newSet.Add(index);
                }
            }
        }

        private void traceBlankBlock(GameContext gameContext, int index)
        {
            var newSet = new HashSet<int>() { index };
            var oldSet = new HashSet<int>();
            var mapVCount = ConfigManager.ConfigManager.Instance.MineWidthCount;
            var mapTotalCount = mapVCount * mapVCount;

            while (newSet.Count() > 0)
            {
                var targetIndex = newSet.First();

                checkField(gameContext, targetIndex - mapVCount - 1, newSet, oldSet);
                checkField(gameContext, targetIndex - mapVCount, newSet, oldSet);
                checkField(gameContext, targetIndex - mapVCount + 1, newSet, oldSet);
                checkField(gameContext, targetIndex - 1, newSet, oldSet);
                checkField(gameContext, targetIndex + 1, newSet, oldSet);
                checkField(gameContext, targetIndex + mapVCount - 1, newSet, oldSet);
                checkField(gameContext, targetIndex + mapVCount, newSet, oldSet);
                checkField(gameContext, targetIndex + mapVCount + 1, newSet, oldSet);

                newSet.Remove(targetIndex);
                oldSet.Add(targetIndex);
            }
        }

        private void calculatePosition(GameContext gameContext)
        {
            int currentPosition = -1;

            try
            {
                currentPosition = gameContext.Players[gameContext.CurrentPlayer].GetPosition(gameContext.PlayField.Clone() as MineType[]);
            }
            catch
            {
                gameContext.ExceptionCount[gameContext.CurrentPlayer]++;
                gameContext.CurrentPlayer = gameContext.CurrentPlayer == 0 ? 1 : 0;
                return;
            }

            if (currentPosition < 0 || currentPosition >= gameContext.PlayField.Count() || gameContext.PlayField[currentPosition] != MineType.NONE)
            {
                gameContext.ChickenCount[gameContext.CurrentPlayer]++;
                gameContext.CurrentPlayer = gameContext.CurrentPlayer == 0 ? 1 : 0;
                return;
            }

            switch (gameContext.OriginField[currentPosition])
            {
                case MineType.RESERVED_0:
                    gameContext.PlayField[currentPosition] = MineType.CHECKED_1 + gameContext.CurrentPlayer;
                    gameContext.Score[gameContext.CurrentPlayer]++;
                    break;
                case MineType.NUMBER_0:
                    traceBlankBlock(gameContext, currentPosition);
                    gameContext.PlayField[currentPosition] = gameContext.OriginField[currentPosition];
                    gameContext.CurrentPlayer = gameContext.CurrentPlayer == 0 ? 1 : 0;
                    break;
                case MineType.NUMBER_1:
                case MineType.NUMBER_2:
                case MineType.NUMBER_3:
                case MineType.NUMBER_4:
                case MineType.NUMBER_5:
                case MineType.NUMBER_6:
                case MineType.NUMBER_7:
                case MineType.NUMBER_8:
                    gameContext.PlayField[currentPosition] = gameContext.OriginField[currentPosition];
                    gameContext.CurrentPlayer = gameContext.CurrentPlayer == 0 ? 1 : 0;
                    break;
            }

            for (int i = 0; i < 2; i++)
                if (gameContext.Score[i] >= ConfigManager.ConfigManager.Instance.WinCondition)
                    gameContext.WinFlag[i] = true;
        }

        private void renderScreen(GameContext gameContext)
        {
            this.mainRenderer.Update(gameContext.PlayField);
            this.player1Renderer.Update(gameContext.CurrentPlayer == 0 ? true : false, gameContext.Score[0], gameContext.ExceptionCount[0], gameContext.ChickenCount[0], gameContext.WinFlag[0]);
            this.player2Renderer.Update(gameContext.CurrentPlayer == 1 ? true : false, gameContext.Score[1], gameContext.ExceptionCount[1], gameContext.ChickenCount[1], gameContext.WinFlag[1]);
        }
    }
}
