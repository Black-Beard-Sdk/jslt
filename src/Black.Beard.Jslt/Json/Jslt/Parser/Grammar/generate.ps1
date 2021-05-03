# antlr-4.7-complete.jar must be preset 
# http://www.antlr.org/download/antlr-4.7-complete.jar

java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp JsltLexer.g4 -visitor -no-listener -package Bb.Json.Jslt.Parser
java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp JsltParser.g4 -visitor -no-listener -package Bb.Json.Jslt.Parser