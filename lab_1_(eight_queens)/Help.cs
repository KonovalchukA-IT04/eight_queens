using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1__eight_queens_
{
    public class Help
    {
        public static bool[,] Copy(int size, bool[,] fst)
        {
            bool[,] new_ar = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    new_ar[i, j] = fst[i, j];
                }
            }
            return new_ar;
        }

        public static bool Same(int size, bool[,] fst, bool[,] scd)
        {
            int count = 0;
            bool[,] new_ar = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (fst[i, j] == scd[i, j])
                        count++;
                }
            }
            if (count == (size*size))
            {
                return true;
            }
            return false;
        }
    }
}
