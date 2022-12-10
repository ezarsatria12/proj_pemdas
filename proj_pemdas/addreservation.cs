using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace proj_pemdas
{
    internal class addreservation
    {
        private string jsonFile = @"E:\Edgar\Kuliah\Pemdas\Proyek Akhir\proj_pemdas\data.json";
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
                    data.UpdateCompany();
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
        public void UpdateCompany()
        {
            addreservation add = new addreservation();
            @class apalah = new @class();
            addreservation data = new addreservation();
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            JArray experiencesArrary = (JArray)jObject.SelectToken("data");
            Console.Write("Pilih Kelas(Id)\t: ");
            var kelasid = int.Parse(Console.ReadLine());
            if (kelasid > 3)
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
                add.UpdateCompany();

            }
            if (kelasid > 0)
            {               
                Console.Write("Pilih Kamar(No)\t: ");
                var kamarid = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");
                if (kamarid > 6)
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
                    add.UpdateCompany();
                }
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
                                exp.Add("nama", nama);
                                exp.Add("nik", nik);
                                exp.Add("nohp", nohp);
                                exp.Add("datein", datetime.ToString("dd/MM/yy"));
                                exp.Add("time", datetime.ToString("hh:mm"));

                                j["pengunjung"] = exp;
                                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                                File.WriteAllText(jsonFile, newJsonResult);
                                //Kembali
                                addreservation back = new addreservation();
                                @class call = new @class();
                                onlyjson show = new onlyjson();
                                Console.Clear();
                                call.title();
                                show.GetUserDetails();
                                call.saved();
                                back.kembali();


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
