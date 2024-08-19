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
using System.Windows.Shapes;
using PhoneVM.Model;
using System.Data.Common;

namespace PhoneVM
{
    /// <summary>
    /// Interaction logic for MessengerWindow.xaml
    /// </summary>
    public partial class MessengerWindow : Window
    {
        private WindowProperties windowProperties;
        private DatabaseController databaseController;
        private LoginController member;
        public MessengerWindow()
        {
            InitializeComponent();
            windowProperties = new WindowProperties(this);

            databaseController = new DatabaseController();
        }

        public void setMember(LoginController member)
        {
            this.member = member;
            show_messsages();
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

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            Message message = new Message(this.member.getMember(), message_input.Text, DateTime.Now);
            MessageContainer.Children.Add(message_container(message));
            // Member temp = new Member(2, "Admin", "Admin", "admin@pedrobasson.com", "Admin01", DateTime.Now, 1);
            // Message temp_m = new Message(temp, "Yes, that works for me", DateTime.Now);
            // MessageContainer.Children.Add(message_container(temp_m));
            databaseController.insert_message(message);
        }

        private void show_messsages()
        {
            // MessageContainer
            List<Message> messages = this.member.getMessages();
            foreach (Message message in messages)
            {
                MessageContainer.Children.Add(message_container(message));
            }

        }

        private Border message_container(Message message)
        {
            Border border = new Border();
            if (message.getMember().getMemberID() == this.member.getMember().getMemberID())
            {
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffd700"));
                border.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a0ccff"));
                border.HorizontalAlignment = HorizontalAlignment.Left;
            }
            border.MaxWidth = 200;
            border.Margin = new Thickness(20, 10, 20, 0);
            border.CornerRadius = new CornerRadius(10);
            border.Padding = new Thickness(10, 0, 10, 0);
            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
            border.BorderThickness = new Thickness(1);

            StackPanel stackPanel = new StackPanel();

            TextBlock textBlock = new TextBlock();
            textBlock.Text = message.getMessage();
            textBlock.FontSize = 12;
            textBlock.FontWeight = FontWeights.DemiBold;
            textBlock.TextWrapping = TextWrapping.WrapWithOverflow;

            Label label = new Label();
            label.FontSize = 10;
            label.FontWeight = FontWeights.Light;
            label.HorizontalAlignment = HorizontalAlignment.Right;
            label.Content = message.getDateOfMessage();

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(label);

            border.Child = stackPanel;

            return border;
        }
    }
}
