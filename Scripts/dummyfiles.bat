REM Created by Matthew "vmetric" Putnam.
REM Generates a given amount of empty text files of a certain size in a given directory.

REM Sets variables to be used by the program. They are fed/filled upon execution.
set numOfFiles=%1
set sizeOfFiles=%2
set createLocation=%3
set filetype=%4

REM Converts size entered by user to bytes.
set /a sizeOfFilesBytes=%sizeOfFiles% * 1000000

REM For loop that uses fsutil to create the files, appending an incrementing integer at the end of filename.
for /L %%I in (1,1,%numOfFiles%) do fsutil file createnew "%createLocation%\dummy%%I%filetype%" %sizeOfFilesBytes%