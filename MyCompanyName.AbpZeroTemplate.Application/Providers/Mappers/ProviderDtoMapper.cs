
using AutoMapper;
using MyCompanyName.AbpZeroTemplate.Providers.Dtos;

namespace MyCompanyName.AbpZeroTemplate.Providers.Mappers
{
	/// <summary>
    /// ProviderDto映射配置
    /// </summary>
    public class ProviderDtoMapper 
    {

    private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();



        /// <summary>
        /// 初始化映射
        /// </summary>
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
        
		  lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }

        }
    




	    /// <summary>
       ///    Configuration.Modules.AbpAutoMapper().Configurators.Add(ProviderDtoMapper.CreateMappings);
      ///注入位置    < see cref = "AbpZeroTemplateApplicationModule" /> 
     /// <param name="configuration"></param>
    /// </summary>       
	  private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
	  {
	           
			      //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。

	  // Configuration.Modules.AbpAutoMapper().Configurators.Add(ProviderDtoMapper.CreateMappings);

	    //    Mapper.CreateMap<Provider,ProviderEditDto>();
       //     Mapper.CreateMap<Provider, ProviderListDto>();

     //       Mapper.CreateMap<ProviderEditDto, Provider>();
    //        Mapper.CreateMap<ProviderListDto,Provider>();
  






 	  }


}}