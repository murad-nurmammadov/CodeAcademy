using HospitalProject.Exceptions;

namespace HospitalProject.Models
{
    // TODO: Hospital class – GetWeeklyAppointments()

    /*
    Hospital class
     - Appointments
     - AddAppointment()
     - EndAppointment() - no deyeri gelir ve hemin appointmentin
                          enddate-ini qeyd edir
     - GetAppointment() - no deyeri qebul ve hemin appointmenti
                          return edir
     - GetAllAppointments()
     - GetWeeklyAppointments()
     - GetTodaysAppointments()
     - GetAllContinuingAppointments()
    */

    internal class Hospital
    {
        // Fields
        private Appointment[] _appointments = [];

        // Properties
        public Appointment[] Appointments
        {
            get => _appointments;
            set { _appointments = value; }
        }

        // Methods
        public void AddAppointment(Appointment newAppointment)
        {
            // Check if new appointment doesn't overlap with any of the appointments of the doctor
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.Doctor == newAppointment.Doctor)
                {
                    if ((appointment.StartDate < newAppointment.StartDate && newAppointment.StartDate < appointment.EndDate)
                    || (appointment.StartDate < newAppointment.EndDate && newAppointment.EndDate < appointment.EndDate)
                    || (newAppointment.StartDate < appointment.StartDate && appointment.EndDate < newAppointment.EndDate))
                    {
                        throw new AppointmentOverlapException();
                    }
                }
            }

            // Add appointment
            Array.Resize(ref _appointments, Appointments.Length + 1);
            Appointments[^1] = newAppointment;
        }

        public void EndAppointment(int no)
        {
            // Check if there is an appointment with this No
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.No == no)
                {
                    // If appointment has already started, set end time to now.
                    if (appointment.StartDate < DateTime.Now)
                    {
                        appointment.EndDate = DateTime.Now;
                    }
                    // Otherwise, equalize start and end dates.
                    else appointment.EndDate = appointment.StartDate;

                    return;
                }
            }

            // If not found
            throw new AppointmentNotFoundException();
        }

        public Appointment GetAppointment(int no)
        {
            // Check if there is an appointment with this No
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.No == no) { return appointment; }
            }

            // If not found
            throw new AppointmentNotFoundException();
        }

        public void GetAllAppointments()
        {
            foreach (Appointment appointment in Appointments)
            {
                Console.WriteLine(appointment);
            }
        }

        public void GetWeeklyAppointments()
        {
            foreach (Appointment appointment in Appointments)
            {
                // TODO
            }
        }

        public void GetTodaysAppointments()
        {
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.StartDate.Date == DateTime.Now.Date)
                {
                    Console.WriteLine(appointment);
                }
            }
        }

        public void GetAllOngoingAppointments()
        {
            foreach (Appointment appointment in Appointments)
            {
                if ((appointment.StartDate <= DateTime.Now)
                    && (DateTime.Now < appointment.EndDate))
                {
                    Console.WriteLine(appointment);
                }
            }
        }
    }
}
