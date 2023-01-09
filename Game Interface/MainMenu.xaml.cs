﻿using MyColleagueIsRobot.controls;
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

namespace MyColleagueIsRobot.Game_Interface
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private static readonly SoundPlayer clickSound = new SoundPlayer(@"resources/music/click_sound.wav");
        public MainMenu()
        {
            InitializeComponent();
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            MainWindow? mainWindow = App.Current.MainWindow as MainWindow;
            if(mainWindow != null)
                mainWindow.Close();
        }

        private void new_game_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            MainWindow? mainWindow = App.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                // otworz okno 
                LevelChoseWindow dialog = new LevelChoseWindow();
                // showdialog
                dialog.Owner = mainWindow;
                dialog.ShowDialog();
                int level = dialog.NumerPoziomu;

                        
                mainWindow.LoadGame(level);
            }
        }
    }
}
