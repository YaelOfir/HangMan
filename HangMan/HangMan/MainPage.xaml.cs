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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HangMan
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GameLogic gameLogic;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded; //מריץ את המשחק- כל פעם עובר דרכה
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            gameLogic = new GameLogic(gameCnv, this, hangMan); // מגדירה ללוגיקה ולבורד את הקמבאס של המשחק
        }
        private void easy_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.SelectWord(((Button)sender).Name.ToString());
            OpenScreen.Visibility = Visibility.Collapsed;
            gameCnv.Visibility = Visibility.Visible;
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            loser.Visibility = Visibility.Collapsed;
            OpenScreen.Visibility = Visibility.Visible;
        }
    }
}
