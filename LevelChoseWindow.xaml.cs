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
    /// Interaction logic for LevelChoseWindow.xaml
    /// </summary>
    /// 
    //class xd
    //{
    //    public static int NumerPoziomu { get; set; }
    //}
    public partial class LevelChoseWindow : Window
    {
        private static readonly SoundPlayer clickSound = new SoundPlayer(@"resources/music/click_sound.wav");
        public int NumerPoziomu { get; set; }

        public LevelChoseWindow()
        {
            InitializeComponent();
        }


        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            DialogResult = true;
        }

        private void level1_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            NumerPoziomu = 1;
            DialogResult = true;
        }

        private void level2_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            NumerPoziomu = 2;
            DialogResult = true;
        }

        private void level3_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            NumerPoziomu = 3;
            DialogResult = true;
        }
    }
}
