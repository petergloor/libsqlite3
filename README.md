# libsqlite3 - Build a Dotnet SQLite3 library for OpenSimulator

The only purpose of this simple app is to generate a Dotnet library for SQLite 3 that can be used in OpenSimulator.

__Requires dotnet 8.0__ (minimal requirement for OpenSimulator).

**1: Add Microsoft.Data.Sqlite package**

    dotnet add package Microsoft.Data.Sqlite

**2: Build the Program.**

    dotnet build


**3: Copy the library from bin/Debug/net8.0/runtimes/<architecture>/native/libe_sqlite3.so.**

In the copy target use OpenSimulator naming conventions. 

_Example for arm64 on Raspberry Pi with RaspberryPi OS:_
    
    cp bin/Debug/net8.0/runtimes/linux-arm64/native/libe_sqlite3.so \
        ../opensim/bin/lib64/libsqlite3-arm64.so


**4: Modify Library config Files for Mono.Data.Sqlite.dll and Mono.Data.SqliteClient.dll**

Add the following line to the appropriate .config files.

    <dllmap os="!windows,osx" cpu="arm64" dll="sqlite3" target="lib64/libsqlite3-arm64.so" />

_Complete example for opensim/bin/Mono.Data.Sqlite.dll.config:_

    <configuration>
        <dllmap os="windows" cpu="x86-64" dll="sqlite3" target="lib64/sqlite3.dll" />
        <dllmap os="windows" cpu="x86" dll="sqlite3" target="lib32/sqlite3.dll" />
        <dllmap os="osx" cpu="x86,x86-64" dll="sqlite3" target="lib64/libsqlite3.dylib" />
        <dllmap os="!windows,osx" cpu="x86-64" dll="sqlite3" target="lib64/libsqlite3_64.so" />
        <dllmap os="!windows,osx" cpu="x86" dll="sqlite3" target="lib32/libsqlite3_32.so" />
        <dllmap os="!windows,osx" cpu="arm64" dll="sqlite3" target="lib64/libsqlite3-arm64.so" />
    </configuration>

Finally you can run the program to see the library works.

    demo@pi4:~/libsqlite3 $ dotnet run
      Opened an SQLite3 connection into memory.
      Looks good - cleaned up and done.
    demo@pi4:~/libsqlite3 $ 

