using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Data.Models
{
    public class CancelRequestModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ShiftDetailModel ShiftDetails { get; set; }
    }
}
