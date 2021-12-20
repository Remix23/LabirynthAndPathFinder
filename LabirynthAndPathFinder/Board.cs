﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LabirynthAndPathFinder
{
    internal class Board
    {

        public Tile[,] Tiles;
        public Point Start;
        public Point End;

        public int BoardWidth;
        public int BoardHeight;
        public int NumOfCellsX;
        public int NumOfCellsY;
        public int TileSize;

        private bool _isAnimating;
        private int _frame;

        public List<Point> Path;

        public Board(int boardWidth, int boardHeight, int tileSize)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            TileSize = tileSize;
            NumOfCellsX = boardWidth / tileSize;
            NumOfCellsY = boardHeight / tileSize;

            Tiles = new Tile[NumOfCellsX,NumOfCellsY];
            Path = new List<Point>();

            Start = new Point(-1, -1);
            End = new Point(-1, -1);

            _isAnimating = false;
            _frame = 0;

            _genTiles();
        }

        private void _genTiles ()
        {
            for (int x = 0; x < NumOfCellsX; x++)
            {
                for (int y = 0; y < NumOfCellsY; y++)
                {
                    Tiles[x, y] = new Tile(new Point(x, y), Color.FromName("White"), TileSize, false);
                }
            }
        }

        public void SetStartingPoint (int x, int y)
        {
            Tiles[x, y].isStart = true;
            Tiles[x, y].isEnd = false;
            Tiles[x, y].isWall = false;
            Start = new Point (x, y);
        }

        public void SetEndPoint (int x, int y)
        {
            Tiles[x, y].isStart = false;
            Tiles[x, y].isEnd = true;
            Tiles[x, y].isWall = false;
            End = new Point(x, y);
        }

        public void CreateWall (int x, int y)
        {
            Tiles[x, y].isStart = false;
            Tiles[x, y].isEnd = false;
            Tiles[x, y].isWall = true;
        }

        public void DestroyWall (int x, int y)
        {
            Tiles[x, y].isStart = false;
            Tiles[x, y].isEnd = false;
            Tiles[x, y].isWall = false;
        }

        public void HandleClick (Point location, MouseButtons mousebtn)
        {
            int x = location.X / TileSize;
            int y = location.Y / TileSize;

            if (!Tile.AreCordsValid(x, y, NumOfCellsX, NumOfCellsY)) return;

            if (mousebtn == MouseButtons.Left)
            {
                CreateWall(x, y);
            } else if (mousebtn == MouseButtons.Right)
            {
                DestroyWall(x, y);
            }
        }

        public void CreateMaze ()
        {
            MazeGenerator.GenMaze(Tiles, new Point(0, 0));

            // start
            Point p = MazeGenerator.RandomPoint(NumOfCellsX, NumOfCellsY);
            SetStartingPoint(p.X, p.Y);

            // end
            p = MazeGenerator.RandomPoint(NumOfCellsX, NumOfCellsY);
            while (Tiles[p.X, p.Y].isStart) { p = MazeGenerator.RandomPoint(NumOfCellsX, NumOfCellsY); }
            SetEndPoint(p.X, p.Y);
        }

        public void GetPath ()
        {
            PathFinder.FindPath(Tiles, Start, End);
            Path = PathFinder.ReconstructPath(Tiles, Start, End);
        }

        public void Solve ()
        {
            string title = "Akcja nie możliwa";
            if (!Tile.AreCordsValid(Start.X, Start.Y, NumOfCellsX, NumOfCellsY))
            {
                MessageBox.Show("Na planszy musi być punkt startowy", title, MessageBoxButtons.OK);
            }
            else if (!Tile.AreCordsValid(End.X, End.Y, NumOfCellsX, NumOfCellsY))
            {
                MessageBox.Show("Na planszy musi być punkt końcowy", title, MessageBoxButtons.OK);
            }
            else
            {
                GetPath();
                _isAnimating = true;
                _frame = 0;
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var tile in Tiles)
            {
                tile.Draw(g);
            }
            if (_isAnimating)
            {
                if (_frame == Path.Count) { _isAnimating = false; return; }
                Point pos = Path[_frame];
                g.FillEllipse(Brushes.Black, pos.X, pos.Y, TileSize, TileSize);
                _frame++;
            }
        }
    }
}
