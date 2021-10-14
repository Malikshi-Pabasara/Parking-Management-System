using AutoMapper;
using ParkingManagementSystemApi.Data;
using ParkingManagementSystemApi.Models;

namespace ParkingManagementSystemApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>().ReverseMap(); //map the data user to user model and user model to user
            CreateMap<Park, CarParkModel>().ReverseMap();
            CreateMap<Slot, SlotModel>().ReverseMap();
            CreateMap<Vehicle, VehicleModel>().ReverseMap();
            CreateMap<CarParking, ParkingModel>().ReverseMap();
        }
    }
}
