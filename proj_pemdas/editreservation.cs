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
        private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
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
        public void DeleteCompany()
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                JArray experiencesArrary = (JArray)jObject.SelectToken("data");
                Console.WriteLine("+---------------------------------------------------------------------------------+");
                Console.WriteLine("Pilih Kelas\t: ");
                var kelasid = int.Parse(Console.ReadLine());

                if (kelasid > 0)
                {
                    Console.WriteLine("Pilih Kamar\t: ");
                    var kamarid = int.Parse(Console.ReadLine());

                    if (kamarid > 0)
                    {

                        foreach (var company in experiencesArrary.Where(obj => obj["id1"].Value<int>() == kelasid))
                        {
                            JArray ex = (JArray)company.SelectToken("kamar");
                            foreach (var pany in ex.Where(obj => obj["id"].Value<int>() == kamarid))
                            {
                                
                               
                                
                                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                                File.WriteAllText(jsonFile, output);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("kamar yang anda pilihh tidak ada");
                    }

                }
                else
                {
                    Console.WriteLine("kelas yang anda pilihh tidak ada");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
