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

namespace WpfDataApp
{
    /// <summary>
    /// Interaction logic for CreateEditSeria.xaml
    /// </summary>
    public partial class CreateEditSeria : Window
    {
        public CreateEditSeria()
        {
            InitializeComponent();
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
