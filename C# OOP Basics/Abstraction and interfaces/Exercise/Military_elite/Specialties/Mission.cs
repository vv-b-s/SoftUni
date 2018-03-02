using System;
using System.Collections.Generic;
using System.Text;

namespace Military_elite.Specialties
{
    public class Mission
    {
        private string progress;

        public Mission(string codeName, string progress)
        {
            CodeName = codeName;
            Progress = progress;
        }

        public string CodeName { get; set; }

        public string Progress
        {
            get => progress;
            set
            {
                if (value == "Finished" || value == "inProgress")
                    progress = value;

                else throw new ArgumentException("Ïnvalid progress");
            }
        }

        public void CompleteMission() => Progress = "Finished";

        public override string ToString() => $"  Code Name: {CodeName} State: {Progress}";

    }
}
