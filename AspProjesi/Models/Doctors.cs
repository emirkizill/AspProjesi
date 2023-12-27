using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AspProjesi.Models
{
    public class Doctors
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Branch { get; set; }


    }
}
