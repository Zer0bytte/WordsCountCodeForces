using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp4.Models
{
    public partial class TbMember
    {
        public TbMember()
        {
            TbAttendences = new HashSet<TbAttendence>();
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? BornDate { get; set; }
        public int? AbsenceNumber { get; set; }
        public int? AttendenceNumber { get; set; }

        public virtual ICollection<TbAttendence> TbAttendences { get; set; }
    }
}
