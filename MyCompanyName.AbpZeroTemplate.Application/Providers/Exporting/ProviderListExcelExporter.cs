using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using MyCompanyName.AbpZeroTemplate.DataExporting.Excel.EpPlus;
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.Providers.Dtos;
using System.Collections.Generic;

namespace MyCompanyName.AbpZeroTemplate.Providers
{
    /// <summary>
    /// 经销商的导出EXCEL功能的实现
    /// </summary>
    public class ProviderListExcelExporter : EpPlusExcelExporterBase, IProviderListExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;


        /// <summary>
        /// 构造方法
        /// </summary>
        public ProviderListExcelExporter(ITimeZoneConverter timeZoneConverter, IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }



        /// <summary>
        /// 导出经销商到EXCEL文件
        /// <param name="providerListDtos">导出信息的DTO</param>
        /// </summary>
        public FileDto ExportProviderToFile(List<ProviderListDto> providerListDtos)
        {


            var file = CreateExcelPackage("providerList.xlsx", excelPackage =>
            {

                var sheet = excelPackage.Workbook.Worksheets.Add(L("Provider"));
                sheet.OutLineApplyStyle = true;

                AddHeader(
                    sheet,
                      L("ProviderName"),
                    L("ProviderId"),
                    L("ShortName"),
                    L("ProviderType"),
                    L("BusinessPhone"),
                    L("BusinessContact"),
                    L("Owner"),
                    L("CreationTime"));
                AddObjects(sheet, 2, providerListDtos,
             _ => _.ProviderName,
             _ => _.ProviderId,
             _ => _.ShortName,
             _ => _.ProviderType,
             _ => _.BusinessPhone,
             _ => _.BusinessContact,
             _ => _.Owner,
        _ => _timeZoneConverter.Convert(_.CreationTime, _abpSession.TenantId, _abpSession.GetUserId())
       );
                //写个时间转换的吧
                //var creationTimeColumn = sheet.Column(10);
                //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";

                for (var i = 1; i <= 8; i++)
                {
                    sheet.Column(i).AutoFit();
                }

            });
            return file;
        }
    }
}
