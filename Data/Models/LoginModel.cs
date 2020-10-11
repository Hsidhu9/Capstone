using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Models
{
    public class LoginModel
    {  
        public bool IsAuthenticated { get; set; }
        public UserModel User { get; set; }
    }
}
