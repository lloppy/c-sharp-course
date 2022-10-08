namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			if (width > height)
			{
				GoDiagonal(robot, width / height + 1, Direction.Right, Direction.Down);
			}
			GoDiagonal(robot, (height + 1) /width , Direction.Down, Direction.Right);
		}

		private static void GoDiagonal(Robot robot, int move, Direction firstMove, Direction secondMove)
		{
			while (!robot.Finished)
			{
				DoMove(robot, move, firstMove);
				if (robot.Finished) break;

				DoMove(robot, 1, secondMove);
			}
		}
		
		private static void DoMove(Robot robot, int width, Direction dir)
		{
			for (int step = 0; step < width; step++)
			{
				robot.MoveTo(dir);
			}
		}
	}
}