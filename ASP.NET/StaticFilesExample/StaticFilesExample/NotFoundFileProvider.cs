using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

public class NotFoundFileProvider : IFileProvider
{
    public NotFoundFileProvider()
    {

    }

    public IDirectoryContents GetDirectoryContents(string subpath)
     => NotFoundDirectoryContents.Singleton;

    public IFileInfo GetFileInfo(string subpath)
    => new NotFoundFileInfo(subpath);

    public IChangeToken Watch(string filter)
    => NullChangeToken.Singleton;
}