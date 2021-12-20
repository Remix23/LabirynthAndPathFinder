using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthAndPathFinder
{
    internal class MazeGenerator
    {
        public static void GenMaze (Tile[,] board, Point start)
        {
            Random rng = new Random();
            Stack<Point> stack = new Stack<Point>();
            List<Point> visited = new List<Point>();
            stack.Push(start);

            while (board.Length > visited.Count)
            {
                Point p = stack.First();

                List<Point> n = Tile.GetNeighbours(p.X, p.Y, board.GetLength(1), board.GetLength(0), 2, false);

                if (n.Count == 0) 
                {
                    stack.Pop();
                    continue;
                }

                Point connection = n[rng.Next(n.Count)];

                if (start.X < connection.X) board[start.X + 1, start.Y].isWall = true;
                else if (start.X > connection.X) board[start.X - 1, start.Y].isWall = true;
                else if (start.Y < connection.Y) board[start.X, start.Y + 1].isWall = true;
                else board[start.X, start.Y - 1].isWall = true;
            }
        }

        public static Point RandomPoint (int maxX, int maxY)
        {
            Random r = new Random();
            int x = Convert.ToInt32(r.NextDouble() * maxX);
            int y = Convert.ToInt32(r.NextDouble() * maxY);
            return new Point(x, y);
        }
    }
}
