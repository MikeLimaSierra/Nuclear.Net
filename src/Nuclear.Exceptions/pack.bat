@ECHO OFF

SET nuget=..\..\..\nuget.exe
SET nuspec=Nuclear.Exceptions.nuspec

REM pack
%nuget% pack %nuspec% -OutputDirectory ..\..\..\