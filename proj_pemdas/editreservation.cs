using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj_pemdas
{
    internal class editreservation
    {
        public void submenu()
        {
            Console.WriteLine("####################");
            Console.WriteLine("# ini edit reservasi #");
            Console.WriteLine("#####################");
            Console.WriteLine("");
            Console.WriteLine("1.Edit Reservasi Data");
            Console.WriteLine("2.Cancel Reservasi Data");
            editreservation asd = new editreservation();
            asd.subsecond();
        }
        public void subwrong()
        {
            Console.WriteLine("####################");
            Console.WriteLine("# ini edit reservasi #");
            Console.WriteLine("#####################");
            Console.WriteLine("");
            Console.WriteLine("1.Edit Reservasi Data");
            Console.WriteLine("2.Cancel Reservasi Data");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR : Input yang anda masukan salah");
            Console.ResetColor();
            editreservation asd = new editreservation();
            asd.subsecond();

        }
        public void subsecond()
        {
            int sub;
            submenu sub1 = new submenu();

            Console.WriteLine("");
            Console.Write("Pilih Menu : ");
            sub = int.Parse(Console.ReadLine());
            sub1.subswitch(sub);
        }

    }
    class submenu
    {
        editreservationdata edit = new editreservationdata();
        cancelreservationdata cancel = new cancelreservationdata();
        editreservation wrong = new editreservation();
        public void subswitch(int sub)
        {
            switch(sub)
            {
                case 1:
                    Console.Clear();
                    edit.sub2();
                    break;
                case 2:
                    Console.Clear();
                    cancel.sub2();
                    break;
                default:
                    Console.Clear();
                    wrong.subwrong();
                    break;

            }

        }
    }
}
