 // 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using MyCompanyName.AbpZeroTemplate.Providers;

namespace MyCompanyName.AbpZeroTemplate.Providers.EntityMapper.Providers
{

	/// <summary>
    /// 经销商的数据配置文件
    /// </summary>
    public class ProviderCfg : EntityTypeConfiguration<Provider>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "AbpZeroTemplateDbContext" /> ]
        /// </summary>
        public ProviderCfg()
        {
            ToTable("Provider", AbpZeroTemplateConsts.SchemaName.Basic);

            // 供应商名称
            Property(a => a.ProviderName).HasMaxLength(64);
            // 供应商编号
            Property(a => a.ProviderId).HasMaxLength(16);
            // 简称
            Property(a => a.ShortName).HasMaxLength(16);
            // 供应商种类
            Property(a => a.ProviderType).HasMaxLength(16);
            // 地址
            Property(a => a.Address).HasMaxLength(128);
            // 商务电话
            Property(a => a.BusinessPhone).HasMaxLength(16);
            // 商务联系人
            Property(a => a.BusinessContact).HasMaxLength(16);
            // 所有者
            Property(a => a.Owner).HasMaxLength(16);
        }
    }
}