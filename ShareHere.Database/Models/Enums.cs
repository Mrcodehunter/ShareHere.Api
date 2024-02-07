using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHere.Database.Models
{
    public static class Enums
    {
        public enum BlogTypes
        {
            [Display(Name ="Technology")]
            Tech,
            [Display(Name = "Political")]
            Political,
            [Display(Name = "Food")]
            Food
        }
    }
}
