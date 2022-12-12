using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj_pemdas
{
    internal class showdata
    {
        public void submenu()//method show data
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            showdata lanjut = new showdata();
            call.setup();//memanggil method setup
            call.title();//memanggil method header
            show.GetUserDetails();//memanggil method tabel data
            lanjut.showback();//memanggil method menu show data
        }
        public void showback()//method menu show data
        {
            Console.WriteLine("");
            Console.WriteLine("1.Kembali ke main menu");
            Console.WriteLine("");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.Write("Pilih: ");
            Console.ForegroundColor= ConsoleColor.Green;
            string back = (Console.ReadLine());
            Console.ResetColor();
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
                    Console.Clear();//menghapus tampilan
                    call.backmainmenu();//memanggil method main menu
                    break;
                default:
                    Console.Clear();//menghapus tampilan
                    call.setup();//memanggil method setup
                    call.title();//memanggil method header
                    show.GetUserDetails();//memanggil method tabel data
                    call.wrong();//memanggil method error
                    lanjut.showback();//memanggil method tampilkan tabel
                    break;
            }
        }
    }
}
