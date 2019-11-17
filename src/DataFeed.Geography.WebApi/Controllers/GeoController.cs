using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataFeed.Geography.WebApi.Contract.Response;
using DataFeed.Geography.WebApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataFeed.Geography.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeoController : ControllerBase
    {
        private readonly ILogger<GeoController> _logger;
        private GeographyService _geographyService;

        public GeoController(ILogger<GeoController> logger, GeographyService geographyService)
        {
            _logger = logger;
            _geographyService = geographyService;
        }

        /// <summary>
        /// 获取省信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("Province")]
        public ApiResponse<List<GetProvinceResponse>> ProvinceList()
        {
            return _geographyService.GetProvinceList();
        }
        /// <summary>
        /// 获取市信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("City")]
        public ApiResponse<List<GetCityResponse>> CityList(string provinceCode)
        {
            return _geographyService.GetCityList(provinceCode);
        }
        /// <summary>
        /// 获取区信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("County")]
        public ApiResponse<List<GetCountyResponse>> CountyList(string cityCode)
        {
            return _geographyService.GetCountyList(cityCode);
        }
        /// <summary>
        /// 获取镇信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("Town")]
        public ApiResponse<List<GetTownResponse>> TownList(string countyCode)
        {
            return _geographyService.GetTownList(countyCode);
        }
        /// <summary>
        /// 获取村信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("Village")]
        public ApiResponse<List<GetVillageResponse>> VillageList(string townCode)
        {
            return _geographyService.GetVillageList(townCode);
        }
    }
}
