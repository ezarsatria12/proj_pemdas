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
            //file data.json di ada di folder bin/debug/net5.0/data.json
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                //JArray a = JArray.Parse(json);
                Console.WriteLine("ID NO\tKELAS\t\tNAMA\t\tNIK\t\tNO HP\t\tDATE IN");
                Console.WriteLine("+---------------------------------------------------------------------------------+");
                for (int i = 0; i <= 2; i++)
                {
                    JObject experiencesArrary = (JObject)jObject["data"][i];
                    for (int j = 0; j <= 1; j++)
                    {
                        JObject kamar = (JObject)experiencesArrary["kamar"][j];
                        var k = kamar["pengunjung"];
                        if (k!= null)
                        {

                            Console.WriteLine("{0}  {7}\t{1}\t{2}\t\t{3}\t{4}\t{5} {6}",
                                experiencesArrary["id1"],
                                experiencesArrary["kelas"],
                                k["nama"],
                                k["nik"],
                                k["nohp"],
                                k["datein"],
                                k["time"],
                                kamar["id"]
                                .ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            addreservation data = new addreservation();
            data.UpdateCompany();
        }
        public void UpdateCompany()
        {
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            JArray experiencesArrary = (JArray)jObject.SelectToken("data");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("Pilih Kelas\t: ");
            var kelasid = int.Parse(Console.ReadLine());
            
            if (kelasid>0)
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
                            
                            var nama = "aaa";
                            var newCompanyMember = "{'nama': '" + nama + "'}";
                            var experienceArrary = jObject.GetValue("data") as JArray;
                            var newCompany = JObject.Parse(newCompanyMember);
                            experienceArrary.Add(newCompany);
                            pany["pengunjung"] = experienceArrary;
                            string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(pany, Newtonsoft.Json.Formatting.Indented);
                            File.WriteAllText(jsonFile, newJsonResult);
                            /*if (ep != null)
                            {
                                
                               
                            }
                            else
                            {
                                Console.WriteLine("!!Kamar sudah terisi!!");
                            }*/
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

            /*var newCompanyMember = "{ 'companyid': " + companyId + ",  'companyname': '" + companyName + "'}";  
            try  
            {  
                var json = File.ReadAllText(jsonFile);
                var jsonObj = JObject.Parse(json);
                var experienceArrary = jsonObj.GetValue("experiences") as JArray;
                var newCompany = JObject.Parse(newCompanyMember);
                experienceArrary.Add(newCompany);  
  
                jsonObj["experiences"] = experienceArrary;  
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, newJsonResult);  
            }  
            catch (Exception ex)  
            {  
                Console.WriteLine("Error : " + ex.Message.ToString());  
            } */
            
        }

    }   

    
}
