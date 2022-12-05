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
        public void title()
        {
            //title
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("|\tHOTEL RESERVATION\t|");
            Console.WriteLine("+-------------------------------+");
        }
        static void Main(string[] args)
        {
            //setup
            Console.SetWindowSize(120, 40);
            Program apalah = new Program();

            apalah.title();

            //mainmenu
            Console.WriteLine("");
            Console.WriteLine("MAIN MENU :");
            Console.WriteLine("");
            Console.WriteLine("1. add reservation \t| 3. show data");
            Console.WriteLine("2. edit reservation \t| 4. check out");
            //Console.WriteLine("======================================");
            apalah.second();

        }
        public void second()
        {
            int men;
            menu chose = new menu();

            Console.WriteLine("");
            Console.Write("Pilih Menu : ");
            men = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            chose.Apph(men);
        }
    }
    class menu
    {
        addreservation add= new addreservation();
        editreservation edit = new editreservation();
        showdata show = new showdata();
        deletereservation delete = new deletereservation();
        Program back = new Program();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR : Input yang anda masukan tidak tersedia");
                    Console.ResetColor();
                    back.second();
                    break;

            }
        }
    }
}
