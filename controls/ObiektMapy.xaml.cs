using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Interaction logic for ObiektMapy.xaml
    /// </summary>
    public partial class ObiektMapy : UserControl
    {
        public bool stawalne { get; private set; }
        public ObiektMapy(bool stawalne = false)
        {
            InitializeComponent();
            this.stawalne = stawalne;
        }

        public ObiektMapy(ObiektMapy om)
        {
            InitializeComponent();

            // skopiuj wlasciwosci
            stawalne = om.stawalne;
            Grid.SetColumn(this, Grid.GetColumn(om));
            Grid.SetRow(this, Grid.GetRow(om));

            // skopiuj obrazek obiektu
            foreach (UIElement element in om.grid.Children)
                if (element is Image)
                    grid.Children.Insert(0, new Image() { Source = ((Image)element).Source });

            // skopiuj wnetrze obiektu
            foreach (UIElement element in om.wnetrze.Children)
                if (element is ObiektMapy)
                    wnetrze.Children.Add(new ObiektMapy((ObiektMapy)element));
        }
    }
}
