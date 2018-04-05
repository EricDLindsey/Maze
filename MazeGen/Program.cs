using System;

namespace MazeGen
{
	class Program
	{
		static void Main()
		{
			Maze maze = new Maze(20, 20);

			do
			{
				maze.build();
				Console.WriteLine(maze.ToString());
				Console.WriteLine("Press 'Enter' to make a new maze or 'q' to quit.");
			}
			while(Console.ReadLine() != "q");
		}
	}
}