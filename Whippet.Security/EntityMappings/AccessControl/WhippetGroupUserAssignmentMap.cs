using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Athi.Whippet.Data.NHibernate.FluentNHibernate;
using Athi.Whippet.Data.NHibernate.FluentNHibernate.Extensions;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Security.EntityMappings.AccessControl
{
    /// <summary>
    /// Provides a Fluent mapping for <see cref="WhippetGroupUserAssignment"/> objects.
    /// </summary>
    public class WhippetGroupUserAssignmentMap : WhippetAuditableFluentMap<WhippetGroupUserAssignment>
    {
        private const string TABLE_NAME = "[Security.Groups.Assignments]";

        private const string COL_USERID = "ReadOnly__UserID";
        private const string COL_GROUPID = "ReadOnly__GroupID";

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentMap"/> class with no arguments.
        /// </summary>
        public WhippetGroupUserAssignmentMap()
            : base(TABLE_NAME)
        {
            Map(gu => gu.UserID).Column(COL_USERID).Not.Nullable();
            Map(gu => gu.GroupID).Column(COL_GROUPID).Not.Nullable();

            References<WhippetUser>(gu => gu.User).Not.Nullable().LazyLoad(Laziness.False);
            References<WhippetGroup>(gu => gu.Group).Not.Nullable();

            this.MapActiveEntity();
            this.MapDeletedEntity();
        }
    }
}
