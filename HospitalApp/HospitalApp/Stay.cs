//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
using System.Collections.Generic;

namespace HospitalApp
{
    class Stay
    {
        public DateTime admittedDate { get; set; }
        //public DateTime? dischargedDate { get; set; }
        public bool isPaid { get; set; }
        public List<MedicalRecord> medicalRecordList{ get; set; } = new List<MedicalRecord>();
        public List<BedStay> bedstayList { get; set; } = new List<BedStay>();
        public Patient Patient { get; set; }

        public Stay(DateTime a, Patient p)
        {
            admittedDate = a;
            Patient = p;
        }

        public void AddMedicalRecord(MedicalRecord m)
        {
            medicalRecordList.Add(m);
        }

        
        public void AddBedStay(BedStay b)
        {
            bedstayList.Add(b);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
