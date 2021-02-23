using System;
using System.Collections.Generic;
using System.Text;

namespace Aerolog.Core
{
    public interface IHasUploadStatus
    {
        UploadStatusTypes UploadStatus { get; set; }
    }
}
