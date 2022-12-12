using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace proj_pemdas
{
    //menu 2

    internal class editreservation
    {
        //private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
        private string jsonFile = @"E:\Edgar\Kuliah\Pemdas\Proyek Akhir\proj_pemdas\data.json";
        public void back()//method menu kembali
        {

            @class call = new @class();
            onlyjson show = new onlyjson();
            editreservation lanjut = new editreservation();
            lanjut.submenu();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1.TKembali");
            Console.WriteLine("2.Kembali ke mainmenu");
            Console.ForegroundColor = ConsoleColor.Green;
            string select = Console.ReadLine();
            Console.ResetColor();
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
        public void submenu()//method tampilan edit reservasi
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
        public void submenuedit()//method menu edit reservasi
        {
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("Menu\t: ");
            Console.WriteLine("\t1.Edit Reservation");
            Console.WriteLine("\t--------------------");
            Console.WriteLine("\t2.Main menu");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
        }
        public void pilihsubmenuedit()//method tampilan pilih menu
        {
            editreservation edit = new editreservation();
            Console.Write("Pilih Menu : ");
            Console.ForegroundColor = ConsoleColor.Green;
            string pilihan = (Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("");
            edit.switchedit(pilihan);
        }
        public void switchedit(string x)//method switch
        {
            editreservation lanjut = new editreservation();
            @class call = new @class();
            onlyjson show = new onlyjson();
            switch (x)
            {
                case "1":
                    lanjut.edit();
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
        public void edit()//method fungsi edit reservasi
        {
            Console.WriteLine("Edit Reservasi");
            onlyjson show = new onlyjson();
            @class call = new @class();
            editreservation lanjut = new editreservation();
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                JArray dataarray = (JArray)jObject.SelectToken("data");
                Console.WriteLine("+---------------------------------------------------------------------------------+");
                Console.Write("Pilih Kelas\t: ");
                Console.ForegroundColor = ConsoleColor.Green;
                var kelasid = int.Parse(Console.ReadLine());
                Console.ResetColor();

                if (kelasid > 0)
                {
                    Console.Write("Pilih Kamar\t: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    var kamarid = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    if (kamarid > 0)
                    {

                        foreach (var getid in dataarray.Where(obj => obj["id1"].Value<int>() == kelasid))
                        {
                            JArray kamararray = (JArray)getid.SelectToken("kamar");
                            foreach (var getkamarid in kamararray.Where(obj => obj["id"].Value<int>() == kamarid))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                var pengunjung = getkamarid["pengunjung"].Count();
                                Console.ResetColor();

                                if (pengunjung != 0)
                                {

                                    JObject objpengunjung = (JObject)getkamarid;


                                    Console.WriteLine("1.Nama\t2.NIK\t3.No Hp");
                                    Console.Write("Pilih : ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    int pilihedit = int.Parse(Console.ReadLine());
                                    Console.ResetColor();
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
                                    Console.WriteLine("!!Kamar belum terisi!!");
                                    Console.ResetColor();
                                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                                    Console.WriteLine("1.kembali");
                                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                                    Console.Write("Pilih: ");
                                    int x = int.Parse(Console.ReadLine());
                                    switch(x)
                                        {
                                        case 1:
                                            Console.Clear();
                                            lanjut.back();
                                            break;
                                    }
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
        public void kembali1()//method tampilan kembali
        {
            onlyjson show = new onlyjson();
            @class call = new @class();
            editreservation lanjut = new editreservation();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("1.Kembali");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.Write("Pilih: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int kembali = int.Parse(Console.ReadLine());
            Console.ResetColor();
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
