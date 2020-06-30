# RootLogging
A logging utility used by Studio Root Games.

# Installation
Either clone the repo to the Assets directory or initialize a Unity project with npm and run `npm install jordanstudioroot/RootLogging-UnityCSharp`.

# Usage
Declare `using RootLogging` at the top of the source file.

Call the static Log method using `RootLog.Log([information to log])`. Optionally, specify the severity of the event being logged using `RootLog.Log([information to log], Severity.[Severity types]`.

Log severity types correspond to [standard log levels in .NET](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=dotnet-plat-ext-3.1).

# Criticisms, Suggestions, Pull Requests
Email: jordannelson@protonmail.com
