using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Xml.Schema;

namespace proj_pemdas
{
    internal class addreservation
    {
        //panggil file json
        private string jsonFile = @"E:\MMS\kuliah\proj_pemdas\proj_pemdas\data.json";
        public void menu()
        {
            Console.WriteLine("Menu\t: ");
            Console.WriteLine("");
            Console.WriteLine("\t1.Add Reservation");
            Console.WriteLine("\t--------------------");
            Console.WriteLine("\t2.Main menu");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
        }
        public void pilihan()
        {
            addreservation add = new addreservation();
            Console.WriteLine("");
            Console.WriteLine("Pilih Menu: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int pilih = int.Parse(Console.ReadLine());
            Console.ResetColor();
            add.milih(pilih);
        }
        public void milih(int x)
        {
            addreservation add = new addreservation();
            @class back = new @class();
            Program turn = new Program();
            addreservation data = new addreservation();
            switch (x)
            {
                case 1:
                    data.add();
                    break;
                case 2:
                    Console.Clear();
                    back.title();
                    turn.mainmenu();
                    turn.second();
                    break;
                default:
                    Console.Clear();
                    back.title();
                    data.GetUserDetails();
                    add.menu();
                    back.wrong();
                    add.pilihan();
                    break;
            }
        }
        public void submenu()
        {
            addreservation add = new addreservation();
            @class apalah = new @class();
            addreservation data = new addreservation();
            apalah.title();
            data.GetUserDetails();
            add.menu();
            add.pilihan();
        }
        public void GetUserDetails()
        {
            onlyjson show = new onlyjson();
            //file data.json di ada di folder bin/debug/net5.0/data.json
            show.GetUserDetails();

        }
        public void add()
        {
            addreservation add = new addreservation();
            @class apalah = new @class();
            addreservation data = new addreservation();
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            JArray dataarray = (JArray)jObject.SelectToken("data");
            Console.Write("Pilih Kelas(Id)\t: ");
            var kelasid = int.Parse(Console.ReadLine());
            
            if (kelasid > 0&&kelasid<=3)
            {               
                Console.Write("Pilih Kamar(No)\t: ");
                var kamarid = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");
                
                if (kamarid > 0&&kamarid<=6)
                {

                    foreach (var getid in dataarray.Where(obj => obj["id1"].Value<int>() == kelasid))
                    {
                        JArray kamararray = (JArray)getid.SelectToken("kamar");
                        JValue harga = (JValue)getid.SelectToken("harga");
                        
                        
                        foreach (var getkamarid in kamararray.Where(obj => obj["id"].Value<int>() == kamarid))
                        {
                            var pengunjung = getkamarid["pengunjung"].Count();

                            if (pengunjung == 0)
                            {
                                Console.Write("Nama: ");
                                string nama = Console.ReadLine();
                                Console.Write("NIK: ");
                                string nik = Console.ReadLine();
                                Console.Write("No hp: ");
                                string nohp = Console.ReadLine();

                                JObject objpengunjung = (JObject)getkamarid;
                                var datapengunjung = objpengunjung.GetValue("pengunjung") as JObject;
                                var datetime = DateTime.Now;
                                datapengunjung.Add("nama", nama);
                                datapengunjung.Add("nik", nik);
                                datapengunjung.Add("nohp", nohp);
                                datapengunjung.Add("datein", datetime.ToString("dd/MM/yy"));
                                datapengunjung.Add("time", datetime.ToString("hh:mm"));

                                objpengunjung["pengunjung"] = datapengunjung;
                                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                                File.WriteAllText(jsonFile, newJsonResult);
                                payment((int)harga);
                                //Kembali
                                addreservation back = new addreservation();
                                @class call = new @class();
                                onlyjson show = new onlyjson();
                                call.saved();
                                back.kembali();


                            }
                            else
                            {
                                Console.Clear();
                                apalah.title();
                                data.GetUserDetails();
                                add.menu();
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Kamar tidak tersedia");
                                Console.ResetColor();
                                Console.WriteLine("");
                                add.add();
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
                Console.Clear();
                apalah.title();
                data.GetUserDetails();
                add.menu();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kelas tidak tersedia");
                Console.ResetColor();
                Console.WriteLine("");
                add.add();
            }
        }
        public void payment(int harga)
        {
            addreservation pay = new addreservation();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("pembayaran\n");
            Console.WriteLine("Harga : "+harga);
            Console.Write("uang yang diterima : ");
            int recive = int.Parse(Console.ReadLine());
            int total = recive -  harga;
            if (recive < harga)
            {
                Console.WriteLine("Uang anda Kurang!!");
                pay.payment(harga);
                
            }
            else
            Console.WriteLine("Kembali Rp "+total+"\n");
        }
        public void kembali()
        {
            //kembali
            @class call = new @class();
            onlyjson show = new onlyjson();
            addreservation add = new addreservation();
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1.Tambah reservasi");
            Console.WriteLine("2.Kembali ke mainmenu");
            Console.Write("Pilih : ");
            string select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    Console.Clear();
                    add.submenu();
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
                    add.kembali();
                    break;
            }

        }
    }
}
