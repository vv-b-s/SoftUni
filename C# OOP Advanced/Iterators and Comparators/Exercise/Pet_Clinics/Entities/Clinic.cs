using Pet_Clinics.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pet_Clinics.Entities
{
    public class Clinic : IClinic
    {
        private IPet[] rooms;

        private int[] roomAdditionOrder;
        private int[] roomReleaseOrder;

        public Clinic(int numberOfRooms)
        {
            if (numberOfRooms % 2 == 0)
                throw new InvalidOperationException("Invalid Operation!");

            else
            {
                this.rooms = new IPet[numberOfRooms];

                roomAdditionOrder = GetRoomAdditionOrder(numberOfRooms);
                roomReleaseOrder = GetRoomReleaseOrder(numberOfRooms);
            }
        }

        public IReadOnlyCollection<IPet> Rooms => this.rooms;

        public bool HasEmptyRooms => this.rooms.Any(r => r is null);

        public bool AddPet(IPet pet)
        {
            if (!this.HasEmptyRooms)
                return false;

            var emptyRoom = GetRoomIndex(true);
            this.rooms[emptyRoom] = pet;

            return true;
        }

        public IEnumerator<IPet> GetEnumerator()
        {
            foreach (var pet in this.rooms)
                yield return pet;
        }

        public string Print()
        {
            var sB = new StringBuilder();

            //Starting from 1, in order to use the Print(int room) method
            for (int i = 1; i <= this.rooms.Length; i++)
                sB.AppendLine(Print(i));

            return sB.ToString();
        }

        public string Print(int room)
        {
            //Rooms start from 1 - N therefor to get the index, decrementation is needed.
            room--;

            var pet = this.rooms[room];

            return pet is null ? "Room empty" : pet.ToString();
        }

        public bool Release()
        {
            var roomToRelease = GetRoomIndex(false);

            if (roomToRelease < 0)
                return false;

            else
            {
                this.rooms[roomToRelease] = null;
                return true;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Gets the required order in which pets will be added
        /// </summary>
        /// <param name="numberOfRooms"></param>
        /// <returns></returns>
        private int[] GetRoomAdditionOrder(int numberOfRooms)
        {
            var orderedRooms = new int[numberOfRooms];

            //Starting from the middle room
            var middleRoom = numberOfRooms / 2;
            orderedRooms[0] = middleRoom;

            //Each next room is the index of the middle room +/- the delta which increases when i is even
            var roomDelta = 1;
            for (int i = 1; i < numberOfRooms; i++)
            {
                int roomIndex;
                if (i % 2 != 0)
                    roomIndex = middleRoom - roomDelta;

                else
                {
                    roomIndex = middleRoom + roomDelta;
                    roomDelta++;
                }

                orderedRooms[i] = roomIndex;
            }

            return orderedRooms;
        }

        private int[] GetRoomReleaseOrder(int numberOfRooms)
        {
            var orderedRooms = new int[numberOfRooms];

            var middleRoom = numberOfRooms / 2;
            orderedRooms[0] = middleRoom;

            //Get the indexes from the middle room +1 to the end
            int roomIndex = 1;
            for (int i = middleRoom + 1; i < orderedRooms.Length; i++, roomIndex++)
                orderedRooms[roomIndex] = i;

            for (int i = 0; i < middleRoom; roomIndex++, i++)
                orderedRooms[roomIndex] = i;

            return orderedRooms;
        }

        /// <summary>
        /// Chooses a room where to add/remove pet
        /// </summary>
        /// <param name="isAddingPet">Room addition differs from room removal</param>
        /// <returns>the index of the room where the pet will be added. If no such, will return -1</returns>
        private int GetRoomIndex(bool isAddingPet)
        {
            if (isAddingPet)
            {
                for (int i = 0; i < roomAdditionOrder.Length; i++)
                {
                    var roomIndex = this.roomAdditionOrder[i];
                    if (this.rooms[roomIndex] == null)
                        return roomIndex;
                }
            }

            else
            {
                for (int i = 0; i < roomReleaseOrder.Length; i++)
                {
                    var roomIndex = this.roomReleaseOrder[i];
                    if (this.rooms[roomIndex] != null)
                        return roomIndex;
                }
            }

            return -1;
        }
    }
}
