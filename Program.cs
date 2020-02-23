using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EtsyToWixCsvConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: etsytowixcsvconverter <inputfile> <outputfile>");
                return;
            }

            var inputFilePath = args[0];
            var outputFilePath = args[1];

            List<EtsyProduct> etsyProducts = null;

            using (var reader = new StreamReader(inputFilePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    etsyProducts = csv.GetRecords<EtsyProduct>().ToList();
                }
            }

            var wixProducts = new List<WixProduct>();

            foreach (var etsyProduct in etsyProducts)
            {
                var wixProduct = new WixProduct
                {
                    Name = etsyProduct.Title,
                    FieldType = "Product",
                    Description = etsyProduct.Description,
                    Inventory = etsyProduct.Quantity.ToString(),
                    Price = etsyProduct.Price,
                    ProductImageUrls = string.Join(";", etsyProduct.GetAllImages()),
                    HandleId = "product_" + Guid.NewGuid(),
                    Collection = "Import"
                };

                if (!string.IsNullOrEmpty(etsyProduct.Tags))
                {
                    wixProduct.AdditionalInfoTitle1 = "Tags";
                    wixProduct.AdditionalInfoDescription1 = etsyProduct.Tags.Replace("_", " ").Replace(",", ", ");
                }

                if (!string.IsNullOrEmpty(etsyProduct.Materials))
                {
                    wixProduct.AdditionalInfoTitle2 = "Materials";
                    wixProduct.AdditionalInfoDescription2 = etsyProduct.Materials.Replace("_", " ").Replace(",", ", ");
                }

                wixProducts.Add(wixProduct);
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(wixProducts);
                }
            }

            Console.WriteLine("Successfully converted {0} products", wixProducts.Count);
        }
    }
}
