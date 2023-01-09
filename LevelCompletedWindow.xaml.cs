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
    /// Okno dialogowe wyskakujące po ukończeniu poziomu z przyciskiem powrotu do menu
    /// </summary>
    public partial class LevelCompletedWindow : Window
    {
        private static readonly SoundPlayer congratulationSound = new SoundPlayer(@"resources/music/congrats_sound.wav");
        private static readonly SoundPlayer clickSound = new SoundPlayer(@"resources/music/click_sound.wav");

        /// <summary>
        /// Domyślny konstruktor, inicjalizuje okno i odpala dźwięk zwycięstwa
        /// </summary>
        public LevelCompletedWindow()
        {
            InitializeComponent();
            congratulationSound.Play();
        }

        /// <summary>
        /// Funkcja odpalana przy kliknięciu zamknięcia okna
        /// </summary>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            DialogResult = true;
        }
    }
}
