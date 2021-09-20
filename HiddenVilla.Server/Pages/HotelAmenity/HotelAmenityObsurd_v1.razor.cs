//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Models;
//using Business.Repository.IRepository;
//using HiddenVilla.Server.Services.IServices;
//using Microsoft.AspNetCore.Components;
//using Microsoft.JSInterop;
//using HiddenVilla.Server.Helper;
//using Microsoft.AspNetCore.Components.Forms;

//namespace HiddenVilla.Server.Pages.HotelRoom
//{
//    public partial class HotelRoomObsurd
//    {

//        [Parameter]
//        public int? Id { get; set; }
//        private HotelRoomDto hotelRoomDto { get; set; } = new HotelRoomDto();
//        private string Title { get; set; } = "Create";
//        private HotelRoomImageDto RoomImageDto { get; set; } = new HotelRoomImageDto();
//        private readonly IHotelRoomRepository HotelRoomRepository;
//        private readonly IHotelRoomImageRepository HotelRoomImageRepository;
//        private readonly NavigationManager NavigationManager;
//        private readonly IJSRuntime JsRuntime;
//        private readonly IFileUpload FileUpload;

//        public HotelRoomObsurd(IHotelRoomRepository HotelRoomRepositoryI, IHotelRoomImageRepository HotelRoomImageRepositoryI, NavigationManager NavigationManagerI, IJSRuntime JsRuntimeI, IFileUpload FileUploadI)
//        {
//            HotelRoomRepository = HotelRoomRepositoryI;
//            HotelRoomImageRepository = HotelRoomImageRepositoryI;
//            NavigationManager = NavigationManagerI;
//            JsRuntime = JsRuntimeI;
//            FileUpload = FileUploadI;
//        }

//        protected override async Task OnInitializedAsync()
//        {
//            if (Id != null)
//            {
//                //update
//                Title = "Update";
//                hotelRoomDto = await HotelRoomRepository.GetHotelRoom(Id.Value);
//            }
//            else
//            {
//                //create
//                hotelRoomDto = new HotelRoomDto();
//            }
//        }

//        private async Task HandleHotelRoomObsurd()
//        {
//            var roomByName = await HotelRoomRepository.IsRoomUnique(hotelRoomDto.Name, hotelRoomDto.Id);
//            if (roomByName != null)
//            {
//                await JsRuntime.ToastrError("Room name already exists");
//                return;
//            }

//            try
//            {
//                if (hotelRoomDto.Id != 0 && Title == "Update")
//                {
//                    //Update
//                    var updateRoomResult = await HotelRoomRepository.UpdateHotelRoom(hotelRoomDto.Id, hotelRoomDto);
//                    await AddHotelRoomImage(updateRoomResult);
//                    await JsRuntime.ToastrSuccess("Hotel room updated successfully.");
//                }
//                else
//                {
//                    //create
//                    var createdResult = await HotelRoomRepository.CreateHotelRoom(hotelRoomDto);
//                    await JsRuntime.ToastrSuccess("Hotel room created successfully.");
//                }

//            }
//            catch (Exception ex)
//            {
//                // log exceptions
//            }

//            NavigationManager.NavigateTo("hotel-room");


//        }

//        private async Task HandleImageUpload(InputFileChangeEventArgs e)
//        {
//            try
//            {
//                var images = new List<string>();
//                if (e.GetMultipleFiles().Count > 0)
//                {
//                    foreach (var file in e.GetMultipleFiles())
//                    {
//                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.Name);
//                        if (fileInfo.Extension.ToLower() == ".jpg" || fileInfo.Extension.ToLower() == ".jpeg" || fileInfo.Extension.ToLower() == ".png")
//                        {
//                            var uploadedImagePath = await FileUpload.UploadFile(file);
//                            images.Add(uploadedImagePath);
//                        }
//                        else
//                        {
//                            await JsRuntime.ToastrError("Please upload only .jpg, .jpeg or .png files.");
//                            return;
//                        }
//                    }

//                    if (images.Any())
//                    {
//                        if (hotelRoomDto.ImageUrls != null && hotelRoomDto.ImageUrls.Any())
//                        {
//                            hotelRoomDto.ImageUrls.AddRange(images);
//                        }
//                        else
//                        {
//                            hotelRoomDto.ImageUrls = new List<string>();
//                            hotelRoomDto.ImageUrls.AddRange(images);
//                        }
//                    }
//                    else
//                    {
//                        await JsRuntime.ToastrError("Image upload failed");
//                        return;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                await JsRuntime.ToastrError(ex.Message);
//            }
//        }

//        private async Task AddHotelRoomImage(HotelRoomDto roomDto)
//        {
//            foreach (var imageUrl in hotelRoomDto.ImageUrls)
//            {
//                RoomImageDto = new HotelRoomImageDto()
//                {
//                    RoomId = roomDto.Id,
//                    RoomImageUrl = imageUrl
//                };
//                await HotelRoomImageRepository.CreateHotelRoomImage(RoomImageDto);
//            }
//        }
//    }
//}
