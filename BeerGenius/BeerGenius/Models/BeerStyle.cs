using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeerGenius.Models
{

    public class StyleRequest
    {
        public string message { get; set; }
        public BeerStyle[] data { get; set; }
        public string status { get; set; }
    }

    public class BeerStyle
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string description { get; set; }
        public string ibuMin { get; set; }
        public string ibuMax { get; set; }
        public string abvMin { get; set; }
        public string abvMax { get; set; }
        public string srmMin { get; set; }
        public string srmMax { get; set; }
        public string ogMin { get; set; }
        public string fgMin { get; set; }
        public string fgMax { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string ogMax { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string createDate { get; set; }
        public string description { get; set; }
        public string updateDate { get; set; }
    }

    public class FlavorProfile
    {
        [Key]
        public int Id { get; set; }
        public int Color { get; set; }
        public int Crisp { get; set; }
        public int Hop { get; set; }
        public int Malt { get; set; }
        public int Fruity { get; set; }
        public int Sour { get; set; }
        public int ABV { get; set; }
        public int Roasty { get; set; }
        public int Sweetness { get; set; }
    }






    public class IndividualStyle
    {
        public string message { get; set; }
        public IndividualData data { get; set; }
        public string status { get; set; }
    }

    public class IndividualData
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public IndividualCategory category { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string description { get; set; }
        public string ibuMin { get; set; }
        public string ibuMax { get; set; }
        public string abvMin { get; set; }
        public string abvMax { get; set; }
        public string srmMin { get; set; }
        public string srmMax { get; set; }
        public string ogMin { get; set; }
        public string fgMin { get; set; }
        public string fgMax { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
    }

    public class IndividualCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string createDate { get; set; }
    }

}
