/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2014 by Bart Kiers
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute,
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
 * NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 * Project : elastic-parser; an ANTLR4 grammar for Elastic https://github.com/bkiers/elastic-parser
 * Developed by : gael beard, black.Beard
 */
parser grammar ElasticParser;

options {
	tokenVocab = ElasticLexer;
}

parse: ( sql_stmt_list | error)* EOF;

error:
	UNEXPECTED_CHAR { 
     throw new RuntimeException("UNEXPECTED_CHAR=" + $UNEXPECTED_CHAR.text); 
   };

sql_stmt_list: ';'* sql_stmt (';'+ sql_stmt)* ';'*;

sql_stmt: (EXPLAIN (QUERY PLAN)?)? (
		  create_table_stmt
		| create_view_stmt
		| create_virtual_table_stmt
		| insert_stmt
		| select_stmt
	);

where_stmt:
	WHERE expr;

indexed_column:
	(column_name | expr) (COLLATE collation_name)? asc_desc?;

create_table_stmt:
	CREATE (TEMP | TEMPORARY)? TABLE (IF NOT EXISTS)? (
		schema_name '.'
	)? table_name (
		(
			'(' column_def (',' column_def)* (
				',' table_constraint
			)* ')' (WITHOUT rowID = IDENTIFIER)?
		)
		| (AS select_stmt)
	);

column_def: column_name type_name? column_constraint*;

type_name:
	name+ (
		'(' signed_number ')'
		| '(' signed_number ',' signed_number ')'
	)?;

column_constraint: (CONSTRAINT name)? (
		(PRIMARY KEY asc_desc? conflict_clause? AUTOINCREMENT?)
		| ((NOT NULL_) | UNIQUE) conflict_clause?
		| CHECK '(' expr ')'
		| DEFAULT (
			signed_number
			| literal_value
			| ('(' expr ')')
		)
		| COLLATE collation_name
		| foreign_key_clause
		| (GENERATED ALWAYS)? AS '(' expr ')' (STORED | VIRTUAL)?
	);

signed_number: ( '+' | '-')? NUMERIC_LITERAL;

table_constraint: (CONSTRAINT name)? (
		(
			(PRIMARY KEY | UNIQUE) '(' indexed_column (
				',' indexed_column
			)* ')' conflict_clause?
		)
		| (CHECK '(' expr ')')
		| (
			FOREIGN KEY column_name_list foreign_key_clause
		)
	);

foreign_key_clause:
	REFERENCES foreign_table column_name_list? (
		(
			ON (DELETE | UPDATE) (
				(SET (NULL_ | DEFAULT))
				| CASCADE
				| RESTRICT
				| (NO ACTION)
			)
		)
		| (MATCH name)
	)* (NOT? DEFERRABLE ( INITIALLY (DEFERRED | IMMEDIATE))?)?;

conflict_clause:
	ON CONFLICT (ROLLBACK | ABORT | FAIL | IGNORE | REPLACE);

create_view_stmt:
	CREATE (TEMP | TEMPORARY)? VIEW (IF NOT EXISTS)? (
		schema_name '.'
	)? view_name column_name_list? AS select_stmt;

create_virtual_table_stmt:
	CREATE VIRTUAL TABLE (IF NOT EXISTS)? (schema_name '.')? table_name USING module_name (
		'(' module_argument (',' module_argument)* ')'
	)?;

with_clause:
	WITH RECURSIVE? cte_table_name AS '(' select_stmt ')' (
		',' cte_table_name AS '(' select_stmt ')'
	)*;

cte_table_name:
	table_name column_name_list?;

recursive_cte:
	cte_table_name AS '(' initial_select UNION ALL? recursive_select ')';

common_table_expression:
	table_name column_name_list? AS '(' select_stmt ')';

/*
 SQLite understands the following binary operators, in order from highest to lowest precedence: || /
 % + - << >> & | < <= > >= = == != <> IS IS NOT IN LIKE GLOB MATCH REGEXP AND OR
 */
