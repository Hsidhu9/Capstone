using Microsoft.AspNetCore.SignalR;
using ShiftPicker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift_Picker.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
