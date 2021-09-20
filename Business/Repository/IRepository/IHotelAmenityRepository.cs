using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Business.Repository.IRepository
{
    public interface IHotelAmenityRepository
    {
        public Task<HotelAmenityDto> CreateHotelAmenity(HotelAmenityDto hotelRoomAmenityDto);
        public Task<HotelAmenityDto> UpdateHotelAmenity(int roomAmenityId, HotelAmenityDto hotelRoomAmenityDto);
        public Task<HotelAmenityDto> GetHotelAmenity(int roomAmenityId);
        public Task<int> DeleteHotelAmenity(int roomAmenityId);
        public Task<IEnumerable<HotelAmenityDto>> GetAllHotelAmenities();
        public Task<HotelAmenityDto> IsHotelAmenityUnique(string name, int roomAmenityId = 0);

    }
}
