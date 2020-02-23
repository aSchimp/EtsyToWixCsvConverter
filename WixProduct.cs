using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtsyToWixCsvConverter
{
    public class WixProduct
    {
        [Name("handleId")]
        public string HandleId { get; set; }

        [Name("fieldType")]
        public string FieldType { get; set; }

        [Name("name")]
        public string Name { get; set; }

        [Name("description")]
        public string Description { get; set; }

        [Name("productImageUrl")]
        public string ProductImageUrls { get; set; }

        [Name("collection")]
        public string Collection { get; set; }

        [Name("price")]
        public decimal Price { get; set; }

        [Name("inventory")]
        public string Inventory { get; set; }
    }
}
