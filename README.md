MetroFramework - WinForms on steroids.
--------------------------------------

Brings the new Modern UI alias Metro UI of Windows 8 to .NET Windows Forms applications. 

[![NuGet](https://img.shields.io/nuget/v/modernui.svg)](https://www.nuget.org/packages/modernui)

Supported platforms
-------------------
* Windows 10/11 with .NET 10

Building
-------------------

MetroFramework requires .NET 10 SDK to build.

```bash
dotnet build
```

Project Structure
-------------------

### Core Library
* **MetroFramework** - The main library containing all controls and components

### Demo Applications
* **MetroFramework.Demo** - Basic demonstration of all Metro controls

### Sample Applications
* **MetroFramework.Samples** - Controls showcase application with theme switching
* **MetroFramework.AspireSample** - Full-stack sample with:
  * **MetroFramework.AppHost** - .NET Aspire orchestration host
  * **MetroFramework.WebApi** - ASP.NET Core Minimal API backend
  * **MetroFramework.ApiClient** - WinForms client consuming the API (with explicit start from Aspire dashboard)
  * **MetroFramework.AppDefaults** - Shared service defaults for desktop clients
  * **MetroFramework.ServiceDefaults** - Shared service configuration for web services

### Test Project
* **MetroFramework.Tests** - xUnit tests for core functionality

Running the Aspire Sample
-------------------

The Aspire sample demonstrates a WinForms client consuming a Web API backend, properly integrated with .NET Aspire orchestration.

**On Windows:**
```bash
cd samples/MetroFramework.AspireSample/MetroFramework.AppHost
dotnet run
```

This starts:
1. The Aspire dashboard (opens in browser)
2. The Web API backend

The WinForms client appears in the Aspire dashboard with "Explicit Start" status. Click the **Start** button in the dashboard to launch the WinForms application.

The client uses Aspire's service discovery (`https+http://webapi`) to connect to the API automatically.

**Running the Web API standalone** (without Aspire)
```bash
cd samples/MetroFramework.AspireSample/MetroFramework.WebApi
dotnet run
```

Controls supported
------------------
* Button
* ComboBox
* Checkbox
* RadioButton
* Toggle
* Label
* Link
* Panel
* ScrollBar
* MetroTile
* ProgressBar
* ProgressSpinner
* TabControl
* TrackBar
* TextBox
* Custom User Control

Components supported
------------------
* StyleManager (Auto inherit a default style to all used controls)

Screenshots
----------
*Light*

![MetroFramework](http://i.imgur.com/8Yk1BiN.png)
![MetroFramework](http://i.imgur.com/qjwRg5z.png)
![MetroFramework](http://i.imgur.com/3S7NPLQ.png)
![MetroFramework](http://i.imgur.com/ULRej3C.png)

*Dark*

![MetroFramework](http://i.imgur.com/EddlvbX.png)
![MetroFramework](http://i.imgur.com/Djnjkti.png)
![MetroFramework](http://i.imgur.com/bI2c6kE.png)
![MetroFramework](http://i.imgur.com/7cxHl1Y.png)

License
-------

The MIT License (MIT)

Copyright (c) 2011 Sven Walter, http://github.com/viperneo

Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the "Software"), to deal in the 
Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, subject to the 
following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
