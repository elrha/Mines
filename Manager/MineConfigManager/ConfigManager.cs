using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mines.Manager.ConfigManager
{
    public class ConfigManager
    {
        private static ConfigManager instance = new ConfigManager();
        public static ConfigManager Instance { get { return ConfigManager.instance; } }

        private int mainThreadSleep = 150;
        public int MainThreadSleep { get { return this.mainThreadSleep; } }

        private int mainCanvasWidth = 400;
        public int MainCanvasWidth { get { return this.mainCanvasWidth; } }

        private int maxMine = 75;
        public int MaxMine { get { return maxMine; } }

        private int winCondition = 38;
        public int WinCondition { get { return winCondition; } }

        private int mineWidthCount = 20;
        public int MineWidthCount { get { return mineWidthCount; } }

        private int minePixelWidth = 20;
        public int MinePixelWidth { get { return minePixelWidth; } }

        private int highlightWidth = 20 / 10;
        public int HighlightWidth { get { return highlightWidth; } }

        private int highlightColorGap = 30;
        public int HightlightColorGap { get { return highlightColorGap; } }

        private Color normalMineColor = Color.FromArgb(0xB6, 0xB6, 0xB6);
        public Color NormalMineColor { get { return normalMineColor; } }

        private Color clickedMineColor = Color.FromArgb(0x8D, 0x8D, 0x8D);
        public Color ClickedMineColor { get { return clickedMineColor; } }

        public void Initialize(int clientWidth, int maxMine, int winCondition, int mineWidthCount)
        {
            this.mainCanvasWidth = clientWidth;
            this.maxMine = maxMine;
            this.winCondition = winCondition;
            this.mineWidthCount = mineWidthCount;
            this.minePixelWidth = clientWidth / mineWidthCount;
            this.highlightWidth = ConfigManager.instance.minePixelWidth / 10;
        }
    }
}