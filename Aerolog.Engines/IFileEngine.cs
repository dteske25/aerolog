using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public interface IFileEngine
    {
        Task<File> GetById(string id);
    }
}
