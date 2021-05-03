// Generated from d:\Src\Sdk\jslt\src\Black.Beard.Jslt\Jslt\Parser\Grammar\Parser.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class Parser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		CURRENT_VALUE=1, RECURSIVE_DESCENT=2, ROOT_VALUE=3, SUBSCRIPT=4, WILDCARD_SUBSCRIPT=5, 
		AND=6, EQ=7, GE=8, GT=9, LE=10, LT=11, NE=12, NOT=13, OR=14, NEW=15, TRUE=16, 
		FALSE=17, NULL=18, BRACE_LEFT=19, BRACE_RIGHT=20, BRACKET_LEFT=21, BRACKET_RIGHT=22, 
		COLON=23, COMMA=24, PAREN_LEFT=25, PAREN_RIGHT=26, QUESTION=27, STRING=28, 
		NUMBER=29, WS=30, ID=31;
	public static final int
		RULE_script = 0, RULE_jsonpath = 1, RULE_subscript = 2, RULE_subscriptables = 3, 
		RULE_subscriptableBareword = 4, RULE_subscriptable = 5, RULE_sliceable = 6, 
		RULE_expression = 7, RULE_andExpression = 8, RULE_orExpression = 9, RULE_notExpression = 10, 
		RULE_json = 11, RULE_obj = 12, RULE_pair = 13, RULE_array = 14, RULE_jsonValue = 15, 
		RULE_jsonCtor = 16, RULE_jsonValueList = 17;
	private static String[] makeRuleNames() {
		return new String[] {
			"script", "jsonpath", "subscript", "subscriptables", "subscriptableBareword", 
			"subscriptable", "sliceable", "expression", "andExpression", "orExpression", 
			"notExpression", "json", "obj", "pair", "array", "jsonValue", "jsonCtor", 
			"jsonValueList"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'@'", "'..'", "'$'", "'.'", "'*'", "'and'", "'='", "'>='", "'>'", 
			"'<='", "'<'", "'!='", "'not'", "'or'", "'new'", "'true'", "'false'", 
			"'null'", "'{'", "'}'", "'['", "']'", "':'", "','", "'('", "')'", "'?'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "CURRENT_VALUE", "RECURSIVE_DESCENT", "ROOT_VALUE", "SUBSCRIPT", 
			"WILDCARD_SUBSCRIPT", "AND", "EQ", "GE", "GT", "LE", "LT", "NE", "NOT", 
			"OR", "NEW", "TRUE", "FALSE", "NULL", "BRACE_LEFT", "BRACE_RIGHT", "BRACKET_LEFT", 
			"BRACKET_RIGHT", "COLON", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", "QUESTION", 
			"STRING", "NUMBER", "WS", "ID"
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
	public String getGrammarFileName() { return "Parser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public Parser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ScriptContext extends ParserRuleContext {
		public JsonpathContext jsonpath() {
			return getRuleContext(JsonpathContext.class,0);
		}
		public TerminalNode EOF() { return getToken(Parser.EOF, 0); }
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
			setState(36);
			jsonpath();
			setState(37);
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

	public static class JsonpathContext extends ParserRuleContext {
		public TerminalNode ROOT_VALUE() { return getToken(Parser.ROOT_VALUE, 0); }
		public TerminalNode EOF() { return getToken(Parser.EOF, 0); }
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
		enterRule(_localctx, 2, RULE_jsonpath);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(39);
			match(ROOT_VALUE);
			setState(41);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
				{
				setState(40);
				subscript();
				}
			}

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

	public static class SubscriptContext extends ParserRuleContext {
		public TerminalNode RECURSIVE_DESCENT() { return getToken(Parser.RECURSIVE_DESCENT, 0); }
		public SubscriptableBarewordContext subscriptableBareword() {
			return getRuleContext(SubscriptableBarewordContext.class,0);
		}
		public SubscriptablesContext subscriptables() {
			return getRuleContext(SubscriptablesContext.class,0);
		}
		public SubscriptContext subscript() {
			return getRuleContext(SubscriptContext.class,0);
		}
		public TerminalNode SUBSCRIPT() { return getToken(Parser.SUBSCRIPT, 0); }
		public SubscriptContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscript; }
	}

	public final SubscriptContext subscript() throws RecognitionException {
		SubscriptContext _localctx = new SubscriptContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_subscript);
		int _la;
		try {
			setState(62);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case RECURSIVE_DESCENT:
				enterOuterAlt(_localctx, 1);
				{
				setState(45);
				match(RECURSIVE_DESCENT);
				setState(48);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case WILDCARD_SUBSCRIPT:
				case ID:
					{
					setState(46);
					subscriptableBareword();
					}
					break;
				case BRACKET_LEFT:
					{
					setState(47);
					subscriptables();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(51);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(50);
					subscript();
					}
				}

				}
				break;
			case SUBSCRIPT:
				enterOuterAlt(_localctx, 2);
				{
				setState(53);
				match(SUBSCRIPT);
				setState(54);
				subscriptableBareword();
				setState(56);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(55);
					subscript();
					}
				}

				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 3);
				{
				setState(58);
				subscriptables();
				setState(60);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(59);
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
		public TerminalNode BRACKET_LEFT() { return getToken(Parser.BRACKET_LEFT, 0); }
		public List<SubscriptableContext> subscriptable() {
			return getRuleContexts(SubscriptableContext.class);
		}
		public SubscriptableContext subscriptable(int i) {
			return getRuleContext(SubscriptableContext.class,i);
		}
		public TerminalNode BRACKET_RIGHT() { return getToken(Parser.BRACKET_RIGHT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(Parser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(Parser.COMMA, i);
		}
		public SubscriptablesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscriptables; }
	}

	public final SubscriptablesContext subscriptables() throws RecognitionException {
		SubscriptablesContext _localctx = new SubscriptablesContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_subscriptables);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(64);
			match(BRACKET_LEFT);
			setState(65);
			subscriptable();
			setState(70);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(66);
				match(COMMA);
				setState(67);
				subscriptable();
				}
				}
				setState(72);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(73);
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
		public TerminalNode ID() { return getToken(Parser.ID, 0); }
		public TerminalNode WILDCARD_SUBSCRIPT() { return getToken(Parser.WILDCARD_SUBSCRIPT, 0); }
		public SubscriptableBarewordContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscriptableBareword; }
	}

	public final SubscriptableBarewordContext subscriptableBareword() throws RecognitionException {
		SubscriptableBarewordContext _localctx = new SubscriptableBarewordContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_subscriptableBareword);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(75);
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
		public TerminalNode STRING() { return getToken(Parser.STRING, 0); }
		public TerminalNode NUMBER() { return getToken(Parser.NUMBER, 0); }
		public SliceableContext sliceable() {
			return getRuleContext(SliceableContext.class,0);
		}
		public TerminalNode WILDCARD_SUBSCRIPT() { return getToken(Parser.WILDCARD_SUBSCRIPT, 0); }
		public TerminalNode QUESTION() { return getToken(Parser.QUESTION, 0); }
		public TerminalNode PAREN_LEFT() { return getToken(Parser.PAREN_LEFT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PAREN_RIGHT() { return getToken(Parser.PAREN_RIGHT, 0); }
		public SubscriptableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subscriptable; }
	}

	public final SubscriptableContext subscriptable() throws RecognitionException {
		SubscriptableContext _localctx = new SubscriptableContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_subscriptable);
		int _la;
		try {
			setState(90);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case STRING:
				enterOuterAlt(_localctx, 1);
				{
				setState(77);
				match(STRING);
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 2);
				{
				setState(78);
				match(NUMBER);
				setState(79);
				if (!(self.tryCast(int))) throw new FailedPredicateException(this, "self.tryCast(int)");
				setState(81);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COLON) {
					{
					setState(80);
					sliceable();
					}
				}

				}
				break;
			case COLON:
				enterOuterAlt(_localctx, 3);
				{
				setState(83);
				sliceable();
				}
				break;
			case WILDCARD_SUBSCRIPT:
				enterOuterAlt(_localctx, 4);
				{
				setState(84);
				match(WILDCARD_SUBSCRIPT);
				}
				break;
			case QUESTION:
				enterOuterAlt(_localctx, 5);
				{
				setState(85);
				match(QUESTION);
				setState(86);
				match(PAREN_LEFT);
				setState(87);
				expression();
				setState(88);
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

	public static class SliceableContext extends ParserRuleContext {
		public List<TerminalNode> COLON() { return getTokens(Parser.COLON); }
		public TerminalNode COLON(int i) {
			return getToken(Parser.COLON, i);
		}
		public List<TerminalNode> NUMBER() { return getTokens(Parser.NUMBER); }
		public TerminalNode NUMBER(int i) {
			return getToken(Parser.NUMBER, i);
		}
		public SliceableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sliceable; }
	}

	public final SliceableContext sliceable() throws RecognitionException {
		SliceableContext _localctx = new SliceableContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_sliceable);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(92);
			match(COLON);
			setState(95);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NUMBER) {
				{
				setState(93);
				match(NUMBER);
				setState(94);
				if (!(self.tryCast(int))) throw new FailedPredicateException(this, "self.tryCast(int)");
				}
			}

			setState(100);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(97);
				match(COLON);
				setState(98);
				match(NUMBER);
				setState(99);
				if (!(self.tryCast(int))) throw new FailedPredicateException(this, "self.tryCast(int)");
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
		enterRule(_localctx, 14, RULE_expression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
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
		public TerminalNode AND() { return getToken(Parser.AND, 0); }
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
		enterRule(_localctx, 16, RULE_andExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(104);
			orExpression();
			setState(107);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AND) {
				{
				setState(105);
				match(AND);
				setState(106);
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
		public TerminalNode OR() { return getToken(Parser.OR, 0); }
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
		enterRule(_localctx, 18, RULE_orExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			notExpression();
			setState(112);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OR) {
				{
				setState(110);
				match(OR);
				setState(111);
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
		public TerminalNode NOT() { return getToken(Parser.NOT, 0); }
		public NotExpressionContext notExpression() {
			return getRuleContext(NotExpressionContext.class,0);
		}
		public TerminalNode PAREN_LEFT() { return getToken(Parser.PAREN_LEFT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PAREN_RIGHT() { return getToken(Parser.PAREN_RIGHT, 0); }
		public TerminalNode ROOT_VALUE() { return getToken(Parser.ROOT_VALUE, 0); }
		public TerminalNode CURRENT_VALUE() { return getToken(Parser.CURRENT_VALUE, 0); }
		public SubscriptContext subscript() {
			return getRuleContext(SubscriptContext.class,0);
		}
		public JsonValueContext jsonValue() {
			return getRuleContext(JsonValueContext.class,0);
		}
		public TerminalNode EQ() { return getToken(Parser.EQ, 0); }
		public TerminalNode NE() { return getToken(Parser.NE, 0); }
		public TerminalNode LT() { return getToken(Parser.LT, 0); }
		public TerminalNode LE() { return getToken(Parser.LE, 0); }
		public TerminalNode GT() { return getToken(Parser.GT, 0); }
		public TerminalNode GE() { return getToken(Parser.GE, 0); }
		public NotExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_notExpression; }
	}

	public final NotExpressionContext notExpression() throws RecognitionException {
		NotExpressionContext _localctx = new NotExpressionContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_notExpression);
		int _la;
		try {
			setState(128);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NOT:
				enterOuterAlt(_localctx, 1);
				{
				setState(114);
				match(NOT);
				setState(115);
				notExpression();
				}
				break;
			case PAREN_LEFT:
				enterOuterAlt(_localctx, 2);
				{
				setState(116);
				match(PAREN_LEFT);
				setState(117);
				expression();
				setState(118);
				match(PAREN_RIGHT);
				}
				break;
			case CURRENT_VALUE:
			case ROOT_VALUE:
				enterOuterAlt(_localctx, 3);
				{
				setState(120);
				_la = _input.LA(1);
				if ( !(_la==CURRENT_VALUE || _la==ROOT_VALUE) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(122);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << RECURSIVE_DESCENT) | (1L << SUBSCRIPT) | (1L << BRACKET_LEFT))) != 0)) {
					{
					setState(121);
					subscript();
					}
				}

				setState(126);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQ) | (1L << GE) | (1L << GT) | (1L << LE) | (1L << LT) | (1L << NE))) != 0)) {
					{
					setState(124);
					_la = _input.LA(1);
					if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQ) | (1L << GE) | (1L << GT) | (1L << LE) | (1L << LT) | (1L << NE))) != 0)) ) {
					_errHandler.recoverInline(this);
					}
					else {
						if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
						_errHandler.reportMatch(this);
						consume();
					}
					setState(125);
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
		enterRule(_localctx, 22, RULE_json);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
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
		public TerminalNode BRACE_LEFT() { return getToken(Parser.BRACE_LEFT, 0); }
		public List<PairContext> pair() {
			return getRuleContexts(PairContext.class);
		}
		public PairContext pair(int i) {
			return getRuleContext(PairContext.class,i);
		}
		public TerminalNode BRACE_RIGHT() { return getToken(Parser.BRACE_RIGHT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(Parser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(Parser.COMMA, i);
		}
		public ObjContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_obj; }
	}

	public final ObjContext obj() throws RecognitionException {
		ObjContext _localctx = new ObjContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_obj);
		int _la;
		try {
			setState(145);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(132);
				match(BRACE_LEFT);
				setState(133);
				pair();
				setState(138);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(134);
					match(COMMA);
					setState(135);
					pair();
					}
					}
					setState(140);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(141);
				match(BRACE_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(143);
				match(BRACE_LEFT);
				setState(144);
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
		public TerminalNode STRING() { return getToken(Parser.STRING, 0); }
		public TerminalNode COLON() { return getToken(Parser.COLON, 0); }
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
		enterRule(_localctx, 26, RULE_pair);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(147);
			match(STRING);
			setState(148);
			match(COLON);
			setState(149);
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
		public TerminalNode BRACKET_LEFT() { return getToken(Parser.BRACKET_LEFT, 0); }
		public List<JsonValueContext> jsonValue() {
			return getRuleContexts(JsonValueContext.class);
		}
		public JsonValueContext jsonValue(int i) {
			return getRuleContext(JsonValueContext.class,i);
		}
		public TerminalNode BRACKET_RIGHT() { return getToken(Parser.BRACKET_RIGHT, 0); }
		public List<TerminalNode> COMMA() { return getTokens(Parser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(Parser.COMMA, i);
		}
		public ArrayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array; }
	}

	public final ArrayContext array() throws RecognitionException {
		ArrayContext _localctx = new ArrayContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_array);
		int _la;
		try {
			setState(164);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(151);
				match(BRACKET_LEFT);
				setState(152);
				jsonValue();
				setState(157);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(153);
					match(COMMA);
					setState(154);
					jsonValue();
					}
					}
					setState(159);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(160);
				match(BRACKET_RIGHT);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(162);
				match(BRACKET_LEFT);
				setState(163);
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
		public TerminalNode STRING() { return getToken(Parser.STRING, 0); }
		public TerminalNode NUMBER() { return getToken(Parser.NUMBER, 0); }
		public ObjContext obj() {
			return getRuleContext(ObjContext.class,0);
		}
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public TerminalNode TRUE() { return getToken(Parser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(Parser.FALSE, 0); }
		public TerminalNode NULL() { return getToken(Parser.NULL, 0); }
		public JsonpathContext jsonpath() {
			return getRuleContext(JsonpathContext.class,0);
		}
		public JsonCtorContext jsonCtor() {
			return getRuleContext(JsonCtorContext.class,0);
		}
		public JsonValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValue; }
	}

	public final JsonValueContext jsonValue() throws RecognitionException {
		JsonValueContext _localctx = new JsonValueContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_jsonValue);
		try {
			setState(175);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case STRING:
				enterOuterAlt(_localctx, 1);
				{
				setState(166);
				match(STRING);
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 2);
				{
				setState(167);
				match(NUMBER);
				}
				break;
			case BRACE_LEFT:
				enterOuterAlt(_localctx, 3);
				{
				setState(168);
				obj();
				}
				break;
			case BRACKET_LEFT:
				enterOuterAlt(_localctx, 4);
				{
				setState(169);
				array();
				}
				break;
			case TRUE:
				enterOuterAlt(_localctx, 5);
				{
				setState(170);
				match(TRUE);
				}
				break;
			case FALSE:
				enterOuterAlt(_localctx, 6);
				{
				setState(171);
				match(FALSE);
				}
				break;
			case NULL:
				enterOuterAlt(_localctx, 7);
				{
				setState(172);
				match(NULL);
				}
				break;
			case ROOT_VALUE:
				enterOuterAlt(_localctx, 8);
				{
				setState(173);
				jsonpath();
				}
				break;
			case NEW:
				enterOuterAlt(_localctx, 9);
				{
				setState(174);
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

	public static class JsonCtorContext extends ParserRuleContext {
		public TerminalNode NEW() { return getToken(Parser.NEW, 0); }
		public TerminalNode ID() { return getToken(Parser.ID, 0); }
		public TerminalNode PAREN_LEFT() { return getToken(Parser.PAREN_LEFT, 0); }
		public TerminalNode PAREN_RIGHT() { return getToken(Parser.PAREN_RIGHT, 0); }
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
		enterRule(_localctx, 32, RULE_jsonCtor);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(177);
			match(NEW);
			setState(178);
			match(ID);
			setState(179);
			match(PAREN_LEFT);
			setState(181);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << ROOT_VALUE) | (1L << NEW) | (1L << TRUE) | (1L << FALSE) | (1L << NULL) | (1L << BRACE_LEFT) | (1L << BRACKET_LEFT) | (1L << STRING) | (1L << NUMBER))) != 0)) {
				{
				setState(180);
				jsonValueList();
				}
			}

			setState(183);
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
		public List<TerminalNode> COMMA() { return getTokens(Parser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(Parser.COMMA, i);
		}
		public JsonValueListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_jsonValueList; }
	}

	public final JsonValueListContext jsonValueList() throws RecognitionException {
		JsonValueListContext _localctx = new JsonValueListContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_jsonValueList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(185);
			jsonValue();
			setState(190);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(186);
				match(COMMA);
				setState(187);
				jsonValue();
				}
				}
				setState(192);
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
		case 5:
			return subscriptable_sempred((SubscriptableContext)_localctx, predIndex);
		case 6:
			return sliceable_sempred((SliceableContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean subscriptable_sempred(SubscriptableContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return self.tryCast(int);
		}
		return true;
	}
	private boolean sliceable_sempred(SliceableContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return self.tryCast(int);
		case 2:
			return self.tryCast(int);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3!\u00c4\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\3\2\3\2\3\2\3\3\3\3\5\3,\n\3\3\3\3\3\3\4\3\4\3\4\5\4\63\n\4"+
		"\3\4\5\4\66\n\4\3\4\3\4\3\4\5\4;\n\4\3\4\3\4\5\4?\n\4\5\4A\n\4\3\5\3\5"+
		"\3\5\3\5\7\5G\n\5\f\5\16\5J\13\5\3\5\3\5\3\6\3\6\3\7\3\7\3\7\3\7\5\7T"+
		"\n\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\5\7]\n\7\3\b\3\b\3\b\5\bb\n\b\3\b\3\b"+
		"\3\b\5\bg\n\b\3\t\3\t\3\n\3\n\3\n\5\nn\n\n\3\13\3\13\3\13\5\13s\n\13\3"+
		"\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\5\f}\n\f\3\f\3\f\5\f\u0081\n\f\5\f\u0083"+
		"\n\f\3\r\3\r\3\16\3\16\3\16\3\16\7\16\u008b\n\16\f\16\16\16\u008e\13\16"+
		"\3\16\3\16\3\16\3\16\5\16\u0094\n\16\3\17\3\17\3\17\3\17\3\20\3\20\3\20"+
		"\3\20\7\20\u009e\n\20\f\20\16\20\u00a1\13\20\3\20\3\20\3\20\3\20\5\20"+
		"\u00a7\n\20\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u00b2\n"+
		"\21\3\22\3\22\3\22\3\22\5\22\u00b8\n\22\3\22\3\22\3\23\3\23\3\23\7\23"+
		"\u00bf\n\23\f\23\16\23\u00c2\13\23\3\23\2\2\24\2\4\6\b\n\f\16\20\22\24"+
		"\26\30\32\34\36 \"$\2\5\4\2\7\7!!\4\2\3\3\5\5\3\2\t\16\2\u00d4\2&\3\2"+
		"\2\2\4)\3\2\2\2\6@\3\2\2\2\bB\3\2\2\2\nM\3\2\2\2\f\\\3\2\2\2\16^\3\2\2"+
		"\2\20h\3\2\2\2\22j\3\2\2\2\24o\3\2\2\2\26\u0082\3\2\2\2\30\u0084\3\2\2"+
		"\2\32\u0093\3\2\2\2\34\u0095\3\2\2\2\36\u00a6\3\2\2\2 \u00b1\3\2\2\2\""+
		"\u00b3\3\2\2\2$\u00bb\3\2\2\2&\'\5\4\3\2\'(\7\2\2\3(\3\3\2\2\2)+\7\5\2"+
		"\2*,\5\6\4\2+*\3\2\2\2+,\3\2\2\2,-\3\2\2\2-.\7\2\2\3.\5\3\2\2\2/\62\7"+
		"\4\2\2\60\63\5\n\6\2\61\63\5\b\5\2\62\60\3\2\2\2\62\61\3\2\2\2\63\65\3"+
		"\2\2\2\64\66\5\6\4\2\65\64\3\2\2\2\65\66\3\2\2\2\66A\3\2\2\2\678\7\6\2"+
		"\28:\5\n\6\29;\5\6\4\2:9\3\2\2\2:;\3\2\2\2;A\3\2\2\2<>\5\b\5\2=?\5\6\4"+
		"\2>=\3\2\2\2>?\3\2\2\2?A\3\2\2\2@/\3\2\2\2@\67\3\2\2\2@<\3\2\2\2A\7\3"+
		"\2\2\2BC\7\27\2\2CH\5\f\7\2DE\7\32\2\2EG\5\f\7\2FD\3\2\2\2GJ\3\2\2\2H"+
		"F\3\2\2\2HI\3\2\2\2IK\3\2\2\2JH\3\2\2\2KL\7\30\2\2L\t\3\2\2\2MN\t\2\2"+
		"\2N\13\3\2\2\2O]\7\36\2\2PQ\7\37\2\2QS\6\7\2\2RT\5\16\b\2SR\3\2\2\2ST"+
		"\3\2\2\2T]\3\2\2\2U]\5\16\b\2V]\7\7\2\2WX\7\35\2\2XY\7\33\2\2YZ\5\20\t"+
		"\2Z[\7\34\2\2[]\3\2\2\2\\O\3\2\2\2\\P\3\2\2\2\\U\3\2\2\2\\V\3\2\2\2\\"+
		"W\3\2\2\2]\r\3\2\2\2^a\7\31\2\2_`\7\37\2\2`b\6\b\3\2a_\3\2\2\2ab\3\2\2"+
		"\2bf\3\2\2\2cd\7\31\2\2de\7\37\2\2eg\6\b\4\2fc\3\2\2\2fg\3\2\2\2g\17\3"+
		"\2\2\2hi\5\22\n\2i\21\3\2\2\2jm\5\24\13\2kl\7\b\2\2ln\5\22\n\2mk\3\2\2"+
		"\2mn\3\2\2\2n\23\3\2\2\2or\5\26\f\2pq\7\20\2\2qs\5\24\13\2rp\3\2\2\2r"+
		"s\3\2\2\2s\25\3\2\2\2tu\7\17\2\2u\u0083\5\26\f\2vw\7\33\2\2wx\5\20\t\2"+
		"xy\7\34\2\2y\u0083\3\2\2\2z|\t\3\2\2{}\5\6\4\2|{\3\2\2\2|}\3\2\2\2}\u0080"+
		"\3\2\2\2~\177\t\4\2\2\177\u0081\5 \21\2\u0080~\3\2\2\2\u0080\u0081\3\2"+
		"\2\2\u0081\u0083\3\2\2\2\u0082t\3\2\2\2\u0082v\3\2\2\2\u0082z\3\2\2\2"+
		"\u0083\27\3\2\2\2\u0084\u0085\5 \21\2\u0085\31\3\2\2\2\u0086\u0087\7\25"+
		"\2\2\u0087\u008c\5\34\17\2\u0088\u0089\7\32\2\2\u0089\u008b\5\34\17\2"+
		"\u008a\u0088\3\2\2\2\u008b\u008e\3\2\2\2\u008c\u008a\3\2\2\2\u008c\u008d"+
		"\3\2\2\2\u008d\u008f\3\2\2\2\u008e\u008c\3\2\2\2\u008f\u0090\7\26\2\2"+
		"\u0090\u0094\3\2\2\2\u0091\u0092\7\25\2\2\u0092\u0094\7\26\2\2\u0093\u0086"+
		"\3\2\2\2\u0093\u0091\3\2\2\2\u0094\33\3\2\2\2\u0095\u0096\7\36\2\2\u0096"+
		"\u0097\7\31\2\2\u0097\u0098\5 \21\2\u0098\35\3\2\2\2\u0099\u009a\7\27"+
		"\2\2\u009a\u009f\5 \21\2\u009b\u009c\7\32\2\2\u009c\u009e\5 \21\2\u009d"+
		"\u009b\3\2\2\2\u009e\u00a1\3\2\2\2\u009f\u009d\3\2\2\2\u009f\u00a0\3\2"+
		"\2\2\u00a0\u00a2\3\2\2\2\u00a1\u009f\3\2\2\2\u00a2\u00a3\7\30\2\2\u00a3"+
		"\u00a7\3\2\2\2\u00a4\u00a5\7\27\2\2\u00a5\u00a7\7\30\2\2\u00a6\u0099\3"+
		"\2\2\2\u00a6\u00a4\3\2\2\2\u00a7\37\3\2\2\2\u00a8\u00b2\7\36\2\2\u00a9"+
		"\u00b2\7\37\2\2\u00aa\u00b2\5\32\16\2\u00ab\u00b2\5\36\20\2\u00ac\u00b2"+
		"\7\22\2\2\u00ad\u00b2\7\23\2\2\u00ae\u00b2\7\24\2\2\u00af\u00b2\5\4\3"+
		"\2\u00b0\u00b2\5\"\22\2\u00b1\u00a8\3\2\2\2\u00b1\u00a9\3\2\2\2\u00b1"+
		"\u00aa\3\2\2\2\u00b1\u00ab\3\2\2\2\u00b1\u00ac\3\2\2\2\u00b1\u00ad\3\2"+
		"\2\2\u00b1\u00ae\3\2\2\2\u00b1\u00af\3\2\2\2\u00b1\u00b0\3\2\2\2\u00b2"+
		"!\3\2\2\2\u00b3\u00b4\7\21\2\2\u00b4\u00b5\7!\2\2\u00b5\u00b7\7\33\2\2"+
		"\u00b6\u00b8\5$\23\2\u00b7\u00b6\3\2\2\2\u00b7\u00b8\3\2\2\2\u00b8\u00b9"+
		"\3\2\2\2\u00b9\u00ba\7\34\2\2\u00ba#\3\2\2\2\u00bb\u00c0\5 \21\2\u00bc"+
		"\u00bd\7\32\2\2\u00bd\u00bf\5 \21\2\u00be\u00bc\3\2\2\2\u00bf\u00c2\3"+
		"\2\2\2\u00c0\u00be\3\2\2\2\u00c0\u00c1\3\2\2\2\u00c1%\3\2\2\2\u00c2\u00c0"+
		"\3\2\2\2\31+\62\65:>@HS\\afmr|\u0080\u0082\u008c\u0093\u009f\u00a6\u00b1"+
		"\u00b7\u00c0";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}