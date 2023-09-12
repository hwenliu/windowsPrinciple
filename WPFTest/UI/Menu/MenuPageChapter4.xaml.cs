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

namespace WPFTest.UI.Menu
{
    /// <summary>
    /// MenuPageChapter1.xaml 的交互逻辑
    /// </summary>
    public partial class MenuPageChapter4 : ChildPage
    {
        public MenuPageChapter4()
        {
            InitializeComponent();
        }

        private void ChildPage_Loaded(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy1");
        }

        private void sy1_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy1");
        }

        private void sy2_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy2");
        }

       

        private void sy3_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy3");
        }

        private void sy4_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy4");
        }

        private void sy5_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy5");
        }

        private void sy6_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy6");
        }

        private void sy7_Click(object sender, RoutedEventArgs e)
        {
            FireNextEvent("chapter4_sy7");
        }
    }
}
