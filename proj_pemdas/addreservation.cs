using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;


namespace proj_pemdas
{
    internal class addreservation
    {
        private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\tsconfig1.json";
      public void submenu()
        {
            Program apalah = new Program();
            apalah.title();
            addreservation data = new addreservation();
            data.GetUserDetails();
        }
        public void GetUserDetails()
        {
            //file data.json di ada di folder bin/debug/net5.0/data.json
            var json = File.ReadAllText("E:\\MMS\\kuliah\\proj_pemdas\\proj_pemdas\\data.json");
            try
            {
                var jObject = JObject.Parse(json);
                //JArray a = JArray.Parse(json);
                Console.WriteLine("NO\tnama\t\tNIK\t\tNO HP\t\tDATE IN");
                Console.WriteLine("+-------------------------------------------------------------+");
                for (int i = 0; i <= 4; i++)
                {
                    JObject experiencesArrary = (JObject)jObject["data"][i];
                    
                    if (experiencesArrary["nama"] == null|| experiencesArrary["nik"] != null)
                    {
                        
                        Console.WriteLine("{0}\t{1}\t\t{3}\t{4}\t\t{5}",
                            experiencesArrary["id"],
                            experiencesArrary["nama"],
                            experiencesArrary["nik"],
                            experiencesArrary["nohp"],
                            experiencesArrary["datein"],
                            experiencesArrary["time"]
                            .ToString());
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

    }   

    
}
