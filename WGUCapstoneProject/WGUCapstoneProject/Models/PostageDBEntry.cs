using System;
using System.Collections.Generic;
using System.Text;

namespace WGUCapstoneProject.Models
{
    public class PostageDBEntry
    {
        public PostageDBEntry()
        {

        }
        public PostageDBEntry(string sender, string caseName, string recipient, string organization, double cost, string postageType, DateTime dateSent)
        {
            Sender = sender;
            CaseName = caseName;
            Recipient = recipient;
            Organization = organization;
            Cost = cost;
            PostageType = postageType;
            DateSent = dateSent;
        }
        public string Sender { get; set; }
        public string CaseName { get; set; }
        public string Recipient { get; set; }
        public string Organization { get; set; }
        public double Cost { get; set; }
        public string PostageType { get; set; }
        public DateTime DateSent { get; set; }
    }
}
