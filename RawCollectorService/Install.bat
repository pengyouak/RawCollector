@echo off

%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe RawCollectorService.exe
Net Start RawCollectorService
sc config RawCollectorService start= auto

pause