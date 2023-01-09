using MyColleagueIsRobot.controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyColleagueIsRobot.Game_Interface
{
    /// <summary>
    /// Zawiera wszystkie potrzebne informacje o poziomie
    /// </summary>
    public class Level
    {
        private BitmapImage biurko = new BitmapImage(new Uri("/resources/images/table.png", UriKind.Relative));
        private BitmapImage kawa = new BitmapImage(new Uri("/resources/images/kawa.png", UriKind.Relative));
        private BitmapImage złota_kratka = new BitmapImage(new Uri("/resources/images/gold.png", UriKind.Relative));

        /// <summary>
        /// Numer identyfikujący poziom
        /// </summary>
        public int LevelNumber { get; }

        /// <summary>
        /// Kolumna w której zaczyna postać gracza
        /// </summary>
        public int PlayerStartX { get; }

        /// <summary>
        /// Wiersz w którym zaczyna postać gracza
        /// </summary>
        public int PlayerStartY { get; }

        /// <summary>
        /// Funkcja sprawdzająca warunki ukończenia poziomu
        /// </summary>
        public Func<Game, int, int> LevelFunction { get; }

        /// <summary>
        /// Numer stanu dla którego poziom zostaje ukończony
        /// </summary>
        public int FinishedState { get; }

        /// <summary>
        /// Tytuł poziomu. Jest wyświetlany w oknie z treścią zadania
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Opis zadania dla danego poziomu. Jest wyświetlany w oknie z treścią zadania
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Lista przechowująca informację o wszystkich obiektach znajdujących się na planszy, które nie są graczem
        /// </summary>
        public List<ObiektMapy> LevelStaticObjects { get { return levelStaticObjectsSource.Select(om => new ObiektMapy(om)).ToList(); } }
        private List<ObiektMapy> levelStaticObjectsSource { get; set; }

        /// <summary>
        /// Konstruktor inicjalizujący dane o konkretnym poziomie
        /// </summary>
        /// <param name="level">Wybrany poziom</param>
        public Level(int level)
        {
            switch (level)
            {
                case 3:
                    LevelNumber = 3;
                    Title = "Elektruś dostarcza kawę";
                    Description = "To już trzeci dzień pracy. Elektruś dostał zlecenie, aby zanieść kawę ze swojego biurka do biurka kolegi z pracy. Ułóż instrukcję w taki sposób aby poprawnie wykonał zlecone mu zadanie. \n" +
                        "Powodzenia!";
                    PlayerStartX = 6;
                    PlayerStartY = 0;
                    FinishedState = 2;
                    LevelFunction = Level3Function;
                    levelStaticObjectsSource = new List<ObiektMapy>() 
                    {
                        CreateMapObject(złota_kratka, 7, 4, true),

                        CreateMapObject(biurko, 0, 4),
                        CreateMapObject(biurko, 7, 4, false, kawa),
                    };
                    break;
                case 2: // level 2
                    LevelNumber = 2;
                    Title = "Elektruś - Przerwa Obiadowa";
                    Description = "Jak dobrze wiesz w pracy potrzebna jest przerwa dlatego i Elektruś potrzebuje chwili aby podładować swoje baterie. Pomóż Elektrusiowi pokonać labirynt kroporacyjnego piekła, aby zdążył na przerwę zanim się skończy! \n" +
                        "Twoim zadaniem jest ułożenie odpowiedniej listy instrukcji tak aby udało mu się przejść na złote pole. \n" +
                        "Powodzenia!";
                    PlayerStartX = 0;
                    PlayerStartY = 5;
                    FinishedState = 1;
                    LevelFunction = Level2Function;
                    levelStaticObjectsSource = new List<ObiektMapy>()
                    {
                        CreateMapObject(złota_kratka, 7, 5, true),

                        CreateMapObject(biurko, 1, 1),
                        CreateMapObject(biurko, 1, 2, false, kawa),
                        CreateMapObject(biurko, 1, 3),
                        CreateMapObject(biurko, 1, 4),
                        CreateMapObject(biurko, 1, 5, false, kawa),

                        CreateMapObject(biurko, 3, 0, false, kawa),
                        CreateMapObject(biurko, 3, 1),
                        CreateMapObject(biurko, 3, 2),
                        CreateMapObject(biurko, 3, 3),
                        CreateMapObject(biurko, 3, 4),

                        CreateMapObject(biurko, 5, 1),
                        CreateMapObject(biurko, 5, 2),
                        CreateMapObject(biurko, 5, 3),
                        CreateMapObject(biurko, 5, 4, false, kawa),
                        CreateMapObject(biurko, 5, 5),

                        CreateMapObject(biurko, 7, 0),
                        CreateMapObject(biurko, 7, 1, false, kawa),
                        CreateMapObject(biurko, 7, 2),
                        CreateMapObject(biurko, 7, 3),
                        CreateMapObject(biurko, 7, 4),
                    };
                    break;
                default: // level 1
                    LevelNumber = 1;
                    Title = "Nowy kolega w pracy";
                    Description = "Firma zleciła ci zadanie. Musisz nauczyć nowego pracownika pracy w biurze. \n" +
                        "Poznaj swojego nowego kolegę - to Elektruś czyli świeży absolwent Politechniki Gdańskiej. \n" +
                        "Jeszcze nie potrafi wielu rzeczy, ale szybko sę uczy! Pomóż mu przejść z góry na dół, a następnie wrócić na pozycję początkową. \n" +
                        "Powodzenia!";
                    PlayerStartX = 3;
                    PlayerStartY = 0;
                    FinishedState = 2;
                    LevelFunction = Level1Function;
                    levelStaticObjectsSource = new List<ObiektMapy>()
                    {
                        CreateMapObject(złota_kratka, 0, 5, true),
                        CreateMapObject(złota_kratka, 1, 5, true),
                        CreateMapObject(złota_kratka, 2, 5, true),
                        CreateMapObject(złota_kratka, 3, 5, true),
                        CreateMapObject(złota_kratka, 4, 5, true),
                        CreateMapObject(złota_kratka, 5, 5, true),
                        CreateMapObject(złota_kratka, 6, 5, true),
                        CreateMapObject(złota_kratka, 7, 5, true),
                    };
                    break;
            }
        }

        /// <summary>
        /// Tworzy instancje obiektu znajdującego się na mapie
        /// </summary>
        /// <param name="image">Wyświetlany obrazek obiektu</param>
        /// <param name="column">Kolumna w której znajduje się obiekt</param>
        /// <param name="row">Rząd w którym znajduje się obiekt</param>
        /// <param name="stawalne">Czy gracz może stanąć na polu z tym obiektem</param>
        /// <param name="inside">Obrazek obiektu w środku, jeśli ma mieć obiekt w środku</param>
        /// <returns></returns>
        private ObiektMapy CreateMapObject (ImageSource image, int column, int row, bool stawalne = false, ImageSource inside = null)
        {
            ObiektMapy obj = new ObiektMapy(stawalne);
            Grid.SetColumn(obj, column);
            Grid.SetRow(obj, row);
            Image img = new Image() { Source = image };
            obj.grid.Children.Insert(0, img);
            if (inside != null)
                obj.wnetrze.Children.Add(CreateMapObject(inside, 0, 0));
            
            return obj;
        }

        private int Level1Function(Game game, int state)
        {
            switch (state)
            {
                case 0:
                    if (Grid.GetRow(game.playerControl) == game.Pole_Gry.RowDefinitions.Count - 1)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            ObiektMapy? kratka = game.IsObject(i, 5, false);
                            int index = game.Pole_Gry.Children.IndexOf(kratka);
                            game.Pole_Gry.Children.Remove(kratka);
                            game.Pole_Gry.Children.Insert(index, CreateMapObject(złota_kratka, i, 0, true));
                        }
                        return 1;
                    }
                    else
                        return 0;
                case 1:
                    if (Grid.GetRow(game.playerControl) == 0)
                        return 2;
                    else
                        return 1;
                default:
                    return 2;
            }
        }

        private int Level2Function(Game game, int state)
        {
            switch (state)
            {
                case 0:
                    if (Grid.GetRow(game.playerControl) == game.Pole_Gry.RowDefinitions.Count - 1 && Grid.GetColumn(game.playerControl) == game.Pole_Gry.ColumnDefinitions.Count - 1)
                        return 1;
                    else
                        return 0;
                default:
                    return 1;
            }
        }

        private int Level3Function(Game game, int state)
        {
            switch (state)
            {
                case 0:
                    if (game.playerControl.wnetrze.Children.Count > 0)
                    {
                        ObiektMapy? kratka = game.IsObject(7, 4, false);
                        int index = game.Pole_Gry.Children.IndexOf(kratka);
                        game.Pole_Gry.Children.Remove(kratka);
                        game.Pole_Gry.Children.Insert(index, CreateMapObject(złota_kratka, 0, 4, true));
                        return 1;
                    }
                    else
                        return 0;
                case 1:
                    if (game.IsObject(0, 4)?.wnetrze.Children.Count > 0)
                        return 2;
                    else
                        return 1;
                default:
                    return 2;
            }
        }
    }
}
