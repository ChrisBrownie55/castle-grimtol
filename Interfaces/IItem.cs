using System.Collections.Generic;

namespace castle_grimtol.Interfaces
{
  public interface IItem
  {
    string Name { get; set; }
    string Description { get; set; }
    bool KillsPlayer { get; set; }
  }
}