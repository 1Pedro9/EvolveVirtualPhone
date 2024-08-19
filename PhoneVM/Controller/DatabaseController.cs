using MySql.Data.MySqlClient;
using PhoneVM.Database;
using PhoneVM.Model;
using System;
using System.Collections.Generic;

namespace PhoneVM.Controller
{
    internal class DatabaseController
    {
        private readonly DatabaseConnection dbConnection;

        public DatabaseController()
        {
            dbConnection = new DatabaseConnection();
        }

        public List<Member> members()
        {
            List<Member> array = new List<Member>();
            string query = "SELECT * FROM members WHERE is_admin = 1";

            using (MySqlConnection conn = dbConnection.CreateNewConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            array.Add(new Member(int.Parse(reader["member_id"].ToString()), reader["firstname"].ToString(), reader["lastname"].ToString(), reader["email"].ToString(), reader["password"].ToString(), DateTime.Parse(reader["date_joined"].ToString()), 1));
                        }
                    }
                }
            }

            return array;
        }

        public Member searchMember(int id)
        {
            Member a = null;
            foreach (Member member in members())
            {
                if (member.getMemberID() == id)
                {
                    a = member;
                }
            }
            return a;
        }

        public List<Message> messages()
        {
            List<Message> array = new List<Message>();
            string query = "SELECT * FROM messages";

            using (MySqlConnection conn = dbConnection.CreateNewConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            array.Add(new Message(searchMember(int.Parse(reader["member_id"].ToString())), reader["message"].ToString(), DateTime.Parse(reader["date_of_message"].ToString())));
                        }
                    }
                }
            }

            return array;
        }

        public void insert_message(Message message)
        {
            string query = "INSERT INTO messages (member_id, message) VALUES (" + message.getMember().getMemberID() + ", '" + message.getMessage() + "')";
            MySqlConnection conn = dbConnection.CreateNewConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
        }
    }
}
