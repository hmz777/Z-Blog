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

### Blog
The blog is located in `wwwroot` and structured like this:

- Blog
    - Metadata
    - Posts
    - Site
    
The `Metadata` directory has a `Metadata.json` file that contains all the posts' metadata.
The purpose of the `Metadata.json` file is to bypass the limitation of enumerating over files in `wwwroot`, it contains all the user provided posts' metadata: `Title`, `Dates`, `Tags`, etc.

The `Posts` directory contains the markdown files that'll be compiled to `.html` and `.yml` on build via the `MarkdownCompiler` project.

The `Site` directory contains the compilation output of the `MarkdownCompiler` project `.html` and `.yml` files for every post.

### Logic and Services
- The `IBlogPostProcessorService` handles processing of html, yaml and json files.
- The `ProcessPostAsync` and `ProcessPostMetadataAsync` processes posts and metadata files respectively.
- The `ProcessPostsMetadataAsync` fetches the `Metadata.json` file and caches it in a global static variable named `GlobalVariables.YamlMetadata`.

#### Pages
- The `Blog` page has the `BlogPosts` components which renders all the posts by injecting the `IBlogPostProcessorService` service and fetching the `Metadata.json` file by calling `ProcessPostsMetadataAsync`.
- The `Post` page renders a specific post by injecting `IBlogPostProcessorService` service and fetching the post related files by calling `ProcessPostAsync`.
The files are deserialized to a [`BlogPostDocument`](https://github.com/hmz777/Z-Blog-Blazor-Wasm/blob/master/HMZ-Software/Models/BlogPostDocument.cs) type which has a `Markdown`, `html` and `Yaml` properties.

#### Components
The `BlogPost` component renders the blog post cards in the `Blog` page.
The `ProjectCards` component renders my GitHub repositories as cards using the GitHub API and it calls the `Intesection Observer` using the `IJSRuntime` in order to call the api once the component is in the viewport.

## MarkdownCompiler
The `MarkdownCompiler` is the project responsible for compiling the markdown files.
The project is triggered to run on every build as a Visual Studio post build event.

### What does it do?
1. Performs clean up on the `Blog` directory (if it exists) to clear it from old posts and metadata files so it can start compiling the files again.
2. Create the blog structure in the main project if it's not created.
3. Parse markdown files that also consists of yaml markup, separate them into compiled html and yml files and write them to the `Site` directory.
4. Construct the `Metadata.json` file the represents the posts' metadata.
5. Any exceptions are logged to `ExecuteLog.log` in the assembly directory.

# Libraries used:
- [Markdig](https://github.com/lunet-io/markdig) for markdown compilation.
- [YamlDotNet](https://github.com/aaubry/YamlDotNet) for yaml related operations.
- [jQuery](https://github.com/jquery/jquery).
- [PrismJs](https://github.com/PrismJS/prism) for syntax highlighting.
- [Line Awesome](https://github.com/icons8/line-awesome) icon font.
- [Brotli](https://github.com/google/brotli) for blazor file decompression.
Aditionally the project uses SASS.
