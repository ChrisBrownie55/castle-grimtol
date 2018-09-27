using System.Collections.Generic;
using castle_grimtol.Models;

namespace castle_grimtol.Interfaces
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        List<IItem> Items { get; set; }
        Dictionary<string, Room> Exits { get; set; }
        void AddRoom(string direction, IRoom room, bool connectOtherSide = true);
        string Locked { get; set; }
        bool Unlock();
    }
}