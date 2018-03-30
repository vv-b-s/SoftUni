using System;
using System.Collections.Generic;
using System.Text;

namespace Pet_Clinics.Contracts
{
    public interface IClinic : IEnumerable<IPet>
    {
        IReadOnlyCollection<IPet> Rooms { get; }

        bool HasEmptyRooms { get; }

        bool AddPet(IPet pet);

        bool Release();

        string Print();

        string Print(int room);
    }
}
