using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Categories")]
    [Index(nameof(Name), IsUnique = true)]
    public class Category : BaseEntity
    {
        public Category() : base() { }

        public Category(Guid id) : base(id)
        {

        }

        
        public string Name { get; set; }
    }
}
