using System.ComponentModel.DataAnnotations;

namespace catRoundUp.Models;


public class Cat
{
  // NOTE for today we need a constructor defined
  public Cat(string name, int? age, string color, bool longHair, bool? penned, int id)
  {
    Name = name;
    Age = age;
    Color = color;
    LongHair = longHair;
    Penned = penned;
    Id = id;
  }

  public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  public int? Age { get; set; }
  public string Color { get; set; }
  public bool LongHair { get; set; }
  public bool? Penned { get; set; }



}