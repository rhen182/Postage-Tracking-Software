using System;

namespace WGUCapstoneProject.Models
{
    public class Mail
    {
        public int MailId { get; set; }
        public DateTime DateSent { get; set; }
        public int CaseId { get; set; }
        public int Cost { get; set; }
        public int PostageTypeId { get; set; }
        public int AddressId { get; set; }
        public int RecipientId { get; set; }
    }
}
