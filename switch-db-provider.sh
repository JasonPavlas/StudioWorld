#!/bin/bash

echo "StudioWorld Database Provider Switcher"
echo "====================================="
echo

# Determine OS
if [[ "$OSTYPE" == "darwin"* || "$OSTYPE" == "linux"* ]]; then
    OS_TYPE="unix"
else
    OS_TYPE="windows"
fi

# Get current connection string
CURRENT_PROVIDER=$(grep -A1 "ConnectionStrings" ./webapp/appsettings.json | grep -i "DefaultConnection" | grep -i "Data Source=")

if [[ $CURRENT_PROVIDER ]]; then
    echo "Currently using SQLite provider."
    USE_PROVIDER="sqlserver"
    echo "Switching to SQL Server provider..."
else
    echo "Currently using SQL Server provider."
    USE_PROVIDER="sqlite"
    echo "Switching to SQLite provider..."
fi

# Perform the switch
if [ "$USE_PROVIDER" == "sqlite" ]; then
    # Switch to SQLite
    sed -i'.bak' 's|"DefaultConnection": "Server=(localdb)\\\\mssqllocaldb;Database=StudioWorldDb;Trusted_Connection=True;MultipleActiveResultSets=true"|"DefaultConnection": "Data Source=StudioWorldDb.sqlite"|g' ./webapp/appsettings.json
    sed -i'.bak' 's|"DefaultConnection": "Server=(localdb)\\\\mssqllocaldb;Database=StudioWorldDb;Trusted_Connection=True;MultipleActiveResultSets=true"|"DefaultConnection": "Data Source=StudioWorldDb.sqlite"|g' ./webapp/appsettings.Development.json
    
    # Update Program.cs
    sed -i'.bak' 's|options.UseSqlServer(|options.UseSqlite(|g' ./webapp/Program.cs
    sed -i'.bak' '/sqlOptions => sqlOptions.EnableRetryOnFailure(/,/)/ d' ./webapp/Program.cs
else
    # Switch to SQL Server
    sed -i'.bak' 's|"DefaultConnection": "Data Source=StudioWorldDb.sqlite"|"DefaultConnection": "Server=(localdb)\\\\mssqllocaldb;Database=StudioWorldDb;Trusted_Connection=True;MultipleActiveResultSets=true"|g' ./webapp/appsettings.json
    sed -i'.bak' 's|"DefaultConnection": "Data Source=StudioWorldDb.sqlite"|"DefaultConnection": "Server=(localdb)\\\\mssqllocaldb;Database=StudioWorldDb;Trusted_Connection=True;MultipleActiveResultSets=true"|g' ./webapp/appsettings.Development.json
    
    # Update Program.cs
    sed -i'.bak' 's|options.UseSqlite(|options.UseSqlServer(|g' ./webapp/Program.cs
    # Add retry logic for SQL Server
    sed -i'.bak' 's|builder.Configuration.GetConnectionString("DefaultConnection")|builder.Configuration.GetConnectionString("DefaultConnection"),\n        sqlOptions => sqlOptions.EnableRetryOnFailure(\n            maxRetryCount: 10,\n            maxRetryDelay: TimeSpan.FromSeconds(30),\n            errorNumbersToAdd: null\n        )|g' ./webapp/Program.cs
fi

# Clean up backup files
find . -name "*.bak" -type f -delete

echo
echo "Done! Provider switched successfully."
echo
echo "Don't forget to run the migration script to recreate your database:"
if [ "$OS_TYPE" == "unix" ]; then
    echo "  ./migrate.sh"
else
    echo "  .\\migrate.cmd"
fi
echo
