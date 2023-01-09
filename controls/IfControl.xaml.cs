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
    /// Interaction logic for IfControl.xaml
    /// </summary>
    public partial class IfControl : UserControl, IKontrolkaInstrukcji
    {
        private static readonly SoundPlayer command_sound = new SoundPlayer(@"resources/music/dropCommand_sound.wav");
        public Type? IfType { get; set; } = null;
        public IfControl()
        {
            InitializeComponent();
            command_sound.Play();
        }

        public IfControl(Type type)
        {
            InitializeComponent();
            IfType = type;
            IfCommand.Content = type.Name;
        }

        public int WykonajRuch(Game game, int id)
        {
            String direction = ((ComboBoxItem)Direction.SelectedValue).Content as String;
            String condition = ((ComboBoxItem)Condition.SelectedValue).Content as String;

            int conditionX = Grid.GetColumn(game.playerControl);
            int conditionY = Grid.GetRow(game.playerControl);

            switch (direction)
            {
                case "UP":
                    conditionY--;
                    break;
                case "DOWN":
                    conditionY++;
                    break;
                case "RIGHT":
                    conditionX++;
                    break;
                case "LEFT":
                    conditionX--;
                    break;
                default:
                    break;
            }

            switch (condition)
            {
                case "WALL":
                    int mapx = game.Pole_Gry.ColumnDefinitions.Count;
                    int mapy = game.Pole_Gry.RowDefinitions.Count;

                    if (conditionX < 0 || conditionY < 0 || conditionX >= mapx || conditionY >= mapy)
                        return (int)Destination.SelectedValue;
                    else
                        return (int)AltDestination.SelectedValue;
                case "OBJECT":
                    if (game.IsObject(conditionX, conditionY) != null)
                        return (int)Destination.SelectedValue;
                    else
                        return (int)AltDestination.SelectedValue;
                default:
                    break;
            }

            return -1;
        }

        public bool CzyJestUstawiony()
        {
            if (Direction.SelectedItem == null)
            {
                IfCommand.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return false;
            }
            IfCommand.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (Condition.SelectedItem == null)
            {
                Is.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return false;
            }
            IfCommand.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (Destination.SelectedItem == null)
            {
                Then.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return false;
            }
            IfCommand.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (AltDestination.SelectedItem == null)
            {
                Else.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return false;
            }
            IfCommand.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            return true;
        }
    }
}
