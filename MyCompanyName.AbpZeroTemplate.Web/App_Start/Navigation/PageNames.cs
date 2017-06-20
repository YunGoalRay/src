namespace MyCompanyName.AbpZeroTemplate.Web.Navigation
{
    public static class PageNames
    {
        public static class App
        {
            public static class Common
            {
                public const string Administration = "Administration";
                public const string Roles = "Administration.Roles";
                public const string Users = "Administration.Users";
                public const string AuditLogs = "Administration.AuditLogs";
                public const string OrganizationUnits = "Administration.OrganizationUnits";
                public const string Languages = "Administration.Languages";

                public const string Shop = "Shop";
                public const string Category = "Category";

                public const string Product = "Product";
                public const string Client = "Client";
                public const string Provider = "Provider";
            }

            public static class Host
            {
                public const string Tenants = "Tenants";
                public const string Editions = "Editions";
                public const string Maintenance = "Administration.Maintenance";
                public const string Settings = "Administration.Settings.Host";

                public const string BasicData = "BasicData";
                public const string SalesManagement = "SalesManagement";
                public const string PurchasingManagement = "PurchasingManagement";
                public const string BusinessReport = "BusinessReport";
            }

            public static class SalesManagement
            {
                public const string SalesOff = "SalesOff";
                public const string ChangeLog = "ChangeLog";
                public const string Manage = "Manage";
                public const string TestExpirationReminder = "TestExpirationReminder";
                public const string Changed = "Changed";
                public const string StatementsManagement = "StatementsManagement";
                public const string AccountsManagement = "AccountsManagement";
                public const string ExpirationReminder = "ExpirationReminder";
                public const string ExpirationAlert = "ExpirationAlert";
            }

            public static class PurchasingManagement
            {
                public const string Product = "Product";
                public const string Client = "Client";
                public const string Provider = "Provider";
            }

            public static class BusinessReport
            {
                public const string Product = "Product";
                public const string Client = "Client";
                public const string Provider = "Provider";
            }

            public static class Tenant
            {
                public const string Dashboard = "Dashboard.Tenant";
                public const string Settings = "Administration.Settings.Tenant";
                public const string Test = "Test";//这里是添加的常量
            }
        }

        public static class Frontend
        {
            public const string Home = "Frontend.Home";
            public const string About = "Frontend.About";
        }
    }
}