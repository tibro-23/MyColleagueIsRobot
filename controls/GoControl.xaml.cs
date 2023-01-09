using MyColleagueIsRobot.Game_Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GoControl.xaml
    /// </summary>
    public partial class GoControl : UserControl, IKontrolkaInstrukcji
    {
        private static readonly SoundPlayer step_sound = new SoundPlayer(@"resources/music/step_sound.wav");
        private static readonly SoundPlayer command_sound = new SoundPlayer(@"resources/music/dropCommand_sound.wav");

        /// <summary>
        /// Typ instrukcji do stworzenia po przeciągnięciu
        /// </summary>
        public Type? GoType { get; set; } = null;

        /// <summary>
        /// Konstruktor bezargumentowy
        /// </summary>
        public GoControl()
        {
            InitializeComponent();
            command_sound.Play();
        }

        /// <summary>
        /// Konstruktor z podanym typem instrukcji
        /// </summary>
        /// <param name="type">Typ instrukcji</param>
        public GoControl(Type type)
        {
            InitializeComponent();
            GoType = type;
            GoCommand.Content = type.Name;
        }

        /// <summary>
        /// Funkcjonalność danej instrukcji
        /// </summary>
        /// <param name="game">Referencja do instancji rozgrywki</param>
        /// <param name="id">Referencja nr instrukcji w panelu instrukcji</param>
        /// <returns>Numer instrukcji, którą gra powinna wykonać następną</returns>
        public int WykonajRuch(Game game, int id)
        {
            int x = Grid.GetColumn(game.playerControl);
            int y = Grid.GetRow(game.playerControl);

            int mapx = game.Pole_Gry.ColumnDefinitions.Count;
            int mapy = game.Pole_Gry.RowDefinitions.Count;

            String direction = ((ComboBoxItem)Direction.SelectedValue).Content as String;

            ObiektMapy? obiekt;
            switch (direction)
            {
                case "UP":
                    obiekt = game.IsObject(x, y - 1);
                    if (y > 0 && (obiekt == null || (obiekt != null && obiekt.stawalne)))
                    {
                        Grid.SetRow(game.playerControl, y - 1);
                        step_sound.Play();
                    }
                    break;
                case "DOWN":
                    obiekt = game.IsObject(x, y + 1);
                    if (y < mapy && (obiekt == null || (obiekt != null && obiekt.stawalne)))
                    {
                        Grid.SetRow(game.playerControl, y + 1);
                        step_sound.Play();
                    }        
                    break;
                case "LEFT":
                    obiekt = game.IsObject(x - 1, y);
                    if (x > 0 && (obiekt == null || (obiekt != null && obiekt.stawalne)))
                    {
                        Grid.SetColumn(game.playerControl, x - 1);
                        step_sound.Play();
                    }
                    break;
                case "RIGHT":
                    obiekt = game.IsObject(x + 1, y);
                    if (x < mapx && (obiekt == null || (obiekt != null && obiekt.stawalne)))
                    {
                        Grid.SetColumn(game.playerControl, x + 1);
                        step_sound.Play();
                    }
                    break;
                default:
                    break;
            }

            return id + 1;
        }

        /// <summary>
        /// Sprawdza czy wszystkie pola są wybrane w instrukcji
        /// </summary>
        /// <returns>Czy wszystkie pola są ustawione</returns>
        public bool CzyJestUstawiony()
        {
            if (Direction.SelectedItem == null)
            {
                GoCommand.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return false;
            }
            GoCommand.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            return true;
        }
    }
}
