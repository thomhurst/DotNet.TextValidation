# TomLonghurst.TextValidation
## Unify text validation logic across your .NET application and easily mock text validation within Unit Tests

### Synchronous Text Validators

All Synchronous Text Validators Implement the `ITextValidator` interface

```csharp
var input = "";
new RegexTextValidator(new Regex(".+")).IsValid(input); // false

```

```csharp
var input = "";
new FunctionTextValidator(value => value == "").IsValid(input) // true;

```

Wrap multiple validators together

```csharp
new MultipleTextValidators(
  new FunctionTextValidator(value => !string.IsNullOrEmpty(value)).IsValid(input),
  new FunctionTextValidator(value => value.Contains("@")).IsValid(input),
  )
```

Use predefined validators

```csharp
PredefinedTextValidation.IsEmailAddress.GetValidator().IsValid("myemail@.") // false
```

### Asynchronous Text Validators

All Asynchronous Text Validators Implement the `IAsyncTextValidator` interface

```csharp
var input = "";
await new AsyncFunctionTextValidator(value => 
  Task.FromResult(value == "") 
  // Obviously put your own async logic here such as a http call
).IsValidAsync(input) // true;

```

Wrap synchronous validators so they can be used in place of an `IAsyncTextValidator`
```csharp
await new AsyncWrapTextValidator(new RegexTextValidator(new Regex(".+")).IsValidAsync(input));
```

Wrap multiple asynchronous validators together

```csharp
  new MultipleAsyncTextValidators(
    new AsyncFunctionTextValidator(value => Task.FromResult(!string.IsNullOrEmpty(value))),
    new AsyncFunctionTextValidator(value => Task.FromResult(value.Contains("@"))),
  )
```

## Dependency Injection

As explained, Asynchronous validators implement `IAsyncTextValidator` and synchronous validators implement `ITextValidator`
If you need to register more than one instance of either of these, it's recommended to create your own interfaces and wrapping classes.

Create the interface
```csharp
  public interface IEmailValidator : ITextValidator
  {

  }
```

Create the implementation
```csharp
  public class EmailValidator : IEmailValidator
  {
      private readonly ITextValidator _innerValidator = PredefinedTextValidation.IsEmailAddress.GetValidator();

      public bool IsValid(string input)
      {
          return _innerValidator.IsValid(input);
      }
  }
```

Register it in your dependency injection framework
```csharp
  _serviceProvider = new ServiceCollection()
      .AddSingleton<IEmailValidator, EmailValidator>()
      //...
```

Take that interface in the constructor of the classes you require it
```csharp
    private ITextValidator _emailValidator;
    
    public MyClass(IEmailValidator emailValidator)
    {
        _emailValidator = emailValidator;
    }
```
