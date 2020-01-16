﻿using System;
using System.Drawing;

namespace Ball_Breaker
{
    internal class CellState
    {
        public static readonly Random Random = new Random();

        public readonly Color BallColor;

        public bool HasBall { get; private set; }
        public int SimilarBallsAroundCount;

        public CellState()
        {
            BallColor = GetRandomColor();
            HasBall = true;
        }

        private Color GetRandomColor()
        {
            switch (Random.Next(0, 5))
            {
                case 0: return Color.Green;
                case 1: return Color.Blue;
                case 2: return Color.Red;
                case 3: return Color.Khaki;
                case 4: return Color.BlueViolet;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public void SetHasBallTrue()
        {
            HasBall = true;
        }

        public void SetHasBallFalse()
        {
            HasBall = false;
        }

        public void Draw(Graphics graphics, int cellX, int cellY, int cellSize)
        {
            int positionX = cellX * cellSize;
            int positionY = cellY * cellSize;
            int offsetToCenter = cellSize / 7;

            if (HasBall)
                graphics.FillEllipse(GetBrush(), positionX + offsetToCenter, positionY + offsetToCenter, 27, 27);
        }

        private Brush GetBrush()
        {
            if (BallColor == Color.Green)
                return Brushes.Green;

            if (BallColor == Color.Blue)
                return Brushes.Blue;

            if (BallColor == Color.Red)
                return Brushes.Red;

            if (BallColor == Color.Khaki)
                return Brushes.Khaki;

            if (BallColor == Color.BlueViolet)
                return Brushes.BlueViolet;

            throw new ArgumentOutOfRangeException();
        }
    }
}
