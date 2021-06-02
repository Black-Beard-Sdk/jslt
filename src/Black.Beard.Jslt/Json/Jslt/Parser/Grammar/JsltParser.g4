/**
 * json transform engine Parser
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

parser grammar JsltParser;

options { 
    // memoize=True;
    tokenVocab=JsltLexer; 
    }

script :
    json
    EOF
    ;


// ---------------------------- json ----------------------------
/* c.f., https://github.com/antlr/grammars-v4/blob/master/json/JSON.g4 */

json :
   jsonValue
   ;

obj : 
     BRACE_LEFT pair ( COMMA pair )* BRACE_RIGHT
   | BRACE_LEFT BRACE_RIGHT
   ;

pair : 
   STRING COLON jsonValue
   ;

array :
     BRACKET_LEFT jsonValue ( COMMA jsonValue )* BRACKET_RIGHT
   | BRACKET_LEFT BRACKET_RIGHT
   ;

jsonValue :
     obj
   | array
   // | jsonValueBoolean
   // | jsonValueString
   // | jsonValueInteger
   // | jsonValueNumber
   // | jsonValueNull
   | jsonLtOperation
   //| jsonValueCodeString
   ;

jsonValueString : STRING jsonType?;
//jsonValueCodeString : CODE_STRING;
jsonValueNumber : NUMBER;
jsonValueInteger : INT;
jsonValueBoolean : TRUE | FALSE;
jsonValueNull : NULL;
jsonType : CURRENT_VALUE (URI | TIME | DATETIME | STRING_ | GUID | INTEGER | DECIMAL);

// ---------------------------- jslt ----------------------------

jsonLtOperation :
     jsonLtItem
   | NT jsonLtOperation
   | PAREN_LEFT jsonLtOperation PAREN_RIGHT
   | jsonLtOperation operation jsonLtOperation
   ;

jsonLtItem : 
     jsonfunctionCall 
   | jsonValueBoolean
   | jsonValueString
   | jsonValueInteger
   | jsonValueNumber
   | jsonValueNull
   | jsonType
   ;

operation : 
     EQ | GE | GT | LE | LT | NE 
   | PLUS | MINUS | DIVID | MODULO | WILDCARD_SUBSCRIPT | POWER
   | CHAIN
   | AND | OR | AND_EXCLUSIVE | OR_EXCLUSIVE
   | COALESCE
   ;

// ---------------------------- extended json ----------------------------

jsonfunctionCall :
   DOT_ID PAREN_LEFT jsonValueList? PAREN_RIGHT obj?
   ;

jsonValueList : 
   jsonValue (COMMA jsonValue)*
   ;



