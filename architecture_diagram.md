```mermaid
graph LR
    %% Reverse the order - Backend on the left, Frontend on the right
    
    subgraph "Backend Architecture"
        N[DbContext] -->|Connects To| O[SQL Database]
        
        M[Models] --> M1[Service Model]
        M --> M2[Booking Model]
        M --> M3[TrainingProgram Model]
        
        L[Controllers] --> L1[ServicesController]
        L --> L2[BookingsController]
        L --> L3[TrainingProgramsController]
        
        L --> |Uses| M
        N --> |Provides Data To| L
    end
    
    subgraph "Frontend Architecture"
        L -->|Provides Data| E[API Service]
        
        A[React TypeScript App] --> |Uses| B[React Router]
        A --> |State Management| C[AppContext]
        A --> |Error Handling| D[ErrorBoundary]
        A --> |API Integration| E

        %% Custom Hooks
        subgraph "Custom Hooks"
            I[useApi] --> I1[useServices]
            I --> I2[useTrainingPrograms]
            I --> I3[useServiceById]
            J[useForm]
        end
        
        %% Components Structure
        subgraph "Components"
            F[Pages] --> F1[Home]
            F --> F2[Services]
            F --> F3[ServiceDetail]
            F --> F4[About]
            F --> F5[Schedule]
            F --> F6[Training]
            F --> F7[Contact]
            
            G[Shared Components] --> G1[Navigation]
            G --> G2[Footer]
            G --> G3[Layout]
            
            H[UI Library] --> H1[Button]
            H --> H2[InputField]
            H --> H3[Alert]
            H --> H4[ServiceCard]
        end

        %% Connect Components to Data
        I1 -.-> F1
        I1 -.-> F2
        I3 -.-> F3
        J -.-> F5
        I2 -.-> F6
        J -.-> F7
        
        C --> |Provides State To| F
        I -->|Uses| C
    end
    
    %% User Flow at the bottom
    subgraph "User Flow"
        P[User] --> |Visits| F1
        P --> |Browses| F2
        P --> |Selects| F3
        P --> |Books| F5
        P --> |Explores Training| F6
        P --> |Contacts Business| F7
    end
```

# StudioWorld MVP Architecture Diagram

This diagram illustrates the architecture and components of the StudioWorld MVP project. The project follows a modern .NET Core backend and React + TypeScript frontend approach, with a left-to-right data flow.

## Backend Architecture

### Data Layer

- **SQL Database**: Persistent storage for application data
- **DbContext**: Entity Framework Core context for database access

### Business Logic

- **Models**: Data models that represent business entities
  - **Service Model**: Represents artistic services offered
  - **Booking Model**: Represents customer appointments
  - **TrainingProgram Model**: Represents training courses offered

### API Layer

- **Controllers**: API endpoints that handle HTTP requests
  - **ServicesController**: Manages service-related operations
  - **BookingsController**: Manages booking-related operations
  - **TrainingProgramsController**: Manages training program operations

## Frontend Architecture

### Core

- **API Service**: Centralized service for making HTTP requests to the backend
- **React TypeScript App**: Main application built with React and TypeScript
- **React Router**: Handles routing between different pages
- **AppContext**: Global state management using Context API
- **ErrorBoundary**: Catches and handles React component errors

### Custom Hooks

- **useApi**: Hooks for data fetching
  - **useServices**: Fetches all services
  - **useTrainingPrograms**: Fetches training programs
  - **useServiceById**: Fetches a specific service by ID
- **useForm**: Hook for form state management and validation

### Components

- **Pages**: Main page components
  - **Home**: Landing page
  - **Services**: Services listing page
  - **ServiceDetail**: Detailed view of a service
  - **About**: Company information page
  - **Schedule**: Booking/scheduling page
  - **Training**: Training programs page
  - **Contact**: Contact form and information
- **Shared Components**: Reusable layout components
  - **Navigation**: Site navigation menu
  - **Footer**: Site footer
  - **Layout**: Common layout wrapper
- **UI Library**: Core UI components
  - **Button**: Reusable button component
  - **InputField**: Form input component
  - **Alert**: Notification component
  - **ServiceCard**: Service preview component

## User Flow

The diagram illustrates the user journey through the StudioWorld application:

- **Visits Home**: Users start at the landing page to get an overview of services
- **Browses Services**: Users explore all available artistic services
- **Selects a Service**: Users view detailed information about specific services
- **Books an Appointment**: Users schedule appointments for services
- **Explores Training**: Users view available training programs and courses
- **Contacts Business**: Users reach out with questions or inquiries

This flow provides a seamless experience from discovery to booking, ensuring users can easily navigate the platform and engage with the business offerings.
