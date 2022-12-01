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
            //setup
            Console.SetWindowSize(120, 40);
            Program apalah = new Program();

            //title
            Console.WriteLine("####################");
            Console.WriteLine("# HOTEL RESERVATION #");
            Console.WriteLine("#####################");

            //mainmenu
            Console.WriteLine("");
            Console.WriteLine("MAIN MENU :");
            Console.WriteLine("");
            Console.WriteLine("1. add reservation \t| 4. check out");
            Console.WriteLine("2. edit reservation \t| 5. exit");
            Console.WriteLine("3. show data \t\t|");
            //Console.WriteLine("======================================");
            apalah.second();

        }
        public void wrong()
        {
            //setup
            Console.SetWindowSize(120, 40);
            Program apalah = new Program();

            //title
            Console.WriteLine("####################");
            Console.WriteLine("# HOTEL RESERVATION #");
            Console.WriteLine("#####################");

            //mainmenu
            Console.WriteLine("");
            Console.WriteLine("MAIN MENU :");
            Console.WriteLine("");
            Console.WriteLine("1. add reservation \t| 4. check out");
            Console.WriteLine("2. edit reservation \t| 5. exit");
            Console.WriteLine("3. show data \t\t|");
            //Console.WriteLine("======================================");
            Console.WriteLine("");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("ERROR : Input yang anda masukan salah");
            Console.ResetColor();
            apalah.second();
        }
        public void second()
        {
            int men;
            menu chose = new menu();

            Console.WriteLine("");
            Console.Write("Pilih Menu : ");
            men = int.Parse(Console.ReadLine());
            chose.Apph(men);
        }
    }
    class menu
    {
        addreservation add= new addreservation();
        editreservation edit = new editreservation();
        showdata show = new showdata();
        deletereservation delete = new deletereservation();
        Program komen = new Program();
        public void Apph(int x)
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
                default:
                    Console.Clear();
                    komen.wrong();
                    break;

            }
        }
    }
}
