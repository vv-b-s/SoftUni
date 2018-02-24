using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                ValidateName(value, 4, nameof(firstName));
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                ValidateName(value, 3, nameof(lastName));
                lastName = value;
            }
        }

        private void ValidateName(string value, int minLength, string typeOfName)
        {
            if (value.Length < minLength)
                throw new ArgumentException($"Expected length at least {minLength} symbols! Argument: {typeOfName}");
            if (char.IsLower(value[0]))
                throw new ArgumentException($"Expected upper case letter! Argument: {typeOfName}");
        }

        public override string ToString() =>
            $"First Name: {firstName}\n" +
            $"Last Name: {lastName}";
    }
}
