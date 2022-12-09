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
    internal class @class //Class Khusus menyimpan Method
    {
        //setup
        public void setup()
        {
            Console.SetWindowSize(120, 40);
        }
        public void title()
        {
            //title
            Console.WriteLine("\t\t+-------------------------------+");
            Console.WriteLine("\t\t|\tHOTEL RESERVATION\t|");
            Console.WriteLine("\t\t+-------------------------------+");
        }
        public void wrong()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR : Input yang anda masukan tidak tersedia");
            Console.ResetColor();
        }
        public void backmainmenu()
        {
            @class call = new @class();
            Program back = new Program();
            call.setup();
            call.title();
            back.mainmenu();
            back.second();
        }
    }
    //Class khusus untuk menampilkan data.json
    class onlyjson
    {
        //tiap pindah device ganti path oakwoakwokaw
        public string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
        public void submenueditdata()
        {

            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            JArray experiencesArrary = (JArray)jObject.SelectToken("data");

            Console.WriteLine("Pilih Nomor Reservasi\t: ");
            var kelasid = int.Parse(Console.ReadLine());

        }


        public void GetUserDetails()
        {
            //file data.json di ada di folder bin/debug/net5.0/data.json
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                //JArray a = JArray.Parse(json);
                Console.WriteLine("ID KELAS\tNO NAMA\t\tNIK\t\tNO HP\t\tDATE IN");
                Console.WriteLine("+---------------------------------------------------------------------------------+");
                for (int i = 0; i <= 2; i++)
                {
                    JObject experiencesArrary = (JObject)jObject["data"][i];
                    for (int j = 0; j <= 1; j++)
                    {
                        JObject kamar = (JObject)experiencesArrary["kamar"][j];
                        var k = kamar["pengunjung"];
                        if (k != null)
                        {

                            Console.WriteLine("{0}  {1}\t{7}  {2}\t\t{3}\t{4}\t{5} {6}",
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

        }
    }
}

