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

CURRENT_VALUE : '@' ;
RECURSIVE_DESCENT : '..' ;
ROOT_VALUE : '$' ;
SUBSCRIPT : '.' ;
WILDCARD_SUBSCRIPT : '*' ;
PIPE : '|';

AND : 'and' ;
EQ : '=' ;
GE : '>=' ;
GT : '>' ;
LE : '<=' ;
LT : '<' ;
NE : '!=' ;
NOT : 'not' ;
OR : 'or' ;

NEW : 'new';

TRUE : 'true' ;
FALSE : 'false' ;
NULL : 'null' ;

BRACE_LEFT : '{' ;
BRACE_RIGHT : '}' ;
BRACKET_LEFT : '[' ;
BRACKET_RIGHT : ']' ;
COLON : ':' ;
COMMA : ',' ;
PAREN_LEFT : '(' ;
PAREN_RIGHT : ')' ;
QUESTION : '?' ;

STRING
   : '"' (ESC | SAFECODEPOINT)* '"'
   ;

MULTI_LINE_COMMENT : '/*' .*? '*/' ;
CODE_STRING:  QUOTE_CODE_STRING LANGUAGE WS .*? QUOTE_CODE_STRING;
QUOTE_CODE_STRING:  '\'\'\'';



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
   : [ \t\n\r] + -> skip
   ;

ID
   : [_A-Za-z] [_A-Za-z0-9]*
   ;

LANGUAGE
   : SUBSCRIPT [_A-Za-z] [_A-Za-z0-9]*
   ;