namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			while (!robot.Finished)
			{
				DoMove(robot, width - 3, Direction.Right);
				DoMove(robot, 2, Direction.Down);
				DoMove(robot, width - 3, Direction.Left);
				
				if (robot.Finished) break;
				DoMove(robot, 2, Direction.Down);
			}
		}
			
		private static void DoMove(Robot robot, int param, Direction dir)
		{
			for (int step = 0; step < param; step++)
			{
				robot.MoveTo(dir);
			}
		}
	}
}