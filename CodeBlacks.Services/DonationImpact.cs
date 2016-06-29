using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.Services
{
    public class DonationImpactItem
    {
        public string locationName;
        public double latitude;
        public double longitude;
        public decimal donation;
        public int peopleEffected;
        public int amountOfItems;
        public string type;
        
    }

    public class DonationImpact
    {
        public string locationName;
        public double latitude;
        public double longitude;
        public int peopleEffected;
        public List<DonationImpactItem> subItems;
    }

    public class Charity
    {
        public string charityName;
        public string iconUrl;
        public string charityWebsite;
        public string description;
    }

}
