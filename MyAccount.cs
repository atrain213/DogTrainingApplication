using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public static class MyAccount
    {
        public static ViewContact Contact { get; set; } = new ViewContact();
        public static ViewSession Session { get; set; } = new();
        public static async Task LoadContantAsync(int id)
        {
            await Contact.loadAPIAsync(id);
            
        } 

         
    }
}
