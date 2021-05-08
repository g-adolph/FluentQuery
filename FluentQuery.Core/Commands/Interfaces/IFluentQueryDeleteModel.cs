// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryDeleteModel.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryDeleteModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    using Manager;
    using Model;

    /// <inheritdoc />
    /// <summary>
    /// The FluentQueryDeleteModel interface.
    /// </summary>
    public interface IFluentQueryDeleteModel : IFluentQueryModel, IFluentQueryWhereModel
    {
        /// <summary>
        /// Gets or sets the delete.
        /// </summary>
        FluentQueryDeleteManager Delete { get; set; }
    }
}