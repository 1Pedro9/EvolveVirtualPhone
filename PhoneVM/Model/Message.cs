using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneVM.Model;

namespace PhoneVM.Model
{
    internal class Message
    {
        private Member member;
        private string message;
        private DateTime date_of_message;

        public Message(Member member, string message, DateTime date_of_time)
        {
            this.member = member;
            this.message = message;
            this.date_of_message = date_of_time;
        }

        public Member getMember()
        {
            return this.member;
        }

        public string getMessage()
        {
            return this.message;
        }

        public DateTime getDateOfMessage()
        {
            return this.date_of_message;
        }
        public override string ToString()
        {
            return this.member.getMemberID().ToString() + ";" + this.message.ToString() + ";" + date_of_message.ToString();
        }
    }
}
