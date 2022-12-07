using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj_pemdas
{
    internal class checkout
    {
        public void submenu()
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            checkout lanjut = new checkout();
            call.setup();//memanggil method setup di class @class
            call.title();//memanggil method title di class @class
            show.GetUserDetails();//memanggil data json di data.json
            lanjut.checkoutback();
        }
        public void checkoutmenu()
        {
            checkout lanjut = new checkout();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Checkout");
            Console.WriteLine("Reservation ID: ");
            Console.WriteLine("");
            int resid = int.Parse(Console.ReadLine());
            
        }
        public void checkoutback()
        {
            Console.WriteLine("");
            Console.WriteLine("1.Checkout: ");
            Console.WriteLine("Kembali ke main menu (y)");
            string back = (Console.ReadLine());
            checkout chose = new checkout();
            chose.switchback(back);
        }
        public void switchback(string x)
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            checkout lanjut = new checkout();
            switch (x)
            {
                case "1":
                    lanjut.checkoutmenu();
                    break;
                case "y":
                    Console.Clear();
                    call.backmainmenu();
                    break;
                default:
                    Console.Clear();
                    call.setup();
                    call.title();
                    show.GetUserDetails();
                    call.wrong();
                    lanjut.checkoutmenu();
                    lanjut.checkoutback();
                    break;
            }
        }
    }
}
