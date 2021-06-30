

REM used for copy the git repository expression "https://github.com/Black-Beard-Sdk/Black.Beard.Expressions"

del .\src\\Black.Beard.Elasticsearch\*.cs
del .\src\Black.Beard.Elasticsearch\Helpers\*.cs
del .\src\Black.Beard.Elasticsearch\Runtimes\*.cs
del .\src\Black.Beard.Elasticsearch\Runtimes\Models\*.cs
del .\src\Black.Beard.Elasticsearch\Runtimes\Visitors\*.cs

del .\src\Black.Beard.Elasticsearch\SqlParser\*.cs
del .\src\Black.Beard.Elasticsearch\SqlParser\Grammar\*.cs
del .\src\Black.Beard.Elasticsearch\SqlParser\Grammar\.antlr\*.cs
del .\src\Black.Beard.Elasticsearch\SqlParser\Models\*.cs



xcopy ..\sqlquery2elasticquery\src\Black.Beard.Elasticsearch\*.cs .\src\Black.Beard.Elasticsearch /s

REM xcopy ..\Black.Beard.Expressions\Src\Black.Beard.Expressions\Exceptions\*.cs .\src\Black.Beard.Jslt\git.Expressions\Exceptions
REM xcopy ..\Black.Beard.Expressions\Src\Black.Beard.Expressions\Expressions\*.cs .\src\Black.Beard.Jslt\git.Expressions\Expressions

REM del .\src\Black.Beard.Jslt\git.Expressions\obj\Debug\netstandard2.0\*.cs
REM rmdir .\src\Black.Beard.Jslt\git.Expressions\obj\Debug\netstandard2.0
REM rmdir .\src\Black.Beard.Jslt\git.Expressions\obj\Debug
REM rmdir .\src\Black.Beard.Jslt\git.Expressions\obj

pause