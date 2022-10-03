using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreConnectedDisconnectedApp.Models
{
    public partial class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long ContactNo { get; set; }
    }
}
