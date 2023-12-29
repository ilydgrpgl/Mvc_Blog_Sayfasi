using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; } 

        [StringLength(50)]
        public String Name { get; set; }


        [StringLength(50)]
        public String SurName { get; set; }

        [StringLength(50)]
        public String Mail { get; set; }

        [StringLength(50)]
        public String Subject { get; set; }

        public String Message { get; set; }

        public DateTime MessageDate { get; set; }

    }
}
