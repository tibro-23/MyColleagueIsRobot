using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyColleagueIsRobot.controls
{
    /// <summary>
    /// Interaction logic for InstrukcjePanel.xaml
    /// </summary>
    class ZmienneGlobalne
    {
        private static int idInstrukcji = 0;

        public static ObservableCollection<int> ids { get; set; } = new ObservableCollection<int>();

        public static int IdInstrukcji { get { return idInstrukcji; } set { idInstrukcji = value; } }

        public static void ZwiększID() 
        { 
            idInstrukcji++; 
            ids.Add(idInstrukcji); 
        }

        public static void ZmniejszID() 
        { 
            idInstrukcji--; 
            ids.RemoveAt(idInstrukcji);
        }
    }
    public partial class InstrukcjePanel : UserControl
    {
        

        public InstrukcjePanel()
        {
            InitializeComponent();
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            
            if (e.Data.GetDataPresent("Name"))
            {
                String name = (String)e.Data.GetData("Name");
                switch (name)
                {
                    case "GoControl":
                        ZmienneGlobalne.ZwiększID();
                        Panel.Children.Add(new InstructionContainer(new GoControl(), ZmienneGlobalne.IdInstrukcji, this));
                        break;

                    case "JumpControl":
                        ZmienneGlobalne.ZwiększID();
                        Panel.Children.Add(new InstructionContainer(new JumpControl(), ZmienneGlobalne.IdInstrukcji, this));
                        break;

                    case "IfControl":
                        ZmienneGlobalne.ZwiększID();
                        Panel.Children.Add(new InstructionContainer(new IfControl(), ZmienneGlobalne.IdInstrukcji, this));
                        break;

                    case "InteractControl":
                        ZmienneGlobalne.ZwiększID();
                        Panel.Children.Add(new InstructionContainer(new InteractControl(), ZmienneGlobalne.IdInstrukcji, this));
                        break;
                }
                e.Effects = DragDropEffects.Copy;
            }

            e.Handled = true;
        }

        public void ClearPanel()
        {
            foreach (InstructionContainer child in Panel.Children)
                ZmienneGlobalne.ZmniejszID();
            Panel.Children.Clear();
        }
    }
}
