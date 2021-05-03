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
		PIPE=6, AND=7, EQ=8, GE=9, GT=10, LE=11, LT=12, NE=13, NOT=14, OR=15, 
		NEW=16, TRUE=17, FALSE=18, NULL=19, BRACE_LEFT=20, BRACE_RIGHT=21, BRACKET_LEFT=22, 
		BRACKET_RIGHT=23, COLON=24, COMMA=25, PAREN_LEFT=26, PAREN_RIGHT=27, QUESTION=28, 
		STRING=29, NUMBER=30, INT=31, WS=32, ID=33;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"CURRENT_VALUE", "RECURSIVE_DESCENT", "ROOT_VALUE", "SUBSCRIPT", "WILDCARD_SUBSCRIPT", 
			"PIPE", "AND", "EQ", "GE", "GT", "LE", "LT", "NE", "NOT", "OR", "NEW", 
			"TRUE", "FALSE", "NULL", "BRACE_LEFT", "BRACE_RIGHT", "BRACKET_LEFT", 
			"BRACKET_RIGHT", "COLON", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", "QUESTION", 
			"STRING", "ESC", "UNICODE", "HEX", "SAFECODEPOINT", "NUMBER", "INT", 
			"EXP", "WS", "ID"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2#\u00e2\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\3\2\3\2\3\3\3\3\3\3\3\4\3"+
		"\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\b\3\b\3\t\3\t\3\n\3\n\3\n\3\13\3"+
		"\13\3\f\3\f\3\f\3\r\3\r\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\20\3\20\3"+
		"\20\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22\3\22\3\23\3\23\3\23\3\23\3"+
		"\23\3\23\3\24\3\24\3\24\3\24\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3"+
		"\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3\36\7"+
		"\36\u00a0\n\36\f\36\16\36\u00a3\13\36\3\36\3\36\3\37\3\37\3\37\5\37\u00aa"+
		"\n\37\3 \3 \3 \3 \3 \3 \3!\3!\3\"\3\"\3#\5#\u00b7\n#\3#\3#\3#\6#\u00bc"+
		"\n#\r#\16#\u00bd\5#\u00c0\n#\3#\5#\u00c3\n#\3$\3$\3$\7$\u00c8\n$\f$\16"+
		"$\u00cb\13$\5$\u00cd\n$\3%\3%\5%\u00d1\n%\3%\3%\3&\6&\u00d6\n&\r&\16&"+
		"\u00d7\3&\3&\3\'\3\'\7\'\u00de\n\'\f\'\16\'\u00e1\13\'\2\2(\3\3\5\4\7"+
		"\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21!\22"+
		"#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36;\37=\2?\2A\2"+
		"C\2E G!I\2K\"M#\3\2\f\n\2$$\61\61^^ddhhppttvv\5\2\62;CHch\5\2\2!$$^^\3"+
		"\2\62;\3\2\63;\4\2GGgg\4\2--//\5\2\13\f\17\17\"\"\5\2C\\aac|\6\2\62;C"+
		"\\aac|\2\u00e8\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3"+
		"\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2"+
		"\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3"+
		"\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2"+
		"\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\2"+
		"9\3\2\2\2\2;\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\3O\3"+
		"\2\2\2\5Q\3\2\2\2\7T\3\2\2\2\tV\3\2\2\2\13X\3\2\2\2\rZ\3\2\2\2\17\\\3"+
		"\2\2\2\21`\3\2\2\2\23b\3\2\2\2\25e\3\2\2\2\27g\3\2\2\2\31j\3\2\2\2\33"+
		"l\3\2\2\2\35o\3\2\2\2\37s\3\2\2\2!v\3\2\2\2#z\3\2\2\2%\177\3\2\2\2\'\u0085"+
		"\3\2\2\2)\u008a\3\2\2\2+\u008c\3\2\2\2-\u008e\3\2\2\2/\u0090\3\2\2\2\61"+
		"\u0092\3\2\2\2\63\u0094\3\2\2\2\65\u0096\3\2\2\2\67\u0098\3\2\2\29\u009a"+
		"\3\2\2\2;\u009c\3\2\2\2=\u00a6\3\2\2\2?\u00ab\3\2\2\2A\u00b1\3\2\2\2C"+
		"\u00b3\3\2\2\2E\u00b6\3\2\2\2G\u00cc\3\2\2\2I\u00ce\3\2\2\2K\u00d5\3\2"+
		"\2\2M\u00db\3\2\2\2OP\7B\2\2P\4\3\2\2\2QR\7\60\2\2RS\7\60\2\2S\6\3\2\2"+
		"\2TU\7&\2\2U\b\3\2\2\2VW\7\60\2\2W\n\3\2\2\2XY\7,\2\2Y\f\3\2\2\2Z[\7~"+
		"\2\2[\16\3\2\2\2\\]\7c\2\2]^\7p\2\2^_\7f\2\2_\20\3\2\2\2`a\7?\2\2a\22"+
		"\3\2\2\2bc\7@\2\2cd\7?\2\2d\24\3\2\2\2ef\7@\2\2f\26\3\2\2\2gh\7>\2\2h"+
		"i\7?\2\2i\30\3\2\2\2jk\7>\2\2k\32\3\2\2\2lm\7#\2\2mn\7?\2\2n\34\3\2\2"+
		"\2op\7p\2\2pq\7q\2\2qr\7v\2\2r\36\3\2\2\2st\7q\2\2tu\7t\2\2u \3\2\2\2"+
		"vw\7p\2\2wx\7g\2\2xy\7y\2\2y\"\3\2\2\2z{\7v\2\2{|\7t\2\2|}\7w\2\2}~\7"+
		"g\2\2~$\3\2\2\2\177\u0080\7h\2\2\u0080\u0081\7c\2\2\u0081\u0082\7n\2\2"+
		"\u0082\u0083\7u\2\2\u0083\u0084\7g\2\2\u0084&\3\2\2\2\u0085\u0086\7p\2"+
		"\2\u0086\u0087\7w\2\2\u0087\u0088\7n\2\2\u0088\u0089\7n\2\2\u0089(\3\2"+
		"\2\2\u008a\u008b\7}\2\2\u008b*\3\2\2\2\u008c\u008d\7\177\2\2\u008d,\3"+
		"\2\2\2\u008e\u008f\7]\2\2\u008f.\3\2\2\2\u0090\u0091\7_\2\2\u0091\60\3"+
		"\2\2\2\u0092\u0093\7<\2\2\u0093\62\3\2\2\2\u0094\u0095\7.\2\2\u0095\64"+
		"\3\2\2\2\u0096\u0097\7*\2\2\u0097\66\3\2\2\2\u0098\u0099\7+\2\2\u0099"+
		"8\3\2\2\2\u009a\u009b\7A\2\2\u009b:\3\2\2\2\u009c\u00a1\7$\2\2\u009d\u00a0"+
		"\5=\37\2\u009e\u00a0\5C\"\2\u009f\u009d\3\2\2\2\u009f\u009e\3\2\2\2\u00a0"+
		"\u00a3\3\2\2\2\u00a1\u009f\3\2\2\2\u00a1\u00a2\3\2\2\2\u00a2\u00a4\3\2"+
		"\2\2\u00a3\u00a1\3\2\2\2\u00a4\u00a5\7$\2\2\u00a5<\3\2\2\2\u00a6\u00a9"+
		"\7^\2\2\u00a7\u00aa\t\2\2\2\u00a8\u00aa\5? \2\u00a9\u00a7\3\2\2\2\u00a9"+
		"\u00a8\3\2\2\2\u00aa>\3\2\2\2\u00ab\u00ac\7w\2\2\u00ac\u00ad\5A!\2\u00ad"+
		"\u00ae\5A!\2\u00ae\u00af\5A!\2\u00af\u00b0\5A!\2\u00b0@\3\2\2\2\u00b1"+
		"\u00b2\t\3\2\2\u00b2B\3\2\2\2\u00b3\u00b4\n\4\2\2\u00b4D\3\2\2\2\u00b5"+
		"\u00b7\7/\2\2\u00b6\u00b5\3\2\2\2\u00b6\u00b7\3\2\2\2\u00b7\u00b8\3\2"+
		"\2\2\u00b8\u00bf\5G$\2\u00b9\u00bb\7\60\2\2\u00ba\u00bc\t\5\2\2\u00bb"+
		"\u00ba\3\2\2\2\u00bc\u00bd\3\2\2\2\u00bd\u00bb\3\2\2\2\u00bd\u00be\3\2"+
		"\2\2\u00be\u00c0\3\2\2\2\u00bf\u00b9\3\2\2\2\u00bf\u00c0\3\2\2\2\u00c0"+
		"\u00c2\3\2\2\2\u00c1\u00c3\5I%\2\u00c2\u00c1\3\2\2\2\u00c2\u00c3\3\2\2"+
		"\2\u00c3F\3\2\2\2\u00c4\u00cd\7\62\2\2\u00c5\u00c9\t\6\2\2\u00c6\u00c8"+
		"\t\5\2\2\u00c7\u00c6\3\2\2\2\u00c8\u00cb\3\2\2\2\u00c9\u00c7\3\2\2\2\u00c9"+
		"\u00ca\3\2\2\2\u00ca\u00cd\3\2\2\2\u00cb\u00c9\3\2\2\2\u00cc\u00c4\3\2"+
		"\2\2\u00cc\u00c5\3\2\2\2\u00cdH\3\2\2\2\u00ce\u00d0\t\7\2\2\u00cf\u00d1"+
		"\t\b\2\2\u00d0\u00cf\3\2\2\2\u00d0\u00d1\3\2\2\2\u00d1\u00d2\3\2\2\2\u00d2"+
		"\u00d3\5G$\2\u00d3J\3\2\2\2\u00d4\u00d6\t\t\2\2\u00d5\u00d4\3\2\2\2\u00d6"+
		"\u00d7\3\2\2\2\u00d7\u00d5\3\2\2\2\u00d7\u00d8\3\2\2\2\u00d8\u00d9\3\2"+
		"\2\2\u00d9\u00da\b&\2\2\u00daL\3\2\2\2\u00db\u00df\t\n\2\2\u00dc\u00de"+
		"\t\13\2\2\u00dd\u00dc\3\2\2\2\u00de\u00e1\3\2\2\2\u00df\u00dd\3\2\2\2"+
		"\u00df\u00e0\3\2\2\2\u00e0N\3\2\2\2\u00e1\u00df\3\2\2\2\17\2\u009f\u00a1"+
		"\u00a9\u00b6\u00bd\u00bf\u00c2\u00c9\u00cc\u00d0\u00d7\u00df\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}