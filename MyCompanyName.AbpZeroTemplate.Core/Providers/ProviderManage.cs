using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace MyCompanyName.AbpZeroTemplate.Providers
{
    /// <summary>
    /// 经销商业务管理
    /// </summary>
    public class ProviderManage : IDomainService
    {
        private readonly IRepository<Provider, int> _providerRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ProviderManage(IRepository<Provider, int> providerRepository)
        {
            _providerRepository = providerRepository;
        }

        //TODO:编写领域业务代码


        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        { }
    }
}
