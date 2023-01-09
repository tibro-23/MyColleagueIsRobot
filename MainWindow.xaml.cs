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
    /// Główne okno gry
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMenu mainMenu { get; } = new MainMenu();
        private Game game { get; } = new Game();
        /// <summary>
        /// Konstruktor bezargumentowy. Po uruchomieniu od razu wczytuje menu główne
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            LoadMenu();       
        }

        /// <summary>
        /// Wczytuje i wyświetla stronę z menu głównym
        /// </summary>
        public void LoadMenu()
        {
            contentFrame.Navigate(mainMenu);
        }

        /// <summary>
        /// Wczytuje i zmiena stronę na grę z wybranym poziomem
        /// </summary>
        /// <param name="level">Numer poziomu do wczytania</param>
        public void LoadGame(int level)
        {
            contentFrame.Navigate(game);
            game.level = new Level(level);
            game.RestartLevel();
        }

        /// <summary>
        /// Wczytuje menu główne
        /// </summary>
        public void BackToMenu()
        {
            contentFrame.Navigate(mainMenu);
        }
       
    }
}
