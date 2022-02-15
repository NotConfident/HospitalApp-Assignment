//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HospitalApp
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            List<Patient> patientList = new List<Patient>();
            List<Bed> bedList = new List<Bed>();

            ShowCSV(patientList);
            BedCSV(bedList);

            while (true)
            {

                Console.WriteLine("MENU");
                Console.WriteLine("====");
                Console.WriteLine("1. View all patients");
                Console.WriteLine("2. View all beds");
                Console.WriteLine("3. Register patients");
                Console.WriteLine("4. Add new bed");
                Console.WriteLine("5. Register hospital stay");
                Console.WriteLine("6. Retrieve patient details");
                Console.WriteLine("7. Add medical record entry");
                Console.WriteLine("8. View medical records");
                Console.WriteLine("9. Transfer patient to another bed");
                Console.WriteLine("10. Discharge and payment");
                Console.WriteLine("11. Display curriencies exchange rate");
                Console.WriteLine("12. Display PM 2.5 information");
                Console.WriteLine("0.  Exit");
                Console.WriteLine("");

                Console.Write("Enter your option: ");

                int input;
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");


                if (input == 1)
                {
                    Console.WriteLine("Option 1. View All Patients");

                    Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", "Name", "ID No", "Age", "Gender", "Citizenship", "Status");

                    foreach (Patient i in patientList)
                    {
                        Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", i.Name, i.ID, i.Age, i.Gender, i.citizenStatus, i.Status);
                    }

                    Console.WriteLine("");
                }

                if (input == 3)
                {
                    Console.WriteLine("Option 3. Register Patient");

                    Console.Write("Enter Patient Name: ");
                    string Name = Console.ReadLine();

                    Console.Write("Enter Patient ID Number: ");

                    string ID = Console.ReadLine();
                    int result = 0;

                    if (int.TryParse(ID, out result))
                    {
                    }
                    else
                    {

                        Console.Write("Enter Patient Age: ");
                        int Age = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Patient Gender: ");
                        char Gender = Convert.ToChar(Console.ReadLine());

                        Console.Write("Enter Patient Citizenship Status: ");
                        string Citizen = Console.ReadLine();

                        if (Age <= 12 && Citizen == "SC" || Citizen == "sc")
                        {
                            Console.Write("Enter Patient's CDA Balance: ");
                            double CDABalance = Convert.ToDouble(Console.ReadLine());
                            Patient x = new Child(ID, Name, Age, Gender, Citizen, "Registered", CDABalance);
                            patientList.Add(x);

                            if (x is Child)
                            {
                                using (StreamWriter file = new System.IO.StreamWriter(@"/Users/yongtenggg/Desktop/Poly/C#/prg2_p01_team5/Assignment/HospitalApp/HospitalApp/HospitalApp/patients.csv", true))
                                {
                                    file.Write(string.Format("\n{0},{1},{2},{3},{4},{5}", x.Name, x.ID, x.Age, x.Gender, x.citizenStatus, ((Child)x).cdaBalance));
                                }

                                Console.WriteLine("{0} is registered successfully.", x.Name);
                                Console.WriteLine("");
                            }

                        }

                        else if (Age <= 12 && Citizen != "SC" || Citizen == "sc")
                        {
                            double CDABalance = 0.0;
                            Patient x = new Child(ID, Name, Age, Gender, Citizen, "Registered", CDABalance);
                            patientList.Add(x);

                            if (x is Child)
                            {
                                using (StreamWriter file = new System.IO.StreamWriter(@"/Users/yongtenggg/Desktop/Poly/C#/prg2_p01_team5/Assignment/HospitalApp/HospitalApp/HospitalApp/patients.csv", true))
                                {
                                    file.Write(string.Format("\n{0},{1},{2},{3},{4},{5}", x.Name, x.ID, x.Age, x.Gender, x.citizenStatus, ((Child)x).cdaBalance));
                                }

                                Console.WriteLine("{0} is registered successfully.", x.Name);
                                Console.WriteLine("");
                            }
                        }

                        else if (Age >= 13 && Age <= 64 && Citizen == "SC" || Citizen == "PR" || Citizen == "sc" || Citizen == "pr")
                        {
                            Console.Write("Enter Patient's Medisave Balance: ");
                            double MedisaveBalance = Convert.ToDouble(Console.ReadLine());
                            Patient x = new Adult(ID, Name, Age, Gender, Citizen, "Registered", MedisaveBalance);
                            patientList.Add(x);

                            if (x is Adult)
                            {
                                using (StreamWriter file = new System.IO.StreamWriter(@"/Users/yongtenggg/Desktop/Poly/C#/prg2_p01_team5/Assignment/HospitalApp/HospitalApp/HospitalApp/patients.csv", true))
                                {
                                    file.Write(string.Format("\n{0},{1},{2},{3},{4},{5}", x.Name, x.ID, x.Age, x.Gender, x.citizenStatus, ((Adult)x).medisaveBalance));
                                }

                                Console.WriteLine("{0} is registered successfully.", x.Name);
                                Console.WriteLine("");
                            }
                        }

                        else if (Age >= 13 && Age <= 64 && Citizen != "SC" || Citizen != "PR" || Citizen == "sc" || Citizen == "pr")
                        {
                            double MedisaveBalance = 0.0;
                            Patient x = new Adult(ID, Name, Age, Gender, Citizen, "Registered", MedisaveBalance);
                            patientList.Add(x);

                            if (x is Adult)
                            {
                                using (StreamWriter file = new System.IO.StreamWriter(@"/Users/yongtenggg/Desktop/Poly/C#/prg2_p01_team5/Assignment/HospitalApp/HospitalApp/HospitalApp/patients.csv", true))
                                {
                                    file.Write(string.Format("\n{0},{1},{2},{3},{4},{5}", x.Name, x.ID, x.Age, x.Gender, x.citizenStatus, ((Adult)x).medisaveBalance));
                                }

                                Console.WriteLine("{0} is registered successfully.", x.Name);
                                Console.WriteLine("");
                            }
                        }

                        else if (Age > 65)
                        {
                            Patient x = new Senior(ID, Name, Age, Gender, Citizen, "Registered");
                            patientList.Add(x);

                            if (x is Senior)
                            {
                                using (StreamWriter file = new System.IO.StreamWriter(@"/Users/yongtenggg/Desktop/Poly/C#/prg2_p01_team5/Assignment/HospitalApp/HospitalApp/HospitalApp/patients.csv", true))
                                {
                                    file.Write(string.Format("\n{0},{1},{2},{3},{4}", x.Name, x.ID, x.Age, x.Gender, x.citizenStatus));
                                }

                                Console.WriteLine("{0} is registered successfully.", x.Name);
                                Console.WriteLine("");
                            }
                        }
                    }
                    Console.WriteLine("Please enter a valid Patient ID. ");
                }

                if (input == 5)
                {
                    Console.WriteLine("Option 5. Register A Hospital Stay");

                    Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", "Name", "ID No", "Age", "Gender", "Citizenship", "Status");

                    foreach (Patient i in patientList)
                    {
                        if (i.Status == "Admitted")
                        {
                            continue;
                        }
                        else if (i.Status != "Admitted")
                        {
                            Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", i.Name, i.ID, i.Age, i.Gender, i.citizenStatus, i.Status);
                        }
                    }

                    Console.WriteLine("");
                    Console.Write("Enter Patient ID Number: ");

                    string patientID = Console.ReadLine();
                    int result = 0;

                    if (int.TryParse(patientID, out result))
                    {
                        Console.WriteLine("Please enter a valid Patient ID. ");
                    }
                    else
                    {
                        Console.WriteLine("");

                        Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", "No", "Type", "Ward No", "Bed No", "Daily Rate", "Available");

                        int counter = 1;
                        foreach (Bed i in bedList)
                        {
                            string temp = "";
                            if (i is ClassABed)
                            {
                                temp += "A";
                            }

                            else if (i is ClassBBed)
                            {
                                temp += "B";
                            }

                            else if (i is ClassCBed)
                            {
                                temp += "C";
                            }
                            Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", counter, temp, i.WardNo, i.BedNo, i.DailyRate, i.Available);
                            counter++;
                        }

                        Console.WriteLine("");

                        Console.Write("Select bed to transfer: ");
                        string value = Console.ReadLine();
                        int bed;
                        if (int.TryParse(value, out bed))
                        {
                            Console.Write("Enter date of admission (DD/MM/YYYY): ");

                            string inputString = Console.ReadLine();
                            DateTime date;
                            if (DateTime.TryParse(inputString, out date))
                            {
                                String.Format("{0:d/MM/yyyy}", date);
                                //Console.WriteLine(date);
                                if (bed > 0 && bed < 5)
                                {
                                    Console.Write("Any accompanying guest? (Additional $100 per day) [Y/N]: ");
                                    string guest = Console.ReadLine();

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && guest == "Y" || guest == "y")
                                        {
                                            Bed pBed = bedList[bed - 1];
                                            Stay s = new Stay(date, p);
                                            BedStay b = new BedStay(date, pBed);
                                            s.AddBedStay(b);
                                            p.Stay = s;
                                            p.Status = "Admitted";
                                            Console.WriteLine("");
                                            Console.WriteLine("Stay registration successfull!");
                                            Console.WriteLine("");
                                        }

                                        else if (p.ID == patientID && guest == "N" || guest == "n")
                                        {
                                            Bed pBed = bedList[bed - 1];
                                            Stay s = new Stay(date, p);
                                            BedStay b = new BedStay(date, pBed);
                                            s.AddBedStay(b);
                                            p.Stay = s;
                                            p.Status = "Admitted";
                                            Console.WriteLine("");
                                            Console.WriteLine("Stay registration successfull!");
                                            Console.WriteLine("");
                                        }
                                    }
                                }

                                else if (bed > 4 && bed < 8)
                                {
                                    Console.Write("Upgrade to an Air-Conditioned room? (Additional $50 per week)? [Y/N] : ");
                                    string ac = Console.ReadLine();

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && ac == "Y" || ac == "y")
                                        {
                                            Bed pBed = bedList[bed - 1];
                                            Stay s = new Stay(date, p);
                                            BedStay b = new BedStay(date, pBed);
                                            s.AddBedStay(b);
                                            p.Stay = s;
                                            p.Status = "Admitted";
                                            Console.WriteLine("");
                                            Console.WriteLine("Stay registration successfull!");
                                            Console.WriteLine("");
                                        }

                                        else if (p.ID == patientID && ac == "N" || ac == "n")
                                        {
                                            Bed pBed = bedList[bed - 1];
                                            Stay s = new Stay(date, p);
                                            BedStay b = new BedStay(date, pBed);
                                            s.AddBedStay(b);
                                            p.Stay = s;
                                            p.Status = "Admitted";
                                            Console.WriteLine("");
                                            Console.WriteLine("Stay registration successfull!");
                                            Console.WriteLine("");
                                        }
                                    }
                                }

                                else if (bed > 7 && bed < 11)
                                {
                                    Console.Write("Any portable TV required (Additional $30 one time cost)? [Y/N] : ");
                                    string tv = Console.ReadLine();

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && tv == "Y" || tv == "y")
                                        {
                                            Bed pBed = bedList[bed - 1];
                                            Stay s = new Stay(date, p);
                                            BedStay b = new BedStay(date, pBed);
                                            s.AddBedStay(b);
                                            p.Stay = s;
                                            p.Status = "Admitted";
                                            Console.WriteLine("");
                                            Console.WriteLine("Stay registration successfull!");
                                            Console.WriteLine("");
                                        }

                                        else if (p.ID == patientID && tv == "N" || tv == "n")
                                        {
                                            Bed pBed = bedList[bed - 1];
                                            Stay s = new Stay(date, p);
                                            BedStay b = new BedStay(date, pBed);
                                            s.AddBedStay(b);
                                            p.Stay = s;
                                            p.Status = "Admitted";
                                            Console.WriteLine("");
                                            Console.WriteLine("Stay registration successfull!");
                                            Console.WriteLine("");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Date!");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid input");
                            Console.WriteLine("");
                        }

                        //DateTime discharge = default;
                        //DateTime endbedStay = default;
                    }
                }

                if (input == 6)
                {

                    Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", "Name", "ID No", "Age", "Gender", "Citizenship", "Status");

                    foreach (Patient i in patientList)
                    {
                        Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", i.Name, i.ID, i.Age, i.Gender, i.citizenStatus, i.Status);
                    }

                    Console.WriteLine("");

                    Console.Write("Enter Patient ID Number: ");
                    Console.WriteLine("");

                    string patientID = Console.ReadLine();
                    int result = 0;

                    if (int.TryParse(patientID, out result))
                    {
                        Console.WriteLine("Please enter a valid Patient ID. ");
                    }
                    else
                    {
                        foreach (Patient i in patientList)
                        {
                            if (i.ID == patientID)
                            {
                                Console.WriteLine("Name of Patient: " + i.Name);
                                Console.WriteLine("ID Number: " + i.ID);
                                Console.WriteLine("Citizenship Status: " + i.citizenStatus);
                                Console.WriteLine("Gender: " + i.Gender);
                                Console.WriteLine("Status: " + i.Status);

                                Console.WriteLine("");

                                Console.WriteLine("Admission Date: " + i.Stay.admittedDate);

                                if (i.Stay.isPaid == true)
                                {
                                    Console.WriteLine("Payment Status: Paid");
                                }

                                else
                                {
                                    Console.WriteLine("Payment Status: Unpaid");
                                }

                                Console.WriteLine("====");


                                foreach (BedStay x in i.Stay.bedstayList)
                                {

                                    string temp = "";
                                    if (x.bed is ClassABed)
                                    {
                                        temp += "A";
                                    }

                                    else if (x.bed is ClassBBed)
                                    {
                                        temp += "B";
                                    }

                                    else if (x.bed is ClassCBed)
                                    {
                                        temp += "C";
                                    }


                                    Console.WriteLine("Ward Number: " + x.bed.WardNo);
                                    Console.WriteLine("Bed Number: " + x.bed.BedNo);
                                    Console.WriteLine("Ward Class: " + temp);
                                    Console.WriteLine("Start of Bed Stay: " + x.startBedstay);
                                    Console.WriteLine("End of Bed Stay: " + x.endBedstay);
                                    Console.WriteLine("");

                                }
                            }
                        }
                    }
                }

                if (input == 9)
                {
                    Console.WriteLine("Option 9. Transfer Patient to another bed");

                    foreach (Patient i in patientList)
                    {
                        if (i.Status == "Admitted")
                        {
                            Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", i.Name, i.ID, i.Age, i.Gender, i.citizenStatus, i.Status);

                        }
                    }

                    Console.WriteLine("");

                    Console.Write("Enter Patient ID Number: ");

                    string patientID = Console.ReadLine();
                    int result = 0;

                    if (int.TryParse(patientID, out result))
                    {
                        Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", "No", "Type", "Ward No", "Bed No", "Daily Rate", "Available");

                        int counter = 1;
                        foreach (Bed i in bedList)
                        {
                            string temp = "";
                            if (i is ClassABed)
                            {
                                temp += "A";
                            }

                            else if (i is ClassBBed)
                            {
                                temp += "B";
                            }

                            else if (i is ClassCBed)
                            {
                                temp += "C";
                            }
                            Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -15}", counter, temp, i.WardNo, i.BedNo, i.DailyRate, i.Available);
                            counter++;
                        }

                        Console.WriteLine("");

                        Console.Write("Select bed to transfer: ");
                        string value = Console.ReadLine();
                        int bed;
                        if (int.TryParse(value, out bed))
                        {
                            Console.Write("Enter date of transfer (DD/MM/YYYY): ");

                            string inputString = Console.ReadLine();
                            DateTime date;
                            if (DateTime.TryParse(inputString, out date))
                            {
                                String.Format("{0:d/MM/yyyy}", date);
                                Console.WriteLine(date);

                                if (bed > 0 && bed < 5)
                                {
                                    Console.Write("Any accompanying guest? (Additional $100 per day) [Y/N]: ");
                                    string guest = Console.ReadLine();

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && guest == "Y" || guest == "y")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                i.endBedstay = date;
                                            }

                                            Console.WriteLine("");
                                        }

                                        else if (p.ID == patientID && guest == "N" || guest == "n")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                i.endBedstay = date;
                                            }

                                            Console.WriteLine("");
                                        }
                                    }

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && guest == "Y" || guest == "y")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                Bed pbed = bedList[bed - 1];
                                                Stay s1 = new Stay(date, p);
                                                BedStay b1 = new BedStay(date, pbed);
                                                s1.AddBedStay(b1);
                                                p.Stay = s1;
                                            }
                                        }

                                        else if (p.ID == patientID && guest == "N" || guest == "n")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                Bed pbed = bedList[bed - 1];
                                                Stay s1 = new Stay(date, p);
                                                BedStay b1 = new BedStay(date, pbed);
                                                s1.AddBedStay(b1);
                                                p.Stay = s1;
                                            }
                                        }
                                    }
                                }

                                else if (bed > 4 && bed < 8)
                                {
                                    Console.Write("Upgrade to an Air-Conditioned room? (Additional $50 per week)? [Y/N] :");
                                    string ac = Console.ReadLine();

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && ac == "Y" || ac == "y")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                i.endBedstay = date;
                                            }

                                            Console.WriteLine("");
                                        }
                                        else if (p.ID == patientID && ac == "N" || ac == "n")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                i.endBedstay = date;
                                            }

                                            Console.WriteLine("");
                                        }
                                    }

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && ac == "Y" || ac == "y")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                Bed pbed = bedList[bed - 1];
                                                Stay s1 = new Stay(date, p);
                                                BedStay b1 = new BedStay(date, pbed);
                                                s1.AddBedStay(b1);
                                                p.Stay = s1;
                                            }
                                        }

                                        else if (p.ID == patientID && ac == "N" || ac == "n")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                Bed pbed = bedList[bed - 1];
                                                Stay s1 = new Stay(date, p);
                                                BedStay b1 = new BedStay(date, pbed);
                                                s1.AddBedStay(b1);
                                                p.Stay = s1;
                                            }
                                        }
                                    }
                                }
                                else if (bed > 7 && bed < 11)
                                {
                                    Console.Write("Any portable TV required (Additional $30 one time cost)? [Y/N] : ");
                                    string tv = Console.ReadLine();

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && tv == "Y" || tv == "y")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                i.endBedstay = date;
                                            }

                                            Console.WriteLine("");
                                        }

                                        else if(p.ID == patientID && tv == "N" || tv == "n")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                i.endBedstay = date;
                                            }

                                            Console.WriteLine("");
                                        }
                                    }

                                    foreach (Patient p in patientList)
                                    {
                                        if (p.ID == patientID && tv == "Y" || tv == "y")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                Bed pbed = bedList[bed - 1];
                                                Stay s1 = new Stay(date, p);
                                                BedStay b1 = new BedStay(date, pbed);
                                                s1.AddBedStay(b1);
                                                p.Stay = s1;
                                            }
                                        }
                                        else if (p.ID == patientID && tv == "N" || tv == "n")
                                        {
                                            foreach (BedStay i in p.Stay.bedstayList)
                                            {
                                                Bed pbed = bedList[bed - 1];
                                                Stay s1 = new Stay(date, p);
                                                BedStay b1 = new BedStay(date, pbed);
                                                s1.AddBedStay(b1);
                                                p.Stay = s1;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Date!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid input");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Patient ID. ");
                    }

                }

                if (input == 11)
                {
                    Rates i = null;
                    List<Rates> rList;

                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://api.exchangeratesapi.io");
                        Task<HttpResponseMessage> responseTask = client.GetAsync("/latest");
                        responseTask.Wait();
                        HttpResponseMessage result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {

                            Task<string> readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            string data = readTask.Result;
                            rList = JsonConvert.DeserializeObject<List<Rates>>(data).ToList();

                            foreach (Rates r in rList)
                            {
                                r.ratesList.Add(r);
                                Console.WriteLine(r);
                            }
                        }


                    }
                }

                if (input == 0)
                {
                    break;
                }

                if(input > 12)
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }
        }

        static void ShowCSV(List<Patient> patientList)
        {
            string[] patients = File.ReadAllLines("patients.csv");

            for (int i = 1; i < patients.Length; i++)
            {
                string[] data = patients[i].Split(',');

                if (Convert.ToInt32(data[2]) <= 12 && data.Length == 5)
                {
                    Patient p = new Child(data[1], data[0], Convert.ToInt32(data[2]), Convert.ToChar(data[3]), data[4], "Registered", 0.0);
                    if (patientList.Contains(p))
                    {
                        Console.WriteLine("Duplicate");
                    }
                    else
                    {
                        patientList.Add(p);
                    }
                }

                else if (Convert.ToInt32(data[2]) <= 12 && data.Length == 6)
                {
                    Patient p = new Child(data[1], data[0], Convert.ToInt32(data[2]), Convert.ToChar(data[3]), data[4], "Registered", Convert.ToDouble(data[5]));
                    if (patientList.Contains(p))
                    {
                        Console.WriteLine("Duplicate");
                    }
                    else
                    {
                        patientList.Add(p);
                    }
                }

                else if (Convert.ToInt32(data[2]) > 12 && Convert.ToInt32(data[2]) < 65 && data.Length == 5)
                {
                    Patient p = new Adult(data[1], data[0], Convert.ToInt32(data[2]), Convert.ToChar(data[3]), data[4], "Registered", 0.0);
                    if (patientList.Contains(p))
                    {
                        Console.WriteLine("Duplicate");
                    }
                    else
                    {
                        patientList.Add(p);
                    }
                }

                else if (Convert.ToInt32(data[2]) > 12 && Convert.ToInt32(data[2]) < 65 && data.Length == 6)
                {
                    Patient p = new Adult(data[1], data[0], Convert.ToInt32(data[2]), Convert.ToChar(data[3]), data[4], "Registered", Convert.ToDouble(data[5]));
                    if (patientList.Contains(p))
                    {
                        Console.WriteLine("Duplicate");
                    }
                    else
                    {
                        patientList.Add(p);
                    }
                }

                else if (Convert.ToInt32(data[2]) >= 65 && data.Length == 5)
                {
                    Patient p = new Senior(data[1], data[0], Convert.ToInt32(data[2]), Convert.ToChar(data[3]), data[4], "Registered");
                    if (patientList.Contains(p))
                    {
                        Console.WriteLine("Duplicate");
                    }
                    else
                    {
                        patientList.Add(p);
                    }
                }
            }
        }

        static void BedCSV(List<Bed> bedList)
        {
            string[] beds = File.ReadAllLines("beds.csv");

            for (int i = 1; i < beds.Length; i++)
            {
                string[] bedInfo = beds[i].Split(',');

                if (bedInfo[0] == "A")
                {
                    Bed b = new ClassABed(Convert.ToInt32(bedInfo[1]), Convert.ToInt32(bedInfo[2]), Convert.ToDouble(bedInfo[4]), true);
                    bedList.Add(b);
                }
                else if (bedInfo[0] == "B")
                {
                    Bed b = new ClassBBed(Convert.ToInt32(bedInfo[1]), Convert.ToInt32(bedInfo[2]), Convert.ToDouble(bedInfo[4]), true);
                    bedList.Add(b);
                }
                else if (bedInfo[0] == "C")
                {
                    Bed b = new ClassCBed(Convert.ToInt32(bedInfo[1]), Convert.ToInt32(bedInfo[2]), Convert.ToDouble(bedInfo[4]), true);
                    bedList.Add(b);
                }
            }
        }
    }
}
