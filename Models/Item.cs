using System.Collections.Generic;
using castle_grimtol.Interfaces;

namespace castle_grimtol.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool KillsPlayer { get; set; }

    public Item(string name, string description, bool killsPlayer = false) {
      Name = name;
      Description = description;
      KillsPlayer = killsPlayer;
    }
  }
}