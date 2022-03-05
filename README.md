# jslt (json Stylesheet Language Transformations)

[![Build status](https://ci.appveyor.com/api/projects/status/9uj618usw1xuqt8r?svg=true)](https://ci.appveyor.com/project/gaelgael5/jslt)

Implementation of jslt language in DOTNET. Use a template for transform Json To another json. Consider the following template. note this template is a json that describe the structure of the target json. If the template is empty, the process return the initial source json.

## Case 1 ##  

For the template document

```JSON
    { "n" : "name1" }
```

The result will be.

```JSON
    { "name" : "name1" }
```
In this case the result is exactly what you have in the template, because you have not used any operations of transformation.


## Case 2 ##
In this case, the value is a json path. Json path is a query language for JSON, similar to XPath for XML. The implementation of JsonPath is did by newtonsoft. [SelectToken] by the method (https://www.newtonsoft.com/json/help/html/SelectToken.htm).
```JSON
    { "name" : "$.n" }
```

The result will be an object with a property named "name" and the value will be the properties "n" at the root of the source json. The value '$..n' is a valid json path implemented by newtonsoft. 

## Case 3 ##
you can use functions for extend the process. 

Like that
```JSON
    "property name": .mymethod( "$.property", arg2, ...)
```

**'mymethod'** is the name of the service you want to call. The sdk provide another keys like sum or distinct. the list is available [here](Documentation/Custom_services.md).
If you write your own method, you must register the methods before in the configuration. the arguments must be any json part (see the directives for register your extension).

A sample for call the method
```JSON
// Source
{ "prices": [{"n" : 1}, {"n" : 2}, {"n" : 3}] }

// Template
{ "prices": sum("$..n") } // sum method is a service registered in the services list.

// Result
{ "prices":  6 }
```  

### Note
if the string start with '\$' the value is automatically convert in json path. if the method expect a string you must cast the value.

```JSON
{ "prices": method("$..n" @string) } 
```  

### cast
for cast a value you must use this syntax '@type'
* @uri
* @time
* @datetime
* @string
* @guid
* @integer 
* @decimal

### Custom services
the customs services are used to extend the feature of the Sdk. You can create your own customs services.

That is the skeleton
```CSHARP
[JsltExtensionMethod("method1")] // name of the method in the template
public static JToken ExtendTheSdkMethod1(RuntimeContext ctx)
{
    return new JValue("result");
}
```

I give you the method loadjson like sample
```CSHARP
[JsltExtensionMethod("loadjson")] // name of the method in the template
[JsltExtensionMethodParameter("sourcePath", "directory source path")] // Provide intellisense in the code editor.
public static JToken ExecuteLoadSource(RuntimeContext ctx, string sourcePath)
{

    // Use the system for resolve the file with path relative to the current template script.
    var file = ctx.Configuration.ResolveFile(sourcePath);

    if (file.Exists)
        return file.FullName
            .LoadContentFromFile()
            .ConvertToJson();
        else
        {
            ctx.Diagnostics.AddDiagnostic(Parser.SeverityEnum.Warning, string.Empty, new Parser.TokenLocation(), "file.FullName", $"file '{file.FullName}' not found");
        }

    return JValue.CreateNull();

}
```  
Note, that you can add any parameter.

### Disclaimer
If you use a easy treatement, the template is a valid json structure. If you want do more the json syntax become verbose. It is for this reason I have extended the json syntax.


### when
the method when is very usefull. it is a switch case.

```JSON
{
    "prices": when("$.prop1" @string) 
    {
        "case1": { /* structure to inject if the value of '$.prop1' is equal to 'case1' */ }
    }
} 
```  

## How to use
### Command line
You can use the command line json.exe.
[Documentation of json cli](Documentation/jsonexcutable.md).  

### By code 
```CSHARP
// Intialization of the configuration
var configuration = new TranformJsonAstConfiguration()
{
    OutputPath = Environment.CurrentDirectory,
};

// add a custom service : Note the services in the sdk are already registered
configuration.Services.ServiceDiscovery.AddService("serviceName", typeof(service));
// if you want to implement your service : use and implemente the interface Bb.Json.Jslt.Services.ITransformJsonService                

TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);

//Build the template translator
StringBuilder sbPayloadTemplate = new StringBuilder(@"payload template");
JsltTemplate template = Templateprovider.GetTemplate(sbPayloadTemplate, false, "name of the template file");


// now the source json
// from text
var source1 = SourceJson.GetFromText("payload");
// from file
var source2 = SourceJson.GetFromFile("filename");
// from json
var source3 = SourceJson.GetFromJson(new JObject());

// Create the sources object with the primary source of data
var src = new Sources(source1);
// you can add additional source of datas
src.Add(source2);
src.Add(source3);

// Add a value for for accessing from the template
src.Variables.Add("My value", new JValue(1));

RuntimeContext ctx = template.Transform(src);
var result = ctx.TokenResult;

```

## JSONPath notation

A JSONPath expression specifies a path to an element (or a set of elements) in a JSON structure. Paths can use the dot notation:
The implementation is provided by newtonsoft.

[Documentation of json path](Documentation/jsonpath.md)  


## Custom services embedded in the Sdk
[Documentation of the Services](Documentation/Custom_services.md)  

## Directives of compilation
You can manage any directives

### Sample
```JSON
"$directives":
{
   "culture":"FR-fr",
   "assemblies":["assembly name referenced in the gac"],
   "functions":["path of the csharp file"],
   "packages":["path of the package on nuget.org"],
   "imports": ["path of the assembly flie"],
   "output": 
   {
       "filter": "$.datas", // It is json path for filter just one part of the output document
       "Mode": to_block()  // Behavior the output serialization
   }
}   

``` 

### culture
Set the culture of the process. The Culture specifies a unique name for each culture, based on RFC 4646. The name is a combination of an ISO 639 two-letter lowercase culture code associated with a language and an ISO 3166 two-letter uppercase subculture code associated with a country or region. In addition, for apps that target .NET Framework 4 or later and are running under Windows 10 or later, culture names that correspond to valid BCP-47 language tags are supported.

### imports
Take a list of assemblies files. the path is relative to the json template file.

### assemblies
Take a list of assemblies name referenced in the GAC.

### Functions
Take a list of c# source code file. the path is relative to the json template file.
The file contains Csharp source code like this class [see the DistinctService like sample](src/Black.Beard.Jslt/Json/Jslt/CustomServices/Services.distinct.cs)

### Packages
You can use 
```JSON
"$directives":
{
   "packages": ["path of the assembly file on nuget"],
}

// or 

"$directives":
{
   "packages": [ ["https://www.nuget.org/api/v2/package/", "path of the assembly file"] ],
}

``` 


### output
the output manage the serialization

#### Filter
Select just a part of the output document

#### Mode
Mode is a function that serialize the output document.

##### to_block()
If the output is an array
all lines are serialized (one object by line)

##### to_json(bool indented, bool ignoreNullAndEmptyValues)
serialize the output in classical serialization

You can write your own serialize service. The returned type must be a StringBuilder
```CSHARP

[JsltExtensionMethod("to_block", ForOutput = true)]
public static StringBuilder ExecuteToBlock(RuntimeContext ctx)
{

    var source = ctx.TokenResult;
    var result = new StringBuilder();

    if (source is JObject o)
        result.AppendLine(o.ToString(Newtonsoft.Json.Formatting.None));

    else if (source is JArray a)    
        foreach (var item in a)
            result.AppendLine(item.ToString(Newtonsoft.Json.Formatting.None));
    
    return result;

}

``` 