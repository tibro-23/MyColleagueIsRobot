using MyColleagueIsRobot.Game_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyColleagueIsRobot.controls
{
    public interface IKontrolkaInstrukcji
    {
        public int WykonajRuch(Game game, int id);
        public bool CzyJestUstawiony();
    }
}
