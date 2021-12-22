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

            while (board.Length > visited.Count && stack.Count > 0)
            {
                Point current = stack.First();
                board[current.X, current.Y].Visited = true;
                board[current.X, current.Y].isWall = false;

                List<Point> neighbours = Tile.GetNeighbours(current.X, current.Y, board.GetLength(0), board.GetLength(1), 2, false);

                neighbours = neighbours.Where( p => !board[p.X, p.Y].Visited ).ToList();

                if (neighbours.Count == 0) 
                {
                    stack.Pop();
                    continue;
                }

                Point connection = neighbours[rng.Next(neighbours.Count)];

                if (current.X < connection.X) board[current.X + 1, current.Y].isWall = false;
                else if (current.X > connection.X) board[current.X - 1, current.Y].isWall = false;
                else if (current.Y < connection.Y) board[current.X, current.Y + 1].isWall = false;
                else if (current.Y > connection.Y) board[current.X, current.Y - 1].isWall = false;

                stack.Push(connection);
            }
        }

        public static Point RandomPoint (int maxX, int maxY)
        {
            Random r = new Random();
            int x = Convert.ToInt32(r.NextDouble() * (maxX - 1));
            int y = Convert.ToInt32(r.NextDouble() * (maxY - 1));
            return new Point(x, y);
        }

        public static void ResetMaze (Tile[,] board)
        {
            foreach (Tile tile in board)
            {
                tile.Visited = false;
                tile.isWall = true;
            }
        }
    }
}
