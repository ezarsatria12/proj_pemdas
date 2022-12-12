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
        
        static void Main(string[] args)
        {
            /*Progra b = new Progra();
            b.aa();*/
            //setup
           Console.SetWindowSize(120, 40);
            Program menuawal = new Program();
            @class layout = new @class();
            layout.setup();
            layout.title();
            menuawal.mainmenu();
            menuawal.second();
        }
        
        public void mainmenu()
        {
            //mainmenu
            Console.WriteLine("+---------------------------------------------------------------+");
            Console.WriteLine("MAIN MENU : ");
            Console.WriteLine("");
            Console.WriteLine("\t1. Add Reservation \t| 4. Check Out");
            Console.WriteLine("\t2. Edit Reservation \t| 5. Exit");
            Console.WriteLine("\t3. Show Data");
            Console.WriteLine("");
            Console.WriteLine("+---------------------------------------------------------------+");
            var dateTime = DateTime.Now;
            Console.WriteLine(dateTime.ToString("dd/MM/yy"));   
        }
        public void second()
        {
            int menuselect;
            menu chose = new menu();
            Console.WriteLine("");
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
        public void pilih(int x)
        {
            switch(x)
            {
                case 1:
                    Console.Clear();
                    add.submenu();
                    break;
                case 2:
                    Console.Clear();
                    edit.submenu();
                    break;
                case 3:
                    Console.Clear();
                    show.submenu();
                    break;
                case 4:
                    Console.Clear();
                    delete.submenu();
                    break;
                case 5:
                    Environment.ExitCode = -1;
                    break;
                default:
                    Console.Clear();
                    back.title();
                    turn.mainmenu();
                    back.wrong();
                    turn.second();
                    break;

            }
        }
    }
}
