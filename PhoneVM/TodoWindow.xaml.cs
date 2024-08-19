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
using System.Windows.Shapes;

namespace PhoneVM
{
    /// <summary>
    /// Interaction logic for TodoWindow.xaml
    /// </summary>
    public partial class TodoWindow : Window
    {

        private WindowProperties windowProperties;
        private LoginController member;
        public TodoWindow()
        {
            InitializeComponent();
            windowProperties = new WindowProperties(this);
            show_list();
            /** TODO:
             * Make that if you click on the stackpanel that the input (Textbox) goes into focus
             *
            */
            
        }
        public void setMember(LoginController member)
        {
            this.member = member;
        }

        private void close(object sender, RoutedEventArgs e)
        {
            windowProperties.close_window(this.member);
        }
        private void minimise(object sender, RoutedEventArgs e)
        {
            windowProperties.minimise();
        }

        private void maximise(object sender, RoutedEventArgs e)
        {
            windowProperties.maximise();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void show_list()
        {
            ModelController modelController = new ModelController();
            foreach (Todo i in modelController.ArrayTodo())
            {
                todo_list.Children.Add(add_list(i));
            }
        }

        private Border add_list(Todo todo)
        {
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#eee"));
            border.BorderThickness = new Thickness(1);
            border.Margin = new Thickness(0, 5, 0, 5);
            border.Padding = new Thickness(10, 5, 10, 5);
            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CFFFFFF"));

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            
            RadioButton radioButton = new RadioButton();
            radioButton.Style = (Style)FindResource("RadioStyle");
            radioButton.VerticalAlignment = VerticalAlignment.Top;
            radioButton.Margin = new Thickness(0, 0, 5, 0);

            StackPanel small = new StackPanel();

            TextBox textBox = new TextBox();
            textBox.Text = todo.getTodo();
            textBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            textBox.Padding = new Thickness(1, 0, 0, 0);
            textBox.FontSize = 15;
            textBox.FontWeight = FontWeights.DemiBold;
            textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
            textBox.BorderThickness = new Thickness(0);

            Label label = new Label();
            label.VerticalAlignment = VerticalAlignment.Center;
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            label.FontSize = 12;
            label.FontWeight = FontWeights.Light;
            label.Content = "No extra information";
            
            border.Child = stackPanel;
            small.Children.Add(textBox);
            small.Children.Add(label);
            stackPanel.Children.Add(radioButton);
            stackPanel.Children.Add(small);

            return border;
        }

        private void EnterPressed(object sender, KeyboardEventArgs e)
        {
            // TODO: Check whether the enter key was pressed
            // TODO: Get the value of the textbox
            ModelController modelController = new ModelController();
            modelController.add_todo(new Todo("This is a test for adding todo"));
        }

        private void RemoveTodo(object sender, EventArgs e)
        {
            ModelController modelController = new ModelController();
        }
    }
}
