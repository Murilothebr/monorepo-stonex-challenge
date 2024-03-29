# Project: Your Project Name

## Description
This is a project that uses .NET 8.0 for the backend and Next.js 14 for the frontend, both containerized, with Docker Compose for container orchestration, along with a MongoDB database.

## Prerequisites
Make sure you have Docker and Docker Compose installed on your system before proceeding with the steps below.

## Automated Build Process (Windows and Ubuntu based distros)
To automate the build process, you can use the `run-build-windows.bat` -- `run-build-ubuntu.sh` file located in the root of the repository.

### Instructions:
1. Ensure that Docker and Docker Compose are installed on your system.
2. Double-click or run the `run-build-windows.bat` -- `run-build-ubuntu.sh` file in the root of the repository.
3. This script will execute the necessary commands to build the Docker images for the backend and frontend components of the project.
4. Once the build process is complete, you can proceed to run the Docker Compose command to orchestrate the containers as described in the previous sections.

## Notes
- You may need to adjust the file permissions or run it with administrative privileges if necessary.
- If you find any issues running the bashes, you can follow the instructions in the file, its basically build both images in the root of each project, be aware of the image name, and then run docker compose with `docker-compose up -d`.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Requirements

### .NET Project Test

### Backend (.NET Core)

- [x] Create a new .NET Core project.
- [x] Configure MongoDB as the database.
- [x] Implement Clean Architecture principles (Separation of Concerns, Dependency Inversion, etc.).

### Frontend (ReactJS with Next.js)

- [x] Initialize a new Next.js project with React.
- [x] Use a modular component structure for better organization.
- [x] Implement Clean Code principles in the frontend codebase.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Backend (.NET Core)

#### 1. Project Setup and Configuration

- [x] Set up a clean .NET Core project structure.
- [x] Use Dockerfile for containerization.

#### 2. Model

- [x] Create a product model with necessary fields (SKU, price, stock, etc.).
- [x] Implement data annotations for validation.

#### 3. Generic MongoDB Repository

- [x] Implement a generic MongoDB repository that accepts entities as '< T >'.
- [x] Include methods like Find, FindById, FindWhere, etc.
- [x] Utilize official MongoDB driver for .NET.
- [x] Implement MongoDB transactions.

#### 4. Fluent Validation

- [x] Use Fluent Validation for input validation.
- [x] Create validation rules for product entities.
- [x] Integrate validation in the services layer.

#### 5. Services

- [x] Implement services for CRUD operations on products.
- [x] Apply Dependency Injection for the generic repository.
- [x] Utilize Fluent Validation for input validation.
- [x] Implement MongoDB transactions in the services layer.

#### 6. Controllers

- [x] Create RESTful controllers for product CRUD operations.
- [x] Follow Clean Code principles in controller methods.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Frontend (ReactJS with Next.js)

#### 1. Project Setup and Configuration

- [x] Set up a clean Next.js project structure.
- [x] Utilize Dockerfile for frontend containerization.

#### 2. Pages and Routes

- [x] Create pages for listing, viewing, adding, editing, and deleting products.
- [ ] Implement clean routing using Next.js.

#### 3. Forms

- [x] Use react-hook-form for efficient form handling.
- [x] Implement form validation with zod.

#### 4. UI Styling

- [x] Apply mantine for UI component styling.
- [x] Follow clean code practices in styling components.

#### 5. Integration between Frontend and Backend

#### a. API Consumption

- [x] Configure the frontend to consume backend API endpoints.
- [x] Utilize a clean approach for handling API calls.

#### b. Dependency Injection

- [x] Consider using Dependency Injection on the frontend for managing API calls.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Integration

#### Docker Compose

- [x] Create a docker-compose.yml file to orchestrate the containers for the backend, frontend, and MongoDB.
- [x] Include appropriate environment variables for configuration.

#### Clean Code Practices

- [x] Enforce SOLID principles in both backend and frontend code.
- [x] Ensure meaningful variable/method names and code readability.
- [x] Implement unit tests for critical functionalities.

### Delivery

- [ ] Provide separate Docker Compose files for development and production.
- [x] Include clear instructions for setting up and running the entire application in README.
- [x] Ensure the application is accessible through a browser after Docker Compose execution.