namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = "";
            var hf = typeof(HarvestingFields);
            var fields = hf.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] filteredMembers;

                switch (input)
                {
                    case "public":
                        filteredMembers = fields.Where(f => f.IsPublic).ToArray();
                        break;

                    case "private":
                        filteredMembers = fields.Where(f => f.IsPrivate).ToArray();
                        break;

                    case "protected":
                        filteredMembers = fields.Where(f => f.IsFamily).ToArray();
                        break;

                    default:
                        filteredMembers = fields;
                        break;
                }

                var sB = new StringBuilder();
                foreach(var field in filteredMembers)
                {
                    var accessType = "";

                    if (field.IsPublic)
                        accessType = "public";
                    else if (field.IsPrivate)
                        accessType = "private";
                    else if (field.IsFamily)
                        accessType = "protected";

                    sB.AppendLine($"{accessType} {field.FieldType.Name} {field.Name}");
                }

                Console.Write(sB.ToString());
            }
        }
    }
}
