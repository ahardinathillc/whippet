@echo off
echo Enabling long file names...
echo.
echo Your computer will restart after running this batch file. Please close all open programs.
echo.

NET SESSION
IF %ERRORLEVEL% NEQ 0 GOTO ELEVATE
GOTO ADMINTASKS

:ELEVATE
CD /d %~dp0
MSHTA "javascript: var shell = new ActiveXObject('shell.application'); shell.ShellExecute('%~nx0', '', '', 'runas', 1);close();"
EXIT

:ADMINTASKS
reg add HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\FileSystem /t REG_DWORD /v LongPathsEnabled /d 1 /f
shutdown /r
EXIT
