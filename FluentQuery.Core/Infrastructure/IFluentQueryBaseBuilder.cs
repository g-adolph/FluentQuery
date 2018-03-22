// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryBaseBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryBaseBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Infrastructure
{
    using global::FluentQuery.Core.Builder.Interfaces;
    using global::FluentQuery.Core.Commands.Interfaces;

    /// <summary>
    /// The FluentQueryBaseBuilder interface.
    /// </summary>
    /// <typeparam name="TQueryModel">
    /// Query Model Type
    /// </typeparam>
    public interface IFluentQueryBaseBuilder<out TQueryModel>
        where TQueryModel : IFluentQueryModel
    {
        /// <summary>
        /// The command query return.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CommandQuery();

        /// <summary>
        /// The parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryParametersBuilder"/>.
        /// </returns>
        IFluentQueryParametersBuilder Parameters();

        /// <summary>
        /// The get query model.
        /// </summary>
        /// <returns>
        /// The <see cref="TQueryModel"/>.
        /// </returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        TQueryModel GetQueryModel();
    }
}