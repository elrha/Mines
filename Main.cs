using Mines.Controls;
using Mines.Manager.ConfigManager;
using Mines.Manager.GameManager;
using Mines.Renderer;
using PerseusCommon.Manager.AssemblyManager;
using PlayerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mines
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializeMain();
            this.FormClosing += formClosing;
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            GameManager.Instance.StopGame();
        }

        private void InitializeMain()
        {
            // note : initialize core
            ConfigManager.Instance.Initialize(this.MainCanvas.Width, 100, 50, 20);

            foreach(var player in PlayerManager.Instance.Players)
            {
                this.Player1Combo.Items.Add(new PlayerComboBoxItem(player.Key, player.Value));
                this.Player2Combo.Items.Add(new PlayerComboBoxItem(player.Key, player.Value));
            }

            this.Player1Combo.SelectedIndex = 0;
            this.Player2Combo.SelectedIndex = 0;
        }

        private void StartButtonClicked(object sender, System.EventArgs e)
        {
            var player1 = (this.Player1Combo.SelectedItem as PlayerComboBoxItem).PlayerGenerator.New();
            var player2 = (this.Player2Combo.SelectedItem as PlayerComboBoxItem).PlayerGenerator.New();
            player1.Initialize(ConfigManager.Instance.MineWidthCount, ConfigManager.Instance.MineWidthCount);
            player2.Initialize(ConfigManager.Instance.MineWidthCount, ConfigManager.Instance.MineWidthCount);
            var player1Image = player1.GetImage();
            var player2Image = player2.GetImage();

            GameManager.Instance.Initialize(
                new MainRenderer(MainCanvas, player1Image, player2Image),
                new PlayerRenderer(Player1Canvas, player1.GetName(), player1Image),
                new PlayerRenderer(Player2Canvas, player2.GetName(), player2Image),
                player1,
                player2
                );
        }
    }
}