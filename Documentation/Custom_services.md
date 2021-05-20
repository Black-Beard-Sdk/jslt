# Custom services

the customs services are use to extend the feature of the Sdk.
for call the service, you must

* Add a property in the model and declare the value with '$' prefix.   
In this sample the argument "$argumentName" describe the source

```JSON
{ "result" : .method(arg1, arg2, ...) }
``` 


## **Concat**  
Concat input stream of type text. 
```JSON
// if you want generate a part of csv
//    the first string value is the split char
//    the second string value is the delimiter char
{ "result" :  .concat("$..properties", ",", "\")  }

// or if you want juste concatenate witout decorator
{ "result" : .concat("$..properties", null, null)  }
```

## **Sum**  
return the sum of array of numeric
```JSON
"Syntax" : .sum("$..n") }
```

## **Crc32**  
Compute Crc32 checksum  
```JSON
{ "Syntax" : .crc32("test") }
```

## **Generate id**  
Generate guid
```JSON
{ "Syntax" : .uuid() }
```

## **Format**  
return a formatted text

if the value is integer the formatting documentation is [here](Format_integer.md)  
if the value is double the formatting documentation is [here](Format_double.md)  
if the value is datetime the formatting documentation is [here](Format_DateTime.md)  
if the value is guid the formatting documentation is [here](Format_Guid.md)  
if the value is timespan the formatting documentation is [here](Format_Timespan.md)  

```JSON
{ "Syntax" : .format(<value>, "G", "fr-FR") }
```

## **parsedate**  
Converts the string representation of a date and time to its DateTime equivalent by using culture-specific format information.  [here](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=net-5.0#System_DateTime_Parse_System_String_System_IFormatProvider_)

```JSON
{ "Syntax" : .parsedate("<value>", "G", "fr-FR") }
```
## **ToBase64**  
return a text encoded base 64
```JSON
{ "Syntax" : .tobase64("test") }
```

## **Frombase64**  
return text of value encoded in base 64  
```JSON
"Syntax" : .frombase64("payload") }
```

## **Now**  
return the current date and time  
```JSON
{ "$type" : .utc(true) }
```

## **Sha256**  
return the hash of Sha256 algorithm  
```JSON
"Syntax" : .sha256("") }
```

## **Sha512**  
return the hash of Sha512 algorithm
```JSON
"Syntax" :  .sha512("") }
```

## **SubStr**  
return a sub string of text
```JSON
{ "Syntax" : .substr("<value>", "$start", "$length") }
```

## **Distinct**  
return false in the value is already matched in the input list
```JSON
"Syntax" : { "$type" : "distinct" }
```

