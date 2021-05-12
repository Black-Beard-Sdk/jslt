// Generated from d:\Src\Sdk\jslt\src\Black.Beard.Jslt\Json\Jslt\Parser\Grammar\JsltParser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JsltParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		SUBSCRIPT=1, WILDCARD_SUBSCRIPT=2, CURRENT_VALUE=3, COLON=4, URI=5, TIME=6, 
		DATETIME=7, STRING_=8, GUID=9, WHEN=10, CASE=11, DEFAULT=12, EQ=13, NE=14, 
		GT=15, LT=16, LE=17, GE=18, NT=19, PLUS=20, MINUS=21, DIVID=22, MODULO=23, 
		POWER=24, AND=25, OR=26, AND_EXCLUSIVE=27, OR_EXCLUSIVE=28, CHAIN=29, 
		TRUE=30, FALSE=31, NULL=32, BRACE_LEFT=33, BRACE_RIGHT=34, BRACKET_LEFT=35, 
		BRACKET_RIGHT=36, COMMA=37, PAREN_LEFT=38, PAREN_RIGHT=39, STRING=40, 
		MULTI_LINE_COMMENT=41, NUMBER=42, INT=43, WS=44, ID=45;
	public static final int
		RULE_script = 0, RULE_json = 1, RULE_obj = 2, RULE_pair = 3, RULE_array = 4, 
		RULE_jsonValue = 5, RULE_jsonValueString = 6, RULE_jsonValueNumber = 7, 
		RULE_jsonValueInteger = 8, RULE_jsonValueBoolean = 9, RULE_jsonValueNull = 10, 
		RULE_jsonType = 11, RULE_jsonLtOperation = 12, RULE_jsonLtItem = 13, RULE_operation = 14, 
		RULE_jsonfunctionCall = 15, RULE_jsonValueList = 16, RULE_jsonWhen = 17, 
		RULE_jsonCase = 18, RULE_jsonDefaultCase = 19, RULE_jsonWhenExpression = 20;
	private static String[] makeRuleNames() {
		return new String[] {
			"script", "json", "obj", "pair", "array", "jsonValue", "jsonValueString", 
			"jsonValueNumber", "jsonValueInteger", "jsonValueBoolean", "jsonValueNull", 
			"jsonType", "jsonLtOperation", "jsonLtItem", "operation", "jsonfunctionCall", 
			"jsonValueList", "jsonWhen", "jsonCase", "jsonDefaultCase", "jsonWhenExpression"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "'*'", "'@'", "':'", "'uri'", "'time'", "'datetime'", "'string'", 
			"'uuid'", "'when'", "'case'", "'default'", "'=='", "'!='", "'>'", "'<'", 
			"'<='", "'>='", "'!'", "'+'", "'-'", "'/'", "'%'", "'^'", "'&'", "'|'", 
			"'&&'", "'||'", "'->'", "'true'", "'false'", "'null'", "'{'", "'}'", 
			"'['", "']'", "','", "'('", "')'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SUBSCRIPT", "WILDCARD_SUBSCRIPT", "CURRENT_VALUE", "COLON", "URI", 
			"TIME", "DATETIME", "STRING_", "GUID", "WHEN", "CASE", "DEFAULT", "EQ", 
			"NE", "GT", "LT", "LE", "GE", "NT", "PLUS", "MINUS", "DIVID", "MODULO", 
			"POWER", "AND", "OR", "AND_EXCLUSIVE", "OR_EXCLUSIVE", "CHAIN", "TRUE", 
			"FALSE", "NULL", "BRACE_LEFT", "BRACE_RIGHT", "BRACKET_LEFT", "BRACKET_RIGHT", 
			"COMMA", "PAREN_LEFT", "PAREN_RIGHT", "STRING", "MULTI_LINE_COMMENT", 
			"NUMBER", "INT", "WS", "ID"
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
	public String getGrammarFileName() { return "JsltParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public JsltParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ScriptContext extends ParserRuleContext {
		public JsonContext json() {
			return getRuleContext(JsonContext.class,0);
		}
		public TerminalNode EOF() { return getToken(JsltParser.EOF, 0); }
		public ScriptContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_script; }
	}

	public final ScriptContext script() throws RecognitionException {
		ScriptContext _localctx = new ScriptContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_script);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(42);
			json();
			setState(43);
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

	public static class JsonContext extends ParserRuleContext {
		public JsonValueContext jsonValue() {
			return getRuleContext(JsonValueContext.class,0);
		}
		public JsonContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_json; }
	}

	public final JsonContext json() throws RecognitionException {
		JsonContext _localctx = new JsonContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_json);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(45);
			jsonValue();
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

	public static class ObjContext extends ParserRuleContext {
		public TerminalNode BRACE_LEFT() { return getToken(JsltParser.BRACE_LEFT, 0); }
		public List<PairContext> pair() {
			return getRuleContexts(PairContext.class);
		}
		public PairContext pair(int i) {
			return getRuleContext(PairContext.class,i);
		}
		public TerminalNode BRACE_RIGHT() { return getToken(JsltParser.BRACE_RIGHT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(JsltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(JsltParser.COMMA, i);
		}
		public ObjContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_obj; }
	}

	public final ObjContext obj() throws RecognitionException {
		ObjContext _localctx = new ObjContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_obj);
		int _la;
		try {
			setState(60);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(47);
				match(BRACE_LEFT);
				setState(48);
				pair();
				setState(53);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(49);
					match(COMMA);
					setState(50);
					pair();
					}
					}
					setState(55);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(56);
				match(BRACE_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(58);
				match(BRACE_LEFT);
				setState(59);
				match(BRACE_RIGHT);
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

	public static class PairContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JsltParser.STRING, 0); }
		public TerminalNode COLON() { return getToken(JsltParser.COLON, 0); }
		public JsonValueContext jsonValue() {
			return getRuleContext(JsonValueContext.class,0);
		}
		public PairContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pair; }
	}

	public final PairContext pair() throws RecognitionException {
		PairContext _localctx = new PairContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_pair);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(62);
			match(STRING);
			setState(63);
			match(COLON);
			setState(64);
			jsonValue();
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

	public static class ArrayContext extends ParserRuleContext {
		public TerminalNode BRACKET_LEFT() { return getToken(JsltParser.BRACKET_LEFT, 0); }
		public List<JsonValueContext> jsonValue() {
			return getRuleContexts(JsonValueContext.class);
		}
		public JsonValueContext jsonValue(int i) {
			return getRuleContext(JsonValueContext.class,i);
		}
		public TerminalNode BRACKET_RIGHT() { return getToken(JsltParser.BRACKET_RIGHT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(JsltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(JsltParser.COMMA, i);
		}
		public ArrayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array; }
	}

	public final ArrayContext array() throws RecognitionException {
		ArrayContext _localctx = new ArrayContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_array);
		int _la;
		try {
			setState(79);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(66);
				match(BRACKET_LEFT);
				setState(67);
				jsonValue();
				setState(72);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(68);
					match(COMMA);
					setState(69);
					jsonValue();
					}
					}
					setState(74);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(75);
				match(BRACKET_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(77);
				match(BRACKET_LEFT);
				setState(78);
				match(BRACKET_RIGHT);
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

	public static class JsonValueContext extends ParserRuleContext {
		public ObjContext obj() {
			return getRuleContext(ObjContext.class,0);
		}
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public JsonLtOperationContext jsonLtOperation() {
			return getRuleContext(JsonLtOperationContext.class,0);
		}
		public JsonValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValue; }
	}

	public final JsonValueContext jsonValue() throws RecognitionException {
		JsonValueContext _localctx = new JsonValueContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_jsonValue);
		try {
			setState(84);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BRACE_LEFT:
				enterOuterAlt(_localctx, 1);
				{
				setState(81);
				obj();
				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(82);
				array();
				}
				break;
			case SUBSCRIPT:
			case CURRENT_VALUE:
			case NT:
			case TRUE:
			case FALSE:
			case NULL:
			case PAREN_LEFT:
			case STRING:
			case NUMBER:
			case INT:
				enterOuterAlt(_localctx, 3);
				{
				setState(83);
				jsonLtOperation();
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

	public static class JsonValueStringContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JsltParser.STRING, 0); }
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
		}
		public JsonValueStringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueString; }
	}

	public final JsonValueStringContext jsonValueString() throws RecognitionException {
		JsonValueStringContext _localctx = new JsonValueStringContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_jsonValueString);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(86);
			match(STRING);
			setState(88);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CURRENT_VALUE) {
				{
				setState(87);
				jsonType();
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

	public static class JsonValueNumberContext extends ParserRuleContext {
		public TerminalNode NUMBER() { return getToken(JsltParser.NUMBER, 0); }
		public JsonValueNumberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueNumber; }
	}

	public final JsonValueNumberContext jsonValueNumber() throws RecognitionException {
		JsonValueNumberContext _localctx = new JsonValueNumberContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_jsonValueNumber);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(90);
			match(NUMBER);
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

	public static class JsonValueIntegerContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(JsltParser.INT, 0); }
		public JsonValueIntegerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueInteger; }
	}

	public final JsonValueIntegerContext jsonValueInteger() throws RecognitionException {
		JsonValueIntegerContext _localctx = new JsonValueIntegerContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_jsonValueInteger);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(92);
			match(INT);
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

	public static class JsonValueBooleanContext extends ParserRuleContext {
		public TerminalNode TRUE() { return getToken(JsltParser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(JsltParser.FALSE, 0); }
		public JsonValueBooleanContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueBoolean; }
	}

	public final JsonValueBooleanContext jsonValueBoolean() throws RecognitionException {
		JsonValueBooleanContext _localctx = new JsonValueBooleanContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_jsonValueBoolean);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(94);
			_la = _input.LA(1);
			if ( !(_la==TRUE || _la==FALSE) ) {
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

	public static class JsonValueNullContext extends ParserRuleContext {
		public TerminalNode NULL() { return getToken(JsltParser.NULL, 0); }
		public JsonValueNullContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueNull; }
	}

	public final JsonValueNullContext jsonValueNull() throws RecognitionException {
		JsonValueNullContext _localctx = new JsonValueNullContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_jsonValueNull);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			match(NULL);
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

	public static class JsonTypeContext extends ParserRuleContext {
		public TerminalNode CURRENT_VALUE() { return getToken(JsltParser.CURRENT_VALUE, 0); }
		public TerminalNode URI() { return getToken(JsltParser.URI, 0); }
		public TerminalNode TIME() { return getToken(JsltParser.TIME, 0); }
		public TerminalNode DATETIME() { return getToken(JsltParser.DATETIME, 0); }
		public TerminalNode STRING_() { return getToken(JsltParser.STRING_, 0); }
		public TerminalNode GUID() { return getToken(JsltParser.GUID, 0); }
		public JsonTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonType; }
	}

	public final JsonTypeContext jsonType() throws RecognitionException {
		JsonTypeContext _localctx = new JsonTypeContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_jsonType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(98);
			match(CURRENT_VALUE);
			setState(99);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << URI) | (1L << TIME) | (1L << DATETIME) | (1L << STRING_) | (1L << GUID))) != 0)) ) {
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

	public static class JsonLtOperationContext extends ParserRuleContext {
		public JsonLtItemContext jsonLtItem() {
			return getRuleContext(JsonLtItemContext.class,0);
		}
		public TerminalNode NT() { return getToken(JsltParser.NT, 0); }
		public OperationContext operation() {
			return getRuleContext(OperationContext.class,0);
		}
		public JsonLtOperationContext jsonLtOperation() {
			return getRuleContext(JsonLtOperationContext.class,0);
		}
		public TerminalNode PAREN_LEFT() { return getToken(JsltParser.PAREN_LEFT, 0); }
		public TerminalNode PAREN_RIGHT() { return getToken(JsltParser.PAREN_RIGHT, 0); }
		public JsonLtOperationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonLtOperation; }
	}

	public final JsonLtOperationContext jsonLtOperation() throws RecognitionException {
		JsonLtOperationContext _localctx = new JsonLtOperationContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_jsonLtOperation);
		int _la;
		try {
			setState(114);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case SUBSCRIPT:
			case CURRENT_VALUE:
			case NT:
			case TRUE:
			case FALSE:
			case NULL:
			case STRING:
			case NUMBER:
			case INT:
				enterOuterAlt(_localctx, 1);
				{
				setState(102);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NT) {
					{
					setState(101);
					match(NT);
					}
				}

				setState(104);
				jsonLtItem();
				setState(108);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WILDCARD_SUBSCRIPT) | (1L << EQ) | (1L << NE) | (1L << GT) | (1L << LT) | (1L << LE) | (1L << GE) | (1L << PLUS) | (1L << MINUS) | (1L << DIVID) | (1L << MODULO) | (1L << POWER) | (1L << AND) | (1L << OR) | (1L << AND_EXCLUSIVE) | (1L << OR_EXCLUSIVE) | (1L << CHAIN))) != 0)) {
					{
					setState(105);
					operation();
					setState(106);
					jsonLtOperation();
					}
				}

				}
				break;
			case PAREN_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(110);
				match(PAREN_LEFT);
				setState(111);
				jsonLtOperation();
				setState(112);
				match(PAREN_RIGHT);
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

	public static class JsonLtItemContext extends ParserRuleContext {
		public JsonfunctionCallContext jsonfunctionCall() {
			return getRuleContext(JsonfunctionCallContext.class,0);
		}
		public JsonWhenContext jsonWhen() {
			return getRuleContext(JsonWhenContext.class,0);
		}
		public JsonValueBooleanContext jsonValueBoolean() {
			return getRuleContext(JsonValueBooleanContext.class,0);
		}
		public JsonValueStringContext jsonValueString() {
			return getRuleContext(JsonValueStringContext.class,0);
		}
		public JsonValueIntegerContext jsonValueInteger() {
			return getRuleContext(JsonValueIntegerContext.class,0);
		}
		public JsonValueNumberContext jsonValueNumber() {
			return getRuleContext(JsonValueNumberContext.class,0);
		}
		public JsonValueNullContext jsonValueNull() {
			return getRuleContext(JsonValueNullContext.class,0);
		}
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
		}
		public JsonLtItemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonLtItem; }
	}

	public final JsonLtItemContext jsonLtItem() throws RecognitionException {
		JsonLtItemContext _localctx = new JsonLtItemContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_jsonLtItem);
		try {
			setState(124);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(116);
				jsonfunctionCall();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(117);
				jsonWhen();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(118);
				jsonValueBoolean();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(119);
				jsonValueString();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(120);
				jsonValueInteger();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(121);
				jsonValueNumber();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(122);
				jsonValueNull();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(123);
				jsonType();
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

	public static class OperationContext extends ParserRuleContext {
		public TerminalNode EQ() { return getToken(JsltParser.EQ, 0); }
		public TerminalNode GE() { return getToken(JsltParser.GE, 0); }
		public TerminalNode GT() { return getToken(JsltParser.GT, 0); }
		public TerminalNode LE() { return getToken(JsltParser.LE, 0); }
		public TerminalNode LT() { return getToken(JsltParser.LT, 0); }
		public TerminalNode NE() { return getToken(JsltParser.NE, 0); }
		public TerminalNode PLUS() { return getToken(JsltParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(JsltParser.MINUS, 0); }
		public TerminalNode DIVID() { return getToken(JsltParser.DIVID, 0); }
		public TerminalNode MODULO() { return getToken(JsltParser.MODULO, 0); }
		public TerminalNode WILDCARD_SUBSCRIPT() { return getToken(JsltParser.WILDCARD_SUBSCRIPT, 0); }
		public TerminalNode POWER() { return getToken(JsltParser.POWER, 0); }
		public TerminalNode CHAIN() { return getToken(JsltParser.CHAIN, 0); }
		public TerminalNode AND() { return getToken(JsltParser.AND, 0); }
		public TerminalNode OR() { return getToken(JsltParser.OR, 0); }
		public TerminalNode AND_EXCLUSIVE() { return getToken(JsltParser.AND_EXCLUSIVE, 0); }
		public TerminalNode OR_EXCLUSIVE() { return getToken(JsltParser.OR_EXCLUSIVE, 0); }
		public OperationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operation; }
	}

	public final OperationContext operation() throws RecognitionException {
		OperationContext _localctx = new OperationContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_operation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(126);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WILDCARD_SUBSCRIPT) | (1L << EQ) | (1L << NE) | (1L << GT) | (1L << LT) | (1L << LE) | (1L << GE) | (1L << PLUS) | (1L << MINUS) | (1L << DIVID) | (1L << MODULO) | (1L << POWER) | (1L << AND) | (1L << OR) | (1L << AND_EXCLUSIVE) | (1L << OR_EXCLUSIVE) | (1L << CHAIN))) != 0)) ) {
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

	public static class JsonfunctionCallContext extends ParserRuleContext {
		public TerminalNode SUBSCRIPT() { return getToken(JsltParser.SUBSCRIPT, 0); }
		public TerminalNode ID() { return getToken(JsltParser.ID, 0); }
		public TerminalNode PAREN_LEFT() { return getToken(JsltParser.PAREN_LEFT, 0); }
		public TerminalNode PAREN_RIGHT() { return getToken(JsltParser.PAREN_RIGHT, 0); }
		public JsonValueListContext jsonValueList() {
			return getRuleContext(JsonValueListContext.class,0);
		}
		public JsonfunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonfunctionCall; }
	}

	public final JsonfunctionCallContext jsonfunctionCall() throws RecognitionException {
		JsonfunctionCallContext _localctx = new JsonfunctionCallContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_jsonfunctionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(128);
			match(SUBSCRIPT);
			setState(129);
			match(ID);
			setState(130);
			match(PAREN_LEFT);
			setState(132);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << SUBSCRIPT) | (1L << CURRENT_VALUE) | (1L << NT) | (1L << TRUE) | (1L << FALSE) | (1L << NULL) | (1L << BRACE_LEFT) | (1L << BRACKET_LEFT) | (1L << PAREN_LEFT) | (1L << STRING) | (1L << NUMBER) | (1L << INT))) != 0)) {
				{
				setState(131);
				jsonValueList();
				}
			}

			setState(134);
			match(PAREN_RIGHT);
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

	public static class JsonValueListContext extends ParserRuleContext {
		public List<JsonValueContext> jsonValue() {
			return getRuleContexts(JsonValueContext.class);
		}
		public JsonValueContext jsonValue(int i) {
			return getRuleContext(JsonValueContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(JsltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(JsltParser.COMMA, i);
		}
		public JsonValueListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueList; }
	}

	public final JsonValueListContext jsonValueList() throws RecognitionException {
		JsonValueListContext _localctx = new JsonValueListContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_jsonValueList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(136);
			jsonValue();
			setState(141);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(137);
				match(COMMA);
				setState(138);
				jsonValue();
				}
				}
				setState(143);
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

	public static class JsonWhenContext extends ParserRuleContext {
		public TerminalNode SUBSCRIPT() { return getToken(JsltParser.SUBSCRIPT, 0); }
		public TerminalNode WHEN() { return getToken(JsltParser.WHEN, 0); }
		public JsonWhenExpressionContext jsonWhenExpression() {
			return getRuleContext(JsonWhenExpressionContext.class,0);
		}
		public List<JsonCaseContext> jsonCase() {
			return getRuleContexts(JsonCaseContext.class);
		}
		public JsonCaseContext jsonCase(int i) {
			return getRuleContext(JsonCaseContext.class,i);
		}
		public JsonDefaultCaseContext jsonDefaultCase() {
			return getRuleContext(JsonDefaultCaseContext.class,0);
		}
		public JsonWhenContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonWhen; }
	}

	public final JsonWhenContext jsonWhen() throws RecognitionException {
		JsonWhenContext _localctx = new JsonWhenContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_jsonWhen);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(144);
			match(SUBSCRIPT);
			setState(145);
			match(WHEN);
			setState(146);
			jsonWhenExpression();
			setState(148); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(147);
					jsonCase();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(150); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(153);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==DEFAULT) {
				{
				setState(152);
				jsonDefaultCase();
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

	public static class JsonCaseContext extends ParserRuleContext {
		public TerminalNode CASE() { return getToken(JsltParser.CASE, 0); }
		public JsonWhenExpressionContext jsonWhenExpression() {
			return getRuleContext(JsonWhenExpressionContext.class,0);
		}
		public TerminalNode COLON() { return getToken(JsltParser.COLON, 0); }
		public TerminalNode BRACE_LEFT() { return getToken(JsltParser.BRACE_LEFT, 0); }
		public JsonValueContext jsonValue() {
			return getRuleContext(JsonValueContext.class,0);
		}
		public TerminalNode BRACE_RIGHT() { return getToken(JsltParser.BRACE_RIGHT, 0); }
		public JsonDefaultCaseContext jsonDefaultCase() {
			return getRuleContext(JsonDefaultCaseContext.class,0);
		}
		public JsonCaseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonCase; }
	}

	public final JsonCaseContext jsonCase() throws RecognitionException {
		JsonCaseContext _localctx = new JsonCaseContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_jsonCase);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(155);
			match(CASE);
			setState(156);
			jsonWhenExpression();
			setState(157);
			match(COLON);
			setState(158);
			match(BRACE_LEFT);
			setState(159);
			jsonValue();
			setState(160);
			match(BRACE_RIGHT);
			setState(162);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(161);
				jsonDefaultCase();
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

	public static class JsonDefaultCaseContext extends ParserRuleContext {
		public TerminalNode DEFAULT() { return getToken(JsltParser.DEFAULT, 0); }
		public TerminalNode COLON() { return getToken(JsltParser.COLON, 0); }
		public TerminalNode BRACE_LEFT() { return getToken(JsltParser.BRACE_LEFT, 0); }
		public JsonValueContext jsonValue() {
			return getRuleContext(JsonValueContext.class,0);
		}
		public TerminalNode BRACE_RIGHT() { return getToken(JsltParser.BRACE_RIGHT, 0); }
		public JsonDefaultCaseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonDefaultCase; }
	}

	public final JsonDefaultCaseContext jsonDefaultCase() throws RecognitionException {
		JsonDefaultCaseContext _localctx = new JsonDefaultCaseContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_jsonDefaultCase);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(164);
			match(DEFAULT);
			setState(165);
			match(COLON);
			setState(166);
			match(BRACE_LEFT);
			setState(167);
			jsonValue();
			setState(168);
			match(BRACE_RIGHT);
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

	public static class JsonWhenExpressionContext extends ParserRuleContext {
		public JsonValueBooleanContext jsonValueBoolean() {
			return getRuleContext(JsonValueBooleanContext.class,0);
		}
		public JsonValueStringContext jsonValueString() {
			return getRuleContext(JsonValueStringContext.class,0);
		}
		public JsonValueIntegerContext jsonValueInteger() {
			return getRuleContext(JsonValueIntegerContext.class,0);
		}
		public JsonValueNumberContext jsonValueNumber() {
			return getRuleContext(JsonValueNumberContext.class,0);
		}
		public JsonValueNullContext jsonValueNull() {
			return getRuleContext(JsonValueNullContext.class,0);
		}
		public JsonLtOperationContext jsonLtOperation() {
			return getRuleContext(JsonLtOperationContext.class,0);
		}
		public JsonWhenExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonWhenExpression; }
	}

	public final JsonWhenExpressionContext jsonWhenExpression() throws RecognitionException {
		JsonWhenExpressionContext _localctx = new JsonWhenExpressionContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_jsonWhenExpression);
		try {
			setState(176);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(170);
				jsonValueBoolean();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(171);
				jsonValueString();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(172);
				jsonValueInteger();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(173);
				jsonValueNumber();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(174);
				jsonValueNull();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(175);
				jsonLtOperation();
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

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3/\u00b5\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\3\2\3\2\3\2\3\3\3\3\3\4\3\4\3"+
		"\4\3\4\7\4\66\n\4\f\4\16\49\13\4\3\4\3\4\3\4\3\4\5\4?\n\4\3\5\3\5\3\5"+
		"\3\5\3\6\3\6\3\6\3\6\7\6I\n\6\f\6\16\6L\13\6\3\6\3\6\3\6\3\6\5\6R\n\6"+
		"\3\7\3\7\3\7\5\7W\n\7\3\b\3\b\5\b[\n\b\3\t\3\t\3\n\3\n\3\13\3\13\3\f\3"+
		"\f\3\r\3\r\3\r\3\16\5\16i\n\16\3\16\3\16\3\16\3\16\5\16o\n\16\3\16\3\16"+
		"\3\16\3\16\5\16u\n\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\5\17\177"+
		"\n\17\3\20\3\20\3\21\3\21\3\21\3\21\5\21\u0087\n\21\3\21\3\21\3\22\3\22"+
		"\3\22\7\22\u008e\n\22\f\22\16\22\u0091\13\22\3\23\3\23\3\23\3\23\6\23"+
		"\u0097\n\23\r\23\16\23\u0098\3\23\5\23\u009c\n\23\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\5\24\u00a5\n\24\3\25\3\25\3\25\3\25\3\25\3\25\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\5\26\u00b3\n\26\3\26\2\2\27\2\4\6\b\n\f\16\20\22"+
		"\24\26\30\32\34\36 \"$&(*\2\5\3\2 !\3\2\7\13\5\2\4\4\17\24\26\37\2\u00ba"+
		"\2,\3\2\2\2\4/\3\2\2\2\6>\3\2\2\2\b@\3\2\2\2\nQ\3\2\2\2\fV\3\2\2\2\16"+
		"X\3\2\2\2\20\\\3\2\2\2\22^\3\2\2\2\24`\3\2\2\2\26b\3\2\2\2\30d\3\2\2\2"+
		"\32t\3\2\2\2\34~\3\2\2\2\36\u0080\3\2\2\2 \u0082\3\2\2\2\"\u008a\3\2\2"+
		"\2$\u0092\3\2\2\2&\u009d\3\2\2\2(\u00a6\3\2\2\2*\u00b2\3\2\2\2,-\5\4\3"+
		"\2-.\7\2\2\3.\3\3\2\2\2/\60\5\f\7\2\60\5\3\2\2\2\61\62\7#\2\2\62\67\5"+
		"\b\5\2\63\64\7\'\2\2\64\66\5\b\5\2\65\63\3\2\2\2\669\3\2\2\2\67\65\3\2"+
		"\2\2\678\3\2\2\28:\3\2\2\29\67\3\2\2\2:;\7$\2\2;?\3\2\2\2<=\7#\2\2=?\7"+
		"$\2\2>\61\3\2\2\2><\3\2\2\2?\7\3\2\2\2@A\7*\2\2AB\7\6\2\2BC\5\f\7\2C\t"+
		"\3\2\2\2DE\7%\2\2EJ\5\f\7\2FG\7\'\2\2GI\5\f\7\2HF\3\2\2\2IL\3\2\2\2JH"+
		"\3\2\2\2JK\3\2\2\2KM\3\2\2\2LJ\3\2\2\2MN\7&\2\2NR\3\2\2\2OP\7%\2\2PR\7"+
		"&\2\2QD\3\2\2\2QO\3\2\2\2R\13\3\2\2\2SW\5\6\4\2TW\5\n\6\2UW\5\32\16\2"+
		"VS\3\2\2\2VT\3\2\2\2VU\3\2\2\2W\r\3\2\2\2XZ\7*\2\2Y[\5\30\r\2ZY\3\2\2"+
		"\2Z[\3\2\2\2[\17\3\2\2\2\\]\7,\2\2]\21\3\2\2\2^_\7-\2\2_\23\3\2\2\2`a"+
		"\t\2\2\2a\25\3\2\2\2bc\7\"\2\2c\27\3\2\2\2de\7\5\2\2ef\t\3\2\2f\31\3\2"+
		"\2\2gi\7\25\2\2hg\3\2\2\2hi\3\2\2\2ij\3\2\2\2jn\5\34\17\2kl\5\36\20\2"+
		"lm\5\32\16\2mo\3\2\2\2nk\3\2\2\2no\3\2\2\2ou\3\2\2\2pq\7(\2\2qr\5\32\16"+
		"\2rs\7)\2\2su\3\2\2\2th\3\2\2\2tp\3\2\2\2u\33\3\2\2\2v\177\5 \21\2w\177"+
		"\5$\23\2x\177\5\24\13\2y\177\5\16\b\2z\177\5\22\n\2{\177\5\20\t\2|\177"+
		"\5\26\f\2}\177\5\30\r\2~v\3\2\2\2~w\3\2\2\2~x\3\2\2\2~y\3\2\2\2~z\3\2"+
		"\2\2~{\3\2\2\2~|\3\2\2\2~}\3\2\2\2\177\35\3\2\2\2\u0080\u0081\t\4\2\2"+
		"\u0081\37\3\2\2\2\u0082\u0083\7\3\2\2\u0083\u0084\7/\2\2\u0084\u0086\7"+
		"(\2\2\u0085\u0087\5\"\22\2\u0086\u0085\3\2\2\2\u0086\u0087\3\2\2\2\u0087"+
		"\u0088\3\2\2\2\u0088\u0089\7)\2\2\u0089!\3\2\2\2\u008a\u008f\5\f\7\2\u008b"+
		"\u008c\7\'\2\2\u008c\u008e\5\f\7\2\u008d\u008b\3\2\2\2\u008e\u0091\3\2"+
		"\2\2\u008f\u008d\3\2\2\2\u008f\u0090\3\2\2\2\u0090#\3\2\2\2\u0091\u008f"+
		"\3\2\2\2\u0092\u0093\7\3\2\2\u0093\u0094\7\f\2\2\u0094\u0096\5*\26\2\u0095"+
		"\u0097\5&\24\2\u0096\u0095\3\2\2\2\u0097\u0098\3\2\2\2\u0098\u0096\3\2"+
		"\2\2\u0098\u0099\3\2\2\2\u0099\u009b\3\2\2\2\u009a\u009c\5(\25\2\u009b"+
		"\u009a\3\2\2\2\u009b\u009c\3\2\2\2\u009c%\3\2\2\2\u009d\u009e\7\r\2\2"+
		"\u009e\u009f\5*\26\2\u009f\u00a0\7\6\2\2\u00a0\u00a1\7#\2\2\u00a1\u00a2"+
		"\5\f\7\2\u00a2\u00a4\7$\2\2\u00a3\u00a5\5(\25\2\u00a4\u00a3\3\2\2\2\u00a4"+
		"\u00a5\3\2\2\2\u00a5\'\3\2\2\2\u00a6\u00a7\7\16\2\2\u00a7\u00a8\7\6\2"+
		"\2\u00a8\u00a9\7#\2\2\u00a9\u00aa\5\f\7\2\u00aa\u00ab\7$\2\2\u00ab)\3"+
		"\2\2\2\u00ac\u00b3\5\24\13\2\u00ad\u00b3\5\16\b\2\u00ae\u00b3\5\22\n\2"+
		"\u00af\u00b3\5\20\t\2\u00b0\u00b3\5\26\f\2\u00b1\u00b3\5\32\16\2\u00b2"+
		"\u00ac\3\2\2\2\u00b2\u00ad\3\2\2\2\u00b2\u00ae\3\2\2\2\u00b2\u00af\3\2"+
		"\2\2\u00b2\u00b0\3\2\2\2\u00b2\u00b1\3\2\2\2\u00b3+\3\2\2\2\22\67>JQV"+
		"Zhnt~\u0086\u008f\u0098\u009b\u00a4\u00b2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}