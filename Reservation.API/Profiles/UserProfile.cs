using AutoMapper;

namespace Reservation.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Model.User, Model.UserDTO>();
    }
}