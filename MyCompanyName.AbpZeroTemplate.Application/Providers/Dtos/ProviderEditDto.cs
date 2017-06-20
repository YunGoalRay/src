using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Providers.Dtos
{
    /// <summary>
    /// 经销商编辑用Dto
    /// </summary>
    [AutoMap(typeof(Provider))]
    public class ProviderEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [DisplayName("供应商名称")]
        [Required]
        [MaxLength(64)]
        public string ProviderName { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [DisplayName("供应商编号")]
        [Required]
        [MaxLength(16)]
        public string ProviderId { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [DisplayName("简称")]
        [MaxLength(16)]
        public string ShortName { get; set; }

        /// <summary>
        /// 供应商种类
        /// </summary>
        [DisplayName("供应商种类")]
        [Required]
        [MaxLength(16)]
        public string ProviderType { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DisplayName("地址")]
        [MaxLength(128)]
        public string Address { get; set; }

        /// <summary>
        /// 商务电话
        /// </summary>
        [DisplayName("商务电话")]
        [MaxLength(16)]
        public string BusinessPhone { get; set; }

        /// <summary>
        /// 商务联系人
        /// </summary>
        [DisplayName("商务联系人")]
        [MaxLength(16)]
        public string BusinessContact { get; set; }

        /// <summary>
        /// 所有者
        /// </summary>
        [DisplayName("所有者")]
        [MaxLength(16)]
        public string Owner { get; set; }

    }
}
