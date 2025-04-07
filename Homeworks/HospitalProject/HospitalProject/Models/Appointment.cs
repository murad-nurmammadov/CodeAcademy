﻿using HospitalProject.Exceptions;

namespace HospitalProject.Models
{
    /*
    Appointment class
     - No
     - Doctor
     - Patient
     - StartDate
     - EndDate
    */

    internal class Appointment
    {
        // Fields
        private static int _no = 0;
        private DateTime _startDate;
        private DateTime _endDate;

        // Properties
        public int No { get; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (value < _startDate) throw new EndBeforeStartException();
            }
        }

        // Constructor
        public Appointment(string patient, string doctor, DateTime startDate, DateTime endDate)
        {
            No = ++_no;
            Patient = patient;
            Doctor = doctor;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Methods
        public override string ToString()
        {
            return $"{No}: Dr {Doctor} with {Patient} | from {StartDate} to {EndDate}";
        }
    }
}
