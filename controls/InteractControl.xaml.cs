using MyColleagueIsRobot.Game_Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for InteractControl.xaml
    /// </summary>
    public partial class InteractControl : UserControl, IKontrolkaInstrukcji
    {
        private static readonly SoundPlayer command_sound = new SoundPlayer(@"resources/music/dropCommand_sound.wav");

        /// <summary>
        /// Typ instrukcji do stworzenia po przeciągnięciu
        /// </summary>
        public Type? GoType { get; set; } = null;

        /// <summary>
        /// Konstruktor bezargumentowy
        /// </summary>
        public InteractControl()
        {
            InitializeComponent();
            command_sound.Play();
        }

        /// <summary>
        /// Konstruktor z podanym typem instrukcji
        /// </summary>
        /// <param name="type">Typ instrukcji</param>
        public InteractControl(Type type)
        {
            InitializeComponent();
            GoType = type;
            InteractCommand.Content = type.Name;
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

            String direction = ((ComboBoxItem)Direction.SelectedValue).Content as String;

            ObiektMapy? obiekt = null;
            switch (direction)
            {
                case "UP":
                    obiekt = game.IsObject(x, y - 1);
                    break;
                case "DOWN":
                    obiekt = game.IsObject(x, y + 1);
                    break;
                case "LEFT":
                    obiekt = game.IsObject(x - 1, y);
                    break;
                case "RIGHT":
                    obiekt = game.IsObject(x + 1, y);
                    break;
                default:
                    break;
            }

            if (game.playerControl.wnetrze.Children.Count > 0) // jesli ma item w rece
            {
                if (obiekt != null && obiekt.wnetrze.Children.Count == 0)
                {
                    ObiektMapy? wnetrze = game.playerControl.wnetrze.Children[0] as ObiektMapy;
                    if (wnetrze != null)
                    {
                        game.playerControl.wnetrze.Children.Remove(wnetrze);
                        obiekt.wnetrze.Children.Add(wnetrze);
                    }
                }
            }
            else // jesli nie ma itemu w rece
            {
                if (obiekt != null && obiekt.wnetrze.Children.Count > 0)
                {
                    ObiektMapy? wnetrze = obiekt.wnetrze.Children[0] as ObiektMapy;
                    if (wnetrze != null)
                    {
                        obiekt.wnetrze.Children.Remove(wnetrze);
                        game.playerControl.wnetrze.Children.Add(wnetrze);
                    }
                }
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
                InteractCommand.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return false;
            }
            InteractCommand.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            return true;
        }
    }
}
