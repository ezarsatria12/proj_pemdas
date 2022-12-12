using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace proj_pemdas
{
    internal class checkout
    {
        // private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
        private string jsonFile = @"E:\Edgar\Kuliah\Pemdas\Proyek Akhir\proj_pemdas\data.json";
        public void submenu()
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            checkout lanjut = new checkout();
            call.setup();//memanggil method setup
            call.title();//memanggil method title
            show.GetUserDetails();//memanggil method tabel data
            lanjut.checkoutback();//memanggil method menu kembali
        }
        public void cekout()//method menghapus data
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                JArray dataarray = (JArray)jObject.SelectToken("data");
                Console.Write("Pilih Kelas: ");
                Console.ForegroundColor = ConsoleColor.Green;
                var kelasid = int.Parse(Console.ReadLine());
                Console.ResetColor();

                if (kelasid > 0)
                {
                    Console.Write("Pilih Kamar: ");
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


                                JObject objpengunjung = (JObject)getkamarid;
                                var datapengunjung = objpengunjung.GetValue("pengunjung") as JObject;
                                //mengapus data yang ada
                                datapengunjung.Remove("nama");
                                datapengunjung.Remove("nik");
                                datapengunjung.Remove("nohp");
                                datapengunjung.Remove("datein");
                                datapengunjung.Remove("time");
                                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                                File.WriteAllText(jsonFile, output);
                                
                                //back
                                checkout lanjut = new checkout();
                                Console.Clear();//menghapus tampilan
                                @class call = new @class();
                                onlyjson show = new onlyjson();
                                addreservation add = new addreservation();
                                checkout checkout = new checkout();
                                call.setup();//memanggil method setup
                                call.title();//memanggil method header
                                show.GetUserDetails();//memanggil method tabel data
                                call.saved();//memanggil method tampilan save
                                lanjut.kembali();//memanggil method kembali

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
        public void kembali()//method kembali
        {
            //kembali
            @class call = new @class();
            onlyjson show = new onlyjson();
            checkout lanjut = new checkout();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("Menu");
            Console.WriteLine("\t1.Kembali");
            Console.WriteLine("-------------------------");
            Console.WriteLine("\t2.Kembali ke mainmenu");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.Write("Pilih: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string select = Console.ReadLine();
            Console.ResetColor();
            switch (select)
            {
                case "1":
                    Console.Clear();//menghapus tampilan
                    call.setup();//memanggil method setup
                    call.title();//memanggil method header
                    show.GetUserDetails();//memanggil method tabel data
                    lanjut.checkoutback();//memanggil method menu kembali
                    lanjut.cekout();//memanggil method checkout
                    break;
                case "2":
                    Console.Clear();//menghapus tampilan
                    call.backmainmenu();//memanggil method main menu
                    break;
                default:
                    Console.Clear();//menghapus tampilan
                    call.setup();//memanggil method setup
                    call.title();//memanggil method header
                    show.GetUserDetails();//memanggil method tabel data
                    call.wrong();//memanggil method error
                    lanjut.kembali();//memanggil method kembali
                    break;
            }
        }
        public void checkoutback()//method menu kembali
        {
            @class call = new @class();
            Console.WriteLine("");
            Console.WriteLine("\t1. Checkout ");
            Console.WriteLine("\t---------------------");
            Console.WriteLine("\t2. main menu");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.Write("Pilih: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string back = (Console.ReadLine());
            Console.ResetColor();
            checkout chose = new checkout();
            chose.switchback(back);
        }
        public void switchback(string x)
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            checkout lanjut = new checkout();

            switch (x)
            {
                case "1":
                    lanjut.cekout();//memanggil method checkout
                    break;
                case "2":
                    Console.Clear();//menghapus tampilan
                    call.backmainmenu();//memanggil method main menu
                    break;
                default:
                    Console.Clear();//menghapus tampilan
                    call.setup();//memanggil method setup
                    call.title();//memanggil method header
                    show.GetUserDetails();//memanggil method tabel data
                    call.wrong();//memanggil method error
                    Console.WriteLine("");
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    lanjut.checkoutback();//memanggil method menu kembali
                    break;
            }

        }
    }
}
