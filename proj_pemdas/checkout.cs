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
        private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
        public void submenu()
        {
            @class call = new @class();
            onlyjson show = new onlyjson();
            checkout lanjut = new checkout();
            call.setup();//memanggil method setup di class @class
            call.title();//memanggil method title di class @class
            show.GetUserDetails();//memanggil data json di data.json
            lanjut.checkoutback();
        }
        public void cekout()
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                JArray dataarray = (JArray)jObject.SelectToken("data");
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


                                JObject objpengunjung = (JObject)getkamarid;
                                var datapengunjung = objpengunjung.GetValue("pengunjung") as JObject;
                                datapengunjung.Remove("nama");
                                datapengunjung.Remove("nik");
                                datapengunjung.Remove("nohp");
                                datapengunjung.Remove("datein");
                                datapengunjung.Remove("time");
                                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                                File.WriteAllText(jsonFile, output);
                                
                                //back
                                checkout lanjut = new checkout();
                                Console.Clear();
                                @class call = new @class();
                                onlyjson show = new onlyjson();
                                addreservation add = new addreservation();
                                checkout checkout = new checkout();
                                call.setup();
                                call.title();
                                show.GetUserDetails();
                                call.saved();
                                lanjut.kembali();

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
        public void kembali()
        {
            //kembali
            @class call = new @class();
            onlyjson show = new onlyjson();
            addreservation add = new addreservation();
            checkout checkout = new checkout();
            checkout lanjut = new checkout();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("Menu");
            Console.WriteLine("1.Kembali");
            Console.WriteLine("2.Kembali ke mainmenu");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            string select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    Console.Clear();
                    call.setup();
                    call.title();
                    show.GetUserDetails();
                    lanjut.cekout();
                    break;
                case "2":
                    Console.Clear();
                    call.backmainmenu();
                    break;
                default:
                    Console.Clear();
                    call.setup();
                    call.title();
                    show.GetUserDetails();

                    call.wrong();
                    lanjut.kembali();
                    break;
            }
        }
        public void checkoutback()
        {
            @class call = new @class();
            //
            Console.WriteLine("Menu: ");
            Console.WriteLine("");
            Console.WriteLine("\t1. Checkout ");
            Console.WriteLine("\t2. main menu");
            string back = (Console.ReadLine());
            checkout chose = new checkout();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
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
                    lanjut.cekout();
                    break;
                case "2":
                    Console.Clear();
                    call.backmainmenu();
                    break;
                default:
                    Console.Clear();
                    call.setup();
                    call.title();
                    show.GetUserDetails();
                    call.wrong();
                    Console.WriteLine("");
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    
                    lanjut.checkoutback();
                    break;
            }

        }
    }
}
