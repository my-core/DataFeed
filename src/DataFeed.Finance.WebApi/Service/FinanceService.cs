using AutoMapper;
using DataFeed.Finance.WebApi.Contract.Request;
using DataFeed.Finance.WebApi.Contract.Response;
using DataFeed.Finance.WebApi.Repository;
using DataFeed.Framework.Model;
using DataFeed.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFeed.Finance.WebApi.Service
{
    /// <summary>
    /// 金融相关业务
    /// </summary>
    public class FinanceService : BaseService, IBaseService
    {
        private IMapper _mapper;
        private FinanceRepository _financeRepository;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="financeRepository"></param>
        /// <param name="mapper"></param>
        public FinanceService(FinanceRepository financeRepository, IMapper mapper)
            : base(financeRepository)
        {
            _mapper = mapper;
            _financeRepository = financeRepository;
        }
        /// <summary>
        /// 股票代码
        /// </summary>
        /// <returns></returns>
        public ApiResponse<List<GetStockCodeResponse>> GetStockCodeList(GetStockCodeRequest request)
        {
            var response = new ApiResponse<List<GetStockCodeResponse>> { Data = new List<GetStockCodeResponse>() };
            var provinceList = _financeRepository.GetStockCodeList(request);
            provinceList.ForEach(item =>
            {
                response.Data.Add(_mapper.Map<GetStockCodeResponse>(item));
            });
            return response;
        }          
    }
}
