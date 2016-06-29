using CodeBlacks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.BackEnd.Services
{
    public static class Impact
    {
        public class KnapsackItem
        {
            public CharityDonationOption parent;
            public double size;
            public double value;
        }
        //knapsack solver
        public static List<KnapsackItem> SplitBestEffect(double spend, List<KnapsackItem> options) 
        {
            //Not sure why this order works
            var temp = options.OrderBy(x => x.value / x.size).Reverse().ToList();
            List<KnapsackItem> result = new List<KnapsackItem>();

            //Fill up the knapsack
            foreach (KnapsackItem item in temp)
            {
                if(spend - item.size >= 0)
                {
                    result.Add(item);
                    spend -= item.size;
                }
                else
                {
                    double space = spend;
                    int index = result.Count-1;
                    if (index > 0)
                    {
                        while (index > 0 && space < item.size)
                        {
                            space += result[index].size;
                            index--;
                        }
                        if (space >= item.size)
                        {
                            var totalValue = result.GetRange(index, result.Count - index).Sum(x => x.value);
                            if (item.value > totalValue)
                            {
                                result.RemoveRange(index, result.Count - index);
                                result.Add(item);
                                spend += totalValue;
                                spend -= item.value;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static List<DonationImpact> GetDonationImpact( string country, string charity, double amount)
        {
            List<DonationImpact> result = new List<DonationImpact>();
            if(amount > 1000000)
            {
                amount = 1000000;
            }
            var options =  CharityDonationOption.getDefault().Where(x => x.country == country && x.charityName == charity).ToList();

            var split = new List<KnapsackItem>();

            foreach(var typeD in options)
            {
                double currentSpend = 0;
                double valueMult = 1;
                while ( currentSpend < amount)
                {
                    
                    split.Add(new KnapsackItem
                    {
                        parent = typeD,
                        value = (double)typeD.ValuePerTreatment * valueMult,
                        size = (double)typeD.costPerTreatment,
                    });
                    currentSpend += (double)typeD.costPerTreatment;
                    valueMult *= typeD.nextEffectiveness;
                }
            }

            var spread = SplitBestEffect(amount,split).GroupBy( x => x.parent).Select( g => new
            {
                parent = g.Key,
                value = g.Sum(x => x.value),
                size = g.Sum(x => x.size),
                amt = g.Count(),
            }).ToList();

            List<DonationImpactItem> resultTemp = new List<DonationImpactItem>();
           spread.ForEach(item =>
               resultTemp.Add(new DonationImpactItem
               {
                   locationName = item.parent.locationName,
                   latitude = item.parent.latitude,
                   longitude = item.parent.longitude,
                   peopleEffected = item.amt * item.parent.peopleEffected,
                   amountOfItems = item.amt,
                   donation = (decimal)item.size,
                   type = item.parent.treatmentName,

               })
           );

            resultTemp.GroupBy(z => new
            {
                z.locationName,
                z.longitude,
                z.latitude
            }).ToList().ForEach(r => result.Add(new DonationImpact
            {
                locationName = r.Key.locationName,
                longitude = r.Key.longitude,
                latitude = r.Key.latitude,
                peopleEffected = r.Sum(x => x.peopleEffected),
                subItems = new List<DonationImpactItem>()
            }));

            resultTemp.ForEach(x => result.First(t => t.locationName == x.locationName).subItems.Add(x));

            return result;
        }
        
        public static List<Charity> GetCharitiesInCountry(string country)
        {
            List<Charity> result = new List<Charity>();
            CharityDonationOption.getDefault().Where(x => x.country == country).GroupBy(z => new {z.charityName, z.charityWebsite, z.iconUrl, z.description }).ToList().ForEach(y => result.Add(new Charity()
            {
                charityName = y.Key.charityName,
                charityWebsite = y.Key.charityWebsite,
                iconUrl = y.Key.iconUrl,
                description = y.Key.description,


            }));
            return result;
        }
    }

    public class Option
    {
        public decimal costPerTreatment;
        public int maxTreatments;
        public decimal ValuePerTreatment;

    }

}
