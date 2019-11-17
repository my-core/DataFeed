using AutoMapper;
using DataFeed.Framework.Model;
using DataFeed.Geography.WebApi.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFeed.Geography.WebApi
{
    /// <summary>
    /// automapper 映射
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ProvinceInfo, GetProvinceResponse>().ReverseMap();
            CreateMap<CityInfo, GetCityResponse>().ReverseMap();
            CreateMap<CountyInfo, GetCountyResponse>().ReverseMap();
            CreateMap<TownInfo, GetTownResponse>().ReverseMap();
            CreateMap<VillageInfo, GetVillageResponse>().ReverseMap();
        }
    }
}
