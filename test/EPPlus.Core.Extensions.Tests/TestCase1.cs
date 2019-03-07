﻿using System.Linq;
using System.Reflection;

using FluentAssertions;

using OfficeOpenXml;

using Xunit;

namespace EPPlus.Core.Extensions.Tests
{
    public class TestCase1
    {
        [Fact]
        public void TestCase()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var excelPackage1 = new ExcelPackage(typeof(TestBase).GetTypeInfo().Assembly.GetManifestResourceStream("EPPlus.Core.Extensions.Tests.Resources.testcase1.xlsx"));
            const int campaignId = 1;
            const int productListId = 1;
            const StockChannel stockChannel = StockChannel.Ft;

            var sheet = excelPackage1.Workbook.Worksheets.First();

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------

            var inputs = sheet.ToList<PriceInput>(configuration => configuration.Intercept((current, index) =>
                                                                                           {
                                                                                               if (index == 1)
                                                                                               {
                                                                                                   return;
                                                                                               }

                                                                                               current.CampaignId = campaignId;
                                                                                               current.StockChannel = stockChannel;
                                                                                               current.ProductListId = productListId;
                                                                                               current.Index = index;
                                                                                           }).SkipCastingErrors());

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            inputs.Count.Should().BeGreaterThan(0);
            inputs.Select(x => x.CampaignId).Should().AllBeEquivalentTo(1);
            inputs.Select(x => x.StockChannel).Should().AllBeEquivalentTo(StockChannel.Ft);
            inputs.Select(x => x.ProductListId).Should().AllBeEquivalentTo(1);
            inputs.First().IsPublished.Should().BeTrue();
            inputs.Last().IsPublished.Should().BeFalse();
            inputs.Count(x => !x.IsPublished).Should().Be(1187);
            inputs.Count(x => x.IsPublished).Should().Be(562);

            inputs.Last().Index.Should().Be(1750);
        }
    }

    public class PriceInput
    {
        public int CampaignId { get; set; }

        public int Index { get; set; }

        public StockChannel StockChannel { get; set; }

        public int ProductListId { get; set; }

        public decimal PurchaseCost { get; set; }

        [ExcelTableColumn(ColumnNames.Barcode)]
        public string Barcode { get; set; }

        [ExcelTableColumn(ColumnNames.BuyingPrice)]
        public decimal BuyingPrice { get; set; } = 0;

        [ExcelTableColumn(ColumnNames.ListPrice)]
        public decimal ListPrice { get; set; } = 0;

        [ExcelTableColumn(ColumnNames.Price)]
        public decimal Price { get; set; } = 0;

        [ExcelTableColumn(ColumnNames.IsPublished)]
        public bool IsPublished { get; set; }
    }

    public static class ColumnNames
    {
        public const string Barcode = "Barkod";
        public const string BuyingPrice = "Alış Fiyatı";
        public const string ListPrice = "Psf";
        public const string Price = "Tsf";

        public const string Brand = "Marka";
        public const string ProductCode = "Ürün Kodu";
        public const string Color = "Renk";
        public const string Supplier = "Tedarikçi";
        public const string Message = "Mesaj";

        public const string StBuyingPrice = "St Alış Fiyatı";

        public const string IsPublished = "Yayında mı?";
    }

    public enum StockChannel
    {
        Ft = 1,
        St = 3,
        Mix = 4,
        Mp = 5
    }
}
