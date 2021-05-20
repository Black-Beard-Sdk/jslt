# jslt (json Stylesheet Language Transformations)
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
In this case the result is exactly what you have in the template, because you have not used any operation of transformation.


## Case 2 ##
In this case, the value is a json path. Json path is a query language for JSON, similar to XPath for XML. The implementation of JsonPath is did by newtonsoft. [SelectToken](https://www.newtonsoft.com/json/help/html/SelectToken.htm).
```JSON
    { "name" : "$.n" }
```

The result will be an object with a property named "name" and the value will be the properties "n" at the root of the source json. The value '$..n' is a valid json path implemented by newtonsoft. 

If you use a easy treatement, the template is a valid json structure. If you want do more the json syntax become verbose. It is for this reason I have extended the json syntax.

```JSON
    "property name": .mymethod( "$.property", arg2, ...)
```

**'mymethod'** is the name of the service you need to call. You must to register the methods before in the configuration. the arguments can be any json part.  
The sdk provide another keys like sum or distinct. the list is available [here](Documentation/Custom_services.md)

```JSON
// Template
{ "prices": .sum("$..n") } // service sum is before registered in the services list.

// Source
{ "prices": [{"n" : 1}, {"n" : 2}, {"n" : 3}] }

// Result
{ "prices":  6 }

```  

## How to use

```CSHARP
// Intialization of the configuration
var configuration = new TranformJsonAstConfiguration()
{
    Path = Environment.CurrentDirector,
};

// add a custom service : Note the services in the sdk are already registered
configuration.Services.ServiceDiscovery.AddService("serviceName", typeof(service));
// if you want to implement your service : use interface Bb.Json.Jslt.Services.ITransformJsonService                

TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);

//Build the template translator
StringBuilder sbPayloadTemplate = new StringBuilder(@"payload template");
JsltTemplate template = Templateprovider.GetTemplate(sb, "name of the template file");


// now the source json
// from text
var source1 = SourceJson.GetFromText("payload");
// from file
var source2 = SourceJson.GetFromfile("filename");
// from json
var source3 = SourceJson.GetFromJson(new JObject());

// Create the sources object with the primay source of data
var src = new Sources(source1);
// you can add additional source of datas
src.Add(source2);
src.Add(source3);

RuntimeContext ctx = template.Transform(sbSource);
result = ctx.TokenResult;

```

## JSONPath notation

A JSONPath expression specifies a path to an element (or a set of elements) in a JSON structure. Paths can use the dot notation:
The implementation is provided by newtonsoft.

[Documentation of json path](Documentation/jsonpath.md)  




## Custom services embedded in the Sdk
## **Add**  
Add the arguments. Note the values must be numeric (integer or float)
```JSON
"Syntax" : { "$type" : "add", "$left":"<value>", "$right":"$value" }
```



* Consume the flow of data.  
Jpath select a value and the function distinct return false if the value is already matched.
```JSON
{ "$where" : "jpath:{$.property_Path} | distinct:{}" }
```

* Consume the flow of data.  
Jpath select a value and the function notnul return false if the value is null.
```JSON
{ "$where" : "jpath:{$.property_Path} | notnull:{}" }
```

