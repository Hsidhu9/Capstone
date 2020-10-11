using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }
        public int EmployeesNeeded { get; set; }
        public ICollection<ShiftDetailModel> ShiftDetails { get; set; }
    }
}
