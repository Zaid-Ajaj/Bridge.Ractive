### Intro
This library provides means to works with [Ractive.js](http://www.ractivejs.org/) with C# in your Bridge.NET project.

### Installation
To use the library in your Bridge.NET app, install it from Nuget:

```Install-Package Bridge.Ractive```

### Usage
Assuming you have a class where app state is defined 
```csharp
[ObjectLiteral]
class State { public string Message; }
```

Create an instance of `Ractive`

```csharp


var ractive = new Ractive(new RactiveOptions 
{
    Element = "#app", // the id of the element to which the template will be bound
    Template = "<h1> {{ message }} </h1>",
    Data = new State 
    {
        Message = "Hello from C#"
    }
});
```

in your html make sure to have a script tag refencing [Ractive.js](http://www.ractivejs.org/). 
