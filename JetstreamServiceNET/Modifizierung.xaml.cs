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
using System.Windows.Shapes;

namespace JetstreamServiceNET
{
    /// <summary>
    /// Interaction logic for Modifizierung.xaml
    /// </summary>
    public partial class Modifizierung : Window
    {
        public Modifizierung(string text)
        {
            InitializeComponent();
            lblTest.Content = text;
        }
    }
}