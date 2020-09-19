using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Models
{
    public class ShiftDetailModel
    {
        public int Id { get; set; }
        public ShiftModel Shift { get; set; }
        public UserModel PickedBy { get; set; }
    }
}
