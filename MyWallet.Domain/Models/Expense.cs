using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Models
{
    public class Expense : BaseEntity
    {
        public Expense(Guid Id) : base(Id) 
        {
            
        }

        public Expense()
        {
            
        }

        public decimal Value { get; set; }

        public Category Category { get; set; }  

        public IEnumerable<string> Tags { get; set; }

    }
}
