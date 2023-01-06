﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private double price;
        private int nightsCount;
        private double discount;
        private double total;

        public double Price
        {
            get => price;
            set
            {
                if (value >= 0) price = value;
                else throw new ArgumentException();
                CountTotal();
                Notify(nameof(Price));
            }
        }     
        
        public int NightsCount
        {
            get => nightsCount;
            set
            {
                if (value > 0) nightsCount = value;
                else throw new ArgumentException();
                CountTotal();
                Notify(nameof(NightsCount));
            }
        }
        
        public double Discount
        {
            get => discount;
            set
            {
                discount = value;
                if (Math.Abs(discount - ((-1) * Total / (Price * NightsCount) + 1) * 100) > 1e-5)
                    CountTotal();
                Notify(nameof(Discount));
            }
        }
        
        public double Total
        {
            get => total;
            set
            {   
                if (value > 0) total = value;
                else throw new ArgumentException();
                if (Math.Abs(total - Price * NightsCount * (1 - Discount / 100)) > 1e-5)
                    CountDiscount();
                Notify(nameof(Total));
            }
        }
        
        public AccountingModel()
        {
            price = 0;
            nightsCount = 1;
            discount = 0;
            total = 0;
        }
        
        private void CountTotal()
        {
            Total = Price * NightsCount * (1 - Discount / 100);
        }

        private void CountDiscount()
        {
            Discount = ((-1) * Total / (Price * NightsCount) + 1) * 100;
        }
    }
}
