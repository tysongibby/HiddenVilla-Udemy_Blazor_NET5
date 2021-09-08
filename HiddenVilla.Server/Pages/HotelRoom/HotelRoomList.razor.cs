using Business.Repository.IRepository;
using Microsoft.AspNetCore.Components;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//@inject IHotelRoomRepository HotelRoomRepository
//@inject NavigationManager NavigationManager

//namespace HiddenVilla.Server.Pages.HotelRoom
//{
//    public partial class HotelRoomList
//    {
//        private IEnumerable<HotelRoomDto> HotelRoomDtos { get; set; } = new List<HotelRoomDto>();
//        private readonly IHotelRoomRepository _HotelRoomRepository;
//        private readonly NavigationManager _NavigationManager;

//        public HotelRoomList(IHotelRoomRepository HotelRoomRepository, NavigationManager NavigationManager)
//        {
//            _HotelRoomRepository = HotelRoomRepository;
//            _NavigationManager = NavigationManager;
//        }
//        protected override async Task OnInitializedAsync()
//        {
//            HotelRoomDtos = await _HotelRoomRepository.GetAllHotelRooms();
//        }
//    }
//}
