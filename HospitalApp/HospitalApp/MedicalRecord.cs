//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    public class MedicalRecord
    {
        public string diagnosis { get; set; }
        public double temperature { get; set; }
        public DateTime datetimeEntered { get; set; }

        public MedicalRecord(string d, double t, DateTime dt)
        {
            diagnosis = d;
            temperature = t;
            datetimeEntered = dt;
        }

        public override string ToString()
        {
            return base.ToString()
                + "\tDiagnosis: " + diagnosis
                + "\tTemperature: " + temperature
                + "\tDateTime Entered: " + datetimeEntered;
        }
    }
}
