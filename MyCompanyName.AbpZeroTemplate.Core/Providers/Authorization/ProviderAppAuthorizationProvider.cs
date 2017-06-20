using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using MyCompanyName.AbpZeroTemplate.Authorization;

namespace MyCompanyName.AbpZeroTemplate.Providers.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ProviderAppPermissions"/> for all permission names.
    /// </summary>
    public class ProviderAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Provider 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var entityNameModel = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
              ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
            var provider = entityNameModel.CreateChildPermission(ProviderAppPermissions.Provider, L("Provider"));
            provider.CreateChildPermission(ProviderAppPermissions.Provider_CreateProvider, L("CreateProvider"));
            provider.CreateChildPermission(ProviderAppPermissions.Provider_EditProvider, L("EditProvider"));
            provider.CreateChildPermission(ProviderAppPermissions.Provider_DeleteProvider, L("DeleteProvider"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}