# GitSearch

A web application built with .NET Core 2.0 that searches for [GitHub](https://github.com/) users leveraging the [GitHub API v3](https://developer.github.com/v3/).

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Prerequisites

* .NET Core 2.0

* C# 7.0 Language Support.

## Installation and Execution

1. Folllow [this guide]((https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio)) to install and configure the .NET Core 2.0 Framework and Visual Studio.
2. Clone the repository.

```
projects> git clone https://github.com/r3core/GitSearch.git
projects> cd GitSearch
```

3. Execute the app with the dotnet CLI.

```
projects\GitSearch> dotnet run --project .\GitSearch.Web\
```

## Additional Configuration

**appsettings.json** of **GitSearch.Web** can be configured to change the number of search results per page.
```
    "Pagination": {
        "PageSize": 10
    } 
```

##