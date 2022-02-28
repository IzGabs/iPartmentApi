using API.Domain.RealState.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Controllers.ViewModels
{
    public class RealStateCreate
    {
        public RealStateCreate() { }
        public RealStateCreate(RealStateObject realState, int? condoID)
        {
            this.realState = realState;
            this.CondoID = condoID;
        }

        [Required]
        public RealStateObject realState;
        public int? CondoID;

    }

    public class RealStateCreateWithCondo : RealStateCreate
    {
        public RealStateCreateWithCondo() { }
        public RealStateCreateWithCondo(RealStateObject realState, int? condoID) : base (realState, condoID){ 
            this.realState = realState;
            this.CondoID = condoID;
        }

      
        [Required]
        public new int? CondoID; 
    }


  
}
