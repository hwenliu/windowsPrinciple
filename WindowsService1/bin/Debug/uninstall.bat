net stop MyService1
sc delete MyService1 binPath= "%~dp0WindowsService1.exe" start= auto
pause