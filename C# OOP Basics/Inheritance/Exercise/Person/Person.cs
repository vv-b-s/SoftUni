﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        string name;
        int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                else name = value;
            }
        }

        public virtual int Age
        {
            get => age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age must be positive!");
                age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }

    }
}
