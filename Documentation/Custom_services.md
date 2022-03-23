
## **Syntax for calling function**
```JSON
{ "result" : method(arg1, arg2, ...) }
``` 

## **Distinct**
Return a unique list in the source that match withe the pattern
```JSON
{ "result" : distinct("source", "json path to match" @string) }
``` 

## **Group**
Return group from list a unique list in the source that match withe the pattern
```JSON
{ "result" : group("$.source", [ "$.pattern1" @string ]) }
``` 

```JSON
{ "result" : [ 
    {
        "Label" : "Item1", 
        "Items" : [ 
          { 
            "pattern1" : "Item1",
            <object> 
          } 
        ]
    }
]
``` 

## **Union**
Return an unified list of specified items
```JSON
{ "result" : union([ [<array 1>], [<array 2>], {<object 1>}  ]) }
``` 

## **select**
Return a single selection specified by the json path
```JSON
{ "result" : select( {<object>}, "json path" @string ) }
``` 

## **select**
Return a many selection specified by the json path
```JSON
{ "result" : selectmany( {<object>}, "json path" @string ) }
``` 

## **limit**
Return a list of x items
```JSON
{ "result" : limit( [<items>], 10 }
``` 

## **loadjson**  
```JSON
{ "result" : loadjson("path to json document") }
``` 

## **loadcsv**  
```JSON
{ "result" : loadjson("path to csv document", "hasHeader", "separator", "quote", "escape") }

// By default 
{ "result" : loadjson("path to csv document", true, null, null, null) }

// is equivalent to
{ "result" : loadjson("path to csv document", true, ";", "\"", "\\") }

``` 

## **loadmcsv**  
```JSON
{ "result" : loadjson("path to multi header csv document", "rulePayload") }

/*
    Rule payload sample : 
    PARENT : CHILD1;                    // Child1 is embedded in the parent
    CHILD1 : SUBCHILD1 | SUBCHILD2;     // subchild1 or subchild2 are embbed in child1
*/

// Sample 
{ "result" : loadjson("\\documentFile.dat", "PARENT:CHILD1;CHILD1:SUBCHILD1|SUBCHILD2;") }


``` 

## **loadhtml**  
the path can be a local file or a web url. the load is implemented be http agility pack.
```JSON
{ "result" : loadhtml("path to load and convert") }
``` 

## **loadxls**  
The excel file will be loaded an translated in json document.
```JSON
{ "result" : loadxls("path to excel document", "path to excel configuration document") }
``` 

## **readsqlserver**  
The sql result will be loaded an translated in json document. Note the parameters are not managed. not yet.
```JSON
{ "result" : readsqlserver("connection string", "SELECT * FROM myTable") }
``` 

## **loadhttpgetJson**  
call an api and return the content like a json document.
```JSON
{ "result" : loadhttpgetJson("root path", "method name") }
``` 

## **Concat**  
Concat input stream of type text. 
```JSON
// if you want generate a part of csv
//    the first string value is the split char
//    the second string value is the delimiter char
{ "result" :  .concat("$..properties", ",", "\")  }

// or if you want juste concatenate witout decorator
{ "result" : concat("$..properties", null, null)  }
```

## **Sum**  
return the sum of array of numeric
```JSON
"Syntax" : sum("$..n") }
```

## **Crc32**  
Compute Crc32 checksum  
```JSON
{ "Syntax" : crc32("test") }
```

## **Generate id**  
Generate guid
```JSON
{ "Syntax" : uuid() }
```

## **Format**  
return a formatted text

if the value is integer the formatting documentation is [here](Format_integer.md)  
if the value is double the formatting documentation is [here](Format_double.md)  
if the value is datetime the formatting documentation is [here](Format_DateTime.md)  
if the value is guid the formatting documentation is [here](Format_Guid.md)  
if the value is timespan the formatting documentation is [here](Format_Timespan.md)  

```JSON
{ "Syntax" : format(<value>, "G", "fr-FR") }
```

