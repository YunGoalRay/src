using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using MyCompanyName.AbpZeroTemplate.Authorization;

namespace MyCompanyName.AbpZeroTemplate.Products.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ProductAppPermissions"/> for all permission names.
    /// </summary>
    public class ProductAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Product 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
              ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
            var product = entityNameModel.CreateChildPermission(ProductAppPermissions.Product, L("Product"));
            product.CreateChildPermission(ProductAppPermissions.Product_CreateProduct, L("CreateProduct"));
            product.CreateChildPermission(ProductAppPermissions.Product_EditProduct, L("EditProduct"));
            product.CreateChildPermission(ProductAppPermissions.Product_DeleteProduct, L("DeleteProduct"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}