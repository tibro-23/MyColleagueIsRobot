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
    /// Interaction logic for CommandTemplate.xaml
    /// </summary>
    public partial class CommandTemplate : UserControl
    {
        public String CommandType { get; set; } = "";
        public CommandTemplate()
        {
            InitializeComponent();
        }

        public CommandTemplate(String name)
        {
            InitializeComponent();
            CommandType = name;
            Komenda.Content = name.Replace("Control", "");
        }

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
