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
		SUBSCRIPT=1, WILDCARD_SUBSCRIPT=2, CURRENT_VALUE=3, COLON=4, URI=5, TIME=6, 
		DATETIME=7, WHEN=8, CASE=9, DEFAULT=10, EQ=11, NE=12, GT=13, LT=14, LE=15, 
		GE=16, NT=17, PLUS=18, MINUS=19, DIVID=20, MODULO=21, POWER=22, AND=23, 
		OR=24, AND_EXCLUSIVE=25, OR_EXCLUSIVE=26, CHAIN=27, TRUE=28, FALSE=29, 
		NULL=30, BRACE_LEFT=31, BRACE_RIGHT=32, BRACKET_LEFT=33, BRACKET_RIGHT=34, 
		COMMA=35, PAREN_LEFT=36, PAREN_RIGHT=37, STRING=38, MULTI_LINE_COMMENT=39, 
		CODE_STRING=40, QUOTE_CODE_STRING=41, NUMBER=42, INT=43, WS=44, ID=45;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"SUBSCRIPT", "WILDCARD_SUBSCRIPT", "CURRENT_VALUE", "COLON", "URI", "TIME", 
			"DATETIME", "WHEN", "CASE", "DEFAULT", "EQ", "NE", "GT", "LT", "LE", 
			"GE", "NT", "PLUS", "MINUS", "DIVID", "MODULO", "POWER", "AND", "OR", 
			"AND_EXCLUSIVE", "OR_EXCLUSIVE", "CHAIN", "TRUE", "FALSE", "NULL", "BRACE_LEFT", 
			"BRACE_RIGHT", "BRACKET_LEFT", "BRACKET_RIGHT", "COMMA", "PAREN_LEFT", 
			"PAREN_RIGHT", "STRING", "MULTI_LINE_COMMENT", "CODE_STRING", "QUOTE_CODE_STRING", 
			"ESC", "UNICODE", "HEX", "SAFECODEPOINT", "NUMBER", "INT", "EXP", "WS", 
			"ID", "DOT_ID", "LANGUAGE"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "'*'", "'@'", "':'", "'uri'", "'time'", "'datetime'", "'when'", 
			"'case'", "'default'", "'=='", "'!='", "'>'", "'<'", "'<='", "'>='", 
			"'!'", "'+'", "'-'", "'/'", "'%'", "'^'", "'&'", "'|'", "'&&'", "'||'", 
			"'->'", "'true'", "'false'", "'null'", "'{'", "'}'", "'['", "']'", "','", 
			"'('", "')'", null, null, null, "'''''"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SUBSCRIPT", "WILDCARD_SUBSCRIPT", "CURRENT_VALUE", "COLON", "URI", 
			"TIME", "DATETIME", "WHEN", "CASE", "DEFAULT", "EQ", "NE", "GT", "LT", 
			"LE", "GE", "NT", "PLUS", "MINUS", "DIVID", "MODULO", "POWER", "AND", 
			"OR", "AND_EXCLUSIVE", "OR_EXCLUSIVE", "CHAIN", "TRUE", "FALSE", "NULL", 
			"BRACE_LEFT", "BRACE_RIGHT", "BRACKET_LEFT", "BRACKET_RIGHT", "COMMA", 
			"PAREN_LEFT", "PAREN_RIGHT", "STRING", "MULTI_LINE_COMMENT", "CODE_STRING", 
			"QUOTE_CODE_STRING", "NUMBER", "INT", "WS", "ID"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2/\u014f\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\6\3\6\3\7\3\7"+
		"\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3"+
		"\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f"+
		"\3\r\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3\20\3\21\3\21\3\21\3\22\3"+
		"\22\3\23\3\23\3\24\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3"+
		"\31\3\32\3\32\3\32\3\33\3\33\3\33\3\34\3\34\3\34\3\35\3\35\3\35\3\35\3"+
		"\35\3\36\3\36\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3\37\3\37\3 \3 \3!\3"+
		"!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3\'\7\'\u00e2\n\'\f\'\16\'\u00e5"+
		"\13\'\3\'\3\'\3(\3(\3(\3(\7(\u00ed\n(\f(\16(\u00f0\13(\3(\3(\3(\3)\3)"+
		"\3)\3)\7)\u00f9\n)\f)\16)\u00fc\13)\3)\3)\3*\3*\3*\3*\3+\3+\3+\5+\u0107"+
		"\n+\3,\3,\3,\3,\3,\3,\3-\3-\3.\3.\3/\5/\u0114\n/\3/\3/\3/\6/\u0119\n/"+
		"\r/\16/\u011a\5/\u011d\n/\3/\5/\u0120\n/\3\60\3\60\3\60\7\60\u0125\n\60"+
		"\f\60\16\60\u0128\13\60\5\60\u012a\n\60\3\61\3\61\5\61\u012e\n\61\3\61"+
		"\3\61\3\62\6\62\u0133\n\62\r\62\16\62\u0134\3\62\3\62\3\63\3\63\7\63\u013b"+
		"\n\63\f\63\16\63\u013e\13\63\3\64\3\64\3\64\7\64\u0143\n\64\f\64\16\64"+
		"\u0146\13\64\3\65\3\65\3\65\7\65\u014b\n\65\f\65\16\65\u014e\13\65\4\u00ee"+
		"\u00fa\2\66\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33"+
		"\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67"+
		"\359\36;\37= ?!A\"C#E$G%I&K\'M(O)Q*S+U\2W\2Y\2[\2],_-a\2c.e/g\2i\2\3\2"+
		"\f\n\2$$\61\61^^ddhhppttvv\5\2\62;CHch\5\2\2!$$^^\3\2\62;\3\2\63;\4\2"+
		"GGgg\4\2--//\5\2\13\f\17\17\"\"\5\2C\\aac|\6\2\62;C\\aac|\2\u0157\2\3"+
		"\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2"+
		"\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31"+
		"\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2"+
		"\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2"+
		"\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2"+
		"\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2"+
		"I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2]\3"+
		"\2\2\2\2_\3\2\2\2\2c\3\2\2\2\2e\3\2\2\2\3k\3\2\2\2\5m\3\2\2\2\7o\3\2\2"+
		"\2\tq\3\2\2\2\13s\3\2\2\2\rw\3\2\2\2\17|\3\2\2\2\21\u0085\3\2\2\2\23\u008a"+
		"\3\2\2\2\25\u008f\3\2\2\2\27\u0097\3\2\2\2\31\u009a\3\2\2\2\33\u009d\3"+
		"\2\2\2\35\u009f\3\2\2\2\37\u00a1\3\2\2\2!\u00a4\3\2\2\2#\u00a7\3\2\2\2"+
		"%\u00a9\3\2\2\2\'\u00ab\3\2\2\2)\u00ad\3\2\2\2+\u00af\3\2\2\2-\u00b1\3"+
		"\2\2\2/\u00b3\3\2\2\2\61\u00b5\3\2\2\2\63\u00b7\3\2\2\2\65\u00ba\3\2\2"+
		"\2\67\u00bd\3\2\2\29\u00c0\3\2\2\2;\u00c5\3\2\2\2=\u00cb\3\2\2\2?\u00d0"+
		"\3\2\2\2A\u00d2\3\2\2\2C\u00d4\3\2\2\2E\u00d6\3\2\2\2G\u00d8\3\2\2\2I"+
		"\u00da\3\2\2\2K\u00dc\3\2\2\2M\u00de\3\2\2\2O\u00e8\3\2\2\2Q\u00f4\3\2"+
		"\2\2S\u00ff\3\2\2\2U\u0103\3\2\2\2W\u0108\3\2\2\2Y\u010e\3\2\2\2[\u0110"+
		"\3\2\2\2]\u0113\3\2\2\2_\u0129\3\2\2\2a\u012b\3\2\2\2c\u0132\3\2\2\2e"+
		"\u0138\3\2\2\2g\u013f\3\2\2\2i\u0147\3\2\2\2kl\7\60\2\2l\4\3\2\2\2mn\7"+
		",\2\2n\6\3\2\2\2op\7B\2\2p\b\3\2\2\2qr\7<\2\2r\n\3\2\2\2st\7w\2\2tu\7"+
		"t\2\2uv\7k\2\2v\f\3\2\2\2wx\7v\2\2xy\7k\2\2yz\7o\2\2z{\7g\2\2{\16\3\2"+
		"\2\2|}\7f\2\2}~\7c\2\2~\177\7v\2\2\177\u0080\7g\2\2\u0080\u0081\7v\2\2"+
		"\u0081\u0082\7k\2\2\u0082\u0083\7o\2\2\u0083\u0084\7g\2\2\u0084\20\3\2"+
		"\2\2\u0085\u0086\7y\2\2\u0086\u0087\7j\2\2\u0087\u0088\7g\2\2\u0088\u0089"+
		"\7p\2\2\u0089\22\3\2\2\2\u008a\u008b\7e\2\2\u008b\u008c\7c\2\2\u008c\u008d"+
		"\7u\2\2\u008d\u008e\7g\2\2\u008e\24\3\2\2\2\u008f\u0090\7f\2\2\u0090\u0091"+
		"\7g\2\2\u0091\u0092\7h\2\2\u0092\u0093\7c\2\2\u0093\u0094\7w\2\2\u0094"+
		"\u0095\7n\2\2\u0095\u0096\7v\2\2\u0096\26\3\2\2\2\u0097\u0098\7?\2\2\u0098"+
		"\u0099\7?\2\2\u0099\30\3\2\2\2\u009a\u009b\7#\2\2\u009b\u009c\7?\2\2\u009c"+
		"\32\3\2\2\2\u009d\u009e\7@\2\2\u009e\34\3\2\2\2\u009f\u00a0\7>\2\2\u00a0"+
		"\36\3\2\2\2\u00a1\u00a2\7>\2\2\u00a2\u00a3\7?\2\2\u00a3 \3\2\2\2\u00a4"+
		"\u00a5\7@\2\2\u00a5\u00a6\7?\2\2\u00a6\"\3\2\2\2\u00a7\u00a8\7#\2\2\u00a8"+
		"$\3\2\2\2\u00a9\u00aa\7-\2\2\u00aa&\3\2\2\2\u00ab\u00ac\7/\2\2\u00ac("+
		"\3\2\2\2\u00ad\u00ae\7\61\2\2\u00ae*\3\2\2\2\u00af\u00b0\7\'\2\2\u00b0"+
		",\3\2\2\2\u00b1\u00b2\7`\2\2\u00b2.\3\2\2\2\u00b3\u00b4\7(\2\2\u00b4\60"+
		"\3\2\2\2\u00b5\u00b6\7~\2\2\u00b6\62\3\2\2\2\u00b7\u00b8\7(\2\2\u00b8"+
		"\u00b9\7(\2\2\u00b9\64\3\2\2\2\u00ba\u00bb\7~\2\2\u00bb\u00bc\7~\2\2\u00bc"+
		"\66\3\2\2\2\u00bd\u00be\7/\2\2\u00be\u00bf\7@\2\2\u00bf8\3\2\2\2\u00c0"+
		"\u00c1\7v\2\2\u00c1\u00c2\7t\2\2\u00c2\u00c3\7w\2\2\u00c3\u00c4\7g\2\2"+
		"\u00c4:\3\2\2\2\u00c5\u00c6\7h\2\2\u00c6\u00c7\7c\2\2\u00c7\u00c8\7n\2"+
		"\2\u00c8\u00c9\7u\2\2\u00c9\u00ca\7g\2\2\u00ca<\3\2\2\2\u00cb\u00cc\7"+
		"p\2\2\u00cc\u00cd\7w\2\2\u00cd\u00ce\7n\2\2\u00ce\u00cf\7n\2\2\u00cf>"+
		"\3\2\2\2\u00d0\u00d1\7}\2\2\u00d1@\3\2\2\2\u00d2\u00d3\7\177\2\2\u00d3"+
		"B\3\2\2\2\u00d4\u00d5\7]\2\2\u00d5D\3\2\2\2\u00d6\u00d7\7_\2\2\u00d7F"+
		"\3\2\2\2\u00d8\u00d9\7.\2\2\u00d9H\3\2\2\2\u00da\u00db\7*\2\2\u00dbJ\3"+
		"\2\2\2\u00dc\u00dd\7+\2\2\u00ddL\3\2\2\2\u00de\u00e3\7$\2\2\u00df\u00e2"+
		"\5U+\2\u00e0\u00e2\5[.\2\u00e1\u00df\3\2\2\2\u00e1\u00e0\3\2\2\2\u00e2"+
		"\u00e5\3\2\2\2\u00e3\u00e1\3\2\2\2\u00e3\u00e4\3\2\2\2\u00e4\u00e6\3\2"+
		"\2\2\u00e5\u00e3\3\2\2\2\u00e6\u00e7\7$\2\2\u00e7N\3\2\2\2\u00e8\u00e9"+
		"\7\61\2\2\u00e9\u00ea\7,\2\2\u00ea\u00ee\3\2\2\2\u00eb\u00ed\13\2\2\2"+
		"\u00ec\u00eb\3\2\2\2\u00ed\u00f0\3\2\2\2\u00ee\u00ef\3\2\2\2\u00ee\u00ec"+
		"\3\2\2\2\u00ef\u00f1\3\2\2\2\u00f0\u00ee\3\2\2\2\u00f1\u00f2\7,\2\2\u00f2"+
		"\u00f3\7\61\2\2\u00f3P\3\2\2\2\u00f4\u00f5\5S*\2\u00f5\u00f6\5i\65\2\u00f6"+
		"\u00fa\5c\62\2\u00f7\u00f9\13\2\2\2\u00f8\u00f7\3\2\2\2\u00f9\u00fc\3"+
		"\2\2\2\u00fa\u00fb\3\2\2\2\u00fa\u00f8\3\2\2\2\u00fb\u00fd\3\2\2\2\u00fc"+
		"\u00fa\3\2\2\2\u00fd\u00fe\5S*\2\u00feR\3\2\2\2\u00ff\u0100\7)\2\2\u0100"+
		"\u0101\7)\2\2\u0101\u0102\7)\2\2\u0102T\3\2\2\2\u0103\u0106\7^\2\2\u0104"+
		"\u0107\t\2\2\2\u0105\u0107\5W,\2\u0106\u0104\3\2\2\2\u0106\u0105\3\2\2"+
		"\2\u0107V\3\2\2\2\u0108\u0109\7w\2\2\u0109\u010a\5Y-\2\u010a\u010b\5Y"+
		"-\2\u010b\u010c\5Y-\2\u010c\u010d\5Y-\2\u010dX\3\2\2\2\u010e\u010f\t\3"+
		"\2\2\u010fZ\3\2\2\2\u0110\u0111\n\4\2\2\u0111\\\3\2\2\2\u0112\u0114\7"+
		"/\2\2\u0113\u0112\3\2\2\2\u0113\u0114\3\2\2\2\u0114\u0115\3\2\2\2\u0115"+
		"\u011c\5_\60\2\u0116\u0118\7\60\2\2\u0117\u0119\t\5\2\2\u0118\u0117\3"+
		"\2\2\2\u0119\u011a\3\2\2\2\u011a\u0118\3\2\2\2\u011a\u011b\3\2\2\2\u011b"+
		"\u011d\3\2\2\2\u011c\u0116\3\2\2\2\u011c\u011d\3\2\2\2\u011d\u011f\3\2"+
		"\2\2\u011e\u0120\5a\61\2\u011f\u011e\3\2\2\2\u011f\u0120\3\2\2\2\u0120"+
		"^\3\2\2\2\u0121\u012a\7\62\2\2\u0122\u0126\t\6\2\2\u0123\u0125\t\5\2\2"+
		"\u0124\u0123\3\2\2\2\u0125\u0128\3\2\2\2\u0126\u0124\3\2\2\2\u0126\u0127"+
		"\3\2\2\2\u0127\u012a\3\2\2\2\u0128\u0126\3\2\2\2\u0129\u0121\3\2\2\2\u0129"+
		"\u0122\3\2\2\2\u012a`\3\2\2\2\u012b\u012d\t\7\2\2\u012c\u012e\t\b\2\2"+
		"\u012d\u012c\3\2\2\2\u012d\u012e\3\2\2\2\u012e\u012f\3\2\2\2\u012f\u0130"+
		"\5_\60\2\u0130b\3\2\2\2\u0131\u0133\t\t\2\2\u0132\u0131\3\2\2\2\u0133"+
		"\u0134\3\2\2\2\u0134\u0132\3\2\2\2\u0134\u0135\3\2\2\2\u0135\u0136\3\2"+
		"\2\2\u0136\u0137\b\62\2\2\u0137d\3\2\2\2\u0138\u013c\t\n\2\2\u0139\u013b"+
		"\t\13\2\2\u013a\u0139\3\2\2\2\u013b\u013e\3\2\2\2\u013c\u013a\3\2\2\2"+
		"\u013c\u013d\3\2\2\2\u013df\3\2\2\2\u013e\u013c\3\2\2\2\u013f\u0140\7"+
		"\60\2\2\u0140\u0144\t\n\2\2\u0141\u0143\t\13\2\2\u0142\u0141\3\2\2\2\u0143"+
		"\u0146\3\2\2\2\u0144\u0142\3\2\2\2\u0144\u0145\3\2\2\2\u0145h\3\2\2\2"+
		"\u0146\u0144\3\2\2\2\u0147\u0148\5\3\2\2\u0148\u014c\t\n\2\2\u0149\u014b"+
		"\t\13\2\2\u014a\u0149\3\2\2\2\u014b\u014e\3\2\2\2\u014c\u014a\3\2\2\2"+
		"\u014c\u014d\3\2\2\2\u014dj\3\2\2\2\u014e\u014c\3\2\2\2\23\2\u00e1\u00e3"+
		"\u00ee\u00fa\u0106\u0113\u011a\u011c\u011f\u0126\u0129\u012d\u0134\u013c"+
		"\u0144\u014c\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}