namespace Kendo.Mvc.UI.Tests.Chart
{
    using System.Collections.Generic;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;
    using Xunit;

    public class ChartCategoryAxisBuilderTests
    {
        protected IChartCategoryAxis axis;
        protected ChartCategoryAxisBuilder<SalesData> builder;
        protected Chart<SalesData> chart;

        public ChartCategoryAxisBuilderTests()
        {
            chart = ChartTestHelper.CreateChart<SalesData>();
            axis = new ChartCategoryAxis<SalesData>(chart);
            chart.CategoryAxes.Add(axis);
            chart.Data = SalesDataBuilder.GetCollection();
            builder = new ChartCategoryAxisBuilder<SalesData>(chart, axis);
        }

        [Fact]
        public void MajorGridLines_should_return_builder()
        {
            builder.MajorGridLines(lines => { }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void MajorGridLines_should_set_Visible()
        {
            builder.MajorGridLines(1, "green", ChartDashType.Dot);
            axis.MajorGridLines.Visible.ShouldEqual(true);
        }

        [Fact]
        public void MajorGridLines_should_set_Width()
        {
            builder.MajorGridLines(1, "green", ChartDashType.Dot);
            axis.MajorGridLines.Width.ShouldEqual(1);
        }

        [Fact]
        public void MajorGridLines_should_set_Color()
        {
            builder.MajorGridLines(1, "green", ChartDashType.Dot);
            axis.MajorGridLines.Color.ShouldEqual("green");
        }

        [Fact]
        public void MajorGridLines_should_set_DashType()
        {
            builder.MajorGridLines(1, "green", ChartDashType.Dot);
            axis.MajorGridLines.DashType.ShouldEqual(ChartDashType.Dot);
        }

        [Fact]
        public void MinorGridLines_should_return_builder()
        {
            builder.MinorGridLines(lines => { }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void MinorGridLines_should_set_Visible()
        {
            builder.MinorGridLines(1, "green", ChartDashType.Dot);
            axis.MinorGridLines.Visible.ShouldEqual(true);
        }

        [Fact]
        public void MinorGridLines_should_set_Width()
        {
            builder.MinorGridLines(1, "green", ChartDashType.Dot);
            axis.MinorGridLines.Width.ShouldEqual(1);
        }

        [Fact]
        public void MinorGridLines_should_set_Color()
        {
            builder.MinorGridLines(1, "green", ChartDashType.Dot);
            axis.MinorGridLines.Color.ShouldEqual("green");
        }

        [Fact]
        public void MinorGridLines_should_set_DashType()
        {
            builder.MinorGridLines(1, "green", ChartDashType.Dot);
            axis.MinorGridLines.DashType.ShouldEqual(ChartDashType.Dot);
        }

        [Fact]
        public void Line_should_return_builder()
        {
            builder.Line(line => { }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Line_should_set_Visible()
        {
            builder.Line(1, "green", ChartDashType.Dot);
            axis.Line.Visible.ShouldEqual(true);
        }

        [Fact]
        public void Line_should_set_Width()
        {
            builder.Line(1, "green", ChartDashType.Dot);
            axis.Line.Width.ShouldEqual(1);
        }

        [Fact]
        public void Line_should_set_Color()
        {
            builder.Line(1, "green", ChartDashType.Dot);
            axis.Line.Color.ShouldEqual("green");
        }

        [Fact]
        public void Line_should_set_DashType()
        {
            builder.Line(1, "green", ChartDashType.Dot);
            axis.Line.DashType.ShouldEqual(ChartDashType.Dot);
        }

        [Fact]
        public void Labels_should_set_Labels()
        {
            builder.Labels(true);
            axis.Labels.Visible.ShouldEqual(true);
        }

        [Fact]
        public void Labels_should_return_builder()
        {
            builder.Labels(true).ShouldBeSameAs(builder);
        }

        [Fact]
        public void PlotBands_should_return_builder()
        {
            builder.PlotBands(pb => { }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Title_should_set_title_text()
        {
            builder.Title("Title");
            axis.Title.Text.ShouldEqual("Title");
        }

        [Fact]
        public void Title_should_return_builder()
        {
            builder.Title(t => { }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Type_should_set_type_text()
        {
            builder.Type(ChartCategoryAxisType.Category);
            axis.Type.ShouldEqual(ChartCategoryAxisType.Category);
        }

        [Fact]
        public void Type_should_return_builder()
        {
            builder.Type(ChartCategoryAxisType.Category).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Color_should_set_color()
        {
            builder.Color("#f00");
            axis.Color.ShouldEqual("#f00");
        }

        [Fact]
        public void Color_should_return_builder()
        {
            builder.Color("#f00").ShouldBeSameAs(builder);
        }

        [Fact]
        public void Reverse_should_set_reverse()
        {
            builder.Reverse(true);
            axis.Reverse.ShouldEqual(true);
        }

        [Fact]
        public void Reverse_should_set_reverse_to_true()
        {
            builder.Reverse();
            axis.Reverse.ShouldEqual(true);
        }

        [Fact]
        public void Reverse_should_return_builder()
        {
            builder.Reverse(true).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Justify_should_set_justified()
        {
            builder.Justify(false);
            axis.Justified.ShouldEqual(false);
        }

        [Fact]
        public void Justify_should_set_justified_to_true()
        {
            builder.Justify();
            axis.Justified.ShouldEqual(true);
        }

        [Fact]
        public void Justify_should_return_builder()
        {
            builder.Justify(false).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Categories_should_not_bind_categories_from_expression()
        {
            builder.Categories(s => s.DateString);
            axis.Categories.ShouldBeNull();
        }

        [Fact]
        public void Categories_set_member_field_with_expression()
        {
            builder.Categories(s => s.Date);
            axis.Member.ShouldEqual("Date");
        }

        [Fact]
        public void Categories_should_return_builder_with_expression()
        {
            builder.Categories(s => s.DateString).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Categories_should_set_categories_from_IEnumerable()
        {
            var categories = new string[] { "Aug 2010", "Sept 2010" };

            builder.Categories(categories);

            axis.Categories.ShouldBeSameAs(categories);
        }

        [Fact]
        public void Categories_should_return_builder_with_IEnumerable()
        {
            var categories = new string[] { "Aug 2010", "Sept 2010" };

            builder.Categories(categories).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Categories_should_set_categories_from_list()
        {
            builder.Categories("Aug 2010", "Sept 2010");

            AssertCategories(new string[] { "Aug 2010", "Sept 2010" });
        }

        [Fact]
        public void Categories_should_return_builder_with_list()
        {
            builder.Categories("Aug 2010", "Sept 2010").ShouldBeSameAs(builder);
        }

        [Fact]
        public void Date_sets_type_to_date()
        {
            builder.Date();
            axis.Type.ShouldEqual(ChartCategoryAxisType.Date);
        }

        [Fact]
        public void AxisCrossingValue_should_set_single_value()
        {
            builder.AxisCrossingValue(42);
            axis.AxisCrossingValues.ShouldEqual(new double[] { 42 });
        }

        [Fact]
        public void AxisCrossingValue_should_return_builder()
        {
            builder.AxisCrossingValue(42).ShouldBeSameAs(builder);
        }

        [Fact]
        public void AxisCrossingValue_should_set_multiple_values_from_params()
        {
            builder.AxisCrossingValue(42, 43);
            axis.AxisCrossingValues.ShouldEqual(new double[] { 42, 43 });
        }

        [Fact]
        public void AxisCrossingValue_overload_with_params_should_return_builder()
        {
            builder.AxisCrossingValue(42, 43).ShouldBeSameAs(builder);
        }

        [Fact]
        public void AxisCrossingValue_should_set_multiple_values_from_enumerable()
        {
            builder.AxisCrossingValue(new double[] { 42, 43 });
            axis.AxisCrossingValues.ShouldEqual(new double[] { 42, 43 });
        }

        [Fact]
        public void AxisCrossingValue_overload_with_enumerable_should_return_builder()
        {
            builder.AxisCrossingValue(new double[] { 42, 43 }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Select_should_set_from_and_to_dates()
        {
            builder.Select(0.0, 1.0);

            axis.Select.From.ShouldEqual(0.0);
            axis.Select.To.ShouldEqual(1.0);
        }

        [Fact]
        public void Select_should_return_builder()
        {
            builder.Select(0, 1).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Select_builder_should_return_builder()
        {
            builder.Select(select => { }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void StartAngle_should_set_StartAngle()
        {
            builder.StartAngle(10);
            axis.StartAngle.ShouldEqual(10);
        }

        [Fact]
        public void StartAngle_should_return_builder()
        {
            builder.StartAngle(10).ShouldBeSameAs(builder);
        }

        private void AssertCategories<T>(IEnumerable<T> categories)
        {
            var expectedCategories = new Queue<T>();
            foreach (var category in categories)
            {
                expectedCategories.Enqueue(category);
            }

            var categoryStrings = builder.Axis.Categories;
            foreach (T category in categoryStrings)
            {
                category.ShouldEqual<T>(expectedCategories.Dequeue());
            }
        }
    }
}
