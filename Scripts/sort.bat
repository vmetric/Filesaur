REM Created by Matthew "vmetric" Putnam
REM Purpose is to automatically sort files into appropriate folders.
REM Current list of supported filetypes:
REM JPG, PNG, GIF, TIFF, MP4, AVI, MOV, DOC, DOCX, XLS, XLSX, TXT

REM Sets variables to be used by the program. They're fed/filled upon execution.
REM Intensity key:
REM 1 = File type (pictures, documents, etc.)
REM 2 = File extension (JPG, PNG, DOC, DOCX, etc.)
set sourceDir=%1
set targetDir=%2
set sortingIntensity=%3


set timesRan = 0

set picturesRoot=%targetDir%Pictures
set videosRoot=%targetDir%Videos
set documentsRoot=%targetDir%Documents
set audioRoot=%targetDir%Audio

if %sortingIntensity% == 1 (
mkdir %picturesRoot%
mkdir %videosRoot%
mkdir %documentsRoot%
mkdir %audioRoot%

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
for /R "%sourceDir%" %%i in (*.txt) do move "%%i" "%documentsRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mp3) do move "%%i" "%audioRoot%" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.wav) do move "%%i" "%audioRoot%" >nul && set /a timesRan = timesRan + 1

echo Successfully sorted %timesRan% files!
)

if %sortingIntensity% == 2 (
mkdir %picturesRoot%\JPG
mkdir %picturesRoot%\PNG
mkdir %picturesRoot%\GIF
mkdir %picturesRoot%\TIFF

mkdir %videosRoot%\MP4
mkdir %videosRoot%\AVI
mkdir %videosRoot%\MOV
mkdir %videosRoot%\WMV

mkdir %documentsRoot%\DOC
mkdir %documentsRoot%\DOCX
mkdir %documentsRoot%\XLS
mkdir %documentsRoot%\XLSX
mkdir %documentsRoot%\TXT

mkdir %audioRoot%\MP3
mkdir %audioRoot%\WAV

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
for /R "%sourceDir%" %%i in (*.txt) do move "%%i" "%documentsRoot%\TXT" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.mp3) do move "%%i" "%audioRoot%\MP3" >nul && set /a timesRan = timesRan + 1
for /R "%sourceDir%" %%i in (*.wav) do move "%%i" "%audioRoot%\WAV" >nul && set /a timesRan = timesRan + 1

echo Successfully sorted %timesRan% files!
)