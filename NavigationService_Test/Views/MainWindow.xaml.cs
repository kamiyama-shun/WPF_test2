using System;
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
using System.Diagnostics;

namespace NavigationService_Test.Views
{


    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigationService _navi;

        private ViewPage1 s = new ViewPage1();

        private List<Uri> _uriList = new List<Uri>() {
                                new Uri("Views/ViewPage1.xaml", UriKind.Relative),
                                new Uri("Views/ViewPage2.xaml", UriKind.Relative),
                                new Uri("Views/ViewPage3.xaml", UriKind.Relative),
                                };

    public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("InitializeComponent");

            _navi = this.myFrame.NavigationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_navi.CanGoBack)
                _navi.GoBack();
            else
            {
                int index = _uriList.FindIndex(p => p == _navi.CurrentSource) - 1;
                _navi.Navigate(_uriList[index]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_navi.CanGoForward)
                _navi.GoForward();
            else
            {
                int index = _uriList.FindIndex(p => p == _navi.CurrentSource) + 1;
                _navi.Navigate(_uriList[index]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _navi.Navigate(_uriList[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myFrame_Navigated(object sender, NavigationEventArgs e)
        {
            int index = _uriList.IndexOf(_navi.CurrentSource);
            if (index <= 0)
                prevButton.IsEnabled = false;
            else
                prevButton.IsEnabled = true;

            if (index + 1 == _uriList.Count)
                nextButton.IsEnabled = false;
            else
                nextButton.IsEnabled = true;
        }
    }
}
