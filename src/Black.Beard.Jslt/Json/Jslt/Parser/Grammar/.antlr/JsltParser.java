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
		PIPE=6, AND=7, EQ=8, GE=9, GT=10, LE=11, LT=12, NE=13, NOT=14, OR=15, 
		NEW=16, TRUE=17, FALSE=18, NULL=19, BRACE_LEFT=20, BRACE_RIGHT=21, BRACKET_LEFT=22, 
		BRACKET_RIGHT=23, COLON=24, COMMA=25, PAREN_LEFT=26, PAREN_RIGHT=27, QUESTION=28, 
		STRING=29, NUMBER=30, INT=31, WS=32, ID=33;
	public static final int
		RULE_script = 0, RULE_json = 1, RULE_obj = 2, RULE_pair = 3, RULE_array = 4, 
		RULE_jsonValue = 5, RULE_jsonValueString = 6, RULE_jsonValueNumber = 7, 
		RULE_jsonValueInteger = 8, RULE_jsonValueBoolean = 9, RULE_jsonValueNull = 10, 
		RULE_jsonCtor = 11, RULE_jsonValueList = 12, RULE_jsonLt = 13, RULE_jsonLtItem = 14, 
		RULE_jsonpath = 15, RULE_subscript = 16, RULE_subscriptables = 17, RULE_subscriptableBareword = 18, 
		RULE_subscriptable = 19, RULE_sliceable = 20, RULE_expression = 21, RULE_andExpression = 22, 
		RULE_orExpression = 23, RULE_notExpression = 24;
	private static String[] makeRuleNames() {
		return new String[] {
			"script", "json", "obj", "pair", "array", "jsonValue", "jsonValueString", 
			"jsonValueNumber", "jsonValueInteger", "jsonValueBoolean", "jsonValueNull", 
			"jsonCtor", "jsonValueList", "jsonLt", "jsonLtItem", "jsonpath", "subscript", 
			"subscriptables", "subscriptableBareword", "subscriptable", "sliceable", 
			"expression", "andExpression", "orExpression", "notExpression"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'@'", "'..'", "'$'", "'.'", "'*'", "'|'", "'and'", "'='", "'>='", 
			"'>'", "'<='", "'<'", "'!='", "'not'", "'or'", "'new'", "'true'", "'false'", 
			"'null'", "'{'", "'}'", "'['", "']'", "':'", "','", "'('", "')'", "'?'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "CURRENT_VALUE", "RECURSIVE_DESCENT", "ROOT_VALUE", "SUBSCRIPT", 
			"WILDCARD_SUBSCRIPT", "PIPE", "AND", "EQ", "GE", "GT", "LE", "LT", "NE", 
			"NOT", "OR", "NEW", "TRUE", "FALSE", "NULL", "BRACE_LEFT", "BRACE_RIGHT", 
			"BRACKET_LEFT", "BRACKET_RIGHT", "COLON", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", 
			"QUESTION", "STRING", "NUMBER", "INT", "WS", "ID"
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
			setState(50);
			json();
			setState(51);
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
			setState(53);
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
			setState(68);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(55);
				match(BRACE_LEFT);
				setState(56);
				pair();
				setState(61);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(57);
					match(COMMA);
					setState(58);
					pair();
					}
					}
					setState(63);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(64);
				match(BRACE_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(66);
				match(BRACE_LEFT);
				setState(67);
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
			setState(70);
			match(STRING);
			setState(71);
			match(COLON);
			setState(72);
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
			setState(87);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(74);
				match(BRACKET_LEFT);
				setState(75);
				jsonValue();
				setState(80);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(76);
					match(COMMA);
					setState(77);
					jsonValue();
					}
					}
					setState(82);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(83);
				match(BRACKET_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(85);
				match(BRACKET_LEFT);
				setState(86);
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
		public JsonValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValue; }
	}

	public final JsonValueContext jsonValue() throws RecognitionException {
		JsonValueContext _localctx = new JsonValueContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_jsonValue);
		try {
			setState(97);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BRACE_LEFT:
				enterOuterAlt(_localctx, 1);
				{
				setState(89);
				obj();
				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(90);
				array();
				}
				break;
			case TRUE:
			case FALSE:
				enterOuterAlt(_localctx, 3);
				{
				setState(91);
				jsonValueBoolean();
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 4);
				{
				setState(92);
				jsonValueString();
				}
				break;
			case INT:
				enterOuterAlt(_localctx, 5);
				{
				setState(93);
				jsonValueInteger();
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 6);
				{
				setState(94);
				jsonValueNumber();
				}
				break;
			case NULL:
				enterOuterAlt(_localctx, 7);
				{
				setState(95);
				jsonValueNull();
				}
				break;
			case ROOT_VALUE:
			case NEW:
				enterOuterAlt(_localctx, 8);
				{
				setState(96);
				jsonLt();
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
			setState(99);
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
			setState(101);
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
			setState(103);
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
			setState(105);
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
			setState(107);
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
		enterRule(_localctx, 22, RULE_jsonCtor);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			match(NEW);
			setState(110);
			match(ID);
			setState(111);
			match(PAREN_LEFT);
			setState(113);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << ROOT_VALUE) | (1L << NEW) | (1L << TRUE) | (1L << FALSE) | (1L << NULL) | (1L << BRACE_LEFT) | (1L << BRACKET_LEFT) | (1L << STRING) | (1L << NUMBER) | (1L << INT))) != 0)) {
				{
				setState(112);
				jsonValueList();
				}
			}

			setState(115);
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
		enterRule(_localctx, 24, RULE_jsonValueList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(117);
			jsonValue();
			setState(122);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(118);
				match(COMMA);
				setState(119);
				jsonValue();
				}
				}
				setState(124);
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
		enterRule(_localctx, 26, RULE_jsonLt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(125);
			jsonLtItem();
			setState(130);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PIPE) {
				{
				{
				setState(126);
				match(PIPE);
				setState(127);
				jsonLtItem();
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
		enterRule(_localctx, 28, RULE_jsonLtItem);
		try {
			setState(135);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ROOT_VALUE:
				enterOuterAlt(_localctx, 1);
				{
				setState(133);
				jsonpath();
				}
				break;
			case NEW:
				enterOuterAlt(_localctx, 2);
				{
				setState(134);
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
		enterRule(_localctx, 30, RULE_jsonpath);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(137);
			match(ROOT_VALUE);
			setState(139);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
				{
				setState(138);
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
		enterRule(_localctx, 32, RULE_subscript);
		int _la;
		try {
			setState(158);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RECURSIVE_DESCENT:
				enterOuterAlt(_localctx, 1);
				{
				setState(141);
				match(RECURSIVE_DESCENT);
				setState(144);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case WILDCARD_SUBSCRIPT:
				case ID:
					{
					setState(142);
					subscriptableBareword();
					}
					break;
				case BRACKET_LEFT:
					{
					setState(143);
					subscriptables();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(147);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(146);
					subscript();
					}
				}

				}
				break;
			case SUBSCRIPT:
				enterOuterAlt(_localctx, 2);
				{
				setState(149);
				match(SUBSCRIPT);
				setState(150);
				subscriptableBareword();
				setState(152);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(151);
					subscript();
					}
				}

				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 3);
				{
				setState(154);
				subscriptables();
				setState(156);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(155);
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
		enterRule(_localctx, 34, RULE_subscriptables);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(160);
			match(BRACKET_LEFT);
			setState(161);
			subscriptable();
			setState(166);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(162);
				match(COMMA);
				setState(163);
				subscriptable();
				}
				}
				setState(168);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(169);
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
		enterRule(_localctx, 36, RULE_subscriptableBareword);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(171);
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
		enterRule(_localctx, 38, RULE_subscriptable);
		int _la;
		try {
			setState(187);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(173);
				match(STRING);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(175);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NUMBER) {
					{
					setState(174);
					match(NUMBER);
					}
				}

				setState(178);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COLON) {
					{
					setState(177);
					sliceable();
					}
				}

				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(180);
				sliceable();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(181);
				match(WILDCARD_SUBSCRIPT);
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(182);
				match(QUESTION);
				setState(183);
				match(PAREN_LEFT);
				setState(184);
				expression();
				setState(185);
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
		enterRule(_localctx, 40, RULE_sliceable);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
			match(COLON);
			setState(191);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NUMBER) {
				{
				setState(190);
				match(NUMBER);
				}
			}

			setState(197);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(193);
				match(COLON);
				setState(195);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NUMBER) {
					{
					setState(194);
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
		enterRule(_localctx, 42, RULE_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(199);
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
		enterRule(_localctx, 44, RULE_andExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(201);
			orExpression();
			setState(204);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AND) {
				{
				setState(202);
				match(AND);
				setState(203);
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
		enterRule(_localctx, 46, RULE_orExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(206);
			notExpression();
			setState(209);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OR) {
				{
				setState(207);
				match(OR);
				setState(208);
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
		enterRule(_localctx, 48, RULE_notExpression);
		int _la;
		try {
			setState(225);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NOT:
				enterOuterAlt(_localctx, 1);
				{
				setState(211);
				match(NOT);
				setState(212);
				notExpression();
				}
				break;
			case PAREN_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(213);
				match(PAREN_LEFT);
				setState(214);
				expression();
				setState(215);
				match(PAREN_RIGHT);
				}
				break;
			case CURRENT_VALUE:
			case ROOT_VALUE:
				enterOuterAlt(_localctx, 3);
				{
				setState(217);
				_la = _input.LA(1);
				if ( !(_la==CURRENT_VALUE || _la==ROOT_VALUE) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(219);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(218);
					subscript();
					}
				}

				setState(223);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQ) | (1L << GE) | (1L << GT) | (1L << LE) | (1L << LT) | (1L << NE))) != 0)) {
					{
					setState(221);
					_la = _input.LA(1);
					if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQ) | (1L << GE) | (1L << GT) | (1L << LE) | (1L << LT) | (1L << NE))) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(222);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3#\u00e6\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\3\2\3\2\3\2\3\3\3\3\3\4\3\4\3\4\3\4\7\4>\n\4\f\4\16\4A\13\4"+
		"\3\4\3\4\3\4\3\4\5\4G\n\4\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\7\6Q\n\6\f\6"+
		"\16\6T\13\6\3\6\3\6\3\6\3\6\5\6Z\n\6\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\5"+
		"\7d\n\7\3\b\3\b\3\t\3\t\3\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\r\3\r\5\r"+
		"t\n\r\3\r\3\r\3\16\3\16\3\16\7\16{\n\16\f\16\16\16~\13\16\3\17\3\17\3"+
		"\17\7\17\u0083\n\17\f\17\16\17\u0086\13\17\3\20\3\20\5\20\u008a\n\20\3"+
		"\21\3\21\5\21\u008e\n\21\3\22\3\22\3\22\5\22\u0093\n\22\3\22\5\22\u0096"+
		"\n\22\3\22\3\22\3\22\5\22\u009b\n\22\3\22\3\22\5\22\u009f\n\22\5\22\u00a1"+
		"\n\22\3\23\3\23\3\23\3\23\7\23\u00a7\n\23\f\23\16\23\u00aa\13\23\3\23"+
		"\3\23\3\24\3\24\3\25\3\25\5\25\u00b2\n\25\3\25\5\25\u00b5\n\25\3\25\3"+
		"\25\3\25\3\25\3\25\3\25\3\25\5\25\u00be\n\25\3\26\3\26\5\26\u00c2\n\26"+
		"\3\26\3\26\5\26\u00c6\n\26\5\26\u00c8\n\26\3\27\3\27\3\30\3\30\3\30\5"+
		"\30\u00cf\n\30\3\31\3\31\3\31\5\31\u00d4\n\31\3\32\3\32\3\32\3\32\3\32"+
		"\3\32\3\32\3\32\5\32\u00de\n\32\3\32\3\32\5\32\u00e2\n\32\5\32\u00e4\n"+
		"\32\3\32\2\2\33\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62"+
		"\2\6\3\2\23\24\4\2\7\7##\4\2\3\3\5\5\3\2\n\17\2\u00f2\2\64\3\2\2\2\4\67"+
		"\3\2\2\2\6F\3\2\2\2\bH\3\2\2\2\nY\3\2\2\2\fc\3\2\2\2\16e\3\2\2\2\20g\3"+
		"\2\2\2\22i\3\2\2\2\24k\3\2\2\2\26m\3\2\2\2\30o\3\2\2\2\32w\3\2\2\2\34"+
		"\177\3\2\2\2\36\u0089\3\2\2\2 \u008b\3\2\2\2\"\u00a0\3\2\2\2$\u00a2\3"+
		"\2\2\2&\u00ad\3\2\2\2(\u00bd\3\2\2\2*\u00bf\3\2\2\2,\u00c9\3\2\2\2.\u00cb"+
		"\3\2\2\2\60\u00d0\3\2\2\2\62\u00e3\3\2\2\2\64\65\5\4\3\2\65\66\7\2\2\3"+
		"\66\3\3\2\2\2\678\5\f\7\28\5\3\2\2\29:\7\26\2\2:?\5\b\5\2;<\7\33\2\2<"+
		">\5\b\5\2=;\3\2\2\2>A\3\2\2\2?=\3\2\2\2?@\3\2\2\2@B\3\2\2\2A?\3\2\2\2"+
		"BC\7\27\2\2CG\3\2\2\2DE\7\26\2\2EG\7\27\2\2F9\3\2\2\2FD\3\2\2\2G\7\3\2"+
		"\2\2HI\7\37\2\2IJ\7\32\2\2JK\5\f\7\2K\t\3\2\2\2LM\7\30\2\2MR\5\f\7\2N"+
		"O\7\33\2\2OQ\5\f\7\2PN\3\2\2\2QT\3\2\2\2RP\3\2\2\2RS\3\2\2\2SU\3\2\2\2"+
		"TR\3\2\2\2UV\7\31\2\2VZ\3\2\2\2WX\7\30\2\2XZ\7\31\2\2YL\3\2\2\2YW\3\2"+
		"\2\2Z\13\3\2\2\2[d\5\6\4\2\\d\5\n\6\2]d\5\24\13\2^d\5\16\b\2_d\5\22\n"+
		"\2`d\5\20\t\2ad\5\26\f\2bd\5\34\17\2c[\3\2\2\2c\\\3\2\2\2c]\3\2\2\2c^"+
		"\3\2\2\2c_\3\2\2\2c`\3\2\2\2ca\3\2\2\2cb\3\2\2\2d\r\3\2\2\2ef\7\37\2\2"+
		"f\17\3\2\2\2gh\7 \2\2h\21\3\2\2\2ij\7!\2\2j\23\3\2\2\2kl\t\2\2\2l\25\3"+
		"\2\2\2mn\7\25\2\2n\27\3\2\2\2op\7\22\2\2pq\7#\2\2qs\7\34\2\2rt\5\32\16"+
		"\2sr\3\2\2\2st\3\2\2\2tu\3\2\2\2uv\7\35\2\2v\31\3\2\2\2w|\5\f\7\2xy\7"+
		"\33\2\2y{\5\f\7\2zx\3\2\2\2{~\3\2\2\2|z\3\2\2\2|}\3\2\2\2}\33\3\2\2\2"+
		"~|\3\2\2\2\177\u0084\5\36\20\2\u0080\u0081\7\b\2\2\u0081\u0083\5\36\20"+
		"\2\u0082\u0080\3\2\2\2\u0083\u0086\3\2\2\2\u0084\u0082\3\2\2\2\u0084\u0085"+
		"\3\2\2\2\u0085\35\3\2\2\2\u0086\u0084\3\2\2\2\u0087\u008a\5 \21\2\u0088"+
		"\u008a\5\30\r\2\u0089\u0087\3\2\2\2\u0089\u0088\3\2\2\2\u008a\37\3\2\2"+
		"\2\u008b\u008d\7\5\2\2\u008c\u008e\5\"\22\2\u008d\u008c\3\2\2\2\u008d"+
		"\u008e\3\2\2\2\u008e!\3\2\2\2\u008f\u0092\7\4\2\2\u0090\u0093\5&\24\2"+
		"\u0091\u0093\5$\23\2\u0092\u0090\3\2\2\2\u0092\u0091\3\2\2\2\u0093\u0095"+
		"\3\2\2\2\u0094\u0096\5\"\22\2\u0095\u0094\3\2\2\2\u0095\u0096\3\2\2\2"+
		"\u0096\u00a1\3\2\2\2\u0097\u0098\7\6\2\2\u0098\u009a\5&\24\2\u0099\u009b"+
		"\5\"\22\2\u009a\u0099\3\2\2\2\u009a\u009b\3\2\2\2\u009b\u00a1\3\2\2\2"+
		"\u009c\u009e\5$\23\2\u009d\u009f\5\"\22\2\u009e\u009d\3\2\2\2\u009e\u009f"+
		"\3\2\2\2\u009f\u00a1\3\2\2\2\u00a0\u008f\3\2\2\2\u00a0\u0097\3\2\2\2\u00a0"+
		"\u009c\3\2\2\2\u00a1#\3\2\2\2\u00a2\u00a3\7\30\2\2\u00a3\u00a8\5(\25\2"+
		"\u00a4\u00a5\7\33\2\2\u00a5\u00a7\5(\25\2\u00a6\u00a4\3\2\2\2\u00a7\u00aa"+
		"\3\2\2\2\u00a8\u00a6\3\2\2\2\u00a8\u00a9\3\2\2\2\u00a9\u00ab\3\2\2\2\u00aa"+
		"\u00a8\3\2\2\2\u00ab\u00ac\7\31\2\2\u00ac%\3\2\2\2\u00ad\u00ae\t\3\2\2"+
		"\u00ae\'\3\2\2\2\u00af\u00be\7\37\2\2\u00b0\u00b2\7 \2\2\u00b1\u00b0\3"+
		"\2\2\2\u00b1\u00b2\3\2\2\2\u00b2\u00b4\3\2\2\2\u00b3\u00b5\5*\26\2\u00b4"+
		"\u00b3\3\2\2\2\u00b4\u00b5\3\2\2\2\u00b5\u00be\3\2\2\2\u00b6\u00be\5*"+
		"\26\2\u00b7\u00be\7\7\2\2\u00b8\u00b9\7\36\2\2\u00b9\u00ba\7\34\2\2\u00ba"+
		"\u00bb\5,\27\2\u00bb\u00bc\7\35\2\2\u00bc\u00be\3\2\2\2\u00bd\u00af\3"+
		"\2\2\2\u00bd\u00b1\3\2\2\2\u00bd\u00b6\3\2\2\2\u00bd\u00b7\3\2\2\2\u00bd"+
		"\u00b8\3\2\2\2\u00be)\3\2\2\2\u00bf\u00c1\7\32\2\2\u00c0\u00c2\7 \2\2"+
		"\u00c1\u00c0\3\2\2\2\u00c1\u00c2\3\2\2\2\u00c2\u00c7\3\2\2\2\u00c3\u00c5"+
		"\7\32\2\2\u00c4\u00c6\7 \2\2\u00c5\u00c4\3\2\2\2\u00c5\u00c6\3\2\2\2\u00c6"+
		"\u00c8\3\2\2\2\u00c7\u00c3\3\2\2\2\u00c7\u00c8\3\2\2\2\u00c8+\3\2\2\2"+
		"\u00c9\u00ca\5.\30\2\u00ca-\3\2\2\2\u00cb\u00ce\5\60\31\2\u00cc\u00cd"+
		"\7\t\2\2\u00cd\u00cf\5.\30\2\u00ce\u00cc\3\2\2\2\u00ce\u00cf\3\2\2\2\u00cf"+
		"/\3\2\2\2\u00d0\u00d3\5\62\32\2\u00d1\u00d2\7\21\2\2\u00d2\u00d4\5\60"+
		"\31\2\u00d3\u00d1\3\2\2\2\u00d3\u00d4\3\2\2\2\u00d4\61\3\2\2\2\u00d5\u00d6"+
		"\7\20\2\2\u00d6\u00e4\5\62\32\2\u00d7\u00d8\7\34\2\2\u00d8\u00d9\5,\27"+
		"\2\u00d9\u00da\7\35\2\2\u00da\u00e4\3\2\2\2\u00db\u00dd\t\4\2\2\u00dc"+
		"\u00de\5\"\22\2\u00dd\u00dc\3\2\2\2\u00dd\u00de\3\2\2\2\u00de\u00e1\3"+
		"\2\2\2\u00df\u00e0\t\5\2\2\u00e0\u00e2\5\f\7\2\u00e1\u00df\3\2\2\2\u00e1"+
		"\u00e2\3\2\2\2\u00e2\u00e4\3\2\2\2\u00e3\u00d5\3\2\2\2\u00e3\u00d7\3\2"+
		"\2\2\u00e3\u00db\3\2\2\2\u00e4\63\3\2\2\2\35?FRYcs|\u0084\u0089\u008d"+
		"\u0092\u0095\u009a\u009e\u00a0\u00a8\u00b1\u00b4\u00bd\u00c1\u00c5\u00c7"+
		"\u00ce\u00d3\u00dd\u00e1\u00e3";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}