using Microsoft.EntityFrameworkCore;
using CommunityApp.Models;

namespace CommunityApp.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Province>().HasData(
                new Province { ProvinceCode = "BC", ProvinceName = "British Columbia" },
                new Province { ProvinceCode = "ON", ProvinceName = "Ontario" },
                new Province { ProvinceCode = "AB", ProvinceName = "Alberta" },
                new Province { ProvinceCode = "QC", ProvinceName = "Quebec" },
                new Province { ProvinceCode = "MB", ProvinceName = "Manitoba" },
                new Province { ProvinceCode = "SK", ProvinceName = "Saskatchewan" },
                new Province { ProvinceCode = "NS", ProvinceName = "Nova Scotia" },
                new Province { ProvinceCode = "NB", ProvinceName = "New Brunswick" },
                new Province { ProvinceCode = "NL", ProvinceName = "Newfoundland and Labrador" },
                new Province { ProvinceCode = "PE", ProvinceName = "Prince Edward Island" },
                new Province { ProvinceCode = "NT", ProvinceName = "Northwest Territories" },
                new Province { ProvinceCode = "YT", ProvinceName = "Yukon" },
                new Province { ProvinceCode = "NU", ProvinceName = "Nunavut" }
            );

            builder.Entity<City>().HasData(
                new City { CityId = 1, CityName = "Vancouver", Population = 675218, ProvinceCode = "BC" },
                new City { CityId = 2, CityName = "Victoria", Population = 85792, ProvinceCode = "BC" },
                new City { CityId = 3, CityName = "Kelowna", Population = 144576, ProvinceCode = "BC" },
                new City { CityId = 4, CityName = "Surrey", Population = 568322, ProvinceCode = "BC" },
                new City { CityId = 5, CityName = "Toronto", Population = 2930000, ProvinceCode = "ON" },
                new City { CityId = 6, CityName = "Ottawa", Population = 1010000, ProvinceCode = "ON" },
                new City { CityId = 7, CityName = "Mississauga", Population = 721599, ProvinceCode = "ON" },
                new City { CityId = 8, CityName = "Hamilton", Population = 569353, ProvinceCode = "ON" },
                new City { CityId = 9, CityName = "Edmonton", Population = 981280, ProvinceCode = "AB" },
                new City { CityId = 10, CityName = "Calgary", Population = 1239000, ProvinceCode = "AB" },
                new City { CityId = 11, CityName = "Red Deer", Population = 103588, ProvinceCode = "AB" },
                new City { CityId = 12, CityName = "Montreal", Population = 1780000, ProvinceCode = "QC" },
                new City { CityId = 13, CityName = "Quebec City", Population = 531902, ProvinceCode = "QC" },
                new City { CityId = 14, CityName = "Laval", Population = 422993, ProvinceCode = "QC" },
                new City { CityId = 15, CityName = "Winnipeg", Population = 749607, ProvinceCode = "MB" },
                new City { CityId = 16, CityName = "Brandon", Population = 48859, ProvinceCode = "MB" },
                new City { CityId = 17, CityName = "Saskatoon", Population = 273010, ProvinceCode = "SK" },
                new City { CityId = 18, CityName = "Regina", Population = 236481, ProvinceCode = "SK" },
                new City { CityId = 19, CityName = "Halifax", Population = 448544, ProvinceCode = "NS" },
                new City { CityId = 20, CityName = "Moncton", Population = 79470, ProvinceCode = "NB" },
                new City { CityId = 21, CityName = "Fredericton", Population = 63116, ProvinceCode = "NB" },
                new City { CityId = 22, CityName = "St. John's", Population = 110525, ProvinceCode = "NL" },
                new City { CityId = 23, CityName = "Charlottetown", Population = 36094, ProvinceCode = "PE" },
                new City { CityId = 24, CityName = "Yellowknife", Population = 20100, ProvinceCode = "NT" },
                new City { CityId = 25, CityName = "Whitehorse", Population = 25136, ProvinceCode = "YT" },
                new City { CityId = 26, CityName = "Iqaluit", Population = 7740, ProvinceCode = "NU" }
            );
        }
    }
}
