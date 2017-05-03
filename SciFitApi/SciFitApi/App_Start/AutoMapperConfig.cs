using SciFitApi.Models;

namespace SciFitApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
            cfg.CreateMap<SportTemplateModel, SportModel>()
                .ForMember
                (dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember
                (dest => dest.Reps, opts => opts.MapFrom(src => src.Reps))
                .ForMember
                (dest => dest.Image, opts => opts.MapFrom(src => src.Image))
                .ForMember
                (dest => dest.Instructions, opts => opts.MapFrom(src => src.Instructions))
                .ForMember
                (dest => dest.Level, opts => opts.MapFrom(src => src.Level))
                .ForMember
                (dest => dest.Done, opts => opts.MapFrom(src => src.Done))
                .ForMember
                (dest => dest.ImgContent, opts => opts.MapFrom(src => src.ImgContent));
            });

        }
    }
}