﻿using System;
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
    /// Interaction logic for InstrukcjePanel.xaml
    /// </summary>
    class ZmienneGlobalne
    {
        private static int idInstrukcji = 0;
        public static int IdInstrukcji { get { return idInstrukcji; } set { idInstrukcji = value; } }
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
                System.Diagnostics.Debug.WriteLine(name);
                switch (name)
                {
                    case "GoControl":
                        ZmienneGlobalne.IdInstrukcji++;
                        Panel.Children.Add(new InstructionContainer(new GoControl(), ZmienneGlobalne.IdInstrukcji,this));
                        //Panel.Children.Add(new CommandTemplate("GoControl"));
                        break;

                    case "JumpControl":
                        ZmienneGlobalne.IdInstrukcji++;
                        Panel.Children.Add(new InstructionContainer(new JumpControl(),ZmienneGlobalne.IdInstrukcji,this));
                       // Panel.Children.Add(new CommandTemplate("JumpControl"));
                        break;
                    
                       
                }
                e.Effects = DragDropEffects.Copy;
            }

            e.Handled = true;
            
            
        }
    }
}
