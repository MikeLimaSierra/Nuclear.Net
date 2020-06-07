@ECHO OFF

SET sn_exe="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe"
SET key=..\KeyPair.snk
SET bin=..\..\bin\Nuclear.Properties\AnyCPU\Release\netstandard1.0\
SET publish=..\..\publish\Nuclear.Properties.Contracts\netstandard1.0\
SET dll=Nuclear.Properties.Contracts.dll
SET pdb=Nuclear.Properties.Contracts.pdb
SET xml=Nuclear.Properties.Contracts.xml
SET deps=Nuclear.Properties.Contracts.deps.json

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