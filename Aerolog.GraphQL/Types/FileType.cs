using Aerolog.Core;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class FileType: ObjectGraphType<File>
    {
        public FileType()
        {
            Name = "File";

            Field(f => f.Id);
            Field(f => f.ContentType);
            Field(f => f.ContentDisposition);
            Field(f => f.FileId);
            Field(f => f.FileName);
        }
    }
}