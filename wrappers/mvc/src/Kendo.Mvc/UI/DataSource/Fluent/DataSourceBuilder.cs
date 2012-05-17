﻿using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;

namespace Kendo.Mvc.UI.Fluent
{
    public class DataSourceBuilder<TModel> : IHideObjectMembers
        where TModel : class
    {
        private readonly DataSource dataSource;
        private readonly IUrlGenerator urlGenerator;
        private readonly ViewContext viewContext;

        public DataSourceBuilder(DataSource dataSource, ViewContext viewContext, IUrlGenerator urlGenerator)
        {
            this.viewContext = viewContext;
            this.urlGenerator = urlGenerator;
            this.dataSource = dataSource;
        }

        public DataSourceBuilder<TModel> Read(Action<CrudOperationBuilder> configurator)
        {
            configurator(new CrudOperationBuilder(dataSource.Transport.Read, viewContext, urlGenerator));

            return this;
        }

        public DataSourceBuilder<TModel> PageSize(int pageSize)
        {
            dataSource.PageSize = pageSize;
            return this;
        }

        public DataSourceBuilder<TModel> ServerPaging(bool enabled)
        {
            dataSource.ServerPaging = enabled;
            return this;
        }

        public DataSourceBuilder<TModel> ServerPaging()
        {
            dataSource.ServerPaging = true;
            return this;
        }

        public DataSourceBuilder<TModel> ServerSorting(bool enabled)
        {
            dataSource.ServerSorting = enabled;
            return this;
        }

        public DataSourceBuilder<TModel> ServerSorting()
        {
            dataSource.ServerSorting = true;
            return this;
        }

        public DataSourceBuilder<TModel> ServerFiltering()
        {
            dataSource.ServerFiltering = true;
            return this;
        }

        public DataSourceBuilder<TModel> ServerFiltering(bool enabled)
        {
            dataSource.ServerFiltering = enabled;
            return this;
        }

        /// <summary>
        /// Configures the initial sort order.
        /// </summary>
        /// <param name="configurator">The configurator.</param>
        /// <returns></returns>
        public virtual DataSourceBuilder<TModel> OrderBy(Action<DataSourceSortDescriptorFactory<TModel>> configurator)
        {
            Guard.IsNotNull(configurator, "configurator");           

            configurator(new DataSourceSortDescriptorFactory<TModel>(dataSource.OrderBy));

            return this;
        }
    }
}
