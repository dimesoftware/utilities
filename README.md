# Dime.Utilities

![Build status](https://dev.azure.com/dimenicsbe/Utilities/_apis/build/status/dimenics.dime-utilities?branchName=master) ![CodeQL](https://github.com/dimenics/utilities/workflows/CodeQL/badge.svg) ![Code coverage](https://img.shields.io/azure-devops/coverage/dimenicsbe/Utilities/150/master)

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
    string truncatedString = "Hello world".Truncate(7); // Returns "Hello w";

    List<int> someList = new List<int> { 1,2,3,4,5 };
    someList.AddIf(10, x => x > 0); // Adds to the list
    someList.AddIf(-10, x => x > 0); // Doesn't add to the list
}
```

## Contributing

![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)

Pull requests are welcome. Please check out the contribution and code of conduct guidelines.

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)
