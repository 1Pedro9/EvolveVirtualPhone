using PhoneVM.Controller;
using System;
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

namespace PhoneVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowProperties windowProperties;
        public MainWindow()
        {
            InitializeComponent();
            windowProperties = new WindowProperties(this);

            /* TodoWindow todoWindow = new TodoWindow();
            todoWindow.Show();
            this.Close(); */
        }

        private void close(object sender, RoutedEventArgs e)
        {
            windowProperties.close();
            
        }
        private void Drag(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Console.WriteLine("Dragging the window");
                this.DragMove();
            }
        }
        private void minimise(object sender, RoutedEventArgs e)
        {
            windowProperties.minimise();
        }

        private void maximise(object sender, RoutedEventArgs e)
        {
            windowProperties.maximise();
        }

        private void Route_Calculator(object sender, RoutedEventArgs e)
        {
            CalculatorWindow calculatorWindow = new CalculatorWindow();
            calculatorWindow.Show();
            this.Close();
        }

        private void Route_Todo(object sender, RoutedEventArgs e)
        {
            TodoWindow todoWindow = new TodoWindow();
            todoWindow.Show();
            this.Close();
        }

        private void Route_Messenger(object sender, RoutedEventArgs e)
        {
            MessengerWindow messengerWindow = new MessengerWindow();
            messengerWindow.Show();
            this.Close();
        }
    }
}
