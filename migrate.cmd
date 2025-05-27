@echo off
REM This script will create the initial database migration for the StudioWorld application

REM Navigate to the webapp directory
cd /d %~dp0\webapp

REM Add initial migration
dotnet ef migrations add InitialCreate --output-dir Data/Migrations

REM Apply the migration to create/update the database
dotnet ef database update

echo.
echo Migration completed successfully!
echo.
pause
