using System;
using System.Collections.Generic;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartYAxisTitleSettings
    /// </summary>
    public partial class ChartYAxisTitleSettingsBuilder
        
    {
        public ChartYAxisTitleSettingsBuilder(ChartYAxisTitleSettings container)
        {
            Container = container;
        }

        protected ChartYAxisTitleSettings Container
        {
            get;
            private set;
        }

        // Place custom settings here
    }
}
