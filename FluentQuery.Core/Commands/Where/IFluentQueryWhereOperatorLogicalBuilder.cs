namespace FluentQuery.Core.Commands.Where
{
    /// <summary>
    /// The FluentQueryWhereOperatorLogicalBuilder interface.
    /// </summary>
    /// <typeparam name="TStatementBuilder">
    /// Statement Type
    /// </typeparam>
    public interface IFluentQueryWhereOperatorLogicalBuilder<TStatementBuilder>
    {
        /// <summary>
        /// The and.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> And();

        /// <summary>
        /// The or.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> Or();

        /// <summary>
        /// The in.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> In();

        /// <summary>
        /// The exists.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> Exists();

        /// <summary>
        /// The not.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> Not();
    }
}