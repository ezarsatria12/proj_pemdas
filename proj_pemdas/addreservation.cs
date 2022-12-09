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
    internal class addreservation
    {
      private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
      public void submenu()
        {
            @class apalah = new @class();
            apalah.title();
            addreservation data = new addreservation();
            data.GetUserDetails();
        }
        public void GetUserDetails()
        {
            onlyjson show=new onlyjson();
            //file data.json di ada di folder bin/debug/net5.0/data.json
            show.GetUserDetails();  
            addreservation data = new addreservation();
            data.UpdateCompany();
        }
        public void UpdateCompany()
        {
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            JArray experiencesArrary = (JArray)jObject.SelectToken("data");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.Write("Pilih Kelas(Id)\t: ");
            var kelasid = int.Parse(Console.ReadLine());
            
            if (kelasid>0)
            {
                Console.Write("Pilih Kamar(No)\t: ");
                var kamarid = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                if (kamarid > 0)
                {
                    
                    foreach (var company in experiencesArrary.Where(obj => obj["id1"].Value<int>() == kelasid))
                    {
                        JArray ex = (JArray)company.SelectToken("kamar");
                        foreach (var pany in ex.Where(obj => obj["id"].Value<int>() == kamarid))
                        {
                            var a = pany["pengunjung"].Count();
                          
                            if (a == 0)
                            {
                                Console.WriteLine("Nama: ");
                                string nama = Console.ReadLine();
                                Console.WriteLine("NIK: ");
                                string nik = Console.ReadLine();
                                Console.WriteLine("No hp: ");
                                string nohp = Console.ReadLine();
                                
                                JObject j = (JObject)pany;
                                var exp = j.GetValue("pengunjung") as JObject;
                                var datetime = DateTime.Now;
                                exp.Add("nama", nama    );
                                exp.Add("nik", nik);
                                exp.Add("nohp", nohp);
                                exp.Add("datein", datetime.ToString("dd/MM/yy"));
                                exp.Add("time", datetime.ToString("hh:mm"));

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

    }   
}
