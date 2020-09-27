using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Accessors;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public class FileEngine : IFileEngine
    {
        private readonly IFileAccessor _fileAccessor;
        public FileEngine(IFileAccessor fileAccessor)
        {
            _fileAccessor = fileAccessor;
        }
        public async Task<File> GetById(string id)
        {
            return await _fileAccessor.GetById(id);
        }
    }
}
