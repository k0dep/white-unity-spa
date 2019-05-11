using System;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace WhiteUnitySpa.Common
{
    public class InMemoryFileProvider : IFileProvider
    {
        private class InMemoryFile : IFileInfo
        {
            private Stream _s;
            public InMemoryFile(Stream s) => _s = s;
            public Stream CreateReadStream() => _s;
            public bool Exists { get; } = true;
            public long Length => _s.Length;
            public string PhysicalPath { get; } = string.Empty;
            public string Name { get; } = string.Empty;
            public DateTimeOffset LastModified { get; } = DateTimeOffset.UtcNow;
            public bool IsDirectory { get; } = false;
        }

        private readonly IFileInfo _fileInfo;
        public InMemoryFileProvider(Stream s) => _fileInfo = new InMemoryFile(s);
        public IFileInfo GetFileInfo(string _) => _fileInfo;
        public IDirectoryContents GetDirectoryContents(string _) => null;
        public IChangeToken Watch(string _) => NullChangeToken.Singleton;

        IChangeToken IFileProvider.Watch(string filter)
        {
            throw new NotImplementedException();
        }
    }
}