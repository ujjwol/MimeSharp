MimeSharp
=========

MIME type handling utility for C#. It includes all mime types and extensions curated by Apache located at:
[http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types](http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types)
Includes all 600+ types and 800+ extensions defined by the Apache project.
Allows user to lookup mime type by filename, get file extensions for mime types.

## Install

### NuGet Package
```
PM> Install-Package MimeSharp
```
https://www.nuget.org/packages/MimeSharp/

Or simply download the MimeSharp.1.0.0.nupkg and use it.

### Reference the dll
Get the ```MimeSharp.dll``` from ```Release``` folder and copy to your references folder and reference in your project. Now, you're reading to use it.

### Using source files
Simply copy ```Mime.cs``` and ```ApacheMimeTypes.cs``` to your project and use as any other class.

## Usage
Example usage in the console application ```Program.cs```

### mime.Lookup(filePath)
Get the mime type associated with a file, if no mime type is found `application/octet-stream` is returned. Performs a case-insensitive lookup using the extension in `filePath` (the substring after the last '/' or '.').  E.g.

```csharp
var mime = new Mime();

mime.Lookup(@"song.ogg"));
mime.Lookup(@"picture.jpg"));
```

Output
```
audio/ogg
image/jpeg
```

### mime.DefaultType()
When no mime type is found. Default is `application/octet-stream`.

### mime.Extension(mimeType)
Get all the extension for `mimeType`. Gives you a list `List<string>` of extensions. Empty list if no mime type is found.

```csharp
var mime = new Mime();

mime.Extension("audio/ogg");
mime.Extension("image/jpeg")
mime.Extension("text/html")
```

Output
```
["oga","ogg","spx"]
["jpeg","jpg","jpe"]
["html","htm"]
```

## Adding new mime type
Even though I don't recommend adding your MIME type if you really have to do it, use the project from ```MimeSharp.FromFile``` directory and change the ```MimeTypes/mime.types``` file or even create new file and modify the source code.


## License

Based off [node-mime by broofa for Node.Js](https://github.com/broofa/node-mime)

This program is licensed under the MIT License.
```
Copyright (c) 2014 Ujjwol Lamichhane

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```


