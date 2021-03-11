using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Employee : User
    {
        private int _experience;
        private string _title;
        private DateTime _dateOfInvite;
        public Employee(
            string name,
            string lastName, 
            string patronymic,
            DateTime dateOfBirth,
            DateTime dateOfInvite,
            string title) 
            : base(name,lastName,patronymic, dateOfBirth)
        {
            if(Age < 18) throw new Exception("Лицам, не достигшим 18-ти лет, приём на работу запрещён.");
            _title = title;
            _dateOfInvite = dateOfInvite;
        }

        public int Experience
        {
            get { return _experience = DateTime.Now.Year - _dateOfInvite.Year; }
        }
        public DateTime DateOfInvite
        {
            get { return _dateOfInvite; }
            set
            {                
                _dateOfInvite = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


    }
}
