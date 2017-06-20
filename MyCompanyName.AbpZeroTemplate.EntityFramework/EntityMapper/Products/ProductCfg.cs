using System.Data.Entity.ModelConfiguration;

namespace MyCompanyName.AbpZeroTemplate.Products.EntityMapper.Products
{

    /// <summary>
    /// 产品的数据配置文件
    /// </summary>
    public class ProductCfg : EntityTypeConfiguration<Product>
    {
		/// <summary>
        ///  构造方法[默认链接字符串< see cref = "AbpZeroTemplateDbContext" /> ]
        /// </summary>
		public ProductCfg ()
		{
		    ToTable("Product", AbpZeroTemplateConsts.SchemaName.Basic);
 
		    // 产品编号
			Property(a => a.ProductId).HasMaxLength(16);
		    // 产品名称
			Property(a => a.ProductName).HasMaxLength(32);
		    // 分类
			Property(a => a.Classify).HasMaxLength(16);
		    // 备注
			Property(a => a.Comment).HasMaxLength(128);
		    // 业务大类
			Property(a => a.BusinessCategory).HasMaxLength(16);
		    // 业务类型
			Property(a => a.BusinessType).HasMaxLength(16);
		}
    }
}