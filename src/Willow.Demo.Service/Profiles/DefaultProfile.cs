namespace Willow.Demo.Service.Profiles
{
    using AutoMapper;
    using Data;
    using Entities;

    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Job, RxJob>();
            CreateMap<RoomType, RxRoomType>();
        }
    }
}
