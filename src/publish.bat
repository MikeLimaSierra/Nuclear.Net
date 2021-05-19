@ECHO OFF

CD /D "%~dp0"

SET sn_exe="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe"
SET key=KeyPair.snk
SET tfm=%1
SET ns=%2
SET asm=%3

SET bin=..\bin\%ns%\AnyCPU\Release\%tfm%\
SET publish=..\publish\%ns%\%tfm%\
SET dll=%asm%.dll
SET pdb=%asm%.pdb
SET xml=%asm%.xml
SET deps=%asm%.deps.json

ECHO "### Publishing ###"
ECHO "Assembly: %asm%.dll"
ECHO "Bin: %bin%"
ECHO "Pub: %publish%"

REM delete publish dir
RMDIR /S /Q %publish%

REM resign assembly
%sn_exe% -Ra %bin%%dll% %key%

REM verify assembly in bin
%sn_exe% -vf %bin%%dll%

REM copy output to publish dir
robocopy %bin% %publish% %dll% %pdb% %xml% %deps%

REM verify assembly in publish
%sn_exe% -vf %publish%%dll%