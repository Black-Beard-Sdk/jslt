/**
 * json transform engine lexer
 *
 * Copyright (c) 2017-2019 Gael beard <gaelgael5@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

lexer grammar JsltLexer;

SUBSCRIPT : '.' ;
WILDCARD_SUBSCRIPT : '*' ;
CURRENT_VALUE : '@' ;
COLON : ':';
SHARP : '#';

URI : 'uri';
TIME : 'time';
DATETIME : 'datetime';
STRING_ : 'string';
GUID : 'uuid';
WHEN : 'when';
CASE : 'case';
DEFAULT : 'default';
INTEGER : 'integer';
DECIMAL : 'decimal';

EQ : '==' ;
NE : '!=' ;
GT : '>' ;
LT : '<' ;
LE : '<=' ;
GE : '>=' ;
NT : '!';

PLUS : '+';
MINUS : '-';
DIVID : '/';
MODULO : '%';
POWER : '^';

AND : '&';
OR : '|';
AND_EXCLUSIVE : '&&';
OR_EXCLUSIVE : '||';
COALESCE : '??';

CHAIN : '->';

TRUE : 'true' ;
FALSE : 'false' ;
NULL : 'null' ;

BRACE_LEFT : '{' ;
BRACE_RIGHT : '}' ;
BRACKET_LEFT : '[' ;
BRACKET_RIGHT : ']' ;

COMMA : ',' ;
PAREN_LEFT : '(' ;
PAREN_RIGHT : ')' ;

STRING
   : '"' (ESC | SAFECODEPOINT)* '"'
   ;

MULTI_LINE_COMMENT : '/*' .*? '*/' -> skip;
//CODE_STRING :        QUOTE_CODE_STRING .*? QUOTE_CODE_STRING;
//QUOTE_CODE_STRING :  '\'\'\'';

fragment ESC
   : '\\' (["\\/bfnrt] | UNICODE)
   ;

fragment UNICODE
   : 'u' HEX HEX HEX HEX
   ;

fragment HEX
   : [0-9a-fA-F]
   ;
fragment SAFECODEPOINT
   : ~ ["\\\u0000-\u001F]
   ;

NUMBER
   : '-'? INT ('.' [0-9] +)? EXP?
   ;

INT
   : '0' | [1-9] [0-9]*
   ;

// no leading zeros

fragment EXP
   : [Ee] [+\-]? INT
   ;

// \- since - means "range" inside [...]

WS
   : [ \t\n\r]+ -> skip
   ;

ID
   : [_A-Za-z] [_A-Za-z0-9]*
   ;
DOT_ID
   : '.' [_A-Za-z]+ [_A-Za-z0-9]*
   ;
