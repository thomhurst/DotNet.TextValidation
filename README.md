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
await new FunctionTextValidator(value => 
Task.FromResult(value == "") 
// Obviously put your own async logic here such as a http call
).IsValidAsync(input) // true;

```

Wrap synchronous validators so they can be used in place of an IAsyncTextValidator
```csharp
await new AsyncWrapTextValidator(new RegexTextValidator(new Regex(".+")).IsValidAsync(input));
```

Wrap multiple asynchronous validators together

```csharp
new MultipleAsyncTextValidators(
  new FunctionTextValidator(value => Task.FromResult(!string.IsNullOrEmpty(value))),
  new FunctionTextValidator(value => Task.FromResult(value.Contains("@"))),
  )
```

