// Generated from c:\_perso\Src\jslt\src\Black.Beard.Jslt\Json\Jslt\Parser\Grammar\JsltParser.g4 by ANTLR 4.8
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
		DATETIME=7, STRING_=8, GUID=9, WHEN=10, CASE=11, DEFAULT=12, INTEGER=13, 
		DECIMAL=14, EQ=15, NE=16, GT=17, LT=18, LE=19, GE=20, NT=21, PLUS=22, 
		MINUS=23, DIVID=24, MODULO=25, POWER=26, AND=27, OR=28, AND_EXCLUSIVE=29, 
		OR_EXCLUSIVE=30, COALESCE=31, CHAIN=32, TRUE=33, FALSE=34, NULL=35, BRACE_LEFT=36, 
		BRACE_RIGHT=37, BRACKET_LEFT=38, BRACKET_RIGHT=39, COMMA=40, PAREN_LEFT=41, 
		PAREN_RIGHT=42, STRING=43, MULTI_LINE_COMMENT=44, NUMBER=45, INT=46, WS=47, 
		ID=48, DOT_ID=49;
	public static final int
		RULE_script = 0, RULE_json = 1, RULE_obj = 2, RULE_pair = 3, RULE_array = 4, 
		RULE_jsonValue = 5, RULE_jsonValueString = 6, RULE_jsonValueNumber = 7, 
		RULE_jsonValueInteger = 8, RULE_jsonValueBoolean = 9, RULE_jsonValueNull = 10, 
		RULE_jsonType = 11, RULE_jsonLtOperation = 12, RULE_jsonLtItem = 13, RULE_operation = 14, 
		RULE_jsonfunctionCall = 15, RULE_jsonValueList = 16;
	private static String[] makeRuleNames() {
		return new String[] {
			"script", "json", "obj", "pair", "array", "jsonValue", "jsonValueString", 
			"jsonValueNumber", "jsonValueInteger", "jsonValueBoolean", "jsonValueNull", 
			"jsonType", "jsonLtOperation", "jsonLtItem", "operation", "jsonfunctionCall", 
			"jsonValueList"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "'*'", "'@'", "':'", "'uri'", "'time'", "'datetime'", "'string'", 
			"'uuid'", "'when'", "'case'", "'default'", "'integer'", "'decimal'", 
			"'=='", "'!='", "'>'", "'<'", "'<='", "'>='", "'!'", "'+'", "'-'", "'/'", 
			"'%'", "'^'", "'&'", "'|'", "'&&'", "'||'", "'??'", "'->'", "'true'", 
			"'false'", "'null'", "'{'", "'}'", "'['", "']'", "','", "'('", "')'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SUBSCRIPT", "WILDCARD_SUBSCRIPT", "CURRENT_VALUE", "COLON", "URI", 
			"TIME", "DATETIME", "STRING_", "GUID", "WHEN", "CASE", "DEFAULT", "INTEGER", 
			"DECIMAL", "EQ", "NE", "GT", "LT", "LE", "GE", "NT", "PLUS", "MINUS", 
			"DIVID", "MODULO", "POWER", "AND", "OR", "AND_EXCLUSIVE", "OR_EXCLUSIVE", 
			"COALESCE", "CHAIN", "TRUE", "FALSE", "NULL", "BRACE_LEFT", "BRACE_RIGHT", 
			"BRACKET_LEFT", "BRACKET_RIGHT", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", 
			"STRING", "MULTI_LINE_COMMENT", "NUMBER", "INT", "WS", "ID", "DOT_ID"
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
			setState(34);
			json();
			setState(35);
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
			setState(37);
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
			setState(52);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(39);
				match(BRACE_LEFT);
				setState(40);
				pair();
				setState(45);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(41);
					match(COMMA);
					setState(42);
					pair();
					}
					}
					setState(47);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(48);
				match(BRACE_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(50);
				match(BRACE_LEFT);
				setState(51);
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
			setState(54);
			match(STRING);
			setState(55);
			match(COLON);
			setState(56);
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
			setState(71);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(58);
				match(BRACKET_LEFT);
				setState(59);
				jsonValue();
				setState(64);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(60);
					match(COMMA);
					setState(61);
					jsonValue();
					}
					}
					setState(66);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(67);
				match(BRACKET_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(69);
				match(BRACKET_LEFT);
				setState(70);
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
			setState(76);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BRACE_LEFT:
				enterOuterAlt(_localctx, 1);
				{
				setState(73);
				obj();
				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(74);
				array();
				}
				break;
			case NT:
			case TRUE:
			case FALSE:
			case NULL:
			case PAREN_LEFT:
			case STRING:
			case NUMBER:
			case INT:
			case DOT_ID:
				enterOuterAlt(_localctx, 3);
				{
				setState(75);
				jsonLtOperation(0);
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
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(78);
			match(STRING);
			setState(80);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
			case 1:
				{
				setState(79);
				jsonType();
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

	public static class JsonValueNumberContext extends ParserRuleContext {
		public TerminalNode NUMBER() { return getToken(JsltParser.NUMBER, 0); }
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
		}
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
			setState(82);
			match(NUMBER);
			setState(84);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				{
				setState(83);
				jsonType();
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

	public static class JsonValueIntegerContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(JsltParser.INT, 0); }
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
		}
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
			setState(86);
			match(INT);
			setState(88);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				{
				setState(87);
				jsonType();
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

	public static class JsonValueBooleanContext extends ParserRuleContext {
		public TerminalNode TRUE() { return getToken(JsltParser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(JsltParser.FALSE, 0); }
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
		}
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
			setState(90);
			_la = _input.LA(1);
			if ( !(_la==TRUE || _la==FALSE) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(92);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(91);
				jsonType();
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
			setState(94);
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
		public TerminalNode INTEGER() { return getToken(JsltParser.INTEGER, 0); }
		public TerminalNode DECIMAL() { return getToken(JsltParser.DECIMAL, 0); }
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
			setState(96);
			match(CURRENT_VALUE);
			setState(97);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << URI) | (1L << TIME) | (1L << DATETIME) | (1L << STRING_) | (1L << GUID) | (1L << INTEGER) | (1L << DECIMAL))) != 0)) ) {
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
		public List<JsonLtOperationContext> jsonLtOperation() {
			return getRuleContexts(JsonLtOperationContext.class);
		}
		public JsonLtOperationContext jsonLtOperation(int i) {
			return getRuleContext(JsonLtOperationContext.class,i);
		}
		public TerminalNode PAREN_LEFT() { return getToken(JsltParser.PAREN_LEFT, 0); }
		public TerminalNode PAREN_RIGHT() { return getToken(JsltParser.PAREN_RIGHT, 0); }
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
		}
		public OperationContext operation() {
			return getRuleContext(OperationContext.class,0);
		}
		public JsonLtOperationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonLtOperation; }
	}

	public final JsonLtOperationContext jsonLtOperation() throws RecognitionException {
		return jsonLtOperation(0);
	}

	private JsonLtOperationContext jsonLtOperation(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		JsonLtOperationContext _localctx = new JsonLtOperationContext(_ctx, _parentState);
		JsonLtOperationContext _prevctx = _localctx;
		int _startState = 24;
		enterRecursionRule(_localctx, 24, RULE_jsonLtOperation, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case TRUE:
			case FALSE:
			case NULL:
			case STRING:
			case NUMBER:
			case INT:
			case DOT_ID:
				{
				setState(100);
				jsonLtItem();
				}
				break;
			case NT:
				{
				setState(101);
				match(NT);
				setState(102);
				jsonLtOperation(3);
				}
				break;
			case PAREN_LEFT:
				{
				setState(103);
				match(PAREN_LEFT);
				setState(104);
				jsonLtOperation(0);
				setState(105);
				match(PAREN_RIGHT);
				setState(107);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
				case 1:
					{
					setState(106);
					jsonType();
					}
					break;
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(117);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new JsonLtOperationContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_jsonLtOperation);
					setState(111);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(112);
					operation();
					setState(113);
					jsonLtOperation(2);
					}
					} 
				}
				setState(119);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
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

	public static class JsonLtItemContext extends ParserRuleContext {
		public JsonfunctionCallContext jsonfunctionCall() {
			return getRuleContext(JsonfunctionCallContext.class,0);
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
		public JsonLtItemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonLtItem; }
	}

	public final JsonLtItemContext jsonLtItem() throws RecognitionException {
		JsonLtItemContext _localctx = new JsonLtItemContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_jsonLtItem);
		try {
			setState(126);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case DOT_ID:
				enterOuterAlt(_localctx, 1);
				{
				setState(120);
				jsonfunctionCall();
				}
				break;
			case TRUE:
			case FALSE:
				enterOuterAlt(_localctx, 2);
				{
				setState(121);
				jsonValueBoolean();
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 3);
				{
				setState(122);
				jsonValueString();
				}
				break;
			case INT:
				enterOuterAlt(_localctx, 4);
				{
				setState(123);
				jsonValueInteger();
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 5);
				{
				setState(124);
				jsonValueNumber();
				}
				break;
			case NULL:
				enterOuterAlt(_localctx, 6);
				{
				setState(125);
				jsonValueNull();
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
		public TerminalNode COALESCE() { return getToken(JsltParser.COALESCE, 0); }
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
			setState(128);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WILDCARD_SUBSCRIPT) | (1L << EQ) | (1L << NE) | (1L << GT) | (1L << LT) | (1L << LE) | (1L << GE) | (1L << PLUS) | (1L << MINUS) | (1L << DIVID) | (1L << MODULO) | (1L << POWER) | (1L << AND) | (1L << OR) | (1L << AND_EXCLUSIVE) | (1L << OR_EXCLUSIVE) | (1L << COALESCE) | (1L << CHAIN))) != 0)) ) {
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
		public TerminalNode DOT_ID() { return getToken(JsltParser.DOT_ID, 0); }
		public TerminalNode PAREN_LEFT() { return getToken(JsltParser.PAREN_LEFT, 0); }
		public TerminalNode PAREN_RIGHT() { return getToken(JsltParser.PAREN_RIGHT, 0); }
		public JsonValueListContext jsonValueList() {
			return getRuleContext(JsonValueListContext.class,0);
		}
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
		}
		public ObjContext obj() {
			return getRuleContext(ObjContext.class,0);
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
			setState(130);
			match(DOT_ID);
			setState(131);
			match(PAREN_LEFT);
			setState(133);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NT) | (1L << TRUE) | (1L << FALSE) | (1L << NULL) | (1L << BRACE_LEFT) | (1L << BRACKET_LEFT) | (1L << PAREN_LEFT) | (1L << STRING) | (1L << NUMBER) | (1L << INT) | (1L << DOT_ID))) != 0)) {
				{
				setState(132);
				jsonValueList();
				}
			}

			setState(135);
			match(PAREN_RIGHT);
			setState(137);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(136);
				jsonType();
				}
				break;
			}
			setState(140);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				{
				setState(139);
				obj();
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
			setState(142);
			jsonValue();
			setState(147);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(143);
				match(COMMA);
				setState(144);
				jsonValue();
				}
				}
				setState(149);
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

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 12:
			return jsonLtOperation_sempred((JsonLtOperationContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean jsonLtOperation_sempred(JsonLtOperationContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\63\u0099\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\3\2\3\2\3\2\3\3\3\3\3\4\3\4\3\4\3\4\7\4.\n\4\f\4\16\4\61\13\4\3\4\3\4"+
		"\3\4\3\4\5\4\67\n\4\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\7\6A\n\6\f\6\16\6"+
		"D\13\6\3\6\3\6\3\6\3\6\5\6J\n\6\3\7\3\7\3\7\5\7O\n\7\3\b\3\b\5\bS\n\b"+
		"\3\t\3\t\5\tW\n\t\3\n\3\n\5\n[\n\n\3\13\3\13\5\13_\n\13\3\f\3\f\3\r\3"+
		"\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16n\n\16\5\16p\n\16\3"+
		"\16\3\16\3\16\3\16\7\16v\n\16\f\16\16\16y\13\16\3\17\3\17\3\17\3\17\3"+
		"\17\3\17\5\17\u0081\n\17\3\20\3\20\3\21\3\21\3\21\5\21\u0088\n\21\3\21"+
		"\3\21\5\21\u008c\n\21\3\21\5\21\u008f\n\21\3\22\3\22\3\22\7\22\u0094\n"+
		"\22\f\22\16\22\u0097\13\22\3\22\2\3\32\23\2\4\6\b\n\f\16\20\22\24\26\30"+
		"\32\34\36 \"\2\5\3\2#$\4\2\7\13\17\20\5\2\4\4\21\26\30\"\2\u009e\2$\3"+
		"\2\2\2\4\'\3\2\2\2\6\66\3\2\2\2\b8\3\2\2\2\nI\3\2\2\2\fN\3\2\2\2\16P\3"+
		"\2\2\2\20T\3\2\2\2\22X\3\2\2\2\24\\\3\2\2\2\26`\3\2\2\2\30b\3\2\2\2\32"+
		"o\3\2\2\2\34\u0080\3\2\2\2\36\u0082\3\2\2\2 \u0084\3\2\2\2\"\u0090\3\2"+
		"\2\2$%\5\4\3\2%&\7\2\2\3&\3\3\2\2\2\'(\5\f\7\2(\5\3\2\2\2)*\7&\2\2*/\5"+
		"\b\5\2+,\7*\2\2,.\5\b\5\2-+\3\2\2\2.\61\3\2\2\2/-\3\2\2\2/\60\3\2\2\2"+
		"\60\62\3\2\2\2\61/\3\2\2\2\62\63\7\'\2\2\63\67\3\2\2\2\64\65\7&\2\2\65"+
		"\67\7\'\2\2\66)\3\2\2\2\66\64\3\2\2\2\67\7\3\2\2\289\7-\2\29:\7\6\2\2"+
		":;\5\f\7\2;\t\3\2\2\2<=\7(\2\2=B\5\f\7\2>?\7*\2\2?A\5\f\7\2@>\3\2\2\2"+
		"AD\3\2\2\2B@\3\2\2\2BC\3\2\2\2CE\3\2\2\2DB\3\2\2\2EF\7)\2\2FJ\3\2\2\2"+
		"GH\7(\2\2HJ\7)\2\2I<\3\2\2\2IG\3\2\2\2J\13\3\2\2\2KO\5\6\4\2LO\5\n\6\2"+
		"MO\5\32\16\2NK\3\2\2\2NL\3\2\2\2NM\3\2\2\2O\r\3\2\2\2PR\7-\2\2QS\5\30"+
		"\r\2RQ\3\2\2\2RS\3\2\2\2S\17\3\2\2\2TV\7/\2\2UW\5\30\r\2VU\3\2\2\2VW\3"+
		"\2\2\2W\21\3\2\2\2XZ\7\60\2\2Y[\5\30\r\2ZY\3\2\2\2Z[\3\2\2\2[\23\3\2\2"+
		"\2\\^\t\2\2\2]_\5\30\r\2^]\3\2\2\2^_\3\2\2\2_\25\3\2\2\2`a\7%\2\2a\27"+
		"\3\2\2\2bc\7\5\2\2cd\t\3\2\2d\31\3\2\2\2ef\b\16\1\2fp\5\34\17\2gh\7\27"+
		"\2\2hp\5\32\16\5ij\7+\2\2jk\5\32\16\2km\7,\2\2ln\5\30\r\2ml\3\2\2\2mn"+
		"\3\2\2\2np\3\2\2\2oe\3\2\2\2og\3\2\2\2oi\3\2\2\2pw\3\2\2\2qr\f\3\2\2r"+
		"s\5\36\20\2st\5\32\16\4tv\3\2\2\2uq\3\2\2\2vy\3\2\2\2wu\3\2\2\2wx\3\2"+
		"\2\2x\33\3\2\2\2yw\3\2\2\2z\u0081\5 \21\2{\u0081\5\24\13\2|\u0081\5\16"+
		"\b\2}\u0081\5\22\n\2~\u0081\5\20\t\2\177\u0081\5\26\f\2\u0080z\3\2\2\2"+
		"\u0080{\3\2\2\2\u0080|\3\2\2\2\u0080}\3\2\2\2\u0080~\3\2\2\2\u0080\177"+
		"\3\2\2\2\u0081\35\3\2\2\2\u0082\u0083\t\4\2\2\u0083\37\3\2\2\2\u0084\u0085"+
		"\7\63\2\2\u0085\u0087\7+\2\2\u0086\u0088\5\"\22\2\u0087\u0086\3\2\2\2"+
		"\u0087\u0088\3\2\2\2\u0088\u0089\3\2\2\2\u0089\u008b\7,\2\2\u008a\u008c"+
		"\5\30\r\2\u008b\u008a\3\2\2\2\u008b\u008c\3\2\2\2\u008c\u008e\3\2\2\2"+
		"\u008d\u008f\5\6\4\2\u008e\u008d\3\2\2\2\u008e\u008f\3\2\2\2\u008f!\3"+
		"\2\2\2\u0090\u0095\5\f\7\2\u0091\u0092\7*\2\2\u0092\u0094\5\f\7\2\u0093"+
		"\u0091\3\2\2\2\u0094\u0097\3\2\2\2\u0095\u0093\3\2\2\2\u0095\u0096\3\2"+
		"\2\2\u0096#\3\2\2\2\u0097\u0095\3\2\2\2\23/\66BINRVZ^mow\u0080\u0087\u008b"+
		"\u008e\u0095";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}