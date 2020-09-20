# Z-Blog Blazor WebAssembly
![GitHub](https://img.shields.io/github/license/hmz777/HMZ-Software-Blazor-WebAssembly?color=black&style=flat-square)

### This is a (work in progress) rewrite of my personal portfolio + blog using Blazor WebAssembly.

The code in this repository is not meant to be a theme template nor cloned or deployed, its for my own personal use, if it helps you, feel free to take whatever inspiration you want from it.

# The Idea
As part of my process to learn Blazor Web Assembly, i will be creating a static blog that takes posts as markdown files with yaml metadata and output .html + .yml files for every post and display them dynamically.

# Project Structure
The solution consists of two projects:

## HMZ-Software
The main blazor wasm app, it contains all the logic and components to form the website.
The blog is located in `wwwroot` and structured like this:

- Blog
    - Metadata
    - Posts
    - Site
    
The `Metadata` directory has a `Metadata.json` file that contains all the posts' metadata.
The purpose of the `Metadata.json` file is to bypass the limitation of enumerating over files in `wwwroot`, it contains all the user provided posts' metadata: `Title`, `Dates`, `Tags`, etc.

The `Posts` directory contains the markdown files that'll be compiled to `.html` and `.yml` on build via the `MarkdownCompiler` project.

The `Site` directory contains the compilation output of the `MarkdownCompiler` project `.html` and `.yml` files for every post.

## MarkdownCompiler
The `MarkdownCompiler` is the project responsible for compiling the markdown files.
The project is triggered to run on every build as a Visual Studio post build event.

### What does it do?
1. Performs clean up on the `Blog` directory (if it exists) to clear it from old posts and metadata files so it can start compiling the files again.
2. Create the blog structure in the main project if it's not created.
3. Parse markdown files that also consists of yaml markup, separate them into compiled html and yml files and write them to the `Site` directory.
4. Construct the `Metadata.json` file the represents the posts' metadata.
5. Any exceptions are logged to `ExecuteLog.log` in the assembly directory.

Libraries used:
- jQuery
- PrismJs for syntax highlighting
