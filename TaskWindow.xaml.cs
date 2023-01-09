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
    /// Okno dialogowe z treścią zadania
    /// </summary>
    public partial class TaskWindow : Window
    {
        private static readonly SoundPlayer clickSound = new SoundPlayer(@"resources/music/click_sound.wav");
        /// <summary>
        /// Domyślny konstruktor bez arugmentów
        /// </summary>
        public TaskWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor z ustawieniem tytułu i opisu treści zadania
        /// </summary>
        /// <param name="title">Tytuł zadania</param>
        /// <param name="description">Treść zadania</param>
        public TaskWindow(string title, string description)
        {
            InitializeComponent();
            titleLabel.Content = title;
            descriptionText.Text = description;
        }

        /// <summary>
        /// Funkcja odpalana przy kliknięciu zamknięcia okna dialogowego z treścią zadania. Zamyka okno z treścią
        /// </summary>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            DialogResult = true;
        }
    }
}
