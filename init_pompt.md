Please help me implement the remaining core features for the StudioWorld MVP based on our current structure. We've set up the architecture with React/TypeScript frontend and .NET Core backend, but need to:

1. Complete the integration between frontend and backend:
   - Update remaining page components (Home, About, etc.) to use TypeScript and our custom hooks
   - Implement the form submission for booking services and training programs
   - Add service details page for viewing individual services

2. Implement basic state management:
   - Ensure AppContext is properly integrated with all components
   - Implement proper error handling and loading states using our ErrorBoundary

3. Add styling improvements:
   - Create consistent styling using our UI component library
   - Make the layout responsive for mobile and desktop views
   - Implement proper transitions between pages

4. Backend data persistence:
   - Add Entity Framework Core for data access
   - Create proper database models
   - Add validation for incoming requests

The goal is to have a fully functional MVP that allows users to:
- Browse services and training programs
- View details about each service
- Submit booking requests for services and training programs
- Contact the business

Please implement these features in a way that maintains code quality, follows TypeScript best practices, and creates a clean user experience.