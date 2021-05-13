﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Awards
    {
      //  private static int _ID = 0;
        public int ID { get; set; }
        private string _title;
        private string _description;
        public bool Selected { get; set; }

        public Awards(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if(value.Length > 50) throw new ArgumentOutOfRangeException("Длинна наименования не должна превышать 50 символов");
                _title = value;
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (value.Length > 250) throw new ArgumentOutOfRangeException("Длинна описания не должна превышать 250 символов");
                _description = value;
            }
        }

        public Awards this[int index]
        {
            get { return this[index]; }
            set { this[index] = value; }
        }
    }
}
