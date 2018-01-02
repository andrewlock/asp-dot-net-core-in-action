Book project for ASP.NET Core in Action
==============================
This repository contains the code samples for [*ASP.NET Core in Action*](https://www.manning.com/books/asp-dot-net-core-in-action).

> **Note** Some projects include 1.x versions of projects as well as 2.0 versions. Projects are essentially equivalent and are found in a folder indicating the .NET Core version.

## Chapter 1
*No code samples*

## [Chapter 2](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter02)
* *WebApplication1* - A sample web application, based on the .NET Core CLI MVC template
* *WebApplication2* - A sample web application, based on the Visual Studio MVC template

## [Chapter 3](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter03)
* *CreatingAHoldingPage* - 3.2.1 Simple pipeline scenario 1: A holding page
* *CreatingAStaticFileWebsite* - 3.2.2 Simple pipeline scenario 2: Handling static files
* *SimpleMVCApplication* - 3.2.3 Simple pipeline scenario 3: An MVC web application
* *SimpleMVCApplicationAndHoldingPage* - 3.2.3 Simple pipeline scenario 3: An MVC web application + a holding page for "/"
* *DeveloperExceptionPage* - 3.3.1 Viewing exceptions in development: the DeveloperExceptionPage
* *ExceptionHandlerMiddleware* - 3.3.2 Handling exceptions in production: the ExceptionHandlerMiddleware
* *StatusCodePages* - 3.3.3 Handling other errors: the StatusCodePagesMiddleware
* *DisableStatusCodePages* - 3.3.4 Disabling error handling middleware for web APIs

## [Chapter 4](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter04)
* *AddingMvcToEmptyProject* - Starting from an empty project and adding the MVC middleware.

## Chapter 5
*No code samples*

## [Chapter 6](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter06)
* *ToDoList* - Basic application demonstrating the application in Figure 6.1
* *SimpleCurrencyConverterBindings* - Model binding simple properties. Demonstrates Table 6.1, binding to route parameters, form parameters and the querystring
* *ExampleBinding* - Binding a custom class using Model Binding
* *ListBinding* - Model binding to collections, as shown in Figure 6.5
* *ValidatingWithDataAnnotations* - A dummy checkout page, demonstrating Model validation using various `DataAnnotations`. Also shows POST-REDIRECT-GET
* *CurrencyConverter* - A dummy currency converter application. Demonstrates model binding, `DataAnnotations`, and a custom validation attribute

## [Chapter 7](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter07)
* *DefaultMVCProject* - Default MVC template, showing how you can sepecify the template to Render. The `HomeController` specifies alternative views to render at the urls [http://localhost:64594/Home/IndexThatRendersContact](http://localhost:64594/Home/IndexThatRendersContact) and  [http://localhost:64594/Home/IndexThatRendersAbout](http://localhost:64594/Home/IndexThatRendersAbout) using two different methods 
* *DynamicHtml* - Example of creating dynamic HTML by using C# in Razor templates.
* *ManageUsers* - Display a list of users, and allow adding new users, as shown in figure 7.3
* *ToDoList* - Example of writing model values to HTML in Razor templates, as shown in section 7.2
* *NestedLayouts* - Demonstrates using a nested layout, where a two column layout, `_TwoColumn.cshtml` is nested in `_Layout.cshtml`.
* *PartialViews* - Demonstrates extracting common code into a partial view, as in section 7.4.3. Also shows adding additional namespace to _ViewImports for `PartialViews.Models` namespace.

## [Chapter 8](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter08)
* *CurrencyConverter* - A demo currency converter application using TagHelpers to generate form elements.
* *TagHelpers* - Demonstrates the input types generated for various property types and `DataAnnotations`, as described table 8.1. Also demonstrates displaying a banner based on the current environment, as shown in section 8.5.
* *SelectLists* - Generating a variety of select lists, as shown in section 8.2.4

## [Chapter 9](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter09)
* *AngularWebApplication1* - A basic Angular web application, as shown in Figure 9.1, created using the JavaScript services template. Follow the instructions at https://blogs.msdn.microsoft.com/webdev/2017/02/14/building-single-page-applications-on-asp-net-core-with-javascriptservices/ to try it for yourself.
* *BasicWebApiProject* - A basic web api project, using default MVC conventional routing, returning a list of fruit, as in 9.3
* *CarsWebApi* - A single Cars WebAPI controller that demonstrates various different response types. Use https://www.getpostman.com to make requests to the API

## [Chapter 10](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter10)
* *SendingAnEmailWithoutDI* - An example demonstrating a use case where you want to send an email when a user registers. The `EmailSender` class is created in code using `new` as shown in section 10.1.1 and Listing 10.3.
* *SendingAnEmailWithDI* - A refactoring of the *SendingAnEmailWithoutDI* project to use DI, showing how the `UserController` has been simplified
* *InjectingMultipleImplementations* - Example demonstrating the behaviour when registering multiple instances of a service, as in section 10.2.4. Click the buttons shown on the home page and observe the console output to see the effect of the DI configuration
* *LifetimeExamples* - The effect of lifetime on DI. For details, see section 10.3 - the project broadly follows this outline, with slightly different naming to allow registering all the services in a single project

## [Chapter 11](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter11)
* *StoreViewerApplication* - A sample application to demonstrate loading values from configuration, and bindingin them to a strongly typed `IOptions` object. You can also view how different property types can be bound, such as the example in section 13.3.3 by viewing the path `/Test`

## [Chapter 12](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter12)
* *RecipeApplication* - A sample application created in chapter 12 demonstrating using EF Core. You will need to run the database migrations to create the database, by running `dotnet ef database update` from the project folder. The connection string is specified in appsettings.json, and uses SQL Server LocalDb

## [Chapter 13](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter13)
* *FilterPipelineExample* - A sample application that contains one of each filter, and logs when the filter runs. Each filter contains commented out code to short-circuit the pipeline. Uncomment the code from each filter in turn to see the effect
* *RecipeApplication* - The RecipeApplication from chapter 12 plus an API controller. The `NoApiController` includes the code from listing 13.6, while the `RecipeApiController` includes the code from listing 13.7 where the code is refactored to use filters.

## [Chapter 14](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter14)
* *DefaultTemplate* - The default MVC template for ASP.NET Core with Authentication, as discussed in seciont 14.3.
* *RecipeApplication* - The recipe application from chapter 13 with authentication added, as described in section 14.4.
* *RecipeApplicationWithNameClaim* - The recipe application with an additional field added to the `RegisterViewModel` to record the `FullName`, as described in section 14.5. The field is added as an extra claim when the user registers, and is dispayed in the menu bar when a user logs in.

## [Chapter 15](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter15)
* *Airport* - An analogy to the airport example presented in section 15.1. There are 4 steps, Home Page, Through security, Enter airport lounge, Board the place. You can set the claims for a user when you register. Which claims you add will determine how far through you can get.
* *RecipeApplication* - The recipe application from previous chapters, with authorization to prevent unauthorized users creating recipes, and resourec based authorization to ensure only the user which created a recipe can edit it.

## [Chapter 16](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter16)
* *RecipeApplication* - The Recipe application from previous chapters, for hosting in IIS. Changed the LocalDb migrations and connection string to use SqlLite as connecting to a LocalDb instance from IIS can be problematic. Also, added additional JS and CSS files to demonstrate bundling aand minifying, and updated *bundleconfig.json*
* *SettingHostConfiguration* - Configuring `IWebHost` by loading from a JSON file instead of using the `ASPNETCORE_ENVIRONMENT` and `ASPNETCORE_URLS` variables, as described in section 16.3.2. The *hosting.json* file is loaded into an `IConfiguration` and passed to the `WebHostBuilder` using `UseConfiguration`.

## [Chapter 17](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter17)

* *RecipeApplication* - The recipe application from previous chapters with some additional logging
* *FileLogger* - A simple Web API Project configured to write log messages to a rolling file by using a rolling file logging provider, as shown in section 17.3.1.
* *LogFiltering* - A simple Web API Project configured to use the configuration filters defined in section 17.4.
* *SerilogLogger* - A simple Web API Project configured to write log messages to the console using Serilog, as shown in section 17.3.2
* *SeqLogger* - A simple web API project to demonstrate structured logging using Seq, and using scopes to add additional properties to a log, as shown in section 17.5.

## [Chapter 18](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter18)

* *KestrelWithHttps* - A basic web api using Kestrel with Https directly. Shows using the `Listen` method to specify the URLs to use, overriding the default values set in _launchSettings.json_. The certificate is self-signed as described in section 18.1. 

On Windows, you can generate a certificate using the *Install-Certificate.ps1* PowerShell script. This will create a self-signd certificate and trust it on Windows.

You can generate a certificate on Ubuntu using *install_certificate.sh*. This uses *localhost.conf* to create a self signed certificate, and trusts it. On Linux, not all applications use the same store, so you may have to trust it explicitly for those applications. Use password `testpassword` to create the certificate.

Three endpoints are configured:

1. An http endpoint at http://localhost:5001/api/values
2. An https endpoint configured directly in code at https://localhost:5002/api/values
3. An https endpoing configured externally by loading from _hosting.json_  at https://localhost:5003/api/values

> The path `/api/values/1` has been decorated with a `[RequireHttps]` attribute, which will force the URL to redirect from http to https. Note however, that as we are not using the standard https port (443), the redirect will not work for this example. Alternatively you can enforce SSL across the whole site by uncommenting the RewriterMiddleware in `Startup.Configure`.


* *CrossSiteScripting* - A simple app to demonstrate XSS attacks due to not encoding user input. The user submits content which is added to an internal list and is later rendered to the page. Using `@Html.Raw` renders the provided input exactly as it was entered - if the content is malicious, e.g. a `<script>` tag, then it is written into the page as a script tag, executing any code it contains. Instead, you should render content with the `@` symbol alone - that way the content is rendered as a string, and can be displayed safely.

* *CrossSiteRequestForgery* - A pair of apps to demonstrate a CSRF vulnerability. You can login to the banking application and view your balance. You can 'withdraw' funds using the provided form, and you'll see your balance reduce. The attacker website contains a form that posts to the banking application and withdraws funds for the currently logged in user. In the example you have to click the button to see the vulnerability, but this could easily be automated. To protect the endpoint, add the `[ValidateAntiForgeryToken]` attribute to the `BalanceController.Withdraw()` action.

## [Chapter 19](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter19)

* *CustomMiddleware* - Various custom middleware, using, `Map`, `Run`, `Use`, and middleware classes,  as described in section 19.1.
* *CustomConfiguration* - Loading configuration in multiple stages and described in section 19.2.
* *StructureMapExample* - Replacing the default DI container with Structuremap, as in section 19.3.
* *CustomTagHelpers* - Creating custom Tag Helpers, an `IfTagHelper` and `SystemInfoTagHelper`, as shown in section 19.4.
* *RecipeApplication* - The Recipe Application from previous chapters, this time with a custom view component, as described in section 19.5.
* *CurrencyConverter* - The demo Currency converter application, containing a custom validation attribute for validating the selected currencies, as in section 19.6.

## [Chapter 20](https://github.com/andrewlock/asp-dot-net-core-in-action/tree/master/chapter20)

* *ExchangeRates* - A basic exchange rate application. Includes unit tests for the `CurrencyConverter` class, for the `StatusMiddleware`, and for both MVC and Web API controllers. Also includes integration tests for the `StatusMiddleware` and for MVC pages.

* *RecipeApplication* - Testing a service that relies on an EF Core `DbContext`, as described in section 20.6. The `RecipeServiceTests` class shows how you can test the `RecipeService`. 
