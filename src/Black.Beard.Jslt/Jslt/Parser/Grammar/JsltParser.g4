/**
 * json transform engine Parser
 *
 * Copyright (c) 2020-2021 Gael beard <gaelgael5@gmail.com>
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

// -------------------------------- json -------------------------------
/* c.f., https://github.com/antlr/grammars-v4/blob/master/json/JSON.g4 */

json :
   jsonValue
   ;

obj : 
     BRACE_LEFT pair ( COMMA pair )* BRACE_RIGHT
   | BRACE_LEFT BRACE_RIGHT
   ;

pair : 
   string COLON jsonValue
   ;

string : STRING;

array :
     BRACKET_LEFT jsonValue ( COMMA jsonValue )* BRACKET_RIGHT
   | BRACKET_LEFT BRACKET_RIGHT
   ;

jsonValue :
     obj
   | array
   | jsonLtOperations
   ;

jsonValueString : string jsonType?;
jsonValueNumber : (signedNumber | signedInt) jsonType?;
jsonValueInteger : INT jsonType?;
jsonValueBoolean : (TRUE | FALSE) jsonType?;
jsonValueNull : NULL;
jsonType 
   : BOOLEAN_TYPE 
   | URI_TYPE 
   | TIME_TYPE 
   | DATETIME_TYPE 
   | STRING_TYPE 
   | GUID_TYPE 
   | INTEGER_TYPE 
   | DECIMAL_TYPE    
   // | CURRENT_VALUE IDLOWCASE
   ;

jsonLtOperations :
     NT? jsonLtOperation (operation jsonLtOperation)*
   | PAREN_LEFT jsonLtOperation PAREN_RIGHT jsonType? 
   ;

jsonLtOperation :
     jsonLtItem
   | NT jsonLtOperation
   | PAREN_LEFT jsonLtOperation PAREN_RIGHT jsonType? 
   ;

jsonLtItem : 
     jsonfunctionCall 
   | jsonValueBoolean
   | jsonValueString
   | jsonValueInteger
   | jsonValueNumber
   | jsonValueNull
   | jsltJsonpath
   | variable
   ;

operation : 
     EQ | GE | GT | LE | LT | NE 
   | PLUS | MINUS | DIVID | MODULO | WILDCARD_SUBSCRIPT | POWER
   | CHAIN
   | AND | OR | AND_EXCLUSIVE | OR_EXCLUSIVE
   | COALESCE
   ;

variable 
   : VARIABLE_NAME jsonType? 
   ;

// ---------------------------- extended json ----------------------------

jsonfunctionCall :
   jsonfunctionName PAREN_LEFT jsonValueList? PAREN_RIGHT jsonType? obj?
   ;

jsonfunctionName : 
   ID
   ;

jsonValueList : 
   jsonValue (COMMA jsonValue)*
   ;

jsltJsonpath : VARIABLE_NAME? jsonpath jsonType?;
jsonpath : DOLLAR jsonpath_subscript?;

// -----------   Json path   -----------

jsonpath_
   : (DOLLAR | CURRENT_VALUE) jsonpath_subscript?
   ;

jsonpath__
   : jsonpath_
   | value
   ;

jsonpath_subscript
   : RECURSIVE_DESCENT ( subscriptableBareword | subscriptables ) jsonpath_subscript?
   | SUBSCRIPT subscriptableBareword jsonpath_subscript?
   | subscriptables jsonpath_subscript?
   ;

subscriptables
   : BRACKET_LEFT subscriptable  BRACKET_RIGHT
   ;

subscriptableArguments
   : PAREN_LEFT ( jsonpath__ ( COMMA jsonpath__ )* )? PAREN_RIGHT
   ;

subscriptableBareword
   : jsonPath_identifier subscriptableArguments?
   | WILDCARD_SUBSCRIPT
   ;

jsonPath_identifier
   : ID
   | IN
   | NIN
   | SUBSETOF
   | CONTAINS
   | SIZE
   | EMPTY
   | TRUE
   | FALSE
   ;

subscriptable
   : STRING
   | sliceable
   | WILDCARD_SUBSCRIPT
   | QUESTION PAREN_LEFT expressions PAREN_RIGHT
   | jsonpath_ ((PLUS | MINUS)? NUMBER)?
   | IDQUOTED subscriptableArguments?
   ;

sliceable
   : signedNumber
   | sliceableLeft
   | sliceableRight
   | sliceableBinary
   ;

signedNumber : SIGNED_NUMBER | NUMBER;

signedInt : SIGNED_INT | INT;

sliceableLeft
   : signedNumber COLON
   ;

sliceableRight
   : COLON signedNumber
   ;

sliceableBinary
   : signedNumber COLON signedNumber
   ;

expressions
   : NT? expression (binaryOperator expression)+
   | PAREN_LEFT expression PAREN_RIGHT   
   ;

expression
   : jsonpath__
   | NT expression
   | PAREN_LEFT expression PAREN_RIGHT   
   ;


binaryOperator
   : AND 
   | OR 
   | EQ 
   | NE 
   | LT 
   | LE 
   | GT 
   | GE  
   | IN
   | NIN
   | SUBSETOF
   | CONTAINS
   | SIZE
   | EMPTY  
   ;

value
   : STRING
   | IDQUOTED
   | signedNumber
   | TRUE
   | FALSE
   | NULL
   | obj
   | array
   | variable
   ;
