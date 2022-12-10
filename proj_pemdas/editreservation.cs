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
            editreservation lanjut = new editreservation();
            lanjut.DeleteCompany();

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
                                var a = pany["pengunjung"].Count();

                                if (a != 0)
                                {
                                    JObject j = (JObject)pany;
                                    Console.WriteLine("1. nama 2.nik 3.no hp");
                                    Console.WriteLine("PILIH : ");
                                    int pilihedit=int.Parse(Console.ReadLine());
                                    var exp = j.GetValue("pengunjung") as JObject;
                                    switch (pilihedit)
                                    {
                                        case 1:
                                            Console.WriteLine("Nama: ");
                                            string nama = Console.ReadLine();
                                            exp["nama"] = !string.IsNullOrEmpty(nama) ? nama : "";
                                            break;
                                        case 2:
                                            Console.WriteLine("NIK: ");
                                            string nik = Console.ReadLine();
                                            exp["nik"] = !string.IsNullOrEmpty(nik) ? nik : "";
                                            break;
                                        case 3:
                                            Console.WriteLine("No hp: ");
                                            string nohp = Console.ReadLine();
                                            exp["nohp"] = !string.IsNullOrEmpty(nohp) ? nohp : "";
                                            break;
                                        default:
                                            break;
                                    }
                                    j["pengunjung"] = exp;
                                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                                    File.WriteAllText(jsonFile, newJsonResult);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("!!Kamar sudah terisi!!");
                                    Console.ResetColor();
                                }
                               
                                
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
