## Introduction


This project is the implementation of the take home challenge. The libraries used to complete the assignment was: 

- ASP.NET Core 9
- [CSV Helper](https://joshclose.github.io/CsvHelper/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/) 
- Bootstrap 5
- [AlpineJS](https://alpinejs.dev/)
- [Htmx](https://htmx.org/)]

and my own library written by me called [RazorComponentTagHelpers](https://razor-components.techgems.net/) which as of January 2026 has approximately 37 000 downloads.

## Comments and things to improve

This project in particular has massive room for improvement, the UX can be improved with toast-like messages.

From the code side of things, some of the models used for the server components can be improved for better separation of concerns, and the filters could be made easier to work with if I were to rework them into using HTMX, which I didn't do at the beginning thinking I wasn't going to need to use the library.

Probably the most useful library in this use case was Fluent Validation, which made it easy to encapsulate the validation logic in a less obtrussive way while also keeping it more similar to a configuration file, something you cannot do with decorator validations alone.