
Example challenge for the backend role as a developer at StoneX
===============================================

This example shows a basic Sphinx project with Read the Docs. You're encouraged to view it to get inspiration and copy & paste from the files in the source code. If you are using 
Read the Docs for the first time, have a look at the official `Read the Docs Tutorial <https://docs.readthedocs.io/en/stable/tutorial/index.html>`__.

📚 `docs/ <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/docs/>`_
    A basic Sphinx project lives in ``docs/``. All the ``*.rst`` make up sections in the documentation.
⚙️ `.readthedocs.yaml <https://github.com/readthedocs-examples/example-sphinx-basic/blob/main/.readthedocs.yaml>`_
    Read the Docs Build configuration is stored in ``.readthedocs.yaml``.
📜 `README.rst <https://github.com/Murilothebr/monorepo-stonex-challenge/blob/main/README.rst>`_
    Contents of this ``README.rst`` are visible on Github and included on `the documentation index page <https://readthedocs.org/projects/monorepo-stonex-challenge/>`_ (Don't Repeat Yourself).

Requirements
===============================================

Description

This is a project that uses .NET 8.0 for the backend and Next.js 14 for the frontend, both containerized, with Docker Compose for container orchestration, along with a MongoDB database.

Prerequisites
Make sure you have Docker and Docker Compose installed on your system before proceeding with the steps below.

Automated Build Process (Windows and Ubuntu based distros)
To automate the build process, you can use the `run-build-windows.bat` -- `run-build-ubuntu.sh` file located in the root of the repository.

Instructions:
#. Ensure that Docker and Docker Compose are installed on your system.
#. Double-click or run the `run-build-windows.bat` -- `run-build-ubuntu.sh` file in the root of the repository.
#. This script will execute the necessary commands to build the Docker images for the backend and frontend components of the project.
#. Once the build process is complete, you can proceed to run the Docker Compose command to orchestrate the containers as described in the previous sections.

Notes
- You may need to adjust the file permissions or run it with administrative privileges if necessary.
- If you find any issues running the bashes, you can follow the instructions in the file, its basically build both images in the root of each project, be aware of the image name, and then run docker compose with `docker-compose up -d`.

===============================================


Project
===============================================

.NET Project Test

Backend (.NET Core)

- [x] Create a new .NET Core project.
- [x] Configure MongoDB as the database.
- [x] Implement Clean Architecture principles (Separation of Concerns, Dependency Inversion, etc.).

Frontend (ReactJS with Next.js)

- [x] Initialize a new Next.js project with React.
- [x] Use a modular component structure for better organization.
- [x] Implement Clean Code principles in the frontend codebase.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
