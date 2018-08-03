REM Created by Matthew "vmetric" Putnam
REM Purpose is to automatically sort files into appropriate folders.
REM |||Incomplete|||
REM Current list of supported filetypes:
REM JPG, PNG, GIF, TIFF, MP4, AVI, MOV, DOC, DOCX, XLS, XLSX

REM Sets variables to be used by the program. They're fed/filled upon execution.
set /p sourceDir="Source dir: "
set /p targetDir="Target dir: "
set /p sortingIntensity="Sorting intensity: "

REM Intensity key:
REM 1 = File type (picture, document, etc.)
REM 2 = File extension (JPG, PNG, DOC, DOCX, etc.)
REM (NOT YET IMPLEMENTED) 3 = File size ( <1MB is small, 1-5MB is medium, >5 is large)
set timesRan = 0

set picturesRoot=%targetDir%\Pictures
set videosRoot=%targetDir%\Videos
set documentsRoot=%targetDir%\Documents
set audioRoot=%targetDir%\Audio

if sortingIntensity == 1
(
mkdir %picturesRoot%
mkdir %videosRoot%
mkdir %documentsRoot%
mkdir %audioRoot%
REM JPG, PNG, GIF, TIFF, MP4, AVI, MOV, DOC, DOCX, XLS, XLSX, MP3, WAV

for /R "%sourceDir%" %%i in (*.jpg) do move "%%i" "%picturesRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.jpeg) do move "%%i" "%picturesRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.png) do move "%%i" "%picturesRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.gif) do move "%%i" "%picturesRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.tiff) do move "%%i" "%picturesRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mp4) do move "%%i" "%videosRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.avi) do move "%%i" "%videosRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mov) do move "%%i" "%videosRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.doc) do move "%%i" "%documentsRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.docx) do move "%%i" "%documentsRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.xls) do move "%%i" "%documentsRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.xlsx) do move "%%i" "%documentsRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mp3) do move "%%i" "%audioRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.wav) do move "%%i" "%audioRoot%" >nul && set /a timesRan = timesRan + 1


echo Successfully sorted %timesRan% files!
)



if sortingIntensity == 2
(
mkdir %targetDir%\Pictures\JPG
mkdir %targetDir%\Pictures\PNG
mkdir %targetDir%\Pictures\GIF
mkdir %targetDir%\Pictures\TIFF

mkdir %targetDir%\Videos\MP4
mkdir %targetDir%\Videos\AVI
mkdir %targetDir%\Videos\MOV
REM Is this a real video filetype? \\ mkdir %targetDir%\Videos\WMVs

mkdir %targetDir%\Documents\DOC
mkdir %targetDir%\Documents\DOCX
mkdir %targetDir%\Documents\XLS
mkdir %targetDir%\Documents\XLSX

mkdir %targetDir%\Audio\MP3
mkdir %targetDir%\Audio\WAV

for /R "%sourceDir%" %%i in (*.jpg) do move "%%i" "%picturesRoot%\JPG" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.jpeg) do move "%%i" "%picturesRoot%\JPG" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.png) do move "%%i" "%picturesRoot%\PNG" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.gif) do move "%%i" "%picturesRoot%\GIF" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.tiff) do move "%%i" "%picturesRoot%\TIFF" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mp4) do move "%%i" "%videosRoot%\MP4" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.avi) do move "%%i" "%videosRoot%\AVI" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mov) do move "%%i" "%videosRoot%\MOV" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.doc) do move "%%i" "%documentsRoot%\DOC" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.docx) do move "%%i" "%documentsRoot%\DOCX" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.xls) do move "%%i" "%documentsRoot%\XLS" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.xlsx) do move "%%i" "%documentsRoot%\XLSX" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mp3) do move "%%i" "%audioRoot%\MP3" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.wav) do move "%%i" "%audioRoot%\WAV" >nul && set /a timesRan = timesRan + 1

echo Successfully sorted %timesRan% files!
)
pause





exit
REM THE BELOW IS NOT YET FUNCTIONAL.
if sortingIntensity == 3
(
mkdir %targetDir%\Pictures\Large
mkdir %targetDir%\Pictures\Medium
mkdir %targetDir%\Pictures\Small

mkdir %targetDir%\Videos\Large
mkdir %targetDir%\Videos\Medium
mkdir %targetDir%\Videos\Small

mkdir %targetDir%\Documents\Large
mkdir %targetDir%\Documents\Medium
mkdir %targetDir%\Documents\Small

mkdir %targetDir%\Audio\Large
mkdir %targetDir%\Audio\Medium
mkdir %targetDir%\Audio\Small

for /R "%sourceDir%" %%i in (*.doc) do move "%%i" "%targetDir%\Documents" >nul && set /a timesRan = timesRan + 1

)