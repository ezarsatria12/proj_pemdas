using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace proj_pemdas
{

    internal class Program
    {
        
        static void Main(string[] args)//Menampilkan Semua Method agar menampilkan Main Menu
        {
            Console.SetWindowSize(120, 40);
            Program menuawal = new Program();
            @class layout = new @class();
            layout.setup();//menyeting lebar dan tinggi jendela console app
            layout.title();//menampilkan header
            menuawal.mainmenu();//menampilkan menu
            menuawal.second();//menampilkan pilih menu
        }
        
        public void mainmenu()//Method Menu
        {
            //mainmenu
            var dateTime = DateTime.Now;
            Console.WriteLine("+---------------------------------------------------------------+");
            Console.Write("MAIN MENU : ");
            Console.WriteLine(dateTime.ToString("\t\t\t\t\t\tdd/MM/yy"));
            Console.WriteLine("");
            Console.WriteLine("\t1. Add Reservation \t| 4. Check Out");
            Console.WriteLine("\t2. Edit Reservation \t| 5. Exit");
            Console.WriteLine("\t3. Show Data");
            Console.WriteLine("");
            Console.WriteLine("+---------------------------------------------------------------+");
            
            
        }
        public void second()//Method Pilih Menu
        {
            int menuselect;
            menu chose = new menu();
            Console.Write("Pilih Menu : ");
            Console.ForegroundColor = ConsoleColor.Green;
            menuselect = int.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("");
            chose.pilih(menuselect);
        }
    }
    
    class menu
    {
        addreservation add= new addreservation();
        editreservation edit = new editreservation();
        showdata show = new showdata();
        checkout delete = new checkout();
        @class back = new @class();
        Program turn = new Program();
        public void pilih(int x)//method untuk berpindah tampilan ke menu lain
        {
            switch(x)
            {
                case 1:
                    Console.Clear();//menghapus tampilan
                    add.submenu();//berpindah ke tampilan add reservation
                    break;
                case 2:
                    Console.Clear();//menghapus tampilan
                    edit.submenu();//berpindah ke tampilan edit reservation
                    break;
                case 3:
                    Console.Clear();//menghapus tampilan
                    show.submenu();//berpindah ke tampilan show data
                    break;
                case 4:
                    Console.Clear();//menghapus tampilan
                    delete.submenu();//berpindah ke tampilan Checkout
                    break;
                case 5:
                    Environment.ExitCode = -1;//exit
                    break;
                default:
                    Console.Clear();
                    back.title();//memanggil method header
                    turn.mainmenu();//memanggil method header main menu
                    back.wrong();//memanggil method header error
                    turn.second();//memanggil method header menu pilih
                    break;

            }
        }
    }
}
