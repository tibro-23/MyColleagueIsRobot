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
    /// Interaction logic for JumpControl.xaml
    /// </summary>
    public partial class JumpControl : UserControl, IKontrolkaInstrukcji
    {
        private static readonly SoundPlayer command_sound = new SoundPlayer(@"resources/music/dropCommand_sound.wav");
        public Type? JumpType { get; set; } = null;
        public JumpControl()
        {
            InitializeComponent();
            command_sound.Play();
        }

        public JumpControl(Type type)
        {
            InitializeComponent();
            JumpType = type;
            JumpCommand.Content = type.Name;
        }

        public int WykonajRuch(Game game, int id)
        {
            return (int)Destination.SelectedValue;
        }

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
