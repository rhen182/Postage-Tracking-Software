using System;
using System.Collections.Generic;
using System.Text;

namespace WGUCapstoneProject.Models
{
    public class Mail
    {
        public int MailId { get; set; }
        public DateTime DateSent { get; set; }
        public int CaseId { get; set; }
        public int Cost { get; set; }
        public Enum PostageType { get; set; }
    }
}
