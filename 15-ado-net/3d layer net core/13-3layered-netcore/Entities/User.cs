using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
       // private static int sID;
        private string _firstName;
        private string _lastName;
        private DateTime _birthdate;

        public List<Awards> AwardsList = new List<Awards>();


        public User(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;           
        }

        public int ID
        {
            get; set;
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
        //public string Award
        //{
        //    get
        //    {
        //        string[] temp = new string[AwardsList.Count];
        //        for (int i = 0; i < temp.Length; i++)
        //        {
        //            temp[i] = AwardsList[i].Title;
        //        }
        //        return string.Join(",", temp);
        //    }
        //}

        public void AddAward(Awards award)
        {
            AwardsList.Add(award);
        }

        public void RemoveAward(Awards award)
        {
            AwardsList.Remove(award);
        }

        public void ClearAwards()
        {
            AwardsList.Clear();
        }

    }
}
