using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class User
    {
        private static int _ID = 0;
        private string _firstName;
        private string _lastName;
        private DateTime _birthdate;
        private List<Awards> _awardsList = new List<Awards>();



        public User(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            ID = _ID;
            _ID++;
        }

        public int ID
        {
            get; private set;
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length > 50) throw new ArgumentOutOfRangeException("Длинна имени не должна превышать 50 символов");
                _firstName = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length > 50) throw new ArgumentOutOfRangeException("Длинна фамилии не должна превышать 50 символов");
                _lastName = value;
            }
        }

        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                if ((DateTime.Now.Year - value.Year) > 150 || value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("Необходимо ввести корректную дату.");
                }
                _birthdate = value;
            }
        }

        public int Age
        {
            get { return DateTime.Now.Year - Birthdate.Year; }
        }
        public string Award
        {
            get
            {
                string[] temp = new string[_awardsList.Count];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = _awardsList[i].Title;
                }
                return string.Join(",", temp);
            }
        }
        public void AddAward(Awards award)
        {
            _awardsList.Add(award);
        }

        public void RemoveAward(Awards award)
        {
            _awardsList.Remove(award);
        }

        public void ClearAward()
        {
            _awardsList.Clear();
        }

    }
}
