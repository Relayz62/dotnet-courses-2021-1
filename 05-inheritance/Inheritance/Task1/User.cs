using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class User
    {
        private string _name; // имя
        private string _lastName; // фамилия
        private string _patronymic; // отчество
        private DateTime _dateOfBirth; // дата рождения
        private int _age; // возраст

        public User(string name, string lastName, string patronymic, DateTime dateOfBirth)
        {
            _name = name;
            _lastName = lastName;
            _patronymic = patronymic;
            _dateOfBirth = dateOfBirth;
        }

        //Свойство - Имя
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Свойство - Фамилия
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        //Свойство - Отчество
        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value;  }
        }
        //Свойство - Дата рождения
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public int Age
        {
            get { return _age = DateTime.Now.Year - _dateOfBirth.Year; }
        }




    }
}
