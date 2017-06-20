using Abp.Domain.Entities.Auditing;

namespace MyCompanyName.AbpZeroTemplate.Products
{
    public class Product : FullAuditedEntity
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public virtual string ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public virtual string ProductName { get; set; }
        
        /// <summary>
        /// 分类
        /// </summary>
        public virtual string Classify { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Comment { get; set; }
        /// <summary>
        /// 业务大类
        /// </summary>
        public virtual string BusinessCategory { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public virtual string BusinessType { get; set; }
    }
}
