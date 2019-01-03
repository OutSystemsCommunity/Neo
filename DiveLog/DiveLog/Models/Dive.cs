using System;

namespace DiveLog.Models
{
    public class Dive
    {
        public string Id { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public string DPIC { get; set; }
        public string Tender { get; set; }
        public Mode Mode { get; set; }
        public string[] Divers { get; set; }
    }

    public enum Mode
    {
        SCUBA,
        SurfaceSupplied,
        Snorkel,
        Other
    }

    public enum Location
    {
        OV,
        CW7, 
        Other
    }
}