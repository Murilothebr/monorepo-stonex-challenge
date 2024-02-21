## Requirements

### .NET Project Test

### Backend (.NET Core)

- [ ] Create a new .NET Core project.
- [ ] Configure MongoDB as the database.
- [ ] Implement Clean Architecture principles (Separation of Concerns, Dependency Inversion, etc.).

### Frontend (ReactJS with Next.js)

- [ ] Initialize a new Next.js project with React.
- [ ] Use a modular component structure for better organization.
- [ ] Implement Clean Code principles in the frontend codebase.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Backend (.NET Core)

#### 1. Project Setup and Configuration

- [ ] Set up a clean .NET Core project structure.
- [ ] Use Dockerfile for containerization.

#### 2. Model

- [ ] Create a product model with necessary fields (SKU, price, stock, etc.).
- [ ] Implement data annotations for validation.

#### 3. Generic MongoDB Repository

- [ ] Implement a generic MongoDB repository that accepts entities as <T>.
- [ ] Include methods like Find, FindById, FindWhere, etc.
- [ ] Utilize official MongoDB driver for .NET.
- [ ] Implement MongoDB transactions.

#### 4. Fluent Validation

- [ ] Use Fluent Validation for input validation.
- [ ] Create validation rules for product entities.
- [ ] Integrate validation in the services layer.

#### 5. Services

- [ ] Implement services for CRUD operations on products.
- [ ] Apply Dependency Injection for the generic repository.
- [ ] Utilize Fluent Validation for input validation.
- [ ] Implement MongoDB transactions in the services layer.

#### 6. Controllers

- [ ] Create RESTful controllers for product CRUD operations.
- [ ] Follow Clean Code principles in controller methods.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Frontend (ReactJS with Next.js)

#### 1. Project Setup and Configuration

- [ ] Set up a clean Next.js project structure.
- [ ] Utilize Dockerfile for frontend containerization.

#### 2. Pages and Routes

- [ ] Create pages for listing, viewing, adding, editing, and deleting products.
- [ ] Implement clean routing using Next.js.

#### 3. Forms

- [ ] Use react-hook-form for efficient form handling.
- [ ] Implement form validation with zod.

 

#### 4. UI Styling

- [ ] Apply mantine for UI component styling.
- [ ] Follow clean code practices in styling components.

#### 5. Integration between Frontend and Backend

#### a. API Consumption

- [ ] Configure the frontend to consume backend API endpoints.
- [ ] Utilize a clean approach for handling API calls.

 

#### b. Dependency Injection

- [ ] Consider using Dependency Injection on the frontend for managing API calls.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Integration

#### Docker Compose

- [ ] Create a docker-compose.yml file to orchestrate the containers for the backend, frontend, and MongoDB.
- [ ] Include appropriate environment variables for configuration.

#### Clean Code Practices

- [ ] Enforce SOLID principles in both backend and frontend code.
- [ ] Ensure meaningful variable/method names and code readability.
- [ ] Implement unit tests for critical functionalities.

### Delivery

- [ ] Provide separate Docker Compose files for development and production.
- [ ] Include clear instructions for setting up and running the entire application in README.
- [ ] Ensure the application is accessible through a browser after Docker Compose execution.