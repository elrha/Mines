using Mines.Manager.ConfigManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mines.Helper
{
    class ImageHelper
    {
        private static Random rand = new Random();

        public static Image CreateNonClickedImage()
        {
            var mineWidth = ConfigManager.Instance.MinePixelWidth;
            var hightlightWidth = ConfigManager.Instance.HighlightWidth;
            var highlightColorGap = ConfigManager.Instance.HightlightColorGap;
            var normalColor = ConfigManager.Instance.NormalMineColor;
            var hightlightTopColor = Color.FromArgb(normalColor.R + highlightColorGap, normalColor.G + highlightColorGap, normalColor.B + highlightColorGap);
            var hightlightBottomColor = Color.FromArgb(normalColor.R - highlightColorGap, normalColor.G - highlightColorGap, normalColor.B - highlightColorGap);
            var retImage = new Bitmap(mineWidth, mineWidth);

            for (int i = hightlightWidth; i < mineWidth - hightlightWidth; i++)
            {
                for (int j = hightlightWidth; j < mineWidth - hightlightWidth; j++)
                {
                    retImage.SetPixel(i, j, normalColor);
                }
            }

            for (int i = 0; i < mineWidth; i++)
            {
                for (int j = 0; j < hightlightWidth; j++)
                {
                    retImage.SetPixel(i, j, hightlightTopColor);
                    retImage.SetPixel(i, mineWidth - j - 1, hightlightBottomColor);
                }
            }

            for (int i = hightlightWidth; i < mineWidth - hightlightWidth; i++)
            {
                for (int j = 0; j < hightlightWidth; j++)
                {
                    retImage.SetPixel(j, i, hightlightTopColor);
                    retImage.SetPixel(mineWidth - j - 1, i, hightlightBottomColor);
                }
            }

            return retImage;
        }

        public static Image CreateClickedImage(int number)
        {
            var mineWidth = ConfigManager.Instance.MinePixelWidth;
            var hightlightWidth = ConfigManager.Instance.HighlightWidth;
            var highlightColorGap = ConfigManager.Instance.HightlightColorGap;
            var normalColor = ConfigManager.Instance.ClickedMineColor;
            var hightlightTopColor = Color.FromArgb(normalColor.R - highlightColorGap, normalColor.G - highlightColorGap, normalColor.B - highlightColorGap);
            var hightlightBottomColor = Color.FromArgb(normalColor.R + highlightColorGap, normalColor.G + highlightColorGap, normalColor.B + highlightColorGap);
            var retImage = new Bitmap(mineWidth, mineWidth);

            for (int i = hightlightWidth; i < mineWidth - hightlightWidth; i++)
            {
                for (int j = hightlightWidth; j < mineWidth - hightlightWidth; j++)
                {
                    retImage.SetPixel(i, j, normalColor);
                }
            }

            for (int i = 0; i < mineWidth; i++)
            {
                for (int j = 0; j < hightlightWidth; j++)
                {
                    retImage.SetPixel(i, j, hightlightTopColor);
                    retImage.SetPixel(i, mineWidth - j - 1, hightlightBottomColor);
                }
            }

            for (int i = hightlightWidth; i < mineWidth - hightlightWidth; i++)
            {
                for (int j = 0; j < hightlightWidth; j++)
                {
                    retImage.SetPixel(j, i, hightlightTopColor);
                    retImage.SetPixel(mineWidth - j - 1, i, hightlightBottomColor);
                }
            }

            if (number > 0 && number <= 8)
            {
                var brushTypes = typeof(Brushes).GetProperties();
                var g = Graphics.FromImage(retImage);
                g.DrawString(
                    number.ToString(),
                    new Font("Arial Black", 8),
                    (Brush)brushTypes[ImageHelper.rand.Next(brushTypes.Length)].GetValue(null, null),
                    new Rectangle(hightlightWidth * 2, hightlightWidth, mineWidth - hightlightWidth, mineWidth - hightlightWidth)
                    );
            }

            return retImage;
        }
    }
}