expr:
	  literal_value
	| BIND_PARAMETER
	| fullname
	| unary_operator expr
	| expr binary_operator expr
	| call_function_expr
	| CAST '(' expr AS type_name ')'
	| expr COLLATE collation_name
	| expr nullable_expr
	| expr in_expr
	| exists_expr
	| case_expression
	| raise_function
	| expr NOT? BETWEEN expr AND expr
	| expr NOT? like_operator expr (ESCAPE expr)?
	| '(' (expr | expr_list) ')'
	;

call_function_expr:
	function_name '(' ((DISTINCT? expr_list) | STAR)? ')' filter_clause? over_clause?
	;

in_expr:
	NOT? IN 
	(
		  ( '(' (select_stmt | expr_list)? ')' )
		| ( ( schema_name '.')? table_name )
		| ( (schema_name '.')? table_function_name '(' expr_list? ')' )
	)
	;

case_expression: 
	case_expr case_when+ case_else_expr? END
	;

case_when: 
	WHEN expr THEN expr
	;

case_expr:
	CASE expr?
	;

case_else_expr:
	ELSE expr
	;

exists_expr: 
	( (NOT)? EXISTS)? '(' select_stmt ')'
	;

nullable_expr: 
	( ISNULL | NOTNULL | (NOT NULL_))
	;

fullname: 
	( ( schema_name '.')? table_name '.')? column_name
	;

binary_operator:
	  '||'
	| ( STAR | '/' | '%') 
	| ( '+' | '-') 
	| ( '<<' | '>>' | '&' | '|') 
	| ( '<' | '<=' | '>' | '>=') 
	| 	'='
	| '=='
	| '!='
	| '<>'
	| IN
	| AND 
	| OR 
	| IS NOT? 
	| like_operator
	;

like_operator:
	  LIKE
	| GLOB
	| MATCH
	| REGEXP
;


raise_function:
	RAISE '(' (
		IGNORE
		| (( ROLLBACK | ABORT | FAIL) ',' error_message)
	) ')';

literal_value:
	NUMERIC_LITERAL
	| STRING_LITERAL
	| BLOB_LITERAL
	| NULL_
	| TRUE_
	| FALSE_
	| CURRENT_TIME
	| CURRENT_DATE
	| CURRENT_TIMESTAMP;

insert_stmt:
	with_clause? (
		INSERT
		| REPLACE
		| (
			INSERT OR (
				REPLACE
				| ROLLBACK
				| ABORT
				| FAIL
				| IGNORE
			)
		)
	) INTO (schema_name '.')? table_name (AS table_alias)? column_name_list? (
		(
			(
				VALUES value_list_stmt
			)
			| select_stmt
		) upsert_clause?
	)
	| (DEFAULT VALUES);

upsert_clause:
	ON CONFLICT (
		'(' indexed_column (',' indexed_column)* ')' where_stmt?
	)? DO (
		NOTHING
		| (
			UPDATE SET (
				(column_name | column_name_list) EQ expr (
					',' (column_name | column_name_list) EQ expr
				)* where_stmt?
			)
		)
	);

select_stmt:
	common_table_stmt? select_core 
	compound* 
	order_by_stmt? 
	limit_stmts?;


compound: compound_operator select_core;

join_clauses: table_or_subquery join_clause+;

join_clause: join_operator table_or_subquery join_constraint?;

select_core:
	(
		SELECT (DISTINCT | ALL)? result_column (',' result_column)* 
		(
			FROM subquery_table
		)? 
		where_stmt? 
		group_by_stmt? 
		(
			WINDOW window_stmt (',' window_stmt)*
		)?
	)
	| VALUES value_list_stmt;

value_list_stmt: '(' expr_list ')' (',' '(' expr_list ')')*;


group_by_stmt: 
	GROUP BY expr_list having_stmt?
	;

having_stmt: 
	HAVING expr
	;

window_stmt: 
	window_name AS window_defn;

expr_list: expr (',' expr)*;

// simple_select_stmt:
// 	common_table_stmt? select_core order_by_stmt? limit_stmts?;

