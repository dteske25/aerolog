using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Aerolog.Web.Params
{
    public class CreateSeriesParams
    {
        public string SeriesName { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
