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
        public void checkoutmenu()
        {
            checkout lanjut = new checkout();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Checkout");
            
            
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
                                var companyName = string.Empty;

                                JObject j = (JObject)pany;
                                var exp = j.GetValue("pengunjung") as JObject;
                                exp.Remove("nama");
                                exp.Remove("nik");
                                exp.Remove("nohp");
                                exp.Remove("datein");
                                exp.Remove("time");
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
        private void UpdateCompany()
        {
            string json = File.ReadAllText(jsonFile);

            try
            {
                var jObject = JObject.Parse(json);
                JArray experiencesArrary = (JArray)jObject["experiences"];
                Console.Write("Enter Company ID to Update Company : ");
                var companyId = Convert.ToInt32(Console.ReadLine());

                if (companyId > 0)
                {
                    Console.Write("Enter new company name : ");
                    var companyName = Convert.ToString(Console.ReadLine());

                    foreach (var company in experiencesArrary.Where(obj => obj["companyid"].Value<int>() == companyId))
                    {
                        company["companyname"] = !string.IsNullOrEmpty(companyName) ? companyName : "";
                    }

                    jObject["experiences"] = experiencesArrary;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonFile, output);
                }
                else
                {
                    Console.Write("Invalid Company ID, Try Again!");
                    UpdateCompany();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Update Error : " + ex.Message.ToString());
            }
        }
        public void checkoutback()
        {
            Console.WriteLine("");
            Console.WriteLine("1.Checkout: ");
            Console.WriteLine("Kembali ke main menu (y)");
            string back = (Console.ReadLine());
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
                    lanjut.DeleteCompany();
                    break;
                case "y":
                    Console.Clear();
                    call.backmainmenu();
                    break;
                default:
                    Console.Clear();
                    call.setup();
                    call.title();
                    show.GetUserDetails();
                    call.wrong();
                    lanjut.checkoutmenu();
                    lanjut.checkoutback();
                    break;
            }
        }
    }
}
