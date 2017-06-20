using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel;

namespace MyCompanyName.AbpZeroTemplate.Products.Dtos
{
    /// <summary>
    /// 产品列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Product))]
    public class ProductListDto : EntityDto<int>
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        [DisplayName("产品编号")]
        public      string ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("产品名称")]
        public      string ProductName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [DisplayName("分类")]
        public      string Classify { get; set; }
        /// <summary>
        /// 业务大类
        /// </summary>
        [DisplayName("业务大类")]
        public      string BusinessCategory { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        [DisplayName("业务类型")]
        public      string BusinessType { get; set; }
    }
}
