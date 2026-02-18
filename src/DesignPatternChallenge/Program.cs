using System;
using DesignPatternChallenge.Builders;
using DesignPatternChallenge.Directors;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Sistema de Relatórios ===");

            var report = new SalesReportBuilder("Relatório Trimestral", "Excel")
                .WithPeriod(new DateTime(2025, 1, 1), new DateTime(2025, 3, 31))
                .AddColumn("Vendedor")
                .AddColumn("Região")
                .AddColumn("Total")
                .WithCharts("Line")
                .GroupBy("Região")
                .IncludeTotals()
                .Build();

            report.Generate();

            var director = new SalesReportDirector();
            var monthlyReport = director.CreateMonthlyPdfReport();
            monthlyReport.Generate();
        }
    }
}
