﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryInsertModel.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryInsertModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Insert
{
    /// <summary>
    /// The FluentQueryInsertModel interface.
    /// </summary>
    public interface IFluentQueryInsertModel : IFluentQueryModel
    {
        /// <summary>
        /// Gets or sets the insert.
        /// </summary>
        FluentQueryInsertManager Insert { get; set; }

    }
}