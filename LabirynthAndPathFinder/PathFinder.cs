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

                List<Point> neighbours = Tile.GetNeighbours(current.X, current.Y, board.GetLength(0), board.GetLength(1), 1, true);
                foreach (Point neighbour in neighbours)
                {
                    if (!board[neighbour.X, neighbour.Y].isWall)
                    {
                        float gCost = board[current.X, current.Y].Gcost + (float)Tile.GetDistance(board[neighbour.X, neighbour.Y], board[current.X, current.Y]);
                        float hCost = (float)Tile.GetDistance(board[neighbour.X, neighbour.Y], board[end.X, end.Y]);
                        float fCost = gCost + hCost;
                        board[neighbour.X, neighbour.Y].Gcost = Convert.ToInt32(gCost * 10);
                        board[neighbour.X, neighbour.Y].Hcost = Convert.ToInt32(hCost * 10);
                        board[neighbour.X, neighbour.Y].Fcost = Convert.ToInt32(fCost * 10);
                        board[neighbour.X, neighbour.Y].Parent = board[current.X, current.Y];
                        to_process.Add(neighbour);
                        if (board[neighbour.X, neighbour.Y].isEnd)
                        {
                            board[neighbour.X, neighbour.Y].Parent = board[current.X, current.Y];
                            return;
                        }
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
