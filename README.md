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

## Install

Based off [node-mime by broofa for Node.Js](https://github.com/broofa/node-mime)

Licensed under MIT License
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


