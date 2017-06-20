using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.Providers.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Providers
{
    /// <summary>
    /// 经销商服务接口
    /// </summary>
    public interface IProviderAppService : IApplicationService
    {
        #region 经销商管理

        /// <summary>
        /// 根据查询条件获取经销商分页列表
        /// </summary>
        Task<PagedResultDto<ProviderListDto>> GetPagedProvidersAsync(GetProviderInput input);

        /// <summary>
        /// 通过Id获取经销商信息进行编辑或修改 
        /// </summary>
        Task<GetProviderForEditOutput> GetProviderForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取经销商ListDto信息
        /// </summary>
        Task<ProviderListDto> GetProviderByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改经销商
        /// </summary>
        Task CreateOrUpdateProviderAsync(CreateOrUpdateProviderInput input);





        /// <summary>
        /// 新增经销商
        /// </summary>
        Task<ProviderEditDto> CreateProviderAsync(ProviderEditDto input);

        /// <summary>
        /// 更新经销商
        /// </summary>
        Task UpdateProviderAsync(ProviderEditDto input);

        /// <summary>
        /// 删除经销商
        /// </summary>
        Task DeleteProviderAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除经销商
        /// </summary>
        Task BatchDeleteProviderAsync(List<int> input);

        #endregion

        #region Excel导出功能



        /// <summary>
        /// 获取经销商信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetProviderToExcel();

        #endregion
    }
}
