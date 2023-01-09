using MyColleagueIsRobot.Game_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyColleagueIsRobot.controls
{
    /// <summary>
    /// Wspólny interfejs instrukcji
    /// </summary>
    public interface IKontrolkaInstrukcji
    {
        /// <summary>
        /// Wykonuje to co powinna robić dana instrukcja
        /// </summary>
        /// <param name="game">Referencja do instancji rozgrywki</param>
        /// <param name="id">Numer tej instrukcji w panelu instrukcji</param>
        /// <returns>Numer instrukcji, którą gra powinna wykonać następną</returns>
        public int WykonajRuch(Game game, int id);

        /// <summary>
        /// Sprawdza czy dana instrukcja ma wszystkie wartości do wyboru ustawione
        /// </summary>
        /// <returns>Czy wszystko jest ustawione</returns>
        public bool CzyJestUstawiony();
    }
}
