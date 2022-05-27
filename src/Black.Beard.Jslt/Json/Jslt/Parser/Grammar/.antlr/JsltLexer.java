// Generated from c:\Src\jslt\src\Black.Beard.Jslt\Json\Jslt\Parser\Grammar\JsltLexer.g4 by ANTLR 4.8
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
		SUBSCRIPT=1, WILDCARD_SUBSCRIPT=2, CURRENT_VALUE=3, COLON=4, SHARP=5, 
		RECURSIVE_DESCENT=6, URI_TYPE=7, TIME_TYPE=8, DATETIME_TYPE=9, STRING_TYPE=10, 
		BOOLEAN_TYPE=11, GUID_TYPE=12, WHEN_TYPE=13, INTEGER_TYPE=14, DECIMAL_TYPE=15, 
		IN=16, NIN=17, SUBSETOF=18, CONTAINS=19, SIZE=20, EMPTY=21, TRUE=22, FALSE=23, 
		DEFAULT=24, EQ=25, NE=26, GT=27, LT=28, LE=29, GE=30, NT=31, PLUS=32, 
		MINUS=33, DIVID=34, MODULO=35, POWER=36, AND=37, OR=38, AND_EXCLUSIVE=39, 
		OR_EXCLUSIVE=40, COALESCE=41, CHAIN=42, NULL=43, BRACE_LEFT=44, BRACE_RIGHT=45, 
		BRACKET_LEFT=46, BRACKET_RIGHT=47, COMMA=48, PAREN_LEFT=49, PAREN_RIGHT=50, 
		DOLLAR=51, QUESTION=52, STRING=53, STRING2=54, MULTI_LINE_COMMENT=55, 
		SINGLE_QUOTE_CODE_STRING=56, NUMBER=57, SIGNED_NUMBER=58, INT=59, SIGNED_INT=60, 
		ID=61, IDQUOTED=62, VARIABLE_NAME=63, IDLOWCASE=64;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"SUBSCRIPT", "WILDCARD_SUBSCRIPT", "CURRENT_VALUE", "COLON", "SHARP", 
			"RECURSIVE_DESCENT", "URI_TYPE", "TIME_TYPE", "DATETIME_TYPE", "STRING_TYPE", 
			"BOOLEAN_TYPE", "GUID_TYPE", "WHEN_TYPE", "INTEGER_TYPE", "DECIMAL_TYPE", 
			"IN", "NIN", "SUBSETOF", "CONTAINS", "SIZE", "EMPTY", "TRUE", "FALSE", 
			"DEFAULT", "EQ", "NE", "GT", "LT", "LE", "GE", "NT", "PLUS", "MINUS", 
			"DIVID", "MODULO", "POWER", "AND", "OR", "AND_EXCLUSIVE", "OR_EXCLUSIVE", 
			"COALESCE", "CHAIN", "NULL", "BRACE_LEFT", "BRACE_RIGHT", "BRACKET_LEFT", 
			"BRACKET_RIGHT", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", "DOLLAR", "QUESTION", 
			"STRING", "STRING2", "MULTI_LINE_COMMENT", "SINGLE_QUOTE_CODE_STRING", 
			"ESC", "UNICODE", "HEX", "SAFECODEPOINT", "NUMBER", "SIGNED_NUMBER", 
			"INT", "SIGNED_INT", "EXP", "ID", "IDQUOTED", "VARIABLE_NAME", "IDLOWCASE"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "'*'", "'@'", "':'", "'#'", "'..'", "'@uri'", "'@time'", 
			"'@datetime'", "'@string'", "'@boolean'", "'@uuid'", "'@when'", "'@integer'", 
			"'@decimal'", "'in'", "'nin'", "'subsetof'", "'contains'", "'size'", 
			"'empty'", "'true'", "'false'", "'default'", "'=='", "'!='", "'>'", "'<'", 
			"'<='", "'>='", "'!'", "'+'", "'-'", "'/'", "'%'", "'^'", "'&'", "'|'", 
			"'&&'", "'||'", "'??'", "'->'", "'null'", "'{'", "'}'", "'['", "']'", 
			"','", "'('", "')'", "'$'", "'?'", null, null, null, "'''"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SUBSCRIPT", "WILDCARD_SUBSCRIPT", "CURRENT_VALUE", "COLON", "SHARP", 
			"RECURSIVE_DESCENT", "URI_TYPE", "TIME_TYPE", "DATETIME_TYPE", "STRING_TYPE", 
			"BOOLEAN_TYPE", "GUID_TYPE", "WHEN_TYPE", "INTEGER_TYPE", "DECIMAL_TYPE", 
			"IN", "NIN", "SUBSETOF", "CONTAINS", "SIZE", "EMPTY", "TRUE", "FALSE", 
			"DEFAULT", "EQ", "NE", "GT", "LT", "LE", "GE", "NT", "PLUS", "MINUS", 
			"DIVID", "MODULO", "POWER", "AND", "OR", "AND_EXCLUSIVE", "OR_EXCLUSIVE", 
			"COALESCE", "CHAIN", "NULL", "BRACE_LEFT", "BRACE_RIGHT", "BRACKET_LEFT", 
			"BRACKET_RIGHT", "COMMA", "PAREN_LEFT", "PAREN_RIGHT", "DOLLAR", "QUESTION", 
			"STRING", "STRING2", "MULTI_LINE_COMMENT", "SINGLE_QUOTE_CODE_STRING", 
			"NUMBER", "SIGNED_NUMBER", "INT", "SIGNED_INT", "ID", "IDQUOTED", "VARIABLE_NAME", 
			"IDLOWCASE"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2B\u01e1\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t="+
		"\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\3\2\3\2\3\3\3\3"+
		"\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3"+
		"\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3"+
		"\r\3\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\17"+
		"\3\17\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\21\3\21"+
		"\3\21\3\22\3\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\25\3\25\3\25\3\25\3\25"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3\27\3\30\3\30\3\30"+
		"\3\30\3\30\3\30\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\32\3\32\3\32"+
		"\3\33\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3\36\3\37\3\37\3\37\3 \3"+
		" \3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3(\3)\3)\3)\3*\3"+
		"*\3*\3+\3+\3+\3,\3,\3,\3,\3,\3-\3-\3.\3.\3/\3/\3\60\3\60\3\61\3\61\3\62"+
		"\3\62\3\63\3\63\3\64\3\64\3\65\3\65\3\66\3\66\3\66\7\66\u015c\n\66\f\66"+
		"\16\66\u015f\13\66\3\66\3\66\3\67\3\67\3\67\3\67\3\67\7\67\u0168\n\67"+
		"\f\67\16\67\u016b\13\67\3\67\3\67\38\38\38\38\78\u0173\n8\f8\168\u0176"+
		"\138\38\38\38\38\38\39\39\3:\3:\3:\5:\u0182\n:\3;\3;\3;\3;\3;\3;\3<\3"+
		"<\3=\3=\3>\3>\3>\6>\u0191\n>\r>\16>\u0192\5>\u0195\n>\3>\5>\u0198\n>\3"+
		"?\5?\u019b\n?\3?\3?\3?\6?\u01a0\n?\r?\16?\u01a1\5?\u01a4\n?\3?\5?\u01a7"+
		"\n?\3@\3@\3@\7@\u01ac\n@\f@\16@\u01af\13@\5@\u01b1\n@\3A\5A\u01b4\nA\3"+
		"A\3A\3A\7A\u01b9\nA\fA\16A\u01bc\13A\5A\u01be\nA\3B\3B\5B\u01c2\nB\3B"+
		"\3B\3C\3C\7C\u01c8\nC\fC\16C\u01cb\13C\3D\3D\3D\3D\3E\3E\3E\3E\3E\7E\u01d6"+
		"\nE\fE\16E\u01d9\13E\3F\3F\7F\u01dd\nF\fF\16F\u01e0\13F\3\u0174\2G\3\3"+
		"\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21"+
		"!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36;\37= ?!"+
		"A\"C#E$G%I&K\'M(O)Q*S+U,W-Y.[/]\60_\61a\62c\63e\64g\65i\66k\67m8o9q:s"+
		"\2u\2w\2y\2{;}<\177=\u0081>\u0083\2\u0085?\u0087@\u0089A\u008bB\3\2\r"+
		"\n\2$$\61\61^^ddhhppttvv\5\2\62;CHch\5\2\2!$$^^\4\2--//\3\2\63;\3\2\62"+
		";\4\2GGgg\5\2C\\aac|\6\2\62;C\\aac|\4\2aac|\5\2\62;aac|\2\u01f1\2\3\3"+
		"\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2"+
		"\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3"+
		"\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2"+
		"%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61"+
		"\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2"+
		"\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I"+
		"\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2U\3\2"+
		"\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3\2\2\2\2]\3\2\2\2\2_\3\2\2\2\2a\3\2\2\2"+
		"\2c\3\2\2\2\2e\3\2\2\2\2g\3\2\2\2\2i\3\2\2\2\2k\3\2\2\2\2m\3\2\2\2\2o"+
		"\3\2\2\2\2q\3\2\2\2\2{\3\2\2\2\2}\3\2\2\2\2\177\3\2\2\2\2\u0081\3\2\2"+
		"\2\2\u0085\3\2\2\2\2\u0087\3\2\2\2\2\u0089\3\2\2\2\2\u008b\3\2\2\2\3\u008d"+
		"\3\2\2\2\5\u008f\3\2\2\2\7\u0091\3\2\2\2\t\u0093\3\2\2\2\13\u0095\3\2"+
		"\2\2\r\u0097\3\2\2\2\17\u009a\3\2\2\2\21\u009f\3\2\2\2\23\u00a5\3\2\2"+
		"\2\25\u00af\3\2\2\2\27\u00b7\3\2\2\2\31\u00c0\3\2\2\2\33\u00c6\3\2\2\2"+
		"\35\u00cc\3\2\2\2\37\u00d5\3\2\2\2!\u00de\3\2\2\2#\u00e1\3\2\2\2%\u00e5"+
		"\3\2\2\2\'\u00ee\3\2\2\2)\u00f7\3\2\2\2+\u00fc\3\2\2\2-\u0102\3\2\2\2"+
		"/\u0107\3\2\2\2\61\u010d\3\2\2\2\63\u0115\3\2\2\2\65\u0118\3\2\2\2\67"+
		"\u011b\3\2\2\29\u011d\3\2\2\2;\u011f\3\2\2\2=\u0122\3\2\2\2?\u0125\3\2"+
		"\2\2A\u0127\3\2\2\2C\u0129\3\2\2\2E\u012b\3\2\2\2G\u012d\3\2\2\2I\u012f"+
		"\3\2\2\2K\u0131\3\2\2\2M\u0133\3\2\2\2O\u0135\3\2\2\2Q\u0138\3\2\2\2S"+
		"\u013b\3\2\2\2U\u013e\3\2\2\2W\u0141\3\2\2\2Y\u0146\3\2\2\2[\u0148\3\2"+
		"\2\2]\u014a\3\2\2\2_\u014c\3\2\2\2a\u014e\3\2\2\2c\u0150\3\2\2\2e\u0152"+
		"\3\2\2\2g\u0154\3\2\2\2i\u0156\3\2\2\2k\u0158\3\2\2\2m\u0162\3\2\2\2o"+
		"\u016e\3\2\2\2q\u017c\3\2\2\2s\u017e\3\2\2\2u\u0183\3\2\2\2w\u0189\3\2"+
		"\2\2y\u018b\3\2\2\2{\u018d\3\2\2\2}\u019a\3\2\2\2\177\u01b0\3\2\2\2\u0081"+
		"\u01b3\3\2\2\2\u0083\u01bf\3\2\2\2\u0085\u01c5\3\2\2\2\u0087\u01cc\3\2"+
		"\2\2\u0089\u01d0\3\2\2\2\u008b\u01da\3\2\2\2\u008d\u008e\7\60\2\2\u008e"+
		"\4\3\2\2\2\u008f\u0090\7,\2\2\u0090\6\3\2\2\2\u0091\u0092\7B\2\2\u0092"+
		"\b\3\2\2\2\u0093\u0094\7<\2\2\u0094\n\3\2\2\2\u0095\u0096\7%\2\2\u0096"+
		"\f\3\2\2\2\u0097\u0098\7\60\2\2\u0098\u0099\7\60\2\2\u0099\16\3\2\2\2"+
		"\u009a\u009b\7B\2\2\u009b\u009c\7w\2\2\u009c\u009d\7t\2\2\u009d\u009e"+
		"\7k\2\2\u009e\20\3\2\2\2\u009f\u00a0\7B\2\2\u00a0\u00a1\7v\2\2\u00a1\u00a2"+
		"\7k\2\2\u00a2\u00a3\7o\2\2\u00a3\u00a4\7g\2\2\u00a4\22\3\2\2\2\u00a5\u00a6"+
		"\7B\2\2\u00a6\u00a7\7f\2\2\u00a7\u00a8\7c\2\2\u00a8\u00a9\7v\2\2\u00a9"+
		"\u00aa\7g\2\2\u00aa\u00ab\7v\2\2\u00ab\u00ac\7k\2\2\u00ac\u00ad\7o\2\2"+
		"\u00ad\u00ae\7g\2\2\u00ae\24\3\2\2\2\u00af\u00b0\7B\2\2\u00b0\u00b1\7"+
		"u\2\2\u00b1\u00b2\7v\2\2\u00b2\u00b3\7t\2\2\u00b3\u00b4\7k\2\2\u00b4\u00b5"+
		"\7p\2\2\u00b5\u00b6\7i\2\2\u00b6\26\3\2\2\2\u00b7\u00b8\7B\2\2\u00b8\u00b9"+
		"\7d\2\2\u00b9\u00ba\7q\2\2\u00ba\u00bb\7q\2\2\u00bb\u00bc\7n\2\2\u00bc"+
		"\u00bd\7g\2\2\u00bd\u00be\7c\2\2\u00be\u00bf\7p\2\2\u00bf\30\3\2\2\2\u00c0"+
		"\u00c1\7B\2\2\u00c1\u00c2\7w\2\2\u00c2\u00c3\7w\2\2\u00c3\u00c4\7k\2\2"+
		"\u00c4\u00c5\7f\2\2\u00c5\32\3\2\2\2\u00c6\u00c7\7B\2\2\u00c7\u00c8\7"+
		"y\2\2\u00c8\u00c9\7j\2\2\u00c9\u00ca\7g\2\2\u00ca\u00cb\7p\2\2\u00cb\34"+
		"\3\2\2\2\u00cc\u00cd\7B\2\2\u00cd\u00ce\7k\2\2\u00ce\u00cf\7p\2\2\u00cf"+
		"\u00d0\7v\2\2\u00d0\u00d1\7g\2\2\u00d1\u00d2\7i\2\2\u00d2\u00d3\7g\2\2"+
		"\u00d3\u00d4\7t\2\2\u00d4\36\3\2\2\2\u00d5\u00d6\7B\2\2\u00d6\u00d7\7"+
		"f\2\2\u00d7\u00d8\7g\2\2\u00d8\u00d9\7e\2\2\u00d9\u00da\7k\2\2\u00da\u00db"+
		"\7o\2\2\u00db\u00dc\7c\2\2\u00dc\u00dd\7n\2\2\u00dd \3\2\2\2\u00de\u00df"+
		"\7k\2\2\u00df\u00e0\7p\2\2\u00e0\"\3\2\2\2\u00e1\u00e2\7p\2\2\u00e2\u00e3"+
		"\7k\2\2\u00e3\u00e4\7p\2\2\u00e4$\3\2\2\2\u00e5\u00e6\7u\2\2\u00e6\u00e7"+
		"\7w\2\2\u00e7\u00e8\7d\2\2\u00e8\u00e9\7u\2\2\u00e9\u00ea\7g\2\2\u00ea"+
		"\u00eb\7v\2\2\u00eb\u00ec\7q\2\2\u00ec\u00ed\7h\2\2\u00ed&\3\2\2\2\u00ee"+
		"\u00ef\7e\2\2\u00ef\u00f0\7q\2\2\u00f0\u00f1\7p\2\2\u00f1\u00f2\7v\2\2"+
		"\u00f2\u00f3\7c\2\2\u00f3\u00f4\7k\2\2\u00f4\u00f5\7p\2\2\u00f5\u00f6"+
		"\7u\2\2\u00f6(\3\2\2\2\u00f7\u00f8\7u\2\2\u00f8\u00f9\7k\2\2\u00f9\u00fa"+
		"\7|\2\2\u00fa\u00fb\7g\2\2\u00fb*\3\2\2\2\u00fc\u00fd\7g\2\2\u00fd\u00fe"+
		"\7o\2\2\u00fe\u00ff\7r\2\2\u00ff\u0100\7v\2\2\u0100\u0101\7{\2\2\u0101"+
		",\3\2\2\2\u0102\u0103\7v\2\2\u0103\u0104\7t\2\2\u0104\u0105\7w\2\2\u0105"+
		"\u0106\7g\2\2\u0106.\3\2\2\2\u0107\u0108\7h\2\2\u0108\u0109\7c\2\2\u0109"+
		"\u010a\7n\2\2\u010a\u010b\7u\2\2\u010b\u010c\7g\2\2\u010c\60\3\2\2\2\u010d"+
		"\u010e\7f\2\2\u010e\u010f\7g\2\2\u010f\u0110\7h\2\2\u0110\u0111\7c\2\2"+
		"\u0111\u0112\7w\2\2\u0112\u0113\7n\2\2\u0113\u0114\7v\2\2\u0114\62\3\2"+
		"\2\2\u0115\u0116\7?\2\2\u0116\u0117\7?\2\2\u0117\64\3\2\2\2\u0118\u0119"+
		"\7#\2\2\u0119\u011a\7?\2\2\u011a\66\3\2\2\2\u011b\u011c\7@\2\2\u011c8"+
		"\3\2\2\2\u011d\u011e\7>\2\2\u011e:\3\2\2\2\u011f\u0120\7>\2\2\u0120\u0121"+
		"\7?\2\2\u0121<\3\2\2\2\u0122\u0123\7@\2\2\u0123\u0124\7?\2\2\u0124>\3"+
		"\2\2\2\u0125\u0126\7#\2\2\u0126@\3\2\2\2\u0127\u0128\7-\2\2\u0128B\3\2"+
		"\2\2\u0129\u012a\7/\2\2\u012aD\3\2\2\2\u012b\u012c\7\61\2\2\u012cF\3\2"+
		"\2\2\u012d\u012e\7\'\2\2\u012eH\3\2\2\2\u012f\u0130\7`\2\2\u0130J\3\2"+
		"\2\2\u0131\u0132\7(\2\2\u0132L\3\2\2\2\u0133\u0134\7~\2\2\u0134N\3\2\2"+
		"\2\u0135\u0136\7(\2\2\u0136\u0137\7(\2\2\u0137P\3\2\2\2\u0138\u0139\7"+
		"~\2\2\u0139\u013a\7~\2\2\u013aR\3\2\2\2\u013b\u013c\7A\2\2\u013c\u013d"+
		"\7A\2\2\u013dT\3\2\2\2\u013e\u013f\7/\2\2\u013f\u0140\7@\2\2\u0140V\3"+
		"\2\2\2\u0141\u0142\7p\2\2\u0142\u0143\7w\2\2\u0143\u0144\7n\2\2\u0144"+
		"\u0145\7n\2\2\u0145X\3\2\2\2\u0146\u0147\7}\2\2\u0147Z\3\2\2\2\u0148\u0149"+
		"\7\177\2\2\u0149\\\3\2\2\2\u014a\u014b\7]\2\2\u014b^\3\2\2\2\u014c\u014d"+
		"\7_\2\2\u014d`\3\2\2\2\u014e\u014f\7.\2\2\u014fb\3\2\2\2\u0150\u0151\7"+
		"*\2\2\u0151d\3\2\2\2\u0152\u0153\7+\2\2\u0153f\3\2\2\2\u0154\u0155\7&"+
		"\2\2\u0155h\3\2\2\2\u0156\u0157\7A\2\2\u0157j\3\2\2\2\u0158\u015d\7$\2"+
		"\2\u0159\u015c\5s:\2\u015a\u015c\5y=\2\u015b\u0159\3\2\2\2\u015b\u015a"+
		"\3\2\2\2\u015c\u015f\3\2\2\2\u015d\u015b\3\2\2\2\u015d\u015e\3\2\2\2\u015e"+
		"\u0160\3\2\2\2\u015f\u015d\3\2\2\2\u0160\u0161\7$\2\2\u0161l\3\2\2\2\u0162"+
		"\u0163\7&\2\2\u0163\u0164\7$\2\2\u0164\u0169\3\2\2\2\u0165\u0168\5s:\2"+
		"\u0166\u0168\5y=\2\u0167\u0165\3\2\2\2\u0167\u0166\3\2\2\2\u0168\u016b"+
		"\3\2\2\2\u0169\u0167\3\2\2\2\u0169\u016a\3\2\2\2\u016a\u016c\3\2\2\2\u016b"+
		"\u0169\3\2\2\2\u016c\u016d\7$\2\2\u016dn\3\2\2\2\u016e\u016f\7\61\2\2"+
		"\u016f\u0170\7,\2\2\u0170\u0174\3\2\2\2\u0171\u0173\13\2\2\2\u0172\u0171"+
		"\3\2\2\2\u0173\u0176\3\2\2\2\u0174\u0175\3\2\2\2\u0174\u0172\3\2\2\2\u0175"+
		"\u0177\3\2\2\2\u0176\u0174\3\2\2\2\u0177\u0178\7,\2\2\u0178\u0179\7\61"+
		"\2\2\u0179\u017a\3\2\2\2\u017a\u017b\b8\2\2\u017bp\3\2\2\2\u017c\u017d"+
		"\7)\2\2\u017dr\3\2\2\2\u017e\u0181\7^\2\2\u017f\u0182\t\2\2\2\u0180\u0182"+
		"\5u;\2\u0181\u017f\3\2\2\2\u0181\u0180\3\2\2\2\u0182t\3\2\2\2\u0183\u0184"+
		"\7w\2\2\u0184\u0185\5w<\2\u0185\u0186\5w<\2\u0186\u0187\5w<\2\u0187\u0188"+
		"\5w<\2\u0188v\3\2\2\2\u0189\u018a\t\3\2\2\u018ax\3\2\2\2\u018b\u018c\n"+
		"\4\2\2\u018cz\3\2\2\2\u018d\u0194\5\177@\2\u018e\u0190\7\60\2\2\u018f"+
		"\u0191\5\177@\2\u0190\u018f\3\2\2\2\u0191\u0192\3\2\2\2\u0192\u0190\3"+
		"\2\2\2\u0192\u0193\3\2\2\2\u0193\u0195\3\2\2\2\u0194\u018e\3\2\2\2\u0194"+
		"\u0195\3\2\2\2\u0195\u0197\3\2\2\2\u0196\u0198\5\u0083B\2\u0197\u0196"+
		"\3\2\2\2\u0197\u0198\3\2\2\2\u0198|\3\2\2\2\u0199\u019b\t\5\2\2\u019a"+
		"\u0199\3\2\2\2\u019a\u019b\3\2\2\2\u019b\u019c\3\2\2\2\u019c\u01a3\5\177"+
		"@\2\u019d\u019f\7\60\2\2\u019e\u01a0\5\177@\2\u019f\u019e\3\2\2\2\u01a0"+
		"\u01a1\3\2\2\2\u01a1\u019f\3\2\2\2\u01a1\u01a2\3\2\2\2\u01a2\u01a4\3\2"+
		"\2\2\u01a3\u019d\3\2\2\2\u01a3\u01a4\3\2\2\2\u01a4\u01a6\3\2\2\2\u01a5"+
		"\u01a7\5\u0083B\2\u01a6\u01a5\3\2\2\2\u01a6\u01a7\3\2\2\2\u01a7~\3\2\2"+
		"\2\u01a8\u01b1\7\62\2\2\u01a9\u01ad\t\6\2\2\u01aa\u01ac\t\7\2\2\u01ab"+
		"\u01aa\3\2\2\2\u01ac\u01af\3\2\2\2\u01ad\u01ab\3\2\2\2\u01ad\u01ae\3\2"+
		"\2\2\u01ae\u01b1\3\2\2\2\u01af\u01ad\3\2\2\2\u01b0\u01a8\3\2\2\2\u01b0"+
		"\u01a9\3\2\2\2\u01b1\u0080\3\2\2\2\u01b2\u01b4\t\5\2\2\u01b3\u01b2\3\2"+
		"\2\2\u01b3\u01b4\3\2\2\2\u01b4\u01bd\3\2\2\2\u01b5\u01be\7\62\2\2\u01b6"+
		"\u01ba\t\6\2\2\u01b7\u01b9\t\7\2\2\u01b8\u01b7\3\2\2\2\u01b9\u01bc\3\2"+
		"\2\2\u01ba\u01b8\3\2\2\2\u01ba\u01bb\3\2\2\2\u01bb\u01be\3\2\2\2\u01bc"+
		"\u01ba\3\2\2\2\u01bd\u01b5\3\2\2\2\u01bd\u01b6\3\2\2\2\u01be\u0082\3\2"+
		"\2\2\u01bf\u01c1\t\b\2\2\u01c0\u01c2\t\5\2\2\u01c1\u01c0\3\2\2\2\u01c1"+
		"\u01c2\3\2\2\2\u01c2\u01c3\3\2\2\2\u01c3\u01c4\5\177@\2\u01c4\u0084\3"+
		"\2\2\2\u01c5\u01c9\t\t\2\2\u01c6\u01c8\t\n\2\2\u01c7\u01c6\3\2\2\2\u01c8"+
		"\u01cb\3\2\2\2\u01c9\u01c7\3\2\2\2\u01c9\u01ca\3\2\2\2\u01ca\u0086\3\2"+
		"\2\2\u01cb\u01c9\3\2\2\2\u01cc\u01cd\7)\2\2\u01cd\u01ce\5\u0085C\2\u01ce"+
		"\u01cf\7)\2\2\u01cf\u0088\3\2\2\2\u01d0\u01d1\7B\2\2\u01d1\u01d2\7B\2"+
		"\2\u01d2\u01d3\3\2\2\2\u01d3\u01d7\t\t\2\2\u01d4\u01d6\t\n\2\2\u01d5\u01d4"+
		"\3\2\2\2\u01d6\u01d9\3\2\2\2\u01d7\u01d5\3\2\2\2\u01d7\u01d8\3\2\2\2\u01d8"+
		"\u008a\3\2\2\2\u01d9\u01d7\3\2\2\2\u01da\u01de\t\13\2\2\u01db\u01dd\t"+
		"\f\2\2\u01dc\u01db\3\2\2\2\u01dd\u01e0\3\2\2\2\u01de\u01dc\3\2\2\2\u01de"+
		"\u01df\3\2\2\2\u01df\u008c\3\2\2\2\u01e0\u01de\3\2\2\2\31\2\u015b\u015d"+
		"\u0167\u0169\u0174\u0181\u0192\u0194\u0197\u019a\u01a1\u01a3\u01a6\u01ad"+
		"\u01b0\u01b3\u01ba\u01bd\u01c1\u01c9\u01d7\u01de\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}