﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Caliburn.Micro;
using System.ComponentModel;

namespace ReactiveUI.Samples.Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                mvvmLightContainer.DataContext = new MVVMLight.MainViewModel();
                reactiveUIContainer.DataContext = new RxUI.MainViewModel();

                //NOTE: Caliburn bootstrapper is created as part of 
                //      App resource dictionary (see App.xaml)
                caliburnMicroContainer.DataContext = new CaliburnMicro.MainViewModel();
            }
        }
    }
}
