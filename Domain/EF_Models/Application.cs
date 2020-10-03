using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    public class Application
    {
        public Application()
        {
            Managers = new List<Sign>();
        }
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Sign> Managers { get; set; }
        public bool AccountingSign { get; set; }
        public bool FullDay { get; set; }
        public string Comment { get; set; }
        public string ProjectRole { get; set; }
        public string State { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
