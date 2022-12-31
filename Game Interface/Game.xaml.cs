using MyColleagueIsRobot.controls;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MyColleagueIsRobot.Game_Interface
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
       
        public Game()
        {
            InitializeComponent();
            StakPanel.Children.Add(new CommandTemplate("GoControl"));
            StakPanel.Children.Add(new CommandTemplate("JumpControl"));
            //StakPanel.Children.Add(new GoControl(typeof(string)));
            // StakPanel.Children.Add(new CommandTemplate("LONIAK"));
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = App.Current.MainWindow as MainWindow;
            if (mainWindow != null)
                mainWindow.BackToMenu();
        }

        
    }
}
