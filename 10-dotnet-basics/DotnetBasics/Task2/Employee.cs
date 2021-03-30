using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task2
{
    class Employee : User, IEquatable<Employee>
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
            : base(name, lastName, patronymic, dateOfBirth)
        {
            if (Age < 18) throw new Exception("Лицам, не достигшим 18-ти лет, приём на работу запрещён.");
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

        public bool Equals([AllowNull] Employee employee)
        {
            if (employee is null)
                return false;
            return Name == employee.Name && LastName == employee.LastName && Patronymic == employee.Patronymic
                && DateOfBirth == employee.DateOfBirth && DateOfInvite == employee.DateOfInvite && Title == employee.Title;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Employee employee = obj as Employee;
            if ((object)employee == null)
                return false;
            return Name == employee.Name && LastName == employee.LastName && Patronymic == employee.Patronymic
                && DateOfBirth == employee.DateOfBirth && DateOfInvite == employee.DateOfInvite && Title == employee.Title;
        }
    }
}
