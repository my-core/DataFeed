using AutoMapper;
using DataFeed.Framework.Model;
using DataFeed.Finance.WebApi.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFeed.Finance.WebApi
{
    /// <summary>
    /// automapper 映射
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<StockInfo, GetStockCodeResponse>().ReverseMap();
        }
    }
}
