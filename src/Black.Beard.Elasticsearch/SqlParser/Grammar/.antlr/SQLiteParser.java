// Generated from c:\Users\g.beard\source\repos\TestQueryElastic\TestQueryElastic\SqlParser\Grammar\SQLiteParser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SQLiteParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		SCOL=1, DOT=2, OPEN_PAR=3, CLOSE_PAR=4, COMMA=5, ASSIGN=6, STAR=7, PLUS=8, 
		MINUS=9, TILDE=10, PIPE2=11, DIV=12, MOD=13, LT2=14, GT2=15, AMP=16, PIPE=17, 
		LT=18, LT_EQ=19, GT=20, GT_EQ=21, EQ=22, NOT_EQ1=23, NOT_EQ2=24, ABORT=25, 
		ACTION=26, ADD=27, AFTER=28, ALL=29, ALTER=30, ANALYZE=31, AND=32, AS=33, 
		ASC=34, ATTACH=35, AUTOINCREMENT=36, BEFORE=37, BEGIN=38, BETWEEN=39, 
		BY=40, CASCADE=41, CASE=42, CAST=43, CHECK=44, COLLATE=45, COLUMN=46, 
		COMMIT=47, CONFLICT=48, CONSTRAINT=49, CREATE=50, CROSS=51, CURRENT_DATE=52, 
		CURRENT_TIME=53, CURRENT_TIMESTAMP=54, DATABASE=55, DEFAULT=56, DEFERRABLE=57, 
		DEFERRED=58, DELETE=59, DESC=60, DETACH=61, DISTINCT=62, DROP=63, EACH=64, 
		ELSE=65, END=66, ESCAPE=67, EXCEPT=68, EXCLUSIVE=69, EXISTS=70, EXPLAIN=71, 
		FAIL=72, FOR=73, FOREIGN=74, FROM=75, FULL=76, GLOB=77, GROUP=78, HAVING=79, 
		IF=80, IGNORE=81, IMMEDIATE=82, IN=83, INDEX=84, INDEXED=85, INITIALLY=86, 
		INNER=87, INSERT=88, INSTEAD=89, INTERSECT=90, INTO=91, IS=92, ISNULL=93, 
		JOIN=94, KEY=95, LEFT=96, LIKE=97, LIMIT=98, MATCH=99, NATURAL=100, NO=101, 
		NOT=102, NOTNULL=103, NULL_=104, OF=105, OFFSET=106, ON=107, OR=108, ORDER=109, 
		OUTER=110, PLAN=111, PRAGMA=112, PRIMARY=113, QUERY=114, RAISE=115, RECURSIVE=116, 
		REFERENCES=117, REGEXP=118, REINDEX=119, RELEASE=120, RENAME=121, REPLACE=122, 
		RESTRICT=123, RIGHT=124, ROLLBACK=125, ROW=126, ROWS=127, SAVEPOINT=128, 
		SELECT=129, SET=130, TABLE=131, TEMP=132, TEMPORARY=133, THEN=134, TO=135, 
		TRANSACTION=136, TRIGGER=137, UNION=138, UNIQUE=139, UPDATE=140, USING=141, 
		VACUUM=142, VALUES=143, VIEW=144, VIRTUAL=145, WHEN=146, WHERE=147, WITH=148, 
		WITHOUT=149, FIRST_VALUE=150, OVER=151, PARTITION=152, RANGE=153, PRECEDING=154, 
		UNBOUNDED=155, CURRENT=156, FOLLOWING=157, CUME_DIST=158, DENSE_RANK=159, 
		LAG=160, LAST_VALUE=161, LEAD=162, NTH_VALUE=163, NTILE=164, PERCENT_RANK=165, 
		RANK=166, ROW_NUMBER=167, GENERATED=168, ALWAYS=169, STORED=170, TRUE_=171, 
		FALSE_=172, WINDOW=173, NULLS=174, FIRST=175, LAST=176, FILTER=177, GROUPS=178, 
		EXCLUDE=179, TIES=180, OTHERS=181, DO=182, NOTHING=183, IDENTIFIER=184, 
		NUMERIC_LITERAL=185, BIND_PARAMETER=186, STRING_LITERAL=187, BLOB_LITERAL=188, 
		SINGLE_LINE_COMMENT=189, MULTILINE_COMMENT=190, SPACES=191, UNEXPECTED_CHAR=192;
	public static final int
		RULE_parse = 0, RULE_error = 1, RULE_sql_stmt_list = 2, RULE_sql_stmt = 3, 
		RULE_alter_table_stmt = 4, RULE_analyze_stmt = 5, RULE_attach_stmt = 6, 
		RULE_begin_stmt = 7, RULE_commit_stmt = 8, RULE_rollback_stmt = 9, RULE_savepoint_stmt = 10, 
		RULE_release_stmt = 11, RULE_create_index_stmt = 12, RULE_where_stmt = 13, 
		RULE_indexed_column = 14, RULE_create_table_stmt = 15, RULE_column_def = 16, 
		RULE_type_name = 17, RULE_column_constraint = 18, RULE_signed_number = 19, 
		RULE_table_constraint = 20, RULE_foreign_key_clause = 21, RULE_conflict_clause = 22, 
		RULE_create_trigger_stmt = 23, RULE_create_view_stmt = 24, RULE_create_virtual_table_stmt = 25, 
		RULE_with_clause = 26, RULE_cte_table_name = 27, RULE_recursive_cte = 28, 
		RULE_common_table_expression = 29, RULE_delete_stmt = 30, RULE_delete_stmt_limited = 31, 
		RULE_detach_stmt = 32, RULE_drop_stmt = 33, RULE_expr = 34, RULE_call_function_expr = 35, 
		RULE_in_expr = 36, RULE_case_expression = 37, RULE_case_when = 38, RULE_case_expr = 39, 
		RULE_case_else_expr = 40, RULE_exists_expr = 41, RULE_nullable_expr = 42, 
		RULE_fullname = 43, RULE_binary_operator = 44, RULE_like_operator = 45, 
		RULE_raise_function = 46, RULE_literal_value = 47, RULE_insert_stmt = 48, 
		RULE_upsert_clause = 49, RULE_pragma_stmt = 50, RULE_pragma_value = 51, 
		RULE_reindex_stmt = 52, RULE_select_stmt = 53, RULE_compound = 54, RULE_join_clauses = 55, 
		RULE_join_clause = 56, RULE_select_core = 57, RULE_value_list_stmt = 58, 
		RULE_group_by_stmt = 59, RULE_having_stmt = 60, RULE_window_stmt = 61, 
		RULE_expr_list = 62, RULE_factored_select_stmt = 63, RULE_simple_select_stmt = 64, 
		RULE_compound_select_stmt = 65, RULE_table_or_subquery = 66, RULE_subquery_table = 67, 
		RULE_result_column = 68, RULE_join_operator = 69, RULE_join_constraint = 70, 
		RULE_compound_operator = 71, RULE_update_stmt = 72, RULE_column_name_list = 73, 
		RULE_update_stmt_limited = 74, RULE_qualified_table_name = 75, RULE_vacuum_stmt = 76, 
		RULE_filter_clause = 77, RULE_window_defn = 78, RULE_over_clause = 79, 
		RULE_frame_spec = 80, RULE_frame_clause = 81, RULE_simple_function_invocation = 82, 
		RULE_aggregate_function_invocation = 83, RULE_window_function_invocation = 84, 
		RULE_common_table_stmt = 85, RULE_order_by_stmt = 86, RULE_limit_stmts = 87, 
		RULE_limit_stmt = 88, RULE_ordering_term = 89, RULE_asc_desc = 90, RULE_frame_left = 91, 
		RULE_frame_right = 92, RULE_frame_single = 93, RULE_window_function = 94, 
		RULE_offset = 95, RULE_default_value = 96, RULE_partition_by = 97, RULE_order_by_expr = 98, 
		RULE_order_by_expr_asc_desc = 99, RULE_expr_asc_desc = 100, RULE_initial_select = 101, 
		RULE_recursive_select = 102, RULE_unary_operator = 103, RULE_error_message = 104, 
		RULE_module_argument = 105, RULE_column_alias = 106, RULE_keyword = 107, 
		RULE_name = 108, RULE_function_name = 109, RULE_schema_name = 110, RULE_table_name = 111, 
		RULE_table_or_index_name = 112, RULE_new_table_name = 113, RULE_column_name = 114, 
		RULE_collation_name = 115, RULE_foreign_table = 116, RULE_index_name = 117, 
		RULE_trigger_name = 118, RULE_view_name = 119, RULE_module_name = 120, 
		RULE_pragma_name = 121, RULE_savepoint_name = 122, RULE_table_alias = 123, 
		RULE_transaction_name = 124, RULE_window_name = 125, RULE_alias = 126, 
		RULE_filename = 127, RULE_base_window_name = 128, RULE_simple_func = 129, 
		RULE_aggregate_func = 130, RULE_table_function_name = 131, RULE_any_name = 132;
	private static String[] makeRuleNames() {
		return new String[] {
			"parse", "error", "sql_stmt_list", "sql_stmt", "alter_table_stmt", "analyze_stmt", 
			"attach_stmt", "begin_stmt", "commit_stmt", "rollback_stmt", "savepoint_stmt", 
			"release_stmt", "create_index_stmt", "where_stmt", "indexed_column", 
			"create_table_stmt", "column_def", "type_name", "column_constraint", 
			"signed_number", "table_constraint", "foreign_key_clause", "conflict_clause", 
			"create_trigger_stmt", "create_view_stmt", "create_virtual_table_stmt", 
			"with_clause", "cte_table_name", "recursive_cte", "common_table_expression", 
			"delete_stmt", "delete_stmt_limited", "detach_stmt", "drop_stmt", "expr", 
			"call_function_expr", "in_expr", "case_expression", "case_when", "case_expr", 
			"case_else_expr", "exists_expr", "nullable_expr", "fullname", "binary_operator", 
			"like_operator", "raise_function", "literal_value", "insert_stmt", "upsert_clause", 
			"pragma_stmt", "pragma_value", "reindex_stmt", "select_stmt", "compound", 
			"join_clauses", "join_clause", "select_core", "value_list_stmt", "group_by_stmt", 
			"having_stmt", "window_stmt", "expr_list", "factored_select_stmt", "simple_select_stmt", 
			"compound_select_stmt", "table_or_subquery", "subquery_table", "result_column", 
			"join_operator", "join_constraint", "compound_operator", "update_stmt", 
			"column_name_list", "update_stmt_limited", "qualified_table_name", "vacuum_stmt", 
			"filter_clause", "window_defn", "over_clause", "frame_spec", "frame_clause", 
			"simple_function_invocation", "aggregate_function_invocation", "window_function_invocation", 
			"common_table_stmt", "order_by_stmt", "limit_stmts", "limit_stmt", "ordering_term", 
			"asc_desc", "frame_left", "frame_right", "frame_single", "window_function", 
			"offset", "default_value", "partition_by", "order_by_expr", "order_by_expr_asc_desc", 
			"expr_asc_desc", "initial_select", "recursive_select", "unary_operator", 
			"error_message", "module_argument", "column_alias", "keyword", "name", 
			"function_name", "schema_name", "table_name", "table_or_index_name", 
			"new_table_name", "column_name", "collation_name", "foreign_table", "index_name", 
			"trigger_name", "view_name", "module_name", "pragma_name", "savepoint_name", 
			"table_alias", "transaction_name", "window_name", "alias", "filename", 
			"base_window_name", "simple_func", "aggregate_func", "table_function_name", 
			"any_name"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "';'", "'.'", "'('", "')'", "','", "'='", "'*'", "'+'", "'-'", 
			"'~'", "'||'", "'/'", "'%'", "'<<'", "'>>'", "'&'", "'|'", "'<'", "'<='", 
			"'>'", "'>='", "'=='", "'!='", "'<>'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SCOL", "DOT", "OPEN_PAR", "CLOSE_PAR", "COMMA", "ASSIGN", "STAR", 
			"PLUS", "MINUS", "TILDE", "PIPE2", "DIV", "MOD", "LT2", "GT2", "AMP", 
			"PIPE", "LT", "LT_EQ", "GT", "GT_EQ", "EQ", "NOT_EQ1", "NOT_EQ2", "ABORT", 
			"ACTION", "ADD", "AFTER", "ALL", "ALTER", "ANALYZE", "AND", "AS", "ASC", 
			"ATTACH", "AUTOINCREMENT", "BEFORE", "BEGIN", "BETWEEN", "BY", "CASCADE", 
			"CASE", "CAST", "CHECK", "COLLATE", "COLUMN", "COMMIT", "CONFLICT", "CONSTRAINT", 
			"CREATE", "CROSS", "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", 
			"DATABASE", "DEFAULT", "DEFERRABLE", "DEFERRED", "DELETE", "DESC", "DETACH", 
			"DISTINCT", "DROP", "EACH", "ELSE", "END", "ESCAPE", "EXCEPT", "EXCLUSIVE", 
			"EXISTS", "EXPLAIN", "FAIL", "FOR", "FOREIGN", "FROM", "FULL", "GLOB", 
			"GROUP", "HAVING", "IF", "IGNORE", "IMMEDIATE", "IN", "INDEX", "INDEXED", 
			"INITIALLY", "INNER", "INSERT", "INSTEAD", "INTERSECT", "INTO", "IS", 
			"ISNULL", "JOIN", "KEY", "LEFT", "LIKE", "LIMIT", "MATCH", "NATURAL", 
			"NO", "NOT", "NOTNULL", "NULL_", "OF", "OFFSET", "ON", "OR", "ORDER", 
			"OUTER", "PLAN", "PRAGMA", "PRIMARY", "QUERY", "RAISE", "RECURSIVE", 
			"REFERENCES", "REGEXP", "REINDEX", "RELEASE", "RENAME", "REPLACE", "RESTRICT", 
			"RIGHT", "ROLLBACK", "ROW", "ROWS", "SAVEPOINT", "SELECT", "SET", "TABLE", 
			"TEMP", "TEMPORARY", "THEN", "TO", "TRANSACTION", "TRIGGER", "UNION", 
			"UNIQUE", "UPDATE", "USING", "VACUUM", "VALUES", "VIEW", "VIRTUAL", "WHEN", 
			"WHERE", "WITH", "WITHOUT", "FIRST_VALUE", "OVER", "PARTITION", "RANGE", 
			"PRECEDING", "UNBOUNDED", "CURRENT", "FOLLOWING", "CUME_DIST", "DENSE_RANK", 
			"LAG", "LAST_VALUE", "LEAD", "NTH_VALUE", "NTILE", "PERCENT_RANK", "RANK", 
			"ROW_NUMBER", "GENERATED", "ALWAYS", "STORED", "TRUE_", "FALSE_", "WINDOW", 
			"NULLS", "FIRST", "LAST", "FILTER", "GROUPS", "EXCLUDE", "TIES", "OTHERS", 
			"DO", "NOTHING", "IDENTIFIER", "NUMERIC_LITERAL", "BIND_PARAMETER", "STRING_LITERAL", 
			"BLOB_LITERAL", "SINGLE_LINE_COMMENT", "MULTILINE_COMMENT", "SPACES", 
			"UNEXPECTED_CHAR"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "SQLiteParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public SQLiteParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ParseContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(SQLiteParser.EOF, 0); }
		public List<Sql_stmt_listContext> sql_stmt_list() {
			return getRuleContexts(Sql_stmt_listContext.class);
		}
		public Sql_stmt_listContext sql_stmt_list(int i) {
			return getRuleContext(Sql_stmt_listContext.class,i);
		}
		public List<ErrorContext> error() {
			return getRuleContexts(ErrorContext.class);
		}
		public ErrorContext error(int i) {
			return getRuleContext(ErrorContext.class,i);
		}
		public ParseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parse; }
	}

	public final ParseContext parse() throws RecognitionException {
		ParseContext _localctx = new ParseContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_parse);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(270);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << SCOL) | (1L << ALTER) | (1L << ANALYZE) | (1L << ATTACH) | (1L << BEGIN) | (1L << COMMIT) | (1L << CREATE) | (1L << DEFAULT) | (1L << DELETE) | (1L << DETACH) | (1L << DROP))) != 0) || ((((_la - 66)) & ~0x3f) == 0 && ((1L << (_la - 66)) & ((1L << (END - 66)) | (1L << (EXPLAIN - 66)) | (1L << (INSERT - 66)) | (1L << (PRAGMA - 66)) | (1L << (REINDEX - 66)) | (1L << (RELEASE - 66)) | (1L << (REPLACE - 66)) | (1L << (ROLLBACK - 66)) | (1L << (SAVEPOINT - 66)) | (1L << (SELECT - 66)))) != 0) || ((((_la - 140)) & ~0x3f) == 0 && ((1L << (_la - 140)) & ((1L << (UPDATE - 140)) | (1L << (VACUUM - 140)) | (1L << (VALUES - 140)) | (1L << (WITH - 140)) | (1L << (UNEXPECTED_CHAR - 140)))) != 0)) {
				{
				setState(268);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case SCOL:
				case ALTER:
				case ANALYZE:
				case ATTACH:
				case BEGIN:
				case COMMIT:
				case CREATE:
				case DEFAULT:
				case DELETE:
				case DETACH:
				case DROP:
				case END:
				case EXPLAIN:
				case INSERT:
				case PRAGMA:
				case REINDEX:
				case RELEASE:
				case REPLACE:
				case ROLLBACK:
				case SAVEPOINT:
				case SELECT:
				case UPDATE:
				case VACUUM:
				case VALUES:
				case WITH:
					{
					setState(266);
					sql_stmt_list();
					}
					break;
				case UNEXPECTED_CHAR:
					{
					setState(267);
					error();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(272);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(273);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ErrorContext extends ParserRuleContext {
		public Token UNEXPECTED_CHAR;
		public TerminalNode UNEXPECTED_CHAR() { return getToken(SQLiteParser.UNEXPECTED_CHAR, 0); }
		public ErrorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_error; }
	}

	public final ErrorContext error() throws RecognitionException {
		ErrorContext _localctx = new ErrorContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_error);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(275);
			((ErrorContext)_localctx).UNEXPECTED_CHAR = match(UNEXPECTED_CHAR);
			 
			     throw new RuntimeException("UNEXPECTED_CHAR=" + (((ErrorContext)_localctx).UNEXPECTED_CHAR!=null?((ErrorContext)_localctx).UNEXPECTED_CHAR.getText():null)); 
			   
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Sql_stmt_listContext extends ParserRuleContext {
		public List<Sql_stmtContext> sql_stmt() {
			return getRuleContexts(Sql_stmtContext.class);
		}
		public Sql_stmtContext sql_stmt(int i) {
			return getRuleContext(Sql_stmtContext.class,i);
		}
		public List<TerminalNode> SCOL() { return getTokens(SQLiteParser.SCOL); }
		public TerminalNode SCOL(int i) {
			return getToken(SQLiteParser.SCOL, i);
		}
		public Sql_stmt_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sql_stmt_list; }
	}

	public final Sql_stmt_listContext sql_stmt_list() throws RecognitionException {
		Sql_stmt_listContext _localctx = new Sql_stmt_listContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_sql_stmt_list);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(281);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SCOL) {
				{
				{
				setState(278);
				match(SCOL);
				}
				}
				setState(283);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(284);
			sql_stmt();
			setState(293);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(286); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(285);
						match(SCOL);
						}
						}
						setState(288); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( _la==SCOL );
					setState(290);
					sql_stmt();
					}
					} 
				}
				setState(295);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			}
			setState(299);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(296);
					match(SCOL);
					}
					} 
				}
				setState(301);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Sql_stmtContext extends ParserRuleContext {
		public Alter_table_stmtContext alter_table_stmt() {
			return getRuleContext(Alter_table_stmtContext.class,0);
		}
		public Analyze_stmtContext analyze_stmt() {
			return getRuleContext(Analyze_stmtContext.class,0);
		}
		public Attach_stmtContext attach_stmt() {
			return getRuleContext(Attach_stmtContext.class,0);
		}
		public Begin_stmtContext begin_stmt() {
			return getRuleContext(Begin_stmtContext.class,0);
		}
		public Commit_stmtContext commit_stmt() {
			return getRuleContext(Commit_stmtContext.class,0);
		}
		public Create_index_stmtContext create_index_stmt() {
			return getRuleContext(Create_index_stmtContext.class,0);
		}
		public Create_table_stmtContext create_table_stmt() {
			return getRuleContext(Create_table_stmtContext.class,0);
		}
		public Create_trigger_stmtContext create_trigger_stmt() {
			return getRuleContext(Create_trigger_stmtContext.class,0);
		}
		public Create_view_stmtContext create_view_stmt() {
			return getRuleContext(Create_view_stmtContext.class,0);
		}
		public Create_virtual_table_stmtContext create_virtual_table_stmt() {
			return getRuleContext(Create_virtual_table_stmtContext.class,0);
		}
		public Delete_stmtContext delete_stmt() {
			return getRuleContext(Delete_stmtContext.class,0);
		}
		public Delete_stmt_limitedContext delete_stmt_limited() {
			return getRuleContext(Delete_stmt_limitedContext.class,0);
		}
		public Detach_stmtContext detach_stmt() {
			return getRuleContext(Detach_stmtContext.class,0);
		}
		public Drop_stmtContext drop_stmt() {
			return getRuleContext(Drop_stmtContext.class,0);
		}
		public Insert_stmtContext insert_stmt() {
			return getRuleContext(Insert_stmtContext.class,0);
		}
		public Pragma_stmtContext pragma_stmt() {
			return getRuleContext(Pragma_stmtContext.class,0);
		}
		public Reindex_stmtContext reindex_stmt() {
			return getRuleContext(Reindex_stmtContext.class,0);
		}
		public Release_stmtContext release_stmt() {
			return getRuleContext(Release_stmtContext.class,0);
		}
		public Rollback_stmtContext rollback_stmt() {
			return getRuleContext(Rollback_stmtContext.class,0);
		}
		public Savepoint_stmtContext savepoint_stmt() {
			return getRuleContext(Savepoint_stmtContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Update_stmtContext update_stmt() {
			return getRuleContext(Update_stmtContext.class,0);
		}
		public Update_stmt_limitedContext update_stmt_limited() {
			return getRuleContext(Update_stmt_limitedContext.class,0);
		}
		public Vacuum_stmtContext vacuum_stmt() {
			return getRuleContext(Vacuum_stmtContext.class,0);
		}
		public TerminalNode EXPLAIN() { return getToken(SQLiteParser.EXPLAIN, 0); }
		public TerminalNode QUERY() { return getToken(SQLiteParser.QUERY, 0); }
		public TerminalNode PLAN() { return getToken(SQLiteParser.PLAN, 0); }
		public Sql_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sql_stmt; }
	}

	public final Sql_stmtContext sql_stmt() throws RecognitionException {
		Sql_stmtContext _localctx = new Sql_stmtContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_sql_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(307);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXPLAIN) {
				{
				setState(302);
				match(EXPLAIN);
				setState(305);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==QUERY) {
					{
					setState(303);
					match(QUERY);
					setState(304);
					match(PLAN);
					}
				}

				}
			}

			setState(333);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(309);
				alter_table_stmt();
				}
				break;
			case 2:
				{
				setState(310);
				analyze_stmt();
				}
				break;
			case 3:
				{
				setState(311);
				attach_stmt();
				}
				break;
			case 4:
				{
				setState(312);
				begin_stmt();
				}
				break;
			case 5:
				{
				setState(313);
				commit_stmt();
				}
				break;
			case 6:
				{
				setState(314);
				create_index_stmt();
				}
				break;
			case 7:
				{
				setState(315);
				create_table_stmt();
				}
				break;
			case 8:
				{
				setState(316);
				create_trigger_stmt();
				}
				break;
			case 9:
				{
				setState(317);
				create_view_stmt();
				}
				break;
			case 10:
				{
				setState(318);
				create_virtual_table_stmt();
				}
				break;
			case 11:
				{
				setState(319);
				delete_stmt();
				}
				break;
			case 12:
				{
				setState(320);
				delete_stmt_limited();
				}
				break;
			case 13:
				{
				setState(321);
				detach_stmt();
				}
				break;
			case 14:
				{
				setState(322);
				drop_stmt();
				}
				break;
			case 15:
				{
				setState(323);
				insert_stmt();
				}
				break;
			case 16:
				{
				setState(324);
				pragma_stmt();
				}
				break;
			case 17:
				{
				setState(325);
				reindex_stmt();
				}
				break;
			case 18:
				{
				setState(326);
				release_stmt();
				}
				break;
			case 19:
				{
				setState(327);
				rollback_stmt();
				}
				break;
			case 20:
				{
				setState(328);
				savepoint_stmt();
				}
				break;
			case 21:
				{
				setState(329);
				select_stmt();
				}
				break;
			case 22:
				{
				setState(330);
				update_stmt();
				}
				break;
			case 23:
				{
				setState(331);
				update_stmt_limited();
				}
				break;
			case 24:
				{
				setState(332);
				vacuum_stmt();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Alter_table_stmtContext extends ParserRuleContext {
		public Column_nameContext old_column_name;
		public Column_nameContext new_column_name;
		public TerminalNode ALTER() { return getToken(SQLiteParser.ALTER, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode RENAME() { return getToken(SQLiteParser.RENAME, 0); }
		public TerminalNode ADD() { return getToken(SQLiteParser.ADD, 0); }
		public Column_defContext column_def() {
			return getRuleContext(Column_defContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode COLUMN() { return getToken(SQLiteParser.COLUMN, 0); }
		public TerminalNode TO() { return getToken(SQLiteParser.TO, 0); }
		public New_table_nameContext new_table_name() {
			return getRuleContext(New_table_nameContext.class,0);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public Alter_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_alter_table_stmt; }
	}

	public final Alter_table_stmtContext alter_table_stmt() throws RecognitionException {
		Alter_table_stmtContext _localctx = new Alter_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_alter_table_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(335);
			match(ALTER);
			setState(336);
			match(TABLE);
			setState(340);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				setState(337);
				schema_name();
				setState(338);
				match(DOT);
				}
				break;
			}
			setState(342);
			table_name();
			setState(360);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RENAME:
				{
				setState(343);
				match(RENAME);
				setState(353);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
				case 1:
					{
					{
					setState(344);
					match(TO);
					setState(345);
					new_table_name();
					}
					}
					break;
				case 2:
					{
					{
					setState(347);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
					case 1:
						{
						setState(346);
						match(COLUMN);
						}
						break;
					}
					setState(349);
					((Alter_table_stmtContext)_localctx).old_column_name = column_name();
					setState(350);
					match(TO);
					setState(351);
					((Alter_table_stmtContext)_localctx).new_column_name = column_name();
					}
					}
					break;
				}
				}
				break;
			case ADD:
				{
				setState(355);
				match(ADD);
				setState(357);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
				case 1:
					{
					setState(356);
					match(COLUMN);
					}
					break;
				}
				setState(359);
				column_def();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Analyze_stmtContext extends ParserRuleContext {
		public TerminalNode ANALYZE() { return getToken(SQLiteParser.ANALYZE, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public Table_or_index_nameContext table_or_index_name() {
			return getRuleContext(Table_or_index_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Analyze_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_analyze_stmt; }
	}

	public final Analyze_stmtContext analyze_stmt() throws RecognitionException {
		Analyze_stmtContext _localctx = new Analyze_stmtContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_analyze_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(362);
			match(ANALYZE);
			setState(370);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				{
				setState(363);
				schema_name();
				}
				break;
			case 2:
				{
				setState(367);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
				case 1:
					{
					setState(364);
					schema_name();
					setState(365);
					match(DOT);
					}
					break;
				}
				setState(369);
				table_or_index_name();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Attach_stmtContext extends ParserRuleContext {
		public TerminalNode ATTACH() { return getToken(SQLiteParser.ATTACH, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DATABASE() { return getToken(SQLiteParser.DATABASE, 0); }
		public Attach_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attach_stmt; }
	}

	public final Attach_stmtContext attach_stmt() throws RecognitionException {
		Attach_stmtContext _localctx = new Attach_stmtContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_attach_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(372);
			match(ATTACH);
			setState(374);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				setState(373);
				match(DATABASE);
				}
				break;
			}
			setState(376);
			expr(0);
			setState(377);
			match(AS);
			setState(378);
			schema_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Begin_stmtContext extends ParserRuleContext {
		public TerminalNode BEGIN() { return getToken(SQLiteParser.BEGIN, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public TerminalNode DEFERRED() { return getToken(SQLiteParser.DEFERRED, 0); }
		public TerminalNode IMMEDIATE() { return getToken(SQLiteParser.IMMEDIATE, 0); }
		public TerminalNode EXCLUSIVE() { return getToken(SQLiteParser.EXCLUSIVE, 0); }
		public Transaction_nameContext transaction_name() {
			return getRuleContext(Transaction_nameContext.class,0);
		}
		public Begin_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_begin_stmt; }
	}

	public final Begin_stmtContext begin_stmt() throws RecognitionException {
		Begin_stmtContext _localctx = new Begin_stmtContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_begin_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(380);
			match(BEGIN);
			setState(382);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (((((_la - 58)) & ~0x3f) == 0 && ((1L << (_la - 58)) & ((1L << (DEFERRED - 58)) | (1L << (EXCLUSIVE - 58)) | (1L << (IMMEDIATE - 58)))) != 0)) {
				{
				setState(381);
				_la = _input.LA(1);
				if ( !(((((_la - 58)) & ~0x3f) == 0 && ((1L << (_la - 58)) & ((1L << (DEFERRED - 58)) | (1L << (EXCLUSIVE - 58)) | (1L << (IMMEDIATE - 58)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(388);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TRANSACTION) {
				{
				setState(384);
				match(TRANSACTION);
				setState(386);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
				case 1:
					{
					setState(385);
					transaction_name();
					}
					break;
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Commit_stmtContext extends ParserRuleContext {
		public TerminalNode COMMIT() { return getToken(SQLiteParser.COMMIT, 0); }
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public Commit_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_commit_stmt; }
	}

	public final Commit_stmtContext commit_stmt() throws RecognitionException {
		Commit_stmtContext _localctx = new Commit_stmtContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_commit_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(390);
			_la = _input.LA(1);
			if ( !(_la==COMMIT || _la==END) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(392);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TRANSACTION) {
				{
				setState(391);
				match(TRANSACTION);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Rollback_stmtContext extends ParserRuleContext {
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public TerminalNode TO() { return getToken(SQLiteParser.TO, 0); }
		public Savepoint_nameContext savepoint_name() {
			return getRuleContext(Savepoint_nameContext.class,0);
		}
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public Rollback_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_rollback_stmt; }
	}

	public final Rollback_stmtContext rollback_stmt() throws RecognitionException {
		Rollback_stmtContext _localctx = new Rollback_stmtContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_rollback_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(394);
			match(ROLLBACK);
			setState(396);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TRANSACTION) {
				{
				setState(395);
				match(TRANSACTION);
				}
			}

			setState(403);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TO) {
				{
				setState(398);
				match(TO);
				setState(400);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,22,_ctx) ) {
				case 1:
					{
					setState(399);
					match(SAVEPOINT);
					}
					break;
				}
				setState(402);
				savepoint_name();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Savepoint_stmtContext extends ParserRuleContext {
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public Savepoint_nameContext savepoint_name() {
			return getRuleContext(Savepoint_nameContext.class,0);
		}
		public Savepoint_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_savepoint_stmt; }
	}

	public final Savepoint_stmtContext savepoint_stmt() throws RecognitionException {
		Savepoint_stmtContext _localctx = new Savepoint_stmtContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_savepoint_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(405);
			match(SAVEPOINT);
			setState(406);
			savepoint_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Release_stmtContext extends ParserRuleContext {
		public TerminalNode RELEASE() { return getToken(SQLiteParser.RELEASE, 0); }
		public Savepoint_nameContext savepoint_name() {
			return getRuleContext(Savepoint_nameContext.class,0);
		}
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public Release_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_release_stmt; }
	}

	public final Release_stmtContext release_stmt() throws RecognitionException {
		Release_stmtContext _localctx = new Release_stmtContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_release_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(408);
			match(RELEASE);
			setState(410);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				{
				setState(409);
				match(SAVEPOINT);
				}
				break;
			}
			setState(412);
			savepoint_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_index_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode INDEX() { return getToken(SQLiteParser.INDEX, 0); }
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public Create_index_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_index_stmt; }
	}

	public final Create_index_stmtContext create_index_stmt() throws RecognitionException {
		Create_index_stmtContext _localctx = new Create_index_stmtContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_create_index_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(414);
			match(CREATE);
			setState(416);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==UNIQUE) {
				{
				setState(415);
				match(UNIQUE);
				}
			}

			setState(418);
			match(INDEX);
			setState(422);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				{
				setState(419);
				match(IF);
				setState(420);
				match(NOT);
				setState(421);
				match(EXISTS);
				}
				break;
			}
			setState(427);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
			case 1:
				{
				setState(424);
				schema_name();
				setState(425);
				match(DOT);
				}
				break;
			}
			setState(429);
			index_name();
			setState(430);
			match(ON);
			setState(431);
			table_name();
			setState(432);
			match(OPEN_PAR);
			setState(433);
			indexed_column();
			setState(438);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(434);
				match(COMMA);
				setState(435);
				indexed_column();
				}
				}
				setState(440);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(441);
			match(CLOSE_PAR);
			setState(443);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(442);
				where_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Where_stmtContext extends ParserRuleContext {
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Where_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_where_stmt; }
	}

	public final Where_stmtContext where_stmt() throws RecognitionException {
		Where_stmtContext _localctx = new Where_stmtContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_where_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(445);
			match(WHERE);
			setState(446);
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Indexed_columnContext extends ParserRuleContext {
		public Column_nameContext column_name() {
			return getRuleContext(Column_nameContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public Indexed_columnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_indexed_column; }
	}

	public final Indexed_columnContext indexed_column() throws RecognitionException {
		Indexed_columnContext _localctx = new Indexed_columnContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_indexed_column);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(450);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
			case 1:
				{
				setState(448);
				column_name();
				}
				break;
			case 2:
				{
				setState(449);
				expr(0);
				}
				break;
			}
			setState(454);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLLATE) {
				{
				setState(452);
				match(COLLATE);
				setState(453);
				collation_name();
				}
			}

			setState(457);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(456);
				asc_desc();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_table_stmtContext extends ParserRuleContext {
		public Token rowID;
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_defContext> column_def() {
			return getRuleContexts(Column_defContext.class);
		}
		public Column_defContext column_def(int i) {
			return getRuleContext(Column_defContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public List<Table_constraintContext> table_constraint() {
			return getRuleContexts(Table_constraintContext.class);
		}
		public Table_constraintContext table_constraint(int i) {
			return getRuleContext(Table_constraintContext.class,i);
		}
		public TerminalNode WITHOUT() { return getToken(SQLiteParser.WITHOUT, 0); }
		public TerminalNode IDENTIFIER() { return getToken(SQLiteParser.IDENTIFIER, 0); }
		public Create_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_table_stmt; }
	}

	public final Create_table_stmtContext create_table_stmt() throws RecognitionException {
		Create_table_stmtContext _localctx = new Create_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_create_table_stmt);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(459);
			match(CREATE);
			setState(461);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(460);
				_la = _input.LA(1);
				if ( !(_la==TEMP || _la==TEMPORARY) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(463);
			match(TABLE);
			setState(467);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,34,_ctx) ) {
			case 1:
				{
				setState(464);
				match(IF);
				setState(465);
				match(NOT);
				setState(466);
				match(EXISTS);
				}
				break;
			}
			setState(472);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,35,_ctx) ) {
			case 1:
				{
				setState(469);
				schema_name();
				setState(470);
				match(DOT);
				}
				break;
			}
			setState(474);
			table_name();
			setState(498);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
				{
				{
				setState(475);
				match(OPEN_PAR);
				setState(476);
				column_def();
				setState(481);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(477);
						match(COMMA);
						setState(478);
						column_def();
						}
						} 
					}
					setState(483);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
				}
				setState(488);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(484);
					match(COMMA);
					setState(485);
					table_constraint();
					}
					}
					setState(490);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(491);
				match(CLOSE_PAR);
				setState(494);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WITHOUT) {
					{
					setState(492);
					match(WITHOUT);
					setState(493);
					((Create_table_stmtContext)_localctx).rowID = match(IDENTIFIER);
					}
				}

				}
				}
				break;
			case AS:
				{
				{
				setState(496);
				match(AS);
				setState(497);
				select_stmt();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_defContext extends ParserRuleContext {
		public Column_nameContext column_name() {
			return getRuleContext(Column_nameContext.class,0);
		}
		public Type_nameContext type_name() {
			return getRuleContext(Type_nameContext.class,0);
		}
		public List<Column_constraintContext> column_constraint() {
			return getRuleContexts(Column_constraintContext.class);
		}
		public Column_constraintContext column_constraint(int i) {
			return getRuleContext(Column_constraintContext.class,i);
		}
		public Column_defContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_def; }
	}

	public final Column_defContext column_def() throws RecognitionException {
		Column_defContext _localctx = new Column_defContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_column_def);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(500);
			column_name();
			setState(502);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
			case 1:
				{
				setState(501);
				type_name();
				}
				break;
			}
			setState(507);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(504);
					column_constraint();
					}
					} 
				}
				setState(509);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Type_nameContext extends ParserRuleContext {
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Signed_numberContext> signed_number() {
			return getRuleContexts(Signed_numberContext.class);
		}
		public Signed_numberContext signed_number(int i) {
			return getRuleContext(Signed_numberContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Type_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type_name; }
	}

	public final Type_nameContext type_name() throws RecognitionException {
		Type_nameContext _localctx = new Type_nameContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_type_name);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(511); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(510);
					name();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(513); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(525);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,43,_ctx) ) {
			case 1:
				{
				setState(515);
				match(OPEN_PAR);
				setState(516);
				signed_number();
				setState(517);
				match(CLOSE_PAR);
				}
				break;
			case 2:
				{
				setState(519);
				match(OPEN_PAR);
				setState(520);
				signed_number();
				setState(521);
				match(COMMA);
				setState(522);
				signed_number();
				setState(523);
				match(CLOSE_PAR);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_constraintContext extends ParserRuleContext {
		public TerminalNode CHECK() { return getToken(SQLiteParser.CHECK, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode DEFAULT() { return getToken(SQLiteParser.DEFAULT, 0); }
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Foreign_key_clauseContext foreign_key_clause() {
			return getRuleContext(Foreign_key_clauseContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public TerminalNode CONSTRAINT() { return getToken(SQLiteParser.CONSTRAINT, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode PRIMARY() { return getToken(SQLiteParser.PRIMARY, 0); }
		public TerminalNode KEY() { return getToken(SQLiteParser.KEY, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public Conflict_clauseContext conflict_clause() {
			return getRuleContext(Conflict_clauseContext.class,0);
		}
		public TerminalNode GENERATED() { return getToken(SQLiteParser.GENERATED, 0); }
		public TerminalNode ALWAYS() { return getToken(SQLiteParser.ALWAYS, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public TerminalNode STORED() { return getToken(SQLiteParser.STORED, 0); }
		public TerminalNode VIRTUAL() { return getToken(SQLiteParser.VIRTUAL, 0); }
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public TerminalNode AUTOINCREMENT() { return getToken(SQLiteParser.AUTOINCREMENT, 0); }
		public Column_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_constraint; }
	}

	public final Column_constraintContext column_constraint() throws RecognitionException {
		Column_constraintContext _localctx = new Column_constraintContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_column_constraint);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(529);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CONSTRAINT) {
				{
				setState(527);
				match(CONSTRAINT);
				setState(528);
				name();
				}
			}

			setState(578);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PRIMARY:
				{
				{
				setState(531);
				match(PRIMARY);
				setState(532);
				match(KEY);
				setState(534);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ASC || _la==DESC) {
					{
					setState(533);
					asc_desc();
					}
				}

				setState(537);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(536);
					conflict_clause();
					}
				}

				setState(540);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AUTOINCREMENT) {
					{
					setState(539);
					match(AUTOINCREMENT);
					}
				}

				}
				}
				break;
			case NOT:
			case UNIQUE:
				{
				setState(545);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NOT:
					{
					{
					setState(542);
					match(NOT);
					setState(543);
					match(NULL_);
					}
					}
					break;
				case UNIQUE:
					{
					setState(544);
					match(UNIQUE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(548);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(547);
					conflict_clause();
					}
				}

				}
				break;
			case CHECK:
				{
				setState(550);
				match(CHECK);
				setState(551);
				match(OPEN_PAR);
				setState(552);
				expr(0);
				setState(553);
				match(CLOSE_PAR);
				}
				break;
			case DEFAULT:
				{
				setState(555);
				match(DEFAULT);
				setState(562);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,50,_ctx) ) {
				case 1:
					{
					setState(556);
					signed_number();
					}
					break;
				case 2:
					{
					setState(557);
					literal_value();
					}
					break;
				case 3:
					{
					{
					setState(558);
					match(OPEN_PAR);
					setState(559);
					expr(0);
					setState(560);
					match(CLOSE_PAR);
					}
					}
					break;
				}
				}
				break;
			case COLLATE:
				{
				setState(564);
				match(COLLATE);
				setState(565);
				collation_name();
				}
				break;
			case REFERENCES:
				{
				setState(566);
				foreign_key_clause();
				}
				break;
			case AS:
			case GENERATED:
				{
				setState(569);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==GENERATED) {
					{
					setState(567);
					match(GENERATED);
					setState(568);
					match(ALWAYS);
					}
				}

				setState(571);
				match(AS);
				setState(572);
				match(OPEN_PAR);
				setState(573);
				expr(0);
				setState(574);
				match(CLOSE_PAR);
				setState(576);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==VIRTUAL || _la==STORED) {
					{
					setState(575);
					_la = _input.LA(1);
					if ( !(_la==VIRTUAL || _la==STORED) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
				}

				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Signed_numberContext extends ParserRuleContext {
		public TerminalNode NUMERIC_LITERAL() { return getToken(SQLiteParser.NUMERIC_LITERAL, 0); }
		public TerminalNode PLUS() { return getToken(SQLiteParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(SQLiteParser.MINUS, 0); }
		public Signed_numberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_signed_number; }
	}

	public final Signed_numberContext signed_number() throws RecognitionException {
		Signed_numberContext _localctx = new Signed_numberContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_signed_number);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(581);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PLUS || _la==MINUS) {
				{
				setState(580);
				_la = _input.LA(1);
				if ( !(_la==PLUS || _la==MINUS) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(583);
			match(NUMERIC_LITERAL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_constraintContext extends ParserRuleContext {
		public TerminalNode CONSTRAINT() { return getToken(SQLiteParser.CONSTRAINT, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode CHECK() { return getToken(SQLiteParser.CHECK, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode FOREIGN() { return getToken(SQLiteParser.FOREIGN, 0); }
		public TerminalNode KEY() { return getToken(SQLiteParser.KEY, 0); }
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public Foreign_key_clauseContext foreign_key_clause() {
			return getRuleContext(Foreign_key_clauseContext.class,0);
		}
		public TerminalNode PRIMARY() { return getToken(SQLiteParser.PRIMARY, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Conflict_clauseContext conflict_clause() {
			return getRuleContext(Conflict_clauseContext.class,0);
		}
		public Table_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_constraint; }
	}

	public final Table_constraintContext table_constraint() throws RecognitionException {
		Table_constraintContext _localctx = new Table_constraintContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_table_constraint);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(587);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CONSTRAINT) {
				{
				setState(585);
				match(CONSTRAINT);
				setState(586);
				name();
				}
			}

			setState(617);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PRIMARY:
			case UNIQUE:
				{
				{
				setState(592);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case PRIMARY:
					{
					setState(589);
					match(PRIMARY);
					setState(590);
					match(KEY);
					}
					break;
				case UNIQUE:
					{
					setState(591);
					match(UNIQUE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(594);
				match(OPEN_PAR);
				setState(595);
				indexed_column();
				setState(600);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(596);
					match(COMMA);
					setState(597);
					indexed_column();
					}
					}
					setState(602);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(603);
				match(CLOSE_PAR);
				setState(605);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(604);
					conflict_clause();
					}
				}

				}
				}
				break;
			case CHECK:
				{
				{
				setState(607);
				match(CHECK);
				setState(608);
				match(OPEN_PAR);
				setState(609);
				expr(0);
				setState(610);
				match(CLOSE_PAR);
				}
				}
				break;
			case FOREIGN:
				{
				{
				setState(612);
				match(FOREIGN);
				setState(613);
				match(KEY);
				setState(614);
				column_name_list();
				setState(615);
				foreign_key_clause();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Foreign_key_clauseContext extends ParserRuleContext {
		public TerminalNode REFERENCES() { return getToken(SQLiteParser.REFERENCES, 0); }
		public Foreign_tableContext foreign_table() {
			return getRuleContext(Foreign_tableContext.class,0);
		}
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public TerminalNode DEFERRABLE() { return getToken(SQLiteParser.DEFERRABLE, 0); }
		public List<TerminalNode> ON() { return getTokens(SQLiteParser.ON); }
		public TerminalNode ON(int i) {
			return getToken(SQLiteParser.ON, i);
		}
		public List<TerminalNode> MATCH() { return getTokens(SQLiteParser.MATCH); }
		public TerminalNode MATCH(int i) {
			return getToken(SQLiteParser.MATCH, i);
		}
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public List<TerminalNode> DELETE() { return getTokens(SQLiteParser.DELETE); }
		public TerminalNode DELETE(int i) {
			return getToken(SQLiteParser.DELETE, i);
		}
		public List<TerminalNode> UPDATE() { return getTokens(SQLiteParser.UPDATE); }
		public TerminalNode UPDATE(int i) {
			return getToken(SQLiteParser.UPDATE, i);
		}
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode INITIALLY() { return getToken(SQLiteParser.INITIALLY, 0); }
		public List<TerminalNode> CASCADE() { return getTokens(SQLiteParser.CASCADE); }
		public TerminalNode CASCADE(int i) {
			return getToken(SQLiteParser.CASCADE, i);
		}
		public List<TerminalNode> RESTRICT() { return getTokens(SQLiteParser.RESTRICT); }
		public TerminalNode RESTRICT(int i) {
			return getToken(SQLiteParser.RESTRICT, i);
		}
		public TerminalNode DEFERRED() { return getToken(SQLiteParser.DEFERRED, 0); }
		public TerminalNode IMMEDIATE() { return getToken(SQLiteParser.IMMEDIATE, 0); }
		public List<TerminalNode> SET() { return getTokens(SQLiteParser.SET); }
		public TerminalNode SET(int i) {
			return getToken(SQLiteParser.SET, i);
		}
		public List<TerminalNode> NO() { return getTokens(SQLiteParser.NO); }
		public TerminalNode NO(int i) {
			return getToken(SQLiteParser.NO, i);
		}
		public List<TerminalNode> ACTION() { return getTokens(SQLiteParser.ACTION); }
		public TerminalNode ACTION(int i) {
			return getToken(SQLiteParser.ACTION, i);
		}
		public List<TerminalNode> NULL_() { return getTokens(SQLiteParser.NULL_); }
		public TerminalNode NULL_(int i) {
			return getToken(SQLiteParser.NULL_, i);
		}
		public List<TerminalNode> DEFAULT() { return getTokens(SQLiteParser.DEFAULT); }
		public TerminalNode DEFAULT(int i) {
			return getToken(SQLiteParser.DEFAULT, i);
		}
		public Foreign_key_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_foreign_key_clause; }
	}

	public final Foreign_key_clauseContext foreign_key_clause() throws RecognitionException {
		Foreign_key_clauseContext _localctx = new Foreign_key_clauseContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_foreign_key_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(619);
			match(REFERENCES);
			setState(620);
			foreign_table();
			setState(622);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(621);
				column_name_list();
				}
			}

			setState(638);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==MATCH || _la==ON) {
				{
				setState(636);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case ON:
					{
					{
					setState(624);
					match(ON);
					setState(625);
					_la = _input.LA(1);
					if ( !(_la==DELETE || _la==UPDATE) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(632);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case SET:
						{
						{
						setState(626);
						match(SET);
						setState(627);
						_la = _input.LA(1);
						if ( !(_la==DEFAULT || _la==NULL_) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						}
						}
						break;
					case CASCADE:
						{
						setState(628);
						match(CASCADE);
						}
						break;
					case RESTRICT:
						{
						setState(629);
						match(RESTRICT);
						}
						break;
					case NO:
						{
						{
						setState(630);
						match(NO);
						setState(631);
						match(ACTION);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					}
					}
					break;
				case MATCH:
					{
					{
					setState(634);
					match(MATCH);
					setState(635);
					name();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(640);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(649);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,66,_ctx) ) {
			case 1:
				{
				setState(642);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(641);
					match(NOT);
					}
				}

				setState(644);
				match(DEFERRABLE);
				setState(647);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==INITIALLY) {
					{
					setState(645);
					match(INITIALLY);
					setState(646);
					_la = _input.LA(1);
					if ( !(_la==DEFERRED || _la==IMMEDIATE) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
				}

				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Conflict_clauseContext extends ParserRuleContext {
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public TerminalNode CONFLICT() { return getToken(SQLiteParser.CONFLICT, 0); }
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public Conflict_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_conflict_clause; }
	}

	public final Conflict_clauseContext conflict_clause() throws RecognitionException {
		Conflict_clauseContext _localctx = new Conflict_clauseContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_conflict_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(651);
			match(ON);
			setState(652);
			match(CONFLICT);
			setState(653);
			_la = _input.LA(1);
			if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_trigger_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode TRIGGER() { return getToken(SQLiteParser.TRIGGER, 0); }
		public Trigger_nameContext trigger_name() {
			return getRuleContext(Trigger_nameContext.class,0);
		}
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode BEGIN() { return getToken(SQLiteParser.BEGIN, 0); }
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode INSERT() { return getToken(SQLiteParser.INSERT, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode BEFORE() { return getToken(SQLiteParser.BEFORE, 0); }
		public TerminalNode AFTER() { return getToken(SQLiteParser.AFTER, 0); }
		public TerminalNode FOR() { return getToken(SQLiteParser.FOR, 0); }
		public TerminalNode EACH() { return getToken(SQLiteParser.EACH, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode WHEN() { return getToken(SQLiteParser.WHEN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public List<TerminalNode> SCOL() { return getTokens(SQLiteParser.SCOL); }
		public TerminalNode SCOL(int i) {
			return getToken(SQLiteParser.SCOL, i);
		}
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public TerminalNode INSTEAD() { return getToken(SQLiteParser.INSTEAD, 0); }
		public List<TerminalNode> OF() { return getTokens(SQLiteParser.OF); }
		public TerminalNode OF(int i) {
			return getToken(SQLiteParser.OF, i);
		}
		public List<Update_stmtContext> update_stmt() {
			return getRuleContexts(Update_stmtContext.class);
		}
		public Update_stmtContext update_stmt(int i) {
			return getRuleContext(Update_stmtContext.class,i);
		}
		public List<Insert_stmtContext> insert_stmt() {
			return getRuleContexts(Insert_stmtContext.class);
		}
		public Insert_stmtContext insert_stmt(int i) {
			return getRuleContext(Insert_stmtContext.class,i);
		}
		public List<Delete_stmtContext> delete_stmt() {
			return getRuleContexts(Delete_stmtContext.class);
		}
		public Delete_stmtContext delete_stmt(int i) {
			return getRuleContext(Delete_stmtContext.class,i);
		}
		public List<Select_stmtContext> select_stmt() {
			return getRuleContexts(Select_stmtContext.class);
		}
		public Select_stmtContext select_stmt(int i) {
			return getRuleContext(Select_stmtContext.class,i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Create_trigger_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_trigger_stmt; }
	}

	public final Create_trigger_stmtContext create_trigger_stmt() throws RecognitionException {
		Create_trigger_stmtContext _localctx = new Create_trigger_stmtContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_create_trigger_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(655);
			match(CREATE);
			setState(657);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(656);
				_la = _input.LA(1);
				if ( !(_la==TEMP || _la==TEMPORARY) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(659);
			match(TRIGGER);
			setState(663);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,68,_ctx) ) {
			case 1:
				{
				setState(660);
				match(IF);
				setState(661);
				match(NOT);
				setState(662);
				match(EXISTS);
				}
				break;
			}
			setState(668);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,69,_ctx) ) {
			case 1:
				{
				setState(665);
				schema_name();
				setState(666);
				match(DOT);
				}
				break;
			}
			setState(670);
			trigger_name();
			setState(675);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BEFORE:
				{
				setState(671);
				match(BEFORE);
				}
				break;
			case AFTER:
				{
				setState(672);
				match(AFTER);
				}
				break;
			case INSTEAD:
				{
				{
				setState(673);
				match(INSTEAD);
				setState(674);
				match(OF);
				}
				}
				break;
			case DELETE:
			case INSERT:
			case UPDATE:
				break;
			default:
				break;
			}
			setState(691);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case DELETE:
				{
				setState(677);
				match(DELETE);
				}
				break;
			case INSERT:
				{
				setState(678);
				match(INSERT);
				}
				break;
			case UPDATE:
				{
				{
				setState(679);
				match(UPDATE);
				setState(689);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==OF) {
					{
					setState(680);
					match(OF);
					setState(681);
					column_name();
					setState(686);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(682);
						match(COMMA);
						setState(683);
						column_name();
						}
						}
						setState(688);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(693);
			match(ON);
			setState(694);
			table_name();
			setState(698);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FOR) {
				{
				setState(695);
				match(FOR);
				setState(696);
				match(EACH);
				setState(697);
				match(ROW);
				}
			}

			setState(702);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHEN) {
				{
				setState(700);
				match(WHEN);
				setState(701);
				expr(0);
				}
			}

			setState(704);
			match(BEGIN);
			setState(713); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(709);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,76,_ctx) ) {
				case 1:
					{
					setState(705);
					update_stmt();
					}
					break;
				case 2:
					{
					setState(706);
					insert_stmt();
					}
					break;
				case 3:
					{
					setState(707);
					delete_stmt();
					}
					break;
				case 4:
					{
					setState(708);
					select_stmt();
					}
					break;
				}
				setState(711);
				match(SCOL);
				}
				}
				setState(715); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==DEFAULT || _la==DELETE || ((((_la - 88)) & ~0x3f) == 0 && ((1L << (_la - 88)) & ((1L << (INSERT - 88)) | (1L << (REPLACE - 88)) | (1L << (SELECT - 88)) | (1L << (UPDATE - 88)) | (1L << (VALUES - 88)) | (1L << (WITH - 88)))) != 0) );
			setState(717);
			match(END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_view_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode VIEW() { return getToken(SQLiteParser.VIEW, 0); }
		public View_nameContext view_name() {
			return getRuleContext(View_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public Create_view_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_view_stmt; }
	}

	public final Create_view_stmtContext create_view_stmt() throws RecognitionException {
		Create_view_stmtContext _localctx = new Create_view_stmtContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_create_view_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(719);
			match(CREATE);
			setState(721);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(720);
				_la = _input.LA(1);
				if ( !(_la==TEMP || _la==TEMPORARY) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(723);
			match(VIEW);
			setState(727);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,79,_ctx) ) {
			case 1:
				{
				setState(724);
				match(IF);
				setState(725);
				match(NOT);
				setState(726);
				match(EXISTS);
				}
				break;
			}
			setState(732);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,80,_ctx) ) {
			case 1:
				{
				setState(729);
				schema_name();
				setState(730);
				match(DOT);
				}
				break;
			}
			setState(734);
			view_name();
			setState(736);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(735);
				column_name_list();
				}
			}

			setState(738);
			match(AS);
			setState(739);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Create_virtual_table_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode VIRTUAL() { return getToken(SQLiteParser.VIRTUAL, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode USING() { return getToken(SQLiteParser.USING, 0); }
		public Module_nameContext module_name() {
			return getRuleContext(Module_nameContext.class,0);
		}
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Module_argumentContext> module_argument() {
			return getRuleContexts(Module_argumentContext.class);
		}
		public Module_argumentContext module_argument(int i) {
			return getRuleContext(Module_argumentContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Create_virtual_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_virtual_table_stmt; }
	}

	public final Create_virtual_table_stmtContext create_virtual_table_stmt() throws RecognitionException {
		Create_virtual_table_stmtContext _localctx = new Create_virtual_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_create_virtual_table_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(741);
			match(CREATE);
			setState(742);
			match(VIRTUAL);
			setState(743);
			match(TABLE);
			setState(747);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,82,_ctx) ) {
			case 1:
				{
				setState(744);
				match(IF);
				setState(745);
				match(NOT);
				setState(746);
				match(EXISTS);
				}
				break;
			}
			setState(752);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,83,_ctx) ) {
			case 1:
				{
				setState(749);
				schema_name();
				setState(750);
				match(DOT);
				}
				break;
			}
			setState(754);
			table_name();
			setState(755);
			match(USING);
			setState(756);
			module_name();
			setState(768);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(757);
				match(OPEN_PAR);
				setState(758);
				module_argument();
				setState(763);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(759);
					match(COMMA);
					setState(760);
					module_argument();
					}
					}
					setState(765);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(766);
				match(CLOSE_PAR);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class With_clauseContext extends ParserRuleContext {
		public TerminalNode WITH() { return getToken(SQLiteParser.WITH, 0); }
		public List<Cte_table_nameContext> cte_table_name() {
			return getRuleContexts(Cte_table_nameContext.class);
		}
		public Cte_table_nameContext cte_table_name(int i) {
			return getRuleContext(Cte_table_nameContext.class,i);
		}
		public List<TerminalNode> AS() { return getTokens(SQLiteParser.AS); }
		public TerminalNode AS(int i) {
			return getToken(SQLiteParser.AS, i);
		}
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public List<Select_stmtContext> select_stmt() {
			return getRuleContexts(Select_stmtContext.class);
		}
		public Select_stmtContext select_stmt(int i) {
			return getRuleContext(Select_stmtContext.class,i);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public TerminalNode RECURSIVE() { return getToken(SQLiteParser.RECURSIVE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public With_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_with_clause; }
	}

	public final With_clauseContext with_clause() throws RecognitionException {
		With_clauseContext _localctx = new With_clauseContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_with_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(770);
			match(WITH);
			setState(772);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,86,_ctx) ) {
			case 1:
				{
				setState(771);
				match(RECURSIVE);
				}
				break;
			}
			setState(774);
			cte_table_name();
			setState(775);
			match(AS);
			setState(776);
			match(OPEN_PAR);
			setState(777);
			select_stmt();
			setState(778);
			match(CLOSE_PAR);
			setState(788);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(779);
				match(COMMA);
				setState(780);
				cte_table_name();
				setState(781);
				match(AS);
				setState(782);
				match(OPEN_PAR);
				setState(783);
				select_stmt();
				setState(784);
				match(CLOSE_PAR);
				}
				}
				setState(790);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Cte_table_nameContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public Cte_table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cte_table_name; }
	}

	public final Cte_table_nameContext cte_table_name() throws RecognitionException {
		Cte_table_nameContext _localctx = new Cte_table_nameContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_cte_table_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(791);
			table_name();
			setState(793);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(792);
				column_name_list();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Recursive_cteContext extends ParserRuleContext {
		public Cte_table_nameContext cte_table_name() {
			return getRuleContext(Cte_table_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public Initial_selectContext initial_select() {
			return getRuleContext(Initial_selectContext.class,0);
		}
		public TerminalNode UNION() { return getToken(SQLiteParser.UNION, 0); }
		public Recursive_selectContext recursive_select() {
			return getRuleContext(Recursive_selectContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public Recursive_cteContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_recursive_cte; }
	}

	public final Recursive_cteContext recursive_cte() throws RecognitionException {
		Recursive_cteContext _localctx = new Recursive_cteContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_recursive_cte);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(795);
			cte_table_name();
			setState(796);
			match(AS);
			setState(797);
			match(OPEN_PAR);
			setState(798);
			initial_select();
			setState(799);
			match(UNION);
			setState(801);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ALL) {
				{
				setState(800);
				match(ALL);
				}
			}

			setState(803);
			recursive_select();
			setState(804);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Common_table_expressionContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public Common_table_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_common_table_expression; }
	}

	public final Common_table_expressionContext common_table_expression() throws RecognitionException {
		Common_table_expressionContext _localctx = new Common_table_expressionContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_common_table_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(806);
			table_name();
			setState(808);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(807);
				column_name_list();
				}
			}

			setState(810);
			match(AS);
			setState(811);
			match(OPEN_PAR);
			setState(812);
			select_stmt();
			setState(813);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Delete_stmtContext extends ParserRuleContext {
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public Delete_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_delete_stmt; }
	}

	public final Delete_stmtContext delete_stmt() throws RecognitionException {
		Delete_stmtContext _localctx = new Delete_stmtContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_delete_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(816);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(815);
				with_clause();
				}
			}

			setState(818);
			match(DELETE);
			setState(819);
			match(FROM);
			setState(820);
			qualified_table_name();
			setState(822);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(821);
				where_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Delete_stmt_limitedContext extends ParserRuleContext {
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public Limit_stmtsContext limit_stmts() {
			return getRuleContext(Limit_stmtsContext.class,0);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Delete_stmt_limitedContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_delete_stmt_limited; }
	}

	public final Delete_stmt_limitedContext delete_stmt_limited() throws RecognitionException {
		Delete_stmt_limitedContext _localctx = new Delete_stmt_limitedContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_delete_stmt_limited);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(825);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(824);
				with_clause();
				}
			}

			setState(827);
			match(DELETE);
			setState(828);
			match(FROM);
			setState(829);
			qualified_table_name();
			setState(831);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(830);
				where_stmt();
				}
			}

			setState(837);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT || _la==ORDER) {
				{
				setState(834);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(833);
					order_by_stmt();
					}
				}

				setState(836);
				limit_stmts();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Detach_stmtContext extends ParserRuleContext {
		public TerminalNode DETACH() { return getToken(SQLiteParser.DETACH, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DATABASE() { return getToken(SQLiteParser.DATABASE, 0); }
		public Detach_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_detach_stmt; }
	}

	public final Detach_stmtContext detach_stmt() throws RecognitionException {
		Detach_stmtContext _localctx = new Detach_stmtContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_detach_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(839);
			match(DETACH);
			setState(841);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,97,_ctx) ) {
			case 1:
				{
				setState(840);
				match(DATABASE);
				}
				break;
			}
			setState(843);
			schema_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Drop_stmtContext extends ParserRuleContext {
		public Token object;
		public TerminalNode DROP() { return getToken(SQLiteParser.DROP, 0); }
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public TerminalNode INDEX() { return getToken(SQLiteParser.INDEX, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public TerminalNode TRIGGER() { return getToken(SQLiteParser.TRIGGER, 0); }
		public TerminalNode VIEW() { return getToken(SQLiteParser.VIEW, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Drop_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_drop_stmt; }
	}

	public final Drop_stmtContext drop_stmt() throws RecognitionException {
		Drop_stmtContext _localctx = new Drop_stmtContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_drop_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(845);
			match(DROP);
			setState(846);
			((Drop_stmtContext)_localctx).object = _input.LT(1);
			_la = _input.LA(1);
			if ( !(((((_la - 84)) & ~0x3f) == 0 && ((1L << (_la - 84)) & ((1L << (INDEX - 84)) | (1L << (TABLE - 84)) | (1L << (TRIGGER - 84)) | (1L << (VIEW - 84)))) != 0)) ) {
				((Drop_stmtContext)_localctx).object = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(849);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,98,_ctx) ) {
			case 1:
				{
				setState(847);
				match(IF);
				setState(848);
				match(EXISTS);
				}
				break;
			}
			setState(854);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,99,_ctx) ) {
			case 1:
				{
				setState(851);
				schema_name();
				setState(852);
				match(DOT);
				}
				break;
			}
			setState(856);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExprContext extends ParserRuleContext {
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public TerminalNode BIND_PARAMETER() { return getToken(SQLiteParser.BIND_PARAMETER, 0); }
		public FullnameContext fullname() {
			return getRuleContext(FullnameContext.class,0);
		}
		public Unary_operatorContext unary_operator() {
			return getRuleContext(Unary_operatorContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Call_function_exprContext call_function_expr() {
			return getRuleContext(Call_function_exprContext.class,0);
		}
		public TerminalNode CAST() { return getToken(SQLiteParser.CAST, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Type_nameContext type_name() {
			return getRuleContext(Type_nameContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Exists_exprContext exists_expr() {
			return getRuleContext(Exists_exprContext.class,0);
		}
		public Case_expressionContext case_expression() {
			return getRuleContext(Case_expressionContext.class,0);
		}
		public Raise_functionContext raise_function() {
			return getRuleContext(Raise_functionContext.class,0);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public Binary_operatorContext binary_operator() {
			return getRuleContext(Binary_operatorContext.class,0);
		}
		public TerminalNode BETWEEN() { return getToken(SQLiteParser.BETWEEN, 0); }
		public TerminalNode AND() { return getToken(SQLiteParser.AND, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Nullable_exprContext nullable_expr() {
			return getRuleContext(Nullable_exprContext.class,0);
		}
		public In_exprContext in_expr() {
			return getRuleContext(In_exprContext.class,0);
		}
		public Like_operatorContext like_operator() {
			return getRuleContext(Like_operatorContext.class,0);
		}
		public TerminalNode ESCAPE() { return getToken(SQLiteParser.ESCAPE, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	}

	public final ExprContext expr() throws RecognitionException {
		return expr(0);
	}

	private ExprContext expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 68;
		enterRecursionRule(_localctx, 68, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(883);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,101,_ctx) ) {
			case 1:
				{
				setState(859);
				literal_value();
				}
				break;
			case 2:
				{
				setState(860);
				match(BIND_PARAMETER);
				}
				break;
			case 3:
				{
				setState(861);
				fullname();
				}
				break;
			case 4:
				{
				setState(862);
				unary_operator();
				setState(863);
				expr(13);
				}
				break;
			case 5:
				{
				setState(865);
				call_function_expr();
				}
				break;
			case 6:
				{
				setState(866);
				match(CAST);
				setState(867);
				match(OPEN_PAR);
				setState(868);
				expr(0);
				setState(869);
				match(AS);
				setState(870);
				type_name();
				setState(871);
				match(CLOSE_PAR);
				}
				break;
			case 7:
				{
				setState(873);
				exists_expr();
				}
				break;
			case 8:
				{
				setState(874);
				case_expression();
				}
				break;
			case 9:
				{
				setState(875);
				raise_function();
				}
				break;
			case 10:
				{
				setState(876);
				match(OPEN_PAR);
				setState(879);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,100,_ctx) ) {
				case 1:
					{
					setState(877);
					expr(0);
					}
					break;
				case 2:
					{
					setState(878);
					expr_list();
					}
					break;
				}
				setState(881);
				match(CLOSE_PAR);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(917);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,106,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(915);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,105,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(885);
						if (!(precpred(_ctx, 12))) throw new FailedPredicateException(this, "precpred(_ctx, 12)");
						setState(886);
						binary_operator();
						setState(887);
						expr(13);
						}
						break;
					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(889);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(891);
						_errHandler.sync(this);
						_la = _input.LA(1);
						if (_la==NOT) {
							{
							setState(890);
							match(NOT);
							}
						}

						setState(893);
						match(BETWEEN);
						setState(894);
						expr(0);
						setState(895);
						match(AND);
						setState(896);
						expr(4);
						}
						break;
					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(898);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(899);
						match(COLLATE);
						setState(900);
						collation_name();
						}
						break;
					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(901);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(902);
						nullable_expr();
						}
						break;
					case 5:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(903);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(904);
						in_expr();
						}
						break;
					case 6:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(905);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(907);
						_errHandler.sync(this);
						_la = _input.LA(1);
						if (_la==NOT) {
							{
							setState(906);
							match(NOT);
							}
						}

						setState(909);
						like_operator();
						setState(910);
						expr(0);
						setState(913);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,104,_ctx) ) {
						case 1:
							{
							setState(911);
							match(ESCAPE);
							setState(912);
							expr(0);
							}
							break;
						}
						}
						break;
					}
					} 
				}
				setState(919);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,106,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class Call_function_exprContext extends ParserRuleContext {
		public Function_nameContext function_name() {
			return getRuleContext(Function_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Filter_clauseContext filter_clause() {
			return getRuleContext(Filter_clauseContext.class,0);
		}
		public Over_clauseContext over_clause() {
			return getRuleContext(Over_clauseContext.class,0);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public Call_function_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_call_function_expr; }
	}

	public final Call_function_exprContext call_function_expr() throws RecognitionException {
		Call_function_exprContext _localctx = new Call_function_exprContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_call_function_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(920);
			function_name();
			setState(921);
			match(OPEN_PAR);
			setState(927);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
			case PLUS:
			case MINUS:
			case TILDE:
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
			case IDENTIFIER:
			case NUMERIC_LITERAL:
			case BIND_PARAMETER:
			case STRING_LITERAL:
			case BLOB_LITERAL:
				{
				{
				setState(923);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,107,_ctx) ) {
				case 1:
					{
					setState(922);
					match(DISTINCT);
					}
					break;
				}
				setState(925);
				expr_list();
				}
				}
				break;
			case STAR:
				{
				setState(926);
				match(STAR);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			setState(929);
			match(CLOSE_PAR);
			setState(931);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,109,_ctx) ) {
			case 1:
				{
				setState(930);
				filter_clause();
				}
				break;
			}
			setState(934);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,110,_ctx) ) {
			case 1:
				{
				setState(933);
				over_clause();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class In_exprContext extends ParserRuleContext {
		public TerminalNode IN() { return getToken(SQLiteParser.IN, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Table_function_nameContext table_function_name() {
			return getRuleContext(Table_function_nameContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public In_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_in_expr; }
	}

	public final In_exprContext in_expr() throws RecognitionException {
		In_exprContext _localctx = new In_exprContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_in_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(937);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NOT) {
				{
				setState(936);
				match(NOT);
				}
			}

			setState(939);
			match(IN);
			setState(964);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,116,_ctx) ) {
			case 1:
				{
				{
				setState(940);
				match(OPEN_PAR);
				setState(943);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,112,_ctx) ) {
				case 1:
					{
					setState(941);
					select_stmt();
					}
					break;
				case 2:
					{
					setState(942);
					expr_list();
					}
					break;
				}
				setState(945);
				match(CLOSE_PAR);
				}
				}
				break;
			case 2:
				{
				{
				setState(949);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,113,_ctx) ) {
				case 1:
					{
					setState(946);
					schema_name();
					setState(947);
					match(DOT);
					}
					break;
				}
				setState(951);
				table_name();
				}
				}
				break;
			case 3:
				{
				{
				setState(955);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,114,_ctx) ) {
				case 1:
					{
					setState(952);
					schema_name();
					setState(953);
					match(DOT);
					}
					break;
				}
				setState(957);
				table_function_name();
				setState(958);
				match(OPEN_PAR);
				setState(960);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAR) | (1L << PLUS) | (1L << MINUS) | (1L << TILDE) | (1L << ABORT) | (1L << ACTION) | (1L << ADD) | (1L << AFTER) | (1L << ALL) | (1L << ALTER) | (1L << ANALYZE) | (1L << AND) | (1L << AS) | (1L << ASC) | (1L << ATTACH) | (1L << AUTOINCREMENT) | (1L << BEFORE) | (1L << BEGIN) | (1L << BETWEEN) | (1L << BY) | (1L << CASCADE) | (1L << CASE) | (1L << CAST) | (1L << CHECK) | (1L << COLLATE) | (1L << COLUMN) | (1L << COMMIT) | (1L << CONFLICT) | (1L << CONSTRAINT) | (1L << CREATE) | (1L << CROSS) | (1L << CURRENT_DATE) | (1L << CURRENT_TIME) | (1L << CURRENT_TIMESTAMP) | (1L << DATABASE) | (1L << DEFAULT) | (1L << DEFERRABLE) | (1L << DEFERRED) | (1L << DELETE) | (1L << DESC) | (1L << DETACH) | (1L << DISTINCT) | (1L << DROP))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (EACH - 64)) | (1L << (ELSE - 64)) | (1L << (END - 64)) | (1L << (ESCAPE - 64)) | (1L << (EXCEPT - 64)) | (1L << (EXCLUSIVE - 64)) | (1L << (EXISTS - 64)) | (1L << (EXPLAIN - 64)) | (1L << (FAIL - 64)) | (1L << (FOR - 64)) | (1L << (FOREIGN - 64)) | (1L << (FROM - 64)) | (1L << (FULL - 64)) | (1L << (GLOB - 64)) | (1L << (GROUP - 64)) | (1L << (HAVING - 64)) | (1L << (IF - 64)) | (1L << (IGNORE - 64)) | (1L << (IMMEDIATE - 64)) | (1L << (IN - 64)) | (1L << (INDEX - 64)) | (1L << (INDEXED - 64)) | (1L << (INITIALLY - 64)) | (1L << (INNER - 64)) | (1L << (INSERT - 64)) | (1L << (INSTEAD - 64)) | (1L << (INTERSECT - 64)) | (1L << (INTO - 64)) | (1L << (IS - 64)) | (1L << (ISNULL - 64)) | (1L << (JOIN - 64)) | (1L << (KEY - 64)) | (1L << (LEFT - 64)) | (1L << (LIKE - 64)) | (1L << (LIMIT - 64)) | (1L << (MATCH - 64)) | (1L << (NATURAL - 64)) | (1L << (NO - 64)) | (1L << (NOT - 64)) | (1L << (NOTNULL - 64)) | (1L << (NULL_ - 64)) | (1L << (OF - 64)) | (1L << (OFFSET - 64)) | (1L << (ON - 64)) | (1L << (OR - 64)) | (1L << (ORDER - 64)) | (1L << (OUTER - 64)) | (1L << (PLAN - 64)) | (1L << (PRAGMA - 64)) | (1L << (PRIMARY - 64)) | (1L << (QUERY - 64)) | (1L << (RAISE - 64)) | (1L << (RECURSIVE - 64)) | (1L << (REFERENCES - 64)) | (1L << (REGEXP - 64)) | (1L << (REINDEX - 64)) | (1L << (RELEASE - 64)) | (1L << (RENAME - 64)) | (1L << (REPLACE - 64)) | (1L << (RESTRICT - 64)) | (1L << (RIGHT - 64)) | (1L << (ROLLBACK - 64)) | (1L << (ROW - 64)) | (1L << (ROWS - 64)))) != 0) || ((((_la - 128)) & ~0x3f) == 0 && ((1L << (_la - 128)) & ((1L << (SAVEPOINT - 128)) | (1L << (SELECT - 128)) | (1L << (SET - 128)) | (1L << (TABLE - 128)) | (1L << (TEMP - 128)) | (1L << (TEMPORARY - 128)) | (1L << (THEN - 128)) | (1L << (TO - 128)) | (1L << (TRANSACTION - 128)) | (1L << (TRIGGER - 128)) | (1L << (UNION - 128)) | (1L << (UNIQUE - 128)) | (1L << (UPDATE - 128)) | (1L << (USING - 128)) | (1L << (VACUUM - 128)) | (1L << (VALUES - 128)) | (1L << (VIEW - 128)) | (1L << (VIRTUAL - 128)) | (1L << (WHEN - 128)) | (1L << (WHERE - 128)) | (1L << (WITH - 128)) | (1L << (WITHOUT - 128)) | (1L << (FIRST_VALUE - 128)) | (1L << (OVER - 128)) | (1L << (PARTITION - 128)) | (1L << (RANGE - 128)) | (1L << (PRECEDING - 128)) | (1L << (UNBOUNDED - 128)) | (1L << (CURRENT - 128)) | (1L << (FOLLOWING - 128)) | (1L << (CUME_DIST - 128)) | (1L << (DENSE_RANK - 128)) | (1L << (LAG - 128)) | (1L << (LAST_VALUE - 128)) | (1L << (LEAD - 128)) | (1L << (NTH_VALUE - 128)) | (1L << (NTILE - 128)) | (1L << (PERCENT_RANK - 128)) | (1L << (RANK - 128)) | (1L << (ROW_NUMBER - 128)) | (1L << (GENERATED - 128)) | (1L << (ALWAYS - 128)) | (1L << (STORED - 128)) | (1L << (TRUE_ - 128)) | (1L << (FALSE_ - 128)) | (1L << (WINDOW - 128)) | (1L << (NULLS - 128)) | (1L << (FIRST - 128)) | (1L << (LAST - 128)) | (1L << (FILTER - 128)) | (1L << (GROUPS - 128)) | (1L << (EXCLUDE - 128)) | (1L << (IDENTIFIER - 128)) | (1L << (NUMERIC_LITERAL - 128)) | (1L << (BIND_PARAMETER - 128)) | (1L << (STRING_LITERAL - 128)) | (1L << (BLOB_LITERAL - 128)))) != 0)) {
					{
					setState(959);
					expr_list();
					}
				}

				setState(962);
				match(CLOSE_PAR);
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Case_expressionContext extends ParserRuleContext {
		public Case_exprContext case_expr() {
			return getRuleContext(Case_exprContext.class,0);
		}
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public List<Case_whenContext> case_when() {
			return getRuleContexts(Case_whenContext.class);
		}
		public Case_whenContext case_when(int i) {
			return getRuleContext(Case_whenContext.class,i);
		}
		public Case_else_exprContext case_else_expr() {
			return getRuleContext(Case_else_exprContext.class,0);
		}
		public Case_expressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_case_expression; }
	}

	public final Case_expressionContext case_expression() throws RecognitionException {
		Case_expressionContext _localctx = new Case_expressionContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_case_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(966);
			case_expr();
			setState(968); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(967);
				case_when();
				}
				}
				setState(970); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==WHEN );
			setState(973);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(972);
				case_else_expr();
				}
			}

			setState(975);
			match(END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Case_whenContext extends ParserRuleContext {
		public TerminalNode WHEN() { return getToken(SQLiteParser.WHEN, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode THEN() { return getToken(SQLiteParser.THEN, 0); }
		public Case_whenContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_case_when; }
	}

	public final Case_whenContext case_when() throws RecognitionException {
		Case_whenContext _localctx = new Case_whenContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_case_when);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(977);
			match(WHEN);
			setState(978);
			expr(0);
			setState(979);
			match(THEN);
			setState(980);
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Case_exprContext extends ParserRuleContext {
		public TerminalNode CASE() { return getToken(SQLiteParser.CASE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Case_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_case_expr; }
	}

	public final Case_exprContext case_expr() throws RecognitionException {
		Case_exprContext _localctx = new Case_exprContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_case_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(982);
			match(CASE);
			setState(984);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,119,_ctx) ) {
			case 1:
				{
				setState(983);
				expr(0);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Case_else_exprContext extends ParserRuleContext {
		public TerminalNode ELSE() { return getToken(SQLiteParser.ELSE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Case_else_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_case_else_expr; }
	}

	public final Case_else_exprContext case_else_expr() throws RecognitionException {
		Case_else_exprContext _localctx = new Case_else_exprContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_case_else_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(986);
			match(ELSE);
			setState(987);
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Exists_exprContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public Exists_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exists_expr; }
	}

	public final Exists_exprContext exists_expr() throws RecognitionException {
		Exists_exprContext _localctx = new Exists_exprContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_exists_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(993);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXISTS || _la==NOT) {
				{
				setState(990);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(989);
					match(NOT);
					}
				}

				setState(992);
				match(EXISTS);
				}
			}

			setState(995);
			match(OPEN_PAR);
			setState(996);
			select_stmt();
			setState(997);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Nullable_exprContext extends ParserRuleContext {
		public TerminalNode ISNULL() { return getToken(SQLiteParser.ISNULL, 0); }
		public TerminalNode NOTNULL() { return getToken(SQLiteParser.NOTNULL, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public Nullable_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nullable_expr; }
	}

	public final Nullable_exprContext nullable_expr() throws RecognitionException {
		Nullable_exprContext _localctx = new Nullable_exprContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_nullable_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1003);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ISNULL:
				{
				setState(999);
				match(ISNULL);
				}
				break;
			case NOTNULL:
				{
				setState(1000);
				match(NOTNULL);
				}
				break;
			case NOT:
				{
				{
				setState(1001);
				match(NOT);
				setState(1002);
				match(NULL_);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FullnameContext extends ParserRuleContext {
		public Column_nameContext column_name() {
			return getRuleContext(Column_nameContext.class,0);
		}
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public List<TerminalNode> DOT() { return getTokens(SQLiteParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(SQLiteParser.DOT, i);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public FullnameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fullname; }
	}

	public final FullnameContext fullname() throws RecognitionException {
		FullnameContext _localctx = new FullnameContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_fullname);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1013);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,124,_ctx) ) {
			case 1:
				{
				setState(1008);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,123,_ctx) ) {
				case 1:
					{
					setState(1005);
					schema_name();
					setState(1006);
					match(DOT);
					}
					break;
				}
				setState(1010);
				table_name();
				setState(1011);
				match(DOT);
				}
				break;
			}
			setState(1015);
			column_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Binary_operatorContext extends ParserRuleContext {
		public TerminalNode PIPE2() { return getToken(SQLiteParser.PIPE2, 0); }
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public TerminalNode DIV() { return getToken(SQLiteParser.DIV, 0); }
		public TerminalNode MOD() { return getToken(SQLiteParser.MOD, 0); }
		public TerminalNode PLUS() { return getToken(SQLiteParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(SQLiteParser.MINUS, 0); }
		public TerminalNode LT2() { return getToken(SQLiteParser.LT2, 0); }
		public TerminalNode GT2() { return getToken(SQLiteParser.GT2, 0); }
		public TerminalNode AMP() { return getToken(SQLiteParser.AMP, 0); }
		public TerminalNode PIPE() { return getToken(SQLiteParser.PIPE, 0); }
		public TerminalNode LT() { return getToken(SQLiteParser.LT, 0); }
		public TerminalNode LT_EQ() { return getToken(SQLiteParser.LT_EQ, 0); }
		public TerminalNode GT() { return getToken(SQLiteParser.GT, 0); }
		public TerminalNode GT_EQ() { return getToken(SQLiteParser.GT_EQ, 0); }
		public TerminalNode ASSIGN() { return getToken(SQLiteParser.ASSIGN, 0); }
		public TerminalNode EQ() { return getToken(SQLiteParser.EQ, 0); }
		public TerminalNode NOT_EQ1() { return getToken(SQLiteParser.NOT_EQ1, 0); }
		public TerminalNode NOT_EQ2() { return getToken(SQLiteParser.NOT_EQ2, 0); }
		public TerminalNode IN() { return getToken(SQLiteParser.IN, 0); }
		public TerminalNode AND() { return getToken(SQLiteParser.AND, 0); }
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public TerminalNode IS() { return getToken(SQLiteParser.IS, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public Like_operatorContext like_operator() {
			return getRuleContext(Like_operatorContext.class,0);
		}
		public Binary_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_binary_operator; }
	}

	public final Binary_operatorContext binary_operator() throws RecognitionException {
		Binary_operatorContext _localctx = new Binary_operatorContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_binary_operator);
		int _la;
		try {
			setState(1034);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PIPE2:
				enterOuterAlt(_localctx, 1);
				{
				setState(1017);
				match(PIPE2);
				}
				break;
			case STAR:
			case DIV:
			case MOD:
				enterOuterAlt(_localctx, 2);
				{
				setState(1018);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << DIV) | (1L << MOD))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			case PLUS:
			case MINUS:
				enterOuterAlt(_localctx, 3);
				{
				setState(1019);
				_la = _input.LA(1);
				if ( !(_la==PLUS || _la==MINUS) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			case LT2:
			case GT2:
			case AMP:
			case PIPE:
				enterOuterAlt(_localctx, 4);
				{
				setState(1020);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LT2) | (1L << GT2) | (1L << AMP) | (1L << PIPE))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			case LT:
			case LT_EQ:
			case GT:
			case GT_EQ:
				enterOuterAlt(_localctx, 5);
				{
				setState(1021);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LT) | (1L << LT_EQ) | (1L << GT) | (1L << GT_EQ))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			case ASSIGN:
				enterOuterAlt(_localctx, 6);
				{
				setState(1022);
				match(ASSIGN);
				}
				break;
			case EQ:
				enterOuterAlt(_localctx, 7);
				{
				setState(1023);
				match(EQ);
				}
				break;
			case NOT_EQ1:
				enterOuterAlt(_localctx, 8);
				{
				setState(1024);
				match(NOT_EQ1);
				}
				break;
			case NOT_EQ2:
				enterOuterAlt(_localctx, 9);
				{
				setState(1025);
				match(NOT_EQ2);
				}
				break;
			case IN:
				enterOuterAlt(_localctx, 10);
				{
				setState(1026);
				match(IN);
				}
				break;
			case AND:
				enterOuterAlt(_localctx, 11);
				{
				setState(1027);
				match(AND);
				}
				break;
			case OR:
				enterOuterAlt(_localctx, 12);
				{
				setState(1028);
				match(OR);
				}
				break;
			case IS:
				enterOuterAlt(_localctx, 13);
				{
				setState(1029);
				match(IS);
				setState(1031);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,125,_ctx) ) {
				case 1:
					{
					setState(1030);
					match(NOT);
					}
					break;
				}
				}
				break;
			case GLOB:
			case LIKE:
			case MATCH:
			case REGEXP:
				enterOuterAlt(_localctx, 14);
				{
				setState(1033);
				like_operator();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Like_operatorContext extends ParserRuleContext {
		public TerminalNode LIKE() { return getToken(SQLiteParser.LIKE, 0); }
		public TerminalNode GLOB() { return getToken(SQLiteParser.GLOB, 0); }
		public TerminalNode MATCH() { return getToken(SQLiteParser.MATCH, 0); }
		public TerminalNode REGEXP() { return getToken(SQLiteParser.REGEXP, 0); }
		public Like_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_like_operator; }
	}

	public final Like_operatorContext like_operator() throws RecognitionException {
		Like_operatorContext _localctx = new Like_operatorContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_like_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1036);
			_la = _input.LA(1);
			if ( !(((((_la - 77)) & ~0x3f) == 0 && ((1L << (_la - 77)) & ((1L << (GLOB - 77)) | (1L << (LIKE - 77)) | (1L << (MATCH - 77)) | (1L << (REGEXP - 77)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Raise_functionContext extends ParserRuleContext {
		public TerminalNode RAISE() { return getToken(SQLiteParser.RAISE, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Error_messageContext error_message() {
			return getRuleContext(Error_messageContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public Raise_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_raise_function; }
	}

	public final Raise_functionContext raise_function() throws RecognitionException {
		Raise_functionContext _localctx = new Raise_functionContext(_ctx, getState());
		enterRule(_localctx, 92, RULE_raise_function);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1038);
			match(RAISE);
			setState(1039);
			match(OPEN_PAR);
			setState(1044);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IGNORE:
				{
				setState(1040);
				match(IGNORE);
				}
				break;
			case ABORT:
			case FAIL:
			case ROLLBACK:
				{
				{
				setState(1041);
				_la = _input.LA(1);
				if ( !(_la==ABORT || _la==FAIL || _la==ROLLBACK) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1042);
				match(COMMA);
				setState(1043);
				error_message();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1046);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Literal_valueContext extends ParserRuleContext {
		public TerminalNode NUMERIC_LITERAL() { return getToken(SQLiteParser.NUMERIC_LITERAL, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public TerminalNode BLOB_LITERAL() { return getToken(SQLiteParser.BLOB_LITERAL, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public TerminalNode TRUE_() { return getToken(SQLiteParser.TRUE_, 0); }
		public TerminalNode FALSE_() { return getToken(SQLiteParser.FALSE_, 0); }
		public TerminalNode CURRENT_TIME() { return getToken(SQLiteParser.CURRENT_TIME, 0); }
		public TerminalNode CURRENT_DATE() { return getToken(SQLiteParser.CURRENT_DATE, 0); }
		public TerminalNode CURRENT_TIMESTAMP() { return getToken(SQLiteParser.CURRENT_TIMESTAMP, 0); }
		public Literal_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal_value; }
	}

	public final Literal_valueContext literal_value() throws RecognitionException {
		Literal_valueContext _localctx = new Literal_valueContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_literal_value);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1048);
			_la = _input.LA(1);
			if ( !(((((_la - 52)) & ~0x3f) == 0 && ((1L << (_la - 52)) & ((1L << (CURRENT_DATE - 52)) | (1L << (CURRENT_TIME - 52)) | (1L << (CURRENT_TIMESTAMP - 52)) | (1L << (NULL_ - 52)))) != 0) || ((((_la - 171)) & ~0x3f) == 0 && ((1L << (_la - 171)) & ((1L << (TRUE_ - 171)) | (1L << (FALSE_ - 171)) | (1L << (NUMERIC_LITERAL - 171)) | (1L << (STRING_LITERAL - 171)) | (1L << (BLOB_LITERAL - 171)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Insert_stmtContext extends ParserRuleContext {
		public TerminalNode INTO() { return getToken(SQLiteParser.INTO, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode INSERT() { return getToken(SQLiteParser.INSERT, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public Upsert_clauseContext upsert_clause() {
			return getRuleContext(Upsert_clauseContext.class,0);
		}
		public TerminalNode VALUES() { return getToken(SQLiteParser.VALUES, 0); }
		public Value_list_stmtContext value_list_stmt() {
			return getRuleContext(Value_list_stmtContext.class,0);
		}
		public TerminalNode DEFAULT() { return getToken(SQLiteParser.DEFAULT, 0); }
		public Insert_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_insert_stmt; }
	}

	public final Insert_stmtContext insert_stmt() throws RecognitionException {
		Insert_stmtContext _localctx = new Insert_stmtContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_insert_stmt);
		int _la;
		try {
			setState(1084);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INSERT:
			case REPLACE:
			case WITH:
				enterOuterAlt(_localctx, 1);
				{
				setState(1051);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WITH) {
					{
					setState(1050);
					with_clause();
					}
				}

				setState(1058);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,129,_ctx) ) {
				case 1:
					{
					setState(1053);
					match(INSERT);
					}
					break;
				case 2:
					{
					setState(1054);
					match(REPLACE);
					}
					break;
				case 3:
					{
					{
					setState(1055);
					match(INSERT);
					setState(1056);
					match(OR);
					setState(1057);
					_la = _input.LA(1);
					if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
					}
					break;
				}
				setState(1060);
				match(INTO);
				setState(1064);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,130,_ctx) ) {
				case 1:
					{
					setState(1061);
					schema_name();
					setState(1062);
					match(DOT);
					}
					break;
				}
				setState(1066);
				table_name();
				setState(1069);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS) {
					{
					setState(1067);
					match(AS);
					setState(1068);
					table_alias();
					}
				}

				setState(1072);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==OPEN_PAR) {
					{
					setState(1071);
					column_name_list();
					}
				}

				{
				setState(1077);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,133,_ctx) ) {
				case 1:
					{
					{
					setState(1074);
					match(VALUES);
					setState(1075);
					value_list_stmt();
					}
					}
					break;
				case 2:
					{
					setState(1076);
					select_stmt();
					}
					break;
				}
				setState(1080);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(1079);
					upsert_clause();
					}
				}

				}
				}
				break;
			case DEFAULT:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1082);
				match(DEFAULT);
				setState(1083);
				match(VALUES);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Upsert_clauseContext extends ParserRuleContext {
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public TerminalNode CONFLICT() { return getToken(SQLiteParser.CONFLICT, 0); }
		public TerminalNode DO() { return getToken(SQLiteParser.DO, 0); }
		public TerminalNode NOTHING() { return getToken(SQLiteParser.NOTHING, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public List<Where_stmtContext> where_stmt() {
			return getRuleContexts(Where_stmtContext.class);
		}
		public Where_stmtContext where_stmt(int i) {
			return getRuleContext(Where_stmtContext.class,i);
		}
		public List<TerminalNode> EQ() { return getTokens(SQLiteParser.EQ); }
		public TerminalNode EQ(int i) {
			return getToken(SQLiteParser.EQ, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<Column_name_listContext> column_name_list() {
			return getRuleContexts(Column_name_listContext.class);
		}
		public Column_name_listContext column_name_list(int i) {
			return getRuleContext(Column_name_listContext.class,i);
		}
		public Upsert_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_upsert_clause; }
	}

	public final Upsert_clauseContext upsert_clause() throws RecognitionException {
		Upsert_clauseContext _localctx = new Upsert_clauseContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_upsert_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1086);
			match(ON);
			setState(1087);
			match(CONFLICT);
			setState(1101);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(1088);
				match(OPEN_PAR);
				setState(1089);
				indexed_column();
				setState(1094);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1090);
					match(COMMA);
					setState(1091);
					indexed_column();
					}
					}
					setState(1096);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1097);
				match(CLOSE_PAR);
				setState(1099);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(1098);
					where_stmt();
					}
				}

				}
			}

			setState(1103);
			match(DO);
			setState(1129);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NOTHING:
				{
				setState(1104);
				match(NOTHING);
				}
				break;
			case UPDATE:
				{
				{
				setState(1105);
				match(UPDATE);
				setState(1106);
				match(SET);
				{
				setState(1109);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,139,_ctx) ) {
				case 1:
					{
					setState(1107);
					column_name();
					}
					break;
				case 2:
					{
					setState(1108);
					column_name_list();
					}
					break;
				}
				setState(1111);
				match(EQ);
				setState(1112);
				expr(0);
				setState(1123);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1113);
					match(COMMA);
					setState(1116);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,140,_ctx) ) {
					case 1:
						{
						setState(1114);
						column_name();
						}
						break;
					case 2:
						{
						setState(1115);
						column_name_list();
						}
						break;
					}
					setState(1118);
					match(EQ);
					setState(1119);
					expr(0);
					}
					}
					setState(1125);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1127);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(1126);
					where_stmt();
					}
				}

				}
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Pragma_stmtContext extends ParserRuleContext {
		public TerminalNode PRAGMA() { return getToken(SQLiteParser.PRAGMA, 0); }
		public Pragma_nameContext pragma_name() {
			return getRuleContext(Pragma_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode ASSIGN() { return getToken(SQLiteParser.ASSIGN, 0); }
		public Pragma_valueContext pragma_value() {
			return getRuleContext(Pragma_valueContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Pragma_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pragma_stmt; }
	}

	public final Pragma_stmtContext pragma_stmt() throws RecognitionException {
		Pragma_stmtContext _localctx = new Pragma_stmtContext(_ctx, getState());
		enterRule(_localctx, 100, RULE_pragma_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1131);
			match(PRAGMA);
			setState(1135);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,144,_ctx) ) {
			case 1:
				{
				setState(1132);
				schema_name();
				setState(1133);
				match(DOT);
				}
				break;
			}
			setState(1137);
			pragma_name();
			setState(1144);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ASSIGN:
				{
				setState(1138);
				match(ASSIGN);
				setState(1139);
				pragma_value();
				}
				break;
			case OPEN_PAR:
				{
				setState(1140);
				match(OPEN_PAR);
				setState(1141);
				pragma_value();
				setState(1142);
				match(CLOSE_PAR);
				}
				break;
			case EOF:
			case SCOL:
			case ALTER:
			case ANALYZE:
			case ATTACH:
			case BEGIN:
			case COMMIT:
			case CREATE:
			case DEFAULT:
			case DELETE:
			case DETACH:
			case DROP:
			case END:
			case EXPLAIN:
			case INSERT:
			case PRAGMA:
			case REINDEX:
			case RELEASE:
			case REPLACE:
			case ROLLBACK:
			case SAVEPOINT:
			case SELECT:
			case UPDATE:
			case VACUUM:
			case VALUES:
			case WITH:
			case UNEXPECTED_CHAR:
				break;
			default:
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Pragma_valueContext extends ParserRuleContext {
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public Pragma_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pragma_value; }
	}

	public final Pragma_valueContext pragma_value() throws RecognitionException {
		Pragma_valueContext _localctx = new Pragma_valueContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_pragma_value);
		try {
			setState(1149);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,146,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1146);
				signed_number();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1147);
				name();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(1148);
				match(STRING_LITERAL);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Reindex_stmtContext extends ParserRuleContext {
		public TerminalNode REINDEX() { return getToken(SQLiteParser.REINDEX, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Reindex_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_reindex_stmt; }
	}

	public final Reindex_stmtContext reindex_stmt() throws RecognitionException {
		Reindex_stmtContext _localctx = new Reindex_stmtContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_reindex_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1151);
			match(REINDEX);
			setState(1162);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,149,_ctx) ) {
			case 1:
				{
				setState(1152);
				collation_name();
				}
				break;
			case 2:
				{
				{
				setState(1156);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,147,_ctx) ) {
				case 1:
					{
					setState(1153);
					schema_name();
					setState(1154);
					match(DOT);
					}
					break;
				}
				setState(1160);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,148,_ctx) ) {
				case 1:
					{
					setState(1158);
					table_name();
					}
					break;
				case 2:
					{
					setState(1159);
					index_name();
					}
					break;
				}
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Select_stmtContext extends ParserRuleContext {
		public Select_coreContext select_core() {
			return getRuleContext(Select_coreContext.class,0);
		}
		public Common_table_stmtContext common_table_stmt() {
			return getRuleContext(Common_table_stmtContext.class,0);
		}
		public List<CompoundContext> compound() {
			return getRuleContexts(CompoundContext.class);
		}
		public CompoundContext compound(int i) {
			return getRuleContext(CompoundContext.class,i);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Limit_stmtsContext limit_stmts() {
			return getRuleContext(Limit_stmtsContext.class,0);
		}
		public Select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select_stmt; }
	}

	public final Select_stmtContext select_stmt() throws RecognitionException {
		Select_stmtContext _localctx = new Select_stmtContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_select_stmt);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(1165);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1164);
				common_table_stmt();
				}
			}

			setState(1167);
			select_core();
			setState(1171);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,151,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(1168);
					compound();
					}
					} 
				}
				setState(1173);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,151,_ctx);
			}
			setState(1175);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(1174);
				order_by_stmt();
				}
			}

			setState(1178);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(1177);
				limit_stmts();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CompoundContext extends ParserRuleContext {
		public Compound_operatorContext compound_operator() {
			return getRuleContext(Compound_operatorContext.class,0);
		}
		public Select_coreContext select_core() {
			return getRuleContext(Select_coreContext.class,0);
		}
		public CompoundContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compound; }
	}

	public final CompoundContext compound() throws RecognitionException {
		CompoundContext _localctx = new CompoundContext(_ctx, getState());
		enterRule(_localctx, 108, RULE_compound);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1180);
			compound_operator();
			setState(1181);
			select_core();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Join_clausesContext extends ParserRuleContext {
		public Table_or_subqueryContext table_or_subquery() {
			return getRuleContext(Table_or_subqueryContext.class,0);
		}
		public List<Join_clauseContext> join_clause() {
			return getRuleContexts(Join_clauseContext.class);
		}
		public Join_clauseContext join_clause(int i) {
			return getRuleContext(Join_clauseContext.class,i);
		}
		public Join_clausesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_clauses; }
	}

	public final Join_clausesContext join_clauses() throws RecognitionException {
		Join_clausesContext _localctx = new Join_clausesContext(_ctx, getState());
		enterRule(_localctx, 110, RULE_join_clauses);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1183);
			table_or_subquery();
			setState(1185); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(1184);
				join_clause();
				}
				}
				setState(1187); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==COMMA || _la==CROSS || ((((_la - 87)) & ~0x3f) == 0 && ((1L << (_la - 87)) & ((1L << (INNER - 87)) | (1L << (JOIN - 87)) | (1L << (LEFT - 87)) | (1L << (NATURAL - 87)))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Join_clauseContext extends ParserRuleContext {
		public Join_operatorContext join_operator() {
			return getRuleContext(Join_operatorContext.class,0);
		}
		public Table_or_subqueryContext table_or_subquery() {
			return getRuleContext(Table_or_subqueryContext.class,0);
		}
		public Join_constraintContext join_constraint() {
			return getRuleContext(Join_constraintContext.class,0);
		}
		public Join_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_clause; }
	}

	public final Join_clauseContext join_clause() throws RecognitionException {
		Join_clauseContext _localctx = new Join_clauseContext(_ctx, getState());
		enterRule(_localctx, 112, RULE_join_clause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1189);
			join_operator();
			setState(1190);
			table_or_subquery();
			setState(1192);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,155,_ctx) ) {
			case 1:
				{
				setState(1191);
				join_constraint();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Select_coreContext extends ParserRuleContext {
		public TerminalNode SELECT() { return getToken(SQLiteParser.SELECT, 0); }
		public List<Result_columnContext> result_column() {
			return getRuleContexts(Result_columnContext.class);
		}
		public Result_columnContext result_column(int i) {
			return getRuleContext(Result_columnContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public Subquery_tableContext subquery_table() {
			return getRuleContext(Subquery_tableContext.class,0);
		}
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public Group_by_stmtContext group_by_stmt() {
			return getRuleContext(Group_by_stmtContext.class,0);
		}
		public TerminalNode WINDOW() { return getToken(SQLiteParser.WINDOW, 0); }
		public List<Window_stmtContext> window_stmt() {
			return getRuleContexts(Window_stmtContext.class);
		}
		public Window_stmtContext window_stmt(int i) {
			return getRuleContext(Window_stmtContext.class,i);
		}
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public TerminalNode VALUES() { return getToken(SQLiteParser.VALUES, 0); }
		public Value_list_stmtContext value_list_stmt() {
			return getRuleContext(Value_list_stmtContext.class,0);
		}
		public Select_coreContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select_core; }
	}

	public final Select_coreContext select_core() throws RecognitionException {
		Select_coreContext _localctx = new Select_coreContext(_ctx, getState());
		enterRule(_localctx, 114, RULE_select_core);
		int _la;
		try {
			setState(1229);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SELECT:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1194);
				match(SELECT);
				setState(1196);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,156,_ctx) ) {
				case 1:
					{
					setState(1195);
					_la = _input.LA(1);
					if ( !(_la==ALL || _la==DISTINCT) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					}
					break;
				}
				setState(1198);
				result_column();
				setState(1203);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1199);
					match(COMMA);
					setState(1200);
					result_column();
					}
					}
					setState(1205);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1208);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==FROM) {
					{
					setState(1206);
					match(FROM);
					setState(1207);
					subquery_table();
					}
				}

				setState(1211);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(1210);
					where_stmt();
					}
				}

				setState(1214);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==GROUP) {
					{
					setState(1213);
					group_by_stmt();
					}
				}

				setState(1225);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WINDOW) {
					{
					setState(1216);
					match(WINDOW);
					setState(1217);
					window_stmt();
					setState(1222);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1218);
						match(COMMA);
						setState(1219);
						window_stmt();
						}
						}
						setState(1224);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				}
				}
				break;
			case VALUES:
				enterOuterAlt(_localctx, 2);
				{
				setState(1227);
				match(VALUES);
				setState(1228);
				value_list_stmt();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Value_list_stmtContext extends ParserRuleContext {
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public List<Expr_listContext> expr_list() {
			return getRuleContexts(Expr_listContext.class);
		}
		public Expr_listContext expr_list(int i) {
			return getRuleContext(Expr_listContext.class,i);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Value_list_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value_list_stmt; }
	}

	public final Value_list_stmtContext value_list_stmt() throws RecognitionException {
		Value_list_stmtContext _localctx = new Value_list_stmtContext(_ctx, getState());
		enterRule(_localctx, 116, RULE_value_list_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1231);
			match(OPEN_PAR);
			setState(1232);
			expr_list();
			setState(1233);
			match(CLOSE_PAR);
			setState(1241);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1234);
				match(COMMA);
				setState(1235);
				match(OPEN_PAR);
				setState(1236);
				expr_list();
				setState(1237);
				match(CLOSE_PAR);
				}
				}
				setState(1243);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Group_by_stmtContext extends ParserRuleContext {
		public TerminalNode GROUP() { return getToken(SQLiteParser.GROUP, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public Having_stmtContext having_stmt() {
			return getRuleContext(Having_stmtContext.class,0);
		}
		public Group_by_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_group_by_stmt; }
	}

	public final Group_by_stmtContext group_by_stmt() throws RecognitionException {
		Group_by_stmtContext _localctx = new Group_by_stmtContext(_ctx, getState());
		enterRule(_localctx, 118, RULE_group_by_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1244);
			match(GROUP);
			setState(1245);
			match(BY);
			setState(1246);
			expr_list();
			setState(1248);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HAVING) {
				{
				setState(1247);
				having_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Having_stmtContext extends ParserRuleContext {
		public TerminalNode HAVING() { return getToken(SQLiteParser.HAVING, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Having_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_having_stmt; }
	}

	public final Having_stmtContext having_stmt() throws RecognitionException {
		Having_stmtContext _localctx = new Having_stmtContext(_ctx, getState());
		enterRule(_localctx, 120, RULE_having_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1250);
			match(HAVING);
			setState(1251);
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_stmtContext extends ParserRuleContext {
		public Window_nameContext window_name() {
			return getRuleContext(Window_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Window_defnContext window_defn() {
			return getRuleContext(Window_defnContext.class,0);
		}
		public Window_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_stmt; }
	}

	public final Window_stmtContext window_stmt() throws RecognitionException {
		Window_stmtContext _localctx = new Window_stmtContext(_ctx, getState());
		enterRule(_localctx, 122, RULE_window_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1253);
			window_name();
			setState(1254);
			match(AS);
			setState(1255);
			window_defn();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Expr_listContext extends ParserRuleContext {
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Expr_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr_list; }
	}

	public final Expr_listContext expr_list() throws RecognitionException {
		Expr_listContext _localctx = new Expr_listContext(_ctx, getState());
		enterRule(_localctx, 124, RULE_expr_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1257);
			expr(0);
			setState(1262);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1258);
				match(COMMA);
				setState(1259);
				expr(0);
				}
				}
				setState(1264);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Factored_select_stmtContext extends ParserRuleContext {
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Factored_select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_factored_select_stmt; }
	}

	public final Factored_select_stmtContext factored_select_stmt() throws RecognitionException {
		Factored_select_stmtContext _localctx = new Factored_select_stmtContext(_ctx, getState());
		enterRule(_localctx, 126, RULE_factored_select_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1265);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Simple_select_stmtContext extends ParserRuleContext {
		public Select_coreContext select_core() {
			return getRuleContext(Select_coreContext.class,0);
		}
		public Common_table_stmtContext common_table_stmt() {
			return getRuleContext(Common_table_stmtContext.class,0);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Limit_stmtsContext limit_stmts() {
			return getRuleContext(Limit_stmtsContext.class,0);
		}
		public Simple_select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simple_select_stmt; }
	}

	public final Simple_select_stmtContext simple_select_stmt() throws RecognitionException {
		Simple_select_stmtContext _localctx = new Simple_select_stmtContext(_ctx, getState());
		enterRule(_localctx, 128, RULE_simple_select_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1268);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1267);
				common_table_stmt();
				}
			}

			setState(1270);
			select_core();
			setState(1272);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(1271);
				order_by_stmt();
				}
			}

			setState(1275);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(1274);
				limit_stmts();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Compound_select_stmtContext extends ParserRuleContext {
		public List<Select_coreContext> select_core() {
			return getRuleContexts(Select_coreContext.class);
		}
		public Select_coreContext select_core(int i) {
			return getRuleContext(Select_coreContext.class,i);
		}
		public Common_table_stmtContext common_table_stmt() {
			return getRuleContext(Common_table_stmtContext.class,0);
		}
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Limit_stmtsContext limit_stmts() {
			return getRuleContext(Limit_stmtsContext.class,0);
		}
		public List<TerminalNode> INTERSECT() { return getTokens(SQLiteParser.INTERSECT); }
		public TerminalNode INTERSECT(int i) {
			return getToken(SQLiteParser.INTERSECT, i);
		}
		public List<TerminalNode> EXCEPT() { return getTokens(SQLiteParser.EXCEPT); }
		public TerminalNode EXCEPT(int i) {
			return getToken(SQLiteParser.EXCEPT, i);
		}
		public List<TerminalNode> UNION() { return getTokens(SQLiteParser.UNION); }
		public TerminalNode UNION(int i) {
			return getToken(SQLiteParser.UNION, i);
		}
		public List<TerminalNode> ALL() { return getTokens(SQLiteParser.ALL); }
		public TerminalNode ALL(int i) {
			return getToken(SQLiteParser.ALL, i);
		}
		public Compound_select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compound_select_stmt; }
	}

	public final Compound_select_stmtContext compound_select_stmt() throws RecognitionException {
		Compound_select_stmtContext _localctx = new Compound_select_stmtContext(_ctx, getState());
		enterRule(_localctx, 130, RULE_compound_select_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1278);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1277);
				common_table_stmt();
				}
			}

			setState(1280);
			select_core();
			setState(1290); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(1287);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case UNION:
					{
					{
					setState(1281);
					match(UNION);
					setState(1283);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==ALL) {
						{
						setState(1282);
						match(ALL);
						}
					}

					}
					}
					break;
				case INTERSECT:
					{
					setState(1285);
					match(INTERSECT);
					}
					break;
				case EXCEPT:
					{
					setState(1286);
					match(EXCEPT);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(1289);
				select_core();
				}
				}
				setState(1292); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==EXCEPT || _la==INTERSECT || _la==UNION );
			setState(1295);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(1294);
				order_by_stmt();
				}
			}

			setState(1298);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(1297);
				limit_stmts();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_or_subqueryContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public TerminalNode INDEXED() { return getToken(SQLiteParser.INDEXED, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Table_function_nameContext table_function_name() {
			return getRuleContext(Table_function_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Subquery_tableContext subquery_table() {
			return getRuleContext(Subquery_tableContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Table_or_subqueryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_or_subquery; }
	}

	public final Table_or_subqueryContext table_or_subquery() throws RecognitionException {
		Table_or_subqueryContext _localctx = new Table_or_subqueryContext(_ctx, getState());
		enterRule(_localctx, 132, RULE_table_or_subquery);
		int _la;
		try {
			setState(1354);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,186,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1303);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,176,_ctx) ) {
				case 1:
					{
					setState(1300);
					schema_name();
					setState(1301);
					match(DOT);
					}
					break;
				}
				setState(1305);
				table_name();
				setState(1310);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,178,_ctx) ) {
				case 1:
					{
					setState(1307);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,177,_ctx) ) {
					case 1:
						{
						setState(1306);
						match(AS);
						}
						break;
					}
					setState(1309);
					table_alias();
					}
					break;
				}
				setState(1317);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case INDEXED:
					{
					{
					setState(1312);
					match(INDEXED);
					setState(1313);
					match(BY);
					setState(1314);
					index_name();
					}
					}
					break;
				case NOT:
					{
					{
					setState(1315);
					match(NOT);
					setState(1316);
					match(INDEXED);
					}
					}
					break;
				case EOF:
				case SCOL:
				case CLOSE_PAR:
				case COMMA:
				case ALTER:
				case ANALYZE:
				case ATTACH:
				case BEGIN:
				case COMMIT:
				case CREATE:
				case CROSS:
				case DEFAULT:
				case DELETE:
				case DETACH:
				case DROP:
				case END:
				case EXCEPT:
				case EXPLAIN:
				case GROUP:
				case INNER:
				case INSERT:
				case INTERSECT:
				case JOIN:
				case LEFT:
				case LIMIT:
				case NATURAL:
				case ON:
				case ORDER:
				case PRAGMA:
				case REINDEX:
				case RELEASE:
				case REPLACE:
				case ROLLBACK:
				case SAVEPOINT:
				case SELECT:
				case UNION:
				case UPDATE:
				case USING:
				case VACUUM:
				case VALUES:
				case WHERE:
				case WITH:
				case WINDOW:
				case UNEXPECTED_CHAR:
					break;
				default:
					break;
				}
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1322);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,180,_ctx) ) {
				case 1:
					{
					setState(1319);
					schema_name();
					setState(1320);
					match(DOT);
					}
					break;
				}
				setState(1324);
				table_function_name();
				setState(1325);
				match(OPEN_PAR);
				setState(1326);
				expr(0);
				setState(1331);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1327);
					match(COMMA);
					setState(1328);
					expr(0);
					}
					}
					setState(1333);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(1334);
				match(CLOSE_PAR);
				setState(1339);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,183,_ctx) ) {
				case 1:
					{
					setState(1336);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,182,_ctx) ) {
					case 1:
						{
						setState(1335);
						match(AS);
						}
						break;
					}
					setState(1338);
					table_alias();
					}
					break;
				}
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(1341);
				match(OPEN_PAR);
				setState(1342);
				subquery_table();
				setState(1343);
				match(CLOSE_PAR);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1345);
				match(OPEN_PAR);
				setState(1346);
				select_stmt();
				setState(1347);
				match(CLOSE_PAR);
				setState(1352);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,185,_ctx) ) {
				case 1:
					{
					setState(1349);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,184,_ctx) ) {
					case 1:
						{
						setState(1348);
						match(AS);
						}
						break;
					}
					setState(1351);
					table_alias();
					}
					break;
				}
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Subquery_tableContext extends ParserRuleContext {
		public List<Table_or_subqueryContext> table_or_subquery() {
			return getRuleContexts(Table_or_subqueryContext.class);
		}
		public Table_or_subqueryContext table_or_subquery(int i) {
			return getRuleContext(Table_or_subqueryContext.class,i);
		}
		public Join_clausesContext join_clauses() {
			return getRuleContext(Join_clausesContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Subquery_tableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subquery_table; }
	}

	public final Subquery_tableContext subquery_table() throws RecognitionException {
		Subquery_tableContext _localctx = new Subquery_tableContext(_ctx, getState());
		enterRule(_localctx, 134, RULE_subquery_table);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1365);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,188,_ctx) ) {
			case 1:
				{
				setState(1356);
				table_or_subquery();
				setState(1361);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(1357);
					match(COMMA);
					setState(1358);
					table_or_subquery();
					}
					}
					setState(1363);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case 2:
				{
				setState(1364);
				join_clauses();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Result_columnContext extends ParserRuleContext {
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Column_aliasContext column_alias() {
			return getRuleContext(Column_aliasContext.class,0);
		}
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public Result_columnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_result_column; }
	}

	public final Result_columnContext result_column() throws RecognitionException {
		Result_columnContext _localctx = new Result_columnContext(_ctx, getState());
		enterRule(_localctx, 136, RULE_result_column);
		int _la;
		try {
			setState(1379);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,191,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1367);
				match(STAR);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1368);
				table_name();
				setState(1369);
				match(DOT);
				setState(1370);
				match(STAR);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(1372);
				expr(0);
				setState(1377);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS || _la==IDENTIFIER || _la==STRING_LITERAL) {
					{
					setState(1374);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==AS) {
						{
						setState(1373);
						match(AS);
						}
					}

					setState(1376);
					column_alias();
					}
				}

				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Join_operatorContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public TerminalNode JOIN() { return getToken(SQLiteParser.JOIN, 0); }
		public TerminalNode NATURAL() { return getToken(SQLiteParser.NATURAL, 0); }
		public TerminalNode INNER() { return getToken(SQLiteParser.INNER, 0); }
		public TerminalNode CROSS() { return getToken(SQLiteParser.CROSS, 0); }
		public TerminalNode LEFT() { return getToken(SQLiteParser.LEFT, 0); }
		public TerminalNode OUTER() { return getToken(SQLiteParser.OUTER, 0); }
		public Join_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_operator; }
	}

	public final Join_operatorContext join_operator() throws RecognitionException {
		Join_operatorContext _localctx = new Join_operatorContext(_ctx, getState());
		enterRule(_localctx, 138, RULE_join_operator);
		int _la;
		try {
			setState(1394);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case COMMA:
				enterOuterAlt(_localctx, 1);
				{
				setState(1381);
				match(COMMA);
				}
				break;
			case CROSS:
			case INNER:
			case JOIN:
			case LEFT:
			case NATURAL:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1383);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NATURAL) {
					{
					setState(1382);
					match(NATURAL);
					}
				}

				setState(1391);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case LEFT:
					{
					{
					setState(1385);
					match(LEFT);
					setState(1387);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==OUTER) {
						{
						setState(1386);
						match(OUTER);
						}
					}

					}
					}
					break;
				case INNER:
					{
					setState(1389);
					match(INNER);
					}
					break;
				case CROSS:
					{
					setState(1390);
					match(CROSS);
					}
					break;
				case JOIN:
					break;
				default:
					break;
				}
				setState(1393);
				match(JOIN);
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Join_constraintContext extends ParserRuleContext {
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode USING() { return getToken(SQLiteParser.USING, 0); }
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public Join_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_constraint; }
	}

	public final Join_constraintContext join_constraint() throws RecognitionException {
		Join_constraintContext _localctx = new Join_constraintContext(_ctx, getState());
		enterRule(_localctx, 140, RULE_join_constraint);
		try {
			setState(1400);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ON:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1396);
				match(ON);
				setState(1397);
				expr(0);
				}
				}
				break;
			case USING:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1398);
				match(USING);
				setState(1399);
				column_name_list();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Compound_operatorContext extends ParserRuleContext {
		public TerminalNode UNION() { return getToken(SQLiteParser.UNION, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public TerminalNode INTERSECT() { return getToken(SQLiteParser.INTERSECT, 0); }
		public TerminalNode EXCEPT() { return getToken(SQLiteParser.EXCEPT, 0); }
		public Compound_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compound_operator; }
	}

	public final Compound_operatorContext compound_operator() throws RecognitionException {
		Compound_operatorContext _localctx = new Compound_operatorContext(_ctx, getState());
		enterRule(_localctx, 142, RULE_compound_operator);
		int _la;
		try {
			setState(1408);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case UNION:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1402);
				match(UNION);
				setState(1404);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ALL) {
					{
					setState(1403);
					match(ALL);
					}
				}

				}
				}
				break;
			case INTERSECT:
				enterOuterAlt(_localctx, 2);
				{
				setState(1406);
				match(INTERSECT);
				}
				break;
			case EXCEPT:
				enterOuterAlt(_localctx, 3);
				{
				setState(1407);
				match(EXCEPT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Update_stmtContext extends ParserRuleContext {
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public List<TerminalNode> ASSIGN() { return getTokens(SQLiteParser.ASSIGN); }
		public TerminalNode ASSIGN(int i) {
			return getToken(SQLiteParser.ASSIGN, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<Column_name_listContext> column_name_list() {
			return getRuleContexts(Column_name_listContext.class);
		}
		public Column_name_listContext column_name_list(int i) {
			return getRuleContext(Column_name_listContext.class,i);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public Update_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_update_stmt; }
	}

	public final Update_stmtContext update_stmt() throws RecognitionException {
		Update_stmtContext _localctx = new Update_stmtContext(_ctx, getState());
		enterRule(_localctx, 144, RULE_update_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1411);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1410);
				with_clause();
				}
			}

			setState(1413);
			match(UPDATE);
			setState(1416);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,200,_ctx) ) {
			case 1:
				{
				setState(1414);
				match(OR);
				setState(1415);
				_la = _input.LA(1);
				if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			}
			setState(1418);
			qualified_table_name();
			setState(1419);
			match(SET);
			setState(1422);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,201,_ctx) ) {
			case 1:
				{
				setState(1420);
				column_name();
				}
				break;
			case 2:
				{
				setState(1421);
				column_name_list();
				}
				break;
			}
			setState(1424);
			match(ASSIGN);
			setState(1425);
			expr(0);
			setState(1436);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1426);
				match(COMMA);
				setState(1429);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,202,_ctx) ) {
				case 1:
					{
					setState(1427);
					column_name();
					}
					break;
				case 2:
					{
					setState(1428);
					column_name_list();
					}
					break;
				}
				setState(1431);
				match(ASSIGN);
				setState(1432);
				expr(0);
				}
				}
				setState(1438);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(1440);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(1439);
				where_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_name_listContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Column_name_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_name_list; }
	}

	public final Column_name_listContext column_name_list() throws RecognitionException {
		Column_name_listContext _localctx = new Column_name_listContext(_ctx, getState());
		enterRule(_localctx, 146, RULE_column_name_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1442);
			match(OPEN_PAR);
			setState(1443);
			column_name();
			setState(1448);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1444);
				match(COMMA);
				setState(1445);
				column_name();
				}
				}
				setState(1450);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(1451);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Update_stmt_limitedContext extends ParserRuleContext {
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public Qualified_table_nameContext qualified_table_name() {
			return getRuleContext(Qualified_table_nameContext.class,0);
		}
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public List<TerminalNode> ASSIGN() { return getTokens(SQLiteParser.ASSIGN); }
		public TerminalNode ASSIGN(int i) {
			return getToken(SQLiteParser.ASSIGN, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public List<Column_name_listContext> column_name_list() {
			return getRuleContexts(Column_name_listContext.class);
		}
		public Column_name_listContext column_name_list(int i) {
			return getRuleContext(Column_name_listContext.class,i);
		}
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public Limit_stmtsContext limit_stmts() {
			return getRuleContext(Limit_stmtsContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public Order_by_stmtContext order_by_stmt() {
			return getRuleContext(Order_by_stmtContext.class,0);
		}
		public Update_stmt_limitedContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_update_stmt_limited; }
	}

	public final Update_stmt_limitedContext update_stmt_limited() throws RecognitionException {
		Update_stmt_limitedContext _localctx = new Update_stmt_limitedContext(_ctx, getState());
		enterRule(_localctx, 148, RULE_update_stmt_limited);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1454);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(1453);
				with_clause();
				}
			}

			setState(1456);
			match(UPDATE);
			setState(1459);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,207,_ctx) ) {
			case 1:
				{
				setState(1457);
				match(OR);
				setState(1458);
				_la = _input.LA(1);
				if ( !(_la==ABORT || ((((_la - 72)) & ~0x3f) == 0 && ((1L << (_la - 72)) & ((1L << (FAIL - 72)) | (1L << (IGNORE - 72)) | (1L << (REPLACE - 72)) | (1L << (ROLLBACK - 72)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			}
			setState(1461);
			qualified_table_name();
			setState(1462);
			match(SET);
			setState(1465);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,208,_ctx) ) {
			case 1:
				{
				setState(1463);
				column_name();
				}
				break;
			case 2:
				{
				setState(1464);
				column_name_list();
				}
				break;
			}
			setState(1467);
			match(ASSIGN);
			setState(1468);
			expr(0);
			setState(1479);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1469);
				match(COMMA);
				setState(1472);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,209,_ctx) ) {
				case 1:
					{
					setState(1470);
					column_name();
					}
					break;
				case 2:
					{
					setState(1471);
					column_name_list();
					}
					break;
				}
				setState(1474);
				match(ASSIGN);
				setState(1475);
				expr(0);
				}
				}
				setState(1481);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(1483);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHERE) {
				{
				setState(1482);
				where_stmt();
				}
			}

			setState(1489);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT || _la==ORDER) {
				{
				setState(1486);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1485);
					order_by_stmt();
					}
				}

				setState(1488);
				limit_stmts();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Qualified_table_nameContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(SQLiteParser.DOT, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public AliasContext alias() {
			return getRuleContext(AliasContext.class,0);
		}
		public TerminalNode INDEXED() { return getToken(SQLiteParser.INDEXED, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public Qualified_table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_qualified_table_name; }
	}

	public final Qualified_table_nameContext qualified_table_name() throws RecognitionException {
		Qualified_table_nameContext _localctx = new Qualified_table_nameContext(_ctx, getState());
		enterRule(_localctx, 150, RULE_qualified_table_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1494);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,214,_ctx) ) {
			case 1:
				{
				setState(1491);
				schema_name();
				setState(1492);
				match(DOT);
				}
				break;
			}
			setState(1496);
			table_name();
			setState(1499);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AS) {
				{
				setState(1497);
				match(AS);
				setState(1498);
				alias();
				}
			}

			setState(1506);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INDEXED:
				{
				{
				setState(1501);
				match(INDEXED);
				setState(1502);
				match(BY);
				setState(1503);
				index_name();
				}
				}
				break;
			case NOT:
				{
				{
				setState(1504);
				match(NOT);
				setState(1505);
				match(INDEXED);
				}
				}
				break;
			case EOF:
			case SCOL:
			case ALTER:
			case ANALYZE:
			case ATTACH:
			case BEGIN:
			case COMMIT:
			case CREATE:
			case DEFAULT:
			case DELETE:
			case DETACH:
			case DROP:
			case END:
			case EXPLAIN:
			case INSERT:
			case LIMIT:
			case ORDER:
			case PRAGMA:
			case REINDEX:
			case RELEASE:
			case REPLACE:
			case ROLLBACK:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case UPDATE:
			case VACUUM:
			case VALUES:
			case WHERE:
			case WITH:
			case UNEXPECTED_CHAR:
				break;
			default:
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Vacuum_stmtContext extends ParserRuleContext {
		public TerminalNode VACUUM() { return getToken(SQLiteParser.VACUUM, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode INTO() { return getToken(SQLiteParser.INTO, 0); }
		public FilenameContext filename() {
			return getRuleContext(FilenameContext.class,0);
		}
		public Vacuum_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_vacuum_stmt; }
	}

	public final Vacuum_stmtContext vacuum_stmt() throws RecognitionException {
		Vacuum_stmtContext _localctx = new Vacuum_stmtContext(_ctx, getState());
		enterRule(_localctx, 152, RULE_vacuum_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1508);
			match(VACUUM);
			setState(1510);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,217,_ctx) ) {
			case 1:
				{
				setState(1509);
				schema_name();
				}
				break;
			}
			setState(1514);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==INTO) {
				{
				setState(1512);
				match(INTO);
				setState(1513);
				filename();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Filter_clauseContext extends ParserRuleContext {
		public TerminalNode FILTER() { return getToken(SQLiteParser.FILTER, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Filter_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filter_clause; }
	}

	public final Filter_clauseContext filter_clause() throws RecognitionException {
		Filter_clauseContext _localctx = new Filter_clauseContext(_ctx, getState());
		enterRule(_localctx, 154, RULE_filter_clause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1516);
			match(FILTER);
			setState(1517);
			match(OPEN_PAR);
			setState(1518);
			match(WHERE);
			setState(1519);
			expr(0);
			setState(1520);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_defnContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public List<TerminalNode> BY() { return getTokens(SQLiteParser.BY); }
		public TerminalNode BY(int i) {
			return getToken(SQLiteParser.BY, i);
		}
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public Base_window_nameContext base_window_name() {
			return getRuleContext(Base_window_nameContext.class,0);
		}
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public Frame_specContext frame_spec() {
			return getRuleContext(Frame_specContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Window_defnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_defn; }
	}

	public final Window_defnContext window_defn() throws RecognitionException {
		Window_defnContext _localctx = new Window_defnContext(_ctx, getState());
		enterRule(_localctx, 156, RULE_window_defn);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1522);
			match(OPEN_PAR);
			setState(1524);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,219,_ctx) ) {
			case 1:
				{
				setState(1523);
				base_window_name();
				}
				break;
			}
			setState(1529);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARTITION) {
				{
				setState(1526);
				match(PARTITION);
				setState(1527);
				match(BY);
				setState(1528);
				expr_list();
				}
			}

			{
			setState(1531);
			match(ORDER);
			setState(1532);
			match(BY);
			setState(1533);
			ordering_term();
			setState(1538);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1534);
				match(COMMA);
				setState(1535);
				ordering_term();
				}
				}
				setState(1540);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
			setState(1542);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
				{
				setState(1541);
				frame_spec();
				}
			}

			setState(1544);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Over_clauseContext extends ParserRuleContext {
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public Window_nameContext window_name() {
			return getRuleContext(Window_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Base_window_nameContext base_window_name() {
			return getRuleContext(Base_window_nameContext.class,0);
		}
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public List<TerminalNode> BY() { return getTokens(SQLiteParser.BY); }
		public TerminalNode BY(int i) {
			return getToken(SQLiteParser.BY, i);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public Frame_specContext frame_spec() {
			return getRuleContext(Frame_specContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Over_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_over_clause; }
	}

	public final Over_clauseContext over_clause() throws RecognitionException {
		Over_clauseContext _localctx = new Over_clauseContext(_ctx, getState());
		enterRule(_localctx, 158, RULE_over_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1546);
			match(OVER);
			setState(1573);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,228,_ctx) ) {
			case 1:
				{
				setState(1547);
				window_name();
				}
				break;
			case 2:
				{
				{
				setState(1548);
				match(OPEN_PAR);
				setState(1550);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,223,_ctx) ) {
				case 1:
					{
					setState(1549);
					base_window_name();
					}
					break;
				}
				setState(1555);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1552);
					match(PARTITION);
					setState(1553);
					match(BY);
					setState(1554);
					expr_list();
					}
				}

				setState(1567);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1557);
					match(ORDER);
					setState(1558);
					match(BY);
					setState(1559);
					ordering_term();
					setState(1564);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1560);
						match(COMMA);
						setState(1561);
						ordering_term();
						}
						}
						setState(1566);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(1570);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1569);
					frame_spec();
					}
				}

				setState(1572);
				match(CLOSE_PAR);
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_specContext extends ParserRuleContext {
		public Frame_clauseContext frame_clause() {
			return getRuleContext(Frame_clauseContext.class,0);
		}
		public TerminalNode EXCLUDE() { return getToken(SQLiteParser.EXCLUDE, 0); }
		public TerminalNode GROUP() { return getToken(SQLiteParser.GROUP, 0); }
		public TerminalNode TIES() { return getToken(SQLiteParser.TIES, 0); }
		public TerminalNode NO() { return getToken(SQLiteParser.NO, 0); }
		public TerminalNode OTHERS() { return getToken(SQLiteParser.OTHERS, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public Frame_specContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_spec; }
	}

	public final Frame_specContext frame_spec() throws RecognitionException {
		Frame_specContext _localctx = new Frame_specContext(_ctx, getState());
		enterRule(_localctx, 160, RULE_frame_spec);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1575);
			frame_clause();
			setState(1583);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case EXCLUDE:
				{
				setState(1576);
				match(EXCLUDE);
				{
				setState(1577);
				match(NO);
				setState(1578);
				match(OTHERS);
				}
				}
				break;
			case CURRENT:
				{
				{
				setState(1579);
				match(CURRENT);
				setState(1580);
				match(ROW);
				}
				}
				break;
			case GROUP:
				{
				setState(1581);
				match(GROUP);
				}
				break;
			case TIES:
				{
				setState(1582);
				match(TIES);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_clauseContext extends ParserRuleContext {
		public TerminalNode RANGE() { return getToken(SQLiteParser.RANGE, 0); }
		public TerminalNode ROWS() { return getToken(SQLiteParser.ROWS, 0); }
		public TerminalNode GROUPS() { return getToken(SQLiteParser.GROUPS, 0); }
		public Frame_singleContext frame_single() {
			return getRuleContext(Frame_singleContext.class,0);
		}
		public TerminalNode BETWEEN() { return getToken(SQLiteParser.BETWEEN, 0); }
		public Frame_leftContext frame_left() {
			return getRuleContext(Frame_leftContext.class,0);
		}
		public TerminalNode AND() { return getToken(SQLiteParser.AND, 0); }
		public Frame_rightContext frame_right() {
			return getRuleContext(Frame_rightContext.class,0);
		}
		public Frame_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_clause; }
	}

	public final Frame_clauseContext frame_clause() throws RecognitionException {
		Frame_clauseContext _localctx = new Frame_clauseContext(_ctx, getState());
		enterRule(_localctx, 162, RULE_frame_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1585);
			_la = _input.LA(1);
			if ( !(((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(1592);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,230,_ctx) ) {
			case 1:
				{
				setState(1586);
				frame_single();
				}
				break;
			case 2:
				{
				setState(1587);
				match(BETWEEN);
				setState(1588);
				frame_left();
				setState(1589);
				match(AND);
				setState(1590);
				frame_right();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Simple_function_invocationContext extends ParserRuleContext {
		public Simple_funcContext simple_func() {
			return getRuleContext(Simple_funcContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Simple_function_invocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simple_function_invocation; }
	}

	public final Simple_function_invocationContext simple_function_invocation() throws RecognitionException {
		Simple_function_invocationContext _localctx = new Simple_function_invocationContext(_ctx, getState());
		enterRule(_localctx, 164, RULE_simple_function_invocation);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1594);
			simple_func();
			setState(1595);
			match(OPEN_PAR);
			setState(1598);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
			case PLUS:
			case MINUS:
			case TILDE:
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
			case IDENTIFIER:
			case NUMERIC_LITERAL:
			case BIND_PARAMETER:
			case STRING_LITERAL:
			case BLOB_LITERAL:
				{
				setState(1596);
				expr_list();
				}
				break;
			case STAR:
				{
				setState(1597);
				match(STAR);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1600);
			match(CLOSE_PAR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Aggregate_function_invocationContext extends ParserRuleContext {
		public Aggregate_funcContext aggregate_func() {
			return getRuleContext(Aggregate_funcContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Filter_clauseContext filter_clause() {
			return getRuleContext(Filter_clauseContext.class,0);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public Aggregate_function_invocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregate_function_invocation; }
	}

	public final Aggregate_function_invocationContext aggregate_function_invocation() throws RecognitionException {
		Aggregate_function_invocationContext _localctx = new Aggregate_function_invocationContext(_ctx, getState());
		enterRule(_localctx, 166, RULE_aggregate_function_invocation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1602);
			aggregate_func();
			setState(1603);
			match(OPEN_PAR);
			setState(1609);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
			case PLUS:
			case MINUS:
			case TILDE:
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
			case IDENTIFIER:
			case NUMERIC_LITERAL:
			case BIND_PARAMETER:
			case STRING_LITERAL:
			case BLOB_LITERAL:
				{
				{
				setState(1605);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,232,_ctx) ) {
				case 1:
					{
					setState(1604);
					match(DISTINCT);
					}
					break;
				}
				setState(1607);
				expr_list();
				}
				}
				break;
			case STAR:
				{
				setState(1608);
				match(STAR);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			setState(1611);
			match(CLOSE_PAR);
			setState(1613);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FILTER) {
				{
				setState(1612);
				filter_clause();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_function_invocationContext extends ParserRuleContext {
		public Window_functionContext window_function() {
			return getRuleContext(Window_functionContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public Window_defnContext window_defn() {
			return getRuleContext(Window_defnContext.class,0);
		}
		public Window_nameContext window_name() {
			return getRuleContext(Window_nameContext.class,0);
		}
		public TerminalNode STAR() { return getToken(SQLiteParser.STAR, 0); }
		public Filter_clauseContext filter_clause() {
			return getRuleContext(Filter_clauseContext.class,0);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public Window_function_invocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_function_invocation; }
	}

	public final Window_function_invocationContext window_function_invocation() throws RecognitionException {
		Window_function_invocationContext _localctx = new Window_function_invocationContext(_ctx, getState());
		enterRule(_localctx, 168, RULE_window_function_invocation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1615);
			window_function();
			setState(1616);
			match(OPEN_PAR);
			setState(1619);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
			case PLUS:
			case MINUS:
			case TILDE:
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
			case IDENTIFIER:
			case NUMERIC_LITERAL:
			case BIND_PARAMETER:
			case STRING_LITERAL:
			case BLOB_LITERAL:
				{
				{
				setState(1617);
				expr_list();
				}
				}
				break;
			case STAR:
				{
				setState(1618);
				match(STAR);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			setState(1621);
			match(CLOSE_PAR);
			setState(1623);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FILTER) {
				{
				setState(1622);
				filter_clause();
				}
			}

			setState(1625);
			match(OVER);
			setState(1628);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,237,_ctx) ) {
			case 1:
				{
				setState(1626);
				window_defn();
				}
				break;
			case 2:
				{
				setState(1627);
				window_name();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Common_table_stmtContext extends ParserRuleContext {
		public TerminalNode WITH() { return getToken(SQLiteParser.WITH, 0); }
		public List<Common_table_expressionContext> common_table_expression() {
			return getRuleContexts(Common_table_expressionContext.class);
		}
		public Common_table_expressionContext common_table_expression(int i) {
			return getRuleContext(Common_table_expressionContext.class,i);
		}
		public TerminalNode RECURSIVE() { return getToken(SQLiteParser.RECURSIVE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Common_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_common_table_stmt; }
	}

	public final Common_table_stmtContext common_table_stmt() throws RecognitionException {
		Common_table_stmtContext _localctx = new Common_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 170, RULE_common_table_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1630);
			match(WITH);
			setState(1632);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,238,_ctx) ) {
			case 1:
				{
				setState(1631);
				match(RECURSIVE);
				}
				break;
			}
			setState(1634);
			common_table_expression();
			setState(1639);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1635);
				match(COMMA);
				setState(1636);
				common_table_expression();
				}
				}
				setState(1641);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Order_by_stmtContext extends ParserRuleContext {
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Order_by_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_stmt; }
	}

	public final Order_by_stmtContext order_by_stmt() throws RecognitionException {
		Order_by_stmtContext _localctx = new Order_by_stmtContext(_ctx, getState());
		enterRule(_localctx, 172, RULE_order_by_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1642);
			match(ORDER);
			setState(1643);
			match(BY);
			setState(1644);
			ordering_term();
			setState(1649);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1645);
				match(COMMA);
				setState(1646);
				ordering_term();
				}
				}
				setState(1651);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Limit_stmtsContext extends ParserRuleContext {
		public TerminalNode LIMIT() { return getToken(SQLiteParser.LIMIT, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Limit_stmtContext limit_stmt() {
			return getRuleContext(Limit_stmtContext.class,0);
		}
		public Limit_stmtsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_limit_stmts; }
	}

	public final Limit_stmtsContext limit_stmts() throws RecognitionException {
		Limit_stmtsContext _localctx = new Limit_stmtsContext(_ctx, getState());
		enterRule(_localctx, 174, RULE_limit_stmts);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1652);
			match(LIMIT);
			setState(1653);
			expr(0);
			setState(1655);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMMA || _la==OFFSET) {
				{
				setState(1654);
				limit_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Limit_stmtContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode OFFSET() { return getToken(SQLiteParser.OFFSET, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Limit_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_limit_stmt; }
	}

	public final Limit_stmtContext limit_stmt() throws RecognitionException {
		Limit_stmtContext _localctx = new Limit_stmtContext(_ctx, getState());
		enterRule(_localctx, 176, RULE_limit_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1657);
			_la = _input.LA(1);
			if ( !(_la==COMMA || _la==OFFSET) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(1658);
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Ordering_termContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public TerminalNode NULLS() { return getToken(SQLiteParser.NULLS, 0); }
		public TerminalNode FIRST() { return getToken(SQLiteParser.FIRST, 0); }
		public TerminalNode LAST() { return getToken(SQLiteParser.LAST, 0); }
		public Ordering_termContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ordering_term; }
	}

	public final Ordering_termContext ordering_term() throws RecognitionException {
		Ordering_termContext _localctx = new Ordering_termContext(_ctx, getState());
		enterRule(_localctx, 178, RULE_ordering_term);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1660);
			expr(0);
			setState(1663);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLLATE) {
				{
				setState(1661);
				match(COLLATE);
				setState(1662);
				collation_name();
				}
			}

			setState(1666);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(1665);
				asc_desc();
				}
			}

			setState(1670);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NULLS) {
				{
				setState(1668);
				match(NULLS);
				setState(1669);
				_la = _input.LA(1);
				if ( !(_la==FIRST || _la==LAST) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Asc_descContext extends ParserRuleContext {
		public TerminalNode ASC() { return getToken(SQLiteParser.ASC, 0); }
		public TerminalNode DESC() { return getToken(SQLiteParser.DESC, 0); }
		public Asc_descContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_asc_desc; }
	}

	public final Asc_descContext asc_desc() throws RecognitionException {
		Asc_descContext _localctx = new Asc_descContext(_ctx, getState());
		enterRule(_localctx, 180, RULE_asc_desc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1672);
			_la = _input.LA(1);
			if ( !(_la==ASC || _la==DESC) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_leftContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode FOLLOWING() { return getToken(SQLiteParser.FOLLOWING, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public Frame_leftContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_left; }
	}

	public final Frame_leftContext frame_left() throws RecognitionException {
		Frame_leftContext _localctx = new Frame_leftContext(_ctx, getState());
		enterRule(_localctx, 182, RULE_frame_left);
		try {
			setState(1684);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,245,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1674);
				expr(0);
				setState(1675);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1677);
				expr(0);
				setState(1678);
				match(FOLLOWING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1680);
				match(CURRENT);
				setState(1681);
				match(ROW);
				}
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1682);
				match(UNBOUNDED);
				setState(1683);
				match(PRECEDING);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_rightContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode FOLLOWING() { return getToken(SQLiteParser.FOLLOWING, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public Frame_rightContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_right; }
	}

	public final Frame_rightContext frame_right() throws RecognitionException {
		Frame_rightContext _localctx = new Frame_rightContext(_ctx, getState());
		enterRule(_localctx, 184, RULE_frame_right);
		try {
			setState(1696);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,246,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1686);
				expr(0);
				setState(1687);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1689);
				expr(0);
				setState(1690);
				match(FOLLOWING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1692);
				match(CURRENT);
				setState(1693);
				match(ROW);
				}
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1694);
				match(UNBOUNDED);
				setState(1695);
				match(FOLLOWING);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Frame_singleContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public Frame_singleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_single; }
	}

	public final Frame_singleContext frame_single() throws RecognitionException {
		Frame_singleContext _localctx = new Frame_singleContext(_ctx, getState());
		enterRule(_localctx, 186, RULE_frame_single);
		try {
			setState(1705);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,247,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1698);
				expr(0);
				setState(1699);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1701);
				match(UNBOUNDED);
				setState(1702);
				match(PRECEDING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1703);
				match(CURRENT);
				setState(1704);
				match(ROW);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_functionContext extends ParserRuleContext {
		public List<TerminalNode> OPEN_PAR() { return getTokens(SQLiteParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(SQLiteParser.OPEN_PAR, i);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(SQLiteParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(SQLiteParser.CLOSE_PAR, i);
		}
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public Order_by_expr_asc_descContext order_by_expr_asc_desc() {
			return getRuleContext(Order_by_expr_asc_descContext.class,0);
		}
		public TerminalNode FIRST_VALUE() { return getToken(SQLiteParser.FIRST_VALUE, 0); }
		public TerminalNode LAST_VALUE() { return getToken(SQLiteParser.LAST_VALUE, 0); }
		public Partition_byContext partition_by() {
			return getRuleContext(Partition_byContext.class,0);
		}
		public Frame_clauseContext frame_clause() {
			return getRuleContext(Frame_clauseContext.class,0);
		}
		public TerminalNode CUME_DIST() { return getToken(SQLiteParser.CUME_DIST, 0); }
		public TerminalNode PERCENT_RANK() { return getToken(SQLiteParser.PERCENT_RANK, 0); }
		public Order_by_exprContext order_by_expr() {
			return getRuleContext(Order_by_exprContext.class,0);
		}
		public TerminalNode DENSE_RANK() { return getToken(SQLiteParser.DENSE_RANK, 0); }
		public TerminalNode RANK() { return getToken(SQLiteParser.RANK, 0); }
		public TerminalNode ROW_NUMBER() { return getToken(SQLiteParser.ROW_NUMBER, 0); }
		public TerminalNode LAG() { return getToken(SQLiteParser.LAG, 0); }
		public TerminalNode LEAD() { return getToken(SQLiteParser.LEAD, 0); }
		public OffsetContext offset() {
			return getRuleContext(OffsetContext.class,0);
		}
		public Default_valueContext default_value() {
			return getRuleContext(Default_valueContext.class,0);
		}
		public TerminalNode NTH_VALUE() { return getToken(SQLiteParser.NTH_VALUE, 0); }
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public TerminalNode NTILE() { return getToken(SQLiteParser.NTILE, 0); }
		public Window_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_function; }
	}

	public final Window_functionContext window_function() throws RecognitionException {
		Window_functionContext _localctx = new Window_functionContext(_ctx, getState());
		enterRule(_localctx, 188, RULE_window_function);
		int _la;
		try {
			setState(1792);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case FIRST_VALUE:
			case LAST_VALUE:
				enterOuterAlt(_localctx, 1);
				{
				setState(1707);
				_la = _input.LA(1);
				if ( !(_la==FIRST_VALUE || _la==LAST_VALUE) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1708);
				match(OPEN_PAR);
				setState(1709);
				expr(0);
				setState(1710);
				match(CLOSE_PAR);
				setState(1711);
				match(OVER);
				setState(1712);
				match(OPEN_PAR);
				setState(1714);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1713);
					partition_by();
					}
				}

				setState(1716);
				order_by_expr_asc_desc();
				setState(1718);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1717);
					frame_clause();
					}
				}

				setState(1720);
				match(CLOSE_PAR);
				}
				break;
			case CUME_DIST:
			case PERCENT_RANK:
				enterOuterAlt(_localctx, 2);
				{
				setState(1722);
				_la = _input.LA(1);
				if ( !(_la==CUME_DIST || _la==PERCENT_RANK) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1723);
				match(OPEN_PAR);
				setState(1724);
				match(CLOSE_PAR);
				setState(1725);
				match(OVER);
				setState(1726);
				match(OPEN_PAR);
				setState(1728);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1727);
					partition_by();
					}
				}

				setState(1731);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1730);
					order_by_expr();
					}
				}

				setState(1733);
				match(CLOSE_PAR);
				}
				break;
			case DENSE_RANK:
			case RANK:
			case ROW_NUMBER:
				enterOuterAlt(_localctx, 3);
				{
				setState(1734);
				_la = _input.LA(1);
				if ( !(((((_la - 159)) & ~0x3f) == 0 && ((1L << (_la - 159)) & ((1L << (DENSE_RANK - 159)) | (1L << (RANK - 159)) | (1L << (ROW_NUMBER - 159)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1735);
				match(OPEN_PAR);
				setState(1736);
				match(CLOSE_PAR);
				setState(1737);
				match(OVER);
				setState(1738);
				match(OPEN_PAR);
				setState(1740);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1739);
					partition_by();
					}
				}

				setState(1742);
				order_by_expr_asc_desc();
				setState(1743);
				match(CLOSE_PAR);
				}
				break;
			case LAG:
			case LEAD:
				enterOuterAlt(_localctx, 4);
				{
				setState(1745);
				_la = _input.LA(1);
				if ( !(_la==LAG || _la==LEAD) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1746);
				match(OPEN_PAR);
				setState(1747);
				expr(0);
				setState(1749);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,253,_ctx) ) {
				case 1:
					{
					setState(1748);
					offset();
					}
					break;
				}
				setState(1752);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COMMA) {
					{
					setState(1751);
					default_value();
					}
				}

				setState(1754);
				match(CLOSE_PAR);
				setState(1755);
				match(OVER);
				setState(1756);
				match(OPEN_PAR);
				setState(1758);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1757);
					partition_by();
					}
				}

				setState(1760);
				order_by_expr_asc_desc();
				setState(1761);
				match(CLOSE_PAR);
				}
				break;
			case NTH_VALUE:
				enterOuterAlt(_localctx, 5);
				{
				setState(1763);
				match(NTH_VALUE);
				setState(1764);
				match(OPEN_PAR);
				setState(1765);
				expr(0);
				setState(1766);
				match(COMMA);
				setState(1767);
				signed_number();
				setState(1768);
				match(CLOSE_PAR);
				setState(1769);
				match(OVER);
				setState(1770);
				match(OPEN_PAR);
				setState(1772);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1771);
					partition_by();
					}
				}

				setState(1774);
				order_by_expr_asc_desc();
				setState(1776);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1775);
					frame_clause();
					}
				}

				setState(1778);
				match(CLOSE_PAR);
				}
				break;
			case NTILE:
				enterOuterAlt(_localctx, 6);
				{
				setState(1780);
				match(NTILE);
				setState(1781);
				match(OPEN_PAR);
				setState(1782);
				expr(0);
				setState(1783);
				match(CLOSE_PAR);
				setState(1784);
				match(OVER);
				setState(1785);
				match(OPEN_PAR);
				setState(1787);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1786);
					partition_by();
					}
				}

				setState(1789);
				order_by_expr_asc_desc();
				setState(1790);
				match(CLOSE_PAR);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OffsetContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public OffsetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_offset; }
	}

	public final OffsetContext offset() throws RecognitionException {
		OffsetContext _localctx = new OffsetContext(_ctx, getState());
		enterRule(_localctx, 190, RULE_offset);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1794);
			match(COMMA);
			setState(1795);
			signed_number();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Default_valueContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(SQLiteParser.COMMA, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public Default_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_default_value; }
	}

	public final Default_valueContext default_value() throws RecognitionException {
		Default_valueContext _localctx = new Default_valueContext(_ctx, getState());
		enterRule(_localctx, 192, RULE_default_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1797);
			match(COMMA);
			setState(1798);
			signed_number();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Partition_byContext extends ParserRuleContext {
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Partition_byContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_partition_by; }
	}

	public final Partition_byContext partition_by() throws RecognitionException {
		Partition_byContext _localctx = new Partition_byContext(_ctx, getState());
		enterRule(_localctx, 194, RULE_partition_by);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(1800);
			match(PARTITION);
			setState(1801);
			match(BY);
			setState(1803); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(1802);
					expr(0);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(1805); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,260,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Order_by_exprContext extends ParserRuleContext {
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Order_by_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_expr; }
	}

	public final Order_by_exprContext order_by_expr() throws RecognitionException {
		Order_by_exprContext _localctx = new Order_by_exprContext(_ctx, getState());
		enterRule(_localctx, 196, RULE_order_by_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1807);
			match(ORDER);
			setState(1808);
			match(BY);
			setState(1810); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(1809);
				expr(0);
				}
				}
				setState(1812); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAR) | (1L << PLUS) | (1L << MINUS) | (1L << TILDE) | (1L << ABORT) | (1L << ACTION) | (1L << ADD) | (1L << AFTER) | (1L << ALL) | (1L << ALTER) | (1L << ANALYZE) | (1L << AND) | (1L << AS) | (1L << ASC) | (1L << ATTACH) | (1L << AUTOINCREMENT) | (1L << BEFORE) | (1L << BEGIN) | (1L << BETWEEN) | (1L << BY) | (1L << CASCADE) | (1L << CASE) | (1L << CAST) | (1L << CHECK) | (1L << COLLATE) | (1L << COLUMN) | (1L << COMMIT) | (1L << CONFLICT) | (1L << CONSTRAINT) | (1L << CREATE) | (1L << CROSS) | (1L << CURRENT_DATE) | (1L << CURRENT_TIME) | (1L << CURRENT_TIMESTAMP) | (1L << DATABASE) | (1L << DEFAULT) | (1L << DEFERRABLE) | (1L << DEFERRED) | (1L << DELETE) | (1L << DESC) | (1L << DETACH) | (1L << DISTINCT) | (1L << DROP))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (EACH - 64)) | (1L << (ELSE - 64)) | (1L << (END - 64)) | (1L << (ESCAPE - 64)) | (1L << (EXCEPT - 64)) | (1L << (EXCLUSIVE - 64)) | (1L << (EXISTS - 64)) | (1L << (EXPLAIN - 64)) | (1L << (FAIL - 64)) | (1L << (FOR - 64)) | (1L << (FOREIGN - 64)) | (1L << (FROM - 64)) | (1L << (FULL - 64)) | (1L << (GLOB - 64)) | (1L << (GROUP - 64)) | (1L << (HAVING - 64)) | (1L << (IF - 64)) | (1L << (IGNORE - 64)) | (1L << (IMMEDIATE - 64)) | (1L << (IN - 64)) | (1L << (INDEX - 64)) | (1L << (INDEXED - 64)) | (1L << (INITIALLY - 64)) | (1L << (INNER - 64)) | (1L << (INSERT - 64)) | (1L << (INSTEAD - 64)) | (1L << (INTERSECT - 64)) | (1L << (INTO - 64)) | (1L << (IS - 64)) | (1L << (ISNULL - 64)) | (1L << (JOIN - 64)) | (1L << (KEY - 64)) | (1L << (LEFT - 64)) | (1L << (LIKE - 64)) | (1L << (LIMIT - 64)) | (1L << (MATCH - 64)) | (1L << (NATURAL - 64)) | (1L << (NO - 64)) | (1L << (NOT - 64)) | (1L << (NOTNULL - 64)) | (1L << (NULL_ - 64)) | (1L << (OF - 64)) | (1L << (OFFSET - 64)) | (1L << (ON - 64)) | (1L << (OR - 64)) | (1L << (ORDER - 64)) | (1L << (OUTER - 64)) | (1L << (PLAN - 64)) | (1L << (PRAGMA - 64)) | (1L << (PRIMARY - 64)) | (1L << (QUERY - 64)) | (1L << (RAISE - 64)) | (1L << (RECURSIVE - 64)) | (1L << (REFERENCES - 64)) | (1L << (REGEXP - 64)) | (1L << (REINDEX - 64)) | (1L << (RELEASE - 64)) | (1L << (RENAME - 64)) | (1L << (REPLACE - 64)) | (1L << (RESTRICT - 64)) | (1L << (RIGHT - 64)) | (1L << (ROLLBACK - 64)) | (1L << (ROW - 64)) | (1L << (ROWS - 64)))) != 0) || ((((_la - 128)) & ~0x3f) == 0 && ((1L << (_la - 128)) & ((1L << (SAVEPOINT - 128)) | (1L << (SELECT - 128)) | (1L << (SET - 128)) | (1L << (TABLE - 128)) | (1L << (TEMP - 128)) | (1L << (TEMPORARY - 128)) | (1L << (THEN - 128)) | (1L << (TO - 128)) | (1L << (TRANSACTION - 128)) | (1L << (TRIGGER - 128)) | (1L << (UNION - 128)) | (1L << (UNIQUE - 128)) | (1L << (UPDATE - 128)) | (1L << (USING - 128)) | (1L << (VACUUM - 128)) | (1L << (VALUES - 128)) | (1L << (VIEW - 128)) | (1L << (VIRTUAL - 128)) | (1L << (WHEN - 128)) | (1L << (WHERE - 128)) | (1L << (WITH - 128)) | (1L << (WITHOUT - 128)) | (1L << (FIRST_VALUE - 128)) | (1L << (OVER - 128)) | (1L << (PARTITION - 128)) | (1L << (RANGE - 128)) | (1L << (PRECEDING - 128)) | (1L << (UNBOUNDED - 128)) | (1L << (CURRENT - 128)) | (1L << (FOLLOWING - 128)) | (1L << (CUME_DIST - 128)) | (1L << (DENSE_RANK - 128)) | (1L << (LAG - 128)) | (1L << (LAST_VALUE - 128)) | (1L << (LEAD - 128)) | (1L << (NTH_VALUE - 128)) | (1L << (NTILE - 128)) | (1L << (PERCENT_RANK - 128)) | (1L << (RANK - 128)) | (1L << (ROW_NUMBER - 128)) | (1L << (GENERATED - 128)) | (1L << (ALWAYS - 128)) | (1L << (STORED - 128)) | (1L << (TRUE_ - 128)) | (1L << (FALSE_ - 128)) | (1L << (WINDOW - 128)) | (1L << (NULLS - 128)) | (1L << (FIRST - 128)) | (1L << (LAST - 128)) | (1L << (FILTER - 128)) | (1L << (GROUPS - 128)) | (1L << (EXCLUDE - 128)) | (1L << (IDENTIFIER - 128)) | (1L << (NUMERIC_LITERAL - 128)) | (1L << (BIND_PARAMETER - 128)) | (1L << (STRING_LITERAL - 128)) | (1L << (BLOB_LITERAL - 128)))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Order_by_expr_asc_descContext extends ParserRuleContext {
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public Order_by_expr_asc_descContext order_by_expr_asc_desc() {
			return getRuleContext(Order_by_expr_asc_descContext.class,0);
		}
		public Order_by_expr_asc_descContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_expr_asc_desc; }
	}

	public final Order_by_expr_asc_descContext order_by_expr_asc_desc() throws RecognitionException {
		Order_by_expr_asc_descContext _localctx = new Order_by_expr_asc_descContext(_ctx, getState());
		enterRule(_localctx, 198, RULE_order_by_expr_asc_desc);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1814);
			match(ORDER);
			setState(1815);
			match(BY);
			setState(1816);
			order_by_expr_asc_desc();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Expr_asc_descContext extends ParserRuleContext {
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<Asc_descContext> asc_desc() {
			return getRuleContexts(Asc_descContext.class);
		}
		public Asc_descContext asc_desc(int i) {
			return getRuleContext(Asc_descContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SQLiteParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SQLiteParser.COMMA, i);
		}
		public Expr_asc_descContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr_asc_desc; }
	}

	public final Expr_asc_descContext expr_asc_desc() throws RecognitionException {
		Expr_asc_descContext _localctx = new Expr_asc_descContext(_ctx, getState());
		enterRule(_localctx, 200, RULE_expr_asc_desc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1818);
			expr(0);
			setState(1820);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(1819);
				asc_desc();
				}
			}

			setState(1829);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1822);
				match(COMMA);
				setState(1823);
				expr(0);
				setState(1825);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ASC || _la==DESC) {
					{
					setState(1824);
					asc_desc();
					}
				}

				}
				}
				setState(1831);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Initial_selectContext extends ParserRuleContext {
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Initial_selectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_initial_select; }
	}

	public final Initial_selectContext initial_select() throws RecognitionException {
		Initial_selectContext _localctx = new Initial_selectContext(_ctx, getState());
		enterRule(_localctx, 202, RULE_initial_select);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1832);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Recursive_selectContext extends ParserRuleContext {
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Recursive_selectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_recursive_select; }
	}

	public final Recursive_selectContext recursive_select() throws RecognitionException {
		Recursive_selectContext _localctx = new Recursive_selectContext(_ctx, getState());
		enterRule(_localctx, 204, RULE_recursive_select);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1834);
			select_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Unary_operatorContext extends ParserRuleContext {
		public TerminalNode MINUS() { return getToken(SQLiteParser.MINUS, 0); }
		public TerminalNode PLUS() { return getToken(SQLiteParser.PLUS, 0); }
		public TerminalNode TILDE() { return getToken(SQLiteParser.TILDE, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public Unary_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_operator; }
	}

	public final Unary_operatorContext unary_operator() throws RecognitionException {
		Unary_operatorContext _localctx = new Unary_operatorContext(_ctx, getState());
		enterRule(_localctx, 206, RULE_unary_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1836);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << PLUS) | (1L << MINUS) | (1L << TILDE))) != 0) || _la==NOT) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Error_messageContext extends ParserRuleContext {
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public Error_messageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_error_message; }
	}

	public final Error_messageContext error_message() throws RecognitionException {
		Error_messageContext _localctx = new Error_messageContext(_ctx, getState());
		enterRule(_localctx, 208, RULE_error_message);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1838);
			match(STRING_LITERAL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Module_argumentContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Column_defContext column_def() {
			return getRuleContext(Column_defContext.class,0);
		}
		public Module_argumentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_module_argument; }
	}

	public final Module_argumentContext module_argument() throws RecognitionException {
		Module_argumentContext _localctx = new Module_argumentContext(_ctx, getState());
		enterRule(_localctx, 210, RULE_module_argument);
		try {
			setState(1842);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,265,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1840);
				expr(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1841);
				column_def();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_aliasContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SQLiteParser.IDENTIFIER, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public Column_aliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_alias; }
	}

	public final Column_aliasContext column_alias() throws RecognitionException {
		Column_aliasContext _localctx = new Column_aliasContext(_ctx, getState());
		enterRule(_localctx, 212, RULE_column_alias);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1844);
			_la = _input.LA(1);
			if ( !(_la==IDENTIFIER || _la==STRING_LITERAL) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class KeywordContext extends ParserRuleContext {
		public TerminalNode ABORT() { return getToken(SQLiteParser.ABORT, 0); }
		public TerminalNode ACTION() { return getToken(SQLiteParser.ACTION, 0); }
		public TerminalNode ADD() { return getToken(SQLiteParser.ADD, 0); }
		public TerminalNode AFTER() { return getToken(SQLiteParser.AFTER, 0); }
		public TerminalNode ALL() { return getToken(SQLiteParser.ALL, 0); }
		public TerminalNode ALTER() { return getToken(SQLiteParser.ALTER, 0); }
		public TerminalNode ANALYZE() { return getToken(SQLiteParser.ANALYZE, 0); }
		public TerminalNode AND() { return getToken(SQLiteParser.AND, 0); }
		public TerminalNode AS() { return getToken(SQLiteParser.AS, 0); }
		public TerminalNode ASC() { return getToken(SQLiteParser.ASC, 0); }
		public TerminalNode ATTACH() { return getToken(SQLiteParser.ATTACH, 0); }
		public TerminalNode AUTOINCREMENT() { return getToken(SQLiteParser.AUTOINCREMENT, 0); }
		public TerminalNode BEFORE() { return getToken(SQLiteParser.BEFORE, 0); }
		public TerminalNode BEGIN() { return getToken(SQLiteParser.BEGIN, 0); }
		public TerminalNode BETWEEN() { return getToken(SQLiteParser.BETWEEN, 0); }
		public TerminalNode BY() { return getToken(SQLiteParser.BY, 0); }
		public TerminalNode CASCADE() { return getToken(SQLiteParser.CASCADE, 0); }
		public TerminalNode CASE() { return getToken(SQLiteParser.CASE, 0); }
		public TerminalNode CAST() { return getToken(SQLiteParser.CAST, 0); }
		public TerminalNode CHECK() { return getToken(SQLiteParser.CHECK, 0); }
		public TerminalNode COLLATE() { return getToken(SQLiteParser.COLLATE, 0); }
		public TerminalNode COLUMN() { return getToken(SQLiteParser.COLUMN, 0); }
		public TerminalNode COMMIT() { return getToken(SQLiteParser.COMMIT, 0); }
		public TerminalNode CONFLICT() { return getToken(SQLiteParser.CONFLICT, 0); }
		public TerminalNode CONSTRAINT() { return getToken(SQLiteParser.CONSTRAINT, 0); }
		public TerminalNode CREATE() { return getToken(SQLiteParser.CREATE, 0); }
		public TerminalNode CROSS() { return getToken(SQLiteParser.CROSS, 0); }
		public TerminalNode CURRENT_DATE() { return getToken(SQLiteParser.CURRENT_DATE, 0); }
		public TerminalNode CURRENT_TIME() { return getToken(SQLiteParser.CURRENT_TIME, 0); }
		public TerminalNode CURRENT_TIMESTAMP() { return getToken(SQLiteParser.CURRENT_TIMESTAMP, 0); }
		public TerminalNode DATABASE() { return getToken(SQLiteParser.DATABASE, 0); }
		public TerminalNode DEFAULT() { return getToken(SQLiteParser.DEFAULT, 0); }
		public TerminalNode DEFERRABLE() { return getToken(SQLiteParser.DEFERRABLE, 0); }
		public TerminalNode DEFERRED() { return getToken(SQLiteParser.DEFERRED, 0); }
		public TerminalNode DELETE() { return getToken(SQLiteParser.DELETE, 0); }
		public TerminalNode DESC() { return getToken(SQLiteParser.DESC, 0); }
		public TerminalNode DETACH() { return getToken(SQLiteParser.DETACH, 0); }
		public TerminalNode DISTINCT() { return getToken(SQLiteParser.DISTINCT, 0); }
		public TerminalNode DROP() { return getToken(SQLiteParser.DROP, 0); }
		public TerminalNode EACH() { return getToken(SQLiteParser.EACH, 0); }
		public TerminalNode ELSE() { return getToken(SQLiteParser.ELSE, 0); }
		public TerminalNode END() { return getToken(SQLiteParser.END, 0); }
		public TerminalNode ESCAPE() { return getToken(SQLiteParser.ESCAPE, 0); }
		public TerminalNode EXCEPT() { return getToken(SQLiteParser.EXCEPT, 0); }
		public TerminalNode EXCLUSIVE() { return getToken(SQLiteParser.EXCLUSIVE, 0); }
		public TerminalNode EXISTS() { return getToken(SQLiteParser.EXISTS, 0); }
		public TerminalNode EXPLAIN() { return getToken(SQLiteParser.EXPLAIN, 0); }
		public TerminalNode FAIL() { return getToken(SQLiteParser.FAIL, 0); }
		public TerminalNode FOR() { return getToken(SQLiteParser.FOR, 0); }
		public TerminalNode FOREIGN() { return getToken(SQLiteParser.FOREIGN, 0); }
		public TerminalNode FROM() { return getToken(SQLiteParser.FROM, 0); }
		public TerminalNode FULL() { return getToken(SQLiteParser.FULL, 0); }
		public TerminalNode GLOB() { return getToken(SQLiteParser.GLOB, 0); }
		public TerminalNode GROUP() { return getToken(SQLiteParser.GROUP, 0); }
		public TerminalNode HAVING() { return getToken(SQLiteParser.HAVING, 0); }
		public TerminalNode IF() { return getToken(SQLiteParser.IF, 0); }
		public TerminalNode IGNORE() { return getToken(SQLiteParser.IGNORE, 0); }
		public TerminalNode IMMEDIATE() { return getToken(SQLiteParser.IMMEDIATE, 0); }
		public TerminalNode IN() { return getToken(SQLiteParser.IN, 0); }
		public TerminalNode INDEX() { return getToken(SQLiteParser.INDEX, 0); }
		public TerminalNode INDEXED() { return getToken(SQLiteParser.INDEXED, 0); }
		public TerminalNode INITIALLY() { return getToken(SQLiteParser.INITIALLY, 0); }
		public TerminalNode INNER() { return getToken(SQLiteParser.INNER, 0); }
		public TerminalNode INSERT() { return getToken(SQLiteParser.INSERT, 0); }
		public TerminalNode INSTEAD() { return getToken(SQLiteParser.INSTEAD, 0); }
		public TerminalNode INTERSECT() { return getToken(SQLiteParser.INTERSECT, 0); }
		public TerminalNode INTO() { return getToken(SQLiteParser.INTO, 0); }
		public TerminalNode IS() { return getToken(SQLiteParser.IS, 0); }
		public TerminalNode ISNULL() { return getToken(SQLiteParser.ISNULL, 0); }
		public TerminalNode JOIN() { return getToken(SQLiteParser.JOIN, 0); }
		public TerminalNode KEY() { return getToken(SQLiteParser.KEY, 0); }
		public TerminalNode LEFT() { return getToken(SQLiteParser.LEFT, 0); }
		public TerminalNode LIKE() { return getToken(SQLiteParser.LIKE, 0); }
		public TerminalNode LIMIT() { return getToken(SQLiteParser.LIMIT, 0); }
		public TerminalNode MATCH() { return getToken(SQLiteParser.MATCH, 0); }
		public TerminalNode NATURAL() { return getToken(SQLiteParser.NATURAL, 0); }
		public TerminalNode NO() { return getToken(SQLiteParser.NO, 0); }
		public TerminalNode NOT() { return getToken(SQLiteParser.NOT, 0); }
		public TerminalNode NOTNULL() { return getToken(SQLiteParser.NOTNULL, 0); }
		public TerminalNode NULL_() { return getToken(SQLiteParser.NULL_, 0); }
		public TerminalNode OF() { return getToken(SQLiteParser.OF, 0); }
		public TerminalNode OFFSET() { return getToken(SQLiteParser.OFFSET, 0); }
		public TerminalNode ON() { return getToken(SQLiteParser.ON, 0); }
		public TerminalNode OR() { return getToken(SQLiteParser.OR, 0); }
		public TerminalNode ORDER() { return getToken(SQLiteParser.ORDER, 0); }
		public TerminalNode OUTER() { return getToken(SQLiteParser.OUTER, 0); }
		public TerminalNode PLAN() { return getToken(SQLiteParser.PLAN, 0); }
		public TerminalNode PRAGMA() { return getToken(SQLiteParser.PRAGMA, 0); }
		public TerminalNode PRIMARY() { return getToken(SQLiteParser.PRIMARY, 0); }
		public TerminalNode QUERY() { return getToken(SQLiteParser.QUERY, 0); }
		public TerminalNode RAISE() { return getToken(SQLiteParser.RAISE, 0); }
		public TerminalNode RECURSIVE() { return getToken(SQLiteParser.RECURSIVE, 0); }
		public TerminalNode REFERENCES() { return getToken(SQLiteParser.REFERENCES, 0); }
		public TerminalNode REGEXP() { return getToken(SQLiteParser.REGEXP, 0); }
		public TerminalNode REINDEX() { return getToken(SQLiteParser.REINDEX, 0); }
		public TerminalNode RELEASE() { return getToken(SQLiteParser.RELEASE, 0); }
		public TerminalNode RENAME() { return getToken(SQLiteParser.RENAME, 0); }
		public TerminalNode REPLACE() { return getToken(SQLiteParser.REPLACE, 0); }
		public TerminalNode RESTRICT() { return getToken(SQLiteParser.RESTRICT, 0); }
		public TerminalNode RIGHT() { return getToken(SQLiteParser.RIGHT, 0); }
		public TerminalNode ROLLBACK() { return getToken(SQLiteParser.ROLLBACK, 0); }
		public TerminalNode ROW() { return getToken(SQLiteParser.ROW, 0); }
		public TerminalNode ROWS() { return getToken(SQLiteParser.ROWS, 0); }
		public TerminalNode SAVEPOINT() { return getToken(SQLiteParser.SAVEPOINT, 0); }
		public TerminalNode SELECT() { return getToken(SQLiteParser.SELECT, 0); }
		public TerminalNode SET() { return getToken(SQLiteParser.SET, 0); }
		public TerminalNode TABLE() { return getToken(SQLiteParser.TABLE, 0); }
		public TerminalNode TEMP() { return getToken(SQLiteParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(SQLiteParser.TEMPORARY, 0); }
		public TerminalNode THEN() { return getToken(SQLiteParser.THEN, 0); }
		public TerminalNode TO() { return getToken(SQLiteParser.TO, 0); }
		public TerminalNode TRANSACTION() { return getToken(SQLiteParser.TRANSACTION, 0); }
		public TerminalNode TRIGGER() { return getToken(SQLiteParser.TRIGGER, 0); }
		public TerminalNode UNION() { return getToken(SQLiteParser.UNION, 0); }
		public TerminalNode UNIQUE() { return getToken(SQLiteParser.UNIQUE, 0); }
		public TerminalNode UPDATE() { return getToken(SQLiteParser.UPDATE, 0); }
		public TerminalNode USING() { return getToken(SQLiteParser.USING, 0); }
		public TerminalNode VACUUM() { return getToken(SQLiteParser.VACUUM, 0); }
		public TerminalNode VALUES() { return getToken(SQLiteParser.VALUES, 0); }
		public TerminalNode VIEW() { return getToken(SQLiteParser.VIEW, 0); }
		public TerminalNode VIRTUAL() { return getToken(SQLiteParser.VIRTUAL, 0); }
		public TerminalNode WHEN() { return getToken(SQLiteParser.WHEN, 0); }
		public TerminalNode WHERE() { return getToken(SQLiteParser.WHERE, 0); }
		public TerminalNode WITH() { return getToken(SQLiteParser.WITH, 0); }
		public TerminalNode WITHOUT() { return getToken(SQLiteParser.WITHOUT, 0); }
		public TerminalNode FIRST_VALUE() { return getToken(SQLiteParser.FIRST_VALUE, 0); }
		public TerminalNode OVER() { return getToken(SQLiteParser.OVER, 0); }
		public TerminalNode PARTITION() { return getToken(SQLiteParser.PARTITION, 0); }
		public TerminalNode RANGE() { return getToken(SQLiteParser.RANGE, 0); }
		public TerminalNode PRECEDING() { return getToken(SQLiteParser.PRECEDING, 0); }
		public TerminalNode UNBOUNDED() { return getToken(SQLiteParser.UNBOUNDED, 0); }
		public TerminalNode CURRENT() { return getToken(SQLiteParser.CURRENT, 0); }
		public TerminalNode FOLLOWING() { return getToken(SQLiteParser.FOLLOWING, 0); }
		public TerminalNode CUME_DIST() { return getToken(SQLiteParser.CUME_DIST, 0); }
		public TerminalNode DENSE_RANK() { return getToken(SQLiteParser.DENSE_RANK, 0); }
		public TerminalNode LAG() { return getToken(SQLiteParser.LAG, 0); }
		public TerminalNode LAST_VALUE() { return getToken(SQLiteParser.LAST_VALUE, 0); }
		public TerminalNode LEAD() { return getToken(SQLiteParser.LEAD, 0); }
		public TerminalNode NTH_VALUE() { return getToken(SQLiteParser.NTH_VALUE, 0); }
		public TerminalNode NTILE() { return getToken(SQLiteParser.NTILE, 0); }
		public TerminalNode PERCENT_RANK() { return getToken(SQLiteParser.PERCENT_RANK, 0); }
		public TerminalNode RANK() { return getToken(SQLiteParser.RANK, 0); }
		public TerminalNode ROW_NUMBER() { return getToken(SQLiteParser.ROW_NUMBER, 0); }
		public TerminalNode GENERATED() { return getToken(SQLiteParser.GENERATED, 0); }
		public TerminalNode ALWAYS() { return getToken(SQLiteParser.ALWAYS, 0); }
		public TerminalNode STORED() { return getToken(SQLiteParser.STORED, 0); }
		public TerminalNode TRUE_() { return getToken(SQLiteParser.TRUE_, 0); }
		public TerminalNode FALSE_() { return getToken(SQLiteParser.FALSE_, 0); }
		public TerminalNode WINDOW() { return getToken(SQLiteParser.WINDOW, 0); }
		public TerminalNode NULLS() { return getToken(SQLiteParser.NULLS, 0); }
		public TerminalNode FIRST() { return getToken(SQLiteParser.FIRST, 0); }
		public TerminalNode LAST() { return getToken(SQLiteParser.LAST, 0); }
		public TerminalNode FILTER() { return getToken(SQLiteParser.FILTER, 0); }
		public TerminalNode GROUPS() { return getToken(SQLiteParser.GROUPS, 0); }
		public TerminalNode EXCLUDE() { return getToken(SQLiteParser.EXCLUDE, 0); }
		public KeywordContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_keyword; }
	}

	public final KeywordContext keyword() throws RecognitionException {
		KeywordContext _localctx = new KeywordContext(_ctx, getState());
		enterRule(_localctx, 214, RULE_keyword);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1846);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << ABORT) | (1L << ACTION) | (1L << ADD) | (1L << AFTER) | (1L << ALL) | (1L << ALTER) | (1L << ANALYZE) | (1L << AND) | (1L << AS) | (1L << ASC) | (1L << ATTACH) | (1L << AUTOINCREMENT) | (1L << BEFORE) | (1L << BEGIN) | (1L << BETWEEN) | (1L << BY) | (1L << CASCADE) | (1L << CASE) | (1L << CAST) | (1L << CHECK) | (1L << COLLATE) | (1L << COLUMN) | (1L << COMMIT) | (1L << CONFLICT) | (1L << CONSTRAINT) | (1L << CREATE) | (1L << CROSS) | (1L << CURRENT_DATE) | (1L << CURRENT_TIME) | (1L << CURRENT_TIMESTAMP) | (1L << DATABASE) | (1L << DEFAULT) | (1L << DEFERRABLE) | (1L << DEFERRED) | (1L << DELETE) | (1L << DESC) | (1L << DETACH) | (1L << DISTINCT) | (1L << DROP))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (EACH - 64)) | (1L << (ELSE - 64)) | (1L << (END - 64)) | (1L << (ESCAPE - 64)) | (1L << (EXCEPT - 64)) | (1L << (EXCLUSIVE - 64)) | (1L << (EXISTS - 64)) | (1L << (EXPLAIN - 64)) | (1L << (FAIL - 64)) | (1L << (FOR - 64)) | (1L << (FOREIGN - 64)) | (1L << (FROM - 64)) | (1L << (FULL - 64)) | (1L << (GLOB - 64)) | (1L << (GROUP - 64)) | (1L << (HAVING - 64)) | (1L << (IF - 64)) | (1L << (IGNORE - 64)) | (1L << (IMMEDIATE - 64)) | (1L << (IN - 64)) | (1L << (INDEX - 64)) | (1L << (INDEXED - 64)) | (1L << (INITIALLY - 64)) | (1L << (INNER - 64)) | (1L << (INSERT - 64)) | (1L << (INSTEAD - 64)) | (1L << (INTERSECT - 64)) | (1L << (INTO - 64)) | (1L << (IS - 64)) | (1L << (ISNULL - 64)) | (1L << (JOIN - 64)) | (1L << (KEY - 64)) | (1L << (LEFT - 64)) | (1L << (LIKE - 64)) | (1L << (LIMIT - 64)) | (1L << (MATCH - 64)) | (1L << (NATURAL - 64)) | (1L << (NO - 64)) | (1L << (NOT - 64)) | (1L << (NOTNULL - 64)) | (1L << (NULL_ - 64)) | (1L << (OF - 64)) | (1L << (OFFSET - 64)) | (1L << (ON - 64)) | (1L << (OR - 64)) | (1L << (ORDER - 64)) | (1L << (OUTER - 64)) | (1L << (PLAN - 64)) | (1L << (PRAGMA - 64)) | (1L << (PRIMARY - 64)) | (1L << (QUERY - 64)) | (1L << (RAISE - 64)) | (1L << (RECURSIVE - 64)) | (1L << (REFERENCES - 64)) | (1L << (REGEXP - 64)) | (1L << (REINDEX - 64)) | (1L << (RELEASE - 64)) | (1L << (RENAME - 64)) | (1L << (REPLACE - 64)) | (1L << (RESTRICT - 64)) | (1L << (RIGHT - 64)) | (1L << (ROLLBACK - 64)) | (1L << (ROW - 64)) | (1L << (ROWS - 64)))) != 0) || ((((_la - 128)) & ~0x3f) == 0 && ((1L << (_la - 128)) & ((1L << (SAVEPOINT - 128)) | (1L << (SELECT - 128)) | (1L << (SET - 128)) | (1L << (TABLE - 128)) | (1L << (TEMP - 128)) | (1L << (TEMPORARY - 128)) | (1L << (THEN - 128)) | (1L << (TO - 128)) | (1L << (TRANSACTION - 128)) | (1L << (TRIGGER - 128)) | (1L << (UNION - 128)) | (1L << (UNIQUE - 128)) | (1L << (UPDATE - 128)) | (1L << (USING - 128)) | (1L << (VACUUM - 128)) | (1L << (VALUES - 128)) | (1L << (VIEW - 128)) | (1L << (VIRTUAL - 128)) | (1L << (WHEN - 128)) | (1L << (WHERE - 128)) | (1L << (WITH - 128)) | (1L << (WITHOUT - 128)) | (1L << (FIRST_VALUE - 128)) | (1L << (OVER - 128)) | (1L << (PARTITION - 128)) | (1L << (RANGE - 128)) | (1L << (PRECEDING - 128)) | (1L << (UNBOUNDED - 128)) | (1L << (CURRENT - 128)) | (1L << (FOLLOWING - 128)) | (1L << (CUME_DIST - 128)) | (1L << (DENSE_RANK - 128)) | (1L << (LAG - 128)) | (1L << (LAST_VALUE - 128)) | (1L << (LEAD - 128)) | (1L << (NTH_VALUE - 128)) | (1L << (NTILE - 128)) | (1L << (PERCENT_RANK - 128)) | (1L << (RANK - 128)) | (1L << (ROW_NUMBER - 128)) | (1L << (GENERATED - 128)) | (1L << (ALWAYS - 128)) | (1L << (STORED - 128)) | (1L << (TRUE_ - 128)) | (1L << (FALSE_ - 128)) | (1L << (WINDOW - 128)) | (1L << (NULLS - 128)) | (1L << (FIRST - 128)) | (1L << (LAST - 128)) | (1L << (FILTER - 128)) | (1L << (GROUPS - 128)) | (1L << (EXCLUDE - 128)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public NameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_name; }
	}

	public final NameContext name() throws RecognitionException {
		NameContext _localctx = new NameContext(_ctx, getState());
		enterRule(_localctx, 216, RULE_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1848);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Function_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Function_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function_name; }
	}

	public final Function_nameContext function_name() throws RecognitionException {
		Function_nameContext _localctx = new Function_nameContext(_ctx, getState());
		enterRule(_localctx, 218, RULE_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1850);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Schema_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Schema_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_schema_name; }
	}

	public final Schema_nameContext schema_name() throws RecognitionException {
		Schema_nameContext _localctx = new Schema_nameContext(_ctx, getState());
		enterRule(_localctx, 220, RULE_schema_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1852);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_name; }
	}

	public final Table_nameContext table_name() throws RecognitionException {
		Table_nameContext _localctx = new Table_nameContext(_ctx, getState());
		enterRule(_localctx, 222, RULE_table_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1854);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_or_index_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_or_index_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_or_index_name; }
	}

	public final Table_or_index_nameContext table_or_index_name() throws RecognitionException {
		Table_or_index_nameContext _localctx = new Table_or_index_nameContext(_ctx, getState());
		enterRule(_localctx, 224, RULE_table_or_index_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1856);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class New_table_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public New_table_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_new_table_name; }
	}

	public final New_table_nameContext new_table_name() throws RecognitionException {
		New_table_nameContext _localctx = new New_table_nameContext(_ctx, getState());
		enterRule(_localctx, 226, RULE_new_table_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1858);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Column_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Column_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_name; }
	}

	public final Column_nameContext column_name() throws RecognitionException {
		Column_nameContext _localctx = new Column_nameContext(_ctx, getState());
		enterRule(_localctx, 228, RULE_column_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1860);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Collation_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Collation_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_collation_name; }
	}

	public final Collation_nameContext collation_name() throws RecognitionException {
		Collation_nameContext _localctx = new Collation_nameContext(_ctx, getState());
		enterRule(_localctx, 230, RULE_collation_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1862);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Foreign_tableContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Foreign_tableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_foreign_table; }
	}

	public final Foreign_tableContext foreign_table() throws RecognitionException {
		Foreign_tableContext _localctx = new Foreign_tableContext(_ctx, getState());
		enterRule(_localctx, 232, RULE_foreign_table);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1864);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Index_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Index_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_index_name; }
	}

	public final Index_nameContext index_name() throws RecognitionException {
		Index_nameContext _localctx = new Index_nameContext(_ctx, getState());
		enterRule(_localctx, 234, RULE_index_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1866);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Trigger_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Trigger_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_trigger_name; }
	}

	public final Trigger_nameContext trigger_name() throws RecognitionException {
		Trigger_nameContext _localctx = new Trigger_nameContext(_ctx, getState());
		enterRule(_localctx, 236, RULE_trigger_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1868);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class View_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public View_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_view_name; }
	}

	public final View_nameContext view_name() throws RecognitionException {
		View_nameContext _localctx = new View_nameContext(_ctx, getState());
		enterRule(_localctx, 238, RULE_view_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1870);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Module_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Module_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_module_name; }
	}

	public final Module_nameContext module_name() throws RecognitionException {
		Module_nameContext _localctx = new Module_nameContext(_ctx, getState());
		enterRule(_localctx, 240, RULE_module_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1872);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Pragma_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Pragma_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pragma_name; }
	}

	public final Pragma_nameContext pragma_name() throws RecognitionException {
		Pragma_nameContext _localctx = new Pragma_nameContext(_ctx, getState());
		enterRule(_localctx, 242, RULE_pragma_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1874);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Savepoint_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Savepoint_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_savepoint_name; }
	}

	public final Savepoint_nameContext savepoint_name() throws RecognitionException {
		Savepoint_nameContext _localctx = new Savepoint_nameContext(_ctx, getState());
		enterRule(_localctx, 244, RULE_savepoint_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1876);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_aliasContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_aliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_alias; }
	}

	public final Table_aliasContext table_alias() throws RecognitionException {
		Table_aliasContext _localctx = new Table_aliasContext(_ctx, getState());
		enterRule(_localctx, 246, RULE_table_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1878);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Transaction_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Transaction_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_transaction_name; }
	}

	public final Transaction_nameContext transaction_name() throws RecognitionException {
		Transaction_nameContext _localctx = new Transaction_nameContext(_ctx, getState());
		enterRule(_localctx, 248, RULE_transaction_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1880);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Window_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Window_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_name; }
	}

	public final Window_nameContext window_name() throws RecognitionException {
		Window_nameContext _localctx = new Window_nameContext(_ctx, getState());
		enterRule(_localctx, 250, RULE_window_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1882);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AliasContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public AliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_alias; }
	}

	public final AliasContext alias() throws RecognitionException {
		AliasContext _localctx = new AliasContext(_ctx, getState());
		enterRule(_localctx, 252, RULE_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1884);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FilenameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public FilenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filename; }
	}

	public final FilenameContext filename() throws RecognitionException {
		FilenameContext _localctx = new FilenameContext(_ctx, getState());
		enterRule(_localctx, 254, RULE_filename);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1886);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Base_window_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Base_window_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_base_window_name; }
	}

	public final Base_window_nameContext base_window_name() throws RecognitionException {
		Base_window_nameContext _localctx = new Base_window_nameContext(_ctx, getState());
		enterRule(_localctx, 256, RULE_base_window_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1888);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Simple_funcContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Simple_funcContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_simple_func; }
	}

	public final Simple_funcContext simple_func() throws RecognitionException {
		Simple_funcContext _localctx = new Simple_funcContext(_ctx, getState());
		enterRule(_localctx, 258, RULE_simple_func);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1890);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Aggregate_funcContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Aggregate_funcContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregate_func; }
	}

	public final Aggregate_funcContext aggregate_func() throws RecognitionException {
		Aggregate_funcContext _localctx = new Aggregate_funcContext(_ctx, getState());
		enterRule(_localctx, 260, RULE_aggregate_func);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1892);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Table_function_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Table_function_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_table_function_name; }
	}

	public final Table_function_nameContext table_function_name() throws RecognitionException {
		Table_function_nameContext _localctx = new Table_function_nameContext(_ctx, getState());
		enterRule(_localctx, 262, RULE_table_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1894);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Any_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SQLiteParser.IDENTIFIER, 0); }
		public KeywordContext keyword() {
			return getRuleContext(KeywordContext.class,0);
		}
		public TerminalNode STRING_LITERAL() { return getToken(SQLiteParser.STRING_LITERAL, 0); }
		public TerminalNode OPEN_PAR() { return getToken(SQLiteParser.OPEN_PAR, 0); }
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(SQLiteParser.CLOSE_PAR, 0); }
		public Any_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_any_name; }
	}

	public final Any_nameContext any_name() throws RecognitionException {
		Any_nameContext _localctx = new Any_nameContext(_ctx, getState());
		enterRule(_localctx, 264, RULE_any_name);
		try {
			setState(1903);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(1896);
				match(IDENTIFIER);
				}
				break;
			case ABORT:
			case ACTION:
			case ADD:
			case AFTER:
			case ALL:
			case ALTER:
			case ANALYZE:
			case AND:
			case AS:
			case ASC:
			case ATTACH:
			case AUTOINCREMENT:
			case BEFORE:
			case BEGIN:
			case BETWEEN:
			case BY:
			case CASCADE:
			case CASE:
			case CAST:
			case CHECK:
			case COLLATE:
			case COLUMN:
			case COMMIT:
			case CONFLICT:
			case CONSTRAINT:
			case CREATE:
			case CROSS:
			case CURRENT_DATE:
			case CURRENT_TIME:
			case CURRENT_TIMESTAMP:
			case DATABASE:
			case DEFAULT:
			case DEFERRABLE:
			case DEFERRED:
			case DELETE:
			case DESC:
			case DETACH:
			case DISTINCT:
			case DROP:
			case EACH:
			case ELSE:
			case END:
			case ESCAPE:
			case EXCEPT:
			case EXCLUSIVE:
			case EXISTS:
			case EXPLAIN:
			case FAIL:
			case FOR:
			case FOREIGN:
			case FROM:
			case FULL:
			case GLOB:
			case GROUP:
			case HAVING:
			case IF:
			case IGNORE:
			case IMMEDIATE:
			case IN:
			case INDEX:
			case INDEXED:
			case INITIALLY:
			case INNER:
			case INSERT:
			case INSTEAD:
			case INTERSECT:
			case INTO:
			case IS:
			case ISNULL:
			case JOIN:
			case KEY:
			case LEFT:
			case LIKE:
			case LIMIT:
			case MATCH:
			case NATURAL:
			case NO:
			case NOT:
			case NOTNULL:
			case NULL_:
			case OF:
			case OFFSET:
			case ON:
			case OR:
			case ORDER:
			case OUTER:
			case PLAN:
			case PRAGMA:
			case PRIMARY:
			case QUERY:
			case RAISE:
			case RECURSIVE:
			case REFERENCES:
			case REGEXP:
			case REINDEX:
			case RELEASE:
			case RENAME:
			case REPLACE:
			case RESTRICT:
			case RIGHT:
			case ROLLBACK:
			case ROW:
			case ROWS:
			case SAVEPOINT:
			case SELECT:
			case SET:
			case TABLE:
			case TEMP:
			case TEMPORARY:
			case THEN:
			case TO:
			case TRANSACTION:
			case TRIGGER:
			case UNION:
			case UNIQUE:
			case UPDATE:
			case USING:
			case VACUUM:
			case VALUES:
			case VIEW:
			case VIRTUAL:
			case WHEN:
			case WHERE:
			case WITH:
			case WITHOUT:
			case FIRST_VALUE:
			case OVER:
			case PARTITION:
			case RANGE:
			case PRECEDING:
			case UNBOUNDED:
			case CURRENT:
			case FOLLOWING:
			case CUME_DIST:
			case DENSE_RANK:
			case LAG:
			case LAST_VALUE:
			case LEAD:
			case NTH_VALUE:
			case NTILE:
			case PERCENT_RANK:
			case RANK:
			case ROW_NUMBER:
			case GENERATED:
			case ALWAYS:
			case STORED:
			case TRUE_:
			case FALSE_:
			case WINDOW:
			case NULLS:
			case FIRST:
			case LAST:
			case FILTER:
			case GROUPS:
			case EXCLUDE:
				enterOuterAlt(_localctx, 2);
				{
				setState(1897);
				keyword();
				}
				break;
			case STRING_LITERAL:
				enterOuterAlt(_localctx, 3);
				{
				setState(1898);
				match(STRING_LITERAL);
				}
				break;
			case OPEN_PAR:
				enterOuterAlt(_localctx, 4);
				{
				setState(1899);
				match(OPEN_PAR);
				setState(1900);
				any_name();
				setState(1901);
				match(CLOSE_PAR);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 34:
			return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 12);
		case 1:
			return precpred(_ctx, 3);
		case 2:
			return precpred(_ctx, 9);
		case 3:
			return precpred(_ctx, 8);
		case 4:
			return precpred(_ctx, 7);
		case 5:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\u00c2\u0774\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t="+
		"\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G\tG\4H\tH\4I"+
		"\tI\4J\tJ\4K\tK\4L\tL\4M\tM\4N\tN\4O\tO\4P\tP\4Q\tQ\4R\tR\4S\tS\4T\tT"+
		"\4U\tU\4V\tV\4W\tW\4X\tX\4Y\tY\4Z\tZ\4[\t[\4\\\t\\\4]\t]\4^\t^\4_\t_\4"+
		"`\t`\4a\ta\4b\tb\4c\tc\4d\td\4e\te\4f\tf\4g\tg\4h\th\4i\ti\4j\tj\4k\t"+
		"k\4l\tl\4m\tm\4n\tn\4o\to\4p\tp\4q\tq\4r\tr\4s\ts\4t\tt\4u\tu\4v\tv\4"+
		"w\tw\4x\tx\4y\ty\4z\tz\4{\t{\4|\t|\4}\t}\4~\t~\4\177\t\177\4\u0080\t\u0080"+
		"\4\u0081\t\u0081\4\u0082\t\u0082\4\u0083\t\u0083\4\u0084\t\u0084\4\u0085"+
		"\t\u0085\4\u0086\t\u0086\3\2\3\2\7\2\u010f\n\2\f\2\16\2\u0112\13\2\3\2"+
		"\3\2\3\3\3\3\3\3\3\4\7\4\u011a\n\4\f\4\16\4\u011d\13\4\3\4\3\4\6\4\u0121"+
		"\n\4\r\4\16\4\u0122\3\4\7\4\u0126\n\4\f\4\16\4\u0129\13\4\3\4\7\4\u012c"+
		"\n\4\f\4\16\4\u012f\13\4\3\5\3\5\3\5\5\5\u0134\n\5\5\5\u0136\n\5\3\5\3"+
		"\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5"+
		"\3\5\3\5\3\5\3\5\3\5\5\5\u0150\n\5\3\6\3\6\3\6\3\6\3\6\5\6\u0157\n\6\3"+
		"\6\3\6\3\6\3\6\3\6\5\6\u015e\n\6\3\6\3\6\3\6\3\6\5\6\u0164\n\6\3\6\3\6"+
		"\5\6\u0168\n\6\3\6\5\6\u016b\n\6\3\7\3\7\3\7\3\7\3\7\5\7\u0172\n\7\3\7"+
		"\5\7\u0175\n\7\3\b\3\b\5\b\u0179\n\b\3\b\3\b\3\b\3\b\3\t\3\t\5\t\u0181"+
		"\n\t\3\t\3\t\5\t\u0185\n\t\5\t\u0187\n\t\3\n\3\n\5\n\u018b\n\n\3\13\3"+
		"\13\5\13\u018f\n\13\3\13\3\13\5\13\u0193\n\13\3\13\5\13\u0196\n\13\3\f"+
		"\3\f\3\f\3\r\3\r\5\r\u019d\n\r\3\r\3\r\3\16\3\16\5\16\u01a3\n\16\3\16"+
		"\3\16\3\16\3\16\5\16\u01a9\n\16\3\16\3\16\3\16\5\16\u01ae\n\16\3\16\3"+
		"\16\3\16\3\16\3\16\3\16\3\16\7\16\u01b7\n\16\f\16\16\16\u01ba\13\16\3"+
		"\16\3\16\5\16\u01be\n\16\3\17\3\17\3\17\3\20\3\20\5\20\u01c5\n\20\3\20"+
		"\3\20\5\20\u01c9\n\20\3\20\5\20\u01cc\n\20\3\21\3\21\5\21\u01d0\n\21\3"+
		"\21\3\21\3\21\3\21\5\21\u01d6\n\21\3\21\3\21\3\21\5\21\u01db\n\21\3\21"+
		"\3\21\3\21\3\21\3\21\7\21\u01e2\n\21\f\21\16\21\u01e5\13\21\3\21\3\21"+
		"\7\21\u01e9\n\21\f\21\16\21\u01ec\13\21\3\21\3\21\3\21\5\21\u01f1\n\21"+
		"\3\21\3\21\5\21\u01f5\n\21\3\22\3\22\5\22\u01f9\n\22\3\22\7\22\u01fc\n"+
		"\22\f\22\16\22\u01ff\13\22\3\23\6\23\u0202\n\23\r\23\16\23\u0203\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u0210\n\23\3\24\3\24"+
		"\5\24\u0214\n\24\3\24\3\24\3\24\5\24\u0219\n\24\3\24\5\24\u021c\n\24\3"+
		"\24\5\24\u021f\n\24\3\24\3\24\3\24\5\24\u0224\n\24\3\24\5\24\u0227\n\24"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u0235"+
		"\n\24\3\24\3\24\3\24\3\24\3\24\5\24\u023c\n\24\3\24\3\24\3\24\3\24\3\24"+
		"\5\24\u0243\n\24\5\24\u0245\n\24\3\25\5\25\u0248\n\25\3\25\3\25\3\26\3"+
		"\26\5\26\u024e\n\26\3\26\3\26\3\26\5\26\u0253\n\26\3\26\3\26\3\26\3\26"+
		"\7\26\u0259\n\26\f\26\16\26\u025c\13\26\3\26\3\26\5\26\u0260\n\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\5\26\u026c\n\26\3\27\3\27"+
		"\3\27\5\27\u0271\n\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\5\27\u027b"+
		"\n\27\3\27\3\27\7\27\u027f\n\27\f\27\16\27\u0282\13\27\3\27\5\27\u0285"+
		"\n\27\3\27\3\27\3\27\5\27\u028a\n\27\5\27\u028c\n\27\3\30\3\30\3\30\3"+
		"\30\3\31\3\31\5\31\u0294\n\31\3\31\3\31\3\31\3\31\5\31\u029a\n\31\3\31"+
		"\3\31\3\31\5\31\u029f\n\31\3\31\3\31\3\31\3\31\3\31\5\31\u02a6\n\31\3"+
		"\31\3\31\3\31\3\31\3\31\3\31\3\31\7\31\u02af\n\31\f\31\16\31\u02b2\13"+
		"\31\5\31\u02b4\n\31\5\31\u02b6\n\31\3\31\3\31\3\31\3\31\3\31\5\31\u02bd"+
		"\n\31\3\31\3\31\5\31\u02c1\n\31\3\31\3\31\3\31\3\31\3\31\5\31\u02c8\n"+
		"\31\3\31\3\31\6\31\u02cc\n\31\r\31\16\31\u02cd\3\31\3\31\3\32\3\32\5\32"+
		"\u02d4\n\32\3\32\3\32\3\32\3\32\5\32\u02da\n\32\3\32\3\32\3\32\5\32\u02df"+
		"\n\32\3\32\3\32\5\32\u02e3\n\32\3\32\3\32\3\32\3\33\3\33\3\33\3\33\3\33"+
		"\3\33\5\33\u02ee\n\33\3\33\3\33\3\33\5\33\u02f3\n\33\3\33\3\33\3\33\3"+
		"\33\3\33\3\33\3\33\7\33\u02fc\n\33\f\33\16\33\u02ff\13\33\3\33\3\33\5"+
		"\33\u0303\n\33\3\34\3\34\5\34\u0307\n\34\3\34\3\34\3\34\3\34\3\34\3\34"+
		"\3\34\3\34\3\34\3\34\3\34\3\34\7\34\u0315\n\34\f\34\16\34\u0318\13\34"+
		"\3\35\3\35\5\35\u031c\n\35\3\36\3\36\3\36\3\36\3\36\3\36\5\36\u0324\n"+
		"\36\3\36\3\36\3\36\3\37\3\37\5\37\u032b\n\37\3\37\3\37\3\37\3\37\3\37"+
		"\3 \5 \u0333\n \3 \3 \3 \3 \5 \u0339\n \3!\5!\u033c\n!\3!\3!\3!\3!\5!"+
		"\u0342\n!\3!\5!\u0345\n!\3!\5!\u0348\n!\3\"\3\"\5\"\u034c\n\"\3\"\3\""+
		"\3#\3#\3#\3#\5#\u0354\n#\3#\3#\3#\5#\u0359\n#\3#\3#\3$\3$\3$\3$\3$\3$"+
		"\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\5$\u0372\n$\3$\3$\5$\u0376"+
		"\n$\3$\3$\3$\3$\3$\3$\5$\u037e\n$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$\3$"+
		"\3$\3$\5$\u038e\n$\3$\3$\3$\3$\5$\u0394\n$\7$\u0396\n$\f$\16$\u0399\13"+
		"$\3%\3%\3%\5%\u039e\n%\3%\3%\5%\u03a2\n%\3%\3%\5%\u03a6\n%\3%\5%\u03a9"+
		"\n%\3&\5&\u03ac\n&\3&\3&\3&\3&\5&\u03b2\n&\3&\3&\3&\3&\5&\u03b8\n&\3&"+
		"\3&\3&\3&\5&\u03be\n&\3&\3&\3&\5&\u03c3\n&\3&\3&\5&\u03c7\n&\3\'\3\'\6"+
		"\'\u03cb\n\'\r\'\16\'\u03cc\3\'\5\'\u03d0\n\'\3\'\3\'\3(\3(\3(\3(\3(\3"+
		")\3)\5)\u03db\n)\3*\3*\3*\3+\5+\u03e1\n+\3+\5+\u03e4\n+\3+\3+\3+\3+\3"+
		",\3,\3,\3,\5,\u03ee\n,\3-\3-\3-\5-\u03f3\n-\3-\3-\3-\5-\u03f8\n-\3-\3"+
		"-\3.\3.\3.\3.\3.\3.\3.\3.\3.\3.\3.\3.\3.\3.\5.\u040a\n.\3.\5.\u040d\n"+
		".\3/\3/\3\60\3\60\3\60\3\60\3\60\3\60\5\60\u0417\n\60\3\60\3\60\3\61\3"+
		"\61\3\62\5\62\u041e\n\62\3\62\3\62\3\62\3\62\3\62\5\62\u0425\n\62\3\62"+
		"\3\62\3\62\3\62\5\62\u042b\n\62\3\62\3\62\3\62\5\62\u0430\n\62\3\62\5"+
		"\62\u0433\n\62\3\62\3\62\3\62\5\62\u0438\n\62\3\62\5\62\u043b\n\62\3\62"+
		"\3\62\5\62\u043f\n\62\3\63\3\63\3\63\3\63\3\63\3\63\7\63\u0447\n\63\f"+
		"\63\16\63\u044a\13\63\3\63\3\63\5\63\u044e\n\63\5\63\u0450\n\63\3\63\3"+
		"\63\3\63\3\63\3\63\3\63\5\63\u0458\n\63\3\63\3\63\3\63\3\63\3\63\5\63"+
		"\u045f\n\63\3\63\3\63\3\63\7\63\u0464\n\63\f\63\16\63\u0467\13\63\3\63"+
		"\5\63\u046a\n\63\5\63\u046c\n\63\3\64\3\64\3\64\3\64\5\64\u0472\n\64\3"+
		"\64\3\64\3\64\3\64\3\64\3\64\3\64\5\64\u047b\n\64\3\65\3\65\3\65\5\65"+
		"\u0480\n\65\3\66\3\66\3\66\3\66\3\66\5\66\u0487\n\66\3\66\3\66\5\66\u048b"+
		"\n\66\5\66\u048d\n\66\3\67\5\67\u0490\n\67\3\67\3\67\7\67\u0494\n\67\f"+
		"\67\16\67\u0497\13\67\3\67\5\67\u049a\n\67\3\67\5\67\u049d\n\67\38\38"+
		"\38\39\39\69\u04a4\n9\r9\169\u04a5\3:\3:\3:\5:\u04ab\n:\3;\3;\5;\u04af"+
		"\n;\3;\3;\3;\7;\u04b4\n;\f;\16;\u04b7\13;\3;\3;\5;\u04bb\n;\3;\5;\u04be"+
		"\n;\3;\5;\u04c1\n;\3;\3;\3;\3;\7;\u04c7\n;\f;\16;\u04ca\13;\5;\u04cc\n"+
		";\3;\3;\5;\u04d0\n;\3<\3<\3<\3<\3<\3<\3<\3<\7<\u04da\n<\f<\16<\u04dd\13"+
		"<\3=\3=\3=\3=\5=\u04e3\n=\3>\3>\3>\3?\3?\3?\3?\3@\3@\3@\7@\u04ef\n@\f"+
		"@\16@\u04f2\13@\3A\3A\3B\5B\u04f7\nB\3B\3B\5B\u04fb\nB\3B\5B\u04fe\nB"+
		"\3C\5C\u0501\nC\3C\3C\3C\5C\u0506\nC\3C\3C\5C\u050a\nC\3C\6C\u050d\nC"+
		"\rC\16C\u050e\3C\5C\u0512\nC\3C\5C\u0515\nC\3D\3D\3D\5D\u051a\nD\3D\3"+
		"D\5D\u051e\nD\3D\5D\u0521\nD\3D\3D\3D\3D\3D\5D\u0528\nD\3D\3D\3D\5D\u052d"+
		"\nD\3D\3D\3D\3D\3D\7D\u0534\nD\fD\16D\u0537\13D\3D\3D\5D\u053b\nD\3D\5"+
		"D\u053e\nD\3D\3D\3D\3D\3D\3D\3D\3D\5D\u0548\nD\3D\5D\u054b\nD\5D\u054d"+
		"\nD\3E\3E\3E\7E\u0552\nE\fE\16E\u0555\13E\3E\5E\u0558\nE\3F\3F\3F\3F\3"+
		"F\3F\3F\5F\u0561\nF\3F\5F\u0564\nF\5F\u0566\nF\3G\3G\5G\u056a\nG\3G\3"+
		"G\5G\u056e\nG\3G\3G\5G\u0572\nG\3G\5G\u0575\nG\3H\3H\3H\3H\5H\u057b\n"+
		"H\3I\3I\5I\u057f\nI\3I\3I\5I\u0583\nI\3J\5J\u0586\nJ\3J\3J\3J\5J\u058b"+
		"\nJ\3J\3J\3J\3J\5J\u0591\nJ\3J\3J\3J\3J\3J\5J\u0598\nJ\3J\3J\3J\7J\u059d"+
		"\nJ\fJ\16J\u05a0\13J\3J\5J\u05a3\nJ\3K\3K\3K\3K\7K\u05a9\nK\fK\16K\u05ac"+
		"\13K\3K\3K\3L\5L\u05b1\nL\3L\3L\3L\5L\u05b6\nL\3L\3L\3L\3L\5L\u05bc\n"+
		"L\3L\3L\3L\3L\3L\5L\u05c3\nL\3L\3L\3L\7L\u05c8\nL\fL\16L\u05cb\13L\3L"+
		"\5L\u05ce\nL\3L\5L\u05d1\nL\3L\5L\u05d4\nL\3M\3M\3M\5M\u05d9\nM\3M\3M"+
		"\3M\5M\u05de\nM\3M\3M\3M\3M\3M\5M\u05e5\nM\3N\3N\5N\u05e9\nN\3N\3N\5N"+
		"\u05ed\nN\3O\3O\3O\3O\3O\3O\3P\3P\5P\u05f7\nP\3P\3P\3P\5P\u05fc\nP\3P"+
		"\3P\3P\3P\3P\7P\u0603\nP\fP\16P\u0606\13P\3P\5P\u0609\nP\3P\3P\3Q\3Q\3"+
		"Q\3Q\5Q\u0611\nQ\3Q\3Q\3Q\5Q\u0616\nQ\3Q\3Q\3Q\3Q\3Q\7Q\u061d\nQ\fQ\16"+
		"Q\u0620\13Q\5Q\u0622\nQ\3Q\5Q\u0625\nQ\3Q\5Q\u0628\nQ\3R\3R\3R\3R\3R\3"+
		"R\3R\3R\5R\u0632\nR\3S\3S\3S\3S\3S\3S\3S\5S\u063b\nS\3T\3T\3T\3T\5T\u0641"+
		"\nT\3T\3T\3U\3U\3U\5U\u0648\nU\3U\3U\5U\u064c\nU\3U\3U\5U\u0650\nU\3V"+
		"\3V\3V\3V\5V\u0656\nV\3V\3V\5V\u065a\nV\3V\3V\3V\5V\u065f\nV\3W\3W\5W"+
		"\u0663\nW\3W\3W\3W\7W\u0668\nW\fW\16W\u066b\13W\3X\3X\3X\3X\3X\7X\u0672"+
		"\nX\fX\16X\u0675\13X\3Y\3Y\3Y\5Y\u067a\nY\3Z\3Z\3Z\3[\3[\3[\5[\u0682\n"+
		"[\3[\5[\u0685\n[\3[\3[\5[\u0689\n[\3\\\3\\\3]\3]\3]\3]\3]\3]\3]\3]\3]"+
		"\3]\5]\u0697\n]\3^\3^\3^\3^\3^\3^\3^\3^\3^\3^\5^\u06a3\n^\3_\3_\3_\3_"+
		"\3_\3_\3_\5_\u06ac\n_\3`\3`\3`\3`\3`\3`\3`\5`\u06b5\n`\3`\3`\5`\u06b9"+
		"\n`\3`\3`\3`\3`\3`\3`\3`\3`\5`\u06c3\n`\3`\5`\u06c6\n`\3`\3`\3`\3`\3`"+
		"\3`\3`\5`\u06cf\n`\3`\3`\3`\3`\3`\3`\3`\5`\u06d8\n`\3`\5`\u06db\n`\3`"+
		"\3`\3`\3`\5`\u06e1\n`\3`\3`\3`\3`\3`\3`\3`\3`\3`\3`\3`\3`\5`\u06ef\n`"+
		"\3`\3`\5`\u06f3\n`\3`\3`\3`\3`\3`\3`\3`\3`\3`\5`\u06fe\n`\3`\3`\3`\5`"+
		"\u0703\n`\3a\3a\3a\3b\3b\3b\3c\3c\3c\6c\u070e\nc\rc\16c\u070f\3d\3d\3"+
		"d\6d\u0715\nd\rd\16d\u0716\3e\3e\3e\3e\3f\3f\5f\u071f\nf\3f\3f\3f\5f\u0724"+
		"\nf\7f\u0726\nf\ff\16f\u0729\13f\3g\3g\3h\3h\3i\3i\3j\3j\3k\3k\5k\u0735"+
		"\nk\3l\3l\3m\3m\3n\3n\3o\3o\3p\3p\3q\3q\3r\3r\3s\3s\3t\3t\3u\3u\3v\3v"+
		"\3w\3w\3x\3x\3y\3y\3z\3z\3{\3{\3|\3|\3}\3}\3~\3~\3\177\3\177\3\u0080\3"+
		"\u0080\3\u0081\3\u0081\3\u0082\3\u0082\3\u0083\3\u0083\3\u0084\3\u0084"+
		"\3\u0085\3\u0085\3\u0086\3\u0086\3\u0086\3\u0086\3\u0086\3\u0086\3\u0086"+
		"\5\u0086\u0772\n\u0086\3\u0086\2\3F\u0087\2\4\6\b\n\f\16\20\22\24\26\30"+
		"\32\34\36 \"$&(*,.\60\62\64\668:<>@BDFHJLNPRTVXZ\\^`bdfhjlnprtvxz|~\u0080"+
		"\u0082\u0084\u0086\u0088\u008a\u008c\u008e\u0090\u0092\u0094\u0096\u0098"+
		"\u009a\u009c\u009e\u00a0\u00a2\u00a4\u00a6\u00a8\u00aa\u00ac\u00ae\u00b0"+
		"\u00b2\u00b4\u00b6\u00b8\u00ba\u00bc\u00be\u00c0\u00c2\u00c4\u00c6\u00c8"+
		"\u00ca\u00cc\u00ce\u00d0\u00d2\u00d4\u00d6\u00d8\u00da\u00dc\u00de\u00e0"+
		"\u00e2\u00e4\u00e6\u00e8\u00ea\u00ec\u00ee\u00f0\u00f2\u00f4\u00f6\u00f8"+
		"\u00fa\u00fc\u00fe\u0100\u0102\u0104\u0106\u0108\u010a\2\36\5\2<<GGTT"+
		"\4\2\61\61DD\3\2\u0086\u0087\4\2\u0093\u0093\u00ac\u00ac\3\2\n\13\4\2"+
		"==\u008e\u008e\4\2::jj\4\2<<TT\7\2\33\33JJSS||\177\177\6\2VV\u0085\u0085"+
		"\u008b\u008b\u0092\u0092\4\2\t\t\16\17\3\2\20\23\3\2\24\27\6\2OOcceex"+
		"x\5\2\33\33JJ\177\177\7\2\668jj\u00ad\u00ae\u00bb\u00bb\u00bd\u00be\4"+
		"\2\37\37@@\5\2\u0081\u0081\u009b\u009b\u00b4\u00b4\4\2\7\7ll\3\2\u00b1"+
		"\u00b2\4\2$$>>\4\2\u0098\u0098\u00a3\u00a3\4\2\u00a0\u00a0\u00a7\u00a7"+
		"\4\2\u00a1\u00a1\u00a8\u00a9\4\2\u00a2\u00a2\u00a4\u00a4\4\2\n\fhh\4\2"+
		"\u00ba\u00ba\u00bd\u00bd\3\2\33\u00b5\2\u0858\2\u0110\3\2\2\2\4\u0115"+
		"\3\2\2\2\6\u011b\3\2\2\2\b\u0135\3\2\2\2\n\u0151\3\2\2\2\f\u016c\3\2\2"+
		"\2\16\u0176\3\2\2\2\20\u017e\3\2\2\2\22\u0188\3\2\2\2\24\u018c\3\2\2\2"+
		"\26\u0197\3\2\2\2\30\u019a\3\2\2\2\32\u01a0\3\2\2\2\34\u01bf\3\2\2\2\36"+
		"\u01c4\3\2\2\2 \u01cd\3\2\2\2\"\u01f6\3\2\2\2$\u0201\3\2\2\2&\u0213\3"+
		"\2\2\2(\u0247\3\2\2\2*\u024d\3\2\2\2,\u026d\3\2\2\2.\u028d\3\2\2\2\60"+
		"\u0291\3\2\2\2\62\u02d1\3\2\2\2\64\u02e7\3\2\2\2\66\u0304\3\2\2\28\u0319"+
		"\3\2\2\2:\u031d\3\2\2\2<\u0328\3\2\2\2>\u0332\3\2\2\2@\u033b\3\2\2\2B"+
		"\u0349\3\2\2\2D\u034f\3\2\2\2F\u0375\3\2\2\2H\u039a\3\2\2\2J\u03ab\3\2"+
		"\2\2L\u03c8\3\2\2\2N\u03d3\3\2\2\2P\u03d8\3\2\2\2R\u03dc\3\2\2\2T\u03e3"+
		"\3\2\2\2V\u03ed\3\2\2\2X\u03f7\3\2\2\2Z\u040c\3\2\2\2\\\u040e\3\2\2\2"+
		"^\u0410\3\2\2\2`\u041a\3\2\2\2b\u043e\3\2\2\2d\u0440\3\2\2\2f\u046d\3"+
		"\2\2\2h\u047f\3\2\2\2j\u0481\3\2\2\2l\u048f\3\2\2\2n\u049e\3\2\2\2p\u04a1"+
		"\3\2\2\2r\u04a7\3\2\2\2t\u04cf\3\2\2\2v\u04d1\3\2\2\2x\u04de\3\2\2\2z"+
		"\u04e4\3\2\2\2|\u04e7\3\2\2\2~\u04eb\3\2\2\2\u0080\u04f3\3\2\2\2\u0082"+
		"\u04f6\3\2\2\2\u0084\u0500\3\2\2\2\u0086\u054c\3\2\2\2\u0088\u0557\3\2"+
		"\2\2\u008a\u0565\3\2\2\2\u008c\u0574\3\2\2\2\u008e\u057a\3\2\2\2\u0090"+
		"\u0582\3\2\2\2\u0092\u0585\3\2\2\2\u0094\u05a4\3\2\2\2\u0096\u05b0\3\2"+
		"\2\2\u0098\u05d8\3\2\2\2\u009a\u05e6\3\2\2\2\u009c\u05ee\3\2\2\2\u009e"+
		"\u05f4\3\2\2\2\u00a0\u060c\3\2\2\2\u00a2\u0629\3\2\2\2\u00a4\u0633\3\2"+
		"\2\2\u00a6\u063c\3\2\2\2\u00a8\u0644\3\2\2\2\u00aa\u0651\3\2\2\2\u00ac"+
		"\u0660\3\2\2\2\u00ae\u066c\3\2\2\2\u00b0\u0676\3\2\2\2\u00b2\u067b\3\2"+
		"\2\2\u00b4\u067e\3\2\2\2\u00b6\u068a\3\2\2\2\u00b8\u0696\3\2\2\2\u00ba"+
		"\u06a2\3\2\2\2\u00bc\u06ab\3\2\2\2\u00be\u0702\3\2\2\2\u00c0\u0704\3\2"+
		"\2\2\u00c2\u0707\3\2\2\2\u00c4\u070a\3\2\2\2\u00c6\u0711\3\2\2\2\u00c8"+
		"\u0718\3\2\2\2\u00ca\u071c\3\2\2\2\u00cc\u072a\3\2\2\2\u00ce\u072c\3\2"+
		"\2\2\u00d0\u072e\3\2\2\2\u00d2\u0730\3\2\2\2\u00d4\u0734\3\2\2\2\u00d6"+
		"\u0736\3\2\2\2\u00d8\u0738\3\2\2\2\u00da\u073a\3\2\2\2\u00dc\u073c\3\2"+
		"\2\2\u00de\u073e\3\2\2\2\u00e0\u0740\3\2\2\2\u00e2\u0742\3\2\2\2\u00e4"+
		"\u0744\3\2\2\2\u00e6\u0746\3\2\2\2\u00e8\u0748\3\2\2\2\u00ea\u074a\3\2"+
		"\2\2\u00ec\u074c\3\2\2\2\u00ee\u074e\3\2\2\2\u00f0\u0750\3\2\2\2\u00f2"+
		"\u0752\3\2\2\2\u00f4\u0754\3\2\2\2\u00f6\u0756\3\2\2\2\u00f8\u0758\3\2"+
		"\2\2\u00fa\u075a\3\2\2\2\u00fc\u075c\3\2\2\2\u00fe\u075e\3\2\2\2\u0100"+
		"\u0760\3\2\2\2\u0102\u0762\3\2\2\2\u0104\u0764\3\2\2\2\u0106\u0766\3\2"+
		"\2\2\u0108\u0768\3\2\2\2\u010a\u0771\3\2\2\2\u010c\u010f\5\6\4\2\u010d"+
		"\u010f\5\4\3\2\u010e\u010c\3\2\2\2\u010e\u010d\3\2\2\2\u010f\u0112\3\2"+
		"\2\2\u0110\u010e\3\2\2\2\u0110\u0111\3\2\2\2\u0111\u0113\3\2\2\2\u0112"+
		"\u0110\3\2\2\2\u0113\u0114\7\2\2\3\u0114\3\3\2\2\2\u0115\u0116\7\u00c2"+
		"\2\2\u0116\u0117\b\3\1\2\u0117\5\3\2\2\2\u0118\u011a\7\3\2\2\u0119\u0118"+
		"\3\2\2\2\u011a\u011d\3\2\2\2\u011b\u0119\3\2\2\2\u011b\u011c\3\2\2\2\u011c"+
		"\u011e\3\2\2\2\u011d\u011b\3\2\2\2\u011e\u0127\5\b\5\2\u011f\u0121\7\3"+
		"\2\2\u0120\u011f\3\2\2\2\u0121\u0122\3\2\2\2\u0122\u0120\3\2\2\2\u0122"+
		"\u0123\3\2\2\2\u0123\u0124\3\2\2\2\u0124\u0126\5\b\5\2\u0125\u0120\3\2"+
		"\2\2\u0126\u0129\3\2\2\2\u0127\u0125\3\2\2\2\u0127\u0128\3\2\2\2\u0128"+
		"\u012d\3\2\2\2\u0129\u0127\3\2\2\2\u012a\u012c\7\3\2\2\u012b\u012a\3\2"+
		"\2\2\u012c\u012f\3\2\2\2\u012d\u012b\3\2\2\2\u012d\u012e\3\2\2\2\u012e"+
		"\7\3\2\2\2\u012f\u012d\3\2\2\2\u0130\u0133\7I\2\2\u0131\u0132\7t\2\2\u0132"+
		"\u0134\7q\2\2\u0133\u0131\3\2\2\2\u0133\u0134\3\2\2\2\u0134\u0136\3\2"+
		"\2\2\u0135\u0130\3\2\2\2\u0135\u0136\3\2\2\2\u0136\u014f\3\2\2\2\u0137"+
		"\u0150\5\n\6\2\u0138\u0150\5\f\7\2\u0139\u0150\5\16\b\2\u013a\u0150\5"+
		"\20\t\2\u013b\u0150\5\22\n\2\u013c\u0150\5\32\16\2\u013d\u0150\5 \21\2"+
		"\u013e\u0150\5\60\31\2\u013f\u0150\5\62\32\2\u0140\u0150\5\64\33\2\u0141"+
		"\u0150\5> \2\u0142\u0150\5@!\2\u0143\u0150\5B\"\2\u0144\u0150\5D#\2\u0145"+
		"\u0150\5b\62\2\u0146\u0150\5f\64\2\u0147\u0150\5j\66\2\u0148\u0150\5\30"+
		"\r\2\u0149\u0150\5\24\13\2\u014a\u0150\5\26\f\2\u014b\u0150\5l\67\2\u014c"+
		"\u0150\5\u0092J\2\u014d\u0150\5\u0096L\2\u014e\u0150\5\u009aN\2\u014f"+
		"\u0137\3\2\2\2\u014f\u0138\3\2\2\2\u014f\u0139\3\2\2\2\u014f\u013a\3\2"+
		"\2\2\u014f\u013b\3\2\2\2\u014f\u013c\3\2\2\2\u014f\u013d\3\2\2\2\u014f"+
		"\u013e\3\2\2\2\u014f\u013f\3\2\2\2\u014f\u0140\3\2\2\2\u014f\u0141\3\2"+
		"\2\2\u014f\u0142\3\2\2\2\u014f\u0143\3\2\2\2\u014f\u0144\3\2\2\2\u014f"+
		"\u0145\3\2\2\2\u014f\u0146\3\2\2\2\u014f\u0147\3\2\2\2\u014f\u0148\3\2"+
		"\2\2\u014f\u0149\3\2\2\2\u014f\u014a\3\2\2\2\u014f\u014b\3\2\2\2\u014f"+
		"\u014c\3\2\2\2\u014f\u014d\3\2\2\2\u014f\u014e\3\2\2\2\u0150\t\3\2\2\2"+
		"\u0151\u0152\7 \2\2\u0152\u0156\7\u0085\2\2\u0153\u0154\5\u00dep\2\u0154"+
		"\u0155\7\4\2\2\u0155\u0157\3\2\2\2\u0156\u0153\3\2\2\2\u0156\u0157\3\2"+
		"\2\2\u0157\u0158\3\2\2\2\u0158\u016a\5\u00e0q\2\u0159\u0163\7{\2\2\u015a"+
		"\u015b\7\u0089\2\2\u015b\u0164\5\u00e4s\2\u015c\u015e\7\60\2\2\u015d\u015c"+
		"\3\2\2\2\u015d\u015e\3\2\2\2\u015e\u015f\3\2\2\2\u015f\u0160\5\u00e6t"+
		"\2\u0160\u0161\7\u0089\2\2\u0161\u0162\5\u00e6t\2\u0162\u0164\3\2\2\2"+
		"\u0163\u015a\3\2\2\2\u0163\u015d\3\2\2\2\u0164\u016b\3\2\2\2\u0165\u0167"+
		"\7\35\2\2\u0166\u0168\7\60\2\2\u0167\u0166\3\2\2\2\u0167\u0168\3\2\2\2"+
		"\u0168\u0169\3\2\2\2\u0169\u016b\5\"\22\2\u016a\u0159\3\2\2\2\u016a\u0165"+
		"\3\2\2\2\u016b\13\3\2\2\2\u016c\u0174\7!\2\2\u016d\u0175\5\u00dep\2\u016e"+
		"\u016f\5\u00dep\2\u016f\u0170\7\4\2\2\u0170\u0172\3\2\2\2\u0171\u016e"+
		"\3\2\2\2\u0171\u0172\3\2\2\2\u0172\u0173\3\2\2\2\u0173\u0175\5\u00e2r"+
		"\2\u0174\u016d\3\2\2\2\u0174\u0171\3\2\2\2\u0174\u0175\3\2\2\2\u0175\r"+
		"\3\2\2\2\u0176\u0178\7%\2\2\u0177\u0179\79\2\2\u0178\u0177\3\2\2\2\u0178"+
		"\u0179\3\2\2\2\u0179\u017a\3\2\2\2\u017a\u017b\5F$\2\u017b\u017c\7#\2"+
		"\2\u017c\u017d\5\u00dep\2\u017d\17\3\2\2\2\u017e\u0180\7(\2\2\u017f\u0181"+
		"\t\2\2\2\u0180\u017f\3\2\2\2\u0180\u0181\3\2\2\2\u0181\u0186\3\2\2\2\u0182"+
		"\u0184\7\u008a\2\2\u0183\u0185\5\u00fa~\2\u0184\u0183\3\2\2\2\u0184\u0185"+
		"\3\2\2\2\u0185\u0187\3\2\2\2\u0186\u0182\3\2\2\2\u0186\u0187\3\2\2\2\u0187"+
		"\21\3\2\2\2\u0188\u018a\t\3\2\2\u0189\u018b\7\u008a\2\2\u018a\u0189\3"+
		"\2\2\2\u018a\u018b\3\2\2\2\u018b\23\3\2\2\2\u018c\u018e\7\177\2\2\u018d"+
		"\u018f\7\u008a\2\2\u018e\u018d\3\2\2\2\u018e\u018f\3\2\2\2\u018f\u0195"+
		"\3\2\2\2\u0190\u0192\7\u0089\2\2\u0191\u0193\7\u0082\2\2\u0192\u0191\3"+
		"\2\2\2\u0192\u0193\3\2\2\2\u0193\u0194\3\2\2\2\u0194\u0196\5\u00f6|\2"+
		"\u0195\u0190\3\2\2\2\u0195\u0196\3\2\2\2\u0196\25\3\2\2\2\u0197\u0198"+
		"\7\u0082\2\2\u0198\u0199\5\u00f6|\2\u0199\27\3\2\2\2\u019a\u019c\7z\2"+
		"\2\u019b\u019d\7\u0082\2\2\u019c\u019b\3\2\2\2\u019c\u019d\3\2\2\2\u019d"+
		"\u019e\3\2\2\2\u019e\u019f\5\u00f6|\2\u019f\31\3\2\2\2\u01a0\u01a2\7\64"+
		"\2\2\u01a1\u01a3\7\u008d\2\2\u01a2\u01a1\3\2\2\2\u01a2\u01a3\3\2\2\2\u01a3"+
		"\u01a4\3\2\2\2\u01a4\u01a8\7V\2\2\u01a5\u01a6\7R\2\2\u01a6\u01a7\7h\2"+
		"\2\u01a7\u01a9\7H\2\2\u01a8\u01a5\3\2\2\2\u01a8\u01a9\3\2\2\2\u01a9\u01ad"+
		"\3\2\2\2\u01aa\u01ab\5\u00dep\2\u01ab\u01ac\7\4\2\2\u01ac\u01ae\3\2\2"+
		"\2\u01ad\u01aa\3\2\2\2\u01ad\u01ae\3\2\2\2\u01ae\u01af\3\2\2\2\u01af\u01b0"+
		"\5\u00ecw\2\u01b0\u01b1\7m\2\2\u01b1\u01b2\5\u00e0q\2\u01b2\u01b3\7\5"+
		"\2\2\u01b3\u01b8\5\36\20\2\u01b4\u01b5\7\7\2\2\u01b5\u01b7\5\36\20\2\u01b6"+
		"\u01b4\3\2\2\2\u01b7\u01ba\3\2\2\2\u01b8\u01b6\3\2\2\2\u01b8\u01b9\3\2"+
		"\2\2\u01b9\u01bb\3\2\2\2\u01ba\u01b8\3\2\2\2\u01bb\u01bd\7\6\2\2\u01bc"+
		"\u01be\5\34\17\2\u01bd\u01bc\3\2\2\2\u01bd\u01be\3\2\2\2\u01be\33\3\2"+
		"\2\2\u01bf\u01c0\7\u0095\2\2\u01c0\u01c1\5F$\2\u01c1\35\3\2\2\2\u01c2"+
		"\u01c5\5\u00e6t\2\u01c3\u01c5\5F$\2\u01c4\u01c2\3\2\2\2\u01c4\u01c3\3"+
		"\2\2\2\u01c5\u01c8\3\2\2\2\u01c6\u01c7\7/\2\2\u01c7\u01c9\5\u00e8u\2\u01c8"+
		"\u01c6\3\2\2\2\u01c8\u01c9\3\2\2\2\u01c9\u01cb\3\2\2\2\u01ca\u01cc\5\u00b6"+
		"\\\2\u01cb\u01ca\3\2\2\2\u01cb\u01cc\3\2\2\2\u01cc\37\3\2\2\2\u01cd\u01cf"+
		"\7\64\2\2\u01ce\u01d0\t\4\2\2\u01cf\u01ce\3\2\2\2\u01cf\u01d0\3\2\2\2"+
		"\u01d0\u01d1\3\2\2\2\u01d1\u01d5\7\u0085\2\2\u01d2\u01d3\7R\2\2\u01d3"+
		"\u01d4\7h\2\2\u01d4\u01d6\7H\2\2\u01d5\u01d2\3\2\2\2\u01d5\u01d6\3\2\2"+
		"\2\u01d6\u01da\3\2\2\2\u01d7\u01d8\5\u00dep\2\u01d8\u01d9\7\4\2\2\u01d9"+
		"\u01db\3\2\2\2\u01da\u01d7\3\2\2\2\u01da\u01db\3\2\2\2\u01db\u01dc\3\2"+
		"\2\2\u01dc\u01f4\5\u00e0q\2\u01dd\u01de\7\5\2\2\u01de\u01e3\5\"\22\2\u01df"+
		"\u01e0\7\7\2\2\u01e0\u01e2\5\"\22\2\u01e1\u01df\3\2\2\2\u01e2\u01e5\3"+
		"\2\2\2\u01e3\u01e1\3\2\2\2\u01e3\u01e4\3\2\2\2\u01e4\u01ea\3\2\2\2\u01e5"+
		"\u01e3\3\2\2\2\u01e6\u01e7\7\7\2\2\u01e7\u01e9\5*\26\2\u01e8\u01e6\3\2"+
		"\2\2\u01e9\u01ec\3\2\2\2\u01ea\u01e8\3\2\2\2\u01ea\u01eb\3\2\2\2\u01eb"+
		"\u01ed\3\2\2\2\u01ec\u01ea\3\2\2\2\u01ed\u01f0\7\6\2\2\u01ee\u01ef\7\u0097"+
		"\2\2\u01ef\u01f1\7\u00ba\2\2\u01f0\u01ee\3\2\2\2\u01f0\u01f1\3\2\2\2\u01f1"+
		"\u01f5\3\2\2\2\u01f2\u01f3\7#\2\2\u01f3\u01f5\5l\67\2\u01f4\u01dd\3\2"+
		"\2\2\u01f4\u01f2\3\2\2\2\u01f5!\3\2\2\2\u01f6\u01f8\5\u00e6t\2\u01f7\u01f9"+
		"\5$\23\2\u01f8\u01f7\3\2\2\2\u01f8\u01f9\3\2\2\2\u01f9\u01fd\3\2\2\2\u01fa"+
		"\u01fc\5&\24\2\u01fb\u01fa\3\2\2\2\u01fc\u01ff\3\2\2\2\u01fd\u01fb\3\2"+
		"\2\2\u01fd\u01fe\3\2\2\2\u01fe#\3\2\2\2\u01ff\u01fd\3\2\2\2\u0200\u0202"+
		"\5\u00dan\2\u0201\u0200\3\2\2\2\u0202\u0203\3\2\2\2\u0203\u0201\3\2\2"+
		"\2\u0203\u0204\3\2\2\2\u0204\u020f\3\2\2\2\u0205\u0206\7\5\2\2\u0206\u0207"+
		"\5(\25\2\u0207\u0208\7\6\2\2\u0208\u0210\3\2\2\2\u0209\u020a\7\5\2\2\u020a"+
		"\u020b\5(\25\2\u020b\u020c\7\7\2\2\u020c\u020d\5(\25\2\u020d\u020e\7\6"+
		"\2\2\u020e\u0210\3\2\2\2\u020f\u0205\3\2\2\2\u020f\u0209\3\2\2\2\u020f"+
		"\u0210\3\2\2\2\u0210%\3\2\2\2\u0211\u0212\7\63\2\2\u0212\u0214\5\u00da"+
		"n\2\u0213\u0211\3\2\2\2\u0213\u0214\3\2\2\2\u0214\u0244\3\2\2\2\u0215"+
		"\u0216\7s\2\2\u0216\u0218\7a\2\2\u0217\u0219\5\u00b6\\\2\u0218\u0217\3"+
		"\2\2\2\u0218\u0219\3\2\2\2\u0219\u021b\3\2\2\2\u021a\u021c\5.\30\2\u021b"+
		"\u021a\3\2\2\2\u021b\u021c\3\2\2\2\u021c\u021e\3\2\2\2\u021d\u021f\7&"+
		"\2\2\u021e\u021d\3\2\2\2\u021e\u021f\3\2\2\2\u021f\u0245\3\2\2\2\u0220"+
		"\u0221\7h\2\2\u0221\u0224\7j\2\2\u0222\u0224\7\u008d\2\2\u0223\u0220\3"+
		"\2\2\2\u0223\u0222\3\2\2\2\u0224\u0226\3\2\2\2\u0225\u0227\5.\30\2\u0226"+
		"\u0225\3\2\2\2\u0226\u0227\3\2\2\2\u0227\u0245\3\2\2\2\u0228\u0229\7."+
		"\2\2\u0229\u022a\7\5\2\2\u022a\u022b\5F$\2\u022b\u022c\7\6\2\2\u022c\u0245"+
		"\3\2\2\2\u022d\u0234\7:\2\2\u022e\u0235\5(\25\2\u022f\u0235\5`\61\2\u0230"+
		"\u0231\7\5\2\2\u0231\u0232\5F$\2\u0232\u0233\7\6\2\2\u0233\u0235\3\2\2"+
		"\2\u0234\u022e\3\2\2\2\u0234\u022f\3\2\2\2\u0234\u0230\3\2\2\2\u0235\u0245"+
		"\3\2\2\2\u0236\u0237\7/\2\2\u0237\u0245\5\u00e8u\2\u0238\u0245\5,\27\2"+
		"\u0239\u023a\7\u00aa\2\2\u023a\u023c\7\u00ab\2\2\u023b\u0239\3\2\2\2\u023b"+
		"\u023c\3\2\2\2\u023c\u023d\3\2\2\2\u023d\u023e\7#\2\2\u023e\u023f\7\5"+
		"\2\2\u023f\u0240\5F$\2\u0240\u0242\7\6\2\2\u0241\u0243\t\5\2\2\u0242\u0241"+
		"\3\2\2\2\u0242\u0243\3\2\2\2\u0243\u0245\3\2\2\2\u0244\u0215\3\2\2\2\u0244"+
		"\u0223\3\2\2\2\u0244\u0228\3\2\2\2\u0244\u022d\3\2\2\2\u0244\u0236\3\2"+
		"\2\2\u0244\u0238\3\2\2\2\u0244\u023b\3\2\2\2\u0245\'\3\2\2\2\u0246\u0248"+
		"\t\6\2\2\u0247\u0246\3\2\2\2\u0247\u0248\3\2\2\2\u0248\u0249\3\2\2\2\u0249"+
		"\u024a\7\u00bb\2\2\u024a)\3\2\2\2\u024b\u024c\7\63\2\2\u024c\u024e\5\u00da"+
		"n\2\u024d\u024b\3\2\2\2\u024d\u024e\3\2\2\2\u024e\u026b\3\2\2\2\u024f"+
		"\u0250\7s\2\2\u0250\u0253\7a\2\2\u0251\u0253\7\u008d\2\2\u0252\u024f\3"+
		"\2\2\2\u0252\u0251\3\2\2\2\u0253\u0254\3\2\2\2\u0254\u0255\7\5\2\2\u0255"+
		"\u025a\5\36\20\2\u0256\u0257\7\7\2\2\u0257\u0259\5\36\20\2\u0258\u0256"+
		"\3\2\2\2\u0259\u025c\3\2\2\2\u025a\u0258\3\2\2\2\u025a\u025b\3\2\2\2\u025b"+
		"\u025d\3\2\2\2\u025c\u025a\3\2\2\2\u025d\u025f\7\6\2\2\u025e\u0260\5."+
		"\30\2\u025f\u025e\3\2\2\2\u025f\u0260\3\2\2\2\u0260\u026c\3\2\2\2\u0261"+
		"\u0262\7.\2\2\u0262\u0263\7\5\2\2\u0263\u0264\5F$\2\u0264\u0265\7\6\2"+
		"\2\u0265\u026c\3\2\2\2\u0266\u0267\7L\2\2\u0267\u0268\7a\2\2\u0268\u0269"+
		"\5\u0094K\2\u0269\u026a\5,\27\2\u026a\u026c\3\2\2\2\u026b\u0252\3\2\2"+
		"\2\u026b\u0261\3\2\2\2\u026b\u0266\3\2\2\2\u026c+\3\2\2\2\u026d\u026e"+
		"\7w\2\2\u026e\u0270\5\u00eav\2\u026f\u0271\5\u0094K\2\u0270\u026f\3\2"+
		"\2\2\u0270\u0271\3\2\2\2\u0271\u0280\3\2\2\2\u0272\u0273\7m\2\2\u0273"+
		"\u027a\t\7\2\2\u0274\u0275\7\u0084\2\2\u0275\u027b\t\b\2\2\u0276\u027b"+
		"\7+\2\2\u0277\u027b\7}\2\2\u0278\u0279\7g\2\2\u0279\u027b\7\34\2\2\u027a"+
		"\u0274\3\2\2\2\u027a\u0276\3\2\2\2\u027a\u0277\3\2\2\2\u027a\u0278\3\2"+
		"\2\2\u027b\u027f\3\2\2\2\u027c\u027d\7e\2\2\u027d\u027f\5\u00dan\2\u027e"+
		"\u0272\3\2\2\2\u027e\u027c\3\2\2\2\u027f\u0282\3\2\2\2\u0280\u027e\3\2"+
		"\2\2\u0280\u0281\3\2\2\2\u0281\u028b\3\2\2\2\u0282\u0280\3\2\2\2\u0283"+
		"\u0285\7h\2\2\u0284\u0283\3\2\2\2\u0284\u0285\3\2\2\2\u0285\u0286\3\2"+
		"\2\2\u0286\u0289\7;\2\2\u0287\u0288\7X\2\2\u0288\u028a\t\t\2\2\u0289\u0287"+
		"\3\2\2\2\u0289\u028a\3\2\2\2\u028a\u028c\3\2\2\2\u028b\u0284\3\2\2\2\u028b"+
		"\u028c\3\2\2\2\u028c-\3\2\2\2\u028d\u028e\7m\2\2\u028e\u028f\7\62\2\2"+
		"\u028f\u0290\t\n\2\2\u0290/\3\2\2\2\u0291\u0293\7\64\2\2\u0292\u0294\t"+
		"\4\2\2\u0293\u0292\3\2\2\2\u0293\u0294\3\2\2\2\u0294\u0295\3\2\2\2\u0295"+
		"\u0299\7\u008b\2\2\u0296\u0297\7R\2\2\u0297\u0298\7h\2\2\u0298\u029a\7"+
		"H\2\2\u0299\u0296\3\2\2\2\u0299\u029a\3\2\2\2\u029a\u029e\3\2\2\2\u029b"+
		"\u029c\5\u00dep\2\u029c\u029d\7\4\2\2\u029d\u029f\3\2\2\2\u029e\u029b"+
		"\3\2\2\2\u029e\u029f\3\2\2\2\u029f\u02a0\3\2\2\2\u02a0\u02a5\5\u00eex"+
		"\2\u02a1\u02a6\7\'\2\2\u02a2\u02a6\7\36\2\2\u02a3\u02a4\7[\2\2\u02a4\u02a6"+
		"\7k\2\2\u02a5\u02a1\3\2\2\2\u02a5\u02a2\3\2\2\2\u02a5\u02a3\3\2\2\2\u02a5"+
		"\u02a6\3\2\2\2\u02a6\u02b5\3\2\2\2\u02a7\u02b6\7=\2\2\u02a8\u02b6\7Z\2"+
		"\2\u02a9\u02b3\7\u008e\2\2\u02aa\u02ab\7k\2\2\u02ab\u02b0\5\u00e6t\2\u02ac"+
		"\u02ad\7\7\2\2\u02ad\u02af\5\u00e6t\2\u02ae\u02ac\3\2\2\2\u02af\u02b2"+
		"\3\2\2\2\u02b0\u02ae\3\2\2\2\u02b0\u02b1\3\2\2\2\u02b1\u02b4\3\2\2\2\u02b2"+
		"\u02b0\3\2\2\2\u02b3\u02aa\3\2\2\2\u02b3\u02b4\3\2\2\2\u02b4\u02b6\3\2"+
		"\2\2\u02b5\u02a7\3\2\2\2\u02b5\u02a8\3\2\2\2\u02b5\u02a9\3\2\2\2\u02b6"+
		"\u02b7\3\2\2\2\u02b7\u02b8\7m\2\2\u02b8\u02bc\5\u00e0q\2\u02b9\u02ba\7"+
		"K\2\2\u02ba\u02bb\7B\2\2\u02bb\u02bd\7\u0080\2\2\u02bc\u02b9\3\2\2\2\u02bc"+
		"\u02bd\3\2\2\2\u02bd\u02c0\3\2\2\2\u02be\u02bf\7\u0094\2\2\u02bf\u02c1"+
		"\5F$\2\u02c0\u02be\3\2\2\2\u02c0\u02c1\3\2\2\2\u02c1\u02c2\3\2\2\2\u02c2"+
		"\u02cb\7(\2\2\u02c3\u02c8\5\u0092J\2\u02c4\u02c8\5b\62\2\u02c5\u02c8\5"+
		"> \2\u02c6\u02c8\5l\67\2\u02c7\u02c3\3\2\2\2\u02c7\u02c4\3\2\2\2\u02c7"+
		"\u02c5\3\2\2\2\u02c7\u02c6\3\2\2\2\u02c8\u02c9\3\2\2\2\u02c9\u02ca\7\3"+
		"\2\2\u02ca\u02cc\3\2\2\2\u02cb\u02c7\3\2\2\2\u02cc\u02cd\3\2\2\2\u02cd"+
		"\u02cb\3\2\2\2\u02cd\u02ce\3\2\2\2\u02ce\u02cf\3\2\2\2\u02cf\u02d0\7D"+
		"\2\2\u02d0\61\3\2\2\2\u02d1\u02d3\7\64\2\2\u02d2\u02d4\t\4\2\2\u02d3\u02d2"+
		"\3\2\2\2\u02d3\u02d4\3\2\2\2\u02d4\u02d5\3\2\2\2\u02d5\u02d9\7\u0092\2"+
		"\2\u02d6\u02d7\7R\2\2\u02d7\u02d8\7h\2\2\u02d8\u02da\7H\2\2\u02d9\u02d6"+
		"\3\2\2\2\u02d9\u02da\3\2\2\2\u02da\u02de\3\2\2\2\u02db\u02dc\5\u00dep"+
		"\2\u02dc\u02dd\7\4\2\2\u02dd\u02df\3\2\2\2\u02de\u02db\3\2\2\2\u02de\u02df"+
		"\3\2\2\2\u02df\u02e0\3\2\2\2\u02e0\u02e2\5\u00f0y\2\u02e1\u02e3\5\u0094"+
		"K\2\u02e2\u02e1\3\2\2\2\u02e2\u02e3\3\2\2\2\u02e3\u02e4\3\2\2\2\u02e4"+
		"\u02e5\7#\2\2\u02e5\u02e6\5l\67\2\u02e6\63\3\2\2\2\u02e7\u02e8\7\64\2"+
		"\2\u02e8\u02e9\7\u0093\2\2\u02e9\u02ed\7\u0085\2\2\u02ea\u02eb\7R\2\2"+
		"\u02eb\u02ec\7h\2\2\u02ec\u02ee\7H\2\2\u02ed\u02ea\3\2\2\2\u02ed\u02ee"+
		"\3\2\2\2\u02ee\u02f2\3\2\2\2\u02ef\u02f0\5\u00dep\2\u02f0\u02f1\7\4\2"+
		"\2\u02f1\u02f3\3\2\2\2\u02f2\u02ef\3\2\2\2\u02f2\u02f3\3\2\2\2\u02f3\u02f4"+
		"\3\2\2\2\u02f4\u02f5\5\u00e0q\2\u02f5\u02f6\7\u008f\2\2\u02f6\u0302\5"+
		"\u00f2z\2\u02f7\u02f8\7\5\2\2\u02f8\u02fd\5\u00d4k\2\u02f9\u02fa\7\7\2"+
		"\2\u02fa\u02fc\5\u00d4k\2\u02fb\u02f9\3\2\2\2\u02fc\u02ff\3\2\2\2\u02fd"+
		"\u02fb\3\2\2\2\u02fd\u02fe\3\2\2\2\u02fe\u0300\3\2\2\2\u02ff\u02fd\3\2"+
		"\2\2\u0300\u0301\7\6\2\2\u0301\u0303\3\2\2\2\u0302\u02f7\3\2\2\2\u0302"+
		"\u0303\3\2\2\2\u0303\65\3\2\2\2\u0304\u0306\7\u0096\2\2\u0305\u0307\7"+
		"v\2\2\u0306\u0305\3\2\2\2\u0306\u0307\3\2\2\2\u0307\u0308\3\2\2\2\u0308"+
		"\u0309\58\35\2\u0309\u030a\7#\2\2\u030a\u030b\7\5\2\2\u030b\u030c\5l\67"+
		"\2\u030c\u0316\7\6\2\2\u030d\u030e\7\7\2\2\u030e\u030f\58\35\2\u030f\u0310"+
		"\7#\2\2\u0310\u0311\7\5\2\2\u0311\u0312\5l\67\2\u0312\u0313\7\6\2\2\u0313"+
		"\u0315\3\2\2\2\u0314\u030d\3\2\2\2\u0315\u0318\3\2\2\2\u0316\u0314\3\2"+
		"\2\2\u0316\u0317\3\2\2\2\u0317\67\3\2\2\2\u0318\u0316\3\2\2\2\u0319\u031b"+
		"\5\u00e0q\2\u031a\u031c\5\u0094K\2\u031b\u031a\3\2\2\2\u031b\u031c\3\2"+
		"\2\2\u031c9\3\2\2\2\u031d\u031e\58\35\2\u031e\u031f\7#\2\2\u031f\u0320"+
		"\7\5\2\2\u0320\u0321\5\u00ccg\2\u0321\u0323\7\u008c\2\2\u0322\u0324\7"+
		"\37\2\2\u0323\u0322\3\2\2\2\u0323\u0324\3\2\2\2\u0324\u0325\3\2\2\2\u0325"+
		"\u0326\5\u00ceh\2\u0326\u0327\7\6\2\2\u0327;\3\2\2\2\u0328\u032a\5\u00e0"+
		"q\2\u0329\u032b\5\u0094K\2\u032a\u0329\3\2\2\2\u032a\u032b\3\2\2\2\u032b"+
		"\u032c\3\2\2\2\u032c\u032d\7#\2\2\u032d\u032e\7\5\2\2\u032e\u032f\5l\67"+
		"\2\u032f\u0330\7\6\2\2\u0330=\3\2\2\2\u0331\u0333\5\66\34\2\u0332\u0331"+
		"\3\2\2\2\u0332\u0333\3\2\2\2\u0333\u0334\3\2\2\2\u0334\u0335\7=\2\2\u0335"+
		"\u0336\7M\2\2\u0336\u0338\5\u0098M\2\u0337\u0339\5\34\17\2\u0338\u0337"+
		"\3\2\2\2\u0338\u0339\3\2\2\2\u0339?\3\2\2\2\u033a\u033c\5\66\34\2\u033b"+
		"\u033a\3\2\2\2\u033b\u033c\3\2\2\2\u033c\u033d\3\2\2\2\u033d\u033e\7="+
		"\2\2\u033e\u033f\7M\2\2\u033f\u0341\5\u0098M\2\u0340\u0342\5\34\17\2\u0341"+
		"\u0340\3\2\2\2\u0341\u0342\3\2\2\2\u0342\u0347\3\2\2\2\u0343\u0345\5\u00ae"+
		"X\2\u0344\u0343\3\2\2\2\u0344\u0345\3\2\2\2\u0345\u0346\3\2\2\2\u0346"+
		"\u0348\5\u00b0Y\2\u0347\u0344\3\2\2\2\u0347\u0348\3\2\2\2\u0348A\3\2\2"+
		"\2\u0349\u034b\7?\2\2\u034a\u034c\79\2\2\u034b\u034a\3\2\2\2\u034b\u034c"+
		"\3\2\2\2\u034c\u034d\3\2\2\2\u034d\u034e\5\u00dep\2\u034eC\3\2\2\2\u034f"+
		"\u0350\7A\2\2\u0350\u0353\t\13\2\2\u0351\u0352\7R\2\2\u0352\u0354\7H\2"+
		"\2\u0353\u0351\3\2\2\2\u0353\u0354\3\2\2\2\u0354\u0358\3\2\2\2\u0355\u0356"+
		"\5\u00dep\2\u0356\u0357\7\4\2\2\u0357\u0359\3\2\2\2\u0358\u0355\3\2\2"+
		"\2\u0358\u0359\3\2\2\2\u0359\u035a\3\2\2\2\u035a\u035b\5\u010a\u0086\2"+
		"\u035bE\3\2\2\2\u035c\u035d\b$\1\2\u035d\u0376\5`\61\2\u035e\u0376\7\u00bc"+
		"\2\2\u035f\u0376\5X-\2\u0360\u0361\5\u00d0i\2\u0361\u0362\5F$\17\u0362"+
		"\u0376\3\2\2\2\u0363\u0376\5H%\2\u0364\u0365\7-\2\2\u0365\u0366\7\5\2"+
		"\2\u0366\u0367\5F$\2\u0367\u0368\7#\2\2\u0368\u0369\5$\23\2\u0369\u036a"+
		"\7\6\2\2\u036a\u0376\3\2\2\2\u036b\u0376\5T+\2\u036c\u0376\5L\'\2\u036d"+
		"\u0376\5^\60\2\u036e\u0371\7\5\2\2\u036f\u0372\5F$\2\u0370\u0372\5~@\2"+
		"\u0371\u036f\3\2\2\2\u0371\u0370\3\2\2\2\u0372\u0373\3\2\2\2\u0373\u0374"+
		"\7\6\2\2\u0374\u0376\3\2\2\2\u0375\u035c\3\2\2\2\u0375\u035e\3\2\2\2\u0375"+
		"\u035f\3\2\2\2\u0375\u0360\3\2\2\2\u0375\u0363\3\2\2\2\u0375\u0364\3\2"+
		"\2\2\u0375\u036b\3\2\2\2\u0375\u036c\3\2\2\2\u0375\u036d\3\2\2\2\u0375"+
		"\u036e\3\2\2\2\u0376\u0397\3\2\2\2\u0377\u0378\f\16\2\2\u0378\u0379\5"+
		"Z.\2\u0379\u037a\5F$\17\u037a\u0396\3\2\2\2\u037b\u037d\f\5\2\2\u037c"+
		"\u037e\7h\2\2\u037d\u037c\3\2\2\2\u037d\u037e\3\2\2\2\u037e\u037f\3\2"+
		"\2\2\u037f\u0380\7)\2\2\u0380\u0381\5F$\2\u0381\u0382\7\"\2\2\u0382\u0383"+
		"\5F$\6\u0383\u0396\3\2\2\2\u0384\u0385\f\13\2\2\u0385\u0386\7/\2\2\u0386"+
		"\u0396\5\u00e8u\2\u0387\u0388\f\n\2\2\u0388\u0396\5V,\2\u0389\u038a\f"+
		"\t\2\2\u038a\u0396\5J&\2\u038b\u038d\f\4\2\2\u038c\u038e\7h\2\2\u038d"+
		"\u038c\3\2\2\2\u038d\u038e\3\2\2\2\u038e\u038f\3\2\2\2\u038f\u0390\5\\"+
		"/\2\u0390\u0393\5F$\2\u0391\u0392\7E\2\2\u0392\u0394\5F$\2\u0393\u0391"+
		"\3\2\2\2\u0393\u0394\3\2\2\2\u0394\u0396\3\2\2\2\u0395\u0377\3\2\2\2\u0395"+
		"\u037b\3\2\2\2\u0395\u0384\3\2\2\2\u0395\u0387\3\2\2\2\u0395\u0389\3\2"+
		"\2\2\u0395\u038b\3\2\2\2\u0396\u0399\3\2\2\2\u0397\u0395\3\2\2\2\u0397"+
		"\u0398\3\2\2\2\u0398G\3\2\2\2\u0399\u0397\3\2\2\2\u039a\u039b\5\u00dc"+
		"o\2\u039b\u03a1\7\5\2\2\u039c\u039e\7@\2\2\u039d\u039c\3\2\2\2\u039d\u039e"+
		"\3\2\2\2\u039e\u039f\3\2\2\2\u039f\u03a2\5~@\2\u03a0\u03a2\7\t\2\2\u03a1"+
		"\u039d\3\2\2\2\u03a1\u03a0\3\2\2\2\u03a1\u03a2\3\2\2\2\u03a2\u03a3\3\2"+
		"\2\2\u03a3\u03a5\7\6\2\2\u03a4\u03a6\5\u009cO\2\u03a5\u03a4\3\2\2\2\u03a5"+
		"\u03a6\3\2\2\2\u03a6\u03a8\3\2\2\2\u03a7\u03a9\5\u00a0Q\2\u03a8\u03a7"+
		"\3\2\2\2\u03a8\u03a9\3\2\2\2\u03a9I\3\2\2\2\u03aa\u03ac\7h\2\2\u03ab\u03aa"+
		"\3\2\2\2\u03ab\u03ac\3\2\2\2\u03ac\u03ad\3\2\2\2\u03ad\u03c6\7U\2\2\u03ae"+
		"\u03b1\7\5\2\2\u03af\u03b2\5l\67\2\u03b0\u03b2\5~@\2\u03b1\u03af\3\2\2"+
		"\2\u03b1\u03b0\3\2\2\2\u03b1\u03b2\3\2\2\2\u03b2\u03b3\3\2\2\2\u03b3\u03c7"+
		"\7\6\2\2\u03b4\u03b5\5\u00dep\2\u03b5\u03b6\7\4\2\2\u03b6\u03b8\3\2\2"+
		"\2\u03b7\u03b4\3\2\2\2\u03b7\u03b8\3\2\2\2\u03b8\u03b9\3\2\2\2\u03b9\u03c7"+
		"\5\u00e0q\2\u03ba\u03bb\5\u00dep\2\u03bb\u03bc\7\4\2\2\u03bc\u03be\3\2"+
		"\2\2\u03bd\u03ba\3\2\2\2\u03bd\u03be\3\2\2\2\u03be\u03bf\3\2\2\2\u03bf"+
		"\u03c0\5\u0108\u0085\2\u03c0\u03c2\7\5\2\2\u03c1\u03c3\5~@\2\u03c2\u03c1"+
		"\3\2\2\2\u03c2\u03c3\3\2\2\2\u03c3\u03c4\3\2\2\2\u03c4\u03c5\7\6\2\2\u03c5"+
		"\u03c7\3\2\2\2\u03c6\u03ae\3\2\2\2\u03c6\u03b7\3\2\2\2\u03c6\u03bd\3\2"+
		"\2\2\u03c7K\3\2\2\2\u03c8\u03ca\5P)\2\u03c9\u03cb\5N(\2\u03ca\u03c9\3"+
		"\2\2\2\u03cb\u03cc\3\2\2\2\u03cc\u03ca\3\2\2\2\u03cc\u03cd\3\2\2\2\u03cd"+
		"\u03cf\3\2\2\2\u03ce\u03d0\5R*\2\u03cf\u03ce\3\2\2\2\u03cf\u03d0\3\2\2"+
		"\2\u03d0\u03d1\3\2\2\2\u03d1\u03d2\7D\2\2\u03d2M\3\2\2\2\u03d3\u03d4\7"+
		"\u0094\2\2\u03d4\u03d5\5F$\2\u03d5\u03d6\7\u0088\2\2\u03d6\u03d7\5F$\2"+
		"\u03d7O\3\2\2\2\u03d8\u03da\7,\2\2\u03d9\u03db\5F$\2\u03da\u03d9\3\2\2"+
		"\2\u03da\u03db\3\2\2\2\u03dbQ\3\2\2\2\u03dc\u03dd\7C\2\2\u03dd\u03de\5"+
		"F$\2\u03deS\3\2\2\2\u03df\u03e1\7h\2\2\u03e0\u03df\3\2\2\2\u03e0\u03e1"+
		"\3\2\2\2\u03e1\u03e2\3\2\2\2\u03e2\u03e4\7H\2\2\u03e3\u03e0\3\2\2\2\u03e3"+
		"\u03e4\3\2\2\2\u03e4\u03e5\3\2\2\2\u03e5\u03e6\7\5\2\2\u03e6\u03e7\5l"+
		"\67\2\u03e7\u03e8\7\6\2\2\u03e8U\3\2\2\2\u03e9\u03ee\7_\2\2\u03ea\u03ee"+
		"\7i\2\2\u03eb\u03ec\7h\2\2\u03ec\u03ee\7j\2\2\u03ed\u03e9\3\2\2\2\u03ed"+
		"\u03ea\3\2\2\2\u03ed\u03eb\3\2\2\2\u03eeW\3\2\2\2\u03ef\u03f0\5\u00de"+
		"p\2\u03f0\u03f1\7\4\2\2\u03f1\u03f3\3\2\2\2\u03f2\u03ef\3\2\2\2\u03f2"+
		"\u03f3\3\2\2\2\u03f3\u03f4\3\2\2\2\u03f4\u03f5\5\u00e0q\2\u03f5\u03f6"+
		"\7\4\2\2\u03f6\u03f8\3\2\2\2\u03f7\u03f2\3\2\2\2\u03f7\u03f8\3\2\2\2\u03f8"+
		"\u03f9\3\2\2\2\u03f9\u03fa\5\u00e6t\2\u03faY\3\2\2\2\u03fb\u040d\7\r\2"+
		"\2\u03fc\u040d\t\f\2\2\u03fd\u040d\t\6\2\2\u03fe\u040d\t\r\2\2\u03ff\u040d"+
		"\t\16\2\2\u0400\u040d\7\b\2\2\u0401\u040d\7\30\2\2\u0402\u040d\7\31\2"+
		"\2\u0403\u040d\7\32\2\2\u0404\u040d\7U\2\2\u0405\u040d\7\"\2\2\u0406\u040d"+
		"\7n\2\2\u0407\u0409\7^\2\2\u0408\u040a\7h\2\2\u0409\u0408\3\2\2\2\u0409"+
		"\u040a\3\2\2\2\u040a\u040d\3\2\2\2\u040b\u040d\5\\/\2\u040c\u03fb\3\2"+
		"\2\2\u040c\u03fc\3\2\2\2\u040c\u03fd\3\2\2\2\u040c\u03fe\3\2\2\2\u040c"+
		"\u03ff\3\2\2\2\u040c\u0400\3\2\2\2\u040c\u0401\3\2\2\2\u040c\u0402\3\2"+
		"\2\2\u040c\u0403\3\2\2\2\u040c\u0404\3\2\2\2\u040c\u0405\3\2\2\2\u040c"+
		"\u0406\3\2\2\2\u040c\u0407\3\2\2\2\u040c\u040b\3\2\2\2\u040d[\3\2\2\2"+
		"\u040e\u040f\t\17\2\2\u040f]\3\2\2\2\u0410\u0411\7u\2\2\u0411\u0416\7"+
		"\5\2\2\u0412\u0417\7S\2\2\u0413\u0414\t\20\2\2\u0414\u0415\7\7\2\2\u0415"+
		"\u0417\5\u00d2j\2\u0416\u0412\3\2\2\2\u0416\u0413\3\2\2\2\u0417\u0418"+
		"\3\2\2\2\u0418\u0419\7\6\2\2\u0419_\3\2\2\2\u041a\u041b\t\21\2\2\u041b"+
		"a\3\2\2\2\u041c\u041e\5\66\34\2\u041d\u041c\3\2\2\2\u041d\u041e\3\2\2"+
		"\2\u041e\u0424\3\2\2\2\u041f\u0425\7Z\2\2\u0420\u0425\7|\2\2\u0421\u0422"+
		"\7Z\2\2\u0422\u0423\7n\2\2\u0423\u0425\t\n\2\2\u0424\u041f\3\2\2\2\u0424"+
		"\u0420\3\2\2\2\u0424\u0421\3\2\2\2\u0425\u0426\3\2\2\2\u0426\u042a\7]"+
		"\2\2\u0427\u0428\5\u00dep\2\u0428\u0429\7\4\2\2\u0429\u042b\3\2\2\2\u042a"+
		"\u0427\3\2\2\2\u042a\u042b\3\2\2\2\u042b\u042c\3\2\2\2\u042c\u042f\5\u00e0"+
		"q\2\u042d\u042e\7#\2\2\u042e\u0430\5\u00f8}\2\u042f\u042d\3\2\2\2\u042f"+
		"\u0430\3\2\2\2\u0430\u0432\3\2\2\2\u0431\u0433\5\u0094K\2\u0432\u0431"+
		"\3\2\2\2\u0432\u0433\3\2\2\2\u0433\u0437\3\2\2\2\u0434\u0435\7\u0091\2"+
		"\2\u0435\u0438\5v<\2\u0436\u0438\5l\67\2\u0437\u0434\3\2\2\2\u0437\u0436"+
		"\3\2\2\2\u0438\u043a\3\2\2\2\u0439\u043b\5d\63\2\u043a\u0439\3\2\2\2\u043a"+
		"\u043b\3\2\2\2\u043b\u043f\3\2\2\2\u043c\u043d\7:\2\2\u043d\u043f\7\u0091"+
		"\2\2\u043e\u041d\3\2\2\2\u043e\u043c\3\2\2\2\u043fc\3\2\2\2\u0440\u0441"+
		"\7m\2\2\u0441\u044f\7\62\2\2\u0442\u0443\7\5\2\2\u0443\u0448\5\36\20\2"+
		"\u0444\u0445\7\7\2\2\u0445\u0447\5\36\20\2\u0446\u0444\3\2\2\2\u0447\u044a"+
		"\3\2\2\2\u0448\u0446\3\2\2\2\u0448\u0449\3\2\2\2\u0449\u044b\3\2\2\2\u044a"+
		"\u0448\3\2\2\2\u044b\u044d\7\6\2\2\u044c\u044e\5\34\17\2\u044d\u044c\3"+
		"\2\2\2\u044d\u044e\3\2\2\2\u044e\u0450\3\2\2\2\u044f\u0442\3\2\2\2\u044f"+
		"\u0450\3\2\2\2\u0450\u0451\3\2\2\2\u0451\u046b\7\u00b8\2\2\u0452\u046c"+
		"\7\u00b9\2\2\u0453\u0454\7\u008e\2\2\u0454\u0457\7\u0084\2\2\u0455\u0458"+
		"\5\u00e6t\2\u0456\u0458\5\u0094K\2\u0457\u0455\3\2\2\2\u0457\u0456\3\2"+
		"\2\2\u0458\u0459\3\2\2\2\u0459\u045a\7\30\2\2\u045a\u0465\5F$\2\u045b"+
		"\u045e\7\7\2\2\u045c\u045f\5\u00e6t\2\u045d\u045f\5\u0094K\2\u045e\u045c"+
		"\3\2\2\2\u045e\u045d\3\2\2\2\u045f\u0460\3\2\2\2\u0460\u0461\7\30\2\2"+
		"\u0461\u0462\5F$\2\u0462\u0464\3\2\2\2\u0463\u045b\3\2\2\2\u0464\u0467"+
		"\3\2\2\2\u0465\u0463\3\2\2\2\u0465\u0466\3\2\2\2\u0466\u0469\3\2\2\2\u0467"+
		"\u0465\3\2\2\2\u0468\u046a\5\34\17\2\u0469\u0468\3\2\2\2\u0469\u046a\3"+
		"\2\2\2\u046a\u046c\3\2\2\2\u046b\u0452\3\2\2\2\u046b\u0453\3\2\2\2\u046c"+
		"e\3\2\2\2\u046d\u0471\7r\2\2\u046e\u046f\5\u00dep\2\u046f\u0470\7\4\2"+
		"\2\u0470\u0472\3\2\2\2\u0471\u046e\3\2\2\2\u0471\u0472\3\2\2\2\u0472\u0473"+
		"\3\2\2\2\u0473\u047a\5\u00f4{\2\u0474\u0475\7\b\2\2\u0475\u047b\5h\65"+
		"\2\u0476\u0477\7\5\2\2\u0477\u0478\5h\65\2\u0478\u0479\7\6\2\2\u0479\u047b"+
		"\3\2\2\2\u047a\u0474\3\2\2\2\u047a\u0476\3\2\2\2\u047a\u047b\3\2\2\2\u047b"+
		"g\3\2\2\2\u047c\u0480\5(\25\2\u047d\u0480\5\u00dan\2\u047e\u0480\7\u00bd"+
		"\2\2\u047f\u047c\3\2\2\2\u047f\u047d\3\2\2\2\u047f\u047e\3\2\2\2\u0480"+
		"i\3\2\2\2\u0481\u048c\7y\2\2\u0482\u048d\5\u00e8u\2\u0483\u0484\5\u00de"+
		"p\2\u0484\u0485\7\4\2\2\u0485\u0487\3\2\2\2\u0486\u0483\3\2\2\2\u0486"+
		"\u0487\3\2\2\2\u0487\u048a\3\2\2\2\u0488\u048b\5\u00e0q\2\u0489\u048b"+
		"\5\u00ecw\2\u048a\u0488\3\2\2\2\u048a\u0489\3\2\2\2\u048b\u048d\3\2\2"+
		"\2\u048c\u0482\3\2\2\2\u048c\u0486\3\2\2\2\u048c\u048d\3\2\2\2\u048dk"+
		"\3\2\2\2\u048e\u0490\5\u00acW\2\u048f\u048e\3\2\2\2\u048f\u0490\3\2\2"+
		"\2\u0490\u0491\3\2\2\2\u0491\u0495\5t;\2\u0492\u0494\5n8\2\u0493\u0492"+
		"\3\2\2\2\u0494\u0497\3\2\2\2\u0495\u0493\3\2\2\2\u0495\u0496\3\2\2\2\u0496"+
		"\u0499\3\2\2\2\u0497\u0495\3\2\2\2\u0498\u049a\5\u00aeX\2\u0499\u0498"+
		"\3\2\2\2\u0499\u049a\3\2\2\2\u049a\u049c\3\2\2\2\u049b\u049d\5\u00b0Y"+
		"\2\u049c\u049b\3\2\2\2\u049c\u049d\3\2\2\2\u049dm\3\2\2\2\u049e\u049f"+
		"\5\u0090I\2\u049f\u04a0\5t;\2\u04a0o\3\2\2\2\u04a1\u04a3\5\u0086D\2\u04a2"+
		"\u04a4\5r:\2\u04a3\u04a2\3\2\2\2\u04a4\u04a5\3\2\2\2\u04a5\u04a3\3\2\2"+
		"\2\u04a5\u04a6\3\2\2\2\u04a6q\3\2\2\2\u04a7\u04a8\5\u008cG\2\u04a8\u04aa"+
		"\5\u0086D\2\u04a9\u04ab\5\u008eH\2\u04aa\u04a9\3\2\2\2\u04aa\u04ab\3\2"+
		"\2\2\u04abs\3\2\2\2\u04ac\u04ae\7\u0083\2\2\u04ad\u04af\t\22\2\2\u04ae"+
		"\u04ad\3\2\2\2\u04ae\u04af\3\2\2\2\u04af\u04b0\3\2\2\2\u04b0\u04b5\5\u008a"+
		"F\2\u04b1\u04b2\7\7\2\2\u04b2\u04b4\5\u008aF\2\u04b3\u04b1\3\2\2\2\u04b4"+
		"\u04b7\3\2\2\2\u04b5\u04b3\3\2\2\2\u04b5\u04b6\3\2\2\2\u04b6\u04ba\3\2"+
		"\2\2\u04b7\u04b5\3\2\2\2\u04b8\u04b9\7M\2\2\u04b9\u04bb\5\u0088E\2\u04ba"+
		"\u04b8\3\2\2\2\u04ba\u04bb\3\2\2\2\u04bb\u04bd\3\2\2\2\u04bc\u04be\5\34"+
		"\17\2\u04bd\u04bc\3\2\2\2\u04bd\u04be\3\2\2\2\u04be\u04c0\3\2\2\2\u04bf"+
		"\u04c1\5x=\2\u04c0\u04bf\3\2\2\2\u04c0\u04c1\3\2\2\2\u04c1\u04cb\3\2\2"+
		"\2\u04c2\u04c3\7\u00af\2\2\u04c3\u04c8\5|?\2\u04c4\u04c5\7\7\2\2\u04c5"+
		"\u04c7\5|?\2\u04c6\u04c4\3\2\2\2\u04c7\u04ca\3\2\2\2\u04c8\u04c6\3\2\2"+
		"\2\u04c8\u04c9\3\2\2\2\u04c9\u04cc\3\2\2\2\u04ca\u04c8\3\2\2\2\u04cb\u04c2"+
		"\3\2\2\2\u04cb\u04cc\3\2\2\2\u04cc\u04d0\3\2\2\2\u04cd\u04ce\7\u0091\2"+
		"\2\u04ce\u04d0\5v<\2\u04cf\u04ac\3\2\2\2\u04cf\u04cd\3\2\2\2\u04d0u\3"+
		"\2\2\2\u04d1\u04d2\7\5\2\2\u04d2\u04d3\5~@\2\u04d3\u04db\7\6\2\2\u04d4"+
		"\u04d5\7\7\2\2\u04d5\u04d6\7\5\2\2\u04d6\u04d7\5~@\2\u04d7\u04d8\7\6\2"+
		"\2\u04d8\u04da\3\2\2\2\u04d9\u04d4\3\2\2\2\u04da\u04dd\3\2\2\2\u04db\u04d9"+
		"\3\2\2\2\u04db\u04dc\3\2\2\2\u04dcw\3\2\2\2\u04dd\u04db\3\2\2\2\u04de"+
		"\u04df\7P\2\2\u04df\u04e0\7*\2\2\u04e0\u04e2\5~@\2\u04e1\u04e3\5z>\2\u04e2"+
		"\u04e1\3\2\2\2\u04e2\u04e3\3\2\2\2\u04e3y\3\2\2\2\u04e4\u04e5\7Q\2\2\u04e5"+
		"\u04e6\5F$\2\u04e6{\3\2\2\2\u04e7\u04e8\5\u00fc\177\2\u04e8\u04e9\7#\2"+
		"\2\u04e9\u04ea\5\u009eP\2\u04ea}\3\2\2\2\u04eb\u04f0\5F$\2\u04ec\u04ed"+
		"\7\7\2\2\u04ed\u04ef\5F$\2\u04ee\u04ec\3\2\2\2\u04ef\u04f2\3\2\2\2\u04f0"+
		"\u04ee\3\2\2\2\u04f0\u04f1\3\2\2\2\u04f1\177\3\2\2\2\u04f2\u04f0\3\2\2"+
		"\2\u04f3\u04f4\5l\67\2\u04f4\u0081\3\2\2\2\u04f5\u04f7\5\u00acW\2\u04f6"+
		"\u04f5\3\2\2\2\u04f6\u04f7\3\2\2\2\u04f7\u04f8\3\2\2\2\u04f8\u04fa\5t"+
		";\2\u04f9\u04fb\5\u00aeX\2\u04fa\u04f9\3\2\2\2\u04fa\u04fb\3\2\2\2\u04fb"+
		"\u04fd\3\2\2\2\u04fc\u04fe\5\u00b0Y\2\u04fd\u04fc\3\2\2\2\u04fd\u04fe"+
		"\3\2\2\2\u04fe\u0083\3\2\2\2\u04ff\u0501\5\u00acW\2\u0500\u04ff\3\2\2"+
		"\2\u0500\u0501\3\2\2\2\u0501\u0502\3\2\2\2\u0502\u050c\5t;\2\u0503\u0505"+
		"\7\u008c\2\2\u0504\u0506\7\37\2\2\u0505\u0504\3\2\2\2\u0505\u0506\3\2"+
		"\2\2\u0506\u050a\3\2\2\2\u0507\u050a\7\\\2\2\u0508\u050a\7F\2\2\u0509"+
		"\u0503\3\2\2\2\u0509\u0507\3\2\2\2\u0509\u0508\3\2\2\2\u050a\u050b\3\2"+
		"\2\2\u050b\u050d\5t;\2\u050c\u0509\3\2\2\2\u050d\u050e\3\2\2\2\u050e\u050c"+
		"\3\2\2\2\u050e\u050f\3\2\2\2\u050f\u0511\3\2\2\2\u0510\u0512\5\u00aeX"+
		"\2\u0511\u0510\3\2\2\2\u0511\u0512\3\2\2\2\u0512\u0514\3\2\2\2\u0513\u0515"+
		"\5\u00b0Y\2\u0514\u0513\3\2\2\2\u0514\u0515\3\2\2\2\u0515\u0085\3\2\2"+
		"\2\u0516\u0517\5\u00dep\2\u0517\u0518\7\4\2\2\u0518\u051a\3\2\2\2\u0519"+
		"\u0516\3\2\2\2\u0519\u051a\3\2\2\2\u051a\u051b\3\2\2\2\u051b\u0520\5\u00e0"+
		"q\2\u051c\u051e\7#\2\2\u051d\u051c\3\2\2\2\u051d\u051e\3\2\2\2\u051e\u051f"+
		"\3\2\2\2\u051f\u0521\5\u00f8}\2\u0520\u051d\3\2\2\2\u0520\u0521\3\2\2"+
		"\2\u0521\u0527\3\2\2\2\u0522\u0523\7W\2\2\u0523\u0524\7*\2\2\u0524\u0528"+
		"\5\u00ecw\2\u0525\u0526\7h\2\2\u0526\u0528\7W\2\2\u0527\u0522\3\2\2\2"+
		"\u0527\u0525\3\2\2\2\u0527\u0528\3\2\2\2\u0528\u054d\3\2\2\2\u0529\u052a"+
		"\5\u00dep\2\u052a\u052b\7\4\2\2\u052b\u052d\3\2\2\2\u052c\u0529\3\2\2"+
		"\2\u052c\u052d\3\2\2\2\u052d\u052e\3\2\2\2\u052e\u052f\5\u0108\u0085\2"+
		"\u052f\u0530\7\5\2\2\u0530\u0535\5F$\2\u0531\u0532\7\7\2\2\u0532\u0534"+
		"\5F$\2\u0533\u0531\3\2\2\2\u0534\u0537\3\2\2\2\u0535\u0533\3\2\2\2\u0535"+
		"\u0536\3\2\2\2\u0536\u0538\3\2\2\2\u0537\u0535\3\2\2\2\u0538\u053d\7\6"+
		"\2\2\u0539\u053b\7#\2\2\u053a\u0539\3\2\2\2\u053a\u053b\3\2\2\2\u053b"+
		"\u053c\3\2\2\2\u053c\u053e\5\u00f8}\2\u053d\u053a\3\2\2\2\u053d\u053e"+
		"\3\2\2\2\u053e\u054d\3\2\2\2\u053f\u0540\7\5\2\2\u0540\u0541\5\u0088E"+
		"\2\u0541\u0542\7\6\2\2\u0542\u054d\3\2\2\2\u0543\u0544\7\5\2\2\u0544\u0545"+
		"\5l\67\2\u0545\u054a\7\6\2\2\u0546\u0548\7#\2\2\u0547\u0546\3\2\2\2\u0547"+
		"\u0548\3\2\2\2\u0548\u0549\3\2\2\2\u0549\u054b\5\u00f8}\2\u054a\u0547"+
		"\3\2\2\2\u054a\u054b\3\2\2\2\u054b\u054d\3\2\2\2\u054c\u0519\3\2\2\2\u054c"+
		"\u052c\3\2\2\2\u054c\u053f\3\2\2\2\u054c\u0543\3\2\2\2\u054d\u0087\3\2"+
		"\2\2\u054e\u0553\5\u0086D\2\u054f\u0550\7\7\2\2\u0550\u0552\5\u0086D\2"+
		"\u0551\u054f\3\2\2\2\u0552\u0555\3\2\2\2\u0553\u0551\3\2\2\2\u0553\u0554"+
		"\3\2\2\2\u0554\u0558\3\2\2\2\u0555\u0553\3\2\2\2\u0556\u0558\5p9\2\u0557"+
		"\u054e\3\2\2\2\u0557\u0556\3\2\2\2\u0558\u0089\3\2\2\2\u0559\u0566\7\t"+
		"\2\2\u055a\u055b\5\u00e0q\2\u055b\u055c\7\4\2\2\u055c\u055d\7\t\2\2\u055d"+
		"\u0566\3\2\2\2\u055e\u0563\5F$\2\u055f\u0561\7#\2\2\u0560\u055f\3\2\2"+
		"\2\u0560\u0561\3\2\2\2\u0561\u0562\3\2\2\2\u0562\u0564\5\u00d6l\2\u0563"+
		"\u0560\3\2\2\2\u0563\u0564\3\2\2\2\u0564\u0566\3\2\2\2\u0565\u0559\3\2"+
		"\2\2\u0565\u055a\3\2\2\2\u0565\u055e\3\2\2\2\u0566\u008b\3\2\2\2\u0567"+
		"\u0575\7\7\2\2\u0568\u056a\7f\2\2\u0569\u0568\3\2\2\2\u0569\u056a\3\2"+
		"\2\2\u056a\u0571\3\2\2\2\u056b\u056d\7b\2\2\u056c\u056e\7p\2\2\u056d\u056c"+
		"\3\2\2\2\u056d\u056e\3\2\2\2\u056e\u0572\3\2\2\2\u056f\u0572\7Y\2\2\u0570"+
		"\u0572\7\65\2\2\u0571\u056b\3\2\2\2\u0571\u056f\3\2\2\2\u0571\u0570\3"+
		"\2\2\2\u0571\u0572\3\2\2\2\u0572\u0573\3\2\2\2\u0573\u0575\7`\2\2\u0574"+
		"\u0567\3\2\2\2\u0574\u0569\3\2\2\2\u0575\u008d\3\2\2\2\u0576\u0577\7m"+
		"\2\2\u0577\u057b\5F$\2\u0578\u0579\7\u008f\2\2\u0579\u057b\5\u0094K\2"+
		"\u057a\u0576\3\2\2\2\u057a\u0578\3\2\2\2\u057b\u008f\3\2\2\2\u057c\u057e"+
		"\7\u008c\2\2\u057d\u057f\7\37\2\2\u057e\u057d\3\2\2\2\u057e\u057f\3\2"+
		"\2\2\u057f\u0583\3\2\2\2\u0580\u0583\7\\\2\2\u0581\u0583\7F\2\2\u0582"+
		"\u057c\3\2\2\2\u0582\u0580\3\2\2\2\u0582\u0581\3\2\2\2\u0583\u0091\3\2"+
		"\2\2\u0584\u0586\5\66\34\2\u0585\u0584\3\2\2\2\u0585\u0586\3\2\2\2\u0586"+
		"\u0587\3\2\2\2\u0587\u058a\7\u008e\2\2\u0588\u0589\7n\2\2\u0589\u058b"+
		"\t\n\2\2\u058a\u0588\3\2\2\2\u058a\u058b\3\2\2\2\u058b\u058c\3\2\2\2\u058c"+
		"\u058d\5\u0098M\2\u058d\u0590\7\u0084\2\2\u058e\u0591\5\u00e6t\2\u058f"+
		"\u0591\5\u0094K\2\u0590\u058e\3\2\2\2\u0590\u058f\3\2\2\2\u0591\u0592"+
		"\3\2\2\2\u0592\u0593\7\b\2\2\u0593\u059e\5F$\2\u0594\u0597\7\7\2\2\u0595"+
		"\u0598\5\u00e6t\2\u0596\u0598\5\u0094K\2\u0597\u0595\3\2\2\2\u0597\u0596"+
		"\3\2\2\2\u0598\u0599\3\2\2\2\u0599\u059a\7\b\2\2\u059a\u059b\5F$\2\u059b"+
		"\u059d\3\2\2\2\u059c\u0594\3\2\2\2\u059d\u05a0\3\2\2\2\u059e\u059c\3\2"+
		"\2\2\u059e\u059f\3\2\2\2\u059f\u05a2\3\2\2\2\u05a0\u059e\3\2\2\2\u05a1"+
		"\u05a3\5\34\17\2\u05a2\u05a1\3\2\2\2\u05a2\u05a3\3\2\2\2\u05a3\u0093\3"+
		"\2\2\2\u05a4\u05a5\7\5\2\2\u05a5\u05aa\5\u00e6t\2\u05a6\u05a7\7\7\2\2"+
		"\u05a7\u05a9\5\u00e6t\2\u05a8\u05a6\3\2\2\2\u05a9\u05ac\3\2\2\2\u05aa"+
		"\u05a8\3\2\2\2\u05aa\u05ab\3\2\2\2\u05ab\u05ad\3\2\2\2\u05ac\u05aa\3\2"+
		"\2\2\u05ad\u05ae\7\6\2\2\u05ae\u0095\3\2\2\2\u05af\u05b1\5\66\34\2\u05b0"+
		"\u05af\3\2\2\2\u05b0\u05b1\3\2\2\2\u05b1\u05b2\3\2\2\2\u05b2\u05b5\7\u008e"+
		"\2\2\u05b3\u05b4\7n\2\2\u05b4\u05b6\t\n\2\2\u05b5\u05b3\3\2\2\2\u05b5"+
		"\u05b6\3\2\2\2\u05b6\u05b7\3\2\2\2\u05b7\u05b8\5\u0098M\2\u05b8\u05bb"+
		"\7\u0084\2\2\u05b9\u05bc\5\u00e6t\2\u05ba\u05bc\5\u0094K\2\u05bb\u05b9"+
		"\3\2\2\2\u05bb\u05ba\3\2\2\2\u05bc\u05bd\3\2\2\2\u05bd\u05be\7\b\2\2\u05be"+
		"\u05c9\5F$\2\u05bf\u05c2\7\7\2\2\u05c0\u05c3\5\u00e6t\2\u05c1\u05c3\5"+
		"\u0094K\2\u05c2\u05c0\3\2\2\2\u05c2\u05c1\3\2\2\2\u05c3\u05c4\3\2\2\2"+
		"\u05c4\u05c5\7\b\2\2\u05c5\u05c6\5F$\2\u05c6\u05c8\3\2\2\2\u05c7\u05bf"+
		"\3\2\2\2\u05c8\u05cb\3\2\2\2\u05c9\u05c7\3\2\2\2\u05c9\u05ca\3\2\2\2\u05ca"+
		"\u05cd\3\2\2\2\u05cb\u05c9\3\2\2\2\u05cc\u05ce\5\34\17\2\u05cd\u05cc\3"+
		"\2\2\2\u05cd\u05ce\3\2\2\2\u05ce\u05d3\3\2\2\2\u05cf\u05d1\5\u00aeX\2"+
		"\u05d0\u05cf\3\2\2\2\u05d0\u05d1\3\2\2\2\u05d1\u05d2\3\2\2\2\u05d2\u05d4"+
		"\5\u00b0Y\2\u05d3\u05d0\3\2\2\2\u05d3\u05d4\3\2\2\2\u05d4\u0097\3\2\2"+
		"\2\u05d5\u05d6\5\u00dep\2\u05d6\u05d7\7\4\2\2\u05d7\u05d9\3\2\2\2\u05d8"+
		"\u05d5\3\2\2\2\u05d8\u05d9\3\2\2\2\u05d9\u05da\3\2\2\2\u05da\u05dd\5\u00e0"+
		"q\2\u05db\u05dc\7#\2\2\u05dc\u05de\5\u00fe\u0080\2\u05dd\u05db\3\2\2\2"+
		"\u05dd\u05de\3\2\2\2\u05de\u05e4\3\2\2\2\u05df\u05e0\7W\2\2\u05e0\u05e1"+
		"\7*\2\2\u05e1\u05e5\5\u00ecw\2\u05e2\u05e3\7h\2\2\u05e3\u05e5\7W\2\2\u05e4"+
		"\u05df\3\2\2\2\u05e4\u05e2\3\2\2\2\u05e4\u05e5\3\2\2\2\u05e5\u0099\3\2"+
		"\2\2\u05e6\u05e8\7\u0090\2\2\u05e7\u05e9\5\u00dep\2\u05e8\u05e7\3\2\2"+
		"\2\u05e8\u05e9\3\2\2\2\u05e9\u05ec\3\2\2\2\u05ea\u05eb\7]\2\2\u05eb\u05ed"+
		"\5\u0100\u0081\2\u05ec\u05ea\3\2\2\2\u05ec\u05ed\3\2\2\2\u05ed\u009b\3"+
		"\2\2\2\u05ee\u05ef\7\u00b3\2\2\u05ef\u05f0\7\5\2\2\u05f0\u05f1\7\u0095"+
		"\2\2\u05f1\u05f2\5F$\2\u05f2\u05f3\7\6\2\2\u05f3\u009d\3\2\2\2\u05f4\u05f6"+
		"\7\5\2\2\u05f5\u05f7\5\u0102\u0082\2\u05f6\u05f5\3\2\2\2\u05f6\u05f7\3"+
		"\2\2\2\u05f7\u05fb\3\2\2\2\u05f8\u05f9\7\u009a\2\2\u05f9\u05fa\7*\2\2"+
		"\u05fa\u05fc\5~@\2\u05fb\u05f8\3\2\2\2\u05fb\u05fc\3\2\2\2\u05fc\u05fd"+
		"\3\2\2\2\u05fd\u05fe\7o\2\2\u05fe\u05ff\7*\2\2\u05ff\u0604\5\u00b4[\2"+
		"\u0600\u0601\7\7\2\2\u0601\u0603\5\u00b4[\2\u0602\u0600\3\2\2\2\u0603"+
		"\u0606\3\2\2\2\u0604\u0602\3\2\2\2\u0604\u0605\3\2\2\2\u0605\u0608\3\2"+
		"\2\2\u0606\u0604\3\2\2\2\u0607\u0609\5\u00a2R\2\u0608\u0607\3\2\2\2\u0608"+
		"\u0609\3\2\2\2\u0609\u060a\3\2\2\2\u060a\u060b\7\6\2\2\u060b\u009f\3\2"+
		"\2\2\u060c\u0627\7\u0099\2\2\u060d\u0628\5\u00fc\177\2\u060e\u0610\7\5"+
		"\2\2\u060f\u0611\5\u0102\u0082\2\u0610\u060f\3\2\2\2\u0610\u0611\3\2\2"+
		"\2\u0611\u0615\3\2\2\2\u0612\u0613\7\u009a\2\2\u0613\u0614\7*\2\2\u0614"+
		"\u0616\5~@\2\u0615\u0612\3\2\2\2\u0615\u0616\3\2\2\2\u0616\u0621\3\2\2"+
		"\2\u0617\u0618\7o\2\2\u0618\u0619\7*\2\2\u0619\u061e\5\u00b4[\2\u061a"+
		"\u061b\7\7\2\2\u061b\u061d\5\u00b4[\2\u061c\u061a\3\2\2\2\u061d\u0620"+
		"\3\2\2\2\u061e\u061c\3\2\2\2\u061e\u061f\3\2\2\2\u061f\u0622\3\2\2\2\u0620"+
		"\u061e\3\2\2\2\u0621\u0617\3\2\2\2\u0621\u0622\3\2\2\2\u0622\u0624\3\2"+
		"\2\2\u0623\u0625\5\u00a2R\2\u0624\u0623\3\2\2\2\u0624\u0625\3\2\2\2\u0625"+
		"\u0626\3\2\2\2\u0626\u0628\7\6\2\2\u0627\u060d\3\2\2\2\u0627\u060e\3\2"+
		"\2\2\u0628\u00a1\3\2\2\2\u0629\u0631\5\u00a4S\2\u062a\u062b\7\u00b5\2"+
		"\2\u062b\u062c\7g\2\2\u062c\u0632\7\u00b7\2\2\u062d\u062e\7\u009e\2\2"+
		"\u062e\u0632\7\u0080\2\2\u062f\u0632\7P\2\2\u0630\u0632\7\u00b6\2\2\u0631"+
		"\u062a\3\2\2\2\u0631\u062d\3\2\2\2\u0631\u062f\3\2\2\2\u0631\u0630\3\2"+
		"\2\2\u0631\u0632\3\2\2\2\u0632\u00a3\3\2\2\2\u0633\u063a\t\23\2\2\u0634"+
		"\u063b\5\u00bc_\2\u0635\u0636\7)\2\2\u0636\u0637\5\u00b8]\2\u0637\u0638"+
		"\7\"\2\2\u0638\u0639\5\u00ba^\2\u0639\u063b\3\2\2\2\u063a\u0634\3\2\2"+
		"\2\u063a\u0635\3\2\2\2\u063b\u00a5\3\2\2\2\u063c\u063d\5\u0104\u0083\2"+
		"\u063d\u0640\7\5\2\2\u063e\u0641\5~@\2\u063f\u0641\7\t\2\2\u0640\u063e"+
		"\3\2\2\2\u0640\u063f\3\2\2\2\u0641\u0642\3\2\2\2\u0642\u0643\7\6\2\2\u0643"+
		"\u00a7\3\2\2\2\u0644\u0645\5\u0106\u0084\2\u0645\u064b\7\5\2\2\u0646\u0648"+
		"\7@\2\2\u0647\u0646\3\2\2\2\u0647\u0648\3\2\2\2\u0648\u0649\3\2\2\2\u0649"+
		"\u064c\5~@\2\u064a\u064c\7\t\2\2\u064b\u0647\3\2\2\2\u064b\u064a\3\2\2"+
		"\2\u064b\u064c\3\2\2\2\u064c\u064d\3\2\2\2\u064d\u064f\7\6\2\2\u064e\u0650"+
		"\5\u009cO\2\u064f\u064e\3\2\2\2\u064f\u0650\3\2\2\2\u0650\u00a9\3\2\2"+
		"\2\u0651\u0652\5\u00be`\2\u0652\u0655\7\5\2\2\u0653\u0656\5~@\2\u0654"+
		"\u0656\7\t\2\2\u0655\u0653\3\2\2\2\u0655\u0654\3\2\2\2\u0655\u0656\3\2"+
		"\2\2\u0656\u0657\3\2\2\2\u0657\u0659\7\6\2\2\u0658\u065a\5\u009cO\2\u0659"+
		"\u0658\3\2\2\2\u0659\u065a\3\2\2\2\u065a\u065b\3\2\2\2\u065b\u065e\7\u0099"+
		"\2\2\u065c\u065f\5\u009eP\2\u065d\u065f\5\u00fc\177\2\u065e\u065c\3\2"+
		"\2\2\u065e\u065d\3\2\2\2\u065f\u00ab\3\2\2\2\u0660\u0662\7\u0096\2\2\u0661"+
		"\u0663\7v\2\2\u0662\u0661\3\2\2\2\u0662\u0663\3\2\2\2\u0663\u0664\3\2"+
		"\2\2\u0664\u0669\5<\37\2\u0665\u0666\7\7\2\2\u0666\u0668\5<\37\2\u0667"+
		"\u0665\3\2\2\2\u0668\u066b\3\2\2\2\u0669\u0667\3\2\2\2\u0669\u066a\3\2"+
		"\2\2\u066a\u00ad\3\2\2\2\u066b\u0669\3\2\2\2\u066c\u066d\7o\2\2\u066d"+
		"\u066e\7*\2\2\u066e\u0673\5\u00b4[\2\u066f\u0670\7\7\2\2\u0670\u0672\5"+
		"\u00b4[\2\u0671\u066f\3\2\2\2\u0672\u0675\3\2\2\2\u0673\u0671\3\2\2\2"+
		"\u0673\u0674\3\2\2\2\u0674\u00af\3\2\2\2\u0675\u0673\3\2\2\2\u0676\u0677"+
		"\7d\2\2\u0677\u0679\5F$\2\u0678\u067a\5\u00b2Z\2\u0679\u0678\3\2\2\2\u0679"+
		"\u067a\3\2\2\2\u067a\u00b1\3\2\2\2\u067b\u067c\t\24\2\2\u067c\u067d\5"+
		"F$\2\u067d\u00b3\3\2\2\2\u067e\u0681\5F$\2\u067f\u0680\7/\2\2\u0680\u0682"+
		"\5\u00e8u\2\u0681\u067f\3\2\2\2\u0681\u0682\3\2\2\2\u0682\u0684\3\2\2"+
		"\2\u0683\u0685\5\u00b6\\\2\u0684\u0683\3\2\2\2\u0684\u0685\3\2\2\2\u0685"+
		"\u0688\3\2\2\2\u0686\u0687\7\u00b0\2\2\u0687\u0689\t\25\2\2\u0688\u0686"+
		"\3\2\2\2\u0688\u0689\3\2\2\2\u0689\u00b5\3\2\2\2\u068a\u068b\t\26\2\2"+
		"\u068b\u00b7\3\2\2\2\u068c\u068d\5F$\2\u068d\u068e\7\u009c\2\2\u068e\u0697"+
		"\3\2\2\2\u068f\u0690\5F$\2\u0690\u0691\7\u009f\2\2\u0691\u0697\3\2\2\2"+
		"\u0692\u0693\7\u009e\2\2\u0693\u0697\7\u0080\2\2\u0694\u0695\7\u009d\2"+
		"\2\u0695\u0697\7\u009c\2\2\u0696\u068c\3\2\2\2\u0696\u068f\3\2\2\2\u0696"+
		"\u0692\3\2\2\2\u0696\u0694\3\2\2\2\u0697\u00b9\3\2\2\2\u0698\u0699\5F"+
		"$\2\u0699\u069a\7\u009c\2\2\u069a\u06a3\3\2\2\2\u069b\u069c\5F$\2\u069c"+
		"\u069d\7\u009f\2\2\u069d\u06a3\3\2\2\2\u069e\u069f\7\u009e\2\2\u069f\u06a3"+
		"\7\u0080\2\2\u06a0\u06a1\7\u009d\2\2\u06a1\u06a3\7\u009f\2\2\u06a2\u0698"+
		"\3\2\2\2\u06a2\u069b\3\2\2\2\u06a2\u069e\3\2\2\2\u06a2\u06a0\3\2\2\2\u06a3"+
		"\u00bb\3\2\2\2\u06a4\u06a5\5F$\2\u06a5\u06a6\7\u009c\2\2\u06a6\u06ac\3"+
		"\2\2\2\u06a7\u06a8\7\u009d\2\2\u06a8\u06ac\7\u009c\2\2\u06a9\u06aa\7\u009e"+
		"\2\2\u06aa\u06ac\7\u0080\2\2\u06ab\u06a4\3\2\2\2\u06ab\u06a7\3\2\2\2\u06ab"+
		"\u06a9\3\2\2\2\u06ac\u00bd\3\2\2\2\u06ad\u06ae\t\27\2\2\u06ae\u06af\7"+
		"\5\2\2\u06af\u06b0\5F$\2\u06b0\u06b1\7\6\2\2\u06b1\u06b2\7\u0099\2\2\u06b2"+
		"\u06b4\7\5\2\2\u06b3\u06b5\5\u00c4c\2\u06b4\u06b3\3\2\2\2\u06b4\u06b5"+
		"\3\2\2\2\u06b5\u06b6\3\2\2\2\u06b6\u06b8\5\u00c8e\2\u06b7\u06b9\5\u00a4"+
		"S\2\u06b8\u06b7\3\2\2\2\u06b8\u06b9\3\2\2\2\u06b9\u06ba\3\2\2\2\u06ba"+
		"\u06bb\7\6\2\2\u06bb\u0703\3\2\2\2\u06bc\u06bd\t\30\2\2\u06bd\u06be\7"+
		"\5\2\2\u06be\u06bf\7\6\2\2\u06bf\u06c0\7\u0099\2\2\u06c0\u06c2\7\5\2\2"+
		"\u06c1\u06c3\5\u00c4c\2\u06c2\u06c1\3\2\2\2\u06c2\u06c3\3\2\2\2\u06c3"+
		"\u06c5\3\2\2\2\u06c4\u06c6\5\u00c6d\2\u06c5\u06c4\3\2\2\2\u06c5\u06c6"+
		"\3\2\2\2\u06c6\u06c7\3\2\2\2\u06c7\u0703\7\6\2\2\u06c8\u06c9\t\31\2\2"+
		"\u06c9\u06ca\7\5\2\2\u06ca\u06cb\7\6\2\2\u06cb\u06cc\7\u0099\2\2\u06cc"+
		"\u06ce\7\5\2\2\u06cd\u06cf\5\u00c4c\2\u06ce\u06cd\3\2\2\2\u06ce\u06cf"+
		"\3\2\2\2\u06cf\u06d0\3\2\2\2\u06d0\u06d1\5\u00c8e\2\u06d1\u06d2\7\6\2"+
		"\2\u06d2\u0703\3\2\2\2\u06d3\u06d4\t\32\2\2\u06d4\u06d5\7\5\2\2\u06d5"+
		"\u06d7\5F$\2\u06d6\u06d8\5\u00c0a\2\u06d7\u06d6\3\2\2\2\u06d7\u06d8\3"+
		"\2\2\2\u06d8\u06da\3\2\2\2\u06d9\u06db\5\u00c2b\2\u06da\u06d9\3\2\2\2"+
		"\u06da\u06db\3\2\2\2\u06db\u06dc\3\2\2\2\u06dc\u06dd\7\6\2\2\u06dd\u06de"+
		"\7\u0099\2\2\u06de\u06e0\7\5\2\2\u06df\u06e1\5\u00c4c\2\u06e0\u06df\3"+
		"\2\2\2\u06e0\u06e1\3\2\2\2\u06e1\u06e2\3\2\2\2\u06e2\u06e3\5\u00c8e\2"+
		"\u06e3\u06e4\7\6\2\2\u06e4\u0703\3\2\2\2\u06e5\u06e6\7\u00a5\2\2\u06e6"+
		"\u06e7\7\5\2\2\u06e7\u06e8\5F$\2\u06e8\u06e9\7\7\2\2\u06e9\u06ea\5(\25"+
		"\2\u06ea\u06eb\7\6\2\2\u06eb\u06ec\7\u0099\2\2\u06ec\u06ee\7\5\2\2\u06ed"+
		"\u06ef\5\u00c4c\2\u06ee\u06ed\3\2\2\2\u06ee\u06ef\3\2\2\2\u06ef\u06f0"+
		"\3\2\2\2\u06f0\u06f2\5\u00c8e\2\u06f1\u06f3\5\u00a4S\2\u06f2\u06f1\3\2"+
		"\2\2\u06f2\u06f3\3\2\2\2\u06f3\u06f4\3\2\2\2\u06f4\u06f5\7\6\2\2\u06f5"+
		"\u0703\3\2\2\2\u06f6\u06f7\7\u00a6\2\2\u06f7\u06f8\7\5\2\2\u06f8\u06f9"+
		"\5F$\2\u06f9\u06fa\7\6\2\2\u06fa\u06fb\7\u0099\2\2\u06fb\u06fd\7\5\2\2"+
		"\u06fc\u06fe\5\u00c4c\2\u06fd\u06fc\3\2\2\2\u06fd\u06fe\3\2\2\2\u06fe"+
		"\u06ff\3\2\2\2\u06ff\u0700\5\u00c8e\2\u0700\u0701\7\6\2\2\u0701\u0703"+
		"\3\2\2\2\u0702\u06ad\3\2\2\2\u0702\u06bc\3\2\2\2\u0702\u06c8\3\2\2\2\u0702"+
		"\u06d3\3\2\2\2\u0702\u06e5\3\2\2\2\u0702\u06f6\3\2\2\2\u0703\u00bf\3\2"+
		"\2\2\u0704\u0705\7\7\2\2\u0705\u0706\5(\25\2\u0706\u00c1\3\2\2\2\u0707"+
		"\u0708\7\7\2\2\u0708\u0709\5(\25\2\u0709\u00c3\3\2\2\2\u070a\u070b\7\u009a"+
		"\2\2\u070b\u070d\7*\2\2\u070c\u070e\5F$\2\u070d\u070c\3\2\2\2\u070e\u070f"+
		"\3\2\2\2\u070f\u070d\3\2\2\2\u070f\u0710\3\2\2\2\u0710\u00c5\3\2\2\2\u0711"+
		"\u0712\7o\2\2\u0712\u0714\7*\2\2\u0713\u0715\5F$\2\u0714\u0713\3\2\2\2"+
		"\u0715\u0716\3\2\2\2\u0716\u0714\3\2\2\2\u0716\u0717\3\2\2\2\u0717\u00c7"+
		"\3\2\2\2\u0718\u0719\7o\2\2\u0719\u071a\7*\2\2\u071a\u071b\5\u00c8e\2"+
		"\u071b\u00c9\3\2\2\2\u071c\u071e\5F$\2\u071d\u071f\5\u00b6\\\2\u071e\u071d"+
		"\3\2\2\2\u071e\u071f\3\2\2\2\u071f\u0727\3\2\2\2\u0720\u0721\7\7\2\2\u0721"+
		"\u0723\5F$\2\u0722\u0724\5\u00b6\\\2\u0723\u0722\3\2\2\2\u0723\u0724\3"+
		"\2\2\2\u0724\u0726\3\2\2\2\u0725\u0720\3\2\2\2\u0726\u0729\3\2\2\2\u0727"+
		"\u0725\3\2\2\2\u0727\u0728\3\2\2\2\u0728\u00cb\3\2\2\2\u0729\u0727\3\2"+
		"\2\2\u072a\u072b\5l\67\2\u072b\u00cd\3\2\2\2\u072c\u072d\5l\67\2\u072d"+
		"\u00cf\3\2\2\2\u072e\u072f\t\33\2\2\u072f\u00d1\3\2\2\2\u0730\u0731\7"+
		"\u00bd\2\2\u0731\u00d3\3\2\2\2\u0732\u0735\5F$\2\u0733\u0735\5\"\22\2"+
		"\u0734\u0732\3\2\2\2\u0734\u0733\3\2\2\2\u0735\u00d5\3\2\2\2\u0736\u0737"+
		"\t\34\2\2\u0737\u00d7\3\2\2\2\u0738\u0739\t\35\2\2\u0739\u00d9\3\2\2\2"+
		"\u073a\u073b\5\u010a\u0086\2\u073b\u00db\3\2\2\2\u073c\u073d\5\u010a\u0086"+
		"\2\u073d\u00dd\3\2\2\2\u073e\u073f\5\u010a\u0086\2\u073f\u00df\3\2\2\2"+
		"\u0740\u0741\5\u010a\u0086\2\u0741\u00e1\3\2\2\2\u0742\u0743\5\u010a\u0086"+
		"\2\u0743\u00e3\3\2\2\2\u0744\u0745\5\u010a\u0086\2\u0745\u00e5\3\2\2\2"+
		"\u0746\u0747\5\u010a\u0086\2\u0747\u00e7\3\2\2\2\u0748\u0749\5\u010a\u0086"+
		"\2\u0749\u00e9\3\2\2\2\u074a\u074b\5\u010a\u0086\2\u074b\u00eb\3\2\2\2"+
		"\u074c\u074d\5\u010a\u0086\2\u074d\u00ed\3\2\2\2\u074e\u074f\5\u010a\u0086"+
		"\2\u074f\u00ef\3\2\2\2\u0750\u0751\5\u010a\u0086\2\u0751\u00f1\3\2\2\2"+
		"\u0752\u0753\5\u010a\u0086\2\u0753\u00f3\3\2\2\2\u0754\u0755\5\u010a\u0086"+
		"\2\u0755\u00f5\3\2\2\2\u0756\u0757\5\u010a\u0086\2\u0757\u00f7\3\2\2\2"+
		"\u0758\u0759\5\u010a\u0086\2\u0759\u00f9\3\2\2\2\u075a\u075b\5\u010a\u0086"+
		"\2\u075b\u00fb\3\2\2\2\u075c\u075d\5\u010a\u0086\2\u075d\u00fd\3\2\2\2"+
		"\u075e\u075f\5\u010a\u0086\2\u075f\u00ff\3\2\2\2\u0760\u0761\5\u010a\u0086"+
		"\2\u0761\u0101\3\2\2\2\u0762\u0763\5\u010a\u0086\2\u0763\u0103\3\2\2\2"+
		"\u0764\u0765\5\u010a\u0086\2\u0765\u0105\3\2\2\2\u0766\u0767\5\u010a\u0086"+
		"\2\u0767\u0107\3\2\2\2\u0768\u0769\5\u010a\u0086\2\u0769\u0109\3\2\2\2"+
		"\u076a\u0772\7\u00ba\2\2\u076b\u0772\5\u00d8m\2\u076c\u0772\7\u00bd\2"+
		"\2\u076d\u076e\7\5\2\2\u076e\u076f\5\u010a\u0086\2\u076f\u0770\7\6\2\2"+
		"\u0770\u0772\3\2\2\2\u0771\u076a\3\2\2\2\u0771\u076b\3\2\2\2\u0771\u076c"+
		"\3\2\2\2\u0771\u076d\3\2\2\2\u0772\u010b\3\2\2\2\u010d\u010e\u0110\u011b"+
		"\u0122\u0127\u012d\u0133\u0135\u014f\u0156\u015d\u0163\u0167\u016a\u0171"+
		"\u0174\u0178\u0180\u0184\u0186\u018a\u018e\u0192\u0195\u019c\u01a2\u01a8"+
		"\u01ad\u01b8\u01bd\u01c4\u01c8\u01cb\u01cf\u01d5\u01da\u01e3\u01ea\u01f0"+
		"\u01f4\u01f8\u01fd\u0203\u020f\u0213\u0218\u021b\u021e\u0223\u0226\u0234"+
		"\u023b\u0242\u0244\u0247\u024d\u0252\u025a\u025f\u026b\u0270\u027a\u027e"+
		"\u0280\u0284\u0289\u028b\u0293\u0299\u029e\u02a5\u02b0\u02b3\u02b5\u02bc"+
		"\u02c0\u02c7\u02cd\u02d3\u02d9\u02de\u02e2\u02ed\u02f2\u02fd\u0302\u0306"+
		"\u0316\u031b\u0323\u032a\u0332\u0338\u033b\u0341\u0344\u0347\u034b\u0353"+
		"\u0358\u0371\u0375\u037d\u038d\u0393\u0395\u0397\u039d\u03a1\u03a5\u03a8"+
		"\u03ab\u03b1\u03b7\u03bd\u03c2\u03c6\u03cc\u03cf\u03da\u03e0\u03e3\u03ed"+
		"\u03f2\u03f7\u0409\u040c\u0416\u041d\u0424\u042a\u042f\u0432\u0437\u043a"+
		"\u043e\u0448\u044d\u044f\u0457\u045e\u0465\u0469\u046b\u0471\u047a\u047f"+
		"\u0486\u048a\u048c\u048f\u0495\u0499\u049c\u04a5\u04aa\u04ae\u04b5\u04ba"+
		"\u04bd\u04c0\u04c8\u04cb\u04cf\u04db\u04e2\u04f0\u04f6\u04fa\u04fd\u0500"+
		"\u0505\u0509\u050e\u0511\u0514\u0519\u051d\u0520\u0527\u052c\u0535\u053a"+
		"\u053d\u0547\u054a\u054c\u0553\u0557\u0560\u0563\u0565\u0569\u056d\u0571"+
		"\u0574\u057a\u057e\u0582\u0585\u058a\u0590\u0597\u059e\u05a2\u05aa\u05b0"+
		"\u05b5\u05bb\u05c2\u05c9\u05cd\u05d0\u05d3\u05d8\u05dd\u05e4\u05e8\u05ec"+
		"\u05f6\u05fb\u0604\u0608\u0610\u0615\u061e\u0621\u0624\u0627\u0631\u063a"+
		"\u0640\u0647\u064b\u064f\u0655\u0659\u065e\u0662\u0669\u0673\u0679\u0681"+
		"\u0684\u0688\u0696\u06a2\u06ab\u06b4\u06b8\u06c2\u06c5\u06ce\u06d7\u06da"+
		"\u06e0\u06ee\u06f2\u06fd\u0702\u070f\u0716\u071e\u0723\u0727\u0734\u0771";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}