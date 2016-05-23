namespace Mines
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainCanvas = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.Player1Combo = new System.Windows.Forms.ComboBox();
            this.Player2Combo = new System.Windows.Forms.ComboBox();
            this.Player1Canvas = new System.Windows.Forms.PictureBox();
            this.Player2Canvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Canvas)).BeginInit();

            // 
            // MainCanvas
            // 
            this.MainCanvas.Location = new System.Drawing.Point(200, 0);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(600, 600);
            this.MainCanvas.TabIndex = 0;
            this.MainCanvas.TabStop = false;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(200, 600);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(600, 24);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButtonClicked);
            // 
            // Player1Combo
            // 
            this.Player1Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Player1Combo.FormattingEnabled = true;
            this.Player1Combo.Location = new System.Drawing.Point(0, 600);
            this.Player1Combo.Name = "Player1Combo";
            this.Player1Combo.Size = new System.Drawing.Size(200, 24);
            this.Player1Combo.TabIndex = 2;
            // 
            // Player2Combo
            // 
            this.Player2Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Player2Combo.FormattingEnabled = true;
            this.Player2Combo.Location = new System.Drawing.Point(800, 600);
            this.Player2Combo.Name = "Player2Combo";
            this.Player2Combo.Size = new System.Drawing.Size(200, 24);
            this.Player2Combo.TabIndex = 3;
            // 
            // Player1Canvas
            // 
            this.Player1Canvas.Location = new System.Drawing.Point(0, 0);
            this.Player1Canvas.Name = "Player1Canvas";
            this.Player1Canvas.Size = new System.Drawing.Size(200, 600);
            this.Player1Canvas.TabIndex = 4;
            this.Player1Canvas.TabStop = false;
            // 
            // Player2Canvas
            // 
            this.Player2Canvas.Location = new System.Drawing.Point(800, 0);
            this.Player2Canvas.Name = "Player2Canvas";
            this.Player2Canvas.Size = new System.Drawing.Size(200, 600);
            this.Player2Canvas.TabIndex = 5;
            this.Player2Canvas.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 624);
            this.Controls.Add(this.Player2Canvas);
            this.Controls.Add(this.Player1Canvas);
            this.Controls.Add(this.Player2Combo);
            this.Controls.Add(this.Player1Combo);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.MainCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Mines";
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Canvas)).EndInit();
        }

        #endregion

        private System.Windows.Forms.PictureBox MainCanvas;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox Player1Combo;
        private System.Windows.Forms.ComboBox Player2Combo;
        private System.Windows.Forms.PictureBox Player1Canvas;
        private System.Windows.Forms.PictureBox Player2Canvas;
    }
}

