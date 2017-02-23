using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //TimingQuestions.TekstTilTal();
            //TimingQuestions.InstantiateArray();
            char[,] maze = null;
            ReadMaze(ref maze, "../../maze.txt");
            PrintMaze(maze);
            Console.ReadLine();
        }

        private static void ReadMaze(ref char[,] maze, string fileLocation)
        {
            FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
            {
                string line = String.Empty;
                if ((line = streamReader.ReadLine()) != null)
                {
                    string[] sizes = line.Split('x');
                    int width, height;
                    if (sizes.Count() == 2 && int.TryParse(sizes[0], out width) && int.TryParse(sizes[1], out height))
                    {
                        maze = new char[width, height];
                        int index = 0;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            for (int i = 0; i < line.Count(); i++)
                            {
                                maze[i, index] = (char)line[i];
                            }
                            index++;
                        }
                    }
                }
            }
        }

        private static void PrintMaze(char[,] maze)
        {
            Console.WriteLine("Maze: " + maze.GetLength(0) + " x " + maze.GetLength(1));
            for (int j = 0; j < maze.GetLength(0); j++)
            {
                for (int i = 0; i < maze.GetLength(1); i++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
