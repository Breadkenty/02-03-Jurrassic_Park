using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_03_Jurrassic_Park
{
  class Dinosaur 
  {
    // 2. Assign properties to the dinosaurs 
    public string Name { get; set; } 
    public string Diet { get; set; } 
    public DateTime WhenAcquired { get; set; }
    public double Weight { get; set; }
    public int EnclosureNumber { get; set;}
    public string Description () 
    {
      return $"{Name} -- {Diet} -- {WhenAcquired.ToString("MM/dd/yyyy")} -- {Weight} -- {EnclosureNumber}";
    }
    
  }
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
      }
      return result;
    }
       static DateTime AskForDateTime(string prompt)
    {
        Console.WriteLine(prompt);
        DateTime result = DateTime.Parse(Console.ReadLine());
        return result;
    }
    
    static void Main(string[] args)
    {
        // 1. Create the list of dummy dinosaurs
        var trent = new Dinosaur 
        {
            Name = "Trent",
            Diet = "Omnivore",
            WhenAcquired = new DateTime(1988, 04, 09),
            Weight =  4.1,
            EnclosureNumber = 2          
        };
        var abtahee = new Dinosaur 
        {
            Name = "Abtahee",
            Diet = "Carnivore",
            WhenAcquired = new DateTime(1997, 08, 29),
            Weight =  15.4,
            EnclosureNumber = 3          
        };
        var cody = new Dinosaur 
        {
            Name = "Cody",
            Diet = "Herbivore",
            WhenAcquired = new DateTime(1997, 11, 08),
            Weight =  13.8,
            EnclosureNumber = 3          
        };
        var kento = new Dinosaur 
        {
            Name = "Kento",
            Diet = "Carnivore",
            WhenAcquired = new DateTime(1993, 07, 26),
            Weight =  6.5,
            EnclosureNumber = 1          
        };
        var gavin = new Dinosaur 
        {
            Name = "Gavin",
            Diet = "Herbivore",
            WhenAcquired = new DateTime(1971, 11, 10),
            Weight =  4.8,
            EnclosureNumber = 2          
        };
        var kentrosaurus = new Dinosaur 
        {
            Name = "Kentrosaurus",
            Diet = "Herbivore",
            WhenAcquired = new DateTime(0001, 05, 16),
            Weight =  6.3,
            EnclosureNumber = 4          
        };
        
        var dinosaurs = new List<Dinosaur>();
        dinosaurs.Add(trent);
        dinosaurs.Add(abtahee);
        dinosaurs.Add(cody);
        dinosaurs.Add(kento);
        dinosaurs.Add(gavin);
        dinosaurs.Add(kentrosaurus);
        
        bool applicationOpen = true;




        // 3. While the application is open is true, asks the user what they would like to do.
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
          Console.WriteLine($"e to see all dinosaurs in an enclosure");
          Console.WriteLine($"Q to quit");

          var input = Console.ReadKey();
          bool goodInput = input.KeyChar == 'v' || input.KeyChar == 'a' || input.KeyChar == 'r' || input.KeyChar == 't' || input.KeyChar == 's' || input.KeyChar == 'q'|| input.KeyChar == 'd' || input.KeyChar == 'e';  
      
           if(input.KeyChar == 'v')
           {
              // V - View - Show all dinosaurs in the list by:
              // 1. Take the list of dinosaurs
              foreach ( var dinosaur in dinosaurs)
              {
                Console.WriteLine(dinosaur.Description());
              }
              // 2. for each of the dinosaur in the list of dinosaurs
              // 3. Print the dinosaur's details into the console. $"{Name} -- {Diet} -- {WhenAcquired} -- {Weight} -- {EnclosureNumber}"
           }
           if (input.KeyChar == 'a')
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
            }
            if (input.KeyChar == 'r')
            {
              // R - Remove - remove a dinosaur that is already in the list by:
              // 1. Ask for the dinosaur.Name in the list you want to remove
              var nameInput = AskForString("What's the dinosaur's name?");              
              var dinosaurToRemove = dinosaurs.First(dinosaur => dinosaur.Name == nameInput);
              // 2. Remove the dinosaur from the list
              dinosaurs.Remove(dinosaurToRemove);
            }
            if (input.KeyChar == 't')
            {
              // t - Transfer - change the enclosure number of the dinosaur by:
              // 1. Ask for the dinosaur.Name in the list
              var nameInput = AskForString("What's the dinosaur's name?");      
              // 2. Ask for the updated enclosureNumber and store that into newEnclosureNumber
              var enclosureNumberInput = AskForInt($"What enclosure do you want to put {nameInput} in?");
              // 3. update the dinosaur.EnclosureNumber = newEnclosureNumber 
              var dinosaurEnclosureToUpdate = dinosaurs.First(dinosaur => dinosaur.Name == nameInput);
              dinosaurEnclosureToUpdate.EnclosureNumber = enclosureNumberInput;
            }
            if (input.KeyChar == 's')
            {
              // S - Summary - display the number of dinosaurs that are carnivores or herbivores by:
              // 1. Select dinosaurs where their diet is a carnivore
              var dinosaursThatAreHerbivores = dinosaurs.Where(dinosaur => dinosaur.Diet == "Herbivore");
              // 2. Display the number of dinosaurs that have been selected.
              Console.WriteLine(dinosaursThatAreHerbivores.Count());
              // 3. select dinosaurs where their diet is a herbivore
              var dinosaursThatAreCarnivores = dinosaurs.Where(dinosaur => dinosaur.Diet == "Carnivore");
              // 4. Display the number of dinosaurs that have been selected. 
              Console.WriteLine(dinosaursThatAreCarnivores.Count());
              // 5. select dinosaurs where their diet is a Omnivore
              var dinosaursThatAreOmnivores = dinosaurs.Where(dinosaur => dinosaur.Diet == "Omnivore");
              // 6. Display the number of dinosaurs that have been selected. 
              Console.WriteLine(dinosaursThatAreOmnivores.Count());
            }
            if (input.KeyChar == 'd')
            {
              // D - Dinosaurs acquired after a given date
              // 1. Ask the user for the dateInput
              var dateInput = AskForDateTime($"Enter a date in the format of MM/dd/YYYY");
              // 2. Select the dinosaurs where their acquiredDate is after the dateInput
              var dinosaursAfterDate = dinosaurs.Where(dinosaur => dinosaur.WhenAcquired > dateInput);
              // 3. List all of the dinosaurs selected
              foreach (var dinosaur in dinosaursAfterDate)
              {
                Console.WriteLine(dinosaur.Name);
              }
            }
            if (input.KeyChar == 'e')
            {
              // E - Dinosaurs by their enclosure
              // 1. Ask the user for the enclosureInput
              var enclosureInput = AskForInt($"Enter an enclosure number");
              // 2. Select the dinosaurs where their acquiredDate is after the dateInput
              var dinosaursByEnclosure = dinosaurs.Where(dinosaur => dinosaur.EnclosureNumber == enclosureInput);
              // 3. List all of the dinosaurs selected
              foreach (var dinosaur in dinosaursByEnclosure)
              {
                Console.WriteLine(dinosaur.Name);
              }
            }
            if (input.KeyChar == 'q')
            {
              // Q - Quit - End the console app by: 
              // 1. applicationOpen = false to leave the while loop. 
              Console.WriteLine($"Quit");
              applicationOpen = false;
            }
            if (!goodInput)
            {
              // else - Console.WriteLine("Invalid input")
              Console.WriteLine($"Wrong input!");
            }
            
          }


        }
      
      }

  }