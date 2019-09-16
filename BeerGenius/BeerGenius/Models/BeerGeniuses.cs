using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeerGenius.Models
{
    public class BeerGeniusUser
    {
        [Key]
        public int UserId { get; set; }

        [RegularExpression("([a-zA-Z0-9 .&'-]+){4,20}", ErrorMessage = "User Name must be between 4 and 20 characters and cannot have special characters")]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("(?=.*[A-Z])(?=.*[@$!%*#?&]).{10,}", ErrorMessage = "Passwords must be at least 10 characters long, contain at least one upper case and one special character")]
        public string Password { get; set; }
    }

    public class FavoriteBeers
    {
        [Key]
        public int BeerId { get; set; }
        public int UserIdForeignKey { get; set; }

        [ForeignKey("BeerGeniusUserForeignKey")]
        public BeerGeniusUser BeerGeniusUser { get; set; }

    }

    public class UserFlavorProfile
    {
        [Key]
        public int UserFlavorProfileId { get; set; }
        public int UserId { get; set; }
        public BeerGeniusUser BeerGeniusUser { get; set; }
        public int Color { get; set; }
        public int Crisp { get; set; }
        public int Hop { get; set; }
        public int Malt { get; set; }
        public int Fruity { get; set; }
        public int Sour { get; set; }
        public int ABV { get; set; }
        public int Roasty { get; set; }
        public int Sweetness { get; set; }
        public int MatchingFlavorProfileId { get; set; }
        public DateTime Date { get; set; }
        public bool PerfectMatch { get; set; }

        public void AddValues(string propertyName, int value)
        {
            switch (propertyName)
            {
                case "Color":
                    this.Color = value;
                    break;
                case "Crisp":
                    this.Crisp = value;
                    break;
                case "Malt":
                    this.Malt = value;
                    break;
                case "Hop":
                    this.Hop = value;
                    break;
                case "Fruity":
                    this.Fruity = value;
                    break;
                case "Sour":
                    this.Sour = value;
                    break;
                case "ABV":
                    this.ABV = value;
                    break;
                case "Roasty":
                    this.Roasty = value;
                    break;
                case "Sweetness":
                    this.Sweetness = value;
                    break;
                default:
                    break;
            }
        }
    }

    public class ProfileData
    {
        public List<Dictionary<string, double>> CurrentUserDataOverTime { get; set; }
        public List<Dictionary<string, double>> AllUserDataOverTime { get; set; }
    }
}
