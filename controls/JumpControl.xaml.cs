using MyColleagueIsRobot.Game_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyColleagueIsRobot.controls
{
    /// <summary>
    /// Kontrolka komendy skoku do instrukcji
    /// </summary>
    public partial class JumpControl : UserControl, IKontrolkaInstrukcji
    {
        private static readonly SoundPlayer command_sound = new SoundPlayer(@"resources/music/dropCommand_sound.wav");

        /// <summary>
        /// Typ instrukcji do stworzenia po przeciągnięciu
        /// </summary>
        public Type? JumpType { get; set; } = null;

        /// <summary>
        /// Konstruktor bezargumentowy
        /// </summary>
        public JumpControl()
        {
            InitializeComponent();
            command_sound.Play();
        }

        /// <summary>
        /// Konstruktor z podanym typem instrukcji
        /// </summary>
        /// <param name="type">Typ instrukcji</param>
        public JumpControl(Type type)
        {
            InitializeComponent();
            JumpType = type;
            JumpCommand.Content = type.Name;
        }

        /// <summary>
        /// Funkcjonalność danej instrukcji
        /// </summary>
        /// <param name="game">Referencja do instancji rozgrywki</param>
        /// <param name="id">Referencja nr instrukcji w panelu instrukcji</param>
        /// <returns>Numer instrukcji, którą gra powinna wykonać następną</returns>
        public int WykonajRuch(Game game, int id)
        {
            return (int)Destination.SelectedValue;
        }

        /// <summary>
        /// Sprawdza czy wszystkie pola są wybrane w instrukcji
        /// </summary>
        /// <returns>Czy wszystkie pola są ustawione</returns>
        public bool CzyJestUstawiony()
        {
            if (Destination.SelectedItem == null)
            {
                JumpCommand.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return false;
            }
            JumpCommand.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            return true;
        }
    }
}
