//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    abstract class Patient
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string citizenStatus { get; set; }
        public string Status { get; set; }
        public Stay Stay { get; set; }


        protected Patient(string id, string n, int a, char g, string cs, string s)
        {
            ID = id;
            Name = n;
            Age = a; 
            Gender = g;
            citizenStatus = cs;
            Status = s;
        }

        public virtual double CalculateCharges()
        {
            foreach(BedStay i in Stay.bedstayList)
            {
                if(i.bed is ClassABed)
                {
                    ((ClassABed)i.bed).CalculateCharges(ID, Age);
                }

                else if (i.bed is ClassBBed)
                {
                    ((ClassBBed)i.bed).CalculateCharges(ID, Age);
                }

                else if (i.bed is ClassCBed)
                {
                    ((ClassCBed)i.bed).CalculateCharges(ID, Age);
                }
            }
            return 0.0;
        }

         
        public override string ToString()
        {
            //return "ID: " + ID
            //    + "\tName: " + Name
            //    + "\tAge: " + Age
            //    + "\tGender: " + Gender
            //    + "\tCitizen Status: " + citizenStatus
            //    + "\tStatus: " + Status;
            ////+ "\tStay: " + Stay;

            return ID + Name + Age + Gender + citizenStatus + Status;
        }
    }
}
