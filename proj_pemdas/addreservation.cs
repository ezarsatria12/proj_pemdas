using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace proj_pemdas
{
    internal class addreservation
    {
      public void submenu()
        {
            Console.WriteLine("####################");
            Console.WriteLine("# ini reservasi #");
            Console.WriteLine("#####################");
            addreservation data = new addreservation();
            data.GetUserDetails();
        }
        private void GetUserDetails()
        {
            //file data.json di ada di folder bin/debug/net5.0/data.json
            var json = File.ReadAllText("./data.json");
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    Console.WriteLine("ID :" + jObject["id"].ToString());
                    Console.WriteLine("Name :" + jObject["name"].ToString());

                    var address = jObject["address"];
                    Console.WriteLine("Street :" + address["street"].ToString());
                    Console.WriteLine("City :" + address["city"].ToString());
                    Console.WriteLine("Zipcode :" + address["zipcode"]);
                    JArray experiencesArrary = (JArray)jObject["experiences"];
                    if (experiencesArrary != null)
                    {
                        foreach (var item in experiencesArrary)
                        {
                            Console.WriteLine("company Id :" + item["companyid"]);
                            Console.WriteLine("company Name :" + item["companyname"].ToString());
                        }

                    }
                    Console.WriteLine("Phone Number :" + jObject["phoneNumber"].ToString());
                    Console.WriteLine("Role :" + jObject["role"].ToString());

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }   
    
}
