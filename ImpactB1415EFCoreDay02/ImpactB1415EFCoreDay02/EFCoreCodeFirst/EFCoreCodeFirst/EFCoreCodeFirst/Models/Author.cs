using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace EFCoreCodeFirst.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        [StringLength(20,ErrorMessage ="First Name cannot exceed 20 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is required")]
        [StringLength(20, ErrorMessage = "First Name cannot exceed 20 characters")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Display(Name ="Mobile No")]
        public long ContactNo { get; set; }
        public int NoOfBestsellers { get; set; }


    }
}
