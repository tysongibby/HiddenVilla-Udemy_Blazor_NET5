using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelAmenityRepository : IHotelAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public HotelAmenityRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<HotelAmenityDto> CreateHotelAmenity(HotelAmenityDto hotelAmenityDto)
        {            
            HotelAmenity hotelAmenity = _mapper.Map<HotelAmenityDto, HotelAmenity>(hotelAmenityDto);
            hotelAmenity.CreatedDate = DateTime.Now;
            hotelAmenity.CreatedBy = "";
            var addedHotelAmenity = await _db.HotelAmenities.AddAsync(hotelAmenity);            
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelAmenity, HotelAmenityDto>(addedHotelAmenity.Entity);
        }

        public async Task<int> DeleteHotelAmenity(int hotelAmenityId)
        {
            HotelAmenity hotelAmenity = await _db.HotelAmenities.FindAsync(hotelAmenityId);
            if (hotelAmenity != null)
            {
                _db.HotelAmenities.Remove(hotelAmenity);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelAmenityDto>> GetAllHotelAmenities()
        {
           try
            {
                IEnumerable<HotelAmenityDto> hotelAmenityDtos = _mapper.Map<IEnumerable<HotelAmenity>, IEnumerable<HotelAmenityDto>>(_db.HotelAmenities);
                return hotelAmenityDtos;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelAmenityDto> GetHotelAmenity(int hotelAmenityId)
        {
            try
            {
                HotelAmenityDto hotelAmenityDto = _mapper.Map<HotelAmenity, HotelAmenityDto>(await _db.HotelAmenities.FirstOrDefaultAsync(x => x.Id == hotelAmenityId));

                return hotelAmenityDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // if unique returns hotelAmenityDto else returns null
        public async Task<HotelAmenityDto> IsHotelAmenityUnique(string name, int hotelAmenityId = 0)
        {
            try
            {
                if (hotelAmenityId == 0)
                {
                    HotelAmenityDto hotelAmenityDto = _mapper.Map<HotelAmenity, HotelAmenityDto>(await _db.HotelAmenities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                    return hotelAmenityDto;
                }
                else
                {
                    HotelAmenityDto hotelAmenityDto = _mapper.Map<HotelAmenity, HotelAmenityDto>(await _db.HotelAmenities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id != hotelAmenityId));
                    return hotelAmenityDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<HotelAmenityDto> UpdateHotelAmenity(int hotelAmenityId, HotelAmenityDto hotelAmenityDto)
        {
            try
            {
                if (hotelAmenityId == hotelAmenityDto.Id)
                {
                    //valid
                    HotelAmenity _hotelAmenity = await _db.HotelAmenities.FindAsync(hotelAmenityId);
                    HotelAmenity hotelAmenity = _mapper.Map<HotelAmenityDto, HotelAmenity>(hotelAmenityDto, _hotelAmenity);
                    hotelAmenity.UpdatedBy = "";
                    hotelAmenity.UpdatedDate = DateTime.Now;
                    var updatedHotelAmenity = _db.HotelAmenities.Update(hotelAmenity);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelAmenity, HotelAmenityDto>(updatedHotelAmenity.Entity);
                }
                else
                {
                    //invalid
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