## **parsedate**  
Converts the string representation of a date and time to its DateTime equivalent by using culture-specific format information.  [here](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=net-5.0#System_DateTime_Parse_System_String_System_IFormatProvider_)

```JSON
{ "Syntax" : parsedate("<value>", "G", "fr-FR") }
```
## **ToBase64**  
return a text encoded base 64
```JSON
{ "Syntax" : tobase64("test") }
```

## **Frombase64**  
return text of value encoded in base 64  
```JSON
"Syntax" : frombase64("payload") }
```

## **Now**  
return the current date and time  
```JSON
{ "$type" : utc(true) }
```

## **Sha256**  
return the hash of Sha256 algorithm  
```JSON
"Syntax" : sha256("") }
```

## **Sha512**  
return the hash of Sha512 algorithm
```JSON
"Syntax" :  sha512("") }
```

## **regexismatch**
Make a regular expression matches that return true or false
```JSON
{ "result" : regexismatch( "<data to evaluate>", "<pattern>" }
``` 

## **regexmatches**
Make a regular expression matches that return the list of matches
```JSON
{ "result" : regexismatch( "<data to evaluate>", "<pattern>" }
``` 

## **SubStr**  
Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length. A string that is equivalent to the substring of length length that begins at startIndex in this instance, or System.String.Empty if startIndex is equal to the length of this instance and length is zero.

```JSON
{ "Syntax" : substr("<value>", "<start position>", "<length>") }
```
## **stringlenght**  
return the lenght of the string
```JSON
{ "Syntax" : stringlenght("<value>") }
```

## **stringcontains**  
return true if the value contains the string chain
```JSON
{ "Syntax" : stringcontains("<value>", "<char>") }
```

## **lower**  
Returns a copy of this string converted to lowercase.
```JSON
{ "Syntax" : lower("<value>") }
```

## **upper**  
Returns a copy of this string converted to uppercase.
```JSON
{ "Syntax" : upper("<value>") }
```

## **startswith**  
 Determines whether the beginning of this string instance matches the specified string. return true if value matches the beginning of this string; otherwise, false.
```JSON
{ "Syntax" : startswith("<value>", "The string to compare") }
```

## **endswith**  
Determines whether the end of this string instance matches the specified string.
return true if value matches the end of this instance; otherwise, false.
```JSON
{ "Syntax" : endswith("<value>", "The string to compare") }
```

## **trim**  
The string that remains after all occurrences of the characters in the trimChars parameter are removed from the start and end of the current string. If trimChars is null or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current
        //     instance unchanged.
```JSON
{ "Syntax" : trim("<value>", "All Unicode characters to remove") }
```

## **indexof**  
Reports the zero-based index of the first occurrence of the specified string in this instance.
```JSON
{ "Syntax" : indexof("<value>", "The string to seek.") }
```

## **lastindexof**  
 Reports the zero-based index position of the last occurrence of a specified string within this instance.
```JSON
{ "Syntax" : lastindexof("<value>", "The string to seek.") }
```

## **normalize**  
Returns a new string whose textual value is the same as this string, but whose binary representation is in Unicode normalization form C.
```JSON
{ "Syntax" : normalize("<value>") }
```

## **padleft**  
A new string that is equivalent to this instance, but right-aligned and padded on the left with as many paddingChar characters as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.

Argument **totalWidth** : The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.
        
Argument **paddingChar** : A Unicode padding character.
```JSON
{ "Syntax" : padleft("<value>", <totalWidth>, "paddingChar") }
```

## **padright**  
A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.

Argument **totalWidth** : The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.
        
Argument **paddingChar** : A Unicode padding character.

```JSON
{ "Syntax" : padright("<value>", <totalWidth>, "paddingChar") }
```

## **split**  
Splits a string into substrings based on the provided character separator.
The result is an array
```JSON
{ "Syntax" : split("<value>", "<charset for split>") }
```
