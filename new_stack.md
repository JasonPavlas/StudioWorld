# StudioWorld MVP Scope

## Objective

Build a scalable platform for exploring services, booking appointments, and accessing training programs. Focus on delivering core functionality with a modern tech stack.

## Tech Stack

### Backend Implementation

- **Framework**: .NET Core scaffolding.

- **Database**: Single SQL Database.

- **ORM**: Entity Framework Core.

- **API**: RESTful Controllers for Services, Bookings, and TrainingPrograms.

### Frontend

- **Framework**: React with TypeScript.

- **Styling**: TailwindCSS.

- **Layout**:

  - **Desktop**: A long panel on the left (1/3 of the screen) and two horizontal sections on the right (2/3 of the screen).

  - **Mobile**: Sections stack vertically.

- **State Management**: Context API.

- **Routing**: React Router.

- **Error Handling**: ErrorBoundary.

- **Custom Hooks**: API integration (useApi) and form management (useForm).

## Core Features

### Backend

- **Data Layer**: SQL Database, DbContext.

- **Business Logic**: Models (Service, Booking, TrainingProgram).

- **API Layer**: Controllers (Services, Bookings, TrainingPrograms).

### Frontend Features

- **Core Components**: React App, API Service, AppContext, ErrorBoundary.

- **Custom Hooks**: useApi, useForm.

- **Pages**: Home, Services, ServiceDetail, About, Schedule, Training, Contact.

- **Shared Components**: Navigation, Footer, Layout.

- **UI Library**: Button, InputField, Alert, ServiceCard.

## Infrastructure

- **Region**: eastus2.

- **Assumptions**:

  - Infrastructure (including Application Insights) is pre-existing.

  - Secrets will be provided via GitHub Actions secrets.

## Testing

- **Performance Testing**: JMeter.

- **End-to-End Testing**: Playwright.

## Deployment

- **Tool**: GitHub Actions.

- **Trigger**: On merges to the `main` branch.

- **Deployment**:

  - Build and deploy to an existing Linux App Service plan.

  - Use the publishing profile stored in GitHub Actions secrets.

## Next Steps

1. Scaffold the backend and frontend.

2. Implement database schema and secure APIs.

3. Develop the React frontend with responsive layout and error handling.

4. Define and validate the CI/CD pipeline.

5. Test the user flow for seamless navigation.

6. Set up monitoring with Application Insights.

## Instructions for the Agent

- **Focus Areas**: Prioritize building the backend and frontend scaffolding as outlined in the "Next Steps" section.

- **Tech Stack Adherence**: Ensure all implementations strictly follow the defined tech stack.

- **Best Practices**: Incorporate recommendations for security, reliability, and performance.

- **Deliverables**: Provide a functional backend, frontend, and infrastructure setup ready for deployment.

- **Validation**: Include tests and monitoring to ensure the platform meets the outlined requirements.

This document serves as the foundation for the project. Use it to guide all development and deployment efforts.
