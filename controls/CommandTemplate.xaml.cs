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
    /// Interaction logic for CommandTemplate.xaml
    /// </summary>
    public partial class CommandTemplate : UserControl
    {
        public Type? CommandType { get; set; } = null;
        public CommandTemplate()
        {
            InitializeComponent();
        }

        public CommandTemplate(Type type)
        {
            InitializeComponent();
            CommandType = type;
            Komenda.Content = type.Name;
        }
    }
}
