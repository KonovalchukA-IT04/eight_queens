using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1__eight_queens_
{
    public class AStar
    {
        public Board Search(Board map, ref List<bool[,]> q, ref List<bool[,]> chk, ref int iterations)
        {
            bool[,] _empty = new bool[map.Size, map.Size];
            _empty = Help.Copy(map.Size, map.Map);
            int cnt = map.СonflictsCount();
            bool[,] _blank = new bool[map.Size, map.Size];

            for (int j = 0; j < map.Size; j++)
            {
                _empty = Help.Copy(map.Size, map.Map);
                for (int i = 0; i < map.Size; i++)
                {
                    _empty[i, j] = false;
                }

                for (int i = 0; i < map.Size; i++)
                {
                    _empty[i, j] = true;
                    if (map.Map[i,j] != true)
                    {
                        q.Add(Help.Copy(map.Size, _empty));
                    }                    
                    _empty[i, j] = false;
                }                
            }

            bool key = true;
            while (key)
            {
                iterations++;
                key = false;
                int counter = 0;
                int clk = 0;
                foreach (bool[,] node in q)
                {
                    counter++;
                    if (cnt >= Board.СonflictsCount(map.Size, node))
                    {
                        cnt = Board.СonflictsCount(map.Size, node);
                        _blank = Help.Copy(map.Size, node);
                        clk = counter;
                    }

                }

                foreach (bool[,] node in chk)
                {
                    if(Help.Same(map.Size, _blank, node))
                    {
                        key = true;
                    }
                }
                if (key == false)
                    chk.Add(_blank);
                if (clk!=0)
                    q.RemoveAt(clk - 1);
            }

            return new Board(map.Size, _blank);
        }
    }
}
