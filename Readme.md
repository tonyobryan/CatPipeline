# Catpipeline :) - A Mediatr Behavior Pipeline Demo

Simple HTTP triggered function app with one endpoint accepeting a string, and outputing that string to the user as an `StatusCodeResult`.

## Pipeline Behaviors

### LoggingBehaviour

Simple behaviour demonstrating how to produce logging before and after a Mediatr handler has fired.

### ValidationBehavior

Using the FluentValidation library, this behaviour gathers validation errors from validators relating to the current request and (if any) throws a new `ValidationException`.

### ExceptionBehavior

This is a global exception handler for the funcion, which handles any errors and formats them into a format readable by the user.

## Other Notable features

Class `BaseResponse.cs` is used to wrap all responses (`IActionResult`) from the function. Allowing the return of a message string to the user.
`BaseResponse.cs` is also used by the `ExceptionBehavior` to package any validation errors within the Message string to inform the user.
`BaseResponse.cs` extends `IStatusCodeActionResult`, allowing us to pass back a HTTP status code to the user along-side the message. See also `OkResponse.cs`.