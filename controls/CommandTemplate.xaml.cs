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
    /// Obiekt komendy do wyboru
    /// </summary>
    public partial class CommandTemplate : UserControl
    {
        /// <summary>
        /// Typ komendy, który reprezentuja dana instancja instrukcji
        /// </summary>
        public String CommandType { get; set; } = "";

        /// <summary>
        /// Domyślny konstruktor
        /// </summary>
        public CommandTemplate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicjalizuje kontrolkę
        /// </summary>
        /// <param name="name">Nazwa instrukcji, którą reprezentuje</param>
        public CommandTemplate(String name)
        {
            InitializeComponent();
            CommandType = name;
            Komenda.Content = name.Replace("Control", "");
        }

        /// <summary>
        /// Funkcja inicjalizująca przeciąganie myszką
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("Name",CommandType);
                
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }

    }
}
