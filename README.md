# StudioWorld

StudioWorld is a platform for capturing the art of every moment.

## Call to Action

Help protect art by investing in it!

Exploring our services:
 Content Creation
 Podcasting and Media
 Cosmotology
 Tattoing

Book an appointment [HERE] or accesses our training programs [HERE].

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Entity Framework Core tools

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/StudioWorld.git
   cd StudioWorld
   ```

1. Install Entity Framework Core tools (if not already installed):

   ```bash
   dotnet tool install --global dotnet-ef
   ```

1. Make the migration script executable (for macOS/Linux):

   ```bash
   chmod +x ./migrate.sh
   ```

1. Run the migrations script to set up the database:

   ```bash
   # For macOS/Linux:
   ./migrate.sh

   # For Windows:
   .\migrate.cmd
   ```

1. Run the application:

   ```bash
   cd webapp
   dotnet run
   ```

1. Open your browser and navigate to:

   ```text
   http://localhost:5211
   ```

### Platform-Specific Notes

- **Windows**: The project is configured to use SQL Server LocalDB by default
- **macOS/Linux**: The project uses SQLite for cross-platform compatibility

### Switching Database Providers

The project includes a script to switch between SQLite and SQL Server database providers:

```bash
# Make the script executable (first time only)
chmod +x ./switch-db-provider.sh

# Run the script to switch providers
./switch-db-provider.sh
```

After switching providers, you'll need to run the migration script again to recreate your database with the new provider.

## Development TODOs

### Foundational Optimizations

- [x] **Project Architecture Improvements**
  - [x] Implement repository pattern and dependency injection
  - [x] Create ViewModels (MVVM pattern)
  - [x] Set up proper folder structure

- [x] **Configuration and Environment Setup**
  - [x] Configure environment-specific settings
  - [x] Set up proper logging configuration
  - [x] Configure database connections

- [x] **Security Best Practices**
  - [x] Implement Anti-Forgery Token validation
  - [x] Add input validation and sanitization
  - [ ] Configure Authentication/Authorization if needed

- [x] **Performance Optimizations**
  - [x] Implement response caching
  - [ ] Set up JS/CSS bundling and minification
  - [x] Configure static file handling

- [ ] **SEO Optimization**
  - [ ] Add proper meta tags
  - [ ] Implement structured data
  - [ ] Set up SEO-friendly URLs

- [x] **Additional Functionality**
  - [x] Implement global exception handling
  - [x] Add custom error pages
  - [x] Set up health checks

- [ ] **Azure Integration**
  - [x] Configure for Azure App Service
  - [ ] Set up Azure Application Insights
  - [ ] Configure Azure Blob Storage for media files

### Feature Implementation

- [ ] Home page design
- [ ] Services pages
- [ ] Booking system
- [ ] User authentication (if needed)
- [ ] Admin dashboard (if needed)
- [ ] Media gallery
- [ ] Training programs section

