using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task2
{
    public class User : IEquatable<User>
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
            set { _patronymic = value; }
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

        public bool Equals([AllowNull] User user)
        {
            if (user is null) throw new ArgumentNullException("ArgumentNullException");
            return Name == user.Name && LastName == user.LastName && Patronymic == user.Patronymic
                && DateOfBirth == user.DateOfBirth;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            User user = obj as User;
            if ((object)user == null)
                return false;
            return Name == user.Name && LastName == user.LastName && Patronymic == user.Patronymic
                 && DateOfBirth == user.DateOfBirth;
        }
    }
}
