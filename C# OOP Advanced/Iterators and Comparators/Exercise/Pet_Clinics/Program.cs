using Pet_Clinics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pet_Clinics
{
    class Program
    {
        private static Dictionary<string, Pet> pets = new Dictionary<string, Pet>();
        private static Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();

        static void Main(string[] args)
        {


            var numberOfCommands = int.Parse(Console.ReadLine());
            var sB = new StringBuilder();

            while (numberOfCommands-- > 0)
            {
                var input = Console.ReadLine();
                var data = input.Split();

                var command = data[0];
                try
                {
                    switch (command)
                    {
                        case "Create":

                            var thingToCreate = data[1];

                            if (thingToCreate == "Pet")
                                CreatePet(data.Skip(2).ToArray());

                            else CreateClinic(data.Skip(2).ToArray());
                            break;

                        case "Add":
                            sB.AppendLine(AddPetToClinic(data.Skip(1).ToArray()).ToString());
                            break;

                        case "Release":
                             sB.AppendLine(ReleasePet(data.Skip(1).ToArray()).ToString());
                            break;

                        case "HasEmptyRooms":
                            var clinicName = data[1];

                            if (clinics.ContainsKey(clinicName))
                                sB.AppendLine(clinics[clinicName].HasEmptyRooms.ToString());

                            break;

                        case "Print":
                            clinicName = data[1];

                            if (clinics.ContainsKey(clinicName))
                            {
                                if (data.Length == 2)
                                    sB.Append(clinics[clinicName].Print());

                                else
                                {
                                    int room = int.Parse(data[2]);
                                    sB.AppendLine(clinics[clinicName].Print(room));
                                }
                            }

                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {

                    sB.AppendLine(ex.Message);
                }
            }

            Console.Write(sB.ToString());
        }

        private static void CreatePet(string[] args)
        {
            var petName = args[0];
            var petAge = int.Parse(args[1]);
            var petKind = args[2];

            var pet = new Pet(petName, petAge, petKind);
            pets[petName] = pet;
        }

        private static void CreateClinic(string[] args)
        {
            var clinicName = args[0];
            var numberOfRooms = int.Parse(args[1]);

            var clinic = new Clinic(numberOfRooms);
            clinics[clinicName] = clinic;
        }

        private static bool AddPetToClinic(string[] args)
        {
            var petName = args[0];
            var clinicName = args[1];

            if (!pets.ContainsKey(petName) || !clinics.ContainsKey(clinicName))
                return false;

            else
            {
                var pet = pets[petName];
                var clinic = clinics[clinicName];

                return clinic.AddPet(pet);
            }
        }

        private static bool ReleasePet(string[] args)
        {
            var clinicName = args[0];

            if (clinics.ContainsKey(clinicName))
                return clinics[clinicName].Release();

            else return false;
        }
    }
}
