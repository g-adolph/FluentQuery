// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionColumnTypeModelHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The reflection column type model helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Infrastructure.Reflection
{
    using Commands.Interfaces;

    /// <summary>
    /// The reflection column type model helper.
    /// </summary>
    public static class ReflectionColumnHelper
    {
        /// <summary>
        /// The is primary key.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsPrimaryKey(this ReflectionColumnTypeModel column)
        {
            if (column.ColumnSelectItem?.CustomProperties == null)
            {
                return false;
            }

            column.ColumnSelectItem.CustomProperties.TryGetValue("key", out var isPrimaryKey);

            if (isPrimaryKey != null && !((bool)isPrimaryKey))
            {
                return column.ColumnSelectItem.Name.ToLower() == "id";
            }


            return isPrimaryKey != null && ((bool)isPrimaryKey);
        }

        /// <summary>
        /// The is primary key.
        /// </summary>
        /// <param name="columnSelectItem">
        /// The column select item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsPrimaryKey(this IFluentQuerySelectItem columnSelectItem)
        {
            if (columnSelectItem?.CustomProperties == null)
            {
                return false;
            }

            columnSelectItem.CustomProperties.TryGetValue("key", out var isPrimaryKey);

            if (isPrimaryKey != null && !((bool)isPrimaryKey))
            {
                return columnSelectItem.Name.ToLower() == "id";
            }


            return isPrimaryKey != null && ((bool)isPrimaryKey);
        }

        /// <summary>
        /// The is foreign key.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsForeignKey(this ReflectionColumnTypeModel column)
        {
            if (column?.ColumnSelectItem?.CustomProperties == null)
            {
                return false;
            }

            column.ColumnSelectItem.CustomProperties.TryGetValue("foreignKey", out var foreignKey);

            return foreignKey != null;
        }

        /// <summary>
        /// The is foreign key.
        /// </summary>
        /// <param name="columnSelectItem">
        /// The column select item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsForeignKey(this IFluentQuerySelectItem columnSelectItem)
        {
            if (columnSelectItem?.CustomProperties == null)
            {
                return false;
            }

            columnSelectItem.CustomProperties.TryGetValue("foreignKey", out var foreignKey);

            return foreignKey != null;
        }
    }
}
