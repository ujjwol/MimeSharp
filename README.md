MimeSharp
=========

MIME type handling utility for C#. It includes all mime types and extensions curated by Apache located at:
[http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types](http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types)
Allows user to lookup mime type by filename, get file extensions for mime types.

## Install

Install simply by cloning MimeSharp and copy ```MimeSharp.cs``` and ```MimeTypes``` directory to your project directory

## Usage
Example usage in the console application ```Program.cs```

### MimeSharp.Lookup(filePath)
Get the mime type associated with a file, if no mime type is found `application/octet-stream` is returned. Performs a case-insensitive lookup using the extension in `filePath` (the substring after the last '/' or '.').  E.g.

```csharp
var MimeSharp = new MimeSharp();

MimeSharp.Lookup(@"song.ogg"));
MimeSharp.Lookup(@"picture.jpg"));
```

Output
```
audio/ogg
image/jpeg
```

### MimeSharp.DefaultType()
When no mime type is found. Default is `application/octet-stream`.

### MimeSharp.Extension(mimeType)
Get all the extension for `mimeType`. Gives you a list `List<string>` of extensions. Empty list if no mime type is found.

```csharp
var MimeSharp = new MimeSharp();

MimeSharp.Extension("audio/ogg");
MimeSharp.Extension("image/jpeg")
MimeSharp.Extension("text/html")
```

Output
```
["oga","ogg","spx"]
["jpeg","jpg","jpe"]
["html","htm"]
```


