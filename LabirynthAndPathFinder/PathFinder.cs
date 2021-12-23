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
            PriorityQueue<Point, float> to_process = new PriorityQueue<Point, float>();

            board[start.X, start.Y].Gcost = 0;
            board[start.X, start.Y].Fcost = float.MaxValue;

            to_process.Enqueue(start, board[start.X, start.Y].Fcost);

            while (to_process.Count > 0)
            {
                Point current = to_process.Dequeue();

                List<Point> neighbours = Tile.GetNeighbours(current.X, current.Y, board.GetLength(0), board.GetLength(1), 1, true);
                foreach (Point neighbour in neighbours)
                {
                    if (!board[neighbour.X, neighbour.Y].isWall)
                    {
                        float gCost = board[current.X, current.Y].Gcost + (float)Tile.GetDistance(board[neighbour.X, neighbour.Y], board[current.X, current.Y]);
                        float hCost = (float)Tile.GetDistance(board[neighbour.X, neighbour.Y], board[end.X, end.Y]);
                        float fCost = gCost + hCost;
                        
                        if (board[neighbour.X, neighbour.Y].Fcost > fCost)
                        {
                            if (board[neighbour.X, neighbour.Y].Parent == new Point(-1, -1))
                            {
                                board[neighbour.X, neighbour.Y].Gcost = gCost;
                                board[neighbour.X, neighbour.Y].Hcost = hCost;
                                board[neighbour.X, neighbour.Y].Fcost = fCost;
                                board[neighbour.X, neighbour.Y].Parent = current;
                                to_process.Enqueue(neighbour, fCost);
                            }
                        }
                        
                        if (board[neighbour.X, neighbour.Y].isEnd)
                        {
                            board[neighbour.X, neighbour.Y].Parent = current;
                            return;
                        }
                    }
                };
            }
        }

        public static List<Point> ReconstructPath(Tile[,] board, Point start, Point end)
        {
            List<Point> path = new List<Point>();
            path.Add(board[end.X, end.Y].Parent);

            while (path.Last() != start)
            {
                Point last = path.Last();
                if (board[last.X, last.Y].Parent != null)
                {
                    path.Add(board[last.X, last.Y].Parent);
                }
            }
            path.Reverse();
            path.Remove(start);
            return path;
        }

        public static void ResetSceneForSearch (Tile[,] board)
        {
            foreach (Tile tile in board)
            {
                tile.Hcost = float.MaxValue;
                tile.Gcost = float.MaxValue;
                tile.Fcost = float.MaxValue;
                tile.Parent = new Point(-1, -1);
            }
        }
    }
}
