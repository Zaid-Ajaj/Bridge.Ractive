### Intro
This library provides means to works with [Ractive.js](http://www.ractivejs.org/) with C# in your Bridge.NET project.

### Installation
The easier way to use Ractive in your Bridge.NET project is to copy and paste the contents of [Generated.Ractive.cs](https://github.com/Zaid-Ajaj/Bridge.Ractive/blob/master/Bridge.Ractive/Generated.Ractive.cs) file in your project. This way there are no binary dependencies and you can tweak it however you want.

Another way to install is from Nuget
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

The Bridge.Ractive.Example demonstrates a complete todo app with [Brige.Redux](https://github.com/Zaid-Ajaj/Bridge.Redux) as the state container

![screenshot](https://cloud.githubusercontent.com/assets/13316248/20609670/d8ea6610-b28f-11e6-8818-ebbbe7740df3.png)
