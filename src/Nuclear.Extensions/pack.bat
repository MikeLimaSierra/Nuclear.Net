@ECHO OFF

SET nuget=..\..\..\nuget.exe
SET nuspec=Nuclear.Extensions.nuspec

REM pack
%nuget% pack %nuspec% -OutputDirectory ..\..\..\