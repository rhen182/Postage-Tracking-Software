using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WGUCapstoneProject.Models
{
    public class PostageDBEntry : INotifyPropertyChanged
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

        private string sender;
        private string caseName;
        private string recipient;
        private string organization;
        private double cost;
        private string postageType;
        private DateTime dateSent;

        public string Sender
        {
            get { return sender; }
            set { sender = value; RaisePropertyChanged(); }
        }
        public string CaseName
        {
            get { return caseName; }
            set { caseName = value; RaisePropertyChanged(); }
        }
        public string Recipient
        {
            get { return recipient; }
            set { recipient = value; RaisePropertyChanged(); }
        }
        public string Organization
        {
            get { return organization; }
            set { organization = value; RaisePropertyChanged(); }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; RaisePropertyChanged(); }
        }
        public string PostageType
        {
            get { return postageType; }
            set { postageType = value; RaisePropertyChanged(); }
        }
        public DateTime DateSent
        {
            get { return dateSent; }
            set { dateSent = value; RaisePropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
