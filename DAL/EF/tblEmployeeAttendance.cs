//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployeeAttendance
    {
        public string employeeId { get; set; }
        public string attendanceDate { get; set; }
        public int isPresent { get; set; }
        public Nullable<int> isAbsent { get; set; }
        public int isOffday { get; set; }
    }
}
