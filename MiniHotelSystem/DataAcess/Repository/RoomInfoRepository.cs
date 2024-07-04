using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class RoomInfoRepository : IRoomInfo
    {
        public void DeleteRoomInfo(int id)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                RoomInformation? deleteRoom = context.RoomInformations.FirstOrDefault(x => x.RoomId == id);
                if (deleteRoom == null)
                {
                    throw new Exception("No Room was found");
                }
                context.RoomInformations.Remove(deleteRoom);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<RoomInformation> GetAll()
        {
            try
            {
                using var context = new QuanLyHotelContext();
                return context.RoomInformations
                    .Include(t => t.RoomType)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertRoomInfo(RoomInformation o)
        {

            try
            {
                using var context = new QuanLyHotelContext();
                context.RoomInformations.Add(o);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateRoomInfo(RoomInformation updatedRoomInfo)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                var existingRoomInfo = context.RoomInformations.SingleOrDefault(r => r.RoomId == updatedRoomInfo.RoomId);

                if (existingRoomInfo != null)
                {
                    existingRoomInfo.RoomNumber = updatedRoomInfo.RoomNumber;
                    existingRoomInfo.RoomDescription = updatedRoomInfo.RoomDescription;
                    existingRoomInfo.RoomMaxCapacity = updatedRoomInfo.RoomMaxCapacity;
                    existingRoomInfo.RoomStatus = updatedRoomInfo.RoomStatus;
                    existingRoomInfo.RoomPricePerDate = updatedRoomInfo.RoomPricePerDate;
                    existingRoomInfo.RoomTypeId = updatedRoomInfo.RoomTypeId;

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Room not found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
