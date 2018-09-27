using System.Collections.Generic;
using castle_grimtol.Interfaces;

namespace castle_grimtol.Models
{
  public class Item : IItem, ICanKillPlayer
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool KillsPlayer { get; set; } = false;

    public Item(string name, string description) {
      Name = name;
      Description = description;
    }
  }
}