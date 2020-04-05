﻿using CSharp_AsyncAwaitSample.Data;
using System.Windows;

namespace CSharp_AsyncAwaitSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }



    }



}