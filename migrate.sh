#!/bin/bash

# This script will create the initial database migration for the StudioWorld application

# Navigate to the webapp directory
cd "$(dirname "$0")/webapp" || exit

# Check if migrations directory exists
if [ ! -d "Data/Migrations" ]; then
    echo "Creating initial migration..."
    # Add initial migration
    dotnet ef migrations add InitialCreate --output-dir Data/Migrations
else
    echo "Migrations directory already exists. Skipping initial migration."
fi

# Apply the migration to create/update the database
dotnet ef database update

echo
echo "Migration completed successfully!"
echo
echo "Your SQLite database has been created at: $(pwd)/StudioWorldDb.sqlite"
echo
