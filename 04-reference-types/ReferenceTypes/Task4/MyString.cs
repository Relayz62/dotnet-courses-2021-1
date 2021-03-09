using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class MyString
    {
        private string _myString;      
        public MyString()
        {
            _myString = null;
        }

        public MyString(string s)
        {
            _myString = s;
        }

        public MyString(params char[] charArray)
        {
            foreach (char symbol in charArray)
            {
                _myString += symbol;
            }
        }

        public override string ToString()
        {
            return this._myString;
        }
        public static MyString operator +(MyString first, MyString second) => new MyString(first._myString + second._myString);
        public static MyString operator -(MyString first, MyString second)
        {
            try
            {
                int index = first._myString.IndexOf(second._myString);
                return new MyString(first._myString.Remove(index, second._myString.Length));
            }
            catch (Exception e) { throw e; }
        }

        public static bool operator ==(MyString first, MyString second)
        {
            if (first._myString == second._myString) return true;
            else return false;
        }
        public static bool operator !=(MyString first, MyString second)
        {
            if (first._myString != second._myString) return true;
            else return false;
        }
        public static bool IsNullOrEmpty(MyString myString) => string.IsNullOrEmpty(myString._myString); 
        public override bool Equals(object obj) => obj is MyString other && this == other;
        public override int GetHashCode() => _myString.GetHashCode();


    }
}
