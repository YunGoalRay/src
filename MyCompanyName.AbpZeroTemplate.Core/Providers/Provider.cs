using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Providers
{
    public class Provider : FullAuditedEntity
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public virtual string ProviderName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public virtual string ProviderId { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public virtual string ShortName { get; set; }
        /// <summary>
        /// 供应商种类
        /// </summary>
        public virtual string ProviderType { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 商务电话
        /// </summary>
        public virtual string BusinessPhone { get; set; }
        /// <summary>
        /// 商务联系人
        /// </summary>
        public virtual string BusinessContact { get; set; }
        /// <summary>
        /// 所有者
        /// </summary>
        public virtual string Owner { get; set; }
    }
}
