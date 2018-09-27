using System.Collections.Generic;
using castle_grimtol.Interfaces;

namespace castle_grimtol.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<IItem> Inventory { get; set; }

    public int IndexOfItemByName(string name) {
      for (int i = 0; i < Inventory.Count; ++i) {
        if (Inventory[i].Name == name) {
          return i;
        }
      }
      return -1;
    }

    public void RemoveItem(int index) {
      Inventory.RemoveAt(index);
    }

    // // Returns true if deleted item, false if not deleted
    // public bool RemoveItem(string name) {
    //   int position = IndexOfItemByName(name);
    //   if (position == -1) {
    //     return false;
    //   }

    //   RemoveItem(position);
    //   return true;
    // }

    public Player(string name) {
      PlayerName = name;
    }
  }
}