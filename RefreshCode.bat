

REM used for copy the git repository expression "https://github.com/Black-Beard-Sdk/Black.Beard.Expressions"

del .\src\Black.Beard.Jslt\git.Expressions\*.cs
del .\src\Black.Beard.Jslt\git.Expressions\Exceptions\*.cs
del .\src\Black.Beard.Jslt\git.Expressions\Expressions\*.cs
del .\src\Black.Beard.Jslt\git.Expressions\Expressions\Statements\*.cs

xcopy ..\Black.Beard.Expressions\Src\Black.Beard.Expressions\*.cs .\src\Black.Beard.Jslt\git.Expressions /s
REM xcopy ..\Black.Beard.Expressions\Src\Black.Beard.Expressions\Exceptions\*.cs .\src\Black.Beard.Jslt\git.Expressions\Exceptions
REM xcopy ..\Black.Beard.Expressions\Src\Black.Beard.Expressions\Expressions\*.cs .\src\Black.Beard.Jslt\git.Expressions\Expressions

del .\src\Black.Beard.Jslt\git.Expressions\obj\Debug\netstandard2.0\*.cs
rmdir .\src\Black.Beard.Jslt\git.Expressions\obj\Debug\netstandard2.0
rmdir .\src\Black.Beard.Jslt\git.Expressions\obj\Debug
rmdir .\src\Black.Beard.Jslt\git.Expressions\obj

pause