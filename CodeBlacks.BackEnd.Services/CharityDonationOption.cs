using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.BackEnd.Services
{
    public class CharityDonationOption
    {
        public decimal costPerTreatment;
        public decimal ValuePerTreatment;
        public string locationName;
        public string treatmentName;
        public double latitude;
        public double longitude;
        public string charityName;
        public string iconUrl;
        public string charityWebsite;
        public string country;
        public string description;
        public int peopleEffected;
        public double nextEffectiveness;

        public static List<CharityDonationOption> getDefault()
        {
            string GiveDirectly = "GiveDirectly";
            string India = "India";
            string GiveDirectlyDesc = "Alleviating extreme poverty through cash transfers";
            string GiveDirectlyIconUrl = "https://www.givingwhatwecan.org/sites/givingwhatwecan.org/files/fromcea/givedirectly.gif";
            string GiveDirectlyWebsite = "https://www.givedirectly.org/";

            string Jordan = "Jordan";
            string WorldVision = "World Vision";
            string WorldVisionIconUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSfY7nUlfzvS1ShslHYehpNIVow_ZundZ2QH_pGvfwupeV9pKD2Cw";
            string WorldVisionWebsite = "http://www.worldvision.org/";
            string WorldVisionDesc = "Building a better world for children by ending poverty and injustice";

            string DewormTheWorld = "Deworm the world";
            string DewormTheWorldIconUrl = "http://www.air.org/sites/default/files/old/Deworm_logo_white.GIF";
            string DewormTheWorldWebsite = "http://www.evidenceaction.org/#deworm-the-world";
            string DewormTheWorldDesc = "The Deworm the World Initiative works with governments around the world to develop and implement national school-based deworming programs";

            return new List<CharityDonationOption>()
            {
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Azraq",
                    latitude = 31.706522,
                    longitude = 35.800880,
                    ValuePerTreatment = 14,
                    costPerTreatment  = 20m,
                    treatmentName = "Stationary pack",
                    description = WorldVisionDesc,
                    peopleEffected = 1,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Azraq",
                    latitude = 31.706522,
                    longitude = 35.800880,
                    ValuePerTreatment = 46,
                    costPerTreatment  = 45m,
                    treatmentName = "Nutricious food",
                    description = WorldVisionDesc,
                    peopleEffected = 5,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Azraq",
                    latitude = 31.706522,
                    longitude = 35.800880,
                    ValuePerTreatment = 70,
                    costPerTreatment  = 75m,
                    treatmentName = "Counselor",
                    description = WorldVisionDesc,
                    peopleEffected = 9,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Azraq",
                    latitude = 31.706522,
                    longitude = 35.800880,
                    ValuePerTreatment = 101,
                    costPerTreatment  = 100m,
                    treatmentName = "Teacher",
                    description = WorldVisionDesc,
                    peopleEffected = 60,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Azraq",
                    latitude = 31.706522,
                    longitude = 35.800880,
                    ValuePerTreatment = 2400,
                    costPerTreatment  = 2500m,
                    treatmentName = "Classroom for 1 term",
                    description = WorldVisionDesc,
                    peopleEffected = 251,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Za'atari",
                    latitude = 32.018792,
                    longitude = 35.878693,
                    ValuePerTreatment = 15,
                    costPerTreatment  = 20m,
                    treatmentName = "Stationary pack",
                    description = WorldVisionDesc,
                    peopleEffected = 1,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Za'atari",
                    latitude = 32.018792,
                    longitude = 35.878693,
                    ValuePerTreatment = 45,
                    costPerTreatment  = 45m,
                    treatmentName = "Nutricious food",
                    description = WorldVisionDesc,
                    peopleEffected = 5,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Za'atari",
                    latitude = 32.018792,
                    longitude = 35.878693,
                    ValuePerTreatment = 74,
                    costPerTreatment  = 75m,
                    treatmentName = "Counselor",
                    description = WorldVisionDesc,
                    peopleEffected = 9,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Za'atari",
                    latitude = 32.018792,
                    longitude = 35.878693,
                    ValuePerTreatment = 102,
                    costPerTreatment  = 100m,
                    treatmentName = "Teacher",
                    description = WorldVisionDesc,
                    peopleEffected = 60,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = Jordan,
                    locationName = "Za'atari",
                    latitude = 32.018792,
                    longitude = 35.878693,
                    ValuePerTreatment = 2503,
                    costPerTreatment  = 2350m,
                    treatmentName = "Classroom for 1 term",
                    description = WorldVisionDesc,
                    peopleEffected = 251,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = DewormTheWorld,
                    iconUrl = DewormTheWorldIconUrl,
                    charityWebsite = DewormTheWorldWebsite,
                    country = India,
                    locationName = "Pradesh",
                    latitude = 22.973423,
                    longitude = 78.656894,
                    ValuePerTreatment = 1,
                    costPerTreatment  = 0.81m,
                    treatmentName = "Deworming tablet",
                    description = DewormTheWorldDesc,
                    peopleEffected = 1,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = India,
                    locationName = "Delhi",
                    latitude = 28.613939,
                    longitude = 77.209021,
                    ValuePerTreatment = 1,
                    costPerTreatment  = 20m,
                    treatmentName = "Stationary pack",
                    description = WorldVisionDesc,
                    peopleEffected = 1,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = India,
                    locationName = "Delhi",
                    latitude = 28.613939,
                    longitude = 77.209021,
                    ValuePerTreatment = 60,
                    costPerTreatment  = 100m,
                    treatmentName = "Teacher",
                    description = WorldVisionDesc,
                    peopleEffected = 60,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = WorldVision,
                    iconUrl = WorldVisionIconUrl,
                    charityWebsite = WorldVisionWebsite,
                    country = India,
                    locationName = "Delhi",
                    latitude = 28.613939,
                    longitude = 77.209021,
                    ValuePerTreatment = 1900,
                    costPerTreatment  = 2500m,
                    treatmentName = "Classroom for 1 term",
                    description = WorldVisionDesc,
                    peopleEffected = 180,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = DewormTheWorld,
                    iconUrl = DewormTheWorldIconUrl,
                    charityWebsite = DewormTheWorldWebsite,
                    country = India,
                    locationName = "Uttar Pradesh",
                    latitude = 26.846709,
                    longitude = 80.946159,
                    ValuePerTreatment = 1,
                    costPerTreatment  = 0.81m,
                    treatmentName = "Deworming tablet",
                    description = DewormTheWorldDesc,
                    peopleEffected = 1,
                    nextEffectiveness = 0.99,
                },
                new CharityDonationOption {
                    charityName = DewormTheWorld,
                    iconUrl = DewormTheWorldIconUrl,
                    charityWebsite = DewormTheWorldWebsite,
                    country = India,
                    locationName = "Rajasthan",
                    latitude = 27.023804,
                    longitude = 74.217933,
                    ValuePerTreatment = 1,
                    costPerTreatment  = 0.81m,
                    treatmentName = "Deworming tablet",
                    description = DewormTheWorldDesc,
                    peopleEffected = 1,
                    nextEffectiveness = 0.99,
                },
            };
        }
    }
}
