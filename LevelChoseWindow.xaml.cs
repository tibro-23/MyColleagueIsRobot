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
using System.Windows.Shapes;
using System.Media;

namespace MyColleagueIsRobot
{
    /// <summary>
    /// Okno wyboru poziomu do wczytania
    /// </summary>
    public partial class LevelChoseWindow : Window
    {
        private static readonly SoundPlayer clickSound = new SoundPlayer(@"resources/music/click_sound.wav");

        /// <summary>
        /// Wybrany numer poziomu
        /// </summary>
        public int NumerPoziomu { get; set; }

        /// <summary>
        /// Inicjalizuje okno z wyborem poziomu
        /// </summary>
        public LevelChoseWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja odpalana po wciśnięciu przycisku zamknięcia okna
        /// </summary>
        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            DialogResult = true;
        }

        /// <summary>
        /// Wybranie poziomu nr 1
        /// </summary>
        private void level1_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            NumerPoziomu = 1;
            DialogResult = true;
        }

        /// <summary>
        /// Wybranie poziomu nr 2
        /// </summary>
        private void level2_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            NumerPoziomu = 2;
            DialogResult = true;
        }

        /// <summary>
        /// Wybranie poziomu nr 3
        /// </summary>
        private void level3_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            NumerPoziomu = 3;
            DialogResult = true;
        }
    }
}
