using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.EntityMappings.AccessControl
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetRoleUserAssignment"/> objects.
    /// </summary>
    public class WhippetRoleUserAssignmentMap : WhippetAuditableFluentMap<WhippetRoleUserAssignment>
    {
        private const string TABLE_NAME = "[Security.Roles.Assignments]";

        private const string COL_USERID = "ReadOnly__UserID";
        private const string COL_ROLEID = "ReadOnly__RoleID";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentMap"/> class with no arguments.
        /// </summary>
        public WhippetRoleUserAssignmentMap()
            : base(TABLE_NAME)
        {
            Map(gu => gu.UserID).Column(COL_USERID).Not.Nullable();
            Map(gu => gu.RoleID).Column(COL_ROLEID).Not.Nullable();

            References<WhippetUser>(ru => ru.User).Not.Nullable().LazyLoad(Laziness.False);
            References<WhippetRole>(ru => ru.Role).Not.Nullable();

            this.MapActiveEntity();
            this.MapDeletedEntity();
        }
    }
}
