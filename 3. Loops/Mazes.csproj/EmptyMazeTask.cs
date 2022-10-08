namespace Mazes
{
    public static class EmptyMazeTask
    {		
        public static void MoveOut(Robot robot, int width, int height)
        {
            DoMove(robot, width - 3, Direction.Right);
            DoMove(robot, height - 3, Direction.Down);
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