// compound_select_stmt:
// 	common_table_stmt? select_core (
// 		((UNION ALL?) | INTERSECT | EXCEPT) select_core
// 	)+ order_by_stmt? limit_stmts?;

table_or_subquery: 
      (
		(schema_name '.')? table_name (AS? table_alias)? 
		((INDEXED BY index_name) | (NOT INDEXED))?
	  )
	| (
		(schema_name '.')? table_function_name '(' expr (',' expr)* ')' (AS? table_alias)?
	  )
	| '(' subquery_table ')'
	| ('(' select_stmt ')' ( AS? table_alias)?);

subquery_table: 
	(table_or_subquery (',' table_or_subquery)* | join_clauses)
	;

result_column:
	STAR
	| table_name '.' STAR
	| expr ( AS? column_alias)?;

join_operator:
	','
	| (NATURAL? ( (LEFT OUTER?) | INNER | CROSS)? JOIN);

join_constraint:
	  (ON expr)
	| (USING column_name_list);

compound_operator: (UNION ALL?) | INTERSECT | EXCEPT;

column_name_list: '(' column_name (',' column_name)* ')';

filter_clause: FILTER '(' WHERE expr ')';

window_defn:
	'(' base_window_name? (PARTITION BY expr_list)? (
		ORDER BY ordering_term (',' ordering_term)*
	) frame_spec? ')';

over_clause:
	OVER (
		window_name
		| (
			'(' base_window_name? (PARTITION BY expr_list)? (
				ORDER BY ordering_term (',' ordering_term)*
			)? frame_spec? ')'
		)
	);

frame_spec:
	frame_clause (
		EXCLUDE (NO OTHERS)
		| (CURRENT ROW)
		| GROUP
		| TIES
	)?;

frame_clause: (RANGE | ROWS | GROUPS) (
		frame_single
		| BETWEEN frame_left AND frame_right
	);

common_table_stmt: //additional structures
	WITH RECURSIVE? common_table_expression (
		',' common_table_expression
	)*;

order_by_stmt: ORDER BY ordering_term ( ',' ordering_term)*;

limit_stmts: LIMIT expr limit_stmt?;

limit_stmt: (OFFSET | ',') expr;

ordering_term:
	expr (COLLATE collation_name)? asc_desc? (
		NULLS (FIRST | LAST)
	)?;
asc_desc: ASC | DESC;

frame_left:
	(expr PRECEDING)
	| (expr FOLLOWING)
	| (CURRENT ROW)
	| (UNBOUNDED PRECEDING);

frame_right:
	(expr PRECEDING)
	| (expr FOLLOWING)
	| (CURRENT ROW)
	| (UNBOUNDED FOLLOWING);

frame_single:
	(expr PRECEDING)
	| (UNBOUNDED PRECEDING)
	| (CURRENT ROW);

// unknown

window_function:
	(FIRST_VALUE | LAST_VALUE) '(' expr ')' OVER '(' partition_by? order_by_expr_asc_desc
		frame_clause? ')'
	| (CUME_DIST | PERCENT_RANK) '(' ')' OVER '(' partition_by? order_by_expr? ')'
	| (DENSE_RANK | RANK | ROW_NUMBER) '(' ')' OVER '(' partition_by? order_by_expr_asc_desc ')'
	| (LAG | LEAD) '(' expr offset? default_value? ')' OVER '(' partition_by? order_by_expr_asc_desc
		')'
	| NTH_VALUE '(' expr ',' signed_number ')' OVER '(' partition_by? order_by_expr_asc_desc
		frame_clause? ')'
	| NTILE '(' expr ')' OVER '(' partition_by? order_by_expr_asc_desc ')';

offset: ',' signed_number;

default_value: ',' signed_number;

partition_by: PARTITION BY expr+;

order_by_expr: ORDER BY expr+;

order_by_expr_asc_desc: ORDER BY order_by_expr_asc_desc;

//expr_asc_desc: expr asc_desc? (',' expr asc_desc?)*;

