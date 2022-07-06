using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp4.Models
{
    public partial class TbAttendence
    {
        public int AttId { get; set; }
        public int? MeetingId { get; set; }
        public int? MemberId { get; set; }

        public virtual TbMember Member { get; set; }
    }
}
