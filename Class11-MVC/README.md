![cf](http://i.imgur.com/7v5ASc8.png) Class 11: Intro to MVC
=====================================

## Learning Objectives
1. Students will be introduced to ASP.NET Core MVC web applications
2. Students will create a new MVC web app from an empty template

## Daily Outline
1. MSFT Inteview Overview
1. Weekly overview
2. Feedback Review
3. Quiz Review

## Lecture Outline

### Intro to .NET Core
What is .NET Core? Why is it so "Great"? 

1. Open Source
	- The Community contributes!
	- [GH Repo!](https://github.com/dotnet/core)
2. Cross Platform
	- Kestrel

## Web Development

We will be using our local windows as our development server for web development. Windows uses IIS express to host web applications, and each windows OS comes with IIS express available. We will learn more about IIS and the windows environment as we navigate through web development and .NET Core throughout the class. 

### MVC

MVC stands for "Model View Controller" and is one of many architectural patterns to build out web applications. 

MVC specializes and focuses on separation of concerns of data and how it is accessed and maintained. 

The main request flow of an MVC app is 

1. Request comes into the controller
2. Controller access all the appropriate models to obtain the data
3. After models have been accessed and data has been retrieved, the controller sends the data from the models to the appropriate view. 
4. The view renders the front end for the user and displays the information from the model

Below is a breakdown and more information about each component. 

#### Models
he model holds the business logic. This is where
we will create new classes and "models" for any objects
we wish to use within our web application

#### Views
This is our front-end. HTML and CSS is displayed on 
the views. In addition, on the View, we reference the "Model"
that was sent to the view from the controller. 

A really cool feature in Views is that we can display the information
from the model on the .cshtml page by using very basic C# syntax.
This "Razor Syntax" allows us to use foreach loops and if statements
to manipulate how to display the information sent from the controller. 

#### Controllers

The controller is the routing part of MVC. A controller contains
Actions, that maps to specific views. Each unique action is it's own 
view page. 
