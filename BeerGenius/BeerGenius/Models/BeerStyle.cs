using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int BreweryDbId { get; set; }
        public int Color { get; set; }
        public int Crisp { get; set; }
        public int Hop { get; set; }
        public int Malt { get; set; }
        public int Fruity { get; set; }
        public int Sour { get; set; }
        public int ABV { get; set; }
        public int Roasty { get; set; }
        public int Sweetness { get; set; }
        public int TimesSelected { get; set; }
    }


    public class IndividualStyle
    {
        public string message { get; set; }
        public IndividualData data { get; set; }
        public string status { get; set; }
        public UserFlavorProfile UserFlavorProfile { get; set; }
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







    public class BeerRootobject
    {
        public int currentPage { get; set; }
        public int numberOfPages { get; set; }
        public int totalResults { get; set; }
        public Datum[] data { get; set; }
        public string status { get; set; }
        public UserFlavorProfile UserFlavorProfile { get; set; }
        public FlavorProfile FlavorProfile { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string nameDisplay { get; set; }
        public string abv { get; set; }
        public int availableId { get; set; }
        public int styleId { get; set; }
        public string isOrganic { get; set; }
        public string isRetired { get; set; }
        public Labels labels { get; set; }
        public string status { get; set; }
        public string statusDisplay { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public Available available { get; set; }
        public Style style { get; set; }
        public string description { get; set; }
        public int srmId { get; set; }
        public Srm srm { get; set; }
        public string ibu { get; set; }
        public int glasswareId { get; set; }
        public string foodPairings { get; set; }
        public string servingTemperature { get; set; }
        public string servingTemperatureDisplay { get; set; }
        public string originalGravity { get; set; }
        public Glass glass { get; set; }
        public int year { get; set; }
    }

    public class Labels
    {
        public string icon { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string contentAwareIcon { get; set; }
        public string contentAwareMedium { get; set; }
        public string contentAwareLarge { get; set; }
    }

    public class Available
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Style
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public BeerCategory category { get; set; }
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

    public class BeerCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string createDate { get; set; }
    }

    public class Srm
    {
        public int id { get; set; }
        public string name { get; set; }
        public string hex { get; set; }
    }

    public class Glass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string createDate { get; set; }
    }


}
