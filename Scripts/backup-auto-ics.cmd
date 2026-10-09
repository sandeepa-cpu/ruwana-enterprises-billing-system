@echo off
"C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\180\Tools\Binn\SQLCMD.EXE" -S LAPTOP-5TPJLVNI\HOME -E -C -b -Q "BACKUP DATABASE [AUTO_ICS] TO DISK = N'D:\System Files\DATABASE BACKUPS\AUTO_ICS_daily.bak' WITH INIT"
exit /b %ERRORLEVEL%
