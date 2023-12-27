using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AspProjesi.Models
{
    public enum Role
    {
        User,Admin
    }
    public class userinfo:DbContext
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Lutfen isim giriniz")]
        public string name { get; set; }
        [Required(ErrorMessage = "Lutfen soyisim giriniz")]
        public string surname { get; set; }
        [EmailAddress(ErrorMessage = "Lutfen gecerli email giriniz")]
        [Required(ErrorMessage = "Lutfen email giriniz")]
        public string email { get; set; }
        [Required(ErrorMessage = "Lutfen gecerli kullanici adi giriniz")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lutfen gecerli sifre giriniz")]
        public string password { get; set; }
        public Role Role { get; set; }
     

    }
}

