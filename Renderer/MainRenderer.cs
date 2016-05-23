using Mines.Helper;
using Mines.Manager.ConfigManager;
using PlayerInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mines.Renderer
{
    class MainRenderer
    {
        private PictureBox targetCanvas;
        private Graphics outGraphics;
        private Image image;
        private Graphics imageGraphics;
        private Image[] mineImages;

        public MainRenderer(PictureBox targetCanvas, Image player1, Image player2)
        {
            this.targetCanvas = targetCanvas;
            this.outGraphics = targetCanvas.CreateGraphics();
            this.image = new Bitmap(targetCanvas.Size.Width, targetCanvas.Size.Height);
            this.imageGraphics = Graphics.FromImage(this.image);
            this.mineImages = new Image[Enum.GetNames(typeof(MineType)).Length];

            for(int i = 0; i <= 8; i++)
            {
                this.mineImages[i] = ImageHelper.CreateClickedImage(i);
            }

            this.mineImages[(int)MineType.NONE] = ImageHelper.CreateNonClickedImage();
            this.mineImages[(int)MineType.CHECKED_1] = player1;
            this.mineImages[(int)MineType.CHECKED_2] = player2;
            this.mineImages[(int)MineType.RESERVED_0] = Properties.Resources.mine;
        }

        public void Update(MineType[] mineFields)
        {
            var mineWidthCount = ConfigManager.Instance.MineWidthCount;
            var mineWidth = ConfigManager.Instance.MinePixelWidth;

            if(mineFields.Count() != mineWidthCount * mineWidthCount) return;

            for (int h = 0; h < mineWidthCount; h++)
            { 
                for(int w = 0; w < mineWidthCount; w++)
                {
                    imageGraphics.DrawImage(this.mineImages[(int)mineFields[h * mineWidthCount + w]], w * mineWidth, h * mineWidth, mineWidth, mineWidth);
                }
            }

            targetCanvas.BeginInvoke(new Action(() =>
            {
                outGraphics.DrawImage(image, 0, 0, targetCanvas.Size.Width, targetCanvas.Size.Height);
            }));
        }
    }
}