using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliScrapper
{
    public class ProductDetailModel
    {
        public JToken PageConfig { get; set; }

        public ProductModel Product { get; set; }

        public JToken RunParams { get; set; }

        public StoreModel Store { get; set; }
    }

    public class StoreModel
    {
        public decimal? Feedback { get; set; }

        public int? Rating { get; set; }

        public long? StoreId { get; set; }

        public string StoreName { get; set; }

        public DateTime? Since { get; set; }
    }

    public class ProductModel
    {
        public bool? NoLongerAvailable { get; set; }

        public int? DiscountTimeLeftMinutes { get; set; }

        public string[] Options { get; set; }

        public int? OrderCount { get; set; }

        public NameValue[] PackagingSpecs { get; set; }

        public int? ProcessingTime { get; set; }

        public long? ProductId { get; set; }

        public ProductSkuModel[] ProductSku { get; set; }

        public NameValue[] ProductSpecs { get; set; }

        public decimal? Rating { get; set; }

        public SkuValueModel[] SkuValues { get; set; }

        public string Title { get; set; }

        public decimal? Weight { get; set; }
    }

    public class NameValue
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }

    public class ProductSkuModel
    {
        public string SkuAttr { get; set; }

        public string SkuPropIds { get; set; }

        public SkuValModel SkuVal { get; set; }
    }

    public class SkuValueModel
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public long? SkuId { get; set; }

        public string Title { get; set; }
    }

    public class SkuValModel
    {
        public decimal? ActSkuBulkCalPrice { get; set; }

        public decimal? ActSkuBulkPrice { get; set; }

        public decimal? ActSkuCalPrice { get; set; }

        public string ActSkuDisplayBulkPrice { get; set; }

        public decimal? ActSkuMultiCurrencyBulkPrice { get; set; }

        public decimal? ActSkuMultiCurrencyCalPrice { get; set; }

        public decimal? ActSkuMultiCurrencyDisplayPrice { get; set; }

        public string ActSkuMultiCurrencyPrice { get; set; }

        public decimal? ActSkuPrice { get; set; }

        public int? AvailQuantity { get; set; }

        public int? BulkOrder { get; set; }

        public int? Inventory { get; set; }

        public bool? IsActivity { get; set; }

        public decimal? SkuBulkCalPrice { get; set; }

        public decimal? SkuBulkPrice { get; set; }

        public decimal? SkuCalPrice { get; set; }

        public string SkuDisplayBulkPrice { get; set; }

        public decimal? SkuMultiCurrencyBulkPrice { get; set; }

        public decimal? SkuMultiCurrencyCalPrice { get; set; }

        public decimal? SkuMultiCurrencyDisplayPrice { get; set; }

        public string SkuMultiCurrencyPrice { get; set; }

        public decimal? SkuPrice { get; set; }
    }
}
