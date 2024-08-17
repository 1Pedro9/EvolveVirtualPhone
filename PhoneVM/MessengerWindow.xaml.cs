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

namespace PhoneVM
{
    /// <summary>
    /// Interaction logic for MessengerWindow.xaml
    /// </summary>
    public partial class MessengerWindow : Window
    {
        private WindowProperties windowProperties;
        private ModelController modelController;
        private Member member;
        private Message message;
        public MessengerWindow()
        {
            InitializeComponent();
            windowProperties = new WindowProperties(this);
            modelController = new ModelController();

            List<Member> members = modelController.members();

            this.member = modelController.searchMember(1);

            show_messsages();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            windowProperties.close_window();
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
            modelController.add_message(new Message(this.member, message_input.Text.ToString(), DateTime.Now));
        }

        private void show_messsages()
        {
            // MessageContainer
            List<Message> messages = modelController.messages();
            foreach (Message message in messages)
            {
                MessageContainer.Children.Add(message_container(message));
            }

        }

        private Border message_container(Message message)
        {
            Border border = new Border();
            if (message.getMember().getMemberID() == this.member.getMemberID())
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
            border.Margin = new Thickness(20, 10, 0, 0);
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
