using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    public class Terrain : ICreature
    {
        public string GetImageFileName()
        {
            return "Terrain.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
    }
    
    
    public class Player : ICreature
    {
        public string GetImageFileName()
        {
            return "Digger.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public CreatureCommand Act(int x, int y)
        {
            var command = new CreatureCommand();
            if CheckKey(System.Windows.Forms.Keys.Right,x + 1, MapWidth )
            if (Game.KeyPressed == System.Windows.Forms.Keys.Right 
                && x + 1 < Game.MapWidth && !(Game.Map[x + 1, y] is Sack))
                command.DeltaX = 1;
            if (Game.KeyPressed == System.Windows.Forms.Keys.Left && x - 1 >= 0 && !(Game.Map[x - 1, y] is Sack))
                command.DeltaX = -1;
            if (Game.KeyPressed == System.Windows.Forms.Keys.Down 
                && y + 1 < Game.MapHeight && !(Game.Map[x, y + 1] is Sack))
                command.DeltaY = 1;
            if (Game.KeyPressed == System.Windows.Forms.Keys.Up && y - 1 >= 0 && !(Game.Map[x, y - 1] is Sack))
                command.DeltaY = -1;
            return command;
        }

        private bool CheckKey(Keys side, int offset, int y, object limitationSide)
        {
            return Game.KeyPressed == side
                && offset < limitationSide
                && !(Game.Map[offset, y] is Sack)
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Sack || conflictedObject is Monster;
        }
    }
    
    public class Sack : ICreature
    {
        public int Counter;

        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            var command = new CreatureCommand();
            
            if (y + 1 < Game.MapHeight 
                && (Game.Map[x, y + 1] is null 
                    || (Counter > 0 && Game.Map[x, y + 1] is Player ))) 
            {
                command.DeltaY = 1;
                Counter++;
                return command;
            }
            if (Counter > 1 || y == Game.MapHeight)
            {
                command.TransformTo = new Gold();
                return command;
            }
            Counter = 0;
            return new CreatureCommand();        
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }
    }
    
    public class Gold : ICreature
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                Game.Scores += 10;
            else if (conflictedObject is Monster)
            {
                return true;
            }
            return true;
        }
    }

    class Monster : ICreature
    {
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public CreatureCommand Act(int x, int y)
        {
            CreatureCommand command = new CreatureCommand();
            
            return command;
        }
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return !(conflictedObject is Gold || conflictedObject is Player);
        }
    }
}                                           


