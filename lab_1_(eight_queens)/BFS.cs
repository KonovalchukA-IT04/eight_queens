using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1__eight_queens_
{
    public class BFS
    {
        public Board Search(Board map, ref Queue<bool[,]> que, ref List<bool[,]> visited, ref int iterations)
        {
            bool enter_key = true;
            while(enter_key)    //
            {
                iterations++;
                enter_key = false;
                foreach (bool[,] matrix in visited)
                {
                    if (Help.Same(map.Size, que.Peek(), matrix))
                    {
                        que.Dequeue();
                        //return new Board(map.Size, que.Peek());
                        enter_key = true;
                    }
                }
            }            

            bool[,] _empty = new bool[map.Size, map.Size];
            _empty = Help.Copy(map.Size, que.Peek());
            bool[,] _blank = new bool[map.Size, map.Size];

            for (int j = 0; j < map.Size; j++)
            {
                _empty = Help.Copy(map.Size, que.Peek());
                for (int i = 0; i < map.Size; i++)
                {
                    _empty[i, j] = false;
                }

                for (int i = 0; i < map.Size; i++)
                {
                    _empty[i, j] = true;
                    if (map.Map[i, j] != true)
                    {
                        que.Enqueue(Help.Copy(map.Size, _empty));
                    }
                    _empty[i, j] = false;
                }
            }

            visited.Add(que.Peek());
            return new Board(map.Size, que.Dequeue());
        }
    }
}
