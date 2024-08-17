using MySql.Data.MySqlClient;
using PhoneVM.Controller;
using PhoneVM.Database;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private WindowProperties windowProperties;
        private DatabaseConnection dbConnection;
        private Member member;
        public LoginWindow()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            windowProperties = new WindowProperties(this);
        }

        public void setMember(Member member)
        {
            this.member = member;
        }

        private void login(object sender, RoutedEventArgs e)
        {
            string Username = username.Text.ToString();
            string Password = password.Text.ToString();

            string query = "SELECT * FROM members WHERE email = '" + Username + "' AND password = '" + Password + "'";

            
            MySqlConnection con = dbConnection.CreateNewConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Member member = new Member(
                                int.Parse(reader["member_id"].ToString()),
                                reader["firstname"].ToString(),
                                reader["lastname"].ToString(),
                                reader["email"].ToString(),
                                reader["password"].ToString(),
                                DateTime.Parse(reader["date_joined"].ToString()),
                                1
                            );

                MainWindow mw = new MainWindow();
                mw.setMember(member);
                mw.Show();
                this.Close();
            }
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

    }
}
