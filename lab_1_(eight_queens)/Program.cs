using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1__eight_queens_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            bool[,] test = new bool[8, 8] { { false, false, false, false, false, false, false, false },
                                            { false, true, false, false, false, false, false, false },
                                            { false, false, false, true, false, false, false, false },
                                            { false, false, false, false, false, false, true, false },
                                            { false, false, true, false, false, false, false, false },
                                            { false, false, false, false, false, false, false, false },
                                            { false, false, false, false, true, true, false, true },                                            
                                            { true, false, false, false, false, false, false, false } };
            
            Board b1 = new Board(8);
            b1.Generate();
            b1.Draw();
            Console.WriteLine(b1.СonflictsCount());
            AStar star = new AStar();
            List<bool[,]> q = new List<bool[,]>();
            List<bool[,]> chk = new List<bool[,]>();
            int iterations = 0;
            while (b1.СonflictsCount() != 0)
            {
                b1 = star.Search(b1, ref q, ref chk, ref iterations);
                //b1.Draw();
                //Console.WriteLine(b1.СonflictsCount());
                //Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Visited = " + chk.Count);
            Console.WriteLine("Iterations = "+ iterations);
            Console.WriteLine("Memory = " + q.Count);
            Console.ReadKey();

            Board b2 = new Board(8, test);
            //b2.Generate();
            b2.Draw();
            Console.WriteLine(b2.СonflictsCount());
            BFS bfs = new BFS();
            List<bool[,]> visited = new List<bool[,]>();
            Queue<bool[,]> que = new Queue<bool[,]>();
            bool[,]_second_map = new bool[b2.Size, b2.Size];
            _second_map = Help.Copy(b2.Size, b2.Map);
            que.Enqueue(_second_map);
            iterations = 0;
            while (b2.СonflictsCount() != 0)
            {
                b2 = bfs.Search(b2, ref que, ref visited, ref iterations);
                //b2.Draw();
                //Console.WriteLine(b2.СonflictsCount());
                //Console.WriteLine();
                //System.Threading.Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Visited = "+ visited.Count);
            Console.WriteLine("Iterations = " + iterations);
            Console.WriteLine("Memory = " + que.Count);
            Console.ReadKey();            
        }
    }
}
