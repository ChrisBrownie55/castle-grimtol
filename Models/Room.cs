using System.Collections.Generic;
using castle_grimtol.Interfaces;

namespace castle_grimtol.Models
{
  public class Room : IRoom, ICanKillPlayer
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    private Dictionary<string, Room> Exits = new Dictionary<string, Room>();

    public void AddRoom(string direction, Room room, bool connectOtherSide = true) {
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
    public void RemoveRoom(string direction, bool disconnectOtherSide = true) {
      throw new System.NotImplementedException();
    }
    public bool HasExit(string direction) {
      return Exits.ContainsKey(direction);
    }
    public Room GetExit(string direction) {
      return Exits[direction];
    }

    private string locked;
    public string Locked {
      get => locked;
      set {
        if (value != null && Exits.ContainsKey(value)) {
          locked = value;
        }
      }
    }

    // Returns true if it was unlocked; false if already unlocked.
    public bool Unlock() {
      if (Locked == null) {
        return false;
      }
      Locked = null;
      return true;
    }

    public bool KillsPlayer { get; set; } = false;

    public Room(string name, string description) {
      Name = name;
      Description = description;
    }
  }
}