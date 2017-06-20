
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.Providers.Dtos;
using System.Collections.Generic;

namespace MyCompanyName.AbpZeroTemplate.Providers
{
    /// <summary>
    /// 经销商的数据导出功能 
    /// </summary>
    public interface IProviderListExcelExporter
    {
        /// <summary>
        /// 导出经销商到EXCEL文件
        /// <param name="providerListDtos">导出信息的DTO</param>
        /// </summary>
        FileDto ExportProviderToFile(List<ProviderListDto> providerListDtos);
    }
}