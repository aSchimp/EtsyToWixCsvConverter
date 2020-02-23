using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtsyToWixCsvConverter
{
    public class EtsyProduct
    {
        [Name("TITLE")]
        public string Title { get; set; }

        [Name("DESCRIPTION")]
        public string Description { get; set; }

        [Name("PRICE")]
        public decimal Price { get; set; }

        [Name("QUANTITY")]
        public int Quantity { get; set; }

        [Name("TAGS")]
        public string Tags { get; set; }

        [Name("MATERIALS")]
        public string Materials { get; set; }

        [Name("IMAGE1")]
        public string Image1 { get; set; }

        [Name("IMAGE2")]
        public string Image2 { get; set; }

        [Name("IMAGE3")]
        public string Image3 { get; set; }

        [Name("IMAGE4")]
        public string Image4 { get; set; }

        [Name("IMAGE5")]
        public string Image5 { get; set; }

        [Name("IMAGE6")]
        public string Image6 { get; set; }

        [Name("IMAGE7")]
        public string Image7 { get; set; }

        [Name("IMAGE8")]
        public string Image8 { get; set; }

        [Name("IMAGE9")]
        public string Image9 { get; set; }

        [Name("IMAGE10")]
        public string Image10 { get; set; }

        public List<string> GetAllImages()
        {
            return new List<string>
            {
                Image1,
                Image2,
                Image3,
                Image4,
                Image5,
                Image6,
                Image7,
                Image8,
                Image9,
                Image10
            };
        }
    }
}
