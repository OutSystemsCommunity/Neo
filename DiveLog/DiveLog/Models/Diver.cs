using System;

namespace DiveLog.Models
{
    public class Diver
    {
        public int Id { get; set; }
        public string Name { get; set; } //TODO FirstName LastName? so we can sort them either way
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public int StartPSI { get; set; }
        public int EndPSI { get; set; }
        public int TankNumber { get; set; }
        public int ComputerNumber { get; set; }
        public bool IsStaff { get; set; }
        //other flags? certifications / qualifications?
        public string Note { get; set; }
    }
}
