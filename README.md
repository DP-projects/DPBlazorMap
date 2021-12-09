# DPBlazorMap.

DP Blazor Map is a library for Blazor, which is a wrapper on top of the Leaflet js library.

[![NuGet version (DPBlazorMapLibrary)](https://img.shields.io/nuget/v/DPBlazorMapLibrary)](https://www.nuget.org/packages/DPBlazorMapLibrary/)

## Table of contents

- [Start](start)

## Start

1. Add NuGet package to your project.
2. Add latest Leflet required [Leflet download](https://leafletjs.com/download.html).

```
	<head>
	  <link rel="stylesheet" href="https://unpkg.com/leaflet@1.7.1/dist/leaflet.css"
		   integrity="sha512-xodZBNTC5n17Xt2atTPuE1HxjVMSvLVW9ocqUKLsCC5CXdbqCmblAshOMAS6/keqq/sMZMZ19scR4PsZChSR7A=="
		   crossorigin="" />
	</head>
	<body>
	    <script src="https://unpkg.com/leaflet@1.7.1/dist/leaflet.js"
		    integrity="sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA=="
		    crossorigin=""></script>
	</body>
```

3. Add ```@using DPBlazorMapLibrary; ``` to your _Import.cshtml file. Or in the places used separately.
4. Add ```builder.Services.AddMapService();``` in your Program.cs file.
