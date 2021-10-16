using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPIEntity.Models
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }

    }
}
