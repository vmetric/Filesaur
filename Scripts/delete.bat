REM Created 7/6/2018 by Matthew Putnam.

REM ---- TODO ---- 
REM Ensure this script works w/ C# program
REM Ensure script is "complete"
REM Add documentation/commentary
REM ---- END TODO : BEGIN SCRIPT ----

set fromDir=%1
set filetype=%2

set fromDirPlusFiletype=%fromDir%*%filetype%

set timesRan=0
for /R "%fromDir%"  %%i in (*%filetype%) do del "%%i" && set /a timesRan = timesRan + 1
echo Successfully deleted %timesRan% files.