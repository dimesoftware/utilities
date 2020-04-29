# Dime.Utilities

![Build status](https://dev.azure.com/dimenicsbe/Utilities/_apis/build/status/Utilities%20Core%20-%20MAIN%20-%20CI?branchName=master)

## Introduction

All-purpose utilities for commonly used assemblies.

## Getting Started

- You must have Visual Studio 2019 Community or higher.
- The dotnet cli is also highly recommended.

## About this project

This project contains heaps of extension methods for common types such as `int` and `string`.

## Build and Test

- Run dotnet restore
- Run dotnet build
- Run dotnet test

## Installation

Use the package manager NuGet to install Dime.Utilities:

`dotnet add package Dime.Utilities`

## Usage

``` csharp
using System;

public void Main(params string[] args)
{
    string truncatedString = "Hello world".Truncate(6); // Returns "Hello w";
}
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)