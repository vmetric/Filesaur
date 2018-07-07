REM Created 7/6/2018 by Matthew Putnam.

REM ---- TODO ---- 
REM Ensure this script works w/ C# program
REM 
REM Add documentation/commentary
REM ---- END TODO : BEGIN SCRIPT ----



set fromDir=%1
set toDir=%2
set filetype=%3

set fromDirPlusFiletype=%fromDir%*%filetype%

set timesRan=0
for /R "%fromDir%" %%i in (*%filetype%) do move "%%i" "%toDir%" >nul && set /a timesRan = timesRan + 1
echo Successfully moved %timesRan% files