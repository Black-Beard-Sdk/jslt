// Generated from c:\_perso\Src\jslt\src\Black.Beard.Jslt\Json\Jslt\Parser\Grammar\JsltLexer.g4 by ANTLR 4.8
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
		DATETIME=7, STRING_=8, GUID=9, WHEN=10, CASE=11, DEFAULT=12, INTEGER=13, 
		DECIMAL=14, EQ=15, NE=16, GT=17, LT=18, LE=19, GE=20, NT=21, PLUS=22, 
		MINUS=23, DIVID=24, MODULO=25, POWER=26, AND=27, OR=28, AND_EXCLUSIVE=29, 
		OR_EXCLUSIVE=30, COALESCE=31, CHAIN=32, TRUE=33, FALSE=34, NULL=35, BRACE_LEFT=36, 
		BRACE_RIGHT=37, BRACKET_LEFT=38, BRACKET_RIGHT=39, COMMA=40, PAREN_LEFT=41, 
		PAREN_RIGHT=42, STRING=43, MULTI_LINE_COMMENT=44, NUMBER=45, INT=46, WS=47, 
		ID=48, DOT_ID=49;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"SUBSCRIPT", "WILDCARD_SUBSCRIPT", "CURRENT_VALUE", "COLON", "URI", "TIME", 
			"DATETIME", "STRING_", "GUID", "WHEN", "CASE", "DEFAULT", "INTEGER", 
			"DECIMAL", "EQ", "NE", "GT", "LT", "LE", "GE", "NT", "PLUS", "MINUS", 
			"DIVID", "MODULO", "POWER", "AND", "OR", "AND_EXCLUSIVE", "OR_EXCLUSIVE", 
			"COALESCE", "CHAIN", "TRUE", "FALSE", "NULL", "BRACE_LEFT", "BRACE_RIGHT", 
			"BRACKET_LEFT", "BRACKET_RIGHT", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", 
			"STRING", "MULTI_LINE_COMMENT", "ESC", "UNICODE", "HEX", "SAFECODEPOINT", 
			"NUMBER", "INT", "EXP", "WS", "ID", "DOT_ID"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\63\u0161\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t"+
		" \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t"+
		"+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64"+
		"\t\64\4\65\t\65\4\66\t\66\4\67\t\67\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3"+
		"\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b"+
		"\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3"+
		"\13\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\16\3\16\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\20"+
		"\3\20\3\20\3\21\3\21\3\21\3\22\3\22\3\23\3\23\3\24\3\24\3\24\3\25\3\25"+
		"\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\34"+
		"\3\34\3\35\3\35\3\36\3\36\3\36\3\37\3\37\3\37\3 \3 \3 \3!\3!\3!\3\"\3"+
		"\"\3\"\3\"\3\"\3#\3#\3#\3#\3#\3#\3$\3$\3$\3$\3$\3%\3%\3&\3&\3\'\3\'\3"+
		"(\3(\3)\3)\3*\3*\3+\3+\3,\3,\3,\7,\u0105\n,\f,\16,\u0108\13,\3,\3,\3-"+
		"\3-\3-\3-\7-\u0110\n-\f-\16-\u0113\13-\3-\3-\3-\3-\3-\3.\3.\3.\5.\u011d"+
		"\n.\3/\3/\3/\3/\3/\3/\3\60\3\60\3\61\3\61\3\62\5\62\u012a\n\62\3\62\3"+
		"\62\3\62\6\62\u012f\n\62\r\62\16\62\u0130\5\62\u0133\n\62\3\62\5\62\u0136"+
		"\n\62\3\63\3\63\3\63\7\63\u013b\n\63\f\63\16\63\u013e\13\63\5\63\u0140"+
		"\n\63\3\64\3\64\5\64\u0144\n\64\3\64\3\64\3\65\6\65\u0149\n\65\r\65\16"+
		"\65\u014a\3\65\3\65\3\66\3\66\7\66\u0151\n\66\f\66\16\66\u0154\13\66\3"+
		"\67\3\67\6\67\u0158\n\67\r\67\16\67\u0159\3\67\7\67\u015d\n\67\f\67\16"+
		"\67\u0160\13\67\3\u0111\28\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25"+
		"\f\27\r\31\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32"+
		"\63\33\65\34\67\359\36;\37= ?!A\"C#E$G%I&K\'M(O)Q*S+U,W-Y.[\2]\2_\2a\2"+
		"c/e\60g\2i\61k\62m\63\3\2\f\n\2$$\61\61^^ddhhppttvv\5\2\62;CHch\5\2\2"+
		"!$$^^\3\2\62;\3\2\63;\4\2GGgg\4\2--//\5\2\13\f\17\17\"\"\5\2C\\aac|\6"+
		"\2\62;C\\aac|\2\u016a\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2"+
		"\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25"+
		"\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2"+
		"\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2"+
		"\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3"+
		"\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2"+
		"\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2"+
		"Q\3\2\2\2\2S\3\2\2\2\2U\3\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\2c\3\2\2\2\2e\3"+
		"\2\2\2\2i\3\2\2\2\2k\3\2\2\2\2m\3\2\2\2\3o\3\2\2\2\5q\3\2\2\2\7s\3\2\2"+
		"\2\tu\3\2\2\2\13w\3\2\2\2\r{\3\2\2\2\17\u0080\3\2\2\2\21\u0089\3\2\2\2"+
		"\23\u0090\3\2\2\2\25\u0095\3\2\2\2\27\u009a\3\2\2\2\31\u009f\3\2\2\2\33"+
		"\u00a7\3\2\2\2\35\u00af\3\2\2\2\37\u00b7\3\2\2\2!\u00ba\3\2\2\2#\u00bd"+
		"\3\2\2\2%\u00bf\3\2\2\2\'\u00c1\3\2\2\2)\u00c4\3\2\2\2+\u00c7\3\2\2\2"+
		"-\u00c9\3\2\2\2/\u00cb\3\2\2\2\61\u00cd\3\2\2\2\63\u00cf\3\2\2\2\65\u00d1"+
		"\3\2\2\2\67\u00d3\3\2\2\29\u00d5\3\2\2\2;\u00d7\3\2\2\2=\u00da\3\2\2\2"+
		"?\u00dd\3\2\2\2A\u00e0\3\2\2\2C\u00e3\3\2\2\2E\u00e8\3\2\2\2G\u00ee\3"+
		"\2\2\2I\u00f3\3\2\2\2K\u00f5\3\2\2\2M\u00f7\3\2\2\2O\u00f9\3\2\2\2Q\u00fb"+
		"\3\2\2\2S\u00fd\3\2\2\2U\u00ff\3\2\2\2W\u0101\3\2\2\2Y\u010b\3\2\2\2["+
		"\u0119\3\2\2\2]\u011e\3\2\2\2_\u0124\3\2\2\2a\u0126\3\2\2\2c\u0129\3\2"+
		"\2\2e\u013f\3\2\2\2g\u0141\3\2\2\2i\u0148\3\2\2\2k\u014e\3\2\2\2m\u0155"+
		"\3\2\2\2op\7\60\2\2p\4\3\2\2\2qr\7,\2\2r\6\3\2\2\2st\7B\2\2t\b\3\2\2\2"+
		"uv\7<\2\2v\n\3\2\2\2wx\7w\2\2xy\7t\2\2yz\7k\2\2z\f\3\2\2\2{|\7v\2\2|}"+
		"\7k\2\2}~\7o\2\2~\177\7g\2\2\177\16\3\2\2\2\u0080\u0081\7f\2\2\u0081\u0082"+
		"\7c\2\2\u0082\u0083\7v\2\2\u0083\u0084\7g\2\2\u0084\u0085\7v\2\2\u0085"+
		"\u0086\7k\2\2\u0086\u0087\7o\2\2\u0087\u0088\7g\2\2\u0088\20\3\2\2\2\u0089"+
		"\u008a\7u\2\2\u008a\u008b\7v\2\2\u008b\u008c\7t\2\2\u008c\u008d\7k\2\2"+
		"\u008d\u008e\7p\2\2\u008e\u008f\7i\2\2\u008f\22\3\2\2\2\u0090\u0091\7"+
		"w\2\2\u0091\u0092\7w\2\2\u0092\u0093\7k\2\2\u0093\u0094\7f\2\2\u0094\24"+
		"\3\2\2\2\u0095\u0096\7y\2\2\u0096\u0097\7j\2\2\u0097\u0098\7g\2\2\u0098"+
		"\u0099\7p\2\2\u0099\26\3\2\2\2\u009a\u009b\7e\2\2\u009b\u009c\7c\2\2\u009c"+
		"\u009d\7u\2\2\u009d\u009e\7g\2\2\u009e\30\3\2\2\2\u009f\u00a0\7f\2\2\u00a0"+
		"\u00a1\7g\2\2\u00a1\u00a2\7h\2\2\u00a2\u00a3\7c\2\2\u00a3\u00a4\7w\2\2"+
		"\u00a4\u00a5\7n\2\2\u00a5\u00a6\7v\2\2\u00a6\32\3\2\2\2\u00a7\u00a8\7"+
		"k\2\2\u00a8\u00a9\7p\2\2\u00a9\u00aa\7v\2\2\u00aa\u00ab\7g\2\2\u00ab\u00ac"+
		"\7i\2\2\u00ac\u00ad\7g\2\2\u00ad\u00ae\7t\2\2\u00ae\34\3\2\2\2\u00af\u00b0"+
		"\7f\2\2\u00b0\u00b1\7g\2\2\u00b1\u00b2\7e\2\2\u00b2\u00b3\7k\2\2\u00b3"+
		"\u00b4\7o\2\2\u00b4\u00b5\7c\2\2\u00b5\u00b6\7n\2\2\u00b6\36\3\2\2\2\u00b7"+
		"\u00b8\7?\2\2\u00b8\u00b9\7?\2\2\u00b9 \3\2\2\2\u00ba\u00bb\7#\2\2\u00bb"+
		"\u00bc\7?\2\2\u00bc\"\3\2\2\2\u00bd\u00be\7@\2\2\u00be$\3\2\2\2\u00bf"+
		"\u00c0\7>\2\2\u00c0&\3\2\2\2\u00c1\u00c2\7>\2\2\u00c2\u00c3\7?\2\2\u00c3"+
		"(\3\2\2\2\u00c4\u00c5\7@\2\2\u00c5\u00c6\7?\2\2\u00c6*\3\2\2\2\u00c7\u00c8"+
		"\7#\2\2\u00c8,\3\2\2\2\u00c9\u00ca\7-\2\2\u00ca.\3\2\2\2\u00cb\u00cc\7"+
		"/\2\2\u00cc\60\3\2\2\2\u00cd\u00ce\7\61\2\2\u00ce\62\3\2\2\2\u00cf\u00d0"+
		"\7\'\2\2\u00d0\64\3\2\2\2\u00d1\u00d2\7`\2\2\u00d2\66\3\2\2\2\u00d3\u00d4"+
		"\7(\2\2\u00d48\3\2\2\2\u00d5\u00d6\7~\2\2\u00d6:\3\2\2\2\u00d7\u00d8\7"+
		"(\2\2\u00d8\u00d9\7(\2\2\u00d9<\3\2\2\2\u00da\u00db\7~\2\2\u00db\u00dc"+
		"\7~\2\2\u00dc>\3\2\2\2\u00dd\u00de\7A\2\2\u00de\u00df\7A\2\2\u00df@\3"+
		"\2\2\2\u00e0\u00e1\7/\2\2\u00e1\u00e2\7@\2\2\u00e2B\3\2\2\2\u00e3\u00e4"+
		"\7v\2\2\u00e4\u00e5\7t\2\2\u00e5\u00e6\7w\2\2\u00e6\u00e7\7g\2\2\u00e7"+
		"D\3\2\2\2\u00e8\u00e9\7h\2\2\u00e9\u00ea\7c\2\2\u00ea\u00eb\7n\2\2\u00eb"+
		"\u00ec\7u\2\2\u00ec\u00ed\7g\2\2\u00edF\3\2\2\2\u00ee\u00ef\7p\2\2\u00ef"+
		"\u00f0\7w\2\2\u00f0\u00f1\7n\2\2\u00f1\u00f2\7n\2\2\u00f2H\3\2\2\2\u00f3"+
		"\u00f4\7}\2\2\u00f4J\3\2\2\2\u00f5\u00f6\7\177\2\2\u00f6L\3\2\2\2\u00f7"+
		"\u00f8\7]\2\2\u00f8N\3\2\2\2\u00f9\u00fa\7_\2\2\u00faP\3\2\2\2\u00fb\u00fc"+
		"\7.\2\2\u00fcR\3\2\2\2\u00fd\u00fe\7*\2\2\u00feT\3\2\2\2\u00ff\u0100\7"+
		"+\2\2\u0100V\3\2\2\2\u0101\u0106\7$\2\2\u0102\u0105\5[.\2\u0103\u0105"+
		"\5a\61\2\u0104\u0102\3\2\2\2\u0104\u0103\3\2\2\2\u0105\u0108\3\2\2\2\u0106"+
		"\u0104\3\2\2\2\u0106\u0107\3\2\2\2\u0107\u0109\3\2\2\2\u0108\u0106\3\2"+
		"\2\2\u0109\u010a\7$\2\2\u010aX\3\2\2\2\u010b\u010c\7\61\2\2\u010c\u010d"+
		"\7,\2\2\u010d\u0111\3\2\2\2\u010e\u0110\13\2\2\2\u010f\u010e\3\2\2\2\u0110"+
		"\u0113\3\2\2\2\u0111\u0112\3\2\2\2\u0111\u010f\3\2\2\2\u0112\u0114\3\2"+
		"\2\2\u0113\u0111\3\2\2\2\u0114\u0115\7,\2\2\u0115\u0116\7\61\2\2\u0116"+
		"\u0117\3\2\2\2\u0117\u0118\b-\2\2\u0118Z\3\2\2\2\u0119\u011c\7^\2\2\u011a"+
		"\u011d\t\2\2\2\u011b\u011d\5]/\2\u011c\u011a\3\2\2\2\u011c\u011b\3\2\2"+
		"\2\u011d\\\3\2\2\2\u011e\u011f\7w\2\2\u011f\u0120\5_\60\2\u0120\u0121"+
		"\5_\60\2\u0121\u0122\5_\60\2\u0122\u0123\5_\60\2\u0123^\3\2\2\2\u0124"+
		"\u0125\t\3\2\2\u0125`\3\2\2\2\u0126\u0127\n\4\2\2\u0127b\3\2\2\2\u0128"+
		"\u012a\7/\2\2\u0129\u0128\3\2\2\2\u0129\u012a\3\2\2\2\u012a\u012b\3\2"+
		"\2\2\u012b\u0132\5e\63\2\u012c\u012e\7\60\2\2\u012d\u012f\t\5\2\2\u012e"+
		"\u012d\3\2\2\2\u012f\u0130\3\2\2\2\u0130\u012e\3\2\2\2\u0130\u0131\3\2"+
		"\2\2\u0131\u0133\3\2\2\2\u0132\u012c\3\2\2\2\u0132\u0133\3\2\2\2\u0133"+
		"\u0135\3\2\2\2\u0134\u0136\5g\64\2\u0135\u0134\3\2\2\2\u0135\u0136\3\2"+
		"\2\2\u0136d\3\2\2\2\u0137\u0140\7\62\2\2\u0138\u013c\t\6\2\2\u0139\u013b"+
		"\t\5\2\2\u013a\u0139\3\2\2\2\u013b\u013e\3\2\2\2\u013c\u013a\3\2\2\2\u013c"+
		"\u013d\3\2\2\2\u013d\u0140\3\2\2\2\u013e\u013c\3\2\2\2\u013f\u0137\3\2"+
		"\2\2\u013f\u0138\3\2\2\2\u0140f\3\2\2\2\u0141\u0143\t\7\2\2\u0142\u0144"+
		"\t\b\2\2\u0143\u0142\3\2\2\2\u0143\u0144\3\2\2\2\u0144\u0145\3\2\2\2\u0145"+
		"\u0146\5e\63\2\u0146h\3\2\2\2\u0147\u0149\t\t\2\2\u0148\u0147\3\2\2\2"+
		"\u0149\u014a\3\2\2\2\u014a\u0148\3\2\2\2\u014a\u014b\3\2\2\2\u014b\u014c"+
		"\3\2\2\2\u014c\u014d\b\65\2\2\u014dj\3\2\2\2\u014e\u0152\t\n\2\2\u014f"+
		"\u0151\t\13\2\2\u0150\u014f\3\2\2\2\u0151\u0154\3\2\2\2\u0152\u0150\3"+
		"\2\2\2\u0152\u0153\3\2\2\2\u0153l\3\2\2\2\u0154\u0152\3\2\2\2\u0155\u0157"+
		"\7\60\2\2\u0156\u0158\t\n\2\2\u0157\u0156\3\2\2\2\u0158\u0159\3\2\2\2"+
		"\u0159\u0157\3\2\2\2\u0159\u015a\3\2\2\2\u015a\u015e\3\2\2\2\u015b\u015d"+
		"\t\13\2\2\u015c\u015b\3\2\2\2\u015d\u0160\3\2\2\2\u015e\u015c\3\2\2\2"+
		"\u015e\u015f\3\2\2\2\u015fn\3\2\2\2\u0160\u015e\3\2\2\2\22\2\u0104\u0106"+
		"\u0111\u011c\u0129\u0130\u0132\u0135\u013c\u013f\u0143\u014a\u0152\u0159"+
		"\u015e\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}