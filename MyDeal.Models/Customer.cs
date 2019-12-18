using MyDeal.Models.BidsInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models
{
    public class Customer:Entity<int>
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string PassWord { get; set; }
        [MaxLength(100)]
        public string EmailSubject { get; set; }
        [MaxLength(250)]
        public string EmailBody { get; set; }
        [DataType(DataType.Password)]
        [Compare("PassWord")]        
        public string ConfirmPassWord { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<Bids> Bids { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
