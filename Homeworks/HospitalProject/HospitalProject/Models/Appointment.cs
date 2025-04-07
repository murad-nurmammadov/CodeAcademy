using HospitalProject.Exceptions;

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
        private string _doctor;
        private string _patient;
        private DateTime _startDate;
        private DateTime _endDate;

        // Properties
        public int No { get; }
        public string Doctor
        {
            get => _doctor;
            set
            {
                if (value == "")
                    throw new ArgumentException("Doctor's name cannot be empty!");
                _doctor = value;
            }
        }
        public string Patient
        {
            get => _patient;
            set
            {
                if (value == "")
                    throw new ArgumentException("Patient's name cannot be empty!");
                _patient = value;
            }
        }
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
                if (value < _startDate)
                    throw new EndBeforeStartException();
                _endDate = value;
            }
        }
        public bool IsCancelled { get; set; } = false;

        // Constructor
        public Appointment(string doctor, string patient, DateTime startDate, DateTime endDate)
        {
            No = ++_no;
            Doctor = doctor;
            Patient = patient;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Methods
        public override string ToString()
        {
            string text = $"{No}: Dr {Doctor} with {Patient} | from {StartDate} to {EndDate}";
            return IsCancelled ? text + " | CANCELLED" : text;
        }
    }
}
