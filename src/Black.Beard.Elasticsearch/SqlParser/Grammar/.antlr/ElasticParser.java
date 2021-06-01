// Generated from c:\Users\g.beard\source\repos\TestQueryElastic\TestQueryElastic\SqlParser\Grammar\ElasticParser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ElasticParser extends Parser {
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
		RULE_where_stmt = 4, RULE_indexed_column = 5, RULE_create_table_stmt = 6, 
		RULE_column_def = 7, RULE_type_name = 8, RULE_column_constraint = 9, RULE_signed_number = 10, 
		RULE_table_constraint = 11, RULE_foreign_key_clause = 12, RULE_conflict_clause = 13, 
		RULE_create_view_stmt = 14, RULE_create_virtual_table_stmt = 15, RULE_with_clause = 16, 
		RULE_cte_table_name = 17, RULE_recursive_cte = 18, RULE_common_table_expression = 19, 
		RULE_expr = 20, RULE_call_function_expr = 21, RULE_in_expr = 22, RULE_case_expression = 23, 
		RULE_case_when = 24, RULE_case_expr = 25, RULE_case_else_expr = 26, RULE_exists_expr = 27, 
		RULE_nullable_expr = 28, RULE_fullname = 29, RULE_binary_operator = 30, 
		RULE_like_operator = 31, RULE_raise_function = 32, RULE_literal_value = 33, 
		RULE_insert_stmt = 34, RULE_upsert_clause = 35, RULE_select_stmt = 36, 
		RULE_compound = 37, RULE_join_clauses = 38, RULE_join_clause = 39, RULE_select_core = 40, 
		RULE_value_list_stmt = 41, RULE_group_by_stmt = 42, RULE_having_stmt = 43, 
		RULE_window_stmt = 44, RULE_expr_list = 45, RULE_table_or_subquery = 46, 
		RULE_subquery_table = 47, RULE_result_column = 48, RULE_join_operator = 49, 
		RULE_join_constraint = 50, RULE_compound_operator = 51, RULE_column_name_list = 52, 
		RULE_filter_clause = 53, RULE_window_defn = 54, RULE_over_clause = 55, 
		RULE_frame_spec = 56, RULE_frame_clause = 57, RULE_common_table_stmt = 58, 
		RULE_order_by_stmt = 59, RULE_limit_stmts = 60, RULE_limit_stmt = 61, 
		RULE_ordering_term = 62, RULE_asc_desc = 63, RULE_frame_left = 64, RULE_frame_right = 65, 
		RULE_frame_single = 66, RULE_window_function = 67, RULE_offset = 68, RULE_default_value = 69, 
		RULE_partition_by = 70, RULE_order_by_expr = 71, RULE_order_by_expr_asc_desc = 72, 
		RULE_initial_select = 73, RULE_recursive_select = 74, RULE_unary_operator = 75, 
		RULE_error_message = 76, RULE_module_argument = 77, RULE_column_alias = 78, 
		RULE_keyword = 79, RULE_name = 80, RULE_function_name = 81, RULE_schema_name = 82, 
		RULE_table_name = 83, RULE_column_name = 84, RULE_collation_name = 85, 
		RULE_foreign_table = 86, RULE_index_name = 87, RULE_view_name = 88, RULE_module_name = 89, 
		RULE_table_alias = 90, RULE_window_name = 91, RULE_alias = 92, RULE_base_window_name = 93, 
		RULE_simple_func = 94, RULE_aggregate_func = 95, RULE_table_function_name = 96, 
		RULE_any_name = 97;
	private static String[] makeRuleNames() {
		return new String[] {
			"parse", "error", "sql_stmt_list", "sql_stmt", "where_stmt", "indexed_column", 
			"create_table_stmt", "column_def", "type_name", "column_constraint", 
			"signed_number", "table_constraint", "foreign_key_clause", "conflict_clause", 
			"create_view_stmt", "create_virtual_table_stmt", "with_clause", "cte_table_name", 
			"recursive_cte", "common_table_expression", "expr", "call_function_expr", 
			"in_expr", "case_expression", "case_when", "case_expr", "case_else_expr", 
			"exists_expr", "nullable_expr", "fullname", "binary_operator", "like_operator", 
			"raise_function", "literal_value", "insert_stmt", "upsert_clause", "select_stmt", 
			"compound", "join_clauses", "join_clause", "select_core", "value_list_stmt", 
			"group_by_stmt", "having_stmt", "window_stmt", "expr_list", "table_or_subquery", 
			"subquery_table", "result_column", "join_operator", "join_constraint", 
			"compound_operator", "column_name_list", "filter_clause", "window_defn", 
			"over_clause", "frame_spec", "frame_clause", "common_table_stmt", "order_by_stmt", 
			"limit_stmts", "limit_stmt", "ordering_term", "asc_desc", "frame_left", 
			"frame_right", "frame_single", "window_function", "offset", "default_value", 
			"partition_by", "order_by_expr", "order_by_expr_asc_desc", "initial_select", 
			"recursive_select", "unary_operator", "error_message", "module_argument", 
			"column_alias", "keyword", "name", "function_name", "schema_name", "table_name", 
			"column_name", "collation_name", "foreign_table", "index_name", "view_name", 
			"module_name", "table_alias", "window_name", "alias", "base_window_name", 
			"simple_func", "aggregate_func", "table_function_name", "any_name"
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
	public String getGrammarFileName() { return "ElasticParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public ElasticParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ParseContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(ElasticParser.EOF, 0); }
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
			setState(200);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << SCOL) | (1L << CREATE) | (1L << DEFAULT))) != 0) || ((((_la - 71)) & ~0x3f) == 0 && ((1L << (_la - 71)) & ((1L << (EXPLAIN - 71)) | (1L << (INSERT - 71)) | (1L << (REPLACE - 71)) | (1L << (SELECT - 71)))) != 0) || ((((_la - 143)) & ~0x3f) == 0 && ((1L << (_la - 143)) & ((1L << (VALUES - 143)) | (1L << (WITH - 143)) | (1L << (UNEXPECTED_CHAR - 143)))) != 0)) {
				{
				setState(198);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case SCOL:
				case CREATE:
				case DEFAULT:
				case EXPLAIN:
				case INSERT:
				case REPLACE:
				case SELECT:
				case VALUES:
				case WITH:
					{
					setState(196);
					sql_stmt_list();
					}
					break;
				case UNEXPECTED_CHAR:
					{
					setState(197);
					error();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(202);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(203);
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
		public TerminalNode UNEXPECTED_CHAR() { return getToken(ElasticParser.UNEXPECTED_CHAR, 0); }
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
			setState(205);
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
		public List<TerminalNode> SCOL() { return getTokens(ElasticParser.SCOL); }
		public TerminalNode SCOL(int i) {
			return getToken(ElasticParser.SCOL, i);
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
			setState(211);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SCOL) {
				{
				{
				setState(208);
				match(SCOL);
				}
				}
				setState(213);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(214);
			sql_stmt();
			setState(223);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(216); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(215);
						match(SCOL);
						}
						}
						setState(218); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( _la==SCOL );
					setState(220);
					sql_stmt();
					}
					} 
				}
				setState(225);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			}
			setState(229);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(226);
					match(SCOL);
					}
					} 
				}
				setState(231);
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
		public Create_table_stmtContext create_table_stmt() {
			return getRuleContext(Create_table_stmtContext.class,0);
		}
		public Create_view_stmtContext create_view_stmt() {
			return getRuleContext(Create_view_stmtContext.class,0);
		}
		public Create_virtual_table_stmtContext create_virtual_table_stmt() {
			return getRuleContext(Create_virtual_table_stmtContext.class,0);
		}
		public Insert_stmtContext insert_stmt() {
			return getRuleContext(Insert_stmtContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode EXPLAIN() { return getToken(ElasticParser.EXPLAIN, 0); }
		public TerminalNode QUERY() { return getToken(ElasticParser.QUERY, 0); }
		public TerminalNode PLAN() { return getToken(ElasticParser.PLAN, 0); }
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
			setState(237);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXPLAIN) {
				{
				setState(232);
				match(EXPLAIN);
				setState(235);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==QUERY) {
					{
					setState(233);
					match(QUERY);
					setState(234);
					match(PLAN);
					}
				}

				}
			}

			setState(244);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(239);
				create_table_stmt();
				}
				break;
			case 2:
				{
				setState(240);
				create_view_stmt();
				}
				break;
			case 3:
				{
				setState(241);
				create_virtual_table_stmt();
				}
				break;
			case 4:
				{
				setState(242);
				insert_stmt();
				}
				break;
			case 5:
				{
				setState(243);
				select_stmt();
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

	public static class Where_stmtContext extends ParserRuleContext {
		public TerminalNode WHERE() { return getToken(ElasticParser.WHERE, 0); }
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
		enterRule(_localctx, 8, RULE_where_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(246);
			match(WHERE);
			setState(247);
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
		public TerminalNode COLLATE() { return getToken(ElasticParser.COLLATE, 0); }
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
		enterRule(_localctx, 10, RULE_indexed_column);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(251);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				setState(249);
				column_name();
				}
				break;
			case 2:
				{
				setState(250);
				expr(0);
				}
				break;
			}
			setState(255);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLLATE) {
				{
				setState(253);
				match(COLLATE);
				setState(254);
				collation_name();
				}
			}

			setState(258);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(257);
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
		public TerminalNode CREATE() { return getToken(ElasticParser.CREATE, 0); }
		public TerminalNode TABLE() { return getToken(ElasticParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode IF() { return getToken(ElasticParser.IF, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(ElasticParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(ElasticParser.DOT, 0); }
		public TerminalNode TEMP() { return getToken(ElasticParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(ElasticParser.TEMPORARY, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public List<Column_defContext> column_def() {
			return getRuleContexts(Column_defContext.class);
		}
		public Column_defContext column_def(int i) {
			return getRuleContext(Column_defContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public List<Table_constraintContext> table_constraint() {
			return getRuleContexts(Table_constraintContext.class);
		}
		public Table_constraintContext table_constraint(int i) {
			return getRuleContext(Table_constraintContext.class,i);
		}
		public TerminalNode WITHOUT() { return getToken(ElasticParser.WITHOUT, 0); }
		public TerminalNode IDENTIFIER() { return getToken(ElasticParser.IDENTIFIER, 0); }
		public Create_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_table_stmt; }
	}

	public final Create_table_stmtContext create_table_stmt() throws RecognitionException {
		Create_table_stmtContext _localctx = new Create_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_create_table_stmt);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(260);
			match(CREATE);
			setState(262);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(261);
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

			setState(264);
			match(TABLE);
			setState(268);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				{
				setState(265);
				match(IF);
				setState(266);
				match(NOT);
				setState(267);
				match(EXISTS);
				}
				break;
			}
			setState(273);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(270);
				schema_name();
				setState(271);
				match(DOT);
				}
				break;
			}
			setState(275);
			table_name();
			setState(299);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN_PAR:
				{
				{
				setState(276);
				match(OPEN_PAR);
				setState(277);
				column_def();
				setState(282);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,15,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(278);
						match(COMMA);
						setState(279);
						column_def();
						}
						} 
					}
					setState(284);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,15,_ctx);
				}
				setState(289);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(285);
					match(COMMA);
					setState(286);
					table_constraint();
					}
					}
					setState(291);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(292);
				match(CLOSE_PAR);
				setState(295);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WITHOUT) {
					{
					setState(293);
					match(WITHOUT);
					setState(294);
					((Create_table_stmtContext)_localctx).rowID = match(IDENTIFIER);
					}
				}

				}
				}
				break;
			case AS:
				{
				{
				setState(297);
				match(AS);
				setState(298);
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
		enterRule(_localctx, 14, RULE_column_def);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(301);
			column_name();
			setState(303);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				{
				setState(302);
				type_name();
				}
				break;
			}
			setState(308);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << AS) | (1L << CHECK) | (1L << COLLATE) | (1L << CONSTRAINT) | (1L << DEFAULT))) != 0) || ((((_la - 102)) & ~0x3f) == 0 && ((1L << (_la - 102)) & ((1L << (NOT - 102)) | (1L << (PRIMARY - 102)) | (1L << (REFERENCES - 102)) | (1L << (UNIQUE - 102)))) != 0) || _la==GENERATED) {
				{
				{
				setState(305);
				column_constraint();
				}
				}
				setState(310);
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

	public static class Type_nameContext extends ParserRuleContext {
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public List<Signed_numberContext> signed_number() {
			return getRuleContexts(Signed_numberContext.class);
		}
		public Signed_numberContext signed_number(int i) {
			return getRuleContext(Signed_numberContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode COMMA() { return getToken(ElasticParser.COMMA, 0); }
		public Type_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type_name; }
	}

	public final Type_nameContext type_name() throws RecognitionException {
		Type_nameContext _localctx = new Type_nameContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_type_name);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(312); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(311);
					name();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(314); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(326);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,22,_ctx) ) {
			case 1:
				{
				setState(316);
				match(OPEN_PAR);
				setState(317);
				signed_number();
				setState(318);
				match(CLOSE_PAR);
				}
				break;
			case 2:
				{
				setState(320);
				match(OPEN_PAR);
				setState(321);
				signed_number();
				setState(322);
				match(COMMA);
				setState(323);
				signed_number();
				setState(324);
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
		public TerminalNode CHECK() { return getToken(ElasticParser.CHECK, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode DEFAULT() { return getToken(ElasticParser.DEFAULT, 0); }
		public TerminalNode COLLATE() { return getToken(ElasticParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Foreign_key_clauseContext foreign_key_clause() {
			return getRuleContext(Foreign_key_clauseContext.class,0);
		}
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public TerminalNode CONSTRAINT() { return getToken(ElasticParser.CONSTRAINT, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode PRIMARY() { return getToken(ElasticParser.PRIMARY, 0); }
		public TerminalNode KEY() { return getToken(ElasticParser.KEY, 0); }
		public TerminalNode UNIQUE() { return getToken(ElasticParser.UNIQUE, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public Conflict_clauseContext conflict_clause() {
			return getRuleContext(Conflict_clauseContext.class,0);
		}
		public TerminalNode GENERATED() { return getToken(ElasticParser.GENERATED, 0); }
		public TerminalNode ALWAYS() { return getToken(ElasticParser.ALWAYS, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode NULL_() { return getToken(ElasticParser.NULL_, 0); }
		public TerminalNode STORED() { return getToken(ElasticParser.STORED, 0); }
		public TerminalNode VIRTUAL() { return getToken(ElasticParser.VIRTUAL, 0); }
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public TerminalNode AUTOINCREMENT() { return getToken(ElasticParser.AUTOINCREMENT, 0); }
		public Column_constraintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_constraint; }
	}

	public final Column_constraintContext column_constraint() throws RecognitionException {
		Column_constraintContext _localctx = new Column_constraintContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_column_constraint);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(330);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CONSTRAINT) {
				{
				setState(328);
				match(CONSTRAINT);
				setState(329);
				name();
				}
			}

			setState(379);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PRIMARY:
				{
				{
				setState(332);
				match(PRIMARY);
				setState(333);
				match(KEY);
				setState(335);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ASC || _la==DESC) {
					{
					setState(334);
					asc_desc();
					}
				}

				setState(338);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(337);
					conflict_clause();
					}
				}

				setState(341);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AUTOINCREMENT) {
					{
					setState(340);
					match(AUTOINCREMENT);
					}
				}

				}
				}
				break;
			case NOT:
			case UNIQUE:
				{
				setState(346);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case NOT:
					{
					{
					setState(343);
					match(NOT);
					setState(344);
					match(NULL_);
					}
					}
					break;
				case UNIQUE:
					{
					setState(345);
					match(UNIQUE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(349);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(348);
					conflict_clause();
					}
				}

				}
				break;
			case CHECK:
				{
				setState(351);
				match(CHECK);
				setState(352);
				match(OPEN_PAR);
				setState(353);
				expr(0);
				setState(354);
				match(CLOSE_PAR);
				}
				break;
			case DEFAULT:
				{
				setState(356);
				match(DEFAULT);
				setState(363);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
				case 1:
					{
					setState(357);
					signed_number();
					}
					break;
				case 2:
					{
					setState(358);
					literal_value();
					}
					break;
				case 3:
					{
					{
					setState(359);
					match(OPEN_PAR);
					setState(360);
					expr(0);
					setState(361);
					match(CLOSE_PAR);
					}
					}
					break;
				}
				}
				break;
			case COLLATE:
				{
				setState(365);
				match(COLLATE);
				setState(366);
				collation_name();
				}
				break;
			case REFERENCES:
				{
				setState(367);
				foreign_key_clause();
				}
				break;
			case AS:
			case GENERATED:
				{
				setState(370);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==GENERATED) {
					{
					setState(368);
					match(GENERATED);
					setState(369);
					match(ALWAYS);
					}
				}

				setState(372);
				match(AS);
				setState(373);
				match(OPEN_PAR);
				setState(374);
				expr(0);
				setState(375);
				match(CLOSE_PAR);
				setState(377);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==VIRTUAL || _la==STORED) {
					{
					setState(376);
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
		public TerminalNode NUMERIC_LITERAL() { return getToken(ElasticParser.NUMERIC_LITERAL, 0); }
		public TerminalNode PLUS() { return getToken(ElasticParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(ElasticParser.MINUS, 0); }
		public Signed_numberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_signed_number; }
	}

	public final Signed_numberContext signed_number() throws RecognitionException {
		Signed_numberContext _localctx = new Signed_numberContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_signed_number);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(382);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PLUS || _la==MINUS) {
				{
				setState(381);
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

			setState(384);
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
		public TerminalNode CONSTRAINT() { return getToken(ElasticParser.CONSTRAINT, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode CHECK() { return getToken(ElasticParser.CHECK, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode FOREIGN() { return getToken(ElasticParser.FOREIGN, 0); }
		public TerminalNode KEY() { return getToken(ElasticParser.KEY, 0); }
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public Foreign_key_clauseContext foreign_key_clause() {
			return getRuleContext(Foreign_key_clauseContext.class,0);
		}
		public TerminalNode PRIMARY() { return getToken(ElasticParser.PRIMARY, 0); }
		public TerminalNode UNIQUE() { return getToken(ElasticParser.UNIQUE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
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
		enterRule(_localctx, 22, RULE_table_constraint);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(388);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CONSTRAINT) {
				{
				setState(386);
				match(CONSTRAINT);
				setState(387);
				name();
				}
			}

			setState(418);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PRIMARY:
			case UNIQUE:
				{
				{
				setState(393);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case PRIMARY:
					{
					setState(390);
					match(PRIMARY);
					setState(391);
					match(KEY);
					}
					break;
				case UNIQUE:
					{
					setState(392);
					match(UNIQUE);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(395);
				match(OPEN_PAR);
				setState(396);
				indexed_column();
				setState(401);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(397);
					match(COMMA);
					setState(398);
					indexed_column();
					}
					}
					setState(403);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(404);
				match(CLOSE_PAR);
				setState(406);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(405);
					conflict_clause();
					}
				}

				}
				}
				break;
			case CHECK:
				{
				{
				setState(408);
				match(CHECK);
				setState(409);
				match(OPEN_PAR);
				setState(410);
				expr(0);
				setState(411);
				match(CLOSE_PAR);
				}
				}
				break;
			case FOREIGN:
				{
				{
				setState(413);
				match(FOREIGN);
				setState(414);
				match(KEY);
				setState(415);
				column_name_list();
				setState(416);
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
		public TerminalNode REFERENCES() { return getToken(ElasticParser.REFERENCES, 0); }
		public Foreign_tableContext foreign_table() {
			return getRuleContext(Foreign_tableContext.class,0);
		}
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public TerminalNode DEFERRABLE() { return getToken(ElasticParser.DEFERRABLE, 0); }
		public List<TerminalNode> ON() { return getTokens(ElasticParser.ON); }
		public TerminalNode ON(int i) {
			return getToken(ElasticParser.ON, i);
		}
		public List<TerminalNode> MATCH() { return getTokens(ElasticParser.MATCH); }
		public TerminalNode MATCH(int i) {
			return getToken(ElasticParser.MATCH, i);
		}
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public List<TerminalNode> DELETE() { return getTokens(ElasticParser.DELETE); }
		public TerminalNode DELETE(int i) {
			return getToken(ElasticParser.DELETE, i);
		}
		public List<TerminalNode> UPDATE() { return getTokens(ElasticParser.UPDATE); }
		public TerminalNode UPDATE(int i) {
			return getToken(ElasticParser.UPDATE, i);
		}
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode INITIALLY() { return getToken(ElasticParser.INITIALLY, 0); }
		public List<TerminalNode> CASCADE() { return getTokens(ElasticParser.CASCADE); }
		public TerminalNode CASCADE(int i) {
			return getToken(ElasticParser.CASCADE, i);
		}
		public List<TerminalNode> RESTRICT() { return getTokens(ElasticParser.RESTRICT); }
		public TerminalNode RESTRICT(int i) {
			return getToken(ElasticParser.RESTRICT, i);
		}
		public TerminalNode DEFERRED() { return getToken(ElasticParser.DEFERRED, 0); }
		public TerminalNode IMMEDIATE() { return getToken(ElasticParser.IMMEDIATE, 0); }
		public List<TerminalNode> SET() { return getTokens(ElasticParser.SET); }
		public TerminalNode SET(int i) {
			return getToken(ElasticParser.SET, i);
		}
		public List<TerminalNode> NO() { return getTokens(ElasticParser.NO); }
		public TerminalNode NO(int i) {
			return getToken(ElasticParser.NO, i);
		}
		public List<TerminalNode> ACTION() { return getTokens(ElasticParser.ACTION); }
		public TerminalNode ACTION(int i) {
			return getToken(ElasticParser.ACTION, i);
		}
		public List<TerminalNode> NULL_() { return getTokens(ElasticParser.NULL_); }
		public TerminalNode NULL_(int i) {
			return getToken(ElasticParser.NULL_, i);
		}
		public List<TerminalNode> DEFAULT() { return getTokens(ElasticParser.DEFAULT); }
		public TerminalNode DEFAULT(int i) {
			return getToken(ElasticParser.DEFAULT, i);
		}
		public Foreign_key_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_foreign_key_clause; }
	}

	public final Foreign_key_clauseContext foreign_key_clause() throws RecognitionException {
		Foreign_key_clauseContext _localctx = new Foreign_key_clauseContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_foreign_key_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(420);
			match(REFERENCES);
			setState(421);
			foreign_table();
			setState(423);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(422);
				column_name_list();
				}
			}

			setState(439);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==MATCH || _la==ON) {
				{
				setState(437);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case ON:
					{
					{
					setState(425);
					match(ON);
					setState(426);
					_la = _input.LA(1);
					if ( !(_la==DELETE || _la==UPDATE) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(433);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case SET:
						{
						{
						setState(427);
						match(SET);
						setState(428);
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
						setState(429);
						match(CASCADE);
						}
						break;
					case RESTRICT:
						{
						setState(430);
						match(RESTRICT);
						}
						break;
					case NO:
						{
						{
						setState(431);
						match(NO);
						setState(432);
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
					setState(435);
					match(MATCH);
					setState(436);
					name();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(441);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(450);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,45,_ctx) ) {
			case 1:
				{
				setState(443);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(442);
					match(NOT);
					}
				}

				setState(445);
				match(DEFERRABLE);
				setState(448);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==INITIALLY) {
					{
					setState(446);
					match(INITIALLY);
					setState(447);
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
		public TerminalNode ON() { return getToken(ElasticParser.ON, 0); }
		public TerminalNode CONFLICT() { return getToken(ElasticParser.CONFLICT, 0); }
		public TerminalNode ROLLBACK() { return getToken(ElasticParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(ElasticParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(ElasticParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(ElasticParser.IGNORE, 0); }
		public TerminalNode REPLACE() { return getToken(ElasticParser.REPLACE, 0); }
		public Conflict_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_conflict_clause; }
	}

	public final Conflict_clauseContext conflict_clause() throws RecognitionException {
		Conflict_clauseContext _localctx = new Conflict_clauseContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_conflict_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(452);
			match(ON);
			setState(453);
			match(CONFLICT);
			setState(454);
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

	public static class Create_view_stmtContext extends ParserRuleContext {
		public TerminalNode CREATE() { return getToken(ElasticParser.CREATE, 0); }
		public TerminalNode VIEW() { return getToken(ElasticParser.VIEW, 0); }
		public View_nameContext view_name() {
			return getRuleContext(View_nameContext.class,0);
		}
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode IF() { return getToken(ElasticParser.IF, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(ElasticParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(ElasticParser.DOT, 0); }
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public TerminalNode TEMP() { return getToken(ElasticParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(ElasticParser.TEMPORARY, 0); }
		public Create_view_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_view_stmt; }
	}

	public final Create_view_stmtContext create_view_stmt() throws RecognitionException {
		Create_view_stmtContext _localctx = new Create_view_stmtContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_create_view_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(456);
			match(CREATE);
			setState(458);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEMP || _la==TEMPORARY) {
				{
				setState(457);
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

			setState(460);
			match(VIEW);
			setState(464);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,47,_ctx) ) {
			case 1:
				{
				setState(461);
				match(IF);
				setState(462);
				match(NOT);
				setState(463);
				match(EXISTS);
				}
				break;
			}
			setState(469);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,48,_ctx) ) {
			case 1:
				{
				setState(466);
				schema_name();
				setState(467);
				match(DOT);
				}
				break;
			}
			setState(471);
			view_name();
			setState(473);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(472);
				column_name_list();
				}
			}

			setState(475);
			match(AS);
			setState(476);
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
		public TerminalNode CREATE() { return getToken(ElasticParser.CREATE, 0); }
		public TerminalNode VIRTUAL() { return getToken(ElasticParser.VIRTUAL, 0); }
		public TerminalNode TABLE() { return getToken(ElasticParser.TABLE, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode USING() { return getToken(ElasticParser.USING, 0); }
		public Module_nameContext module_name() {
			return getRuleContext(Module_nameContext.class,0);
		}
		public TerminalNode IF() { return getToken(ElasticParser.IF, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode EXISTS() { return getToken(ElasticParser.EXISTS, 0); }
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(ElasticParser.DOT, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public List<Module_argumentContext> module_argument() {
			return getRuleContexts(Module_argumentContext.class);
		}
		public Module_argumentContext module_argument(int i) {
			return getRuleContext(Module_argumentContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Create_virtual_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_create_virtual_table_stmt; }
	}

	public final Create_virtual_table_stmtContext create_virtual_table_stmt() throws RecognitionException {
		Create_virtual_table_stmtContext _localctx = new Create_virtual_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_create_virtual_table_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(478);
			match(CREATE);
			setState(479);
			match(VIRTUAL);
			setState(480);
			match(TABLE);
			setState(484);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,50,_ctx) ) {
			case 1:
				{
				setState(481);
				match(IF);
				setState(482);
				match(NOT);
				setState(483);
				match(EXISTS);
				}
				break;
			}
			setState(489);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,51,_ctx) ) {
			case 1:
				{
				setState(486);
				schema_name();
				setState(487);
				match(DOT);
				}
				break;
			}
			setState(491);
			table_name();
			setState(492);
			match(USING);
			setState(493);
			module_name();
			setState(505);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(494);
				match(OPEN_PAR);
				setState(495);
				module_argument();
				setState(500);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(496);
					match(COMMA);
					setState(497);
					module_argument();
					}
					}
					setState(502);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(503);
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
		public TerminalNode WITH() { return getToken(ElasticParser.WITH, 0); }
		public List<Cte_table_nameContext> cte_table_name() {
			return getRuleContexts(Cte_table_nameContext.class);
		}
		public Cte_table_nameContext cte_table_name(int i) {
			return getRuleContext(Cte_table_nameContext.class,i);
		}
		public List<TerminalNode> AS() { return getTokens(ElasticParser.AS); }
		public TerminalNode AS(int i) {
			return getToken(ElasticParser.AS, i);
		}
		public List<TerminalNode> OPEN_PAR() { return getTokens(ElasticParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(ElasticParser.OPEN_PAR, i);
		}
		public List<Select_stmtContext> select_stmt() {
			return getRuleContexts(Select_stmtContext.class);
		}
		public Select_stmtContext select_stmt(int i) {
			return getRuleContext(Select_stmtContext.class,i);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(ElasticParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(ElasticParser.CLOSE_PAR, i);
		}
		public TerminalNode RECURSIVE() { return getToken(ElasticParser.RECURSIVE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public With_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_with_clause; }
	}

	public final With_clauseContext with_clause() throws RecognitionException {
		With_clauseContext _localctx = new With_clauseContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_with_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(507);
			match(WITH);
			setState(509);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,54,_ctx) ) {
			case 1:
				{
				setState(508);
				match(RECURSIVE);
				}
				break;
			}
			setState(511);
			cte_table_name();
			setState(512);
			match(AS);
			setState(513);
			match(OPEN_PAR);
			setState(514);
			select_stmt();
			setState(515);
			match(CLOSE_PAR);
			setState(525);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(516);
				match(COMMA);
				setState(517);
				cte_table_name();
				setState(518);
				match(AS);
				setState(519);
				match(OPEN_PAR);
				setState(520);
				select_stmt();
				setState(521);
				match(CLOSE_PAR);
				}
				}
				setState(527);
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
		enterRule(_localctx, 34, RULE_cte_table_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(528);
			table_name();
			setState(530);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(529);
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
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public Initial_selectContext initial_select() {
			return getRuleContext(Initial_selectContext.class,0);
		}
		public TerminalNode UNION() { return getToken(ElasticParser.UNION, 0); }
		public Recursive_selectContext recursive_select() {
			return getRuleContext(Recursive_selectContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode ALL() { return getToken(ElasticParser.ALL, 0); }
		public Recursive_cteContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_recursive_cte; }
	}

	public final Recursive_cteContext recursive_cte() throws RecognitionException {
		Recursive_cteContext _localctx = new Recursive_cteContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_recursive_cte);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(532);
			cte_table_name();
			setState(533);
			match(AS);
			setState(534);
			match(OPEN_PAR);
			setState(535);
			initial_select();
			setState(536);
			match(UNION);
			setState(538);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ALL) {
				{
				setState(537);
				match(ALL);
				}
			}

			setState(540);
			recursive_select();
			setState(541);
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
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
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
		enterRule(_localctx, 38, RULE_common_table_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(543);
			table_name();
			setState(545);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(544);
				column_name_list();
				}
			}

			setState(547);
			match(AS);
			setState(548);
			match(OPEN_PAR);
			setState(549);
			select_stmt();
			setState(550);
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

	public static class ExprContext extends ParserRuleContext {
		public Literal_valueContext literal_value() {
			return getRuleContext(Literal_valueContext.class,0);
		}
		public TerminalNode BIND_PARAMETER() { return getToken(ElasticParser.BIND_PARAMETER, 0); }
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
		public TerminalNode CAST() { return getToken(ElasticParser.CAST, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public Type_nameContext type_name() {
			return getRuleContext(Type_nameContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
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
		public TerminalNode BETWEEN() { return getToken(ElasticParser.BETWEEN, 0); }
		public TerminalNode AND() { return getToken(ElasticParser.AND, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode COLLATE() { return getToken(ElasticParser.COLLATE, 0); }
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
		public TerminalNode ESCAPE() { return getToken(ElasticParser.ESCAPE, 0); }
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
		int _startState = 40;
		enterRecursionRule(_localctx, 40, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(577);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,60,_ctx) ) {
			case 1:
				{
				setState(553);
				literal_value();
				}
				break;
			case 2:
				{
				setState(554);
				match(BIND_PARAMETER);
				}
				break;
			case 3:
				{
				setState(555);
				fullname();
				}
				break;
			case 4:
				{
				setState(556);
				unary_operator();
				setState(557);
				expr(13);
				}
				break;
			case 5:
				{
				setState(559);
				call_function_expr();
				}
				break;
			case 6:
				{
				setState(560);
				match(CAST);
				setState(561);
				match(OPEN_PAR);
				setState(562);
				expr(0);
				setState(563);
				match(AS);
				setState(564);
				type_name();
				setState(565);
				match(CLOSE_PAR);
				}
				break;
			case 7:
				{
				setState(567);
				exists_expr();
				}
				break;
			case 8:
				{
				setState(568);
				case_expression();
				}
				break;
			case 9:
				{
				setState(569);
				raise_function();
				}
				break;
			case 10:
				{
				setState(570);
				match(OPEN_PAR);
				setState(573);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,59,_ctx) ) {
				case 1:
					{
					setState(571);
					expr(0);
					}
					break;
				case 2:
					{
					setState(572);
					expr_list();
					}
					break;
				}
				setState(575);
				match(CLOSE_PAR);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(611);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,65,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(609);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,64,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(579);
						if (!(precpred(_ctx, 12))) throw new FailedPredicateException(this, "precpred(_ctx, 12)");
						setState(580);
						binary_operator();
						setState(581);
						expr(13);
						}
						break;
					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(583);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(585);
						_errHandler.sync(this);
						_la = _input.LA(1);
						if (_la==NOT) {
							{
							setState(584);
							match(NOT);
							}
						}

						setState(587);
						match(BETWEEN);
						setState(588);
						expr(0);
						setState(589);
						match(AND);
						setState(590);
						expr(4);
						}
						break;
					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(592);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(593);
						match(COLLATE);
						setState(594);
						collation_name();
						}
						break;
					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(595);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(596);
						nullable_expr();
						}
						break;
					case 5:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(597);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(598);
						in_expr();
						}
						break;
					case 6:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(599);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(601);
						_errHandler.sync(this);
						_la = _input.LA(1);
						if (_la==NOT) {
							{
							setState(600);
							match(NOT);
							}
						}

						setState(603);
						like_operator();
						setState(604);
						expr(0);
						setState(607);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,63,_ctx) ) {
						case 1:
							{
							setState(605);
							match(ESCAPE);
							setState(606);
							expr(0);
							}
							break;
						}
						}
						break;
					}
					} 
				}
				setState(613);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,65,_ctx);
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
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode STAR() { return getToken(ElasticParser.STAR, 0); }
		public Filter_clauseContext filter_clause() {
			return getRuleContext(Filter_clauseContext.class,0);
		}
		public Over_clauseContext over_clause() {
			return getRuleContext(Over_clauseContext.class,0);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public TerminalNode DISTINCT() { return getToken(ElasticParser.DISTINCT, 0); }
		public Call_function_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_call_function_expr; }
	}

	public final Call_function_exprContext call_function_expr() throws RecognitionException {
		Call_function_exprContext _localctx = new Call_function_exprContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_call_function_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(614);
			function_name();
			setState(615);
			match(OPEN_PAR);
			setState(621);
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
				setState(617);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,66,_ctx) ) {
				case 1:
					{
					setState(616);
					match(DISTINCT);
					}
					break;
				}
				setState(619);
				expr_list();
				}
				}
				break;
			case STAR:
				{
				setState(620);
				match(STAR);
				}
				break;
			case CLOSE_PAR:
				break;
			default:
				break;
			}
			setState(623);
			match(CLOSE_PAR);
			setState(625);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,68,_ctx) ) {
			case 1:
				{
				setState(624);
				filter_clause();
				}
				break;
			}
			setState(628);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,69,_ctx) ) {
			case 1:
				{
				setState(627);
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
		public TerminalNode IN() { return getToken(ElasticParser.IN, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
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
		public TerminalNode DOT() { return getToken(ElasticParser.DOT, 0); }
		public In_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_in_expr; }
	}

	public final In_exprContext in_expr() throws RecognitionException {
		In_exprContext _localctx = new In_exprContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_in_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(631);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NOT) {
				{
				setState(630);
				match(NOT);
				}
			}

			setState(633);
			match(IN);
			setState(658);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,75,_ctx) ) {
			case 1:
				{
				{
				setState(634);
				match(OPEN_PAR);
				setState(637);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,71,_ctx) ) {
				case 1:
					{
					setState(635);
					select_stmt();
					}
					break;
				case 2:
					{
					setState(636);
					expr_list();
					}
					break;
				}
				setState(639);
				match(CLOSE_PAR);
				}
				}
				break;
			case 2:
				{
				{
				setState(643);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,72,_ctx) ) {
				case 1:
					{
					setState(640);
					schema_name();
					setState(641);
					match(DOT);
					}
					break;
				}
				setState(645);
				table_name();
				}
				}
				break;
			case 3:
				{
				{
				setState(649);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,73,_ctx) ) {
				case 1:
					{
					setState(646);
					schema_name();
					setState(647);
					match(DOT);
					}
					break;
				}
				setState(651);
				table_function_name();
				setState(652);
				match(OPEN_PAR);
				setState(654);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAR) | (1L << PLUS) | (1L << MINUS) | (1L << TILDE) | (1L << ABORT) | (1L << ACTION) | (1L << ADD) | (1L << AFTER) | (1L << ALL) | (1L << ALTER) | (1L << ANALYZE) | (1L << AND) | (1L << AS) | (1L << ASC) | (1L << ATTACH) | (1L << AUTOINCREMENT) | (1L << BEFORE) | (1L << BEGIN) | (1L << BETWEEN) | (1L << BY) | (1L << CASCADE) | (1L << CASE) | (1L << CAST) | (1L << CHECK) | (1L << COLLATE) | (1L << COLUMN) | (1L << COMMIT) | (1L << CONFLICT) | (1L << CONSTRAINT) | (1L << CREATE) | (1L << CROSS) | (1L << CURRENT_DATE) | (1L << CURRENT_TIME) | (1L << CURRENT_TIMESTAMP) | (1L << DATABASE) | (1L << DEFAULT) | (1L << DEFERRABLE) | (1L << DEFERRED) | (1L << DELETE) | (1L << DESC) | (1L << DETACH) | (1L << DISTINCT) | (1L << DROP))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (EACH - 64)) | (1L << (ELSE - 64)) | (1L << (END - 64)) | (1L << (ESCAPE - 64)) | (1L << (EXCEPT - 64)) | (1L << (EXCLUSIVE - 64)) | (1L << (EXISTS - 64)) | (1L << (EXPLAIN - 64)) | (1L << (FAIL - 64)) | (1L << (FOR - 64)) | (1L << (FOREIGN - 64)) | (1L << (FROM - 64)) | (1L << (FULL - 64)) | (1L << (GLOB - 64)) | (1L << (GROUP - 64)) | (1L << (HAVING - 64)) | (1L << (IF - 64)) | (1L << (IGNORE - 64)) | (1L << (IMMEDIATE - 64)) | (1L << (IN - 64)) | (1L << (INDEX - 64)) | (1L << (INDEXED - 64)) | (1L << (INITIALLY - 64)) | (1L << (INNER - 64)) | (1L << (INSERT - 64)) | (1L << (INSTEAD - 64)) | (1L << (INTERSECT - 64)) | (1L << (INTO - 64)) | (1L << (IS - 64)) | (1L << (ISNULL - 64)) | (1L << (JOIN - 64)) | (1L << (KEY - 64)) | (1L << (LEFT - 64)) | (1L << (LIKE - 64)) | (1L << (LIMIT - 64)) | (1L << (MATCH - 64)) | (1L << (NATURAL - 64)) | (1L << (NO - 64)) | (1L << (NOT - 64)) | (1L << (NOTNULL - 64)) | (1L << (NULL_ - 64)) | (1L << (OF - 64)) | (1L << (OFFSET - 64)) | (1L << (ON - 64)) | (1L << (OR - 64)) | (1L << (ORDER - 64)) | (1L << (OUTER - 64)) | (1L << (PLAN - 64)) | (1L << (PRAGMA - 64)) | (1L << (PRIMARY - 64)) | (1L << (QUERY - 64)) | (1L << (RAISE - 64)) | (1L << (RECURSIVE - 64)) | (1L << (REFERENCES - 64)) | (1L << (REGEXP - 64)) | (1L << (REINDEX - 64)) | (1L << (RELEASE - 64)) | (1L << (RENAME - 64)) | (1L << (REPLACE - 64)) | (1L << (RESTRICT - 64)) | (1L << (RIGHT - 64)) | (1L << (ROLLBACK - 64)) | (1L << (ROW - 64)) | (1L << (ROWS - 64)))) != 0) || ((((_la - 128)) & ~0x3f) == 0 && ((1L << (_la - 128)) & ((1L << (SAVEPOINT - 128)) | (1L << (SELECT - 128)) | (1L << (SET - 128)) | (1L << (TABLE - 128)) | (1L << (TEMP - 128)) | (1L << (TEMPORARY - 128)) | (1L << (THEN - 128)) | (1L << (TO - 128)) | (1L << (TRANSACTION - 128)) | (1L << (TRIGGER - 128)) | (1L << (UNION - 128)) | (1L << (UNIQUE - 128)) | (1L << (UPDATE - 128)) | (1L << (USING - 128)) | (1L << (VACUUM - 128)) | (1L << (VALUES - 128)) | (1L << (VIEW - 128)) | (1L << (VIRTUAL - 128)) | (1L << (WHEN - 128)) | (1L << (WHERE - 128)) | (1L << (WITH - 128)) | (1L << (WITHOUT - 128)) | (1L << (FIRST_VALUE - 128)) | (1L << (OVER - 128)) | (1L << (PARTITION - 128)) | (1L << (RANGE - 128)) | (1L << (PRECEDING - 128)) | (1L << (UNBOUNDED - 128)) | (1L << (CURRENT - 128)) | (1L << (FOLLOWING - 128)) | (1L << (CUME_DIST - 128)) | (1L << (DENSE_RANK - 128)) | (1L << (LAG - 128)) | (1L << (LAST_VALUE - 128)) | (1L << (LEAD - 128)) | (1L << (NTH_VALUE - 128)) | (1L << (NTILE - 128)) | (1L << (PERCENT_RANK - 128)) | (1L << (RANK - 128)) | (1L << (ROW_NUMBER - 128)) | (1L << (GENERATED - 128)) | (1L << (ALWAYS - 128)) | (1L << (STORED - 128)) | (1L << (TRUE_ - 128)) | (1L << (FALSE_ - 128)) | (1L << (WINDOW - 128)) | (1L << (NULLS - 128)) | (1L << (FIRST - 128)) | (1L << (LAST - 128)) | (1L << (FILTER - 128)) | (1L << (GROUPS - 128)) | (1L << (EXCLUDE - 128)) | (1L << (IDENTIFIER - 128)) | (1L << (NUMERIC_LITERAL - 128)) | (1L << (BIND_PARAMETER - 128)) | (1L << (STRING_LITERAL - 128)) | (1L << (BLOB_LITERAL - 128)))) != 0)) {
					{
					setState(653);
					expr_list();
					}
				}

				setState(656);
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
		public TerminalNode END() { return getToken(ElasticParser.END, 0); }
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
		enterRule(_localctx, 46, RULE_case_expression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(660);
			case_expr();
			setState(662); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(661);
				case_when();
				}
				}
				setState(664); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==WHEN );
			setState(667);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(666);
				case_else_expr();
				}
			}

			setState(669);
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
		public TerminalNode WHEN() { return getToken(ElasticParser.WHEN, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode THEN() { return getToken(ElasticParser.THEN, 0); }
		public Case_whenContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_case_when; }
	}

	public final Case_whenContext case_when() throws RecognitionException {
		Case_whenContext _localctx = new Case_whenContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_case_when);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(671);
			match(WHEN);
			setState(672);
			expr(0);
			setState(673);
			match(THEN);
			setState(674);
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
		public TerminalNode CASE() { return getToken(ElasticParser.CASE, 0); }
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
		enterRule(_localctx, 50, RULE_case_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(676);
			match(CASE);
			setState(678);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,78,_ctx) ) {
			case 1:
				{
				setState(677);
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
		public TerminalNode ELSE() { return getToken(ElasticParser.ELSE, 0); }
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
		enterRule(_localctx, 52, RULE_case_else_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(680);
			match(ELSE);
			setState(681);
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
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode EXISTS() { return getToken(ElasticParser.EXISTS, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public Exists_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exists_expr; }
	}

	public final Exists_exprContext exists_expr() throws RecognitionException {
		Exists_exprContext _localctx = new Exists_exprContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_exists_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(687);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXISTS || _la==NOT) {
				{
				setState(684);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(683);
					match(NOT);
					}
				}

				setState(686);
				match(EXISTS);
				}
			}

			setState(689);
			match(OPEN_PAR);
			setState(690);
			select_stmt();
			setState(691);
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
		public TerminalNode ISNULL() { return getToken(ElasticParser.ISNULL, 0); }
		public TerminalNode NOTNULL() { return getToken(ElasticParser.NOTNULL, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode NULL_() { return getToken(ElasticParser.NULL_, 0); }
		public Nullable_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nullable_expr; }
	}

	public final Nullable_exprContext nullable_expr() throws RecognitionException {
		Nullable_exprContext _localctx = new Nullable_exprContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_nullable_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(697);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ISNULL:
				{
				setState(693);
				match(ISNULL);
				}
				break;
			case NOTNULL:
				{
				setState(694);
				match(NOTNULL);
				}
				break;
			case NOT:
				{
				{
				setState(695);
				match(NOT);
				setState(696);
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
		public List<TerminalNode> DOT() { return getTokens(ElasticParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(ElasticParser.DOT, i);
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
		enterRule(_localctx, 58, RULE_fullname);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(707);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,83,_ctx) ) {
			case 1:
				{
				setState(702);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,82,_ctx) ) {
				case 1:
					{
					setState(699);
					schema_name();
					setState(700);
					match(DOT);
					}
					break;
				}
				setState(704);
				table_name();
				setState(705);
				match(DOT);
				}
				break;
			}
			setState(709);
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
		public TerminalNode PIPE2() { return getToken(ElasticParser.PIPE2, 0); }
		public TerminalNode STAR() { return getToken(ElasticParser.STAR, 0); }
		public TerminalNode DIV() { return getToken(ElasticParser.DIV, 0); }
		public TerminalNode MOD() { return getToken(ElasticParser.MOD, 0); }
		public TerminalNode PLUS() { return getToken(ElasticParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(ElasticParser.MINUS, 0); }
		public TerminalNode LT2() { return getToken(ElasticParser.LT2, 0); }
		public TerminalNode GT2() { return getToken(ElasticParser.GT2, 0); }
		public TerminalNode AMP() { return getToken(ElasticParser.AMP, 0); }
		public TerminalNode PIPE() { return getToken(ElasticParser.PIPE, 0); }
		public TerminalNode LT() { return getToken(ElasticParser.LT, 0); }
		public TerminalNode LT_EQ() { return getToken(ElasticParser.LT_EQ, 0); }
		public TerminalNode GT() { return getToken(ElasticParser.GT, 0); }
		public TerminalNode GT_EQ() { return getToken(ElasticParser.GT_EQ, 0); }
		public TerminalNode ASSIGN() { return getToken(ElasticParser.ASSIGN, 0); }
		public TerminalNode EQ() { return getToken(ElasticParser.EQ, 0); }
		public TerminalNode NOT_EQ1() { return getToken(ElasticParser.NOT_EQ1, 0); }
		public TerminalNode NOT_EQ2() { return getToken(ElasticParser.NOT_EQ2, 0); }
		public TerminalNode IN() { return getToken(ElasticParser.IN, 0); }
		public TerminalNode AND() { return getToken(ElasticParser.AND, 0); }
		public TerminalNode OR() { return getToken(ElasticParser.OR, 0); }
		public TerminalNode IS() { return getToken(ElasticParser.IS, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
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
		enterRule(_localctx, 60, RULE_binary_operator);
		int _la;
		try {
			setState(728);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PIPE2:
				enterOuterAlt(_localctx, 1);
				{
				setState(711);
				match(PIPE2);
				}
				break;
			case STAR:
			case DIV:
			case MOD:
				enterOuterAlt(_localctx, 2);
				{
				setState(712);
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
				setState(713);
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
				setState(714);
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
				setState(715);
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
				setState(716);
				match(ASSIGN);
				}
				break;
			case EQ:
				enterOuterAlt(_localctx, 7);
				{
				setState(717);
				match(EQ);
				}
				break;
			case NOT_EQ1:
				enterOuterAlt(_localctx, 8);
				{
				setState(718);
				match(NOT_EQ1);
				}
				break;
			case NOT_EQ2:
				enterOuterAlt(_localctx, 9);
				{
				setState(719);
				match(NOT_EQ2);
				}
				break;
			case IN:
				enterOuterAlt(_localctx, 10);
				{
				setState(720);
				match(IN);
				}
				break;
			case AND:
				enterOuterAlt(_localctx, 11);
				{
				setState(721);
				match(AND);
				}
				break;
			case OR:
				enterOuterAlt(_localctx, 12);
				{
				setState(722);
				match(OR);
				}
				break;
			case IS:
				enterOuterAlt(_localctx, 13);
				{
				setState(723);
				match(IS);
				setState(725);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,84,_ctx) ) {
				case 1:
					{
					setState(724);
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
				setState(727);
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
		public TerminalNode LIKE() { return getToken(ElasticParser.LIKE, 0); }
		public TerminalNode GLOB() { return getToken(ElasticParser.GLOB, 0); }
		public TerminalNode MATCH() { return getToken(ElasticParser.MATCH, 0); }
		public TerminalNode REGEXP() { return getToken(ElasticParser.REGEXP, 0); }
		public Like_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_like_operator; }
	}

	public final Like_operatorContext like_operator() throws RecognitionException {
		Like_operatorContext _localctx = new Like_operatorContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_like_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(730);
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
		public TerminalNode RAISE() { return getToken(ElasticParser.RAISE, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode IGNORE() { return getToken(ElasticParser.IGNORE, 0); }
		public TerminalNode COMMA() { return getToken(ElasticParser.COMMA, 0); }
		public Error_messageContext error_message() {
			return getRuleContext(Error_messageContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(ElasticParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(ElasticParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(ElasticParser.FAIL, 0); }
		public Raise_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_raise_function; }
	}

	public final Raise_functionContext raise_function() throws RecognitionException {
		Raise_functionContext _localctx = new Raise_functionContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_raise_function);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(732);
			match(RAISE);
			setState(733);
			match(OPEN_PAR);
			setState(738);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IGNORE:
				{
				setState(734);
				match(IGNORE);
				}
				break;
			case ABORT:
			case FAIL:
			case ROLLBACK:
				{
				{
				setState(735);
				_la = _input.LA(1);
				if ( !(_la==ABORT || _la==FAIL || _la==ROLLBACK) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(736);
				match(COMMA);
				setState(737);
				error_message();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(740);
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
		public TerminalNode NUMERIC_LITERAL() { return getToken(ElasticParser.NUMERIC_LITERAL, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(ElasticParser.STRING_LITERAL, 0); }
		public TerminalNode BLOB_LITERAL() { return getToken(ElasticParser.BLOB_LITERAL, 0); }
		public TerminalNode NULL_() { return getToken(ElasticParser.NULL_, 0); }
		public TerminalNode TRUE_() { return getToken(ElasticParser.TRUE_, 0); }
		public TerminalNode FALSE_() { return getToken(ElasticParser.FALSE_, 0); }
		public TerminalNode CURRENT_TIME() { return getToken(ElasticParser.CURRENT_TIME, 0); }
		public TerminalNode CURRENT_DATE() { return getToken(ElasticParser.CURRENT_DATE, 0); }
		public TerminalNode CURRENT_TIMESTAMP() { return getToken(ElasticParser.CURRENT_TIMESTAMP, 0); }
		public Literal_valueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal_value; }
	}

	public final Literal_valueContext literal_value() throws RecognitionException {
		Literal_valueContext _localctx = new Literal_valueContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_literal_value);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(742);
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
		public TerminalNode INTO() { return getToken(ElasticParser.INTO, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode INSERT() { return getToken(ElasticParser.INSERT, 0); }
		public TerminalNode REPLACE() { return getToken(ElasticParser.REPLACE, 0); }
		public With_clauseContext with_clause() {
			return getRuleContext(With_clauseContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(ElasticParser.DOT, 0); }
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public Column_name_listContext column_name_list() {
			return getRuleContext(Column_name_listContext.class,0);
		}
		public TerminalNode OR() { return getToken(ElasticParser.OR, 0); }
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public TerminalNode ROLLBACK() { return getToken(ElasticParser.ROLLBACK, 0); }
		public TerminalNode ABORT() { return getToken(ElasticParser.ABORT, 0); }
		public TerminalNode FAIL() { return getToken(ElasticParser.FAIL, 0); }
		public TerminalNode IGNORE() { return getToken(ElasticParser.IGNORE, 0); }
		public Upsert_clauseContext upsert_clause() {
			return getRuleContext(Upsert_clauseContext.class,0);
		}
		public TerminalNode VALUES() { return getToken(ElasticParser.VALUES, 0); }
		public Value_list_stmtContext value_list_stmt() {
			return getRuleContext(Value_list_stmtContext.class,0);
		}
		public TerminalNode DEFAULT() { return getToken(ElasticParser.DEFAULT, 0); }
		public Insert_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_insert_stmt; }
	}

	public final Insert_stmtContext insert_stmt() throws RecognitionException {
		Insert_stmtContext _localctx = new Insert_stmtContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_insert_stmt);
		int _la;
		try {
			setState(778);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INSERT:
			case REPLACE:
			case WITH:
				enterOuterAlt(_localctx, 1);
				{
				setState(745);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WITH) {
					{
					setState(744);
					with_clause();
					}
				}

				setState(752);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,88,_ctx) ) {
				case 1:
					{
					setState(747);
					match(INSERT);
					}
					break;
				case 2:
					{
					setState(748);
					match(REPLACE);
					}
					break;
				case 3:
					{
					{
					setState(749);
					match(INSERT);
					setState(750);
					match(OR);
					setState(751);
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
				setState(754);
				match(INTO);
				setState(758);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,89,_ctx) ) {
				case 1:
					{
					setState(755);
					schema_name();
					setState(756);
					match(DOT);
					}
					break;
				}
				setState(760);
				table_name();
				setState(763);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS) {
					{
					setState(761);
					match(AS);
					setState(762);
					table_alias();
					}
				}

				setState(766);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==OPEN_PAR) {
					{
					setState(765);
					column_name_list();
					}
				}

				{
				setState(771);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,92,_ctx) ) {
				case 1:
					{
					{
					setState(768);
					match(VALUES);
					setState(769);
					value_list_stmt();
					}
					}
					break;
				case 2:
					{
					setState(770);
					select_stmt();
					}
					break;
				}
				setState(774);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ON) {
					{
					setState(773);
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
				setState(776);
				match(DEFAULT);
				setState(777);
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
		public TerminalNode ON() { return getToken(ElasticParser.ON, 0); }
		public TerminalNode CONFLICT() { return getToken(ElasticParser.CONFLICT, 0); }
		public TerminalNode DO() { return getToken(ElasticParser.DO, 0); }
		public TerminalNode NOTHING() { return getToken(ElasticParser.NOTHING, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public List<Indexed_columnContext> indexed_column() {
			return getRuleContexts(Indexed_columnContext.class);
		}
		public Indexed_columnContext indexed_column(int i) {
			return getRuleContext(Indexed_columnContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode UPDATE() { return getToken(ElasticParser.UPDATE, 0); }
		public TerminalNode SET() { return getToken(ElasticParser.SET, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public List<Where_stmtContext> where_stmt() {
			return getRuleContexts(Where_stmtContext.class);
		}
		public Where_stmtContext where_stmt(int i) {
			return getRuleContext(Where_stmtContext.class,i);
		}
		public List<TerminalNode> EQ() { return getTokens(ElasticParser.EQ); }
		public TerminalNode EQ(int i) {
			return getToken(ElasticParser.EQ, i);
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
		enterRule(_localctx, 70, RULE_upsert_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(780);
			match(ON);
			setState(781);
			match(CONFLICT);
			setState(795);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPEN_PAR) {
				{
				setState(782);
				match(OPEN_PAR);
				setState(783);
				indexed_column();
				setState(788);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(784);
					match(COMMA);
					setState(785);
					indexed_column();
					}
					}
					setState(790);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(791);
				match(CLOSE_PAR);
				setState(793);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(792);
					where_stmt();
					}
				}

				}
			}

			setState(797);
			match(DO);
			setState(823);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NOTHING:
				{
				setState(798);
				match(NOTHING);
				}
				break;
			case UPDATE:
				{
				{
				setState(799);
				match(UPDATE);
				setState(800);
				match(SET);
				{
				setState(803);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,98,_ctx) ) {
				case 1:
					{
					setState(801);
					column_name();
					}
					break;
				case 2:
					{
					setState(802);
					column_name_list();
					}
					break;
				}
				setState(805);
				match(EQ);
				setState(806);
				expr(0);
				setState(817);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(807);
					match(COMMA);
					setState(810);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,99,_ctx) ) {
					case 1:
						{
						setState(808);
						column_name();
						}
						break;
					case 2:
						{
						setState(809);
						column_name_list();
						}
						break;
					}
					setState(812);
					match(EQ);
					setState(813);
					expr(0);
					}
					}
					setState(819);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(821);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(820);
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
		enterRule(_localctx, 72, RULE_select_stmt);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(826);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WITH) {
				{
				setState(825);
				common_table_stmt();
				}
			}

			setState(828);
			select_core();
			setState(832);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,104,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(829);
					compound();
					}
					} 
				}
				setState(834);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,104,_ctx);
			}
			setState(836);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDER) {
				{
				setState(835);
				order_by_stmt();
				}
			}

			setState(839);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(838);
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
		enterRule(_localctx, 74, RULE_compound);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(841);
			compound_operator();
			setState(842);
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
		enterRule(_localctx, 76, RULE_join_clauses);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(844);
			table_or_subquery();
			setState(846); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(845);
				join_clause();
				}
				}
				setState(848); 
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
		enterRule(_localctx, 78, RULE_join_clause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(850);
			join_operator();
			setState(851);
			table_or_subquery();
			setState(853);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,108,_ctx) ) {
			case 1:
				{
				setState(852);
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
		public TerminalNode SELECT() { return getToken(ElasticParser.SELECT, 0); }
		public List<Result_columnContext> result_column() {
			return getRuleContexts(Result_columnContext.class);
		}
		public Result_columnContext result_column(int i) {
			return getRuleContext(Result_columnContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public TerminalNode FROM() { return getToken(ElasticParser.FROM, 0); }
		public Subquery_tableContext subquery_table() {
			return getRuleContext(Subquery_tableContext.class,0);
		}
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public Group_by_stmtContext group_by_stmt() {
			return getRuleContext(Group_by_stmtContext.class,0);
		}
		public TerminalNode WINDOW() { return getToken(ElasticParser.WINDOW, 0); }
		public List<Window_stmtContext> window_stmt() {
			return getRuleContexts(Window_stmtContext.class);
		}
		public Window_stmtContext window_stmt(int i) {
			return getRuleContext(Window_stmtContext.class,i);
		}
		public TerminalNode DISTINCT() { return getToken(ElasticParser.DISTINCT, 0); }
		public TerminalNode ALL() { return getToken(ElasticParser.ALL, 0); }
		public TerminalNode VALUES() { return getToken(ElasticParser.VALUES, 0); }
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
		enterRule(_localctx, 80, RULE_select_core);
		int _la;
		try {
			setState(890);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SELECT:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(855);
				match(SELECT);
				setState(857);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,109,_ctx) ) {
				case 1:
					{
					setState(856);
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
				setState(859);
				result_column();
				setState(864);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(860);
					match(COMMA);
					setState(861);
					result_column();
					}
					}
					setState(866);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(869);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==FROM) {
					{
					setState(867);
					match(FROM);
					setState(868);
					subquery_table();
					}
				}

				setState(872);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WHERE) {
					{
					setState(871);
					where_stmt();
					}
				}

				setState(875);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==GROUP) {
					{
					setState(874);
					group_by_stmt();
					}
				}

				setState(886);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WINDOW) {
					{
					setState(877);
					match(WINDOW);
					setState(878);
					window_stmt();
					setState(883);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(879);
						match(COMMA);
						setState(880);
						window_stmt();
						}
						}
						setState(885);
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
				setState(888);
				match(VALUES);
				setState(889);
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
		public List<TerminalNode> OPEN_PAR() { return getTokens(ElasticParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(ElasticParser.OPEN_PAR, i);
		}
		public List<Expr_listContext> expr_list() {
			return getRuleContexts(Expr_listContext.class);
		}
		public Expr_listContext expr_list(int i) {
			return getRuleContext(Expr_listContext.class,i);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(ElasticParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(ElasticParser.CLOSE_PAR, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Value_list_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value_list_stmt; }
	}

	public final Value_list_stmtContext value_list_stmt() throws RecognitionException {
		Value_list_stmtContext _localctx = new Value_list_stmtContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_value_list_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(892);
			match(OPEN_PAR);
			setState(893);
			expr_list();
			setState(894);
			match(CLOSE_PAR);
			setState(902);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(895);
				match(COMMA);
				setState(896);
				match(OPEN_PAR);
				setState(897);
				expr_list();
				setState(898);
				match(CLOSE_PAR);
				}
				}
				setState(904);
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
		public TerminalNode GROUP() { return getToken(ElasticParser.GROUP, 0); }
		public TerminalNode BY() { return getToken(ElasticParser.BY, 0); }
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
		enterRule(_localctx, 84, RULE_group_by_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(905);
			match(GROUP);
			setState(906);
			match(BY);
			setState(907);
			expr_list();
			setState(909);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HAVING) {
				{
				setState(908);
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
		public TerminalNode HAVING() { return getToken(ElasticParser.HAVING, 0); }
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
		enterRule(_localctx, 86, RULE_having_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(911);
			match(HAVING);
			setState(912);
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
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
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
		enterRule(_localctx, 88, RULE_window_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(914);
			window_name();
			setState(915);
			match(AS);
			setState(916);
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
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Expr_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr_list; }
	}

	public final Expr_listContext expr_list() throws RecognitionException {
		Expr_listContext _localctx = new Expr_listContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_expr_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(918);
			expr(0);
			setState(923);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(919);
				match(COMMA);
				setState(920);
				expr(0);
				}
				}
				setState(925);
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

	public static class Table_or_subqueryContext extends ParserRuleContext {
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public Schema_nameContext schema_name() {
			return getRuleContext(Schema_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(ElasticParser.DOT, 0); }
		public Table_aliasContext table_alias() {
			return getRuleContext(Table_aliasContext.class,0);
		}
		public TerminalNode INDEXED() { return getToken(ElasticParser.INDEXED, 0); }
		public TerminalNode BY() { return getToken(ElasticParser.BY, 0); }
		public Index_nameContext index_name() {
			return getRuleContext(Index_nameContext.class,0);
		}
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public Table_function_nameContext table_function_name() {
			return getRuleContext(Table_function_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
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
		enterRule(_localctx, 92, RULE_table_or_subquery);
		int _la;
		try {
			setState(980);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,130,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(929);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,120,_ctx) ) {
				case 1:
					{
					setState(926);
					schema_name();
					setState(927);
					match(DOT);
					}
					break;
				}
				setState(931);
				table_name();
				setState(936);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,122,_ctx) ) {
				case 1:
					{
					setState(933);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,121,_ctx) ) {
					case 1:
						{
						setState(932);
						match(AS);
						}
						break;
					}
					setState(935);
					table_alias();
					}
					break;
				}
				setState(943);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case INDEXED:
					{
					{
					setState(938);
					match(INDEXED);
					setState(939);
					match(BY);
					setState(940);
					index_name();
					}
					}
					break;
				case NOT:
					{
					{
					setState(941);
					match(NOT);
					setState(942);
					match(INDEXED);
					}
					}
					break;
				case EOF:
				case SCOL:
				case CLOSE_PAR:
				case COMMA:
				case CREATE:
				case CROSS:
				case DEFAULT:
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
				case REPLACE:
				case SELECT:
				case UNION:
				case USING:
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
				setState(948);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,124,_ctx) ) {
				case 1:
					{
					setState(945);
					schema_name();
					setState(946);
					match(DOT);
					}
					break;
				}
				setState(950);
				table_function_name();
				setState(951);
				match(OPEN_PAR);
				setState(952);
				expr(0);
				setState(957);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(953);
					match(COMMA);
					setState(954);
					expr(0);
					}
					}
					setState(959);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(960);
				match(CLOSE_PAR);
				setState(965);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,127,_ctx) ) {
				case 1:
					{
					setState(962);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,126,_ctx) ) {
					case 1:
						{
						setState(961);
						match(AS);
						}
						break;
					}
					setState(964);
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
				setState(967);
				match(OPEN_PAR);
				setState(968);
				subquery_table();
				setState(969);
				match(CLOSE_PAR);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(971);
				match(OPEN_PAR);
				setState(972);
				select_stmt();
				setState(973);
				match(CLOSE_PAR);
				setState(978);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,129,_ctx) ) {
				case 1:
					{
					setState(975);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,128,_ctx) ) {
					case 1:
						{
						setState(974);
						match(AS);
						}
						break;
					}
					setState(977);
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
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Subquery_tableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subquery_table; }
	}

	public final Subquery_tableContext subquery_table() throws RecognitionException {
		Subquery_tableContext _localctx = new Subquery_tableContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_subquery_table);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(991);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,132,_ctx) ) {
			case 1:
				{
				setState(982);
				table_or_subquery();
				setState(987);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(983);
					match(COMMA);
					setState(984);
					table_or_subquery();
					}
					}
					setState(989);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case 2:
				{
				setState(990);
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
		public TerminalNode STAR() { return getToken(ElasticParser.STAR, 0); }
		public Table_nameContext table_name() {
			return getRuleContext(Table_nameContext.class,0);
		}
		public TerminalNode DOT() { return getToken(ElasticParser.DOT, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Column_aliasContext column_alias() {
			return getRuleContext(Column_aliasContext.class,0);
		}
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public Result_columnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_result_column; }
	}

	public final Result_columnContext result_column() throws RecognitionException {
		Result_columnContext _localctx = new Result_columnContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_result_column);
		int _la;
		try {
			setState(1005);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,135,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(993);
				match(STAR);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(994);
				table_name();
				setState(995);
				match(DOT);
				setState(996);
				match(STAR);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(998);
				expr(0);
				setState(1003);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AS || _la==IDENTIFIER || _la==STRING_LITERAL) {
					{
					setState(1000);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==AS) {
						{
						setState(999);
						match(AS);
						}
					}

					setState(1002);
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
		public TerminalNode COMMA() { return getToken(ElasticParser.COMMA, 0); }
		public TerminalNode JOIN() { return getToken(ElasticParser.JOIN, 0); }
		public TerminalNode NATURAL() { return getToken(ElasticParser.NATURAL, 0); }
		public TerminalNode INNER() { return getToken(ElasticParser.INNER, 0); }
		public TerminalNode CROSS() { return getToken(ElasticParser.CROSS, 0); }
		public TerminalNode LEFT() { return getToken(ElasticParser.LEFT, 0); }
		public TerminalNode OUTER() { return getToken(ElasticParser.OUTER, 0); }
		public Join_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_join_operator; }
	}

	public final Join_operatorContext join_operator() throws RecognitionException {
		Join_operatorContext _localctx = new Join_operatorContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_join_operator);
		int _la;
		try {
			setState(1020);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case COMMA:
				enterOuterAlt(_localctx, 1);
				{
				setState(1007);
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
				setState(1009);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NATURAL) {
					{
					setState(1008);
					match(NATURAL);
					}
				}

				setState(1017);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case LEFT:
					{
					{
					setState(1011);
					match(LEFT);
					setState(1013);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==OUTER) {
						{
						setState(1012);
						match(OUTER);
						}
					}

					}
					}
					break;
				case INNER:
					{
					setState(1015);
					match(INNER);
					}
					break;
				case CROSS:
					{
					setState(1016);
					match(CROSS);
					}
					break;
				case JOIN:
					break;
				default:
					break;
				}
				setState(1019);
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
		public TerminalNode ON() { return getToken(ElasticParser.ON, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode USING() { return getToken(ElasticParser.USING, 0); }
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
		enterRule(_localctx, 100, RULE_join_constraint);
		try {
			setState(1026);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ON:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1022);
				match(ON);
				setState(1023);
				expr(0);
				}
				}
				break;
			case USING:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1024);
				match(USING);
				setState(1025);
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
		public TerminalNode UNION() { return getToken(ElasticParser.UNION, 0); }
		public TerminalNode ALL() { return getToken(ElasticParser.ALL, 0); }
		public TerminalNode INTERSECT() { return getToken(ElasticParser.INTERSECT, 0); }
		public TerminalNode EXCEPT() { return getToken(ElasticParser.EXCEPT, 0); }
		public Compound_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compound_operator; }
	}

	public final Compound_operatorContext compound_operator() throws RecognitionException {
		Compound_operatorContext _localctx = new Compound_operatorContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_compound_operator);
		int _la;
		try {
			setState(1034);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case UNION:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1028);
				match(UNION);
				setState(1030);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ALL) {
					{
					setState(1029);
					match(ALL);
					}
				}

				}
				}
				break;
			case INTERSECT:
				enterOuterAlt(_localctx, 2);
				{
				setState(1032);
				match(INTERSECT);
				}
				break;
			case EXCEPT:
				enterOuterAlt(_localctx, 3);
				{
				setState(1033);
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

	public static class Column_name_listContext extends ParserRuleContext {
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public List<Column_nameContext> column_name() {
			return getRuleContexts(Column_nameContext.class);
		}
		public Column_nameContext column_name(int i) {
			return getRuleContext(Column_nameContext.class,i);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Column_name_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_name_list; }
	}

	public final Column_name_listContext column_name_list() throws RecognitionException {
		Column_name_listContext _localctx = new Column_name_listContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_column_name_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1036);
			match(OPEN_PAR);
			setState(1037);
			column_name();
			setState(1042);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1038);
				match(COMMA);
				setState(1039);
				column_name();
				}
				}
				setState(1044);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(1045);
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

	public static class Filter_clauseContext extends ParserRuleContext {
		public TerminalNode FILTER() { return getToken(ElasticParser.FILTER, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public TerminalNode WHERE() { return getToken(ElasticParser.WHERE, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public Filter_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filter_clause; }
	}

	public final Filter_clauseContext filter_clause() throws RecognitionException {
		Filter_clauseContext _localctx = new Filter_clauseContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_filter_clause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1047);
			match(FILTER);
			setState(1048);
			match(OPEN_PAR);
			setState(1049);
			match(WHERE);
			setState(1050);
			expr(0);
			setState(1051);
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
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public TerminalNode ORDER() { return getToken(ElasticParser.ORDER, 0); }
		public List<TerminalNode> BY() { return getTokens(ElasticParser.BY); }
		public TerminalNode BY(int i) {
			return getToken(ElasticParser.BY, i);
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
		public TerminalNode PARTITION() { return getToken(ElasticParser.PARTITION, 0); }
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public Frame_specContext frame_spec() {
			return getRuleContext(Frame_specContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Window_defnContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_defn; }
	}

	public final Window_defnContext window_defn() throws RecognitionException {
		Window_defnContext _localctx = new Window_defnContext(_ctx, getState());
		enterRule(_localctx, 108, RULE_window_defn);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1053);
			match(OPEN_PAR);
			setState(1055);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,144,_ctx) ) {
			case 1:
				{
				setState(1054);
				base_window_name();
				}
				break;
			}
			setState(1060);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARTITION) {
				{
				setState(1057);
				match(PARTITION);
				setState(1058);
				match(BY);
				setState(1059);
				expr_list();
				}
			}

			{
			setState(1062);
			match(ORDER);
			setState(1063);
			match(BY);
			setState(1064);
			ordering_term();
			setState(1069);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1065);
				match(COMMA);
				setState(1066);
				ordering_term();
				}
				}
				setState(1071);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
			setState(1073);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
				{
				setState(1072);
				frame_spec();
				}
			}

			setState(1075);
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
		public TerminalNode OVER() { return getToken(ElasticParser.OVER, 0); }
		public Window_nameContext window_name() {
			return getRuleContext(Window_nameContext.class,0);
		}
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public Base_window_nameContext base_window_name() {
			return getRuleContext(Base_window_nameContext.class,0);
		}
		public TerminalNode PARTITION() { return getToken(ElasticParser.PARTITION, 0); }
		public List<TerminalNode> BY() { return getTokens(ElasticParser.BY); }
		public TerminalNode BY(int i) {
			return getToken(ElasticParser.BY, i);
		}
		public Expr_listContext expr_list() {
			return getRuleContext(Expr_listContext.class,0);
		}
		public TerminalNode ORDER() { return getToken(ElasticParser.ORDER, 0); }
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public Frame_specContext frame_spec() {
			return getRuleContext(Frame_specContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Over_clauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_over_clause; }
	}

	public final Over_clauseContext over_clause() throws RecognitionException {
		Over_clauseContext _localctx = new Over_clauseContext(_ctx, getState());
		enterRule(_localctx, 110, RULE_over_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1077);
			match(OVER);
			setState(1104);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,153,_ctx) ) {
			case 1:
				{
				setState(1078);
				window_name();
				}
				break;
			case 2:
				{
				{
				setState(1079);
				match(OPEN_PAR);
				setState(1081);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,148,_ctx) ) {
				case 1:
					{
					setState(1080);
					base_window_name();
					}
					break;
				}
				setState(1086);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1083);
					match(PARTITION);
					setState(1084);
					match(BY);
					setState(1085);
					expr_list();
					}
				}

				setState(1098);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1088);
					match(ORDER);
					setState(1089);
					match(BY);
					setState(1090);
					ordering_term();
					setState(1095);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(1091);
						match(COMMA);
						setState(1092);
						ordering_term();
						}
						}
						setState(1097);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(1101);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1100);
					frame_spec();
					}
				}

				setState(1103);
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
		public TerminalNode EXCLUDE() { return getToken(ElasticParser.EXCLUDE, 0); }
		public TerminalNode GROUP() { return getToken(ElasticParser.GROUP, 0); }
		public TerminalNode TIES() { return getToken(ElasticParser.TIES, 0); }
		public TerminalNode NO() { return getToken(ElasticParser.NO, 0); }
		public TerminalNode OTHERS() { return getToken(ElasticParser.OTHERS, 0); }
		public TerminalNode CURRENT() { return getToken(ElasticParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(ElasticParser.ROW, 0); }
		public Frame_specContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_spec; }
	}

	public final Frame_specContext frame_spec() throws RecognitionException {
		Frame_specContext _localctx = new Frame_specContext(_ctx, getState());
		enterRule(_localctx, 112, RULE_frame_spec);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1106);
			frame_clause();
			setState(1114);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case EXCLUDE:
				{
				setState(1107);
				match(EXCLUDE);
				{
				setState(1108);
				match(NO);
				setState(1109);
				match(OTHERS);
				}
				}
				break;
			case CURRENT:
				{
				{
				setState(1110);
				match(CURRENT);
				setState(1111);
				match(ROW);
				}
				}
				break;
			case GROUP:
				{
				setState(1112);
				match(GROUP);
				}
				break;
			case TIES:
				{
				setState(1113);
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
		public TerminalNode RANGE() { return getToken(ElasticParser.RANGE, 0); }
		public TerminalNode ROWS() { return getToken(ElasticParser.ROWS, 0); }
		public TerminalNode GROUPS() { return getToken(ElasticParser.GROUPS, 0); }
		public Frame_singleContext frame_single() {
			return getRuleContext(Frame_singleContext.class,0);
		}
		public TerminalNode BETWEEN() { return getToken(ElasticParser.BETWEEN, 0); }
		public Frame_leftContext frame_left() {
			return getRuleContext(Frame_leftContext.class,0);
		}
		public TerminalNode AND() { return getToken(ElasticParser.AND, 0); }
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
		enterRule(_localctx, 114, RULE_frame_clause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1116);
			_la = _input.LA(1);
			if ( !(((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(1123);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,155,_ctx) ) {
			case 1:
				{
				setState(1117);
				frame_single();
				}
				break;
			case 2:
				{
				setState(1118);
				match(BETWEEN);
				setState(1119);
				frame_left();
				setState(1120);
				match(AND);
				setState(1121);
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

	public static class Common_table_stmtContext extends ParserRuleContext {
		public TerminalNode WITH() { return getToken(ElasticParser.WITH, 0); }
		public List<Common_table_expressionContext> common_table_expression() {
			return getRuleContexts(Common_table_expressionContext.class);
		}
		public Common_table_expressionContext common_table_expression(int i) {
			return getRuleContext(Common_table_expressionContext.class,i);
		}
		public TerminalNode RECURSIVE() { return getToken(ElasticParser.RECURSIVE, 0); }
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Common_table_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_common_table_stmt; }
	}

	public final Common_table_stmtContext common_table_stmt() throws RecognitionException {
		Common_table_stmtContext _localctx = new Common_table_stmtContext(_ctx, getState());
		enterRule(_localctx, 116, RULE_common_table_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1125);
			match(WITH);
			setState(1127);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,156,_ctx) ) {
			case 1:
				{
				setState(1126);
				match(RECURSIVE);
				}
				break;
			}
			setState(1129);
			common_table_expression();
			setState(1134);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1130);
				match(COMMA);
				setState(1131);
				common_table_expression();
				}
				}
				setState(1136);
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
		public TerminalNode ORDER() { return getToken(ElasticParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(ElasticParser.BY, 0); }
		public List<Ordering_termContext> ordering_term() {
			return getRuleContexts(Ordering_termContext.class);
		}
		public Ordering_termContext ordering_term(int i) {
			return getRuleContext(Ordering_termContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ElasticParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ElasticParser.COMMA, i);
		}
		public Order_by_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_by_stmt; }
	}

	public final Order_by_stmtContext order_by_stmt() throws RecognitionException {
		Order_by_stmtContext _localctx = new Order_by_stmtContext(_ctx, getState());
		enterRule(_localctx, 118, RULE_order_by_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1137);
			match(ORDER);
			setState(1138);
			match(BY);
			setState(1139);
			ordering_term();
			setState(1144);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(1140);
				match(COMMA);
				setState(1141);
				ordering_term();
				}
				}
				setState(1146);
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
		public TerminalNode LIMIT() { return getToken(ElasticParser.LIMIT, 0); }
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
		enterRule(_localctx, 120, RULE_limit_stmts);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1147);
			match(LIMIT);
			setState(1148);
			expr(0);
			setState(1150);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMMA || _la==OFFSET) {
				{
				setState(1149);
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
		public TerminalNode OFFSET() { return getToken(ElasticParser.OFFSET, 0); }
		public TerminalNode COMMA() { return getToken(ElasticParser.COMMA, 0); }
		public Limit_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_limit_stmt; }
	}

	public final Limit_stmtContext limit_stmt() throws RecognitionException {
		Limit_stmtContext _localctx = new Limit_stmtContext(_ctx, getState());
		enterRule(_localctx, 122, RULE_limit_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1152);
			_la = _input.LA(1);
			if ( !(_la==COMMA || _la==OFFSET) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(1153);
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
		public TerminalNode COLLATE() { return getToken(ElasticParser.COLLATE, 0); }
		public Collation_nameContext collation_name() {
			return getRuleContext(Collation_nameContext.class,0);
		}
		public Asc_descContext asc_desc() {
			return getRuleContext(Asc_descContext.class,0);
		}
		public TerminalNode NULLS() { return getToken(ElasticParser.NULLS, 0); }
		public TerminalNode FIRST() { return getToken(ElasticParser.FIRST, 0); }
		public TerminalNode LAST() { return getToken(ElasticParser.LAST, 0); }
		public Ordering_termContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ordering_term; }
	}

	public final Ordering_termContext ordering_term() throws RecognitionException {
		Ordering_termContext _localctx = new Ordering_termContext(_ctx, getState());
		enterRule(_localctx, 124, RULE_ordering_term);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1155);
			expr(0);
			setState(1158);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLLATE) {
				{
				setState(1156);
				match(COLLATE);
				setState(1157);
				collation_name();
				}
			}

			setState(1161);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASC || _la==DESC) {
				{
				setState(1160);
				asc_desc();
				}
			}

			setState(1165);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NULLS) {
				{
				setState(1163);
				match(NULLS);
				setState(1164);
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
		public TerminalNode ASC() { return getToken(ElasticParser.ASC, 0); }
		public TerminalNode DESC() { return getToken(ElasticParser.DESC, 0); }
		public Asc_descContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_asc_desc; }
	}

	public final Asc_descContext asc_desc() throws RecognitionException {
		Asc_descContext _localctx = new Asc_descContext(_ctx, getState());
		enterRule(_localctx, 126, RULE_asc_desc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1167);
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
		public TerminalNode PRECEDING() { return getToken(ElasticParser.PRECEDING, 0); }
		public TerminalNode FOLLOWING() { return getToken(ElasticParser.FOLLOWING, 0); }
		public TerminalNode CURRENT() { return getToken(ElasticParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(ElasticParser.ROW, 0); }
		public TerminalNode UNBOUNDED() { return getToken(ElasticParser.UNBOUNDED, 0); }
		public Frame_leftContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_left; }
	}

	public final Frame_leftContext frame_left() throws RecognitionException {
		Frame_leftContext _localctx = new Frame_leftContext(_ctx, getState());
		enterRule(_localctx, 128, RULE_frame_left);
		try {
			setState(1179);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,163,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1169);
				expr(0);
				setState(1170);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1172);
				expr(0);
				setState(1173);
				match(FOLLOWING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1175);
				match(CURRENT);
				setState(1176);
				match(ROW);
				}
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1177);
				match(UNBOUNDED);
				setState(1178);
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
		public TerminalNode PRECEDING() { return getToken(ElasticParser.PRECEDING, 0); }
		public TerminalNode FOLLOWING() { return getToken(ElasticParser.FOLLOWING, 0); }
		public TerminalNode CURRENT() { return getToken(ElasticParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(ElasticParser.ROW, 0); }
		public TerminalNode UNBOUNDED() { return getToken(ElasticParser.UNBOUNDED, 0); }
		public Frame_rightContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_right; }
	}

	public final Frame_rightContext frame_right() throws RecognitionException {
		Frame_rightContext _localctx = new Frame_rightContext(_ctx, getState());
		enterRule(_localctx, 130, RULE_frame_right);
		try {
			setState(1191);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,164,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1181);
				expr(0);
				setState(1182);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1184);
				expr(0);
				setState(1185);
				match(FOLLOWING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1187);
				match(CURRENT);
				setState(1188);
				match(ROW);
				}
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(1189);
				match(UNBOUNDED);
				setState(1190);
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
		public TerminalNode PRECEDING() { return getToken(ElasticParser.PRECEDING, 0); }
		public TerminalNode UNBOUNDED() { return getToken(ElasticParser.UNBOUNDED, 0); }
		public TerminalNode CURRENT() { return getToken(ElasticParser.CURRENT, 0); }
		public TerminalNode ROW() { return getToken(ElasticParser.ROW, 0); }
		public Frame_singleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_frame_single; }
	}

	public final Frame_singleContext frame_single() throws RecognitionException {
		Frame_singleContext _localctx = new Frame_singleContext(_ctx, getState());
		enterRule(_localctx, 132, RULE_frame_single);
		try {
			setState(1200);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,165,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(1193);
				expr(0);
				setState(1194);
				match(PRECEDING);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(1196);
				match(UNBOUNDED);
				setState(1197);
				match(PRECEDING);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(1198);
				match(CURRENT);
				setState(1199);
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
		public List<TerminalNode> OPEN_PAR() { return getTokens(ElasticParser.OPEN_PAR); }
		public TerminalNode OPEN_PAR(int i) {
			return getToken(ElasticParser.OPEN_PAR, i);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public List<TerminalNode> CLOSE_PAR() { return getTokens(ElasticParser.CLOSE_PAR); }
		public TerminalNode CLOSE_PAR(int i) {
			return getToken(ElasticParser.CLOSE_PAR, i);
		}
		public TerminalNode OVER() { return getToken(ElasticParser.OVER, 0); }
		public Order_by_expr_asc_descContext order_by_expr_asc_desc() {
			return getRuleContext(Order_by_expr_asc_descContext.class,0);
		}
		public TerminalNode FIRST_VALUE() { return getToken(ElasticParser.FIRST_VALUE, 0); }
		public TerminalNode LAST_VALUE() { return getToken(ElasticParser.LAST_VALUE, 0); }
		public Partition_byContext partition_by() {
			return getRuleContext(Partition_byContext.class,0);
		}
		public Frame_clauseContext frame_clause() {
			return getRuleContext(Frame_clauseContext.class,0);
		}
		public TerminalNode CUME_DIST() { return getToken(ElasticParser.CUME_DIST, 0); }
		public TerminalNode PERCENT_RANK() { return getToken(ElasticParser.PERCENT_RANK, 0); }
		public Order_by_exprContext order_by_expr() {
			return getRuleContext(Order_by_exprContext.class,0);
		}
		public TerminalNode DENSE_RANK() { return getToken(ElasticParser.DENSE_RANK, 0); }
		public TerminalNode RANK() { return getToken(ElasticParser.RANK, 0); }
		public TerminalNode ROW_NUMBER() { return getToken(ElasticParser.ROW_NUMBER, 0); }
		public TerminalNode LAG() { return getToken(ElasticParser.LAG, 0); }
		public TerminalNode LEAD() { return getToken(ElasticParser.LEAD, 0); }
		public OffsetContext offset() {
			return getRuleContext(OffsetContext.class,0);
		}
		public Default_valueContext default_value() {
			return getRuleContext(Default_valueContext.class,0);
		}
		public TerminalNode NTH_VALUE() { return getToken(ElasticParser.NTH_VALUE, 0); }
		public TerminalNode COMMA() { return getToken(ElasticParser.COMMA, 0); }
		public Signed_numberContext signed_number() {
			return getRuleContext(Signed_numberContext.class,0);
		}
		public TerminalNode NTILE() { return getToken(ElasticParser.NTILE, 0); }
		public Window_functionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_window_function; }
	}

	public final Window_functionContext window_function() throws RecognitionException {
		Window_functionContext _localctx = new Window_functionContext(_ctx, getState());
		enterRule(_localctx, 134, RULE_window_function);
		int _la;
		try {
			setState(1287);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case FIRST_VALUE:
			case LAST_VALUE:
				enterOuterAlt(_localctx, 1);
				{
				setState(1202);
				_la = _input.LA(1);
				if ( !(_la==FIRST_VALUE || _la==LAST_VALUE) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1203);
				match(OPEN_PAR);
				setState(1204);
				expr(0);
				setState(1205);
				match(CLOSE_PAR);
				setState(1206);
				match(OVER);
				setState(1207);
				match(OPEN_PAR);
				setState(1209);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1208);
					partition_by();
					}
				}

				setState(1211);
				order_by_expr_asc_desc();
				setState(1213);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1212);
					frame_clause();
					}
				}

				setState(1215);
				match(CLOSE_PAR);
				}
				break;
			case CUME_DIST:
			case PERCENT_RANK:
				enterOuterAlt(_localctx, 2);
				{
				setState(1217);
				_la = _input.LA(1);
				if ( !(_la==CUME_DIST || _la==PERCENT_RANK) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1218);
				match(OPEN_PAR);
				setState(1219);
				match(CLOSE_PAR);
				setState(1220);
				match(OVER);
				setState(1221);
				match(OPEN_PAR);
				setState(1223);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1222);
					partition_by();
					}
				}

				setState(1226);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ORDER) {
					{
					setState(1225);
					order_by_expr();
					}
				}

				setState(1228);
				match(CLOSE_PAR);
				}
				break;
			case DENSE_RANK:
			case RANK:
			case ROW_NUMBER:
				enterOuterAlt(_localctx, 3);
				{
				setState(1229);
				_la = _input.LA(1);
				if ( !(((((_la - 159)) & ~0x3f) == 0 && ((1L << (_la - 159)) & ((1L << (DENSE_RANK - 159)) | (1L << (RANK - 159)) | (1L << (ROW_NUMBER - 159)))) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1230);
				match(OPEN_PAR);
				setState(1231);
				match(CLOSE_PAR);
				setState(1232);
				match(OVER);
				setState(1233);
				match(OPEN_PAR);
				setState(1235);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1234);
					partition_by();
					}
				}

				setState(1237);
				order_by_expr_asc_desc();
				setState(1238);
				match(CLOSE_PAR);
				}
				break;
			case LAG:
			case LEAD:
				enterOuterAlt(_localctx, 4);
				{
				setState(1240);
				_la = _input.LA(1);
				if ( !(_la==LAG || _la==LEAD) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(1241);
				match(OPEN_PAR);
				setState(1242);
				expr(0);
				setState(1244);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,171,_ctx) ) {
				case 1:
					{
					setState(1243);
					offset();
					}
					break;
				}
				setState(1247);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COMMA) {
					{
					setState(1246);
					default_value();
					}
				}

				setState(1249);
				match(CLOSE_PAR);
				setState(1250);
				match(OVER);
				setState(1251);
				match(OPEN_PAR);
				setState(1253);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1252);
					partition_by();
					}
				}

				setState(1255);
				order_by_expr_asc_desc();
				setState(1256);
				match(CLOSE_PAR);
				}
				break;
			case NTH_VALUE:
				enterOuterAlt(_localctx, 5);
				{
				setState(1258);
				match(NTH_VALUE);
				setState(1259);
				match(OPEN_PAR);
				setState(1260);
				expr(0);
				setState(1261);
				match(COMMA);
				setState(1262);
				signed_number();
				setState(1263);
				match(CLOSE_PAR);
				setState(1264);
				match(OVER);
				setState(1265);
				match(OPEN_PAR);
				setState(1267);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1266);
					partition_by();
					}
				}

				setState(1269);
				order_by_expr_asc_desc();
				setState(1271);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (((((_la - 127)) & ~0x3f) == 0 && ((1L << (_la - 127)) & ((1L << (ROWS - 127)) | (1L << (RANGE - 127)) | (1L << (GROUPS - 127)))) != 0)) {
					{
					setState(1270);
					frame_clause();
					}
				}

				setState(1273);
				match(CLOSE_PAR);
				}
				break;
			case NTILE:
				enterOuterAlt(_localctx, 6);
				{
				setState(1275);
				match(NTILE);
				setState(1276);
				match(OPEN_PAR);
				setState(1277);
				expr(0);
				setState(1278);
				match(CLOSE_PAR);
				setState(1279);
				match(OVER);
				setState(1280);
				match(OPEN_PAR);
				setState(1282);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PARTITION) {
					{
					setState(1281);
					partition_by();
					}
				}

				setState(1284);
				order_by_expr_asc_desc();
				setState(1285);
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
		public TerminalNode COMMA() { return getToken(ElasticParser.COMMA, 0); }
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
		enterRule(_localctx, 136, RULE_offset);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1289);
			match(COMMA);
			setState(1290);
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
		public TerminalNode COMMA() { return getToken(ElasticParser.COMMA, 0); }
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
		enterRule(_localctx, 138, RULE_default_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1292);
			match(COMMA);
			setState(1293);
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
		public TerminalNode PARTITION() { return getToken(ElasticParser.PARTITION, 0); }
		public TerminalNode BY() { return getToken(ElasticParser.BY, 0); }
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
		enterRule(_localctx, 140, RULE_partition_by);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(1295);
			match(PARTITION);
			setState(1296);
			match(BY);
			setState(1298); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(1297);
					expr(0);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(1300); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,178,_ctx);
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
		public TerminalNode ORDER() { return getToken(ElasticParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(ElasticParser.BY, 0); }
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
		enterRule(_localctx, 142, RULE_order_by_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1302);
			match(ORDER);
			setState(1303);
			match(BY);
			setState(1305); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(1304);
				expr(0);
				}
				}
				setState(1307); 
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
		public TerminalNode ORDER() { return getToken(ElasticParser.ORDER, 0); }
		public TerminalNode BY() { return getToken(ElasticParser.BY, 0); }
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
		enterRule(_localctx, 144, RULE_order_by_expr_asc_desc);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1309);
			match(ORDER);
			setState(1310);
			match(BY);
			setState(1311);
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
		enterRule(_localctx, 146, RULE_initial_select);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1313);
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
		enterRule(_localctx, 148, RULE_recursive_select);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1315);
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
		public TerminalNode MINUS() { return getToken(ElasticParser.MINUS, 0); }
		public TerminalNode PLUS() { return getToken(ElasticParser.PLUS, 0); }
		public TerminalNode TILDE() { return getToken(ElasticParser.TILDE, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public Unary_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_operator; }
	}

	public final Unary_operatorContext unary_operator() throws RecognitionException {
		Unary_operatorContext _localctx = new Unary_operatorContext(_ctx, getState());
		enterRule(_localctx, 150, RULE_unary_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1317);
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
		public TerminalNode STRING_LITERAL() { return getToken(ElasticParser.STRING_LITERAL, 0); }
		public Error_messageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_error_message; }
	}

	public final Error_messageContext error_message() throws RecognitionException {
		Error_messageContext _localctx = new Error_messageContext(_ctx, getState());
		enterRule(_localctx, 152, RULE_error_message);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1319);
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
		enterRule(_localctx, 154, RULE_module_argument);
		try {
			setState(1323);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,180,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1321);
				expr(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1322);
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
		public TerminalNode IDENTIFIER() { return getToken(ElasticParser.IDENTIFIER, 0); }
		public TerminalNode STRING_LITERAL() { return getToken(ElasticParser.STRING_LITERAL, 0); }
		public Column_aliasContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_column_alias; }
	}

	public final Column_aliasContext column_alias() throws RecognitionException {
		Column_aliasContext _localctx = new Column_aliasContext(_ctx, getState());
		enterRule(_localctx, 156, RULE_column_alias);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1325);
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
		public TerminalNode ABORT() { return getToken(ElasticParser.ABORT, 0); }
		public TerminalNode ACTION() { return getToken(ElasticParser.ACTION, 0); }
		public TerminalNode ADD() { return getToken(ElasticParser.ADD, 0); }
		public TerminalNode AFTER() { return getToken(ElasticParser.AFTER, 0); }
		public TerminalNode ALL() { return getToken(ElasticParser.ALL, 0); }
		public TerminalNode ALTER() { return getToken(ElasticParser.ALTER, 0); }
		public TerminalNode ANALYZE() { return getToken(ElasticParser.ANALYZE, 0); }
		public TerminalNode AND() { return getToken(ElasticParser.AND, 0); }
		public TerminalNode AS() { return getToken(ElasticParser.AS, 0); }
		public TerminalNode ASC() { return getToken(ElasticParser.ASC, 0); }
		public TerminalNode ATTACH() { return getToken(ElasticParser.ATTACH, 0); }
		public TerminalNode AUTOINCREMENT() { return getToken(ElasticParser.AUTOINCREMENT, 0); }
		public TerminalNode BEFORE() { return getToken(ElasticParser.BEFORE, 0); }
		public TerminalNode BEGIN() { return getToken(ElasticParser.BEGIN, 0); }
		public TerminalNode BETWEEN() { return getToken(ElasticParser.BETWEEN, 0); }
		public TerminalNode BY() { return getToken(ElasticParser.BY, 0); }
		public TerminalNode CASCADE() { return getToken(ElasticParser.CASCADE, 0); }
		public TerminalNode CASE() { return getToken(ElasticParser.CASE, 0); }
		public TerminalNode CAST() { return getToken(ElasticParser.CAST, 0); }
		public TerminalNode CHECK() { return getToken(ElasticParser.CHECK, 0); }
		public TerminalNode COLLATE() { return getToken(ElasticParser.COLLATE, 0); }
		public TerminalNode COLUMN() { return getToken(ElasticParser.COLUMN, 0); }
		public TerminalNode COMMIT() { return getToken(ElasticParser.COMMIT, 0); }
		public TerminalNode CONFLICT() { return getToken(ElasticParser.CONFLICT, 0); }
		public TerminalNode CONSTRAINT() { return getToken(ElasticParser.CONSTRAINT, 0); }
		public TerminalNode CREATE() { return getToken(ElasticParser.CREATE, 0); }
		public TerminalNode CROSS() { return getToken(ElasticParser.CROSS, 0); }
		public TerminalNode CURRENT_DATE() { return getToken(ElasticParser.CURRENT_DATE, 0); }
		public TerminalNode CURRENT_TIME() { return getToken(ElasticParser.CURRENT_TIME, 0); }
		public TerminalNode CURRENT_TIMESTAMP() { return getToken(ElasticParser.CURRENT_TIMESTAMP, 0); }
		public TerminalNode DATABASE() { return getToken(ElasticParser.DATABASE, 0); }
		public TerminalNode DEFAULT() { return getToken(ElasticParser.DEFAULT, 0); }
		public TerminalNode DEFERRABLE() { return getToken(ElasticParser.DEFERRABLE, 0); }
		public TerminalNode DEFERRED() { return getToken(ElasticParser.DEFERRED, 0); }
		public TerminalNode DELETE() { return getToken(ElasticParser.DELETE, 0); }
		public TerminalNode DESC() { return getToken(ElasticParser.DESC, 0); }
		public TerminalNode DETACH() { return getToken(ElasticParser.DETACH, 0); }
		public TerminalNode DISTINCT() { return getToken(ElasticParser.DISTINCT, 0); }
		public TerminalNode DROP() { return getToken(ElasticParser.DROP, 0); }
		public TerminalNode EACH() { return getToken(ElasticParser.EACH, 0); }
		public TerminalNode ELSE() { return getToken(ElasticParser.ELSE, 0); }
		public TerminalNode END() { return getToken(ElasticParser.END, 0); }
		public TerminalNode ESCAPE() { return getToken(ElasticParser.ESCAPE, 0); }
		public TerminalNode EXCEPT() { return getToken(ElasticParser.EXCEPT, 0); }
		public TerminalNode EXCLUSIVE() { return getToken(ElasticParser.EXCLUSIVE, 0); }
		public TerminalNode EXISTS() { return getToken(ElasticParser.EXISTS, 0); }
		public TerminalNode EXPLAIN() { return getToken(ElasticParser.EXPLAIN, 0); }
		public TerminalNode FAIL() { return getToken(ElasticParser.FAIL, 0); }
		public TerminalNode FOR() { return getToken(ElasticParser.FOR, 0); }
		public TerminalNode FOREIGN() { return getToken(ElasticParser.FOREIGN, 0); }
		public TerminalNode FROM() { return getToken(ElasticParser.FROM, 0); }
		public TerminalNode FULL() { return getToken(ElasticParser.FULL, 0); }
		public TerminalNode GLOB() { return getToken(ElasticParser.GLOB, 0); }
		public TerminalNode GROUP() { return getToken(ElasticParser.GROUP, 0); }
		public TerminalNode HAVING() { return getToken(ElasticParser.HAVING, 0); }
		public TerminalNode IF() { return getToken(ElasticParser.IF, 0); }
		public TerminalNode IGNORE() { return getToken(ElasticParser.IGNORE, 0); }
		public TerminalNode IMMEDIATE() { return getToken(ElasticParser.IMMEDIATE, 0); }
		public TerminalNode IN() { return getToken(ElasticParser.IN, 0); }
		public TerminalNode INDEX() { return getToken(ElasticParser.INDEX, 0); }
		public TerminalNode INDEXED() { return getToken(ElasticParser.INDEXED, 0); }
		public TerminalNode INITIALLY() { return getToken(ElasticParser.INITIALLY, 0); }
		public TerminalNode INNER() { return getToken(ElasticParser.INNER, 0); }
		public TerminalNode INSERT() { return getToken(ElasticParser.INSERT, 0); }
		public TerminalNode INSTEAD() { return getToken(ElasticParser.INSTEAD, 0); }
		public TerminalNode INTERSECT() { return getToken(ElasticParser.INTERSECT, 0); }
		public TerminalNode INTO() { return getToken(ElasticParser.INTO, 0); }
		public TerminalNode IS() { return getToken(ElasticParser.IS, 0); }
		public TerminalNode ISNULL() { return getToken(ElasticParser.ISNULL, 0); }
		public TerminalNode JOIN() { return getToken(ElasticParser.JOIN, 0); }
		public TerminalNode KEY() { return getToken(ElasticParser.KEY, 0); }
		public TerminalNode LEFT() { return getToken(ElasticParser.LEFT, 0); }
		public TerminalNode LIKE() { return getToken(ElasticParser.LIKE, 0); }
		public TerminalNode LIMIT() { return getToken(ElasticParser.LIMIT, 0); }
		public TerminalNode MATCH() { return getToken(ElasticParser.MATCH, 0); }
		public TerminalNode NATURAL() { return getToken(ElasticParser.NATURAL, 0); }
		public TerminalNode NO() { return getToken(ElasticParser.NO, 0); }
		public TerminalNode NOT() { return getToken(ElasticParser.NOT, 0); }
		public TerminalNode NOTNULL() { return getToken(ElasticParser.NOTNULL, 0); }
		public TerminalNode NULL_() { return getToken(ElasticParser.NULL_, 0); }
		public TerminalNode OF() { return getToken(ElasticParser.OF, 0); }
		public TerminalNode OFFSET() { return getToken(ElasticParser.OFFSET, 0); }
		public TerminalNode ON() { return getToken(ElasticParser.ON, 0); }
		public TerminalNode OR() { return getToken(ElasticParser.OR, 0); }
		public TerminalNode ORDER() { return getToken(ElasticParser.ORDER, 0); }
		public TerminalNode OUTER() { return getToken(ElasticParser.OUTER, 0); }
		public TerminalNode PLAN() { return getToken(ElasticParser.PLAN, 0); }
		public TerminalNode PRAGMA() { return getToken(ElasticParser.PRAGMA, 0); }
		public TerminalNode PRIMARY() { return getToken(ElasticParser.PRIMARY, 0); }
		public TerminalNode QUERY() { return getToken(ElasticParser.QUERY, 0); }
		public TerminalNode RAISE() { return getToken(ElasticParser.RAISE, 0); }
		public TerminalNode RECURSIVE() { return getToken(ElasticParser.RECURSIVE, 0); }
		public TerminalNode REFERENCES() { return getToken(ElasticParser.REFERENCES, 0); }
		public TerminalNode REGEXP() { return getToken(ElasticParser.REGEXP, 0); }
		public TerminalNode REINDEX() { return getToken(ElasticParser.REINDEX, 0); }
		public TerminalNode RELEASE() { return getToken(ElasticParser.RELEASE, 0); }
		public TerminalNode RENAME() { return getToken(ElasticParser.RENAME, 0); }
		public TerminalNode REPLACE() { return getToken(ElasticParser.REPLACE, 0); }
		public TerminalNode RESTRICT() { return getToken(ElasticParser.RESTRICT, 0); }
		public TerminalNode RIGHT() { return getToken(ElasticParser.RIGHT, 0); }
		public TerminalNode ROLLBACK() { return getToken(ElasticParser.ROLLBACK, 0); }
		public TerminalNode ROW() { return getToken(ElasticParser.ROW, 0); }
		public TerminalNode ROWS() { return getToken(ElasticParser.ROWS, 0); }
		public TerminalNode SAVEPOINT() { return getToken(ElasticParser.SAVEPOINT, 0); }
		public TerminalNode SELECT() { return getToken(ElasticParser.SELECT, 0); }
		public TerminalNode SET() { return getToken(ElasticParser.SET, 0); }
		public TerminalNode TABLE() { return getToken(ElasticParser.TABLE, 0); }
		public TerminalNode TEMP() { return getToken(ElasticParser.TEMP, 0); }
		public TerminalNode TEMPORARY() { return getToken(ElasticParser.TEMPORARY, 0); }
		public TerminalNode THEN() { return getToken(ElasticParser.THEN, 0); }
		public TerminalNode TO() { return getToken(ElasticParser.TO, 0); }
		public TerminalNode TRANSACTION() { return getToken(ElasticParser.TRANSACTION, 0); }
		public TerminalNode TRIGGER() { return getToken(ElasticParser.TRIGGER, 0); }
		public TerminalNode UNION() { return getToken(ElasticParser.UNION, 0); }
		public TerminalNode UNIQUE() { return getToken(ElasticParser.UNIQUE, 0); }
		public TerminalNode UPDATE() { return getToken(ElasticParser.UPDATE, 0); }
		public TerminalNode USING() { return getToken(ElasticParser.USING, 0); }
		public TerminalNode VACUUM() { return getToken(ElasticParser.VACUUM, 0); }
		public TerminalNode VALUES() { return getToken(ElasticParser.VALUES, 0); }
		public TerminalNode VIEW() { return getToken(ElasticParser.VIEW, 0); }
		public TerminalNode VIRTUAL() { return getToken(ElasticParser.VIRTUAL, 0); }
		public TerminalNode WHEN() { return getToken(ElasticParser.WHEN, 0); }
		public TerminalNode WHERE() { return getToken(ElasticParser.WHERE, 0); }
		public TerminalNode WITH() { return getToken(ElasticParser.WITH, 0); }
		public TerminalNode WITHOUT() { return getToken(ElasticParser.WITHOUT, 0); }
		public TerminalNode FIRST_VALUE() { return getToken(ElasticParser.FIRST_VALUE, 0); }
		public TerminalNode OVER() { return getToken(ElasticParser.OVER, 0); }
		public TerminalNode PARTITION() { return getToken(ElasticParser.PARTITION, 0); }
		public TerminalNode RANGE() { return getToken(ElasticParser.RANGE, 0); }
		public TerminalNode PRECEDING() { return getToken(ElasticParser.PRECEDING, 0); }
		public TerminalNode UNBOUNDED() { return getToken(ElasticParser.UNBOUNDED, 0); }
		public TerminalNode CURRENT() { return getToken(ElasticParser.CURRENT, 0); }
		public TerminalNode FOLLOWING() { return getToken(ElasticParser.FOLLOWING, 0); }
		public TerminalNode CUME_DIST() { return getToken(ElasticParser.CUME_DIST, 0); }
		public TerminalNode DENSE_RANK() { return getToken(ElasticParser.DENSE_RANK, 0); }
		public TerminalNode LAG() { return getToken(ElasticParser.LAG, 0); }
		public TerminalNode LAST_VALUE() { return getToken(ElasticParser.LAST_VALUE, 0); }
		public TerminalNode LEAD() { return getToken(ElasticParser.LEAD, 0); }
		public TerminalNode NTH_VALUE() { return getToken(ElasticParser.NTH_VALUE, 0); }
		public TerminalNode NTILE() { return getToken(ElasticParser.NTILE, 0); }
		public TerminalNode PERCENT_RANK() { return getToken(ElasticParser.PERCENT_RANK, 0); }
		public TerminalNode RANK() { return getToken(ElasticParser.RANK, 0); }
		public TerminalNode ROW_NUMBER() { return getToken(ElasticParser.ROW_NUMBER, 0); }
		public TerminalNode GENERATED() { return getToken(ElasticParser.GENERATED, 0); }
		public TerminalNode ALWAYS() { return getToken(ElasticParser.ALWAYS, 0); }
		public TerminalNode STORED() { return getToken(ElasticParser.STORED, 0); }
		public TerminalNode TRUE_() { return getToken(ElasticParser.TRUE_, 0); }
		public TerminalNode FALSE_() { return getToken(ElasticParser.FALSE_, 0); }
		public TerminalNode WINDOW() { return getToken(ElasticParser.WINDOW, 0); }
		public TerminalNode NULLS() { return getToken(ElasticParser.NULLS, 0); }
		public TerminalNode FIRST() { return getToken(ElasticParser.FIRST, 0); }
		public TerminalNode LAST() { return getToken(ElasticParser.LAST, 0); }
		public TerminalNode FILTER() { return getToken(ElasticParser.FILTER, 0); }
		public TerminalNode GROUPS() { return getToken(ElasticParser.GROUPS, 0); }
		public TerminalNode EXCLUDE() { return getToken(ElasticParser.EXCLUDE, 0); }
		public KeywordContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_keyword; }
	}

	public final KeywordContext keyword() throws RecognitionException {
		KeywordContext _localctx = new KeywordContext(_ctx, getState());
		enterRule(_localctx, 158, RULE_keyword);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1327);
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
		enterRule(_localctx, 160, RULE_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1329);
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
		enterRule(_localctx, 162, RULE_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1331);
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
		enterRule(_localctx, 164, RULE_schema_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1333);
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
		enterRule(_localctx, 166, RULE_table_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1335);
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
		enterRule(_localctx, 168, RULE_column_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1337);
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
		enterRule(_localctx, 170, RULE_collation_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1339);
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
		enterRule(_localctx, 172, RULE_foreign_table);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1341);
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
		enterRule(_localctx, 174, RULE_index_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1343);
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
		enterRule(_localctx, 176, RULE_view_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1345);
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
		enterRule(_localctx, 178, RULE_module_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1347);
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
		enterRule(_localctx, 180, RULE_table_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1349);
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
		enterRule(_localctx, 182, RULE_window_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1351);
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
		enterRule(_localctx, 184, RULE_alias);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1353);
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
		enterRule(_localctx, 186, RULE_base_window_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1355);
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
		enterRule(_localctx, 188, RULE_simple_func);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1357);
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
		enterRule(_localctx, 190, RULE_aggregate_func);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1359);
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
		enterRule(_localctx, 192, RULE_table_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1361);
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
		public TerminalNode IDENTIFIER() { return getToken(ElasticParser.IDENTIFIER, 0); }
		public KeywordContext keyword() {
			return getRuleContext(KeywordContext.class,0);
		}
		public TerminalNode STRING_LITERAL() { return getToken(ElasticParser.STRING_LITERAL, 0); }
		public TerminalNode OPEN_PAR() { return getToken(ElasticParser.OPEN_PAR, 0); }
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public TerminalNode CLOSE_PAR() { return getToken(ElasticParser.CLOSE_PAR, 0); }
		public Any_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_any_name; }
	}

	public final Any_nameContext any_name() throws RecognitionException {
		Any_nameContext _localctx = new Any_nameContext(_ctx, getState());
		enterRule(_localctx, 194, RULE_any_name);
		try {
			setState(1370);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(1363);
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
				setState(1364);
				keyword();
				}
				break;
			case STRING_LITERAL:
				enterOuterAlt(_localctx, 3);
				{
				setState(1365);
				match(STRING_LITERAL);
				}
				break;
			case OPEN_PAR:
				enterOuterAlt(_localctx, 4);
				{
				setState(1366);
				match(OPEN_PAR);
				setState(1367);
				any_name();
				setState(1368);
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
		case 20:
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\u00c2\u055f\4\2\t"+
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
		"`\t`\4a\ta\4b\tb\4c\tc\3\2\3\2\7\2\u00c9\n\2\f\2\16\2\u00cc\13\2\3\2\3"+
		"\2\3\3\3\3\3\3\3\4\7\4\u00d4\n\4\f\4\16\4\u00d7\13\4\3\4\3\4\6\4\u00db"+
		"\n\4\r\4\16\4\u00dc\3\4\7\4\u00e0\n\4\f\4\16\4\u00e3\13\4\3\4\7\4\u00e6"+
		"\n\4\f\4\16\4\u00e9\13\4\3\5\3\5\3\5\5\5\u00ee\n\5\5\5\u00f0\n\5\3\5\3"+
		"\5\3\5\3\5\3\5\5\5\u00f7\n\5\3\6\3\6\3\6\3\7\3\7\5\7\u00fe\n\7\3\7\3\7"+
		"\5\7\u0102\n\7\3\7\5\7\u0105\n\7\3\b\3\b\5\b\u0109\n\b\3\b\3\b\3\b\3\b"+
		"\5\b\u010f\n\b\3\b\3\b\3\b\5\b\u0114\n\b\3\b\3\b\3\b\3\b\3\b\7\b\u011b"+
		"\n\b\f\b\16\b\u011e\13\b\3\b\3\b\7\b\u0122\n\b\f\b\16\b\u0125\13\b\3\b"+
		"\3\b\3\b\5\b\u012a\n\b\3\b\3\b\5\b\u012e\n\b\3\t\3\t\5\t\u0132\n\t\3\t"+
		"\7\t\u0135\n\t\f\t\16\t\u0138\13\t\3\n\6\n\u013b\n\n\r\n\16\n\u013c\3"+
		"\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\5\n\u0149\n\n\3\13\3\13\5\13\u014d"+
		"\n\13\3\13\3\13\3\13\5\13\u0152\n\13\3\13\5\13\u0155\n\13\3\13\5\13\u0158"+
		"\n\13\3\13\3\13\3\13\5\13\u015d\n\13\3\13\5\13\u0160\n\13\3\13\3\13\3"+
		"\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\5\13\u016e\n\13\3\13"+
		"\3\13\3\13\3\13\3\13\5\13\u0175\n\13\3\13\3\13\3\13\3\13\3\13\5\13\u017c"+
		"\n\13\5\13\u017e\n\13\3\f\5\f\u0181\n\f\3\f\3\f\3\r\3\r\5\r\u0187\n\r"+
		"\3\r\3\r\3\r\5\r\u018c\n\r\3\r\3\r\3\r\3\r\7\r\u0192\n\r\f\r\16\r\u0195"+
		"\13\r\3\r\3\r\5\r\u0199\n\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\5"+
		"\r\u01a5\n\r\3\16\3\16\3\16\5\16\u01aa\n\16\3\16\3\16\3\16\3\16\3\16\3"+
		"\16\3\16\3\16\5\16\u01b4\n\16\3\16\3\16\7\16\u01b8\n\16\f\16\16\16\u01bb"+
		"\13\16\3\16\5\16\u01be\n\16\3\16\3\16\3\16\5\16\u01c3\n\16\5\16\u01c5"+
		"\n\16\3\17\3\17\3\17\3\17\3\20\3\20\5\20\u01cd\n\20\3\20\3\20\3\20\3\20"+
		"\5\20\u01d3\n\20\3\20\3\20\3\20\5\20\u01d8\n\20\3\20\3\20\5\20\u01dc\n"+
		"\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u01e7\n\21\3\21"+
		"\3\21\3\21\5\21\u01ec\n\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\7\21\u01f5"+
		"\n\21\f\21\16\21\u01f8\13\21\3\21\3\21\5\21\u01fc\n\21\3\22\3\22\5\22"+
		"\u0200\n\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\7\22\u020e\n\22\f\22\16\22\u0211\13\22\3\23\3\23\5\23\u0215\n\23\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\5\24\u021d\n\24\3\24\3\24\3\24\3\25\3\25\5\25"+
		"\u0224\n\25\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\5\26\u0240\n\26\3\26\3\26\5\26\u0244\n\26\3\26\3\26\3\26\3\26\3\26\3"+
		"\26\5\26\u024c\n\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\5\26\u025c\n\26\3\26\3\26\3\26\3\26\5\26\u0262\n"+
		"\26\7\26\u0264\n\26\f\26\16\26\u0267\13\26\3\27\3\27\3\27\5\27\u026c\n"+
		"\27\3\27\3\27\5\27\u0270\n\27\3\27\3\27\5\27\u0274\n\27\3\27\5\27\u0277"+
		"\n\27\3\30\5\30\u027a\n\30\3\30\3\30\3\30\3\30\5\30\u0280\n\30\3\30\3"+
		"\30\3\30\3\30\5\30\u0286\n\30\3\30\3\30\3\30\3\30\5\30\u028c\n\30\3\30"+
		"\3\30\3\30\5\30\u0291\n\30\3\30\3\30\5\30\u0295\n\30\3\31\3\31\6\31\u0299"+
		"\n\31\r\31\16\31\u029a\3\31\5\31\u029e\n\31\3\31\3\31\3\32\3\32\3\32\3"+
		"\32\3\32\3\33\3\33\5\33\u02a9\n\33\3\34\3\34\3\34\3\35\5\35\u02af\n\35"+
		"\3\35\5\35\u02b2\n\35\3\35\3\35\3\35\3\35\3\36\3\36\3\36\3\36\5\36\u02bc"+
		"\n\36\3\37\3\37\3\37\5\37\u02c1\n\37\3\37\3\37\3\37\5\37\u02c6\n\37\3"+
		"\37\3\37\3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \3 \5 \u02d8\n \3 \5 \u02db"+
		"\n \3!\3!\3\"\3\"\3\"\3\"\3\"\3\"\5\"\u02e5\n\"\3\"\3\"\3#\3#\3$\5$\u02ec"+
		"\n$\3$\3$\3$\3$\3$\5$\u02f3\n$\3$\3$\3$\3$\5$\u02f9\n$\3$\3$\3$\5$\u02fe"+
		"\n$\3$\5$\u0301\n$\3$\3$\3$\5$\u0306\n$\3$\5$\u0309\n$\3$\3$\5$\u030d"+
		"\n$\3%\3%\3%\3%\3%\3%\7%\u0315\n%\f%\16%\u0318\13%\3%\3%\5%\u031c\n%\5"+
		"%\u031e\n%\3%\3%\3%\3%\3%\3%\5%\u0326\n%\3%\3%\3%\3%\3%\5%\u032d\n%\3"+
		"%\3%\3%\7%\u0332\n%\f%\16%\u0335\13%\3%\5%\u0338\n%\5%\u033a\n%\3&\5&"+
		"\u033d\n&\3&\3&\7&\u0341\n&\f&\16&\u0344\13&\3&\5&\u0347\n&\3&\5&\u034a"+
		"\n&\3\'\3\'\3\'\3(\3(\6(\u0351\n(\r(\16(\u0352\3)\3)\3)\5)\u0358\n)\3"+
		"*\3*\5*\u035c\n*\3*\3*\3*\7*\u0361\n*\f*\16*\u0364\13*\3*\3*\5*\u0368"+
		"\n*\3*\5*\u036b\n*\3*\5*\u036e\n*\3*\3*\3*\3*\7*\u0374\n*\f*\16*\u0377"+
		"\13*\5*\u0379\n*\3*\3*\5*\u037d\n*\3+\3+\3+\3+\3+\3+\3+\3+\7+\u0387\n"+
		"+\f+\16+\u038a\13+\3,\3,\3,\3,\5,\u0390\n,\3-\3-\3-\3.\3.\3.\3.\3/\3/"+
		"\3/\7/\u039c\n/\f/\16/\u039f\13/\3\60\3\60\3\60\5\60\u03a4\n\60\3\60\3"+
		"\60\5\60\u03a8\n\60\3\60\5\60\u03ab\n\60\3\60\3\60\3\60\3\60\3\60\5\60"+
		"\u03b2\n\60\3\60\3\60\3\60\5\60\u03b7\n\60\3\60\3\60\3\60\3\60\3\60\7"+
		"\60\u03be\n\60\f\60\16\60\u03c1\13\60\3\60\3\60\5\60\u03c5\n\60\3\60\5"+
		"\60\u03c8\n\60\3\60\3\60\3\60\3\60\3\60\3\60\3\60\3\60\5\60\u03d2\n\60"+
		"\3\60\5\60\u03d5\n\60\5\60\u03d7\n\60\3\61\3\61\3\61\7\61\u03dc\n\61\f"+
		"\61\16\61\u03df\13\61\3\61\5\61\u03e2\n\61\3\62\3\62\3\62\3\62\3\62\3"+
		"\62\3\62\5\62\u03eb\n\62\3\62\5\62\u03ee\n\62\5\62\u03f0\n\62\3\63\3\63"+
		"\5\63\u03f4\n\63\3\63\3\63\5\63\u03f8\n\63\3\63\3\63\5\63\u03fc\n\63\3"+
		"\63\5\63\u03ff\n\63\3\64\3\64\3\64\3\64\5\64\u0405\n\64\3\65\3\65\5\65"+
		"\u0409\n\65\3\65\3\65\5\65\u040d\n\65\3\66\3\66\3\66\3\66\7\66\u0413\n"+
		"\66\f\66\16\66\u0416\13\66\3\66\3\66\3\67\3\67\3\67\3\67\3\67\3\67\38"+
		"\38\58\u0422\n8\38\38\38\58\u0427\n8\38\38\38\38\38\78\u042e\n8\f8\16"+
		"8\u0431\138\38\58\u0434\n8\38\38\39\39\39\39\59\u043c\n9\39\39\39\59\u0441"+
		"\n9\39\39\39\39\39\79\u0448\n9\f9\169\u044b\139\59\u044d\n9\39\59\u0450"+
		"\n9\39\59\u0453\n9\3:\3:\3:\3:\3:\3:\3:\3:\5:\u045d\n:\3;\3;\3;\3;\3;"+
		"\3;\3;\5;\u0466\n;\3<\3<\5<\u046a\n<\3<\3<\3<\7<\u046f\n<\f<\16<\u0472"+
		"\13<\3=\3=\3=\3=\3=\7=\u0479\n=\f=\16=\u047c\13=\3>\3>\3>\5>\u0481\n>"+
		"\3?\3?\3?\3@\3@\3@\5@\u0489\n@\3@\5@\u048c\n@\3@\3@\5@\u0490\n@\3A\3A"+
		"\3B\3B\3B\3B\3B\3B\3B\3B\3B\3B\5B\u049e\nB\3C\3C\3C\3C\3C\3C\3C\3C\3C"+
		"\3C\5C\u04aa\nC\3D\3D\3D\3D\3D\3D\3D\5D\u04b3\nD\3E\3E\3E\3E\3E\3E\3E"+
		"\5E\u04bc\nE\3E\3E\5E\u04c0\nE\3E\3E\3E\3E\3E\3E\3E\3E\5E\u04ca\nE\3E"+
		"\5E\u04cd\nE\3E\3E\3E\3E\3E\3E\3E\5E\u04d6\nE\3E\3E\3E\3E\3E\3E\3E\5E"+
		"\u04df\nE\3E\5E\u04e2\nE\3E\3E\3E\3E\5E\u04e8\nE\3E\3E\3E\3E\3E\3E\3E"+
		"\3E\3E\3E\3E\3E\5E\u04f6\nE\3E\3E\5E\u04fa\nE\3E\3E\3E\3E\3E\3E\3E\3E"+
		"\3E\5E\u0505\nE\3E\3E\3E\5E\u050a\nE\3F\3F\3F\3G\3G\3G\3H\3H\3H\6H\u0515"+
		"\nH\rH\16H\u0516\3I\3I\3I\6I\u051c\nI\rI\16I\u051d\3J\3J\3J\3J\3K\3K\3"+
		"L\3L\3M\3M\3N\3N\3O\3O\5O\u052e\nO\3P\3P\3Q\3Q\3R\3R\3S\3S\3T\3T\3U\3"+
		"U\3V\3V\3W\3W\3X\3X\3Y\3Y\3Z\3Z\3[\3[\3\\\3\\\3]\3]\3^\3^\3_\3_\3`\3`"+
		"\3a\3a\3b\3b\3c\3c\3c\3c\3c\3c\3c\5c\u055d\nc\3c\2\3*d\2\4\6\b\n\f\16"+
		"\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<>@BDFHJLNPRTVXZ\\^`bd"+
		"fhjlnprtvxz|~\u0080\u0082\u0084\u0086\u0088\u008a\u008c\u008e\u0090\u0092"+
		"\u0094\u0096\u0098\u009a\u009c\u009e\u00a0\u00a2\u00a4\u00a6\u00a8\u00aa"+
		"\u00ac\u00ae\u00b0\u00b2\u00b4\u00b6\u00b8\u00ba\u00bc\u00be\u00c0\u00c2"+
		"\u00c4\2\33\3\2\u0086\u0087\4\2\u0093\u0093\u00ac\u00ac\3\2\n\13\4\2="+
		"=\u008e\u008e\4\2::jj\4\2<<TT\7\2\33\33JJSS||\177\177\4\2\t\t\16\17\3"+
		"\2\20\23\3\2\24\27\6\2OOcceexx\5\2\33\33JJ\177\177\7\2\668jj\u00ad\u00ae"+
		"\u00bb\u00bb\u00bd\u00be\4\2\37\37@@\5\2\u0081\u0081\u009b\u009b\u00b4"+
		"\u00b4\4\2\7\7ll\3\2\u00b1\u00b2\4\2$$>>\4\2\u0098\u0098\u00a3\u00a3\4"+
		"\2\u00a0\u00a0\u00a7\u00a7\4\2\u00a1\u00a1\u00a8\u00a9\4\2\u00a2\u00a2"+
		"\u00a4\u00a4\4\2\n\fhh\4\2\u00ba\u00ba\u00bd\u00bd\3\2\33\u00b5\2\u05f1"+
		"\2\u00ca\3\2\2\2\4\u00cf\3\2\2\2\6\u00d5\3\2\2\2\b\u00ef\3\2\2\2\n\u00f8"+
		"\3\2\2\2\f\u00fd\3\2\2\2\16\u0106\3\2\2\2\20\u012f\3\2\2\2\22\u013a\3"+
		"\2\2\2\24\u014c\3\2\2\2\26\u0180\3\2\2\2\30\u0186\3\2\2\2\32\u01a6\3\2"+
		"\2\2\34\u01c6\3\2\2\2\36\u01ca\3\2\2\2 \u01e0\3\2\2\2\"\u01fd\3\2\2\2"+
		"$\u0212\3\2\2\2&\u0216\3\2\2\2(\u0221\3\2\2\2*\u0243\3\2\2\2,\u0268\3"+
		"\2\2\2.\u0279\3\2\2\2\60\u0296\3\2\2\2\62\u02a1\3\2\2\2\64\u02a6\3\2\2"+
		"\2\66\u02aa\3\2\2\28\u02b1\3\2\2\2:\u02bb\3\2\2\2<\u02c5\3\2\2\2>\u02da"+
		"\3\2\2\2@\u02dc\3\2\2\2B\u02de\3\2\2\2D\u02e8\3\2\2\2F\u030c\3\2\2\2H"+
		"\u030e\3\2\2\2J\u033c\3\2\2\2L\u034b\3\2\2\2N\u034e\3\2\2\2P\u0354\3\2"+
		"\2\2R\u037c\3\2\2\2T\u037e\3\2\2\2V\u038b\3\2\2\2X\u0391\3\2\2\2Z\u0394"+
		"\3\2\2\2\\\u0398\3\2\2\2^\u03d6\3\2\2\2`\u03e1\3\2\2\2b\u03ef\3\2\2\2"+
		"d\u03fe\3\2\2\2f\u0404\3\2\2\2h\u040c\3\2\2\2j\u040e\3\2\2\2l\u0419\3"+
		"\2\2\2n\u041f\3\2\2\2p\u0437\3\2\2\2r\u0454\3\2\2\2t\u045e\3\2\2\2v\u0467"+
		"\3\2\2\2x\u0473\3\2\2\2z\u047d\3\2\2\2|\u0482\3\2\2\2~\u0485\3\2\2\2\u0080"+
		"\u0491\3\2\2\2\u0082\u049d\3\2\2\2\u0084\u04a9\3\2\2\2\u0086\u04b2\3\2"+
		"\2\2\u0088\u0509\3\2\2\2\u008a\u050b\3\2\2\2\u008c\u050e\3\2\2\2\u008e"+
		"\u0511\3\2\2\2\u0090\u0518\3\2\2\2\u0092\u051f\3\2\2\2\u0094\u0523\3\2"+
		"\2\2\u0096\u0525\3\2\2\2\u0098\u0527\3\2\2\2\u009a\u0529\3\2\2\2\u009c"+
		"\u052d\3\2\2\2\u009e\u052f\3\2\2\2\u00a0\u0531\3\2\2\2\u00a2\u0533\3\2"+
		"\2\2\u00a4\u0535\3\2\2\2\u00a6\u0537\3\2\2\2\u00a8\u0539\3\2\2\2\u00aa"+
		"\u053b\3\2\2\2\u00ac\u053d\3\2\2\2\u00ae\u053f\3\2\2\2\u00b0\u0541\3\2"+
		"\2\2\u00b2\u0543\3\2\2\2\u00b4\u0545\3\2\2\2\u00b6\u0547\3\2\2\2\u00b8"+
		"\u0549\3\2\2\2\u00ba\u054b\3\2\2\2\u00bc\u054d\3\2\2\2\u00be\u054f\3\2"+
		"\2\2\u00c0\u0551\3\2\2\2\u00c2\u0553\3\2\2\2\u00c4\u055c\3\2\2\2\u00c6"+
		"\u00c9\5\6\4\2\u00c7\u00c9\5\4\3\2\u00c8\u00c6\3\2\2\2\u00c8\u00c7\3\2"+
		"\2\2\u00c9\u00cc\3\2\2\2\u00ca\u00c8\3\2\2\2\u00ca\u00cb\3\2\2\2\u00cb"+
		"\u00cd\3\2\2\2\u00cc\u00ca\3\2\2\2\u00cd\u00ce\7\2\2\3\u00ce\3\3\2\2\2"+
		"\u00cf\u00d0\7\u00c2\2\2\u00d0\u00d1\b\3\1\2\u00d1\5\3\2\2\2\u00d2\u00d4"+
		"\7\3\2\2\u00d3\u00d2\3\2\2\2\u00d4\u00d7\3\2\2\2\u00d5\u00d3\3\2\2\2\u00d5"+
		"\u00d6\3\2\2\2\u00d6\u00d8\3\2\2\2\u00d7\u00d5\3\2\2\2\u00d8\u00e1\5\b"+
		"\5\2\u00d9\u00db\7\3\2\2\u00da\u00d9\3\2\2\2\u00db\u00dc\3\2\2\2\u00dc"+
		"\u00da\3\2\2\2\u00dc\u00dd\3\2\2\2\u00dd\u00de\3\2\2\2\u00de\u00e0\5\b"+
		"\5\2\u00df\u00da\3\2\2\2\u00e0\u00e3\3\2\2\2\u00e1\u00df\3\2\2\2\u00e1"+
		"\u00e2\3\2\2\2\u00e2\u00e7\3\2\2\2\u00e3\u00e1\3\2\2\2\u00e4\u00e6\7\3"+
		"\2\2\u00e5\u00e4\3\2\2\2\u00e6\u00e9\3\2\2\2\u00e7\u00e5\3\2\2\2\u00e7"+
		"\u00e8\3\2\2\2\u00e8\7\3\2\2\2\u00e9\u00e7\3\2\2\2\u00ea\u00ed\7I\2\2"+
		"\u00eb\u00ec\7t\2\2\u00ec\u00ee\7q\2\2\u00ed\u00eb\3\2\2\2\u00ed\u00ee"+
		"\3\2\2\2\u00ee\u00f0\3\2\2\2\u00ef\u00ea\3\2\2\2\u00ef\u00f0\3\2\2\2\u00f0"+
		"\u00f6\3\2\2\2\u00f1\u00f7\5\16\b\2\u00f2\u00f7\5\36\20\2\u00f3\u00f7"+
		"\5 \21\2\u00f4\u00f7\5F$\2\u00f5\u00f7\5J&\2\u00f6\u00f1\3\2\2\2\u00f6"+
		"\u00f2\3\2\2\2\u00f6\u00f3\3\2\2\2\u00f6\u00f4\3\2\2\2\u00f6\u00f5\3\2"+
		"\2\2\u00f7\t\3\2\2\2\u00f8\u00f9\7\u0095\2\2\u00f9\u00fa\5*\26\2\u00fa"+
		"\13\3\2\2\2\u00fb\u00fe\5\u00aaV\2\u00fc\u00fe\5*\26\2\u00fd\u00fb\3\2"+
		"\2\2\u00fd\u00fc\3\2\2\2\u00fe\u0101\3\2\2\2\u00ff\u0100\7/\2\2\u0100"+
		"\u0102\5\u00acW\2\u0101\u00ff\3\2\2\2\u0101\u0102\3\2\2\2\u0102\u0104"+
		"\3\2\2\2\u0103\u0105\5\u0080A\2\u0104\u0103\3\2\2\2\u0104\u0105\3\2\2"+
		"\2\u0105\r\3\2\2\2\u0106\u0108\7\64\2\2\u0107\u0109\t\2\2\2\u0108\u0107"+
		"\3\2\2\2\u0108\u0109\3\2\2\2\u0109\u010a\3\2\2\2\u010a\u010e\7\u0085\2"+
		"\2\u010b\u010c\7R\2\2\u010c\u010d\7h\2\2\u010d\u010f\7H\2\2\u010e\u010b"+
		"\3\2\2\2\u010e\u010f\3\2\2\2\u010f\u0113\3\2\2\2\u0110\u0111\5\u00a6T"+
		"\2\u0111\u0112\7\4\2\2\u0112\u0114\3\2\2\2\u0113\u0110\3\2\2\2\u0113\u0114"+
		"\3\2\2\2\u0114\u0115\3\2\2\2\u0115\u012d\5\u00a8U\2\u0116\u0117\7\5\2"+
		"\2\u0117\u011c\5\20\t\2\u0118\u0119\7\7\2\2\u0119\u011b\5\20\t\2\u011a"+
		"\u0118\3\2\2\2\u011b\u011e\3\2\2\2\u011c\u011a\3\2\2\2\u011c\u011d\3\2"+
		"\2\2\u011d\u0123\3\2\2\2\u011e\u011c\3\2\2\2\u011f\u0120\7\7\2\2\u0120"+
		"\u0122\5\30\r\2\u0121\u011f\3\2\2\2\u0122\u0125\3\2\2\2\u0123\u0121\3"+
		"\2\2\2\u0123\u0124\3\2\2\2\u0124\u0126\3\2\2\2\u0125\u0123\3\2\2\2\u0126"+
		"\u0129\7\6\2\2\u0127\u0128\7\u0097\2\2\u0128\u012a\7\u00ba\2\2\u0129\u0127"+
		"\3\2\2\2\u0129\u012a\3\2\2\2\u012a\u012e\3\2\2\2\u012b\u012c\7#\2\2\u012c"+
		"\u012e\5J&\2\u012d\u0116\3\2\2\2\u012d\u012b\3\2\2\2\u012e\17\3\2\2\2"+
		"\u012f\u0131\5\u00aaV\2\u0130\u0132\5\22\n\2\u0131\u0130\3\2\2\2\u0131"+
		"\u0132\3\2\2\2\u0132\u0136\3\2\2\2\u0133\u0135\5\24\13\2\u0134\u0133\3"+
		"\2\2\2\u0135\u0138\3\2\2\2\u0136\u0134\3\2\2\2\u0136\u0137\3\2\2\2\u0137"+
		"\21\3\2\2\2\u0138\u0136\3\2\2\2\u0139\u013b\5\u00a2R\2\u013a\u0139\3\2"+
		"\2\2\u013b\u013c\3\2\2\2\u013c\u013a\3\2\2\2\u013c\u013d\3\2\2\2\u013d"+
		"\u0148\3\2\2\2\u013e\u013f\7\5\2\2\u013f\u0140\5\26\f\2\u0140\u0141\7"+
		"\6\2\2\u0141\u0149\3\2\2\2\u0142\u0143\7\5\2\2\u0143\u0144\5\26\f\2\u0144"+
		"\u0145\7\7\2\2\u0145\u0146\5\26\f\2\u0146\u0147\7\6\2\2\u0147\u0149\3"+
		"\2\2\2\u0148\u013e\3\2\2\2\u0148\u0142\3\2\2\2\u0148\u0149\3\2\2\2\u0149"+
		"\23\3\2\2\2\u014a\u014b\7\63\2\2\u014b\u014d\5\u00a2R\2\u014c\u014a\3"+
		"\2\2\2\u014c\u014d\3\2\2\2\u014d\u017d\3\2\2\2\u014e\u014f\7s\2\2\u014f"+
		"\u0151\7a\2\2\u0150\u0152\5\u0080A\2\u0151\u0150\3\2\2\2\u0151\u0152\3"+
		"\2\2\2\u0152\u0154\3\2\2\2\u0153\u0155\5\34\17\2\u0154\u0153\3\2\2\2\u0154"+
		"\u0155\3\2\2\2\u0155\u0157\3\2\2\2\u0156\u0158\7&\2\2\u0157\u0156\3\2"+
		"\2\2\u0157\u0158\3\2\2\2\u0158\u017e\3\2\2\2\u0159\u015a\7h\2\2\u015a"+
		"\u015d\7j\2\2\u015b\u015d\7\u008d\2\2\u015c\u0159\3\2\2\2\u015c\u015b"+
		"\3\2\2\2\u015d\u015f\3\2\2\2\u015e\u0160\5\34\17\2\u015f\u015e\3\2\2\2"+
		"\u015f\u0160\3\2\2\2\u0160\u017e\3\2\2\2\u0161\u0162\7.\2\2\u0162\u0163"+
		"\7\5\2\2\u0163\u0164\5*\26\2\u0164\u0165\7\6\2\2\u0165\u017e\3\2\2\2\u0166"+
		"\u016d\7:\2\2\u0167\u016e\5\26\f\2\u0168\u016e\5D#\2\u0169\u016a\7\5\2"+
		"\2\u016a\u016b\5*\26\2\u016b\u016c\7\6\2\2\u016c\u016e\3\2\2\2\u016d\u0167"+
		"\3\2\2\2\u016d\u0168\3\2\2\2\u016d\u0169\3\2\2\2\u016e\u017e\3\2\2\2\u016f"+
		"\u0170\7/\2\2\u0170\u017e\5\u00acW\2\u0171\u017e\5\32\16\2\u0172\u0173"+
		"\7\u00aa\2\2\u0173\u0175\7\u00ab\2\2\u0174\u0172\3\2\2\2\u0174\u0175\3"+
		"\2\2\2\u0175\u0176\3\2\2\2\u0176\u0177\7#\2\2\u0177\u0178\7\5\2\2\u0178"+
		"\u0179\5*\26\2\u0179\u017b\7\6\2\2\u017a\u017c\t\3\2\2\u017b\u017a\3\2"+
		"\2\2\u017b\u017c\3\2\2\2\u017c\u017e\3\2\2\2\u017d\u014e\3\2\2\2\u017d"+
		"\u015c\3\2\2\2\u017d\u0161\3\2\2\2\u017d\u0166\3\2\2\2\u017d\u016f\3\2"+
		"\2\2\u017d\u0171\3\2\2\2\u017d\u0174\3\2\2\2\u017e\25\3\2\2\2\u017f\u0181"+
		"\t\4\2\2\u0180\u017f\3\2\2\2\u0180\u0181\3\2\2\2\u0181\u0182\3\2\2\2\u0182"+
		"\u0183\7\u00bb\2\2\u0183\27\3\2\2\2\u0184\u0185\7\63\2\2\u0185\u0187\5"+
		"\u00a2R\2\u0186\u0184\3\2\2\2\u0186\u0187\3\2\2\2\u0187\u01a4\3\2\2\2"+
		"\u0188\u0189\7s\2\2\u0189\u018c\7a\2\2\u018a\u018c\7\u008d\2\2\u018b\u0188"+
		"\3\2\2\2\u018b\u018a\3\2\2\2\u018c\u018d\3\2\2\2\u018d\u018e\7\5\2\2\u018e"+
		"\u0193\5\f\7\2\u018f\u0190\7\7\2\2\u0190\u0192\5\f\7\2\u0191\u018f\3\2"+
		"\2\2\u0192\u0195\3\2\2\2\u0193\u0191\3\2\2\2\u0193\u0194\3\2\2\2\u0194"+
		"\u0196\3\2\2\2\u0195\u0193\3\2\2\2\u0196\u0198\7\6\2\2\u0197\u0199\5\34"+
		"\17\2\u0198\u0197\3\2\2\2\u0198\u0199\3\2\2\2\u0199\u01a5\3\2\2\2\u019a"+
		"\u019b\7.\2\2\u019b\u019c\7\5\2\2\u019c\u019d\5*\26\2\u019d\u019e\7\6"+
		"\2\2\u019e\u01a5\3\2\2\2\u019f\u01a0\7L\2\2\u01a0\u01a1\7a\2\2\u01a1\u01a2"+
		"\5j\66\2\u01a2\u01a3\5\32\16\2\u01a3\u01a5\3\2\2\2\u01a4\u018b\3\2\2\2"+
		"\u01a4\u019a\3\2\2\2\u01a4\u019f\3\2\2\2\u01a5\31\3\2\2\2\u01a6\u01a7"+
		"\7w\2\2\u01a7\u01a9\5\u00aeX\2\u01a8\u01aa\5j\66\2\u01a9\u01a8\3\2\2\2"+
		"\u01a9\u01aa\3\2\2\2\u01aa\u01b9\3\2\2\2\u01ab\u01ac\7m\2\2\u01ac\u01b3"+
		"\t\5\2\2\u01ad\u01ae\7\u0084\2\2\u01ae\u01b4\t\6\2\2\u01af\u01b4\7+\2"+
		"\2\u01b0\u01b4\7}\2\2\u01b1\u01b2\7g\2\2\u01b2\u01b4\7\34\2\2\u01b3\u01ad"+
		"\3\2\2\2\u01b3\u01af\3\2\2\2\u01b3\u01b0\3\2\2\2\u01b3\u01b1\3\2\2\2\u01b4"+
		"\u01b8\3\2\2\2\u01b5\u01b6\7e\2\2\u01b6\u01b8\5\u00a2R\2\u01b7\u01ab\3"+
		"\2\2\2\u01b7\u01b5\3\2\2\2\u01b8\u01bb\3\2\2\2\u01b9\u01b7\3\2\2\2\u01b9"+
		"\u01ba\3\2\2\2\u01ba\u01c4\3\2\2\2\u01bb\u01b9\3\2\2\2\u01bc\u01be\7h"+
		"\2\2\u01bd\u01bc\3\2\2\2\u01bd\u01be\3\2\2\2\u01be\u01bf\3\2\2\2\u01bf"+
		"\u01c2\7;\2\2\u01c0\u01c1\7X\2\2\u01c1\u01c3\t\7\2\2\u01c2\u01c0\3\2\2"+
		"\2\u01c2\u01c3\3\2\2\2\u01c3\u01c5\3\2\2\2\u01c4\u01bd\3\2\2\2\u01c4\u01c5"+
		"\3\2\2\2\u01c5\33\3\2\2\2\u01c6\u01c7\7m\2\2\u01c7\u01c8\7\62\2\2\u01c8"+
		"\u01c9\t\b\2\2\u01c9\35\3\2\2\2\u01ca\u01cc\7\64\2\2\u01cb\u01cd\t\2\2"+
		"\2\u01cc\u01cb\3\2\2\2\u01cc\u01cd\3\2\2\2\u01cd\u01ce\3\2\2\2\u01ce\u01d2"+
		"\7\u0092\2\2\u01cf\u01d0\7R\2\2\u01d0\u01d1\7h\2\2\u01d1\u01d3\7H\2\2"+
		"\u01d2\u01cf\3\2\2\2\u01d2\u01d3\3\2\2\2\u01d3\u01d7\3\2\2\2\u01d4\u01d5"+
		"\5\u00a6T\2\u01d5\u01d6\7\4\2\2\u01d6\u01d8\3\2\2\2\u01d7\u01d4\3\2\2"+
		"\2\u01d7\u01d8\3\2\2\2\u01d8\u01d9\3\2\2\2\u01d9\u01db\5\u00b2Z\2\u01da"+
		"\u01dc\5j\66\2\u01db\u01da\3\2\2\2\u01db\u01dc\3\2\2\2\u01dc\u01dd\3\2"+
		"\2\2\u01dd\u01de\7#\2\2\u01de\u01df\5J&\2\u01df\37\3\2\2\2\u01e0\u01e1"+
		"\7\64\2\2\u01e1\u01e2\7\u0093\2\2\u01e2\u01e6\7\u0085\2\2\u01e3\u01e4"+
		"\7R\2\2\u01e4\u01e5\7h\2\2\u01e5\u01e7\7H\2\2\u01e6\u01e3\3\2\2\2\u01e6"+
		"\u01e7\3\2\2\2\u01e7\u01eb\3\2\2\2\u01e8\u01e9\5\u00a6T\2\u01e9\u01ea"+
		"\7\4\2\2\u01ea\u01ec\3\2\2\2\u01eb\u01e8\3\2\2\2\u01eb\u01ec\3\2\2\2\u01ec"+
		"\u01ed\3\2\2\2\u01ed\u01ee\5\u00a8U\2\u01ee\u01ef\7\u008f\2\2\u01ef\u01fb"+
		"\5\u00b4[\2\u01f0\u01f1\7\5\2\2\u01f1\u01f6\5\u009cO\2\u01f2\u01f3\7\7"+
		"\2\2\u01f3\u01f5\5\u009cO\2\u01f4\u01f2\3\2\2\2\u01f5\u01f8\3\2\2\2\u01f6"+
		"\u01f4\3\2\2\2\u01f6\u01f7\3\2\2\2\u01f7\u01f9\3\2\2\2\u01f8\u01f6\3\2"+
		"\2\2\u01f9\u01fa\7\6\2\2\u01fa\u01fc\3\2\2\2\u01fb\u01f0\3\2\2\2\u01fb"+
		"\u01fc\3\2\2\2\u01fc!\3\2\2\2\u01fd\u01ff\7\u0096\2\2\u01fe\u0200\7v\2"+
		"\2\u01ff\u01fe\3\2\2\2\u01ff\u0200\3\2\2\2\u0200\u0201\3\2\2\2\u0201\u0202"+
		"\5$\23\2\u0202\u0203\7#\2\2\u0203\u0204\7\5\2\2\u0204\u0205\5J&\2\u0205"+
		"\u020f\7\6\2\2\u0206\u0207\7\7\2\2\u0207\u0208\5$\23\2\u0208\u0209\7#"+
		"\2\2\u0209\u020a\7\5\2\2\u020a\u020b\5J&\2\u020b\u020c\7\6\2\2\u020c\u020e"+
		"\3\2\2\2\u020d\u0206\3\2\2\2\u020e\u0211\3\2\2\2\u020f\u020d\3\2\2\2\u020f"+
		"\u0210\3\2\2\2\u0210#\3\2\2\2\u0211\u020f\3\2\2\2\u0212\u0214\5\u00a8"+
		"U\2\u0213\u0215\5j\66\2\u0214\u0213\3\2\2\2\u0214\u0215\3\2\2\2\u0215"+
		"%\3\2\2\2\u0216\u0217\5$\23\2\u0217\u0218\7#\2\2\u0218\u0219\7\5\2\2\u0219"+
		"\u021a\5\u0094K\2\u021a\u021c\7\u008c\2\2\u021b\u021d\7\37\2\2\u021c\u021b"+
		"\3\2\2\2\u021c\u021d\3\2\2\2\u021d\u021e\3\2\2\2\u021e\u021f\5\u0096L"+
		"\2\u021f\u0220\7\6\2\2\u0220\'\3\2\2\2\u0221\u0223\5\u00a8U\2\u0222\u0224"+
		"\5j\66\2\u0223\u0222\3\2\2\2\u0223\u0224\3\2\2\2\u0224\u0225\3\2\2\2\u0225"+
		"\u0226\7#\2\2\u0226\u0227\7\5\2\2\u0227\u0228\5J&\2\u0228\u0229\7\6\2"+
		"\2\u0229)\3\2\2\2\u022a\u022b\b\26\1\2\u022b\u0244\5D#\2\u022c\u0244\7"+
		"\u00bc\2\2\u022d\u0244\5<\37\2\u022e\u022f\5\u0098M\2\u022f\u0230\5*\26"+
		"\17\u0230\u0244\3\2\2\2\u0231\u0244\5,\27\2\u0232\u0233\7-\2\2\u0233\u0234"+
		"\7\5\2\2\u0234\u0235\5*\26\2\u0235\u0236\7#\2\2\u0236\u0237\5\22\n\2\u0237"+
		"\u0238\7\6\2\2\u0238\u0244\3\2\2\2\u0239\u0244\58\35\2\u023a\u0244\5\60"+
		"\31\2\u023b\u0244\5B\"\2\u023c\u023f\7\5\2\2\u023d\u0240\5*\26\2\u023e"+
		"\u0240\5\\/\2\u023f\u023d\3\2\2\2\u023f\u023e\3\2\2\2\u0240\u0241\3\2"+
		"\2\2\u0241\u0242\7\6\2\2\u0242\u0244\3\2\2\2\u0243\u022a\3\2\2\2\u0243"+
		"\u022c\3\2\2\2\u0243\u022d\3\2\2\2\u0243\u022e\3\2\2\2\u0243\u0231\3\2"+
		"\2\2\u0243\u0232\3\2\2\2\u0243\u0239\3\2\2\2\u0243\u023a\3\2\2\2\u0243"+
		"\u023b\3\2\2\2\u0243\u023c\3\2\2\2\u0244\u0265\3\2\2\2\u0245\u0246\f\16"+
		"\2\2\u0246\u0247\5> \2\u0247\u0248\5*\26\17\u0248\u0264\3\2\2\2\u0249"+
		"\u024b\f\5\2\2\u024a\u024c\7h\2\2\u024b\u024a\3\2\2\2\u024b\u024c\3\2"+
		"\2\2\u024c\u024d\3\2\2\2\u024d\u024e\7)\2\2\u024e\u024f\5*\26\2\u024f"+
		"\u0250\7\"\2\2\u0250\u0251\5*\26\6\u0251\u0264\3\2\2\2\u0252\u0253\f\13"+
		"\2\2\u0253\u0254\7/\2\2\u0254\u0264\5\u00acW\2\u0255\u0256\f\n\2\2\u0256"+
		"\u0264\5:\36\2\u0257\u0258\f\t\2\2\u0258\u0264\5.\30\2\u0259\u025b\f\4"+
		"\2\2\u025a\u025c\7h\2\2\u025b\u025a\3\2\2\2\u025b\u025c\3\2\2\2\u025c"+
		"\u025d\3\2\2\2\u025d\u025e\5@!\2\u025e\u0261\5*\26\2\u025f\u0260\7E\2"+
		"\2\u0260\u0262\5*\26\2\u0261\u025f\3\2\2\2\u0261\u0262\3\2\2\2\u0262\u0264"+
		"\3\2\2\2\u0263\u0245\3\2\2\2\u0263\u0249\3\2\2\2\u0263\u0252\3\2\2\2\u0263"+
		"\u0255\3\2\2\2\u0263\u0257\3\2\2\2\u0263\u0259\3\2\2\2\u0264\u0267\3\2"+
		"\2\2\u0265\u0263\3\2\2\2\u0265\u0266\3\2\2\2\u0266+\3\2\2\2\u0267\u0265"+
		"\3\2\2\2\u0268\u0269\5\u00a4S\2\u0269\u026f\7\5\2\2\u026a\u026c\7@\2\2"+
		"\u026b\u026a\3\2\2\2\u026b\u026c\3\2\2\2\u026c\u026d\3\2\2\2\u026d\u0270"+
		"\5\\/\2\u026e\u0270\7\t\2\2\u026f\u026b\3\2\2\2\u026f\u026e\3\2\2\2\u026f"+
		"\u0270\3\2\2\2\u0270\u0271\3\2\2\2\u0271\u0273\7\6\2\2\u0272\u0274\5l"+
		"\67\2\u0273\u0272\3\2\2\2\u0273\u0274\3\2\2\2\u0274\u0276\3\2\2\2\u0275"+
		"\u0277\5p9\2\u0276\u0275\3\2\2\2\u0276\u0277\3\2\2\2\u0277-\3\2\2\2\u0278"+
		"\u027a\7h\2\2\u0279\u0278\3\2\2\2\u0279\u027a\3\2\2\2\u027a\u027b\3\2"+
		"\2\2\u027b\u0294\7U\2\2\u027c\u027f\7\5\2\2\u027d\u0280\5J&\2\u027e\u0280"+
		"\5\\/\2\u027f\u027d\3\2\2\2\u027f\u027e\3\2\2\2\u027f\u0280\3\2\2\2\u0280"+
		"\u0281\3\2\2\2\u0281\u0295\7\6\2\2\u0282\u0283\5\u00a6T\2\u0283\u0284"+
		"\7\4\2\2\u0284\u0286\3\2\2\2\u0285\u0282\3\2\2\2\u0285\u0286\3\2\2\2\u0286"+
		"\u0287\3\2\2\2\u0287\u0295\5\u00a8U\2\u0288\u0289\5\u00a6T\2\u0289\u028a"+
		"\7\4\2\2\u028a\u028c\3\2\2\2\u028b\u0288\3\2\2\2\u028b\u028c\3\2\2\2\u028c"+
		"\u028d\3\2\2\2\u028d\u028e\5\u00c2b\2\u028e\u0290\7\5\2\2\u028f\u0291"+
		"\5\\/\2\u0290\u028f\3\2\2\2\u0290\u0291\3\2\2\2\u0291\u0292\3\2\2\2\u0292"+
		"\u0293\7\6\2\2\u0293\u0295\3\2\2\2\u0294\u027c\3\2\2\2\u0294\u0285\3\2"+
		"\2\2\u0294\u028b\3\2\2\2\u0295/\3\2\2\2\u0296\u0298\5\64\33\2\u0297\u0299"+
		"\5\62\32\2\u0298\u0297\3\2\2\2\u0299\u029a\3\2\2\2\u029a\u0298\3\2\2\2"+
		"\u029a\u029b\3\2\2\2\u029b\u029d\3\2\2\2\u029c\u029e\5\66\34\2\u029d\u029c"+
		"\3\2\2\2\u029d\u029e\3\2\2\2\u029e\u029f\3\2\2\2\u029f\u02a0\7D\2\2\u02a0"+
		"\61\3\2\2\2\u02a1\u02a2\7\u0094\2\2\u02a2\u02a3\5*\26\2\u02a3\u02a4\7"+
		"\u0088\2\2\u02a4\u02a5\5*\26\2\u02a5\63\3\2\2\2\u02a6\u02a8\7,\2\2\u02a7"+
		"\u02a9\5*\26\2\u02a8\u02a7\3\2\2\2\u02a8\u02a9\3\2\2\2\u02a9\65\3\2\2"+
		"\2\u02aa\u02ab\7C\2\2\u02ab\u02ac\5*\26\2\u02ac\67\3\2\2\2\u02ad\u02af"+
		"\7h\2\2\u02ae\u02ad\3\2\2\2\u02ae\u02af\3\2\2\2\u02af\u02b0\3\2\2\2\u02b0"+
		"\u02b2\7H\2\2\u02b1\u02ae\3\2\2\2\u02b1\u02b2\3\2\2\2\u02b2\u02b3\3\2"+
		"\2\2\u02b3\u02b4\7\5\2\2\u02b4\u02b5\5J&\2\u02b5\u02b6\7\6\2\2\u02b69"+
		"\3\2\2\2\u02b7\u02bc\7_\2\2\u02b8\u02bc\7i\2\2\u02b9\u02ba\7h\2\2\u02ba"+
		"\u02bc\7j\2\2\u02bb\u02b7\3\2\2\2\u02bb\u02b8\3\2\2\2\u02bb\u02b9\3\2"+
		"\2\2\u02bc;\3\2\2\2\u02bd\u02be\5\u00a6T\2\u02be\u02bf\7\4\2\2\u02bf\u02c1"+
		"\3\2\2\2\u02c0\u02bd\3\2\2\2\u02c0\u02c1\3\2\2\2\u02c1\u02c2\3\2\2\2\u02c2"+
		"\u02c3\5\u00a8U\2\u02c3\u02c4\7\4\2\2\u02c4\u02c6\3\2\2\2\u02c5\u02c0"+
		"\3\2\2\2\u02c5\u02c6\3\2\2\2\u02c6\u02c7\3\2\2\2\u02c7\u02c8\5\u00aaV"+
		"\2\u02c8=\3\2\2\2\u02c9\u02db\7\r\2\2\u02ca\u02db\t\t\2\2\u02cb\u02db"+
		"\t\4\2\2\u02cc\u02db\t\n\2\2\u02cd\u02db\t\13\2\2\u02ce\u02db\7\b\2\2"+
		"\u02cf\u02db\7\30\2\2\u02d0\u02db\7\31\2\2\u02d1\u02db\7\32\2\2\u02d2"+
		"\u02db\7U\2\2\u02d3\u02db\7\"\2\2\u02d4\u02db\7n\2\2\u02d5\u02d7\7^\2"+
		"\2\u02d6\u02d8\7h\2\2\u02d7\u02d6\3\2\2\2\u02d7\u02d8\3\2\2\2\u02d8\u02db"+
		"\3\2\2\2\u02d9\u02db\5@!\2\u02da\u02c9\3\2\2\2\u02da\u02ca\3\2\2\2\u02da"+
		"\u02cb\3\2\2\2\u02da\u02cc\3\2\2\2\u02da\u02cd\3\2\2\2\u02da\u02ce\3\2"+
		"\2\2\u02da\u02cf\3\2\2\2\u02da\u02d0\3\2\2\2\u02da\u02d1\3\2\2\2\u02da"+
		"\u02d2\3\2\2\2\u02da\u02d3\3\2\2\2\u02da\u02d4\3\2\2\2\u02da\u02d5\3\2"+
		"\2\2\u02da\u02d9\3\2\2\2\u02db?\3\2\2\2\u02dc\u02dd\t\f\2\2\u02ddA\3\2"+
		"\2\2\u02de\u02df\7u\2\2\u02df\u02e4\7\5\2\2\u02e0\u02e5\7S\2\2\u02e1\u02e2"+
		"\t\r\2\2\u02e2\u02e3\7\7\2\2\u02e3\u02e5\5\u009aN\2\u02e4\u02e0\3\2\2"+
		"\2\u02e4\u02e1\3\2\2\2\u02e5\u02e6\3\2\2\2\u02e6\u02e7\7\6\2\2\u02e7C"+
		"\3\2\2\2\u02e8\u02e9\t\16\2\2\u02e9E\3\2\2\2\u02ea\u02ec\5\"\22\2\u02eb"+
		"\u02ea\3\2\2\2\u02eb\u02ec\3\2\2\2\u02ec\u02f2\3\2\2\2\u02ed\u02f3\7Z"+
		"\2\2\u02ee\u02f3\7|\2\2\u02ef\u02f0\7Z\2\2\u02f0\u02f1\7n\2\2\u02f1\u02f3"+
		"\t\b\2\2\u02f2\u02ed\3\2\2\2\u02f2\u02ee\3\2\2\2\u02f2\u02ef\3\2\2\2\u02f3"+
		"\u02f4\3\2\2\2\u02f4\u02f8\7]\2\2\u02f5\u02f6\5\u00a6T\2\u02f6\u02f7\7"+
		"\4\2\2\u02f7\u02f9\3\2\2\2\u02f8\u02f5\3\2\2\2\u02f8\u02f9\3\2\2\2\u02f9"+
		"\u02fa\3\2\2\2\u02fa\u02fd\5\u00a8U\2\u02fb\u02fc\7#\2\2\u02fc\u02fe\5"+
		"\u00b6\\\2\u02fd\u02fb\3\2\2\2\u02fd\u02fe\3\2\2\2\u02fe\u0300\3\2\2\2"+
		"\u02ff\u0301\5j\66\2\u0300\u02ff\3\2\2\2\u0300\u0301\3\2\2\2\u0301\u0305"+
		"\3\2\2\2\u0302\u0303\7\u0091\2\2\u0303\u0306\5T+\2\u0304\u0306\5J&\2\u0305"+
		"\u0302\3\2\2\2\u0305\u0304\3\2\2\2\u0306\u0308\3\2\2\2\u0307\u0309\5H"+
		"%\2\u0308\u0307\3\2\2\2\u0308\u0309\3\2\2\2\u0309\u030d\3\2\2\2\u030a"+
		"\u030b\7:\2\2\u030b\u030d\7\u0091\2\2\u030c\u02eb\3\2\2\2\u030c\u030a"+
		"\3\2\2\2\u030dG\3\2\2\2\u030e\u030f\7m\2\2\u030f\u031d\7\62\2\2\u0310"+
		"\u0311\7\5\2\2\u0311\u0316\5\f\7\2\u0312\u0313\7\7\2\2\u0313\u0315\5\f"+
		"\7\2\u0314\u0312\3\2\2\2\u0315\u0318\3\2\2\2\u0316\u0314\3\2\2\2\u0316"+
		"\u0317\3\2\2\2\u0317\u0319\3\2\2\2\u0318\u0316\3\2\2\2\u0319\u031b\7\6"+
		"\2\2\u031a\u031c\5\n\6\2\u031b\u031a\3\2\2\2\u031b\u031c\3\2\2\2\u031c"+
		"\u031e\3\2\2\2\u031d\u0310\3\2\2\2\u031d\u031e\3\2\2\2\u031e\u031f\3\2"+
		"\2\2\u031f\u0339\7\u00b8\2\2\u0320\u033a\7\u00b9\2\2\u0321\u0322\7\u008e"+
		"\2\2\u0322\u0325\7\u0084\2\2\u0323\u0326\5\u00aaV\2\u0324\u0326\5j\66"+
		"\2\u0325\u0323\3\2\2\2\u0325\u0324\3\2\2\2\u0326\u0327\3\2\2\2\u0327\u0328"+
		"\7\30\2\2\u0328\u0333\5*\26\2\u0329\u032c\7\7\2\2\u032a\u032d\5\u00aa"+
		"V\2\u032b\u032d\5j\66\2\u032c\u032a\3\2\2\2\u032c\u032b\3\2\2\2\u032d"+
		"\u032e\3\2\2\2\u032e\u032f\7\30\2\2\u032f\u0330\5*\26\2\u0330\u0332\3"+
		"\2\2\2\u0331\u0329\3\2\2\2\u0332\u0335\3\2\2\2\u0333\u0331\3\2\2\2\u0333"+
		"\u0334\3\2\2\2\u0334\u0337\3\2\2\2\u0335\u0333\3\2\2\2\u0336\u0338\5\n"+
		"\6\2\u0337\u0336\3\2\2\2\u0337\u0338\3\2\2\2\u0338\u033a\3\2\2\2\u0339"+
		"\u0320\3\2\2\2\u0339\u0321\3\2\2\2\u033aI\3\2\2\2\u033b\u033d\5v<\2\u033c"+
		"\u033b\3\2\2\2\u033c\u033d\3\2\2\2\u033d\u033e\3\2\2\2\u033e\u0342\5R"+
		"*\2\u033f\u0341\5L\'\2\u0340\u033f\3\2\2\2\u0341\u0344\3\2\2\2\u0342\u0340"+
		"\3\2\2\2\u0342\u0343\3\2\2\2\u0343\u0346\3\2\2\2\u0344\u0342\3\2\2\2\u0345"+
		"\u0347\5x=\2\u0346\u0345\3\2\2\2\u0346\u0347\3\2\2\2\u0347\u0349\3\2\2"+
		"\2\u0348\u034a\5z>\2\u0349\u0348\3\2\2\2\u0349\u034a\3\2\2\2\u034aK\3"+
		"\2\2\2\u034b\u034c\5h\65\2\u034c\u034d\5R*\2\u034dM\3\2\2\2\u034e\u0350"+
		"\5^\60\2\u034f\u0351\5P)\2\u0350\u034f\3\2\2\2\u0351\u0352\3\2\2\2\u0352"+
		"\u0350\3\2\2\2\u0352\u0353\3\2\2\2\u0353O\3\2\2\2\u0354\u0355\5d\63\2"+
		"\u0355\u0357\5^\60\2\u0356\u0358\5f\64\2\u0357\u0356\3\2\2\2\u0357\u0358"+
		"\3\2\2\2\u0358Q\3\2\2\2\u0359\u035b\7\u0083\2\2\u035a\u035c\t\17\2\2\u035b"+
		"\u035a\3\2\2\2\u035b\u035c\3\2\2\2\u035c\u035d\3\2\2\2\u035d\u0362\5b"+
		"\62\2\u035e\u035f\7\7\2\2\u035f\u0361\5b\62\2\u0360\u035e\3\2\2\2\u0361"+
		"\u0364\3\2\2\2\u0362\u0360\3\2\2\2\u0362\u0363\3\2\2\2\u0363\u0367\3\2"+
		"\2\2\u0364\u0362\3\2\2\2\u0365\u0366\7M\2\2\u0366\u0368\5`\61\2\u0367"+
		"\u0365\3\2\2\2\u0367\u0368\3\2\2\2\u0368\u036a\3\2\2\2\u0369\u036b\5\n"+
		"\6\2\u036a\u0369\3\2\2\2\u036a\u036b\3\2\2\2\u036b\u036d\3\2\2\2\u036c"+
		"\u036e\5V,\2\u036d\u036c\3\2\2\2\u036d\u036e\3\2\2\2\u036e\u0378\3\2\2"+
		"\2\u036f\u0370\7\u00af\2\2\u0370\u0375\5Z.\2\u0371\u0372\7\7\2\2\u0372"+
		"\u0374\5Z.\2\u0373\u0371\3\2\2\2\u0374\u0377\3\2\2\2\u0375\u0373\3\2\2"+
		"\2\u0375\u0376\3\2\2\2\u0376\u0379\3\2\2\2\u0377\u0375\3\2\2\2\u0378\u036f"+
		"\3\2\2\2\u0378\u0379\3\2\2\2\u0379\u037d\3\2\2\2\u037a\u037b\7\u0091\2"+
		"\2\u037b\u037d\5T+\2\u037c\u0359\3\2\2\2\u037c\u037a\3\2\2\2\u037dS\3"+
		"\2\2\2\u037e\u037f\7\5\2\2\u037f\u0380\5\\/\2\u0380\u0388\7\6\2\2\u0381"+
		"\u0382\7\7\2\2\u0382\u0383\7\5\2\2\u0383\u0384\5\\/\2\u0384\u0385\7\6"+
		"\2\2\u0385\u0387\3\2\2\2\u0386\u0381\3\2\2\2\u0387\u038a\3\2\2\2\u0388"+
		"\u0386\3\2\2\2\u0388\u0389\3\2\2\2\u0389U\3\2\2\2\u038a\u0388\3\2\2\2"+
		"\u038b\u038c\7P\2\2\u038c\u038d\7*\2\2\u038d\u038f\5\\/\2\u038e\u0390"+
		"\5X-\2\u038f\u038e\3\2\2\2\u038f\u0390\3\2\2\2\u0390W\3\2\2\2\u0391\u0392"+
		"\7Q\2\2\u0392\u0393\5*\26\2\u0393Y\3\2\2\2\u0394\u0395\5\u00b8]\2\u0395"+
		"\u0396\7#\2\2\u0396\u0397\5n8\2\u0397[\3\2\2\2\u0398\u039d\5*\26\2\u0399"+
		"\u039a\7\7\2\2\u039a\u039c\5*\26\2\u039b\u0399\3\2\2\2\u039c\u039f\3\2"+
		"\2\2\u039d\u039b\3\2\2\2\u039d\u039e\3\2\2\2\u039e]\3\2\2\2\u039f\u039d"+
		"\3\2\2\2\u03a0\u03a1\5\u00a6T\2\u03a1\u03a2\7\4\2\2\u03a2\u03a4\3\2\2"+
		"\2\u03a3\u03a0\3\2\2\2\u03a3\u03a4\3\2\2\2\u03a4\u03a5\3\2\2\2\u03a5\u03aa"+
		"\5\u00a8U\2\u03a6\u03a8\7#\2\2\u03a7\u03a6\3\2\2\2\u03a7\u03a8\3\2\2\2"+
		"\u03a8\u03a9\3\2\2\2\u03a9\u03ab\5\u00b6\\\2\u03aa\u03a7\3\2\2\2\u03aa"+
		"\u03ab\3\2\2\2\u03ab\u03b1\3\2\2\2\u03ac\u03ad\7W\2\2\u03ad\u03ae\7*\2"+
		"\2\u03ae\u03b2\5\u00b0Y\2\u03af\u03b0\7h\2\2\u03b0\u03b2\7W\2\2\u03b1"+
		"\u03ac\3\2\2\2\u03b1\u03af\3\2\2\2\u03b1\u03b2\3\2\2\2\u03b2\u03d7\3\2"+
		"\2\2\u03b3\u03b4\5\u00a6T\2\u03b4\u03b5\7\4\2\2\u03b5\u03b7\3\2\2\2\u03b6"+
		"\u03b3\3\2\2\2\u03b6\u03b7\3\2\2\2\u03b7\u03b8\3\2\2\2\u03b8\u03b9\5\u00c2"+
		"b\2\u03b9\u03ba\7\5\2\2\u03ba\u03bf\5*\26\2\u03bb\u03bc\7\7\2\2\u03bc"+
		"\u03be\5*\26\2\u03bd\u03bb\3\2\2\2\u03be\u03c1\3\2\2\2\u03bf\u03bd\3\2"+
		"\2\2\u03bf\u03c0\3\2\2\2\u03c0\u03c2\3\2\2\2\u03c1\u03bf\3\2\2\2\u03c2"+
		"\u03c7\7\6\2\2\u03c3\u03c5\7#\2\2\u03c4\u03c3\3\2\2\2\u03c4\u03c5\3\2"+
		"\2\2\u03c5\u03c6\3\2\2\2\u03c6\u03c8\5\u00b6\\\2\u03c7\u03c4\3\2\2\2\u03c7"+
		"\u03c8\3\2\2\2\u03c8\u03d7\3\2\2\2\u03c9\u03ca\7\5\2\2\u03ca\u03cb\5`"+
		"\61\2\u03cb\u03cc\7\6\2\2\u03cc\u03d7\3\2\2\2\u03cd\u03ce\7\5\2\2\u03ce"+
		"\u03cf\5J&\2\u03cf\u03d4\7\6\2\2\u03d0\u03d2\7#\2\2\u03d1\u03d0\3\2\2"+
		"\2\u03d1\u03d2\3\2\2\2\u03d2\u03d3\3\2\2\2\u03d3\u03d5\5\u00b6\\\2\u03d4"+
		"\u03d1\3\2\2\2\u03d4\u03d5\3\2\2\2\u03d5\u03d7\3\2\2\2\u03d6\u03a3\3\2"+
		"\2\2\u03d6\u03b6\3\2\2\2\u03d6\u03c9\3\2\2\2\u03d6\u03cd\3\2\2\2\u03d7"+
		"_\3\2\2\2\u03d8\u03dd\5^\60\2\u03d9\u03da\7\7\2\2\u03da\u03dc\5^\60\2"+
		"\u03db\u03d9\3\2\2\2\u03dc\u03df\3\2\2\2\u03dd\u03db\3\2\2\2\u03dd\u03de"+
		"\3\2\2\2\u03de\u03e2\3\2\2\2\u03df\u03dd\3\2\2\2\u03e0\u03e2\5N(\2\u03e1"+
		"\u03d8\3\2\2\2\u03e1\u03e0\3\2\2\2\u03e2a\3\2\2\2\u03e3\u03f0\7\t\2\2"+
		"\u03e4\u03e5\5\u00a8U\2\u03e5\u03e6\7\4\2\2\u03e6\u03e7\7\t\2\2\u03e7"+
		"\u03f0\3\2\2\2\u03e8\u03ed\5*\26\2\u03e9\u03eb\7#\2\2\u03ea\u03e9\3\2"+
		"\2\2\u03ea\u03eb\3\2\2\2\u03eb\u03ec\3\2\2\2\u03ec\u03ee\5\u009eP\2\u03ed"+
		"\u03ea\3\2\2\2\u03ed\u03ee\3\2\2\2\u03ee\u03f0\3\2\2\2\u03ef\u03e3\3\2"+
		"\2\2\u03ef\u03e4\3\2\2\2\u03ef\u03e8\3\2\2\2\u03f0c\3\2\2\2\u03f1\u03ff"+
		"\7\7\2\2\u03f2\u03f4\7f\2\2\u03f3\u03f2\3\2\2\2\u03f3\u03f4\3\2\2\2\u03f4"+
		"\u03fb\3\2\2\2\u03f5\u03f7\7b\2\2\u03f6\u03f8\7p\2\2\u03f7\u03f6\3\2\2"+
		"\2\u03f7\u03f8\3\2\2\2\u03f8\u03fc\3\2\2\2\u03f9\u03fc\7Y\2\2\u03fa\u03fc"+
		"\7\65\2\2\u03fb\u03f5\3\2\2\2\u03fb\u03f9\3\2\2\2\u03fb\u03fa\3\2\2\2"+
		"\u03fb\u03fc\3\2\2\2\u03fc\u03fd\3\2\2\2\u03fd\u03ff\7`\2\2\u03fe\u03f1"+
		"\3\2\2\2\u03fe\u03f3\3\2\2\2\u03ffe\3\2\2\2\u0400\u0401\7m\2\2\u0401\u0405"+
		"\5*\26\2\u0402\u0403\7\u008f\2\2\u0403\u0405\5j\66\2\u0404\u0400\3\2\2"+
		"\2\u0404\u0402\3\2\2\2\u0405g\3\2\2\2\u0406\u0408\7\u008c\2\2\u0407\u0409"+
		"\7\37\2\2\u0408\u0407\3\2\2\2\u0408\u0409\3\2\2\2\u0409\u040d\3\2\2\2"+
		"\u040a\u040d\7\\\2\2\u040b\u040d\7F\2\2\u040c\u0406\3\2\2\2\u040c\u040a"+
		"\3\2\2\2\u040c\u040b\3\2\2\2\u040di\3\2\2\2\u040e\u040f\7\5\2\2\u040f"+
		"\u0414\5\u00aaV\2\u0410\u0411\7\7\2\2\u0411\u0413\5\u00aaV\2\u0412\u0410"+
		"\3\2\2\2\u0413\u0416\3\2\2\2\u0414\u0412\3\2\2\2\u0414\u0415\3\2\2\2\u0415"+
		"\u0417\3\2\2\2\u0416\u0414\3\2\2\2\u0417\u0418\7\6\2\2\u0418k\3\2\2\2"+
		"\u0419\u041a\7\u00b3\2\2\u041a\u041b\7\5\2\2\u041b\u041c\7\u0095\2\2\u041c"+
		"\u041d\5*\26\2\u041d\u041e\7\6\2\2\u041em\3\2\2\2\u041f\u0421\7\5\2\2"+
		"\u0420\u0422\5\u00bc_\2\u0421\u0420\3\2\2\2\u0421\u0422\3\2\2\2\u0422"+
		"\u0426\3\2\2\2\u0423\u0424\7\u009a\2\2\u0424\u0425\7*\2\2\u0425\u0427"+
		"\5\\/\2\u0426\u0423\3\2\2\2\u0426\u0427\3\2\2\2\u0427\u0428\3\2\2\2\u0428"+
		"\u0429\7o\2\2\u0429\u042a\7*\2\2\u042a\u042f\5~@\2\u042b\u042c\7\7\2\2"+
		"\u042c\u042e\5~@\2\u042d\u042b\3\2\2\2\u042e\u0431\3\2\2\2\u042f\u042d"+
		"\3\2\2\2\u042f\u0430\3\2\2\2\u0430\u0433\3\2\2\2\u0431\u042f\3\2\2\2\u0432"+
		"\u0434\5r:\2\u0433\u0432\3\2\2\2\u0433\u0434\3\2\2\2\u0434\u0435\3\2\2"+
		"\2\u0435\u0436\7\6\2\2\u0436o\3\2\2\2\u0437\u0452\7\u0099\2\2\u0438\u0453"+
		"\5\u00b8]\2\u0439\u043b\7\5\2\2\u043a\u043c\5\u00bc_\2\u043b\u043a\3\2"+
		"\2\2\u043b\u043c\3\2\2\2\u043c\u0440\3\2\2\2\u043d\u043e\7\u009a\2\2\u043e"+
		"\u043f\7*\2\2\u043f\u0441\5\\/\2\u0440\u043d\3\2\2\2\u0440\u0441\3\2\2"+
		"\2\u0441\u044c\3\2\2\2\u0442\u0443\7o\2\2\u0443\u0444\7*\2\2\u0444\u0449"+
		"\5~@\2\u0445\u0446\7\7\2\2\u0446\u0448\5~@\2\u0447\u0445\3\2\2\2\u0448"+
		"\u044b\3\2\2\2\u0449\u0447\3\2\2\2\u0449\u044a\3\2\2\2\u044a\u044d\3\2"+
		"\2\2\u044b\u0449\3\2\2\2\u044c\u0442\3\2\2\2\u044c\u044d\3\2\2\2\u044d"+
		"\u044f\3\2\2\2\u044e\u0450\5r:\2\u044f\u044e\3\2\2\2\u044f\u0450\3\2\2"+
		"\2\u0450\u0451\3\2\2\2\u0451\u0453\7\6\2\2\u0452\u0438\3\2\2\2\u0452\u0439"+
		"\3\2\2\2\u0453q\3\2\2\2\u0454\u045c\5t;\2\u0455\u0456\7\u00b5\2\2\u0456"+
		"\u0457\7g\2\2\u0457\u045d\7\u00b7\2\2\u0458\u0459\7\u009e\2\2\u0459\u045d"+
		"\7\u0080\2\2\u045a\u045d\7P\2\2\u045b\u045d\7\u00b6\2\2\u045c\u0455\3"+
		"\2\2\2\u045c\u0458\3\2\2\2\u045c\u045a\3\2\2\2\u045c\u045b\3\2\2\2\u045c"+
		"\u045d\3\2\2\2\u045ds\3\2\2\2\u045e\u0465\t\20\2\2\u045f\u0466\5\u0086"+
		"D\2\u0460\u0461\7)\2\2\u0461\u0462\5\u0082B\2\u0462\u0463\7\"\2\2\u0463"+
		"\u0464\5\u0084C\2\u0464\u0466\3\2\2\2\u0465\u045f\3\2\2\2\u0465\u0460"+
		"\3\2\2\2\u0466u\3\2\2\2\u0467\u0469\7\u0096\2\2\u0468\u046a\7v\2\2\u0469"+
		"\u0468\3\2\2\2\u0469\u046a\3\2\2\2\u046a\u046b\3\2\2\2\u046b\u0470\5("+
		"\25\2\u046c\u046d\7\7\2\2\u046d\u046f\5(\25\2\u046e\u046c\3\2\2\2\u046f"+
		"\u0472\3\2\2\2\u0470\u046e\3\2\2\2\u0470\u0471\3\2\2\2\u0471w\3\2\2\2"+
		"\u0472\u0470\3\2\2\2\u0473\u0474\7o\2\2\u0474\u0475\7*\2\2\u0475\u047a"+
		"\5~@\2\u0476\u0477\7\7\2\2\u0477\u0479\5~@\2\u0478\u0476\3\2\2\2\u0479"+
		"\u047c\3\2\2\2\u047a\u0478\3\2\2\2\u047a\u047b\3\2\2\2\u047by\3\2\2\2"+
		"\u047c\u047a\3\2\2\2\u047d\u047e\7d\2\2\u047e\u0480\5*\26\2\u047f\u0481"+
		"\5|?\2\u0480\u047f\3\2\2\2\u0480\u0481\3\2\2\2\u0481{\3\2\2\2\u0482\u0483"+
		"\t\21\2\2\u0483\u0484\5*\26\2\u0484}\3\2\2\2\u0485\u0488\5*\26\2\u0486"+
		"\u0487\7/\2\2\u0487\u0489\5\u00acW\2\u0488\u0486\3\2\2\2\u0488\u0489\3"+
		"\2\2\2\u0489\u048b\3\2\2\2\u048a\u048c\5\u0080A\2\u048b\u048a\3\2\2\2"+
		"\u048b\u048c\3\2\2\2\u048c\u048f\3\2\2\2\u048d\u048e\7\u00b0\2\2\u048e"+
		"\u0490\t\22\2\2\u048f\u048d\3\2\2\2\u048f\u0490\3\2\2\2\u0490\177\3\2"+
		"\2\2\u0491\u0492\t\23\2\2\u0492\u0081\3\2\2\2\u0493\u0494\5*\26\2\u0494"+
		"\u0495\7\u009c\2\2\u0495\u049e\3\2\2\2\u0496\u0497\5*\26\2\u0497\u0498"+
		"\7\u009f\2\2\u0498\u049e\3\2\2\2\u0499\u049a\7\u009e\2\2\u049a\u049e\7"+
		"\u0080\2\2\u049b\u049c\7\u009d\2\2\u049c\u049e\7\u009c\2\2\u049d\u0493"+
		"\3\2\2\2\u049d\u0496\3\2\2\2\u049d\u0499\3\2\2\2\u049d\u049b\3\2\2\2\u049e"+
		"\u0083\3\2\2\2\u049f\u04a0\5*\26\2\u04a0\u04a1\7\u009c\2\2\u04a1\u04aa"+
		"\3\2\2\2\u04a2\u04a3\5*\26\2\u04a3\u04a4\7\u009f\2\2\u04a4\u04aa\3\2\2"+
		"\2\u04a5\u04a6\7\u009e\2\2\u04a6\u04aa\7\u0080\2\2\u04a7\u04a8\7\u009d"+
		"\2\2\u04a8\u04aa\7\u009f\2\2\u04a9\u049f\3\2\2\2\u04a9\u04a2\3\2\2\2\u04a9"+
		"\u04a5\3\2\2\2\u04a9\u04a7\3\2\2\2\u04aa\u0085\3\2\2\2\u04ab\u04ac\5*"+
		"\26\2\u04ac\u04ad\7\u009c\2\2\u04ad\u04b3\3\2\2\2\u04ae\u04af\7\u009d"+
		"\2\2\u04af\u04b3\7\u009c\2\2\u04b0\u04b1\7\u009e\2\2\u04b1\u04b3\7\u0080"+
		"\2\2\u04b2\u04ab\3\2\2\2\u04b2\u04ae\3\2\2\2\u04b2\u04b0\3\2\2\2\u04b3"+
		"\u0087\3\2\2\2\u04b4\u04b5\t\24\2\2\u04b5\u04b6\7\5\2\2\u04b6\u04b7\5"+
		"*\26\2\u04b7\u04b8\7\6\2\2\u04b8\u04b9\7\u0099\2\2\u04b9\u04bb\7\5\2\2"+
		"\u04ba\u04bc\5\u008eH\2\u04bb\u04ba\3\2\2\2\u04bb\u04bc\3\2\2\2\u04bc"+
		"\u04bd\3\2\2\2\u04bd\u04bf\5\u0092J\2\u04be\u04c0\5t;\2\u04bf\u04be\3"+
		"\2\2\2\u04bf\u04c0\3\2\2\2\u04c0\u04c1\3\2\2\2\u04c1\u04c2\7\6\2\2\u04c2"+
		"\u050a\3\2\2\2\u04c3\u04c4\t\25\2\2\u04c4\u04c5\7\5\2\2\u04c5\u04c6\7"+
		"\6\2\2\u04c6\u04c7\7\u0099\2\2\u04c7\u04c9\7\5\2\2\u04c8\u04ca\5\u008e"+
		"H\2\u04c9\u04c8\3\2\2\2\u04c9\u04ca\3\2\2\2\u04ca\u04cc\3\2\2\2\u04cb"+
		"\u04cd\5\u0090I\2\u04cc\u04cb\3\2\2\2\u04cc\u04cd\3\2\2\2\u04cd\u04ce"+
		"\3\2\2\2\u04ce\u050a\7\6\2\2\u04cf\u04d0\t\26\2\2\u04d0\u04d1\7\5\2\2"+
		"\u04d1\u04d2\7\6\2\2\u04d2\u04d3\7\u0099\2\2\u04d3\u04d5\7\5\2\2\u04d4"+
		"\u04d6\5\u008eH\2\u04d5\u04d4\3\2\2\2\u04d5\u04d6\3\2\2\2\u04d6\u04d7"+
		"\3\2\2\2\u04d7\u04d8\5\u0092J\2\u04d8\u04d9\7\6\2\2\u04d9\u050a\3\2\2"+
		"\2\u04da\u04db\t\27\2\2\u04db\u04dc\7\5\2\2\u04dc\u04de\5*\26\2\u04dd"+
		"\u04df\5\u008aF\2\u04de\u04dd\3\2\2\2\u04de\u04df\3\2\2\2\u04df\u04e1"+
		"\3\2\2\2\u04e0\u04e2\5\u008cG\2\u04e1\u04e0\3\2\2\2\u04e1\u04e2\3\2\2"+
		"\2\u04e2\u04e3\3\2\2\2\u04e3\u04e4\7\6\2\2\u04e4\u04e5\7\u0099\2\2\u04e5"+
		"\u04e7\7\5\2\2\u04e6\u04e8\5\u008eH\2\u04e7\u04e6\3\2\2\2\u04e7\u04e8"+
		"\3\2\2\2\u04e8\u04e9\3\2\2\2\u04e9\u04ea\5\u0092J\2\u04ea\u04eb\7\6\2"+
		"\2\u04eb\u050a\3\2\2\2\u04ec\u04ed\7\u00a5\2\2\u04ed\u04ee\7\5\2\2\u04ee"+
		"\u04ef\5*\26\2\u04ef\u04f0\7\7\2\2\u04f0\u04f1\5\26\f\2\u04f1\u04f2\7"+
		"\6\2\2\u04f2\u04f3\7\u0099\2\2\u04f3\u04f5\7\5\2\2\u04f4\u04f6\5\u008e"+
		"H\2\u04f5\u04f4\3\2\2\2\u04f5\u04f6\3\2\2\2\u04f6\u04f7\3\2\2\2\u04f7"+
		"\u04f9\5\u0092J\2\u04f8\u04fa\5t;\2\u04f9\u04f8\3\2\2\2\u04f9\u04fa\3"+
		"\2\2\2\u04fa\u04fb\3\2\2\2\u04fb\u04fc\7\6\2\2\u04fc\u050a\3\2\2\2\u04fd"+
		"\u04fe\7\u00a6\2\2\u04fe\u04ff\7\5\2\2\u04ff\u0500\5*\26\2\u0500\u0501"+
		"\7\6\2\2\u0501\u0502\7\u0099\2\2\u0502\u0504\7\5\2\2\u0503\u0505\5\u008e"+
		"H\2\u0504\u0503\3\2\2\2\u0504\u0505\3\2\2\2\u0505\u0506\3\2\2\2\u0506"+
		"\u0507\5\u0092J\2\u0507\u0508\7\6\2\2\u0508\u050a\3\2\2\2\u0509\u04b4"+
		"\3\2\2\2\u0509\u04c3\3\2\2\2\u0509\u04cf\3\2\2\2\u0509\u04da\3\2\2\2\u0509"+
		"\u04ec\3\2\2\2\u0509\u04fd\3\2\2\2\u050a\u0089\3\2\2\2\u050b\u050c\7\7"+
		"\2\2\u050c\u050d\5\26\f\2\u050d\u008b\3\2\2\2\u050e\u050f\7\7\2\2\u050f"+
		"\u0510\5\26\f\2\u0510\u008d\3\2\2\2\u0511\u0512\7\u009a\2\2\u0512\u0514"+
		"\7*\2\2\u0513\u0515\5*\26\2\u0514\u0513\3\2\2\2\u0515\u0516\3\2\2\2\u0516"+
		"\u0514\3\2\2\2\u0516\u0517\3\2\2\2\u0517\u008f\3\2\2\2\u0518\u0519\7o"+
		"\2\2\u0519\u051b\7*\2\2\u051a\u051c\5*\26\2\u051b\u051a\3\2\2\2\u051c"+
		"\u051d\3\2\2\2\u051d\u051b\3\2\2\2\u051d\u051e\3\2\2\2\u051e\u0091\3\2"+
		"\2\2\u051f\u0520\7o\2\2\u0520\u0521\7*\2\2\u0521\u0522\5\u0092J\2\u0522"+
		"\u0093\3\2\2\2\u0523\u0524\5J&\2\u0524\u0095\3\2\2\2\u0525\u0526\5J&\2"+
		"\u0526\u0097\3\2\2\2\u0527\u0528\t\30\2\2\u0528\u0099\3\2\2\2\u0529\u052a"+
		"\7\u00bd\2\2\u052a\u009b\3\2\2\2\u052b\u052e\5*\26\2\u052c\u052e\5\20"+
		"\t\2\u052d\u052b\3\2\2\2\u052d\u052c\3\2\2\2\u052e\u009d\3\2\2\2\u052f"+
		"\u0530\t\31\2\2\u0530\u009f\3\2\2\2\u0531\u0532\t\32\2\2\u0532\u00a1\3"+
		"\2\2\2\u0533\u0534\5\u00c4c\2\u0534\u00a3\3\2\2\2\u0535\u0536\5\u00c4"+
		"c\2\u0536\u00a5\3\2\2\2\u0537\u0538\5\u00c4c\2\u0538\u00a7\3\2\2\2\u0539"+
		"\u053a\5\u00c4c\2\u053a\u00a9\3\2\2\2\u053b\u053c\5\u00c4c\2\u053c\u00ab"+
		"\3\2\2\2\u053d\u053e\5\u00c4c\2\u053e\u00ad\3\2\2\2\u053f\u0540\5\u00c4"+
		"c\2\u0540\u00af\3\2\2\2\u0541\u0542\5\u00c4c\2\u0542\u00b1\3\2\2\2\u0543"+
		"\u0544\5\u00c4c\2\u0544\u00b3\3\2\2\2\u0545\u0546\5\u00c4c\2\u0546\u00b5"+
		"\3\2\2\2\u0547\u0548\5\u00c4c\2\u0548\u00b7\3\2\2\2\u0549\u054a\5\u00c4"+
		"c\2\u054a\u00b9\3\2\2\2\u054b\u054c\5\u00c4c\2\u054c\u00bb\3\2\2\2\u054d"+
		"\u054e\5\u00c4c\2\u054e\u00bd\3\2\2\2\u054f\u0550\5\u00c4c\2\u0550\u00bf"+
		"\3\2\2\2\u0551\u0552\5\u00c4c\2\u0552\u00c1\3\2\2\2\u0553\u0554\5\u00c4"+
		"c\2\u0554\u00c3\3\2\2\2\u0555\u055d\7\u00ba\2\2\u0556\u055d\5\u00a0Q\2"+
		"\u0557\u055d\7\u00bd\2\2\u0558\u0559\7\5\2\2\u0559\u055a\5\u00c4c\2\u055a"+
		"\u055b\7\6\2\2\u055b\u055d\3\2\2\2\u055c\u0555\3\2\2\2\u055c\u0556\3\2"+
		"\2\2\u055c\u0557\3\2\2\2\u055c\u0558\3\2\2\2\u055d\u00c5\3\2\2\2\u00b8"+
		"\u00c8\u00ca\u00d5\u00dc\u00e1\u00e7\u00ed\u00ef\u00f6\u00fd\u0101\u0104"+
		"\u0108\u010e\u0113\u011c\u0123\u0129\u012d\u0131\u0136\u013c\u0148\u014c"+
		"\u0151\u0154\u0157\u015c\u015f\u016d\u0174\u017b\u017d\u0180\u0186\u018b"+
		"\u0193\u0198\u01a4\u01a9\u01b3\u01b7\u01b9\u01bd\u01c2\u01c4\u01cc\u01d2"+
		"\u01d7\u01db\u01e6\u01eb\u01f6\u01fb\u01ff\u020f\u0214\u021c\u0223\u023f"+
		"\u0243\u024b\u025b\u0261\u0263\u0265\u026b\u026f\u0273\u0276\u0279\u027f"+
		"\u0285\u028b\u0290\u0294\u029a\u029d\u02a8\u02ae\u02b1\u02bb\u02c0\u02c5"+
		"\u02d7\u02da\u02e4\u02eb\u02f2\u02f8\u02fd\u0300\u0305\u0308\u030c\u0316"+
		"\u031b\u031d\u0325\u032c\u0333\u0337\u0339\u033c\u0342\u0346\u0349\u0352"+
		"\u0357\u035b\u0362\u0367\u036a\u036d\u0375\u0378\u037c\u0388\u038f\u039d"+
		"\u03a3\u03a7\u03aa\u03b1\u03b6\u03bf\u03c4\u03c7\u03d1\u03d4\u03d6\u03dd"+
		"\u03e1\u03ea\u03ed\u03ef\u03f3\u03f7\u03fb\u03fe\u0404\u0408\u040c\u0414"+
		"\u0421\u0426\u042f\u0433\u043b\u0440\u0449\u044c\u044f\u0452\u045c\u0465"+
		"\u0469\u0470\u047a\u0480\u0488\u048b\u048f\u049d\u04a9\u04b2\u04bb\u04bf"+
		"\u04c9\u04cc\u04d5\u04de\u04e1\u04e7\u04f5\u04f9\u0504\u0509\u0516\u051d"+
		"\u052d\u055c";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}