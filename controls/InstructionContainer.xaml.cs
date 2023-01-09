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

namespace MyColleagueIsRobot.controls
{
    /// <summary>
    /// Wspólny kontener dla wszystkich instrukcji w panelu instrukcji. Posiada przyciski przesuwania i usuwania instrukcji
    /// </summary>
    public partial class InstructionContainer : UserControl
    {
        private InstrukcjePanel instrukcjePanel { get; }

        /// <summary>
        /// Numer na liście instrukcji
        /// </summary>
        public int IdInstrukcji { get; set; }

        /// <summary>
        /// Domyślny konstruktor
        /// </summary>
        public InstructionContainer()
        {
            InitializeComponent();
            this.instrukcjePanel = null;
        }

        /// <summary>
        /// Inicjalizuje kontener na instrukcje z podaną instrukcją w środku
        /// </summary>
        /// <param name="name">Instrukcja do włożenia do kontenera</param>
        /// <param name="numer">Numer instrukcji w liście instrukcji</param>
        /// <param name="instrukcjePanel">Referencja do listy instrukcji</param>
        public InstructionContainer(Control name, int numer, InstrukcjePanel instrukcjePanel)
        {
            InitializeComponent();
            TypKontrolki.Children.Add(name);
            NumerInstrukcji.Content = numer;
            this.instrukcjePanel = instrukcjePanel;
        }

        /// <summary>
        /// Przesuwa instrukcje do góry po wciśnięciu odpowiedniego przycisku
        /// </summary>
        private void sort_up_Click(object sender, RoutedEventArgs e)
        {
            if (this.NumerInstrukcji.Content != null)
            {
                if ((int)this.NumerInstrukcji.Content > 1)
                {
                    InstructionContainer container = (InstructionContainer)this.instrukcjePanel.Panel.Children[(int)this.NumerInstrukcji.Content - 2];
                    this.instrukcjePanel.Panel.Children.RemoveAt((int)this.NumerInstrukcji.Content - 2);
                    this.instrukcjePanel.Panel.Children[(int)this.NumerInstrukcji.Content - 2] = this;
                    this.instrukcjePanel.Panel.Children.Insert((int)this.NumerInstrukcji.Content - 1, container);
                    int content = (int)container.NumerInstrukcji.Content;
                    container.NumerInstrukcji.Content = (int)this.NumerInstrukcji.Content;
                    this.NumerInstrukcji.Content = content;
                }
            }
        }

        /// <summary>
        /// Przesuwa instrukcje w dół po wciśnięciu odpowiedniego przycisku
        /// </summary>
        private void sort_down_Click(object sender, RoutedEventArgs e)
        {
            if (this.NumerInstrukcji.Content != null)
            {
                if ((int)this.NumerInstrukcji.Content < ZmienneGlobalne.IdInstrukcji)
                {
                    InstructionContainer container = (InstructionContainer)this.instrukcjePanel.Panel.Children[(int)this.NumerInstrukcji.Content];
                    this.instrukcjePanel.Panel.Children.RemoveAt((int)this.NumerInstrukcji.Content - 1);
                    this.instrukcjePanel.Panel.Children.RemoveAt((int)this.NumerInstrukcji.Content - 1);
                    this.instrukcjePanel.Panel.Children.Insert((int)this.NumerInstrukcji.Content - 1, this);
                    this.instrukcjePanel.Panel.Children.Insert((int)this.NumerInstrukcji.Content - 1, container);
                    int content = (int)container.NumerInstrukcji.Content;
                    container.NumerInstrukcji.Content = (int)this.NumerInstrukcji.Content;
                    this.NumerInstrukcji.Content = content;
                }
            }
        }

        /// <summary>
        /// Usuwa instrukcje z listy instrukcji
        /// </summary>
        private void delete_instruction_Click(object sender, RoutedEventArgs e)
        {
            if (this.NumerInstrukcji.Content != null)
            {
                if ((int)this.NumerInstrukcji.Content >= 0)
                {
                    this.instrukcjePanel.Panel.Children.RemoveAt((int)this.NumerInstrukcji.Content - 1);
                    ZmienneGlobalne.ZmniejszID();
                    foreach (InstructionContainer container in this.instrukcjePanel.Panel.Children)
                    {
                        if ((int)container.NumerInstrukcji.Content > (int)this.NumerInstrukcji.Content)
                        {
                            container.NumerInstrukcji.Content = (int)container.NumerInstrukcji.Content - 1;
                        }
                    }
                }
            }
        }
    }
}
