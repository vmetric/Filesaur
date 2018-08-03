REM Created by Matthew "vmetric" Putnam.
REM Recursively deletes files of a certain type from a given directory.

REM Sets variables to be used by the program. They are fed/filled upon execution.
set fromDir=%1
set filetype=%2

REM Combines the "from" directory with the filetype.
set fromDirPlusFiletype=%fromDir%*%filetype%

REM Sets variable to be used to count times ran, i.e., files moved.
set timesRan=0

REM For loop to delete every %filetype% file and increment timesRan each run-through.
for /R "%fromDir%"  %%i in (*%filetype%) do del "%%i" && set /a timesRan = timesRan + 1

REM Echos success of deleting however many files.
echo Successfully deleted %timesRan% files.