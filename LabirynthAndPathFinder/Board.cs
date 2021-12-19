using System;
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
        public Point? Start;
        public Point? End;

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

            Start = null;
            End = null;

            _isAnimating = false;
            _frame = 0;
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

        public void CreateMaze ()
        {
            MazeGenerator.GenMaze(Tiles, new Point(0, 0));
        }

        public void GetPath ()
        {
            
        }

        public void Solve ()
        {
            GetPath();
            _isAnimating = true;
            _frame = 0;
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
