# antlr-4.7-complete.jar must be preset 
# http://www.antlr.org/download/antlr-4.7-complete.jar

java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp ElasticLexer.g4 -visitor -no-listener -package Bb.Elastic.Lexer
java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp ElasticParser.g4 -visitor -no-listener -package Bb.Elastic.Parser
