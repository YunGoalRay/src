namespace MyCompanyName.AbpZeroTemplate.Providers.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
     /// <see cref="ProviderAppAuthorizationProvider"/>中对权限的定义.
     /// </summary>
  public static   class ProviderAppPermissions
    {
        /// <summary>
        /// 经销商管理权限
        /// </summary>
        public const string Provider = "Pages.Provider";
		/// <summary>
        /// 经销商创建权限
        /// </summary>
        public const string Provider_CreateProvider = "Pages.Provider.CreateProvider";
		/// <summary>
        /// 经销商修改权限
        /// </summary>
        public const string Provider_EditProvider = "Pages.Provider.EditProvider";
		/// <summary>
        /// 经销商删除权限
        /// </summary>
        public const string Provider_DeleteProvider = "Pages.Provider.DeleteProvider";
    }
}

