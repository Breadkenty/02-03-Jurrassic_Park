## Jurassic Park 

Objectives: 
  1. Control structures
  2. Work with data
  3. Use LINQ
  4. Use OOP (Classes and Methods)

  Task: Create an application that manages the dinosaurs in your zoo.

  Problem----------------------------------------------

    Create an app that manages the dinosaurs in our zoo. 
    The app should be able to display the following descriptions of the dinosaur:
    
    Properties: 

    string ------- Name
    string ------- Diet
    DateTime ----- WhenAcquired
    Integer ------ Weight
    Integer ------- Enclosure Number

    Methods:
    Description - Prints out the description of the dinosaur with all it's properties. 
    $"{Name} -- {Diet} -- {WhenAcquired} -- {Weight} -- {EnclosureNumber}

    Store the dinosaurs in a list. 

    Create a menu that does the following:
    1. View - Show all dinosaurs in the list
    2. Add - create a dinosaur to be included in the list
    3. Remove - remove a dinosaur that is already in the list
    4. Transfer - change the enclosure number of the dinosaur
    5. Summary - display the number of dinosaurs that are carnivores or herbivores
    6. Quit - End the console app


  Examples----------------------------------------------

    Dinosaur 1:
    Name: Trent
    Diet: Omnivore
    WhenAcquired: 04/09/1988
    Weight: 4 tons
    Enclosure Number: 2


    Dinosaur 2:
    Name: Abtahee
    Diet: Carnivore
    WhenAcquired: 08/29/1997
    Weight: 15 tons
    Enclosure Number: 3

    Dinosaur 3:
    Name: Cody
    Diet: Herbivore
    WhenAcquired: 11/08/1997
    Weight: 13 tons
    Enclosure Number: 3

    Dinosaur 4:
    Name: Kento
    Diet: Carnivore
    WhenAcquired: 07/26/1993
    Weight: 6.5 tons
    Enclosure Number: 1

    Dinosaur 5:
    Name: Gavin
    Diet: Herbivore
    WhenAcquired: 11/10/1970
    Weight: 20 tons
    Enclosure Number: 5

    Dinosaur 6:
    Name: Kentrosaurus
    Diet: Herbivore
    WhenAcquired: 05/16/0001
    Weight: 6.5 tons
    Enclosure Number: 4


  1. View - Show all dinosaurs in the list
    2. Add - create a dinosaur to be included in the list
    3. Remove - remove a dinosaur that is already in the list
    4. Transfer - change the enclosure number of the dinosaur
    5. Summary - display the number of dinosaurs that are carnivores or herbivores
    6. Quit - End the console app
    
      
      While 
        
        1. Select an option: V - View, A - Add, R - Remove, T - Transfer, S - Summary, Q - Quit

          If

            V - Display all of the dinosaurs

            A - Add a dinosaur

            R - Remove a dinosaur

            T - Transfer a dinosaur 

            S - Display the number of dinosaurs that are carnivores and herbivores respectively

            Q - Quit the application
                Get out of while loop

            Any other key - Prompt to choose the correct input

      Quit the application


  Data Structure ---------------------------------------

    Properties: 

    string ------- Name
    string ------- Diet
    DateTime ----- WhenAcquired
    Integer ------ Weight
    Integer ------- Enclosure Number

    DateTime == ?????? 

    Methods: 

    1. Display all dinosaurs: for loop
    2. Add a dinosaur: Console.ReadLine() => class Dinosaurs => List<Dinosaurs>
    3. Select a dinosaur: Console.ReadLine() => .Where =>
        A. Remove a dinosaur: .Remove
        B. Transfer a dinosaur: update its enclosure number. enclosureNumber = newEnclosureNumber
        C. Display dinosaurs by their (Diet). dinosaur.Diet == "carnivore", "herbivore", "omnivore" etc. 
    4. Quit application: change "bool quitProgram = false" to true


  Algorithm ---------------------------------------------

  1. Create the list of dummy dinosaurs
  2. Assign properties to the dinosaurs 
  3. While the application is open is true, asks the user what they would like to do.
        If
  
          V - View - Show all dinosaurs in the list by:
            1. Take the list of dinosaurs
            2. for each of the dinosaur in the list of dinosaurs
            3. Print the dinosaur's details into the console. $"{Name} -- {Diet} -- {WhenAcquired} -- {Weight} -- {EnclosureNumber}"
          
          
          A - Add - create a dinosaur to be included in the list by:
            1. Asking for the nameInput of a dinosaur as a string Name
            2. Asking for the dietInput of the dinosaur as a string Diet
            3. Asking for whenAcquiredInput as DateTime WhenAcquired
            4. Asking for the weightInput of the dinosaur as a decimal Weight
            5. Asking for the enclosureNumberInput of the Dinosaur as a integer EnclosureNumber
            6. take that input, and add to a list of Dinosaurs.
          
          
          R - Remove - remove a dinosaur that is already in the list by:
            1. Ask for the dinosaur.Name in the list you want to remove
            2. Remove the dinosaur from the list
          
          
          R - Transfer - change the enclosure number of the dinosaur by:
            1. Ask for the dinosaur.Name in the list
            2. Ask for the updated enclosureNumber and store that into newEnclosureNumber
            3. update the dinosaur.EnclosureNumber = newEnclosureNumber 

          
          S - Summary - display the number of dinosaurs that are carnivores or herbivores by:
            1. Ask for the name of the dinosaur in the list we'll call this nameInput
            2. Ask for diet you want to see. We'll call this dietInput
                A. If it's herbivore, display the amount of dinosaurs in the list that are herbivores
                B. If it's carnivore, display the amount of dinosaurs in the list that are carnivores
                C. If it's omnivore, display the amount of dinosaurs in the list that are omnivores

          Q - Quit - End the console app by: 
            1. applicationOpen = false to leave the while loop. 

          else - Console.WriteLine("Invalid input")





