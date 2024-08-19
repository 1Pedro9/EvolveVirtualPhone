using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneVM.Model;

namespace PhoneVM.Controller
{
    public class LoginController
    {

        private Member member;
        private List<Message> messages;
        private List<Todo> todos;

        public LoginController(Member member, List<Message> messages, List<Todo> todos)
        {
            /**
             * Member
             * List<Message>
             * List<Todo>
             */
            this.member = member;
            this.messages = messages;
            this.todos = todos;
        }

        public Member getMember()
        {
            return this.member;
        }
        public List<Message> getMessages() 
        {
            return this.messages;
        }

        public List<Todo> getTodo()
        {
            return this.todos;
        }
        
    } 
}
