using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;
using Aerolog.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Aerolog.Accessors
{
    public class FileAccessor : BaseMongoAccessor<File>, IFileAccessor
    {
        private readonly GridFSBucket _bucket;
        public FileAccessor(MongoContext context): base(context)
        {
            _bucket = new GridFSBucket(context.Database);

        }

        public override async Task Delete(Expression<Func<File, bool>> where)
        {
            var filesToDelete = await Get(where);
            foreach (var file in filesToDelete)
            {
                await _bucket.DeleteAsync(file.Id.ToObjectId());
            }
            await base.Delete(where);
        }

        public override async Task DeleteById(string id)
        {
            await _bucket.DeleteAsync(id.ToObjectId());
            await base.DeleteById(id);
        }

        public override async Task<IEnumerable<File>> Get(Expression<Func<File, bool>> where)
        {
            var files = await base.Get(where);
            return await LoadByteContentForFiles(files);
        }

        public override async Task<IEnumerable<File>> GetAll()
        {
            var files = await base.GetAll();
            return await LoadByteContentForFiles(files);
        }

        public override async Task<IEnumerable<File>> GetByFilter(FilterDefinition<File> filter)
        {
            var files = await base.GetByFilter(filter);
            return await LoadByteContentForFiles(files);
        }

        public override async Task<File> GetById(string id)
        {
            var file = await base.GetById(id);
            return await LoadByteContentForFile(file);
        }

        public override async Task<IEnumerable<File>> GetByIds(IEnumerable<string> ids)
        {
            var files = await base.GetByIds(ids);
            return await LoadByteContentForFiles(files);
        }

        public override async Task<File> Insert(File entity)
        {
            entity = await InsertFileContent(entity);
            await base.Insert(entity);
            return entity;
        }

        public override async Task InsertMany(IEnumerable<File> entities)
        {
            await Task.WhenAll(entities.Select(e => Insert(e)));
        }

        public override async Task<File> Save(File entity)
        {
            return await base.Save(entity);
        }

        public override async Task<File> Update(File entity)
        {
            // Clean up old file content
            await _bucket.DeleteAsync(entity.FileId.ToObjectId());

            entity = await InsertFileContent(entity);
            await base.Update(entity);
            return entity;
        }

        private async Task<IEnumerable<File>> LoadByteContentForFiles(IEnumerable<File> files)
        {
            var fileTasks = files.Select(f => LoadByteContentForFile(f));
            return await Task.WhenAll(fileTasks);
        }

        private async Task<File> LoadByteContentForFile(File file)
        {
            file.FileContent = await _bucket.DownloadAsBytesAsync(file.FileId.ToObjectId());
            return file;
        }

        private async Task<File> InsertFileContent(File file)
        {
            var fileId = await _bucket.UploadFromBytesAsync(file.FileName, file.FileContent);
            file.FileId = fileId.ToString();
            return file;
        }
    }
}
