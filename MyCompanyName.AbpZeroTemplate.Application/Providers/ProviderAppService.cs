using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.Providers.Authorization;
using MyCompanyName.AbpZeroTemplate.Providers.Dtos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Providers
{
    /// <summary>
    /// 经销商服务实现
    /// </summary>
    [AbpAuthorize(ProviderAppPermissions.Provider)]
    public class ProviderAppService : AbpZeroTemplateAppServiceBase, IProviderAppService
    {
        private readonly IRepository<Provider, int> _providerRepository;
        private readonly IProviderListExcelExporter _providerListExcelExporter;


        private readonly ProviderManage _providerManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public ProviderAppService(IRepository<Provider, int> providerRepository,
ProviderManage providerManage
      , IProviderListExcelExporter providerListExcelExporter
  )
        {
            _providerRepository = providerRepository;
            _providerManage = providerManage;
            _providerListExcelExporter = providerListExcelExporter;
        }

        #region 经销商管理

        /// <summary>
        /// 根据查询条件获取经销商分页列表
        /// </summary>
        public async Task<PagedResultDto<ProviderListDto>> GetPagedProvidersAsync(GetProviderInput input)
        {

            var query = _providerRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var providerCount = await query.CountAsync();

            var providers = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var providerListDtos = providers.MapTo<List<ProviderListDto>>();
            return new PagedResultDto<ProviderListDto>(
            providerCount,
            providerListDtos
            );
        }

        /// <summary>
        /// 通过Id获取经销商信息进行编辑或修改 
        /// </summary>
        public async Task<GetProviderForEditOutput> GetProviderForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetProviderForEditOutput();

            ProviderEditDto providerEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _providerRepository.GetAsync(input.Id.Value);
                providerEditDto = entity.MapTo<ProviderEditDto>();
            }
            else
            {
                providerEditDto = new ProviderEditDto();
            }

            output.Provider = providerEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取经销商ListDto信息
        /// </summary>
        public async Task<ProviderListDto> GetProviderByIdAsync(EntityDto<int> input)
        {
            var entity = await _providerRepository.GetAsync(input.Id);

            return entity.MapTo<ProviderListDto>();
        }







        /// <summary>
        /// 新增或更改经销商
        /// </summary>
        public async Task CreateOrUpdateProviderAsync(CreateOrUpdateProviderInput input)
        {
            if (input.ProviderEditDto.Id.HasValue)
            {
                await UpdateProviderAsync(input.ProviderEditDto);
            }
            else
            {
                await CreateProviderAsync(input.ProviderEditDto);
            }
        }

        /// <summary>
        /// 新增经销商
        /// </summary>
        [AbpAuthorize(ProviderAppPermissions.Provider_CreateProvider)]
        public virtual async Task<ProviderEditDto> CreateProviderAsync(ProviderEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Provider>();

            entity = await _providerRepository.InsertAsync(entity);
            return entity.MapTo<ProviderEditDto>();
        }

        /// <summary>
        /// 编辑经销商
        /// </summary>
        [AbpAuthorize(ProviderAppPermissions.Provider_EditProvider)]
        public virtual async Task UpdateProviderAsync(ProviderEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _providerRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _providerRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除经销商
        /// </summary>
        [AbpAuthorize(ProviderAppPermissions.Provider_DeleteProvider)]
        public async Task DeleteProviderAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _providerRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除经销商
        /// </summary>
        [AbpAuthorize(ProviderAppPermissions.Provider_DeleteProvider)]
        public async Task BatchDeleteProviderAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _providerRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


        #region 经销商的Excel导出功能


        public async Task<FileDto> GetProviderToExcel()
        {
            var entities = await _providerRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<ProviderListDto>>();

            var fileDto = _providerListExcelExporter.ExportProviderToFile(dtos);



            return fileDto;
        }


        #endregion
    }
}
