@ECHO OFF

SET nuget=..\..\..\nuget.exe
SET nuspec=package.nuspec

REM pack
%nuget% pack %nuspec% -OutputDirectory ..\..\..\

PAUSE