.. include:: ../README.rst

Welcome to my project's documentation!
===================================

Backend (.NET Core)

Project Setup and Configuration

- [x] Set up a clean .NET Core project structure.
- [x] Use Dockerfile for containerization.

Model

- [x] Create a product model with necessary fields (SKU, price, stock, etc.).
- [x] Implement data annotations for validation.

Generic MongoDB Repository

- [x] Implement a generic MongoDB repository that accepts entities as '< T >'.
- [x] Include methods like Find, FindById, FindWhere, etc.
- [x] Utilize official MongoDB driver for .NET.
- [x] Implement MongoDB transactions.

Fluent Validation

- [x] Use Fluent Validation for input validation.
- [x] Create validation rules for product entities.
- [x] Integrate validation in the services layer.

Services

- [x] Implement services for CRUD operations on products.
- [x] Apply Dependency Injection for the generic repository.
- [x] Utilize Fluent Validation for input validation.
- [x] Implement MongoDB transactions in the services layer.

Controllers

- [x] Create RESTful controllers for product CRUD operations.
- [x] Follow Clean Code principles in controller methods.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Frontend (ReactJS with Next.js)

Project Setup and Configuration

- [x] Set up a clean Next.js project structure.
- [x] Utilize Dockerfile for frontend containerization.

Pages and Routes

- [ ] Create pages for listing, viewing, adding, editing, and deleting products.
- [ ] Implement clean routing using Next.js.

Forms

- [ ] Use react-hook-form for efficient form handling.
- [ ] Implement form validation with zod.

UI Styling

- [x] Apply mantine for UI component styling.
- [x] Follow clean code practices in styling components.

Integration between Frontend and Backend

a. API Consumption

- [x] Configure the frontend to consume backend API endpoints.
- [x] Utilize a clean approach for handling API calls.

b. Dependency Injection

- [x] Consider using Dependency Injection on the frontend for managing API calls.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Integration

Docker Compose

- [x] Create a docker-compose.yml file to orchestrate the containers for the backend, frontend, and MongoDB.
- [ ] Include appropriate environment variables for configuration.

Clean Code Practices

- [x] Enforce SOLID principles in both backend and frontend code.
- [x] Ensure meaningful variable/method names and code readability.
- [x] Implement unit tests for critical functionalities.

Delivery

- [ ] Provide separate Docker Compose files for development and production.
- [x] Include clear instructions for setting up and running the entire application in README.
- [ ] Ensure the application is accessible through a browser after Docker Compose execution.