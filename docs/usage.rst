Usage
=====

.. _installation:

Installation
------------

===============================================

This is a project that uses .NET 8.0 for the backend and Next.js 14 for the frontend, both containerized, with Docker Compose for container orchestration, along with a MongoDB database.

Prerequisites
Make sure you have Docker and Docker Compose installed on your system before proceeding with the steps below.

Automated Build Process (Windows and Ubuntu based distros)
To automate the build process, you can use the `run-build-windows.bat` -- `run-build-ubuntu.sh` file located in the root of the repository.

Instructions:
# Ensure that Docker and Docker Compose are installed on your system.
# Double-click or run the `run-build-windows.bat` -- `run-build-ubuntu.sh` file in the root of the repository.
# This script will execute the necessary commands to build the Docker images for the backend and frontend components of the project.
# Once the build process is complete, you can proceed to run the Docker Compose command to orchestrate the containers as described in the previous sections.

Notes
- You may need to adjust the file permissions or run it with administrative privileges if necessary.
- If you find any issues running the bashes, you can follow the instructions in the file, its basically build both images in the root of each project, be aware of the image name, and then run docker compose with `docker-compose up -d`.

===============================================

