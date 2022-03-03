# antlr-4.7-complete.jar must be preset 
# http://www.antlr.org/download/antlr-4.7-complete.jar


cp ..\..\..\..\..\Black.Beard.Jslt\Json\Jslt\Parser\Grammar\*.g4 .

java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp JsltLexer.g4 -visitor -no-listener -package Bb.Parsers.Intellisense.Jslt
java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp JsltParser.g4 -visitor -no-listener -package Bb.Parsers.Intellisense.Jslt

rm *.g4