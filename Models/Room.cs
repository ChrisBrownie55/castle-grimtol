using System.Collections.Generic;
using castle_grimtol.Interfaces;

namespace castle_grimtol.Models
{
  public class Room : IRoom, ICanKillPlayer
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
    private Dictionary<string, Room> Exits = new Dictionary<string, Room>();

    public void AddRoom(string direction, Room room, bool connectOtherSide = true) {
      direction = direction.ToLower();
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
    public void RemoveRoom(string direction, bool disconnectOtherSide = true) {
      throw new System.NotImplementedException();
    }
    public bool HasExit(string direction) {
      return Exits.ContainsKey(direction);
    }
    public Room GetExit(string direction) {
      return Exits[direction];
    }

    public string Locked { get; set; }

    public void Lock(string direction) {
      if (Locked != null) {
        return;
      }
      Locked = direction;

      string oppositeDirection =
        direction == "north" ? "south" :
        direction == "south" ? "north" :
        direction == "east" ? "west" :
        direction == "west" ? "east" :
        "";

      Exits[direction].Lock(oppositeDirection);
    }

    // Returns true if it was unlocked; false if already unlocked.
    public bool Unlock() {
      if (Locked == null) {
        return false;
      }

      Exits[Locked].Unlock();
      Locked = null;

      return true;
    }
    public bool KillsPlayer { get; set; } = false;

    public int IndexOfItemByName(string name) {
      for (int i = 0; i < Items.Count; ++i) {
        if (Items[i].Name == name) {
          return i;
        }
      }
      return -1;
    }

    public void RemoveItem(int index) {
      Items.RemoveAt(index);
    }

    public Room(string name, string description) {
      Name = name;
      Description = description;
    }
  }
}