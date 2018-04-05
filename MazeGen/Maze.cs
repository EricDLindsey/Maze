using System;
using System.Collections.Generic;

namespace MazeGen
{
	class Maze
	{
		public Maze(int w, int h)
		{
			grid = new Grid(w, h);
		}
		
		private Grid grid;
		
		public void build()
		{
			grid.Clear();
			Random r = new Random();
			Stack<Cell> stack = new Stack<Cell>();
			Cell curCell = grid.GetCell(r.Next(grid.Width) + ", " + r.Next(grid.Height));
			stack.Push(curCell);
			
			while(stack.Count > 0)
			{
				Dir[] openings = grid.GetUnvisited(curCell);

				if(openings.Length == 0)
				{
					curCell = stack.Pop();
				}
				else
				{
					int choose = r.Next(openings.Length);

					curCell.SetOpening(openings[choose]);
					curCell = grid.GetCell(curCell, openings[choose]);
					curCell.SetOpening(opposite(openings[choose]));

					stack.Push(curCell);
				}
			}
		}

		public override string ToString()
		{
			string s = "";

			for(int i = 0; i < grid.Width*2+1; i++)
				s += "_";
			s += "\n";

			for(int y = 0; y < grid.Height; y++)
			{
				for(int x = 0; x < grid.Width; x++)
				{
					if(!grid[x, y].IsOpen(Dir.West))
						s += "|";
					else
						s += "_";

					if(grid[x, y].IsOpen(Dir.South))
						s += " ";
					else
						s += "_";
				}

				s += "|\n";
			}

			return s;
		}

		private Dir opposite(Dir d)
		{
			Dir rd;

			switch(d)
			{
				case Dir.North:
					rd = Dir.South;
					break;
				case Dir.East:
					rd = Dir.West;
					break;
				case Dir.South:
					rd = Dir.North;
					break;
				case Dir.West:
					rd = Dir.East;
					break;
				default:
					rd = Dir.None;
					break;
			}

			return rd;
		}
	}
}