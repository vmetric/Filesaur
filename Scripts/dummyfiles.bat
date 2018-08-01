REM Created by Matthew Putnam.

set numOfFiles=%1
set sizeOfFiles=%2
set createLocation=%3

REM Converts size entered by user to bytes.
set /a sizeOfFilesBytes=%sizeOfFiles% * 1000000

REM For loop that uses fsutil to create the files, naming each file with 
REM incrementing integer at the end.
for /L %%I in (1,1,%numOfFiles%) do fsutil file createnew "%createLocation%\dummy%%I.txt" %sizeOfFilesBytes%