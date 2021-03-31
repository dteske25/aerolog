using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aerolog.Uploader
{
    public interface ILoader
    {
        Task Populate();
    }
}
