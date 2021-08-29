using System;
using System.Collections.Generic;
using System.Text;

namespace WMF.Models.ViewModels
{
    public class IndustryDropdownVM
    {
        public IEnumerable<string> Retail { get; set; }
        public IEnumerable<string> Manufacturing { get; set; }
        public IEnumerable<string> Ecommerce { get; set; }
        public IEnumerable<string> MobileApp { get; set; }
        public IEnumerable<string> ConsumerServices { get; set; }
        public IEnumerable<string> FoodBeverage { get; set; }
        public IEnumerable<string> GamesEntertainment { get; set; }
        public IEnumerable<string> Education { get; set; }
        public IEnumerable<string> B2B { get; set; }
        public IEnumerable<string> FinancialServices { get; set; }
        public IEnumerable<string> SAAS { get; set; }
        public IEnumerable<string> Other { get; set; }
    }
}