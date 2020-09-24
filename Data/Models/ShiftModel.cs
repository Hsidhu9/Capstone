using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public UserModel CreatedBy { get; set; }
        public int NumberOfEmployeesNeeded { get; set; }
        public ICollection<ShiftDetailModel> ShiftDetails { get; set; }
    }
}
