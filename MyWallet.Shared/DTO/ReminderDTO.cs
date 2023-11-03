using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Shared.DTO
{
    public class ReminderDTO
    {
        public Guid? Id { get; set; }

        public bool Resolved { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string? Comments { get; set; }
    }
}
