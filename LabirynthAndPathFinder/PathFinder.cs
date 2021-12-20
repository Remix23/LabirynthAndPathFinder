using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthAndPathFinder
{
    internal class PathFinder
    {
        public static void FindPath (Tile[,] board, Point start, Point end)
        {
            HashSet<Point> to_process = new HashSet<Point>();

            to_process.Add(start);

            while (to_process.Count > 0)
            {
                Point current = to_process.First();
                to_process.Remove(current);

                List<Point> neighbours = Tile.GetNeighbours(current.X, current.Y, board.GetLength(1), board.GetLength(0), 1, true);

                foreach (Point neighbour in neighbours)
                {
                    if (!board[neighbour.X, neighbour.Y].isWall)
                    {
                        float gCost = board[current.X, current.Y].Gcost + 0;
                        float hCost = (float)Tile.GetDistance(board[neighbour.X, neighbour.Y], board[end.X, end.Y]);
                        float fCost = gCost + hCost;
                        if (fCost < board[current.X, current.Y].Fcost)
                        {
                            board[neighbour.X, neighbour.Y].Parent = board[current.X, current.Y];
                            to_process.Add(neighbour);
                        }
                    }
                    if (board[neighbour.X, neighbour.Y].isEnd)
                    {
                        board[neighbour.X, neighbour.Y].Parent = board[current.X, current.Y];
                        to_process.Clear();
                        return;
                    }
                };
            }
        }

        public static List<Point> ReconstructPath(Tile[,] board, Point start, Point end)
        {
            List<Point> path = new List<Point>();
            path.Add(end);

            while (path.Last() != start)
            {
                Point last = path.Last();
                if (board[last.X, last.Y].Parent != null)
                {
                    path.Add(board[last.X, last.Y].Parent.Pos);
                }
            }
            return path;
        }
    }
}
