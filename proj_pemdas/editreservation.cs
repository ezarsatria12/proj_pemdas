using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace proj_pemdas
{
    //menu 2

    internal class editreservation
    {
        private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
        public void back()
        {

            @class call = new @class();
            onlyjson show = new onlyjson();
            editreservation lanjut = new editreservation();
            lanjut.submenu();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1.TKembali");
            Console.WriteLine("2.Kembali ke mainmenu");
            string select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    Console.Clear();
                    lanjut.submenu();
                    break;
                case "2":
                    Console.Clear();
                    call.backmainmenu();
                    break;

                default:
                    Console.Clear();
                    call.title();
                    show.GetUserDetails();
                    call.wrong();
                    lanjut.back();
                    break;
            }
        }
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
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("Menu\t: ");
            Console.WriteLine("");
            Console.WriteLine("\t1.Edit Reservation");
            Console.WriteLine("\t--------------------");
            Console.WriteLine("\t2.Main menu");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
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
            lanjut.edit();

        }
        public void deletereservasi()
        {
            Console.WriteLine("Delete Reservasi");
            Console.WriteLine("-------------------");
            Console.WriteLine("Pilih Nomor Reservasi : ");
            int reservasi = int.Parse(Console.ReadLine());
        }
        public void edit()
        {
            onlyjson show = new onlyjson();
            @class call = new @class();
            editreservation lanjut = new editreservation();
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                JArray dataarray= (JArray)jObject.SelectToken("data");
                Console.WriteLine("+---------------------------------------------------------------------------------+");
                Console.WriteLine("Pilih Kelas\t: ");
                var kelasid = int.Parse(Console.ReadLine());

                if (kelasid > 0)
                {
                    Console.WriteLine("Pilih Kamar\t: ");
                    var kamarid = int.Parse(Console.ReadLine());

                    if (kamarid > 0)
                    {

                        foreach (var getid in dataarray.Where(obj => obj["id1"].Value<int>() == kelasid))
                        {
                            JArray kamararray = (JArray)getid.SelectToken("kamar");
                            foreach (var getkamarid in kamararray.Where(obj => obj["id"].Value<int>() == kamarid))
                            {
                                var pengunjung = getkamarid["pengunjung"].Count();

                                if (pengunjung != 0)
                                {

                                    JObject objpengunjung = (JObject)getkamarid;
                                    Console.WriteLine("1. nama 2.nik 3.no hp");
                                    Console.Write("PILIH : ");
                                    int pilihedit = int.Parse(Console.ReadLine());
                                    var datapengunjung = objpengunjung.GetValue("pengunjung") as JObject;
                                    switch (pilihedit)
                                    {
                                        case 1:
                                            Console.Write("Nama: ");
                                            string nama = Console.ReadLine();
                                            datapengunjung["nama"] = !string.IsNullOrEmpty(nama) ? nama : "";
                                            break;
                                        case 2:
                                            Console.Write("NIK: ");
                                            string nik = Console.ReadLine();
                                            datapengunjung["nik"] = !string.IsNullOrEmpty(nik) ? nik : "";
                                            break;
                                        case 3:
                                            Console.Write("No hp: ");
                                            string nohp = Console.ReadLine();
                                            datapengunjung["nohp"] = !string.IsNullOrEmpty(nohp) ? nohp : "";
                                            break;
                                        default:
                                            break;
                                    }
                                    objpengunjung["pengunjung"] = datapengunjung;
                                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                                    File.WriteAllText(jsonFile, newJsonResult);
                                    lanjut.kembali1();
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
        public void kembali1()
        {
            onlyjson show = new onlyjson();
            @class call = new @class();
            editreservation lanjut = new editreservation();
            Console.WriteLine("1.Kembali");
            int kembali = int.Parse(Console.ReadLine());
            switch (kembali)
            {
                case 1:
                    Console.Clear();
                    call.title();
                    show.GetUserDetails();
                    call.saved();
                    lanjut.submenuedit();
                    lanjut.pilihsubmenuedit();
                    break;
                default:
                    call.wrong();
                    lanjut.kembali1();
                    break;
            }
        }
    }
}
