Formatting Guid

## Installings

```bash 
    // Install package in the solution
    dotnet tool install -g Black.Beard.Jslt.Services
```

```CSharp
    // add the assembly in the configuration for discover all methods
    var configuration = new TranformJsonAstConfiguration()
                .AddAssembly(typeof(Bb.Jslt.Services.AddedServices))
                ;
```


OR

```CSharp
    // add the assembly in the configuration for discover all methods
    var configuration = new TranformJsonAstConfiguration()
                .AddPackage(typeof(Black.Beard.Jslt.Services))
                ;
```

OR

```JSON
    // add the assembly in the configuration directly in the json file for discover all methods
"$directives":
{
   "culture":"FR-fr",
   "packages":["Black.Beard.Jslt.Services"],
}   
``` 

## Excel
Load and use excel file
```JSON
{
   "propertyName": loadxls("path to the excel file", "path to the config")
}   
``` 

```JSON
{
   "propertyName": loadxls("path to the excel file", 
    // configuration
    { 
        "FirstRowHasColumnName" : true, 
        "HeaderLine" : 4, 
        "Tablename": "Table1", 
        "AddRowNumber": true, 
        "ByPassEmptyObject": true 
    }
}   
``` 


## Html
Load and use html document. Note the path can be file or an url.
```JSON
{
   "propertyName": loadxls("path to the document")
}   
``` 


## Sql
Get data from any databases
```JSON
{

    // Add package SqlLite in the configuration
    "$directives":
    {
       "culture":"FR-fr",
       "packages":["Black.Beard.Jslt.Services", "Microsoft.Data.Sqlite"],
    },

   // connect to database
   "@cnx": connectsql("Microsoft.Data.Sqlite", "Data Source={db}"),

    // read data from the database
    "datas" : readsql(@cnx, "SELECT * FROM table1")

}   
``` 


## Phone
```JSON
{
    "phone": phoneisvalid("phone number", "CODE ISO 2")
}   

