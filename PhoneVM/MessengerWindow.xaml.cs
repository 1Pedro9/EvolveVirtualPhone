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
using PhoneVM.Controller;
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
            this.member = members.FirstOrDefault();

            List<Message> messages = modelController.messages();
            foreach (Message m in messages)
            {
                Console.WriteLine(m.ToString());
            }
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

        }

    }
}
