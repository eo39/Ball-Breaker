﻿using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ball_Breaker
{
    public partial class MainForm : Form
    {
        private const int CellSize = 36;

        private readonly Game game = new Game(CellSize);

        public MainForm()
        {
            InitializeComponent();

            gameField.Paint += Draw;

            game.StartGame();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; 
            game.Draw(e.Graphics);
        }

        private void ClickMouse(object sender, MouseEventArgs e)
        {
            int cellX = e.X / CellSize;
            int cellY = e.Y / CellSize;

            if (e.Button == MouseButtons.Left)
                game.SelectArea(cellX, cellY);

            gameField.Refresh();
        }
    }

}