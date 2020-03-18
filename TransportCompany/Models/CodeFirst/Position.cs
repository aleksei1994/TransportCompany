using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.Models.CodeFirst
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        
        [MaxLength(100)]
        public string JobTitle { get; set; }


        public int Salary { get; set; }


        public string Responsibilities { get; set; }


        public string Requirements { get; set; }

        public ICollection<Staff> Staffs { get; set; }
    }
}