//TODO BOTH OF THESE HAVE TO BE REWORKED TO FOLLOW THE SPEC
initial_select: select_stmt;

recursive_select: select_stmt;

unary_operator: '-' | '+' | '~' | NOT;

error_message: STRING_LITERAL;

module_argument: // TODO check what exactly is permitted here
	expr
	| column_def;

column_alias: IDENTIFIER | STRING_LITERAL;

keyword:
	ABORT
	| ACTION
	| ADD
	| AFTER
	| ALL
	| ALTER
	| ANALYZE
	| AND
	| AS
	| ASC
	| ATTACH
	| AUTOINCREMENT
	| BEFORE
	| BEGIN
	| BETWEEN
	| BY
	| CASCADE
	| CASE
	| CAST
	| CHECK
	| COLLATE
	| COLUMN
	| COMMIT
	| CONFLICT
	| CONSTRAINT
	| CREATE
	| CROSS
	| CURRENT_DATE
	| CURRENT_TIME
	| CURRENT_TIMESTAMP
	| DATABASE
	| DEFAULT
	| DEFERRABLE
	| DEFERRED
	| DELETE
	| DESC
	| DETACH
	| DISTINCT
	| DROP
	| EACH
	| ELSE
	| END
	| ESCAPE
	| EXCEPT
	| EXCLUSIVE
	| EXISTS
	| EXPLAIN
	| FAIL
	| FOR
	| FOREIGN
	| FROM
	| FULL
	| GLOB
	| GROUP
	| HAVING
	| IF
	| IGNORE
	| IMMEDIATE
	| IN
	| INDEX
	| INDEXED
	| INITIALLY
	| INNER
	| INSERT
	| INSTEAD
	| INTERSECT
	| INTO
	| IS
	| ISNULL
	| JOIN
	| KEY
	| LEFT
	| LIKE
	| LIMIT
	| MATCH
	| NATURAL
	| NO
	| NOT
	| NOTNULL
	| NULL_
	| OF
	| OFFSET
	| ON
	| OR
	| ORDER
	| OUTER
	| PLAN
	| PRAGMA
	| PRIMARY
	| QUERY
	| RAISE
	| RECURSIVE
	| REFERENCES
	| REGEXP
	| REINDEX
	| RELEASE
	| RENAME
	| REPLACE
	| RESTRICT
	| RIGHT
	| ROLLBACK
	| ROW
	| ROWS
	| SAVEPOINT
	| SELECT
	| SET
	| TABLE
	| TEMP
	| TEMPORARY
	| THEN
	| TO
	| TRANSACTION
	| TRIGGER
	| UNION
	| UNIQUE
	| UPDATE
	| USING
	| VACUUM
	| VALUES
	| VIEW
	| VIRTUAL
	| WHEN
	| WHERE
	| WITH
	| WITHOUT
	| FIRST_VALUE
	| OVER
	| PARTITION
	| RANGE
	| PRECEDING
	| UNBOUNDED
	| CURRENT
	| FOLLOWING
	| CUME_DIST
	| DENSE_RANK
	| LAG
	| LAST_VALUE
	| LEAD
	| NTH_VALUE
	| NTILE
	| PERCENT_RANK
	| RANK
	| ROW_NUMBER
	| GENERATED
	| ALWAYS
	| STORED
	| TRUE_
	| FALSE_
	| WINDOW
	| NULLS
	| FIRST
	| LAST
	| FILTER
	| GROUPS
	| EXCLUDE;

// TODO check all names below

name: any_name;

function_name: any_name;

schema_name: any_name;

table_name: any_name;

column_name: any_name;

collation_name: any_name;

foreign_table: any_name;

index_name: any_name;

view_name: any_name;

module_name: any_name;

table_alias: any_name;

window_name: any_name;

alias: any_name;


base_window_name: any_name;

simple_func: any_name;

aggregate_func: any_name;

table_function_name: any_name;

any_name:
	IDENTIFIER
	| keyword
	| STRING_LITERAL
	| '(' any_name ')';