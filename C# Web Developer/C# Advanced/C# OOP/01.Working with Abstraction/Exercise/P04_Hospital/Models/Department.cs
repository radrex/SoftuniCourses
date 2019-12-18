namespace P04_Hospital.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Department
    {
        //---------------- Fields --------------------
        private Room[] rooms;
        private List<Doctor> doctors;
        private List<Patient> patients;
             
        //-------------- Constructors ----------------
        public Department(string name)
        {
            this.Name = name;
        
            this.rooms = new Room[20];
            this.InitializeRooms();
            
            this.doctors = new List<Doctor>();

            this.patients = new List<Patient>();
        }

        //--------------- Properties -----------------
        public string Name { get; private set; }
        public Room[] Rooms => this.rooms;
        public IReadOnlyCollection<Doctor> Doctors => this.doctors.AsReadOnly();

        //------------- Public Methods ---------------
        public void AddDoctor(Doctor doctor)
        {
            this.doctors.Add(doctor);
        }

        public void AddPatient(Patient patient)
        {
            foreach (Room room in this.Rooms)
            {
                Bed freeBed = room.Beds.FirstOrDefault(b => !b.IsOccupied);
                if (freeBed != null)
                {
                    freeBed.Occupy(patient);
                    this.patients.Add(patient);
                    break;
                }
            }
        }

        //------------- Private Methods --------------
        private void InitializeRooms()
        {
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                this.rooms[i] = new Room();
            }
        }
    }
}
