using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneVM.Model
{
    internal class Todo
    {
        private string todo;

        public Todo(string todo)
        {
            this.todo = todo;
        }

        public string getTodo()
        {
            return this.todo;
        }

        public void setTodo(string value)
        {
            this.todo = value;
        }

        public override string ToString()
        {
            return this.todo; 
        }
    }
}
