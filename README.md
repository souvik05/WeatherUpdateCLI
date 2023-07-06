# WeatherUpdateCLI Tool
# This is a command-line Weather Info Tool (Using .net Core) tool that retrieves weather information based on a city name using the Open-Meteo API.
Sample Output Screen Shot:
If you want to open project sample output then requested you to open Weather Tool.PNG file

Prerequisites:
.NET Core SDK installed on your system.

Open Metro API: https://api.open-meteo.com/v1/forecast?latitude=18.9667&longitude=72.8333&current_weather=true

How to set up your project:

open the command prompt and create a new directory for your project:[Use this CMD command]>>      mkdir WeatherApp 

Navigate to the project directory:[Use this CMD command]>>    cd WeatherApp

Initialize a new .NET Core console application:[Use this CMD command]>>    dotnet new console

Next, we need to add the Newtonsoft.Json package to handle JSON parsing:[Use this CMD command]>>  dotnet add package Newtonsoft.Json

Open your preferred code editor and open Program.cs file.

Copy program.cs file code from this git repository and replace your program.cs file code

Create a json file inside your project(using your code editor you can add inside this project) and name it cities.json. It is used to store city information.

Copy cities.Json file code from this repository and replace your cities.json file code

Save the project.

Next, open the command prompt and navigate to the project directory then build your project using the following command:[Use this CMD command]>> dotnet build

Next, run this project in the command prompt:[Use this CMD command]>> dotnet run

Enter a city name:

It will show the user input city weather information like temperature and wind speed.

How to set up a test project to unit test the code:

First, make sure you have the xUnit NuGet package installed. You can install it using the following command in the project directory:[Use this CMD command]>>   dotnet add package xunit

Create a new directory named "WeatherApp.Tests" in the project directory: [Use this CMD command]>>   mkdir WeatherApp.Tests

Change into the "WeatherApp.Tests" directory:[Use this CMD command]>> cd WeatherApp.Tests

Initialize a new xUnit test project: dotnet new xunit

Open the project in your code editor.

Copy UnitTest1.cs file code from this git repository and replace your UnitTest1.cs file code

Create a json file inside your project and name it cities.json. It is used to store city information.

Copy cities.Json file code from this repository and replace your cities.json file code

Save the project.

Next open the command prompt and navigate to the test project directory then run your project using the following command:[Use this CMD command]>>    dotnet test
