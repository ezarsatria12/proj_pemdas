using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj_pemdas
{
    internal class showdata
    {
        public void submenu()
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            showdata lanjut = new showdata();
            call.setup();
            call.title();
            show.GetUserDetails();
            lanjut.showback();
        }
        public void showback()
        {
            Console.WriteLine("");
            Console.WriteLine("1.Kembali ke main menu");
            string back = (Console.ReadLine());
            showdata chose = new showdata();
            chose.switchback(back);

        }
        public void switchback(string x)
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            showdata lanjut = new showdata();
            switch (x)
            {
                case "1":
                    Console.Clear();
                    call.backmainmenu();
                    break;
                default:
                    Console.Clear();
                    call.setup();
                    call.title();
                    show.GetUserDetails();
                    call.wrong();
                    lanjut.showback();
                    break;
            }
        }
    }
}
