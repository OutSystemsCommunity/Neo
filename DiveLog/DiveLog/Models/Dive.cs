﻿using System;

namespace DiveLog.Models
{
    public class Dive
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string DPIC { get; set; }
        public string Tender { get; set; }
        public string Mode { get; set; }
    }
}