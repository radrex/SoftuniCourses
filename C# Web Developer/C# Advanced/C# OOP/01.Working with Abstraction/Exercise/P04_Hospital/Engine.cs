namespace P04_Hospital
{
    using P04_Hospital.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        //---------------- Fields --------------------
        private Hospital hospital;

        //-------------- Constructors ----------------
        public Engine()
        {
            this.hospital = new Hospital();
        }

        //------------- Public Methods ---------------
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Output")
                {
                    break;
                }

                string[] tokens = command.Split();
                string departmentName = tokens[0];
                string doctorFirstName = tokens[1];
                string doctorLastName = tokens[2];
                string patientName = tokens[3];

                Department department = this.hospital.Departments.FirstOrDefault(d => d.Name == departmentName);
                if (department == null)
                {
                    department = new Department(departmentName);
                    Doctor doctor = new Doctor(doctorFirstName, doctorLastName);
                    Patient patient = new Patient(patientName);

                    department.AddDoctor(doctor);

                    doctor.AddPatient(patient);
                    department.AddPatient(patient);

                    this.hospital.AddDepartment(department);
                }
                else
                {
                    Doctor doctor = department.Doctors.FirstOrDefault(d => d.FirstName == doctorFirstName && d.LastName == d.LastName);
                    Patient patient = new Patient(patientName);
                    if (doctor == null)
                    {
                        doctor = new Doctor(doctorFirstName, doctorLastName);
                    }

                    department.AddDoctor(doctor);

                    doctor.AddPatient(patient);
                    department.AddPatient(patient);
                }
            }

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Department selectedDepartment = this.hospital.Departments.FirstOrDefault(d => d.Name == commands[0]);

            if (commands.Length == 1)
            {
                if (selectedDepartment != null)
                {
                    foreach (Room room in selectedDepartment.Rooms)
                    {
                        foreach (Bed bed in room.Beds.Where(b => b.IsOccupied))
                        {
                            Console.WriteLine(bed.Patient.Name);
                        }
                    }
                }
            }
            else if (commands.Length == 2)
            {
                if (selectedDepartment != null && int.TryParse(commands[1], out int roomNumber))
                {
                    List<string> patients = new List<string>();

                    Room selectedRoom = selectedDepartment.Rooms[roomNumber - 1];
                    foreach (Bed bed in selectedRoom.Beds.Where(b => b.IsOccupied))
                    {
                        patients.Add(bed.Patient.Name);
                    }

                    Console.WriteLine(String.Join(Environment.NewLine, patients.OrderBy(p => p)));
                }
                else
                {
                    List<string> patients = new List<string>();

                    foreach (Department department in this.hospital.Departments.Where(d => d.Doctors.Count != 0))
                    {
                        Doctor selectedDoctor = department.Doctors.FirstOrDefault(d => d.FirstName == commands[0] && d.LastName == commands[1]);

                        if (selectedDoctor != null)
                        {
                            selectedDoctor.Patients.ToList().ForEach(p => patients.Add(p.Name));
                        }
                    }

                    Console.WriteLine(String.Join(Environment.NewLine, patients.OrderBy(p => p)));
                }
            }
        }
    }
}
