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
		CURRENT_VALUE=1, RECURSIVE_DESCENT=2, ROOT_VALUE=3, SUBSCRIPT=4, WILDCARD_SUBSCRIPT=5, 
		PIPE=6, URI=7, TIME=8, DATETIME=9, AND=10, EQ=11, GE=12, GT=13, LE=14, 
		LT=15, NE=16, NOT=17, OR=18, NEW=19, TRUE=20, FALSE=21, NULL=22, BRACE_LEFT=23, 
		BRACE_RIGHT=24, BRACKET_LEFT=25, BRACKET_RIGHT=26, COLON=27, COMMA=28, 
		PAREN_LEFT=29, PAREN_RIGHT=30, QUESTION=31, STRING=32, MULTI_LINE_COMMENT=33, 
		CODE_STRING=34, QUOTE_CODE_STRING=35, NUMBER=36, INT=37, WS=38, ID=39, 
		LANGUAGE=40;
	public static final int
		RULE_script = 0, RULE_json = 1, RULE_obj = 2, RULE_pair = 3, RULE_array = 4, 
		RULE_jsonValue = 5, RULE_jsonValueString = 6, RULE_jsonValueCodeString = 7, 
		RULE_jsonValueNumber = 8, RULE_jsonValueInteger = 9, RULE_jsonValueBoolean = 10, 
		RULE_jsonValueNull = 11, RULE_jsonCtor = 12, RULE_jsonValueList = 13, 
		RULE_jsonType = 14, RULE_jsonLt = 15, RULE_jsonLtItem = 16, RULE_jsonpath = 17, 
		RULE_subscript = 18, RULE_subscriptables = 19, RULE_subscriptableBareword = 20, 
		RULE_subscriptable = 21, RULE_sliceable = 22, RULE_expression = 23, RULE_andExpression = 24, 
		RULE_orExpression = 25, RULE_notExpression = 26;
	private static String[] makeRuleNames() {
		return new String[] {
			"script", "json", "obj", "pair", "array", "jsonValue", "jsonValueString", 
			"jsonValueCodeString", "jsonValueNumber", "jsonValueInteger", "jsonValueBoolean", 
			"jsonValueNull", "jsonCtor", "jsonValueList", "jsonType", "jsonLt", "jsonLtItem", 
			"jsonpath", "subscript", "subscriptables", "subscriptableBareword", "subscriptable", 
			"sliceable", "expression", "andExpression", "orExpression", "notExpression"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'@'", "'..'", "'$'", "'.'", "'*'", "'|'", "'uri'", "'time'", "'datetime'", 
			"'and'", "'='", "'>='", "'>'", "'<='", "'<'", "'!='", "'not'", "'or'", 
			"'new'", "'true'", "'false'", "'null'", "'{'", "'}'", "'['", "']'", "':'", 
			"','", "'('", "')'", "'?'", null, null, null, "'''''"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "CURRENT_VALUE", "RECURSIVE_DESCENT", "ROOT_VALUE", "SUBSCRIPT", 
			"WILDCARD_SUBSCRIPT", "PIPE", "URI", "TIME", "DATETIME", "AND", "EQ", 
			"GE", "GT", "LE", "LT", "NE", "NOT", "OR", "NEW", "TRUE", "FALSE", "NULL", 
			"BRACE_LEFT", "BRACE_RIGHT", "BRACKET_LEFT", "BRACKET_RIGHT", "COLON", 
			"COMMA", "PAREN_LEFT", "PAREN_RIGHT", "QUESTION", "STRING", "MULTI_LINE_COMMENT", 
			"CODE_STRING", "QUOTE_CODE_STRING", "NUMBER", "INT", "WS", "ID", "LANGUAGE"
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
			setState(54);
			json();
			setState(55);
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
			setState(57);
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
			setState(72);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(59);
				match(BRACE_LEFT);
				setState(60);
				pair();
				setState(65);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(61);
					match(COMMA);
					setState(62);
					pair();
					}
					}
					setState(67);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(68);
				match(BRACE_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(70);
				match(BRACE_LEFT);
				setState(71);
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
			setState(74);
			match(STRING);
			setState(75);
			match(COLON);
			setState(76);
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
			setState(91);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(78);
				match(BRACKET_LEFT);
				setState(79);
				jsonValue();
				setState(84);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(80);
					match(COMMA);
					setState(81);
					jsonValue();
					}
					}
					setState(86);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(87);
				match(BRACKET_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(89);
				match(BRACKET_LEFT);
				setState(90);
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
		public JsonLtContext jsonLt() {
			return getRuleContext(JsonLtContext.class,0);
		}
		public JsonValueCodeStringContext jsonValueCodeString() {
			return getRuleContext(JsonValueCodeStringContext.class,0);
		}
		public JsonTypeContext jsonType() {
			return getRuleContext(JsonTypeContext.class,0);
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
			setState(103);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BRACE_LEFT:
				enterOuterAlt(_localctx, 1);
				{
				setState(93);
				obj();
				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(94);
				array();
				}
				break;
			case TRUE:
			case FALSE:
				enterOuterAlt(_localctx, 3);
				{
				setState(95);
				jsonValueBoolean();
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 4);
				{
				setState(96);
				jsonValueString();
				}
				break;
			case INT:
				enterOuterAlt(_localctx, 5);
				{
				setState(97);
				jsonValueInteger();
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 6);
				{
				setState(98);
				jsonValueNumber();
				}
				break;
			case NULL:
				enterOuterAlt(_localctx, 7);
				{
				setState(99);
				jsonValueNull();
				}
				break;
			case ROOT_VALUE:
			case NEW:
				enterOuterAlt(_localctx, 8);
				{
				setState(100);
				jsonLt();
				}
				break;
			case CODE_STRING:
				enterOuterAlt(_localctx, 9);
				{
				setState(101);
				jsonValueCodeString();
				}
				break;
			case CURRENT_VALUE:
				enterOuterAlt(_localctx, 10);
				{
				setState(102);
				jsonType();
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
			setState(105);
			match(STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class JsonValueCodeStringContext extends ParserRuleContext {
		public TerminalNode CODE_STRING() { return getToken(JsltParser.CODE_STRING, 0); }
		public JsonValueCodeStringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueCodeString; }
	}

	public final JsonValueCodeStringContext jsonValueCodeString() throws RecognitionException {
		JsonValueCodeStringContext _localctx = new JsonValueCodeStringContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_jsonValueCodeString);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			match(CODE_STRING);
			}
		}
		catch (RecognitionException re) {
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
		enterRule(_localctx, 16, RULE_jsonValueNumber);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
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
		enterRule(_localctx, 18, RULE_jsonValueInteger);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(111);
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
		enterRule(_localctx, 20, RULE_jsonValueBoolean);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
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
		enterRule(_localctx, 22, RULE_jsonValueNull);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(115);
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

	public static class JsonCtorContext extends ParserRuleContext {
		public TerminalNode NEW() { return getToken(JsltParser.NEW, 0); }
		public TerminalNode ID() { return getToken(JsltParser.ID, 0); }
		public TerminalNode PAREN_LEFT() { return getToken(JsltParser.PAREN_LEFT, 0); }
		public TerminalNode PAREN_RIGHT() { return getToken(JsltParser.PAREN_RIGHT, 0); }
		public JsonValueListContext jsonValueList() {
			return getRuleContext(JsonValueListContext.class,0);
		}
		public JsonCtorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonCtor; }
	}

	public final JsonCtorContext jsonCtor() throws RecognitionException {
		JsonCtorContext _localctx = new JsonCtorContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_jsonCtor);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(117);
			match(NEW);
			setState(118);
			match(ID);
			setState(119);
			match(PAREN_LEFT);
			setState(121);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << CURRENT_VALUE) | (1L << ROOT_VALUE) | (1L << NEW) | (1L << TRUE) | (1L << FALSE) | (1L << NULL) | (1L << BRACE_LEFT) | (1L << BRACKET_LEFT) | (1L << STRING) | (1L << CODE_STRING) | (1L << NUMBER) | (1L << INT))) != 0)) {
				{
				setState(120);
				jsonValueList();
				}
			}

			setState(123);
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
		enterRule(_localctx, 26, RULE_jsonValueList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(125);
			jsonValue();
			setState(130);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(126);
				match(COMMA);
				setState(127);
				jsonValue();
				}
				}
				setState(132);
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

	public static class JsonTypeContext extends ParserRuleContext {
		public TerminalNode CURRENT_VALUE() { return getToken(JsltParser.CURRENT_VALUE, 0); }
		public TerminalNode URI() { return getToken(JsltParser.URI, 0); }
		public TerminalNode TIME() { return getToken(JsltParser.TIME, 0); }
		public TerminalNode DATETIME() { return getToken(JsltParser.DATETIME, 0); }
		public JsonTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonType; }
	}

	public final JsonTypeContext jsonType() throws RecognitionException {
		JsonTypeContext _localctx = new JsonTypeContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_jsonType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(133);
			match(CURRENT_VALUE);
			setState(134);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << URI) | (1L << TIME) | (1L << DATETIME))) != 0)) ) {
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

	public static class JsonLtContext extends ParserRuleContext {
		public List<JsonLtItemContext> jsonLtItem() {
			return getRuleContexts(JsonLtItemContext.class);
		}
		public JsonLtItemContext jsonLtItem(int i) {
			return getRuleContext(JsonLtItemContext.class,i);
		}
		public List<TerminalNode> PIPE() { return getTokens(JsltParser.PIPE); }
		public TerminalNode PIPE(int i) {
			return getToken(JsltParser.PIPE, i);
		}
		public JsonLtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonLt; }
	}

	public final JsonLtContext jsonLt() throws RecognitionException {
		JsonLtContext _localctx = new JsonLtContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_jsonLt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(136);
			jsonLtItem();
			setState(141);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PIPE) {
				{
				{
				setState(137);
				match(PIPE);
				setState(138);
				jsonLtItem();
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

	public static class JsonLtItemContext extends ParserRuleContext {
		public JsonpathContext jsonpath() {
			return getRuleContext(JsonpathContext.class,0);
		}
		public JsonCtorContext jsonCtor() {
			return getRuleContext(JsonCtorContext.class,0);
		}
		public JsonLtItemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonLtItem; }
	}

	public final JsonLtItemContext jsonLtItem() throws RecognitionException {
		JsonLtItemContext _localctx = new JsonLtItemContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_jsonLtItem);
		try {
			setState(146);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ROOT_VALUE:
				enterOuterAlt(_localctx, 1);
				{
				setState(144);
				jsonpath();
				}
				break;
			case NEW:
				enterOuterAlt(_localctx, 2);
				{
				setState(145);
				jsonCtor();
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

	public static class JsonpathContext extends ParserRuleContext {
		public TerminalNode ROOT_VALUE() { return getToken(JsltParser.ROOT_VALUE, 0); }
		public SubscriptContext subscript() {
			return getRuleContext(SubscriptContext.class,0);
		}
		public JsonpathContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonpath; }
	}

	public final JsonpathContext jsonpath() throws RecognitionException {
		JsonpathContext _localctx = new JsonpathContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_jsonpath);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(148);
			match(ROOT_VALUE);
			setState(150);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
				{
				setState(149);
				subscript();
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

	public static class SubscriptContext extends ParserRuleContext {
		public TerminalNode RECURSIVE_DESCENT() { return getToken(JsltParser.RECURSIVE_DESCENT, 0); }
		public SubscriptableBarewordContext subscriptableBareword() {
			return getRuleContext(SubscriptableBarewordContext.class,0);
		}
		public SubscriptablesContext subscriptables() {
			return getRuleContext(SubscriptablesContext.class,0);
		}
		public SubscriptContext subscript() {
			return getRuleContext(SubscriptContext.class,0);
		}
		public TerminalNode SUBSCRIPT() { return getToken(JsltParser.SUBSCRIPT, 0); }
		public SubscriptContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscript; }
	}

	public final SubscriptContext subscript() throws RecognitionException {
		SubscriptContext _localctx = new SubscriptContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_subscript);
		int _la;
		try {
			setState(169);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RECURSIVE_DESCENT:
				enterOuterAlt(_localctx, 1);
				{
				setState(152);
				match(RECURSIVE_DESCENT);
				setState(155);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case WILDCARD_SUBSCRIPT:
				case ID:
					{
					setState(153);
					subscriptableBareword();
					}
					break;
				case BRACKET_LEFT:
					{
					setState(154);
					subscriptables();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(158);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(157);
					subscript();
					}
				}

				}
				break;
			case SUBSCRIPT:
				enterOuterAlt(_localctx, 2);
				{
				setState(160);
				match(SUBSCRIPT);
				setState(161);
				subscriptableBareword();
				setState(163);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(162);
					subscript();
					}
				}

				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 3);
				{
				setState(165);
				subscriptables();
				setState(167);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(166);
					subscript();
					}
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

	public static class SubscriptablesContext extends ParserRuleContext {
		public TerminalNode BRACKET_LEFT() { return getToken(JsltParser.BRACKET_LEFT, 0); }
		public List<SubscriptableContext> subscriptable() {
			return getRuleContexts(SubscriptableContext.class);
		}
		public SubscriptableContext subscriptable(int i) {
			return getRuleContext(SubscriptableContext.class,i);
		}
		public TerminalNode BRACKET_RIGHT() { return getToken(JsltParser.BRACKET_RIGHT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(JsltParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(JsltParser.COMMA, i);
		}
		public SubscriptablesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscriptables; }
	}

	public final SubscriptablesContext subscriptables() throws RecognitionException {
		SubscriptablesContext _localctx = new SubscriptablesContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_subscriptables);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(171);
			match(BRACKET_LEFT);
			setState(172);
			subscriptable();
			setState(177);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(173);
				match(COMMA);
				setState(174);
				subscriptable();
				}
				}
				setState(179);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(180);
			match(BRACKET_RIGHT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SubscriptableBarewordContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(JsltParser.ID, 0); }
		public TerminalNode WILDCARD_SUBSCRIPT() { return getToken(JsltParser.WILDCARD_SUBSCRIPT, 0); }
		public SubscriptableBarewordContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscriptableBareword; }
	}

	public final SubscriptableBarewordContext subscriptableBareword() throws RecognitionException {
		SubscriptableBarewordContext _localctx = new SubscriptableBarewordContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_subscriptableBareword);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(182);
			_la = _input.LA(1);
			if ( !(_la==WILDCARD_SUBSCRIPT || _la==ID) ) {
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

	public static class SubscriptableContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JsltParser.STRING, 0); }
		public TerminalNode NUMBER() { return getToken(JsltParser.NUMBER, 0); }
		public SliceableContext sliceable() {
			return getRuleContext(SliceableContext.class,0);
		}
		public TerminalNode WILDCARD_SUBSCRIPT() { return getToken(JsltParser.WILDCARD_SUBSCRIPT, 0); }
		public TerminalNode QUESTION() { return getToken(JsltParser.QUESTION, 0); }
		public TerminalNode PAREN_LEFT() { return getToken(JsltParser.PAREN_LEFT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PAREN_RIGHT() { return getToken(JsltParser.PAREN_RIGHT, 0); }
		public SubscriptableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscriptable; }
	}

	public final SubscriptableContext subscriptable() throws RecognitionException {
		SubscriptableContext _localctx = new SubscriptableContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_subscriptable);
		int _la;
		try {
			setState(198);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(184);
				match(STRING);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(186);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NUMBER) {
					{
					setState(185);
					match(NUMBER);
					}
				}

				setState(189);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COLON) {
					{
					setState(188);
					sliceable();
					}
				}

				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(191);
				sliceable();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(192);
				match(WILDCARD_SUBSCRIPT);
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(193);
				match(QUESTION);
				setState(194);
				match(PAREN_LEFT);
				setState(195);
				expression();
				setState(196);
				match(PAREN_RIGHT);
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

	public static class SliceableContext extends ParserRuleContext {
		public List<TerminalNode> COLON() { return getTokens(JsltParser.COLON); }
		public TerminalNode COLON(int i) {
			return getToken(JsltParser.COLON, i);
		}
		public List<TerminalNode> NUMBER() { return getTokens(JsltParser.NUMBER); }
		public TerminalNode NUMBER(int i) {
			return getToken(JsltParser.NUMBER, i);
		}
		public SliceableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sliceable; }
	}

	public final SliceableContext sliceable() throws RecognitionException {
		SliceableContext _localctx = new SliceableContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_sliceable);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(200);
			match(COLON);
			setState(202);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NUMBER) {
				{
				setState(201);
				match(NUMBER);
				}
			}

			setState(208);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(204);
				match(COLON);
				setState(206);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NUMBER) {
					{
					setState(205);
					match(NUMBER);
					}
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

	public static class ExpressionContext extends ParserRuleContext {
		public AndExpressionContext andExpression() {
			return getRuleContext(AndExpressionContext.class,0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	}

	public final ExpressionContext expression() throws RecognitionException {
		ExpressionContext _localctx = new ExpressionContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(210);
			andExpression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AndExpressionContext extends ParserRuleContext {
		public OrExpressionContext orExpression() {
			return getRuleContext(OrExpressionContext.class,0);
		}
		public TerminalNode AND() { return getToken(JsltParser.AND, 0); }
		public AndExpressionContext andExpression() {
			return getRuleContext(AndExpressionContext.class,0);
		}
		public AndExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_andExpression; }
	}

	public final AndExpressionContext andExpression() throws RecognitionException {
		AndExpressionContext _localctx = new AndExpressionContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_andExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(212);
			orExpression();
			setState(215);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AND) {
				{
				setState(213);
				match(AND);
				setState(214);
				andExpression();
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

	public static class OrExpressionContext extends ParserRuleContext {
		public NotExpressionContext notExpression() {
			return getRuleContext(NotExpressionContext.class,0);
		}
		public TerminalNode OR() { return getToken(JsltParser.OR, 0); }
		public OrExpressionContext orExpression() {
			return getRuleContext(OrExpressionContext.class,0);
		}
		public OrExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_orExpression; }
	}

	public final OrExpressionContext orExpression() throws RecognitionException {
		OrExpressionContext _localctx = new OrExpressionContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_orExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(217);
			notExpression();
			setState(220);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OR) {
				{
				setState(218);
				match(OR);
				setState(219);
				orExpression();
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

	public static class NotExpressionContext extends ParserRuleContext {
		public TerminalNode NOT() { return getToken(JsltParser.NOT, 0); }
		public NotExpressionContext notExpression() {
			return getRuleContext(NotExpressionContext.class,0);
		}
		public TerminalNode PAREN_LEFT() { return getToken(JsltParser.PAREN_LEFT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PAREN_RIGHT() { return getToken(JsltParser.PAREN_RIGHT, 0); }
		public TerminalNode ROOT_VALUE() { return getToken(JsltParser.ROOT_VALUE, 0); }
		public TerminalNode CURRENT_VALUE() { return getToken(JsltParser.CURRENT_VALUE, 0); }
		public SubscriptContext subscript() {
			return getRuleContext(SubscriptContext.class,0);
		}
		public JsonValueContext jsonValue() {
			return getRuleContext(JsonValueContext.class,0);
		}
		public TerminalNode EQ() { return getToken(JsltParser.EQ, 0); }
		public TerminalNode NE() { return getToken(JsltParser.NE, 0); }
		public TerminalNode LT() { return getToken(JsltParser.LT, 0); }
		public TerminalNode LE() { return getToken(JsltParser.LE, 0); }
		public TerminalNode GT() { return getToken(JsltParser.GT, 0); }
		public TerminalNode GE() { return getToken(JsltParser.GE, 0); }
		public NotExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_notExpression; }
	}

	public final NotExpressionContext notExpression() throws RecognitionException {
		NotExpressionContext _localctx = new NotExpressionContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_notExpression);
		int _la;
		try {
			setState(236);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NOT:
				enterOuterAlt(_localctx, 1);
				{
				setState(222);
				match(NOT);
				setState(223);
				notExpression();
				}
				break;
			case PAREN_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(224);
				match(PAREN_LEFT);
				setState(225);
				expression();
				setState(226);
				match(PAREN_RIGHT);
				}
				break;
			case CURRENT_VALUE:
			case ROOT_VALUE:
				enterOuterAlt(_localctx, 3);
				{
				setState(228);
				_la = _input.LA(1);
				if ( !(_la==CURRENT_VALUE || _la==ROOT_VALUE) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(230);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(229);
					subscript();
					}
				}

				setState(234);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQ) | (1L << GE) | (1L << GT) | (1L << LE) | (1L << LT) | (1L << NE))) != 0)) {
					{
					setState(232);
					_la = _input.LA(1);
					if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQ) | (1L << GE) | (1L << GT) | (1L << LE) | (1L << LT) | (1L << NE))) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(233);
					jsonValue();
					}
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

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3*\u00f1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\3\2\3\2\3\2\3\3\3\3\3\4\3\4\3\4\3\4\7\4"+
		"B\n\4\f\4\16\4E\13\4\3\4\3\4\3\4\3\4\5\4K\n\4\3\5\3\5\3\5\3\5\3\6\3\6"+
		"\3\6\3\6\7\6U\n\6\f\6\16\6X\13\6\3\6\3\6\3\6\3\6\5\6^\n\6\3\7\3\7\3\7"+
		"\3\7\3\7\3\7\3\7\3\7\3\7\3\7\5\7j\n\7\3\b\3\b\3\t\3\t\3\n\3\n\3\13\3\13"+
		"\3\f\3\f\3\r\3\r\3\16\3\16\3\16\3\16\5\16|\n\16\3\16\3\16\3\17\3\17\3"+
		"\17\7\17\u0083\n\17\f\17\16\17\u0086\13\17\3\20\3\20\3\20\3\21\3\21\3"+
		"\21\7\21\u008e\n\21\f\21\16\21\u0091\13\21\3\22\3\22\5\22\u0095\n\22\3"+
		"\23\3\23\5\23\u0099\n\23\3\24\3\24\3\24\5\24\u009e\n\24\3\24\5\24\u00a1"+
		"\n\24\3\24\3\24\3\24\5\24\u00a6\n\24\3\24\3\24\5\24\u00aa\n\24\5\24\u00ac"+
		"\n\24\3\25\3\25\3\25\3\25\7\25\u00b2\n\25\f\25\16\25\u00b5\13\25\3\25"+
		"\3\25\3\26\3\26\3\27\3\27\5\27\u00bd\n\27\3\27\5\27\u00c0\n\27\3\27\3"+
		"\27\3\27\3\27\3\27\3\27\3\27\5\27\u00c9\n\27\3\30\3\30\5\30\u00cd\n\30"+
		"\3\30\3\30\5\30\u00d1\n\30\5\30\u00d3\n\30\3\31\3\31\3\32\3\32\3\32\5"+
		"\32\u00da\n\32\3\33\3\33\3\33\5\33\u00df\n\33\3\34\3\34\3\34\3\34\3\34"+
		"\3\34\3\34\3\34\5\34\u00e9\n\34\3\34\3\34\5\34\u00ed\n\34\5\34\u00ef\n"+
		"\34\3\34\2\2\35\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62"+
		"\64\66\2\7\3\2\26\27\3\2\t\13\4\2\7\7))\4\2\3\3\5\5\3\2\r\22\2\u00fd\2"+
		"8\3\2\2\2\4;\3\2\2\2\6J\3\2\2\2\bL\3\2\2\2\n]\3\2\2\2\fi\3\2\2\2\16k\3"+
		"\2\2\2\20m\3\2\2\2\22o\3\2\2\2\24q\3\2\2\2\26s\3\2\2\2\30u\3\2\2\2\32"+
		"w\3\2\2\2\34\177\3\2\2\2\36\u0087\3\2\2\2 \u008a\3\2\2\2\"\u0094\3\2\2"+
		"\2$\u0096\3\2\2\2&\u00ab\3\2\2\2(\u00ad\3\2\2\2*\u00b8\3\2\2\2,\u00c8"+
		"\3\2\2\2.\u00ca\3\2\2\2\60\u00d4\3\2\2\2\62\u00d6\3\2\2\2\64\u00db\3\2"+
		"\2\2\66\u00ee\3\2\2\289\5\4\3\29:\7\2\2\3:\3\3\2\2\2;<\5\f\7\2<\5\3\2"+
		"\2\2=>\7\31\2\2>C\5\b\5\2?@\7\36\2\2@B\5\b\5\2A?\3\2\2\2BE\3\2\2\2CA\3"+
		"\2\2\2CD\3\2\2\2DF\3\2\2\2EC\3\2\2\2FG\7\32\2\2GK\3\2\2\2HI\7\31\2\2I"+
		"K\7\32\2\2J=\3\2\2\2JH\3\2\2\2K\7\3\2\2\2LM\7\"\2\2MN\7\35\2\2NO\5\f\7"+
		"\2O\t\3\2\2\2PQ\7\33\2\2QV\5\f\7\2RS\7\36\2\2SU\5\f\7\2TR\3\2\2\2UX\3"+
		"\2\2\2VT\3\2\2\2VW\3\2\2\2WY\3\2\2\2XV\3\2\2\2YZ\7\34\2\2Z^\3\2\2\2[\\"+
		"\7\33\2\2\\^\7\34\2\2]P\3\2\2\2][\3\2\2\2^\13\3\2\2\2_j\5\6\4\2`j\5\n"+
		"\6\2aj\5\26\f\2bj\5\16\b\2cj\5\24\13\2dj\5\22\n\2ej\5\30\r\2fj\5 \21\2"+
		"gj\5\20\t\2hj\5\36\20\2i_\3\2\2\2i`\3\2\2\2ia\3\2\2\2ib\3\2\2\2ic\3\2"+
		"\2\2id\3\2\2\2ie\3\2\2\2if\3\2\2\2ig\3\2\2\2ih\3\2\2\2j\r\3\2\2\2kl\7"+
		"\"\2\2l\17\3\2\2\2mn\7$\2\2n\21\3\2\2\2op\7&\2\2p\23\3\2\2\2qr\7\'\2\2"+
		"r\25\3\2\2\2st\t\2\2\2t\27\3\2\2\2uv\7\30\2\2v\31\3\2\2\2wx\7\25\2\2x"+
		"y\7)\2\2y{\7\37\2\2z|\5\34\17\2{z\3\2\2\2{|\3\2\2\2|}\3\2\2\2}~\7 \2\2"+
		"~\33\3\2\2\2\177\u0084\5\f\7\2\u0080\u0081\7\36\2\2\u0081\u0083\5\f\7"+
		"\2\u0082\u0080\3\2\2\2\u0083\u0086\3\2\2\2\u0084\u0082\3\2\2\2\u0084\u0085"+
		"\3\2\2\2\u0085\35\3\2\2\2\u0086\u0084\3\2\2\2\u0087\u0088\7\3\2\2\u0088"+
		"\u0089\t\3\2\2\u0089\37\3\2\2\2\u008a\u008f\5\"\22\2\u008b\u008c\7\b\2"+
		"\2\u008c\u008e\5\"\22\2\u008d\u008b\3\2\2\2\u008e\u0091\3\2\2\2\u008f"+
		"\u008d\3\2\2\2\u008f\u0090\3\2\2\2\u0090!\3\2\2\2\u0091\u008f\3\2\2\2"+
		"\u0092\u0095\5$\23\2\u0093\u0095\5\32\16\2\u0094\u0092\3\2\2\2\u0094\u0093"+
		"\3\2\2\2\u0095#\3\2\2\2\u0096\u0098\7\5\2\2\u0097\u0099\5&\24\2\u0098"+
		"\u0097\3\2\2\2\u0098\u0099\3\2\2\2\u0099%\3\2\2\2\u009a\u009d\7\4\2\2"+
		"\u009b\u009e\5*\26\2\u009c\u009e\5(\25\2\u009d\u009b\3\2\2\2\u009d\u009c"+
		"\3\2\2\2\u009e\u00a0\3\2\2\2\u009f\u00a1\5&\24\2\u00a0\u009f\3\2\2\2\u00a0"+
		"\u00a1\3\2\2\2\u00a1\u00ac\3\2\2\2\u00a2\u00a3\7\6\2\2\u00a3\u00a5\5*"+
		"\26\2\u00a4\u00a6\5&\24\2\u00a5\u00a4\3\2\2\2\u00a5\u00a6\3\2\2\2\u00a6"+
		"\u00ac\3\2\2\2\u00a7\u00a9\5(\25\2\u00a8\u00aa\5&\24\2\u00a9\u00a8\3\2"+
		"\2\2\u00a9\u00aa\3\2\2\2\u00aa\u00ac\3\2\2\2\u00ab\u009a\3\2\2\2\u00ab"+
		"\u00a2\3\2\2\2\u00ab\u00a7\3\2\2\2\u00ac\'\3\2\2\2\u00ad\u00ae\7\33\2"+
		"\2\u00ae\u00b3\5,\27\2\u00af\u00b0\7\36\2\2\u00b0\u00b2\5,\27\2\u00b1"+
		"\u00af\3\2\2\2\u00b2\u00b5\3\2\2\2\u00b3\u00b1\3\2\2\2\u00b3\u00b4\3\2"+
		"\2\2\u00b4\u00b6\3\2\2\2\u00b5\u00b3\3\2\2\2\u00b6\u00b7\7\34\2\2\u00b7"+
		")\3\2\2\2\u00b8\u00b9\t\4\2\2\u00b9+\3\2\2\2\u00ba\u00c9\7\"\2\2\u00bb"+
		"\u00bd\7&\2\2\u00bc\u00bb\3\2\2\2\u00bc\u00bd\3\2\2\2\u00bd\u00bf\3\2"+
		"\2\2\u00be\u00c0\5.\30\2\u00bf\u00be\3\2\2\2\u00bf\u00c0\3\2\2\2\u00c0"+
		"\u00c9\3\2\2\2\u00c1\u00c9\5.\30\2\u00c2\u00c9\7\7\2\2\u00c3\u00c4\7!"+
		"\2\2\u00c4\u00c5\7\37\2\2\u00c5\u00c6\5\60\31\2\u00c6\u00c7\7 \2\2\u00c7"+
		"\u00c9\3\2\2\2\u00c8\u00ba\3\2\2\2\u00c8\u00bc\3\2\2\2\u00c8\u00c1\3\2"+
		"\2\2\u00c8\u00c2\3\2\2\2\u00c8\u00c3\3\2\2\2\u00c9-\3\2\2\2\u00ca\u00cc"+
		"\7\35\2\2\u00cb\u00cd\7&\2\2\u00cc\u00cb\3\2\2\2\u00cc\u00cd\3\2\2\2\u00cd"+
		"\u00d2\3\2\2\2\u00ce\u00d0\7\35\2\2\u00cf\u00d1\7&\2\2\u00d0\u00cf\3\2"+
		"\2\2\u00d0\u00d1\3\2\2\2\u00d1\u00d3\3\2\2\2\u00d2\u00ce\3\2\2\2\u00d2"+
		"\u00d3\3\2\2\2\u00d3/\3\2\2\2\u00d4\u00d5\5\62\32\2\u00d5\61\3\2\2\2\u00d6"+
		"\u00d9\5\64\33\2\u00d7\u00d8\7\f\2\2\u00d8\u00da\5\62\32\2\u00d9\u00d7"+
		"\3\2\2\2\u00d9\u00da\3\2\2\2\u00da\63\3\2\2\2\u00db\u00de\5\66\34\2\u00dc"+
		"\u00dd\7\24\2\2\u00dd\u00df\5\64\33\2\u00de\u00dc\3\2\2\2\u00de\u00df"+
		"\3\2\2\2\u00df\65\3\2\2\2\u00e0\u00e1\7\23\2\2\u00e1\u00ef\5\66\34\2\u00e2"+
		"\u00e3\7\37\2\2\u00e3\u00e4\5\60\31\2\u00e4\u00e5\7 \2\2\u00e5\u00ef\3"+
		"\2\2\2\u00e6\u00e8\t\5\2\2\u00e7\u00e9\5&\24\2\u00e8\u00e7\3\2\2\2\u00e8"+
		"\u00e9\3\2\2\2\u00e9\u00ec\3\2\2\2\u00ea\u00eb\t\6\2\2\u00eb\u00ed\5\f"+
		"\7\2\u00ec\u00ea\3\2\2\2\u00ec\u00ed\3\2\2\2\u00ed\u00ef\3\2\2\2\u00ee"+
		"\u00e0\3\2\2\2\u00ee\u00e2\3\2\2\2\u00ee\u00e6\3\2\2\2\u00ef\67\3\2\2"+
		"\2\35CJV]i{\u0084\u008f\u0094\u0098\u009d\u00a0\u00a5\u00a9\u00ab\u00b3"+
		"\u00bc\u00bf\u00c8\u00cc\u00d0\u00d2\u00d9\u00de\u00e8\u00ec\u00ee";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}