﻿using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxRateTitle"/> entity objects.
    /// </summary>
    public interface ITaxRateTitleRepository : IWhippetRepository<TaxRateTitle, int>, IWhippetExternalQueryRepository<TaxRateTitle, int>
    { }
}