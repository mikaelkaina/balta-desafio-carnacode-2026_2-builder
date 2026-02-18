using System;
using DesignPatternChallenge.Builders;
using DesignPatternChallenge;

namespace DesignPatternChallenge.Directors
{
    public class SalesReportDirector
    {
        public SalesReport CreateMonthlyPdfReport()
        {
            return new SalesReportBuilder("Vendas Mensais", "PDF")
                .WithPeriod(new DateTime(2025, 1, 1), new DateTime(2025, 1, 31))
                .WithHeader("Relatório de Vendas")
                .WithFooter("Confidencial")
                .AddColumn("Produto")
                .AddColumn("Quantidade")
                .AddColumn("Valor")
                .WithCharts("Bar")
                .IncludeTotals()
                .WithLayout("Portrait", "A4")
                .Build();
        }
    }
}
