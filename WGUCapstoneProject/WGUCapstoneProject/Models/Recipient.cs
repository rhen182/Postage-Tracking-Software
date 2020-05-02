using System;
using System.Collections.Generic;
using System.Text;

namespace WGUCapstoneProject.Models
{
    public class Recipient : PersonBase
    {
        public int RecipientId { get; set; }
        public int OrganizationId { get; set; }
    }
}
