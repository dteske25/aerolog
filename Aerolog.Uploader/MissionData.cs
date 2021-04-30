using System;
using System.Collections.Generic;
using System.Text;
using Aerolog.Core;

namespace Aerolog.Uploader
{
    public class MissionData
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string DataPath { get; set; }
        public DateTime MissionStart { get; set; }
        public Dictionary<string, string> Speakers { get; set; }

    }
}
