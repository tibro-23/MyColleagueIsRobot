using MyColleagueIsRobot.controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Strona z interfejsem i logiką rozgrywki
    /// </summary>
    public partial class Game : Page
    {
        private static readonly SoundPlayer clickSound = new SoundPlayer(@"resources/music/click_sound.wav");

        /// <summary>
        /// Czy gra jest w trakcie symulacji
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Referencja do obiektu z danymi o wczytanym poziomie
        /// </summary>
        public Level? level { get; set; } = null;

        /// <summary>
        /// Referencja do obiektu gracza na planszy
        /// </summary>
        public Player playerControl { get; private set; } = new Player();

        /// <summary>
        /// Inicjalizuje interfejs rozgrywki. Dodaje dostępne komendy do panelu komend
        /// </summary>
        public Game()
        {
            InitializeComponent();
            StakPanel.Children.Add(new CommandTemplate("GoControl"));
            StakPanel.Children.Add(new CommandTemplate("JumpControl"));
            StakPanel.Children.Add(new CommandTemplate("IfControl"));
            StakPanel.Children.Add(new CommandTemplate("InteractControl"));
        }

        /// <summary>
        /// Wraca do menu głównego. Przed powrotem do menu zatrzymuje rozgrywke
        /// </summary>
        private async void back_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            MainWindow? mainWindow = App.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                IsRunning = false;
                await Task.Delay(250); // zaczekaj na ostatnia instrukcje
                RestartLevel();
                mainWindow.BackToMenu();
            }
        }

        /// <summary>
        /// Czyści panel z ułożonymi instrukcjami
        /// </summary>
        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound?.Play();
            instrukcjePanel.ClearPanel();
        }

        /// <summary>
        /// Rozpoczyna symulacje gry według ustawionych instrukcji
        /// </summary>
        private async void start_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            if (level != null)
            {
                int licznik = 0;
                int liczba_instrukcji = 0;
                int stan_gry = 0;
                List<IKontrolkaInstrukcji> instrukcjeList = new List<IKontrolkaInstrukcji>();

                // zebranie wszystkich instrukcji
                foreach (Object child in instrukcjePanel.Panel.Children)
                {
                    InstructionContainer? container = child as InstructionContainer;
                    if (container != null)
                    {
                        IKontrolkaInstrukcji? instrukcja = container.TypKontrolki.Children[0] as IKontrolkaInstrukcji;
                        if (instrukcja != null)
                        {
                            instrukcjeList.Add(instrukcja);
                            liczba_instrukcji++;
                        }
                    }
                }

                // sprawdzenie czy sa w ogole instrukcje
                if (instrukcjeList.Count < 1)
                    return;

                // sprawdzenie czy instrukcje są poprawne
                foreach (IKontrolkaInstrukcji instrukcja in instrukcjeList)
                    if (!instrukcja.CzyJestUstawiony())
                        return;

                IsRunning = true;
                start_button.IsEnabled = false;
                stop_button.IsEnabled = true;
                instrukcjePanel.AllowDrop = false; // na czas trwania wylaczyc dodawanie instrukcji
                instrukcjePanel.IsEnabled = false; // na czas trwania wylaczyc wszystkie przyciski

                // wykonywanie programu
                while (licznik < liczba_instrukcji && IsRunning)
                {
                    int id = licznik;
                    instrukcjePanel.Panel.Children[id].Opacity = 0.5;
                    await Task.Delay(250);
                    licznik = instrukcjeList[id].WykonajRuch(this, id + 1) - 1;
                    instrukcjePanel.Panel.Children[id].Opacity = 1.0;

                    stan_gry = level.LevelFunction(this, stan_gry);
                    if (stan_gry == level.FinishedState && IsRunning)
                    {
                        MainWindow? mainWindow = App.Current.MainWindow as MainWindow;
                        if (mainWindow != null)
                        {
                            LevelCompletedWindow dialog = new LevelCompletedWindow();
                            dialog.Owner = mainWindow;
                            dialog.ShowDialog();
                            instrukcjePanel.ClearPanel();
                            mainWindow.LoadMenu();
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Zatrzymuje symulacje rozgrywki
        /// </summary>
        private async void stop_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            IsRunning = false;
            await Task.Delay(250); // zaczekaj na ostatnia instrukcje
            RestartLevel();
        }

        /// <summary>
        /// Wyświetla okno z treścią zadania
        /// </summary>
        private void task_button_Click(object sender, RoutedEventArgs e)
        {
            clickSound.Play();
            MainWindow? mainWindow = App.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                TaskWindow dialog = new TaskWindow(level.Title, level.Description);
                dialog.Owner = mainWindow;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Przywraca stan początkowy poziomu
        /// </summary>
        public void RestartLevel()
        {
            // usun obiekty
            Pole_Gry.Children.Clear();
            playerControl.wnetrze.Children.Clear();

            // narysuj siatke
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid kratka = new Grid();
                    Grid.SetColumn(kratka, i);
                    Grid.SetRow(kratka, j);
                    if ((i + j) % 2 == 0)
                        kratka.Background = (SolidColorBrush)App.Current.FindResource("OddTile");
                    else
                        kratka.Background = (SolidColorBrush)App.Current.FindResource("EvenTile");
                    Pole_Gry.Children.Add(kratka);
                }
            }

            // wczytaj poziom
            if (level != null)
            {
                level = new Level(level.LevelNumber);
                foreach (UIElement staticObject in level.LevelStaticObjects)
                    Pole_Gry.Children.Add(staticObject);

                Grid.SetColumn(playerControl, level.PlayerStartX);
                Grid.SetRow(playerControl, level.PlayerStartY);
                Pole_Gry.Children.Add(playerControl);
            }

            // ustaw interfejs
            IsRunning = false;
            instrukcjePanel.AllowDrop = true;
            instrukcjePanel.IsEnabled = true;
            start_button.IsEnabled = true;
            stop_button.IsEnabled = false;
        }

        ///<summary>
        /// Pobiera pierwszy obiekt typu ObiektMapy po numerze kolumny i wiersza na mapie
        ///</summary>
        ///<param name="x">Numer kolumny</param>
        ///<param name="y">Numer rzędu</param>
        ///<param name="ignoreStawalne">Czy ignorować stawalne ObiektyMapy</param>
        ///<returns>Pierwszy znaleziony obiekt mapy w danym miejscu, jeśli jest tam jakiś</returns>
        public ObiektMapy? IsObject(int x, int y, bool ignoreStawalne = true)
        {
            foreach (UIElement child in Pole_Gry.Children)
            {
                if (child is ObiektMapy && child != playerControl)
                {
                    if (ignoreStawalne && ((ObiektMapy)child).stawalne)
                        continue;

                    if (Grid.GetColumn(child) == x && Grid.GetRow(child) == y)
                        return child as ObiektMapy;
                }
            }

            return null;
        }
    }
}
