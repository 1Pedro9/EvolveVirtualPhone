using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PhoneVM.Database;
using PhoneVM.Model;

namespace PhoneVM.Controller
{
    internal class ModelController
    {

        public List<Todo> ArrayTodo()
        {
            List<Todo> array = new List<Todo>();
            try
            {
                string path = @"C:\Users\basso\source\repos\PhoneVM\PhoneVM\Database\Todo.txt";

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        array.Add(new Todo(line));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return array;
        }

        public void add_todo(Todo todo)
        {
            List<Todo> array = ArrayTodo();
            array.Add(todo);

            update_file(array);
        }

        public void remove_todo(Todo todo)
        {
            List<Todo> array = ArrayTodo();
            array.Remove(todo);

            update_file(array);
        }

        private void update_file(List<Todo> array)
        {
            string content = "";
            foreach (Todo i in array)
            {
                content += i.ToString() +  "\n";
            }

            Console.WriteLine(content);
        }

        /**
         * This is the part for the Members controller
         */

        
        public List<Member> members()
        {
            List<Member> array = new List<Member>();
            try
            {
                string path = @"C:\Users\basso\source\repos\PhoneVM\PhoneVM\Database\Member.txt";

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(';');
                        array.Add(new Member(int.Parse(data[0]), data[1], data[2], data[3], data[4], DateTime.Parse(data[5]), int.Parse(data[6])));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return array;
        }

        public Member searchMember(int id)
        {
            Member value = null;
            foreach(Member member in members())
            {
                if(id == member.getMemberID())
                {
                    value = member;
                }
            }
            return value;
        }

        /**
         * This is the section for Messages
         */
        public List<Message> messages()
        {
            List<Message> array = new List<Message>();
            try
            {
                string path = @"C:\Users\basso\source\repos\PhoneVM\PhoneVM\Database\Message.txt";

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        var data = line.Split(';');
                        array.Add(new Message(searchMember(int.Parse(data[0])), data[1], DateTime.Parse(data[2])));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return array;
        }
        public Message searchMessage(Member m)
        {
            Message value = null;
            foreach (Message message in messages())
            {
                if (m == message.getMember())
                {
                    value = message;
                }
            }
            return value;
        }

        public void add_message(Message message)
        {
            List<Message> array = messages();
            array.Add(message);

            update_message(array);
        }

        public void remove_message(Message message)
        {
            List<Message> array = messages();
            array.Remove(message);

            update_message(array);
        }

        private void update_message(List<Message> array)
        {
            string content = "";
            foreach (Message i in array)
            {
                content += i.ToString() + "\n";
            }

            string filePath = @"C:\Users\basso\source\repos\PhoneVM\PhoneVM\Database\Test.txt";
            File.WriteAllText(filePath, content);
            Console.WriteLine(content);
        }
    }
}
