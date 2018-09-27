using System.Collections.Generic;
using castle_grimtol.Models;

namespace castle_grimtol.Interfaces
{
  public interface IPlayer
  {
    string PlayerName { get; set; }
    List<IItem> Inventory { get; set; }
  }
}