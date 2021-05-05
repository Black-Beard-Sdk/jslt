// Generated from d:\Src\Sdk\jslt\src\Black.Beard.Jslt\Json\Jslt\Parser\Grammar\JsltLexer.g4 by ANTLR 4.8
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JsltLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"CURRENT_VALUE", "RECURSIVE_DESCENT", "ROOT_VALUE", "SUBSCRIPT", "WILDCARD_SUBSCRIPT", 
			"PIPE", "URI", "TIME", "DATETIME", "AND", "EQ", "GE", "GT", "LE", "LT", 
			"NE", "NOT", "OR", "NEW", "TRUE", "FALSE", "NULL", "BRACE_LEFT", "BRACE_RIGHT", 
			"BRACKET_LEFT", "BRACKET_RIGHT", "COLON", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", 
			"QUESTION", "STRING", "MULTI_LINE_COMMENT", "CODE_STRING", "QUOTE_CODE_STRING", 
			"ESC", "UNICODE", "HEX", "SAFECODEPOINT", "NUMBER", "INT", "EXP", "WS", 
			"ID", "LANGUAGE"
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


	public JsltLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "JsltLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2*\u0125\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\3\2\3\2\3\3\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3"+
		"\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n"+
		"\3\13\3\13\3\13\3\13\3\f\3\f\3\r\3\r\3\r\3\16\3\16\3\17\3\17\3\17\3\20"+
		"\3\20\3\21\3\21\3\21\3\22\3\22\3\22\3\22\3\23\3\23\3\23\3\24\3\24\3\24"+
		"\3\24\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26\3\26\3\26\3\26\3\27\3\27"+
		"\3\27\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\35"+
		"\3\35\3\36\3\36\3\37\3\37\3 \3 \3!\3!\3!\7!\u00c0\n!\f!\16!\u00c3\13!"+
		"\3!\3!\3\"\3\"\3\"\3\"\7\"\u00cb\n\"\f\"\16\"\u00ce\13\"\3\"\3\"\3\"\3"+
		"#\3#\3#\3#\7#\u00d7\n#\f#\16#\u00da\13#\3#\3#\3$\3$\3$\3$\3%\3%\3%\5%"+
		"\u00e5\n%\3&\3&\3&\3&\3&\3&\3\'\3\'\3(\3(\3)\5)\u00f2\n)\3)\3)\3)\6)\u00f7"+
		"\n)\r)\16)\u00f8\5)\u00fb\n)\3)\5)\u00fe\n)\3*\3*\3*\7*\u0103\n*\f*\16"+
		"*\u0106\13*\5*\u0108\n*\3+\3+\5+\u010c\n+\3+\3+\3,\6,\u0111\n,\r,\16,"+
		"\u0112\3,\3,\3-\3-\7-\u0119\n-\f-\16-\u011c\13-\3.\3.\3.\7.\u0121\n.\f"+
		".\16.\u0124\13.\4\u00cc\u00d8\2/\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23"+
		"\13\25\f\27\r\31\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31"+
		"\61\32\63\33\65\34\67\359\36;\37= ?!A\"C#E$G%I\2K\2M\2O\2Q&S\'U\2W(Y)"+
		"[*\3\2\f\n\2$$\61\61^^ddhhppttvv\5\2\62;CHch\5\2\2!$$^^\3\2\62;\3\2\63"+
		";\4\2GGgg\4\2--//\5\2\13\f\17\17\"\"\5\2C\\aac|\6\2\62;C\\aac|\2\u012e"+
		"\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2"+
		"\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2"+
		"\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2"+
		"\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2"+
		"\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3"+
		"\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2"+
		"\2\2Q\3\2\2\2\2S\3\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3\2\2\2\3]\3\2\2\2\5"+
		"_\3\2\2\2\7b\3\2\2\2\td\3\2\2\2\13f\3\2\2\2\rh\3\2\2\2\17j\3\2\2\2\21"+
		"n\3\2\2\2\23s\3\2\2\2\25|\3\2\2\2\27\u0080\3\2\2\2\31\u0082\3\2\2\2\33"+
		"\u0085\3\2\2\2\35\u0087\3\2\2\2\37\u008a\3\2\2\2!\u008c\3\2\2\2#\u008f"+
		"\3\2\2\2%\u0093\3\2\2\2\'\u0096\3\2\2\2)\u009a\3\2\2\2+\u009f\3\2\2\2"+
		"-\u00a5\3\2\2\2/\u00aa\3\2\2\2\61\u00ac\3\2\2\2\63\u00ae\3\2\2\2\65\u00b0"+
		"\3\2\2\2\67\u00b2\3\2\2\29\u00b4\3\2\2\2;\u00b6\3\2\2\2=\u00b8\3\2\2\2"+
		"?\u00ba\3\2\2\2A\u00bc\3\2\2\2C\u00c6\3\2\2\2E\u00d2\3\2\2\2G\u00dd\3"+
		"\2\2\2I\u00e1\3\2\2\2K\u00e6\3\2\2\2M\u00ec\3\2\2\2O\u00ee\3\2\2\2Q\u00f1"+
		"\3\2\2\2S\u0107\3\2\2\2U\u0109\3\2\2\2W\u0110\3\2\2\2Y\u0116\3\2\2\2["+
		"\u011d\3\2\2\2]^\7B\2\2^\4\3\2\2\2_`\7\60\2\2`a\7\60\2\2a\6\3\2\2\2bc"+
		"\7&\2\2c\b\3\2\2\2de\7\60\2\2e\n\3\2\2\2fg\7,\2\2g\f\3\2\2\2hi\7~\2\2"+
		"i\16\3\2\2\2jk\7w\2\2kl\7t\2\2lm\7k\2\2m\20\3\2\2\2no\7v\2\2op\7k\2\2"+
		"pq\7o\2\2qr\7g\2\2r\22\3\2\2\2st\7f\2\2tu\7c\2\2uv\7v\2\2vw\7g\2\2wx\7"+
		"v\2\2xy\7k\2\2yz\7o\2\2z{\7g\2\2{\24\3\2\2\2|}\7c\2\2}~\7p\2\2~\177\7"+
		"f\2\2\177\26\3\2\2\2\u0080\u0081\7?\2\2\u0081\30\3\2\2\2\u0082\u0083\7"+
		"@\2\2\u0083\u0084\7?\2\2\u0084\32\3\2\2\2\u0085\u0086\7@\2\2\u0086\34"+
		"\3\2\2\2\u0087\u0088\7>\2\2\u0088\u0089\7?\2\2\u0089\36\3\2\2\2\u008a"+
		"\u008b\7>\2\2\u008b \3\2\2\2\u008c\u008d\7#\2\2\u008d\u008e\7?\2\2\u008e"+
		"\"\3\2\2\2\u008f\u0090\7p\2\2\u0090\u0091\7q\2\2\u0091\u0092\7v\2\2\u0092"+
		"$\3\2\2\2\u0093\u0094\7q\2\2\u0094\u0095\7t\2\2\u0095&\3\2\2\2\u0096\u0097"+
		"\7p\2\2\u0097\u0098\7g\2\2\u0098\u0099\7y\2\2\u0099(\3\2\2\2\u009a\u009b"+
		"\7v\2\2\u009b\u009c\7t\2\2\u009c\u009d\7w\2\2\u009d\u009e\7g\2\2\u009e"+
		"*\3\2\2\2\u009f\u00a0\7h\2\2\u00a0\u00a1\7c\2\2\u00a1\u00a2\7n\2\2\u00a2"+
		"\u00a3\7u\2\2\u00a3\u00a4\7g\2\2\u00a4,\3\2\2\2\u00a5\u00a6\7p\2\2\u00a6"+
		"\u00a7\7w\2\2\u00a7\u00a8\7n\2\2\u00a8\u00a9\7n\2\2\u00a9.\3\2\2\2\u00aa"+
		"\u00ab\7}\2\2\u00ab\60\3\2\2\2\u00ac\u00ad\7\177\2\2\u00ad\62\3\2\2\2"+
		"\u00ae\u00af\7]\2\2\u00af\64\3\2\2\2\u00b0\u00b1\7_\2\2\u00b1\66\3\2\2"+
		"\2\u00b2\u00b3\7<\2\2\u00b38\3\2\2\2\u00b4\u00b5\7.\2\2\u00b5:\3\2\2\2"+
		"\u00b6\u00b7\7*\2\2\u00b7<\3\2\2\2\u00b8\u00b9\7+\2\2\u00b9>\3\2\2\2\u00ba"+
		"\u00bb\7A\2\2\u00bb@\3\2\2\2\u00bc\u00c1\7$\2\2\u00bd\u00c0\5I%\2\u00be"+
		"\u00c0\5O(\2\u00bf\u00bd\3\2\2\2\u00bf\u00be\3\2\2\2\u00c0\u00c3\3\2\2"+
		"\2\u00c1\u00bf\3\2\2\2\u00c1\u00c2\3\2\2\2\u00c2\u00c4\3\2\2\2\u00c3\u00c1"+
		"\3\2\2\2\u00c4\u00c5\7$\2\2\u00c5B\3\2\2\2\u00c6\u00c7\7\61\2\2\u00c7"+
		"\u00c8\7,\2\2\u00c8\u00cc\3\2\2\2\u00c9\u00cb\13\2\2\2\u00ca\u00c9\3\2"+
		"\2\2\u00cb\u00ce\3\2\2\2\u00cc\u00cd\3\2\2\2\u00cc\u00ca\3\2\2\2\u00cd"+
		"\u00cf\3\2\2\2\u00ce\u00cc\3\2\2\2\u00cf\u00d0\7,\2\2\u00d0\u00d1\7\61"+
		"\2\2\u00d1D\3\2\2\2\u00d2\u00d3\5G$\2\u00d3\u00d4\5[.\2\u00d4\u00d8\5"+
		"W,\2\u00d5\u00d7\13\2\2\2\u00d6\u00d5\3\2\2\2\u00d7\u00da\3\2\2\2\u00d8"+
		"\u00d9\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d9\u00db\3\2\2\2\u00da\u00d8\3\2"+
		"\2\2\u00db\u00dc\5G$\2\u00dcF\3\2\2\2\u00dd\u00de\7)\2\2\u00de\u00df\7"+
		")\2\2\u00df\u00e0\7)\2\2\u00e0H\3\2\2\2\u00e1\u00e4\7^\2\2\u00e2\u00e5"+
		"\t\2\2\2\u00e3\u00e5\5K&\2\u00e4\u00e2\3\2\2\2\u00e4\u00e3\3\2\2\2\u00e5"+
		"J\3\2\2\2\u00e6\u00e7\7w\2\2\u00e7\u00e8\5M\'\2\u00e8\u00e9\5M\'\2\u00e9"+
		"\u00ea\5M\'\2\u00ea\u00eb\5M\'\2\u00ebL\3\2\2\2\u00ec\u00ed\t\3\2\2\u00ed"+
		"N\3\2\2\2\u00ee\u00ef\n\4\2\2\u00efP\3\2\2\2\u00f0\u00f2\7/\2\2\u00f1"+
		"\u00f0\3\2\2\2\u00f1\u00f2\3\2\2\2\u00f2\u00f3\3\2\2\2\u00f3\u00fa\5S"+
		"*\2\u00f4\u00f6\7\60\2\2\u00f5\u00f7\t\5\2\2\u00f6\u00f5\3\2\2\2\u00f7"+
		"\u00f8\3\2\2\2\u00f8\u00f6\3\2\2\2\u00f8\u00f9\3\2\2\2\u00f9\u00fb\3\2"+
		"\2\2\u00fa\u00f4\3\2\2\2\u00fa\u00fb\3\2\2\2\u00fb\u00fd\3\2\2\2\u00fc"+
		"\u00fe\5U+\2\u00fd\u00fc\3\2\2\2\u00fd\u00fe\3\2\2\2\u00feR\3\2\2\2\u00ff"+
		"\u0108\7\62\2\2\u0100\u0104\t\6\2\2\u0101\u0103\t\5\2\2\u0102\u0101\3"+
		"\2\2\2\u0103\u0106\3\2\2\2\u0104\u0102\3\2\2\2\u0104\u0105\3\2\2\2\u0105"+
		"\u0108\3\2\2\2\u0106\u0104\3\2\2\2\u0107\u00ff\3\2\2\2\u0107\u0100\3\2"+
		"\2\2\u0108T\3\2\2\2\u0109\u010b\t\7\2\2\u010a\u010c\t\b\2\2\u010b\u010a"+
		"\3\2\2\2\u010b\u010c\3\2\2\2\u010c\u010d\3\2\2\2\u010d\u010e\5S*\2\u010e"+
		"V\3\2\2\2\u010f\u0111\t\t\2\2\u0110\u010f\3\2\2\2\u0111\u0112\3\2\2\2"+
		"\u0112\u0110\3\2\2\2\u0112\u0113\3\2\2\2\u0113\u0114\3\2\2\2\u0114\u0115"+
		"\b,\2\2\u0115X\3\2\2\2\u0116\u011a\t\n\2\2\u0117\u0119\t\13\2\2\u0118"+
		"\u0117\3\2\2\2\u0119\u011c\3\2\2\2\u011a\u0118\3\2\2\2\u011a\u011b\3\2"+
		"\2\2\u011bZ\3\2\2\2\u011c\u011a\3\2\2\2\u011d\u011e\5\t\5\2\u011e\u0122"+
		"\t\n\2\2\u011f\u0121\t\13\2\2\u0120\u011f\3\2\2\2\u0121\u0124\3\2\2\2"+
		"\u0122\u0120\3\2\2\2\u0122\u0123\3\2\2\2\u0123\\\3\2\2\2\u0124\u0122\3"+
		"\2\2\2\22\2\u00bf\u00c1\u00cc\u00d8\u00e4\u00f1\u00f8\u00fa\u00fd\u0104"+
		"\u0107\u010b\u0112\u011a\u0122\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}