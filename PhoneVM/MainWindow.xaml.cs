using PhoneVM.Controller;
using PhoneVM.Model;
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

        private Member member;
        public MainWindow()
        {
            InitializeComponent();
            windowProperties = new WindowProperties(this);
        }

        public void setMember(Member value)
        {
            this.member = value;
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
            if (member != null)
            {
                CalculatorWindow calculatorWindow = new CalculatorWindow();
                calculatorWindow.setMember(this.member);
                calculatorWindow.Show();
                this.Close();
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }

        private void Route_Todo(object sender, RoutedEventArgs e)
        {
            if (member != null)
            {
                TodoWindow todoWindow = new TodoWindow();
                todoWindow.setMember(this.member);
                todoWindow.Show();
                this.Close();
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }

        private void Route_Messenger(object sender, RoutedEventArgs e)
        {
            if (member != null)
            {
                MessengerWindow messengerWindow = new MessengerWindow();
                messengerWindow.setMember(this.member);
                messengerWindow.Show();
                this.Close();
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
