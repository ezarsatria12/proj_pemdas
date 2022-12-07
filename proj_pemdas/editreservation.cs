using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.ComponentModel.Design;

namespace proj_pemdas
{
    //menu 2

    internal class editreservation
    {
        public void submenu()
        {
            //Panggil Method dari Class Program
            @class call = new @class();
            onlyjson show = new onlyjson();
            editreservation lanjut = new editreservation();
            call.setup();
            call.title();
            show.GetUserDetails();
            lanjut.submenuedit();
            lanjut.pilihsubmenuedit();
        }
        public void submenuedit()
        {
            Console.WriteLine("+---------------------------------------------------------------+");
            Console.WriteLine("Menu\t: ");
            Console.WriteLine("");
            Console.WriteLine("\t1.Edit Reservation");
            Console.WriteLine("\t2.Delete Reservation");
            Console.WriteLine("\t--------------------");
            Console.WriteLine("\tBack to main menu (y)");
            Console.WriteLine("+---------------------------------------------------------------+");
        }
        public void pilihsubmenuedit()
        {
            editreservation edit = new editreservation();
            Console.WriteLine("");
            Console.Write("Pilih Menu : ");
            Console.ForegroundColor = ConsoleColor.Green;
            string pilihan = (Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("");
            edit.switchedit(pilihan);
        }
        public void switchedit(string x)
        {
            editreservation lanjut = new editreservation();
            @class call = new @class();
            onlyjson show = new onlyjson();
            switch (x)
            {
                case "1":
                    lanjut.editreservasi();
                    break;
                case "2":
                    lanjut.deletereservasi();
                    break;
                case "y":
                    Console.Clear();
                    call.backmainmenu();
                    break;
                default:
                    Console.Clear();
                    call.title();
                    show.GetUserDetails();
                    lanjut.submenuedit();
                    call.wrong();
                    lanjut.pilihsubmenuedit();
                    break;
            }
        }
        public void editreservasi()
        {
            Console.WriteLine("Edit Reservasi");
            Console.WriteLine("-------------------");
            Console.WriteLine("Pilih Nomor Reservasi : ");
            int reservasi = int.Parse(Console.ReadLine());
        }
        public void deletereservasi()
        {
            Console.WriteLine("Delete Reservasi");
            Console.WriteLine("-------------------");
            Console.WriteLine("Pilih Nomor Reservasi : ");
            int reservasi = int.Parse(Console.ReadLine());
        }
        
    }
}
