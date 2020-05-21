using System;

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
      return $"Name: {Name} -- Diet: {Diet} -- Date Acquired: {WhenAcquired.ToString("MM/dd/yyyy")} -- Weight: {Weight} tons -- Enclosure: {EnclosureNumber}";
    }
  }
  
}