namespace MyCompanyName.AbpZeroTemplate.Products.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="ProductAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static class ProductAppPermissions
    {
        /// <summary>
        /// 产品管理权限
        /// </summary>
        public const string Product = "Pages.Product";

		/// <summary>
        /// 产品创建权限
        /// </summary>
        public const string Product_CreateProduct = "Pages.Product.CreateProduct";
		/// <summary>
        /// 产品修改权限
        /// </summary>
        public const string Product_EditProduct = "Pages.Product.EditProduct";
		/// <summary>
        /// 产品删除权限
        /// </summary>
        public const string Product_DeleteProduct = "Pages.Product.DeleteProduct";
    }
	
}

