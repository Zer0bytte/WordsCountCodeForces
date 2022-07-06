using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp4.Models
{
    public partial class Tblicense
    {
        public int LicenseId { get; set; }
        public string LicenseKey { get; set; }
        public int Duration { get; set; }
        public string ComputerName { get; set; }
        public bool IsUsed { get; set; }
        public string Hwid { get; set; }
        public DateTime? UsedDate { get; set; }
    }
}
