using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace proj_pemdas
{
    internal class @class //Class Khusus menyimpan Method
    {
        public void saved()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reservation Changes Saved");
            Console.WriteLine("");
            Console.ResetColor();
        }
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
            Console.WriteLine("");
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
                Console.WriteLine("ID\tKELAS\t\tNO\tNAMA\t NIK\t\tNO HP\t\tDATE IN");
                Console.WriteLine("+---------------------------------------------------------------------------------+");
                for (int i = 0; i <= 2; i++)
                {
                    JObject objkelas = (JObject)jObject["data"][i];
                    for (int j = 0; j <= 1; j++)
                    {
                        JObject kamar = (JObject)objkelas["kamar"][j];
                        var objpengujung = kamar["pengunjung"];
                        if (objpengujung != null)
                        {
                            Console.WriteLine("{0}\t{1}\t{7}\t{2}\t {3}\t{4}\t{5} {6}",
                                objkelas["id1"],
                                objkelas["kelas"],
                                objpengujung["nama"],
                                objpengujung["nik"],
                                objpengujung["nohp"],
                                objpengujung["datein"],
                                objpengujung["time"],
                                kamar["id"]
                                .ToString());
                        }
                    }
                }
                Console.WriteLine("+---------------------------------------------------------------------------------+");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

