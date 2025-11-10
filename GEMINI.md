# Project: PopGeneS.js

## Project Overview

This project is a web-based population genetics simulation suite. It appears to be a modern web-based rewrite of a desktop application originally written in Visual Basic. The goal of the project is to provide a web-based interface for simulating and visualizing various population genetics concepts.

The project is built using the following technologies:

*   **Frontend:** TypeScript, Vite, D3.js
*   **Styling:** CSS with custom properties (design tokens)

The project is structured as a multi-page application, with separate HTML files for different simulations (e.g., drift, selection, mutation). The styling is modern and clean, with a well-defined design system.

## Building and Running

The project uses `npm` for package management and `vite` for the development server and build process.

*   **Install dependencies:**
    ```bash
    npm install
    ```

*   **Run the development server:**
    ```bash
    npm run dev
    ```
    This will start a local development server, and you can access the application in your browser at the URL provided by Vite.

*   **Build for production:**
    ```bash
    npm run build
    ```
    This will create a `dist` directory with the optimized and bundled assets for production.

*   **Preview the production build:**
    ```bash
    npm run preview
    ```
    This will start a local server to preview the production build.

## Development Conventions

*   **TypeScript:** The project uses TypeScript for type safety and improved developer experience.
*   **Styling:** The project uses a BEM-like naming convention for CSS classes. It also uses CSS custom properties for design tokens, which helps maintain a consistent visual style.
*   **Code Structure:** The source code is organized in the `src` directory. The `PopGene.S` directory contains the original Visual Basic project, which can be used as a reference for the web-based version.
*   **Data Visualization:** The project uses D3.js for creating interactive data visualizations.
