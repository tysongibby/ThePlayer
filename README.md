# The Player
A music player that plays music.
This project is designed to leverage new tecnologies in .NET 6 that leverage Blazor Web Assemblies, specifically allowing 3 party libraries to be complied and deployed to the web browser client. In this case SQLite is the library being deployed as a Web Assmbly.

references:
- File and Directory Entries API https://developer.mozilla.org/en-US/docs/Web/API/File_and_Directory_Entries_API/Introduction
- File System Access API https://web.dev/read-files/
- Build an Audio Browser app with Blazor | .NET Conf 2022 https://youtu.be/2t4VwBeQ9DY
- New Blazor WebAssembly capabilities in .NET 6 https://youtu.be/kesUNeBZ1Os  (starting at 6:30)
- SQLite with EF Core in Blazor Wasm https://www.youtube.com/watch?v=2UPiKgHv8YE
- File System Access API: https://developer.mozilla.org/en-US/docs/Web/API/File_System_Access_API
- The File System Access API: simplifying access to local files: https://developer.chrome.com/articles/file-system-access/
- How to recursively read local files and directories in web browser using File System Access API https://stackoverflow.com/questions/64283711/how-to-recursively-read-local-files-and-directories-in-web-browser-using-file-sy
- Getting Started With the File System Access API https://css-tricks.com/getting-started-with-the-file-system-access-api/
- The Embed Audio element https://developer.mozilla.org/en-US/docs/Web/HTML/Element/audio
- HTMLAudioElement interface https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement


Lyrics API References:
- LyricWiki API: This API allows you to access the data from the LyricWiki database programmatically. It provides a variety of methods for retrieving information about artists, albums, and lyrics, and is available under a Creative Commons license. It is powered by the MediaWiki software and is freely editable by anyone.
	- https://lyrics.fandom.com/wiki/LyricWiki_API
- Lyrics.Fandom.com API: This API allows you to access the data from the Lyrics.Fandom.com database programmatically. It provides a variety of methods for retrieving information about artists, albums, and lyrics, and is available under a Creative Commons license. It is powered by the MediaWiki software and is freely editable by anyone.
	- https://lyrics.fandom.com/wiki/API
- Lyrics.net API: This API allows you to access the data from the Lyrics.net database programmatically. It provides a variety of methods for retrieving information about artists, albums, and lyrics, and is available under a Creative Commons license. It allows users to contribute and edit lyrics, and includes features such as search and filtering by artist, track, or album.
	- https://www.lyrics.net/developers



Userful terms:
- Handle: In the Windows operating system, a handle is a unique identifier that is assigned to a system object such as a file, a process, or a thread. Handles are used to reference these objects within the operating system, and are typically used by system calls and API functions to access and manipulate the objects. They are also used by applications to access resources such as files and network connections. Handles are usually created and managed by the operating system, but can also be created and used by applications.
- Directory Handle: In the Windows operating system, a directory handle is a handle that is used to refer to a specific directory or folder on a file system. It is a unique identifier assigned by the operating system when a directory is opened, and it can be used to access the files and subdirectories within that directory. The handle is used by various file system functions, such as CreateFile, ReadFile, and WriteFile, to perform operations on the directory.




