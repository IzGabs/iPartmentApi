using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Monetary
{
    public interface IMonetaryEntity
    {
        [Required]
        public double montlyValue { get; set; }

        double valorTotal();
    }
}
