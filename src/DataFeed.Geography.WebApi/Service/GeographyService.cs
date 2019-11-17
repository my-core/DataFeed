using AutoMapper;
using DataFeed.Framework.Model;
using DataFeed.Framework.Service;
using DataFeed.Geography.WebApi.Contract.Response;
using DataFeed.Geography.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFeed.Geography.WebApi.Service
{
    public class GeographyService : BaseService, IBaseService
    {
        private IMapper _mapper;
        public GeographyService(GeographyRepository geographyRepository, IMapper mapper)
            : base(geographyRepository)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        public ApiResponse<List<GetProvinceResponse>> GetProvinceList()
        {
            var response = new ApiResponse<List<GetProvinceResponse>> { Data = new List<GetProvinceResponse>() };
            var provinceList = GetList<ProvinceInfo>();
            provinceList.ForEach(item =>
            {
                response.Data.Add(_mapper.Map<GetProvinceResponse>(item));
            });
            return response;
        }
        /// <summary>
        /// 市
        /// </summary>
        /// <returns></returns>
        public ApiResponse<List<GetCityResponse>> GetCityList(string provinceCode)
        {
            var response = new ApiResponse<List<GetCityResponse>> { Data = new List<GetCityResponse>() };
            var cityList = GetList<CityInfo>(new { provinceCode });
            cityList.ForEach(item =>
            {
                response.Data.Add(_mapper.Map<GetCityResponse>(item));
            });
            return response;
        }
        /// <summary>
        /// 区
        /// </summary>
        /// <returns></returns>
        public ApiResponse<List<GetCountyResponse>> GetCountyList(string cityCode)
        {
            var response = new ApiResponse<List<GetCountyResponse>> { Data = new List<GetCountyResponse>() };
            var countyList = GetList<CountyInfo>(new { cityCode});
            countyList.ForEach(item =>
            {
                response.Data.Add(_mapper.Map<GetCountyResponse>(item));
            });
            return response;
        }
        /// <summary>
        /// 镇
        /// </summary>
        /// <returns></returns>
        public ApiResponse<List<GetTownResponse>> GetTownList(string countyCode)
        {
            var response = new ApiResponse<List<GetTownResponse>> { Data = new List<GetTownResponse>() };
            var townList = GetList<TownInfo>(new { countyCode });
            townList.ForEach(item =>
            {
                response.Data.Add(_mapper.Map<GetTownResponse>(item));
            });
            return response;
        }
        /// <summary>
        /// 村
        /// </summary>
        /// <returns></returns>
        public ApiResponse<List<GetVillageResponse>> GetVillageList(string townCode)
        {
            var response = new ApiResponse<List<GetVillageResponse>> { Data = new List<GetVillageResponse>() };
            var villageList = GetList<VillageInfo>(new { townCode });
            villageList.ForEach(item =>
            {
                response.Data.Add(_mapper.Map<GetVillageResponse>(item));
            });
            return response;
        }
    }
}
