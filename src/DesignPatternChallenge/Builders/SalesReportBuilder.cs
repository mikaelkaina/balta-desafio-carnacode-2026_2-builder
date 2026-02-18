using System;
using System.Collections.Generic;
using DesignPatternChallenge;

namespace DesignPatternChallenge.Builders
{
    public class SalesReportBuilder : ISalesReportBuilder
    {
        private readonly string _title;
        private readonly string _format;

        private DateTime _startDate;
        private DateTime _endDate;

        private bool _includeHeader;
        private bool _includeFooter;
        private string? _headerText;
        private string? _footerText;

        private bool _includeCharts;
        private string? _chartType;
        private bool _includeSummary;

        private readonly List<string> _columns = new();
        private readonly List<string> _filters = new();

        private string? _sortBy;
        private string? _groupBy;
        private bool _includeTotals;

        private string? _orientation;
        private string? _pageSize;
        private bool _includePageNumbers;
        private string? _companyLogo;
        private string? _waterMark;

        // Campos obrigatórios exigidos aqui
        public SalesReportBuilder(string title, string format)
        {
            _title = title;
            _format = format;
        }

        public ISalesReportBuilder WithPeriod(DateTime start, DateTime end)
        {
            _startDate = start;
            _endDate = end;
            return this;
        }

        public ISalesReportBuilder WithHeader(string headerText)
        {
            _includeHeader = true;
            _headerText = headerText;
            return this;
        }

        public ISalesReportBuilder WithFooter(string footerText)
        {
            _includeFooter = true;
            _footerText = footerText;
            return this;
        }

        public ISalesReportBuilder AddColumn(string column)
        {
            _columns.Add(column);
            return this;
        }

        public ISalesReportBuilder AddFilter(string filter)
        {
            _filters.Add(filter);
            return this;
        }

        public ISalesReportBuilder WithCharts(string chartType)
        {
            _includeCharts = true;
            _chartType = chartType;
            return this;
        }

        public ISalesReportBuilder GroupBy(string groupBy)
        {
            _groupBy = groupBy;
            return this;
        }

        public ISalesReportBuilder SortBy(string sortBy)
        {
            _sortBy = sortBy;
            return this;
        }

        public ISalesReportBuilder IncludeTotals()
        {
            _includeTotals = true;
            return this;
        }

        public ISalesReportBuilder WithLayout(string orientation, string pageSize)
        {
            _orientation = orientation;
            _pageSize = pageSize;
            return this;
        }

        public ISalesReportBuilder WithWatermark(string watermark)
        {
            _waterMark = watermark;
            return this;
        }

        public SalesReport Build()
        {
            if (_startDate == default || _endDate == default)
                throw new InvalidOperationException("Período é obrigatório.");

            if (_columns.Count == 0)
                throw new InvalidOperationException("Ao menos uma coluna deve ser definida.");

            return new SalesReport(
                _title,
                _format,
                _startDate,
                _endDate,
                _includeHeader,
                _includeFooter,
                _headerText,
                _footerText,
                _includeCharts,
                _chartType,
                _includeSummary,
                _columns,
                _filters,
                _sortBy,
                _groupBy,
                _includeTotals,
                _orientation,
                _pageSize,
                _includePageNumbers,
                _companyLogo,
                _waterMark);
        }
    }
}