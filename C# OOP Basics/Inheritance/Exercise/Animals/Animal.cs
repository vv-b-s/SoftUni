using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            AnimalGender = gender;
        }

        public enum Gender { Male, Female}

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid input!");

                else name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid input!");

                else age = value;
            }
        }

        public virtual Gender AnimalGender
        {
            get => gender;
            set
            {
                if (Enum.IsDefined(value.GetType(), value))
                    gender = value;

                else throw new ArgumentException("Invalid input!");
            }
        }

        public abstract string ProduceSound();

        public override string ToString() =>
            $"{this.GetType().Name}\n" +
            $"{name} {age} {gender}\n" +
            $"{ProduceSound()}";
    }
}
