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
   | jsonValueBoolean
   | jsonValueString
   | jsonValueInteger
   | jsonValueNumber
   | jsonValueNull
   | jsonLt
   ;

jsonValueString : STRING;
jsonValueNumber : NUMBER;
jsonValueInteger : INT;
jsonValueBoolean : TRUE | FALSE;
jsonValueNull : NULL;

// ---------------------------- extended json ----------------------------
jsonCtor :
   NEW ID PAREN_LEFT jsonValueList? PAREN_RIGHT
   ;

jsonValueList : 
   jsonValue (COMMA jsonValue)*
   ;

// ---------------------------- jslt ----------------------------

jsonLt : 
     jsonLtItem (PIPE jsonLtItem)*
   ;

jsonLtItem : 
     jsonpath
   | jsonCtor
   ;

// ---------------------------- json path ----------------------------

jsonpath : 
   ROOT_VALUE subscript?
   ;

subscript :
     RECURSIVE_DESCENT ( subscriptableBareword | subscriptables ) subscript?
   | SUBSCRIPT subscriptableBareword subscript?
   | subscriptables subscript?
   ;

subscriptables :
   BRACKET_LEFT subscriptable ( COMMA subscriptable )* BRACKET_RIGHT
   ;

subscriptableBareword :
     ID
   | WILDCARD_SUBSCRIPT
   ;

subscriptable :
     STRING
   | NUMBER? sliceable?
   | sliceable
   | WILDCARD_SUBSCRIPT
   | QUESTION PAREN_LEFT expression PAREN_RIGHT
   ;

sliceable :
   COLON NUMBER? (COLON NUMBER? )?
   ;

expression :
   andExpression
   ;

andExpression :
   orExpression ( AND andExpression )?
   ;

orExpression :
   notExpression ( OR orExpression )?
   ;

notExpression : 
     NOT notExpression
   | PAREN_LEFT expression PAREN_RIGHT
   | ( ROOT_VALUE | CURRENT_VALUE ) subscript? ( ( EQ | NE | LT | LE | GT | GE ) jsonValue )?
   ;
