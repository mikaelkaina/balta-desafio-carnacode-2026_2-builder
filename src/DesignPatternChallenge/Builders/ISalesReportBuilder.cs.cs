using System;
using DesignPatternChallenge;

namespace DesignPatternChallenge.Builders
{
    public interface ISalesReportBuilder
    {
        ISalesReportBuilder WithPeriod(DateTime start, DateTime end);
        ISalesReportBuilder WithHeader(string headerText);
        ISalesReportBuilder WithFooter(string footerText);
        ISalesReportBuilder AddColumn(string column);
        ISalesReportBuilder AddFilter(string filter);
        ISalesReportBuilder WithCharts(string chartType);
        ISalesReportBuilder GroupBy(string groupBy);
        ISalesReportBuilder SortBy(string sortBy);
        ISalesReportBuilder IncludeTotals();
        ISalesReportBuilder WithLayout(string orientation, string pageSize);
        ISalesReportBuilder WithWatermark(string watermark);

        SalesReport Build();
    }
}