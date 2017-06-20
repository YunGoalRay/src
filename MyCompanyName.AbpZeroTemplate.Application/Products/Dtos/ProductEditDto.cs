using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Products.Dtos
{
    /// <summary>
    /// 产品编辑用Dto
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        [DisplayName("产品编号")]
        [Required]
        [MaxLength(16)]
        public string ProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("产品名称")]
        [Required]
        [MaxLength(32)]
        public string ProductName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [DisplayName("分类")]
        [Required]
        [MaxLength(16)]
        public string Classify { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        [MaxLength(128)]
        public string Comment { get; set; }

        /// <summary>
        /// 业务大类
        /// </summary>
        [DisplayName("业务大类")]
        [Required]
        [MaxLength(16)]
        public string BusinessCategory { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        [DisplayName("业务类型")]
        [Required]
        [MaxLength(16)]
        public string BusinessType { get; set; }

    }
}
