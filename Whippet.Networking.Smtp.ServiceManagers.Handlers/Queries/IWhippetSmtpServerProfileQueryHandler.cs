using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetSmtpServerProfile"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetSmtpServerProfileQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetSmtpServerProfile> where TQuery : IWhippetQuery<WhippetSmtpServerProfile>
    { }
}
