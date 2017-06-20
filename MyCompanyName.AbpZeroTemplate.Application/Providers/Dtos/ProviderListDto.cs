
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel;

namespace MyCompanyName.AbpZeroTemplate.Providers.Dtos
{
    /// <summary>
    /// 经销商列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Provider))]
    public class ProviderListDto : EntityDto<int>
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        [DisplayName("供应商名称")]
        public string ProviderName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        [DisplayName("供应商编号")]
        public string ProviderId { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        [DisplayName("简称")]
        public string ShortName { get; set; }
        /// <summary>
        /// 供应商种类
        /// </summary>
        [DisplayName("供应商种类")]
        public string ProviderType { get; set; }
        /// <summary>
        /// 商务电话
        /// </summary>
        [DisplayName("商务电话")]
        public string BusinessPhone { get; set; }
        /// <summary>
        /// 商务联系人
        /// </summary>
        [DisplayName("商务联系人")]
        public string BusinessContact { get; set; }
        /// <summary>
        /// 所有者
        /// </summary>
        [DisplayName("所有者")]
        public string Owner { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
