using MyColleagueIsRobot.Game_Interface;
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
using System.Media;

namespace MyColleagueIsRobot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMenu mainMenu { get; } = new MainMenu();
        private Game game { get; } = new Game();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            LoadMenu();       
            
        }

        public void LoadMenu()
        {
            contentFrame.Navigate(mainMenu);
        }

        public void LoadGame()
        {
            contentFrame.Navigate(game);
        }

        public void BackToMenu()
        {
            contentFrame.Navigate(mainMenu);
        }
       
    }
}
