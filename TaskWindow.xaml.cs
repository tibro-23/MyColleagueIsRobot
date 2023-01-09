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
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private static readonly SoundPlayer clickSound = new SoundPlayer(@"resources/music/click_sound.wav");
        public TaskWindow()
        {
            InitializeComponent();
        }

        public TaskWindow(string title, string description)
        {
            InitializeComponent();
            titleLabel.Content = title;
            descriptionText.Text = description;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            DialogResult = true;
        }
    }
}
