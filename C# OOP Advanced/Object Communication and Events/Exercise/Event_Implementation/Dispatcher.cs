using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Implementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);
    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get => this.name;
            set
            {
                OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }


        protected void OnNameChange(NameChangeEventArgs args)
        {
            NameChange(this, args);
        }
    }
}
