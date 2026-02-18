using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    public class SalesReport
    {
        public string Title { get; }
        public string Format { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public bool IncludeHeader { get; }
        public bool IncludeFooter { get; }
        public string? HeaderText { get; }
        public string? FooterText { get; }

        public bool IncludeCharts { get; }
        public string? ChartType { get; }
        public bool IncludeSummary { get; }

        public IReadOnlyList<string> Columns { get; }
        public IReadOnlyList<string> Filters { get; }

        public string? SortBy { get; }
        public string? GroupBy { get; }
        public bool IncludeTotals { get; }

        public string? Orientation { get; }
        public string? PageSize { get; }

        public bool IncludePageNumbers { get; }
        public string? CompanyLogo { get; }
        public string? WaterMark { get; }

        // Construtor internal → só o Builder cria
        internal SalesReport(
            string title,
            string format,
            DateTime startDate,
            DateTime endDate,
            bool includeHeader,
            bool includeFooter,
            string? headerText,
            string? footerText,
            bool includeCharts,
            string? chartType,
            bool includeSummary,
            List<string> columns,
            List<string> filters,
            string? sortBy,
            string? groupBy,
            bool includeTotals,
            string? orientation,
            string? pageSize,
            bool includePageNumbers,
            string? companyLogo,
            string? waterMark)
        {
            Title = title;
            Format = format;
            StartDate = startDate;
            EndDate = endDate;
            IncludeHeader = includeHeader;
            IncludeFooter = includeFooter;
            HeaderText = headerText;
            FooterText = footerText;
            IncludeCharts = includeCharts;
            ChartType = chartType;
            IncludeSummary = includeSummary;
            Columns = columns.AsReadOnly();
            Filters = filters.AsReadOnly();
            SortBy = sortBy;
            GroupBy = groupBy;
            IncludeTotals = includeTotals;
            Orientation = orientation;
            PageSize = pageSize;
            IncludePageNumbers = includePageNumbers;
            CompanyLogo = companyLogo;
            WaterMark = waterMark;
        }

        public void Generate()
        {
            Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
            Console.WriteLine($"Formato: {Format}");
            Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");

            if (IncludeHeader)
                Console.WriteLine($"Cabeçalho: {HeaderText}");

            if (IncludeCharts)
                Console.WriteLine($"Gráfico: {ChartType}");

            Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");

            if (Filters.Count > 0)
                Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");

            if (!string.IsNullOrEmpty(GroupBy))
                Console.WriteLine($"Agrupado por: {GroupBy}");

            if (IncludeFooter)
                Console.WriteLine($"Rodapé: {FooterText}");

            Console.WriteLine("Relatório gerado com sucesso!");
        }
    }
}