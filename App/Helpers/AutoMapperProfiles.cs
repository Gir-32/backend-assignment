namespace App.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Player, PlayerDto>();
        CreateMap<CasinoWager, CasinoListDto>()
            .ForMember(dest => dest.WagerId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.Game.Name))
            .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider.Name))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDatetime.ToUniversalTime()));
    }
}
