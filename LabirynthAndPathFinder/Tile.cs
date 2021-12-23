using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LabirynthAndPathFinder
{
    public class Tile
    {
        public Point Pos;
        public bool isWall;
        public bool isStart;
        public bool isEnd;

        private Color _color;
        private int _size;

        // maze genarating 
        public bool Visited;

        // path finding
        public float Fcost;
        public float Gcost;
        public float Hcost;

        public Point Parent; 

        public Tile(Point pos, Color color, int size, bool is_wall)
        {
            Pos = pos;
            isWall = is_wall;

            isStart = false;
            isEnd = false;

            Visited = false;

            _color = color;
            _size = size;
            Fcost = 0;
            Gcost = 0;
            Hcost = 0;

            Parent = new Point(-1, -1);
        }

        public void Draw (Graphics g)
        {
            _color = Color.White;
            if (isWall) _color = Color.Gray;
            if (isStart) _color = Color.Red;
            if (isEnd) _color = Color.Blue;
            g.FillRectangle(new SolidBrush(_color), Pos.X * _size, Pos.Y * _size, _size, _size);
        }

        public static bool AreCordsValid (int x, int y, int maxX, int maxY)
        {
            return !(x < 0 || x >= maxX || y < 0 || y >= maxY);
        }

        public static double GetDistance (Tile t1, Tile t2)
        {
            return Math.Sqrt(Math.Pow(t2.Pos.X - t1.Pos.X, 2) + Math.Pow(t2.Pos.Y - t2.Pos.X, 2));
        }

        public static List<Point> GetNeighbours (int x, int y, int maxX, int maxY, int min_step, bool cross_allowed)
        {
            List<Point> list = new List<Point>();
            for (int i = -min_step; i < min_step + 1; i += min_step)
            {
                for (int j = -min_step; j < min_step + 1; j += min_step)
                {
                    if (Tile.AreCordsValid(x + i, y + j, maxX, maxY))
                    {
                        if (cross_allowed)
                        {
                            if (i != 0 || j != 0) list.Add(new Point(x + i, y + j));
                        } else
                        {
                            if (i == 0 ^ j == 0) list.Add(new Point(x + i, y + j));
                        }
                    }
                }
            }
            return list;
        }
    }
}
