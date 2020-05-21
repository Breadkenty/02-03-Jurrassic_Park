using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace _02_03_Jurrassic_Park
{

    class Program
    {
        static string AskForString(string prompt)
        {
            Console.WriteLine(prompt);

            return Console.ReadLine();
        }

        static double AskForDouble(string prompt)
        {
            Console.WriteLine(prompt);

            double result;
            bool goodResponse = false;

            var input = Console.ReadLine();

            goodResponse = double.TryParse(input, out result);
            while (!goodResponse)
            {
                Console.WriteLine("Are you kidding me?! Give me an number by the two decimal places eg. 0.00");
                input = Console.ReadLine();

                goodResponse = double.TryParse(input, out result);
            }

            return result;
        }

        static int AskForInt(string prompt)
        {
            Console.WriteLine(prompt);

            int result;
            bool goodResponse = false;

            var input = Console.ReadLine();

            goodResponse = int.TryParse(input, out result);
            while (!goodResponse)
            {
                Console.WriteLine("Are you kidding me?! Give me an number");
                input = Console.ReadLine();

                goodResponse = int.TryParse(input, out result);
            }

            return result;
        }

        static DateTime AskForDateTime(string prompt)
        {
            Console.WriteLine(prompt);

            bool goodResponse = false;
            DateTime result;

            var input = Console.ReadLine();

            goodResponse = DateTime.TryParse(input, out result);
            while (!goodResponse)
            {
                Console.WriteLine("Are you kidding me?! Give me a date in the following format: MM/DD/YYYY");
                input = Console.ReadLine();

                goodResponse = DateTime.TryParse(input, out result);
            }

            return result;
        }

        static void PressAnyKeyToContinue()
        {
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            // Check to see if there is the file: Dinosaur.csv
            TextReader reader;

            // If there is a file, use the StreamReader pointing to the file
            if (File.Exists("Dinosaurs.csv"))
            {
                // Assign a StreamReader to read from the file
                reader = new StreamReader("Dinosaurs.csv");
            }
            else
            {
                // If there is not a file, use StringReader with an empty string
                // Assign a StringReader to read from an empty string
                reader = new StringReader("");
            }

            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var dinosaurs = csvReader.GetRecords<Dinosaur>().ToList();
            reader.Close();

            // 3. While the application is open is true, asks the user what they would like to do.
            bool applicationOpen = true;
            while (applicationOpen == true)
            {
                Console.WriteLine($"Welcome to Dinosaurworld!");
                Console.WriteLine($"-----------------Main Menu-----------------");
                Console.WriteLine($"V to view your dinosaurs");
                Console.WriteLine($"A to add a dinosaur");
                Console.WriteLine($"R to remove a dinosaur");
                Console.WriteLine($"T to transfer a dinosaur to another enclosure");
                Console.WriteLine($"S to see how many dinosaurs by their diet");
                Console.WriteLine($"D to see all the dinosaurs after a date");
                Console.WriteLine($"E to see all dinosaurs in an enclosure");
                Console.WriteLine($"Q to quit");

                var input = Console.ReadKey().KeyChar;
                bool goodInput = "vartsqde".Contains(input);

                if (input == 'v')
                {
                    // V - View - Show all dinosaurs in the list by:
                    // 1. Take the list of dinosaurs
                    // 2. for each of the dinosaur in the list of dinosaurs
                    // 3. Print the dinosaur's details into the console. $"{Name} -- {Diet} -- {WhenAcquired} -- {Weight} -- {EnclosureNumber}"
                    foreach (var dinosaur in dinosaurs)
                    {
                        Console.WriteLine(dinosaur.Description());
                    }

                    PressAnyKeyToContinue();
                }
                if (input == 'a')
                {
                    // A - Add - create a dinosaur to be included in the list by:
                    // 1. Asking for the nameInput of a dinosaur as a string Name
                    var nameInput = AskForString("What's the dinosaur's name?");

                    // 2. Asking for the dietInput of the dinosaur as a string Diet
                    var dietInput = AskForString($"What type of diet does {nameInput} have?");

                    // 3. Asking for whenAcquiredInput as DateTime WhenAcquired
                    var whenAcquiredInput = AskForDateTime($"When did you acquire {nameInput}?");

                    // 4. Asking for the weightInput of the dinosaur as a decimal Weight
                    var weightInput = AskForDouble($"How many tons does {nameInput} weigh?");

                    // 5. Asking for the enclosureNumberInput of the Dinosaur as a integer EnclosureNumber
                    var enclosureNumberInput = AskForInt($"Which enclosure is {nameInput} in?");

                    // 6. take that input, and add to a list of Dinosaurs.
                    var newDinosaur = new Dinosaur
                    {
                        Name = nameInput,
                        Diet = dietInput,
                        WhenAcquired = whenAcquiredInput,
                        Weight = weightInput,
                        EnclosureNumber = enclosureNumberInput
                    };
                    dinosaurs.Add(newDinosaur);

                    PressAnyKeyToContinue();
                }
                if (input == 'r')
                {
                    // R - Remove - remove a dinosaur that is already in the list by:
                    // 1. Ask for the dinosaur.Name in the list you want to remove
                    var nameInput = AskForString("What's the dinosaur's name?");
                    var dinosaurToRemove = dinosaurs.First(dinosaur => dinosaur.Name == nameInput);

                    // 2. Remove the dinosaur from the list
                    dinosaurs.Remove(dinosaurToRemove);

                    PressAnyKeyToContinue();
                }
                if (input == 't')
                {
                    // t - Transfer - change the enclosure number of the dinosaur by:
                    // 1. Ask for the dinosaur.Name in the list
                    var nameInput = AskForString("What's the dinosaur's name?");

                    // 2. Ask for the updated enclosureNumber and store that into newEnclosureNumber
                    var enclosureNumberInput = AskForInt($"What enclosure do you want to put {nameInput} in?");

                    // 3. update the dinosaur.EnclosureNumber = newEnclosureNumber 
                    var dinosaurEnclosureToUpdate = dinosaurs.First(dinosaur => dinosaur.Name == nameInput);
                    dinosaurEnclosureToUpdate.EnclosureNumber = enclosureNumberInput;

                    PressAnyKeyToContinue();
                }
                if (input == 's')
                {
                    // S - Summary - display the number of dinosaurs that are carnivores or herbivores by:
                    // 1. Select dinosaurs where their diet is a carnivore
                    var dinosaursThatAreHerbivores = dinosaurs.Where(dinosaur => dinosaur.Diet == "Herbivore");

                    // 2. Display the number of dinosaurs that have been selected.
                    Console.WriteLine($"Herbivore: {dinosaursThatAreHerbivores.Count()}");

                    // 3. select dinosaurs where their diet is a herbivore
                    var dinosaursThatAreCarnivores = dinosaurs.Where(dinosaur => dinosaur.Diet == "Carnivore");

                    // 4. Display the number of dinosaurs that have been selected. 
                    Console.WriteLine($"Carnivore: {dinosaursThatAreCarnivores.Count()}");

                    // 5. select dinosaurs where their diet is a Omnivore
                    var dinosaursThatAreOmnivores = dinosaurs.Where(dinosaur => dinosaur.Diet == "Omnivore");

                    // 6. Display the number of dinosaurs that have been selected. 
                    Console.WriteLine($"Omnivore: {dinosaursThatAreOmnivores.Count()}");

                    PressAnyKeyToContinue();
                }
                if (input == 'd')
                {
                    // D - Dinosaurs acquired after a given date
                    // 1. Ask the user for the dateInput
                    var dateInput = AskForDateTime($"Enter a date in the format of MM/dd/YYYY");

                    // 2. Select the dinosaurs where their acquiredDate is after the dateInput
                    var dinosaursAfterDate = dinosaurs.Where(dinosaur => dinosaur.WhenAcquired > dateInput);
                    Console.WriteLine($"Dinosaurs acquired after {dateInput.ToString("MM/dd/yyyy")}");

                    // 3. List all of the dinosaurs selected
                    foreach (var dinosaur in dinosaursAfterDate)
                    {
                        Console.WriteLine(dinosaur.Name);
                    }

                    PressAnyKeyToContinue();
                }
                if (input == 'e')
                {
                    // E - Dinosaurs by their enclosure
                    // 1. Ask the user for the enclosureInput
                    var enclosureInput = AskForInt($"Enter an enclosure number to see all of the dinosaurs inside");

                    // 2. Select the dinosaurs where their acquiredDate is after the dateInput
                    var dinosaursByEnclosure = dinosaurs.Where(dinosaur => dinosaur.EnclosureNumber == enclosureInput);

                    // 3. List all of the dinosaurs selected
                    foreach (var dinosaur in dinosaursByEnclosure)
                    {
                        Console.WriteLine(dinosaur.Name);
                    }

                    PressAnyKeyToContinue();
                }
                if (input == 'q')
                {
                    // Q - Quit - End the console app by: 
                    // 1. applicationOpen = false to leave the while loop. 
                    Console.WriteLine($"Quit");
                    applicationOpen = false;

                    PressAnyKeyToContinue();
                }
                if (!goodInput)
                {
                    // else - Console.WriteLine("Invalid input")
                    Console.WriteLine($"Wrong input!");

                    PressAnyKeyToContinue();
                }

                var fileWriter = new StreamWriter("dinosaurs.csv");
                var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(dinosaurs);
                fileWriter.Close();
            }
        }
    }
}