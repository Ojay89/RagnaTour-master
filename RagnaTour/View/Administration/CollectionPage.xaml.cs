﻿using RagnaTour.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RagnaTour.Domain;




// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RagnaTour
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CollectionPage : Page
    {

        
        public CollectionPage()
        {
            this.InitializeComponent();
            
        }

        //private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
            
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        //private void MenuButton3_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(LoginPag));
        //}

        private void Hamburgerbutton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.mySplitView.IsPaneOpen = !this.mySplitView.IsPaneOpen;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object obj = LV.SelectedValue;

           Display dis=  (Display)obj;

            Minboks.Text = dis.Info.ToString();
        }

      
    }
}
