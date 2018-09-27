using System.Collections.Generic;
using castle_grimtol.Interfaces;

namespace castle_grimtol.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void AddRoom(string direction, IRoom room, bool connectOtherSide = true) {
      direction = direction.ToString();
      if (Exits.ContainsKey(direction)) {
        return;
      }
      Exits.Add(direction, room);
      if (connectOtherSide) {
        string oppositeDirection =
          direction == "north" ? "south" :
          direction == "south" ? "north" :
          direction == "east" ? "west" :
          direction == "west" ? "east" :
          "";
        room.Exits.Add(oppositeDirection, this);
      }
    }

    public string Locked { get; set; }

    // Returns true if it was unlocked; false if already unlocked.
    public bool Unlock() {
      if (Locked == null) {
        return false;
      }
      Locked = null;
      return true;
    }


    public Room(string name, string description, string locked = null) {
      Name = name;
      Description = description;
      List<string> directions = new List<string>(){ "north", "east", "south", "west" };
      if (locked != null && directions.Contains(locked)) {
        Locked = locked;
      }
    }
  }
}