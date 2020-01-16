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

            game.Defeat += () =>
            {
                gameField.Refresh();
                Timer.Enabled = false;
                MessageBox.Show("Game over");
                game.StartNewGame();
            };

            game.StartNewGame();
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
                game.ChooseCell(cellX, cellY);
        }

        private void TickTimer(object sender, System.EventArgs e)
        {
            game.Update();
            gameField.Refresh();
        }

        private void ClickNewGame(object sender, System.EventArgs e)
        {
            game.StartNewGame();
        }

        private void ClickUndo(object sender, System.EventArgs e)
        {
            game.UndoDeleteSelectedArea();
        }
    }

}