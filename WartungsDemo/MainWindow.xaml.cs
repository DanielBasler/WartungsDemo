using System.Collections.Generic;
using System.Windows;

namespace WartungsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InitHandler initHandler = new InitHandler();
        List<string> vectorValues = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            ListVectorValues.ItemsSource = null;
            vectorValues.Clear();

            vectorValues = initHandler.setInitNeuralNetwork();
            ListVectorValues.ItemsSource = vectorValues;
            ButtonOk.IsEnabled = false;
        }
    }
}
