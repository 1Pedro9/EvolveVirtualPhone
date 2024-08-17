using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneVM.Model
{
    internal class Member
    {

        private int member_id;
        private string firstname;
        private string lastname;
        private string email;
        private string password;
        private DateTime date;
        private int is_member;
        public Member(int member_id, string firstname, string lastname, string email, string password, DateTime date, int is_member) 
        { 
            this.member_id = member_id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.password = password;
            this.date = date;
            this.is_member = is_member;
        }

        public int getMemberID()
        {
            return this.member_id; 
        }
        public string getFirstname()
        {
            return this.firstname;
        }

        public string getLastname()
        {
            return this.lastname;
        }

        public string getEmail()
        {
            return this.email;
        }
        public string getPassword()
        {
            return this.password;
        }
        public DateTime getDate()
        {
            return this.date;
        }
        public int getIsMember()
        {
            return this.is_member;
        }

        public string ToString()
        {
            return this.member_id.ToString() + ";" + this.firstname.ToString() + ";" + this.lastname.ToString() + ";" + this.email.ToString() + ";" + this.password.ToString() + ";" + this.date.ToString() + ";" + this.is_member.ToString();
        }
    }
}
