//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Pseudo.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AntlrGenerated {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class PseudoLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, INT_TYPE=13, FLOAT_TYPE=14, STRING_TYPE=15, 
		CHAR_TYPE=16, BOOL_TYPE=17, READ_BUILTIN=18, WRITE_BUILTIN=19, WRITELN_BUILTIN=20, 
		IF=21, THEN=22, ELSE=23, WHILE=24, EXEC=25, REPEAT=26, UNTIL=27, FOR=28, 
		END=29, AND=30, OR=31, NOT=32, FUNCTION=33, LP=34, RP=35, ASSIGN=36, EQUAL=37, 
		INT=38, FLOAT=39, STRING=40, ID=41, NL=42, LINE_COMMENT=43, COMMENT=44, 
		WS=45;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "INT_TYPE", "FLOAT_TYPE", "STRING_TYPE", "CHAR_TYPE", 
		"BOOL_TYPE", "READ_BUILTIN", "WRITE_BUILTIN", "WRITELN_BUILTIN", "IF", 
		"THEN", "ELSE", "WHILE", "EXEC", "REPEAT", "UNTIL", "FOR", "END", "AND", 
		"OR", "NOT", "FUNCTION", "LP", "RP", "ASSIGN", "EQUAL", "INT", "FLOAT", 
		"STRING", "ID", "NL", "ESC", "LETTER", "DIGIT", "LINE_COMMENT", "COMMENT", 
		"WS"
	};


	public PseudoLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public PseudoLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "','", "'<'", "'<='", "'>'", "'>='", "'['", "']'", "'+'", "'-'", 
		"'*'", "'/'", "'%'", "'intreg'", "'real'", "'text'", "'caracter'", "'boolean'", 
		"'citeste'", "'scrie'", "'scrieln'", "'daca'", "'atunci'", "'altfel'", 
		"'cat timp'", "'executa'", "'repeta'", "'pana cand'", "'pentru'", "'sfarsit'", 
		"'si'", "'sau'", "'!'", "'fun'", "'('", "')'", "'<-'", "'='"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "INT_TYPE", "FLOAT_TYPE", "STRING_TYPE", "CHAR_TYPE", "BOOL_TYPE", 
		"READ_BUILTIN", "WRITE_BUILTIN", "WRITELN_BUILTIN", "IF", "THEN", "ELSE", 
		"WHILE", "EXEC", "REPEAT", "UNTIL", "FOR", "END", "AND", "OR", "NOT", 
		"FUNCTION", "LP", "RP", "ASSIGN", "EQUAL", "INT", "FLOAT", "STRING", "ID", 
		"NL", "LINE_COMMENT", "COMMENT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Pseudo.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static PseudoLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '/', '\x172', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', '/', '\t', '/', 
		'\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', 
		'\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', 
		'\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x19', '\x3', 
		'\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', 
		'\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', 
		'\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', 
		'\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', 
		'!', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '#', '\x3', 
		'#', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', 
		'&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\a', '\'', '\x113', 
		'\n', '\'', '\f', '\'', '\xE', '\'', '\x116', '\v', '\'', '\x5', '\'', 
		'\x118', '\n', '\'', '\x3', '(', '\x6', '(', '\x11B', '\n', '(', '\r', 
		'(', '\xE', '(', '\x11C', '\x3', '(', '\x3', '(', '\a', '(', '\x121', 
		'\n', '(', '\f', '(', '\xE', '(', '\x124', '\v', '(', '\x3', '(', '\x3', 
		'(', '\x6', '(', '\x128', '\n', '(', '\r', '(', '\xE', '(', '\x129', '\x5', 
		'(', '\x12C', '\n', '(', '\x3', ')', '\x3', ')', '\x3', ')', '\a', ')', 
		'\x131', '\n', ')', '\f', ')', '\xE', ')', '\x134', '\v', ')', '\x3', 
		')', '\x3', ')', '\x3', '*', '\x3', '*', '\x5', '*', '\x13A', '\n', '*', 
		'\x3', '*', '\x3', '*', '\x3', '*', '\a', '*', '\x13F', '\n', '*', '\f', 
		'*', '\xE', '*', '\x142', '\v', '*', '\x3', '+', '\x5', '+', '\x145', 
		'\n', '+', '\x3', '+', '\x3', '+', '\x3', ',', '\x3', ',', '\x3', ',', 
		'\x3', '-', '\x3', '-', '\x3', '.', '\x3', '.', '\x3', '/', '\x3', '/', 
		'\x3', '/', '\x3', '/', '\a', '/', '\x154', '\n', '/', '\f', '/', '\xE', 
		'/', '\x157', '\v', '/', '\x3', '/', '\x3', '/', '\x3', '/', '\x3', '/', 
		'\x3', '\x30', '\x3', '\x30', '\x3', '\x30', '\x3', '\x30', '\a', '\x30', 
		'\x161', '\n', '\x30', '\f', '\x30', '\xE', '\x30', '\x164', '\v', '\x30', 
		'\x3', '\x30', '\x3', '\x30', '\x3', '\x30', '\x3', '\x30', '\x3', '\x30', 
		'\x3', '\x31', '\x3', '\x31', '\x3', '\x31', '\x3', '\x31', '\x5', '\x31', 
		'\x16F', '\n', '\x31', '\x3', '\x31', '\x3', '\x31', '\x5', '\x132', '\x155', 
		'\x162', '\x2', '\x32', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', 
		'\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', 
		'\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', 
		'\x1F', '\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', 
		'\x16', '+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', 
		'\x1B', '\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', 
		' ', '?', '!', '\x41', '\"', '\x43', '#', '\x45', '$', 'G', '%', 'I', 
		'&', 'K', '\'', 'M', '(', 'O', ')', 'Q', '*', 'S', '+', 'U', ',', 'W', 
		'\x2', 'Y', '\x2', '[', '\x2', ']', '-', '_', '.', '\x61', '/', '\x3', 
		'\x2', '\a', '\x3', '\x2', '\x33', ';', '\b', '\x2', '$', '$', '^', '^', 
		'\x64', '\x64', 'p', 'p', 't', 't', 'v', 'v', '\x4', '\x2', '\x43', '\\', 
		'\x63', '|', '\x3', '\x2', '\x32', ';', '\x4', '\x2', '\v', '\v', '\"', 
		'\"', '\x2', '\x17F', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', 
		'\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', 
		'\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x41', '\x3', '\x2', '\x2', '\x2', '\x2', '\x43', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x45', '\x3', '\x2', '\x2', '\x2', '\x2', 'G', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'I', '\x3', '\x2', '\x2', '\x2', '\x2', 'K', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'M', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'O', '\x3', '\x2', '\x2', '\x2', '\x2', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'S', '\x3', '\x2', '\x2', '\x2', '\x2', 'U', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ']', '\x3', '\x2', '\x2', '\x2', '\x2', '_', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x61', '\x3', '\x2', '\x2', '\x2', '\x3', '\x63', 
		'\x3', '\x2', '\x2', '\x2', '\x5', '\x65', '\x3', '\x2', '\x2', '\x2', 
		'\a', 'g', '\x3', '\x2', '\x2', '\x2', '\t', 'j', '\x3', '\x2', '\x2', 
		'\x2', '\v', 'l', '\x3', '\x2', '\x2', '\x2', '\r', 'o', '\x3', '\x2', 
		'\x2', '\x2', '\xF', 'q', '\x3', '\x2', '\x2', '\x2', '\x11', 's', '\x3', 
		'\x2', '\x2', '\x2', '\x13', 'u', '\x3', '\x2', '\x2', '\x2', '\x15', 
		'w', '\x3', '\x2', '\x2', '\x2', '\x17', 'y', '\x3', '\x2', '\x2', '\x2', 
		'\x19', '{', '\x3', '\x2', '\x2', '\x2', '\x1B', '}', '\x3', '\x2', '\x2', 
		'\x2', '\x1D', '\x84', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x89', '\x3', 
		'\x2', '\x2', '\x2', '!', '\x8E', '\x3', '\x2', '\x2', '\x2', '#', '\x97', 
		'\x3', '\x2', '\x2', '\x2', '%', '\x9F', '\x3', '\x2', '\x2', '\x2', '\'', 
		'\xA7', '\x3', '\x2', '\x2', '\x2', ')', '\xAD', '\x3', '\x2', '\x2', 
		'\x2', '+', '\xB5', '\x3', '\x2', '\x2', '\x2', '-', '\xBA', '\x3', '\x2', 
		'\x2', '\x2', '/', '\xC1', '\x3', '\x2', '\x2', '\x2', '\x31', '\xC8', 
		'\x3', '\x2', '\x2', '\x2', '\x33', '\xD1', '\x3', '\x2', '\x2', '\x2', 
		'\x35', '\xD9', '\x3', '\x2', '\x2', '\x2', '\x37', '\xE0', '\x3', '\x2', 
		'\x2', '\x2', '\x39', '\xEA', '\x3', '\x2', '\x2', '\x2', ';', '\xF1', 
		'\x3', '\x2', '\x2', '\x2', '=', '\xF9', '\x3', '\x2', '\x2', '\x2', '?', 
		'\xFC', '\x3', '\x2', '\x2', '\x2', '\x41', '\x100', '\x3', '\x2', '\x2', 
		'\x2', '\x43', '\x102', '\x3', '\x2', '\x2', '\x2', '\x45', '\x106', '\x3', 
		'\x2', '\x2', '\x2', 'G', '\x108', '\x3', '\x2', '\x2', '\x2', 'I', '\x10A', 
		'\x3', '\x2', '\x2', '\x2', 'K', '\x10D', '\x3', '\x2', '\x2', '\x2', 
		'M', '\x117', '\x3', '\x2', '\x2', '\x2', 'O', '\x12B', '\x3', '\x2', 
		'\x2', '\x2', 'Q', '\x12D', '\x3', '\x2', '\x2', '\x2', 'S', '\x139', 
		'\x3', '\x2', '\x2', '\x2', 'U', '\x144', '\x3', '\x2', '\x2', '\x2', 
		'W', '\x148', '\x3', '\x2', '\x2', '\x2', 'Y', '\x14B', '\x3', '\x2', 
		'\x2', '\x2', '[', '\x14D', '\x3', '\x2', '\x2', '\x2', ']', '\x14F', 
		'\x3', '\x2', '\x2', '\x2', '_', '\x15C', '\x3', '\x2', '\x2', '\x2', 
		'\x61', '\x16E', '\x3', '\x2', '\x2', '\x2', '\x63', '\x64', '\a', '.', 
		'\x2', '\x2', '\x64', '\x4', '\x3', '\x2', '\x2', '\x2', '\x65', '\x66', 
		'\a', '>', '\x2', '\x2', '\x66', '\x6', '\x3', '\x2', '\x2', '\x2', 'g', 
		'h', '\a', '>', '\x2', '\x2', 'h', 'i', '\a', '?', '\x2', '\x2', 'i', 
		'\b', '\x3', '\x2', '\x2', '\x2', 'j', 'k', '\a', '@', '\x2', '\x2', 'k', 
		'\n', '\x3', '\x2', '\x2', '\x2', 'l', 'm', '\a', '@', '\x2', '\x2', 'm', 
		'n', '\a', '?', '\x2', '\x2', 'n', '\f', '\x3', '\x2', '\x2', '\x2', 'o', 
		'p', '\a', ']', '\x2', '\x2', 'p', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'q', 'r', '\a', '_', '\x2', '\x2', 'r', '\x10', '\x3', '\x2', '\x2', '\x2', 
		's', 't', '\a', '-', '\x2', '\x2', 't', '\x12', '\x3', '\x2', '\x2', '\x2', 
		'u', 'v', '\a', '/', '\x2', '\x2', 'v', '\x14', '\x3', '\x2', '\x2', '\x2', 
		'w', 'x', '\a', ',', '\x2', '\x2', 'x', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'y', 'z', '\a', '\x31', '\x2', '\x2', 'z', '\x18', '\x3', '\x2', '\x2', 
		'\x2', '{', '|', '\a', '\'', '\x2', '\x2', '|', '\x1A', '\x3', '\x2', 
		'\x2', '\x2', '}', '~', '\a', 'k', '\x2', '\x2', '~', '\x7F', '\a', 'p', 
		'\x2', '\x2', '\x7F', '\x80', '\a', 'v', '\x2', '\x2', '\x80', '\x81', 
		'\a', 't', '\x2', '\x2', '\x81', '\x82', '\a', 'g', '\x2', '\x2', '\x82', 
		'\x83', '\a', 'i', '\x2', '\x2', '\x83', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', '\x84', '\x85', '\a', 't', '\x2', '\x2', '\x85', '\x86', '\a', 
		'g', '\x2', '\x2', '\x86', '\x87', '\a', '\x63', '\x2', '\x2', '\x87', 
		'\x88', '\a', 'n', '\x2', '\x2', '\x88', '\x1E', '\x3', '\x2', '\x2', 
		'\x2', '\x89', '\x8A', '\a', 'v', '\x2', '\x2', '\x8A', '\x8B', '\a', 
		'g', '\x2', '\x2', '\x8B', '\x8C', '\a', 'z', '\x2', '\x2', '\x8C', '\x8D', 
		'\a', 'v', '\x2', '\x2', '\x8D', ' ', '\x3', '\x2', '\x2', '\x2', '\x8E', 
		'\x8F', '\a', '\x65', '\x2', '\x2', '\x8F', '\x90', '\a', '\x63', '\x2', 
		'\x2', '\x90', '\x91', '\a', 't', '\x2', '\x2', '\x91', '\x92', '\a', 
		'\x63', '\x2', '\x2', '\x92', '\x93', '\a', '\x65', '\x2', '\x2', '\x93', 
		'\x94', '\a', 'v', '\x2', '\x2', '\x94', '\x95', '\a', 'g', '\x2', '\x2', 
		'\x95', '\x96', '\a', 't', '\x2', '\x2', '\x96', '\"', '\x3', '\x2', '\x2', 
		'\x2', '\x97', '\x98', '\a', '\x64', '\x2', '\x2', '\x98', '\x99', '\a', 
		'q', '\x2', '\x2', '\x99', '\x9A', '\a', 'q', '\x2', '\x2', '\x9A', '\x9B', 
		'\a', 'n', '\x2', '\x2', '\x9B', '\x9C', '\a', 'g', '\x2', '\x2', '\x9C', 
		'\x9D', '\a', '\x63', '\x2', '\x2', '\x9D', '\x9E', '\a', 'p', '\x2', 
		'\x2', '\x9E', '$', '\x3', '\x2', '\x2', '\x2', '\x9F', '\xA0', '\a', 
		'\x65', '\x2', '\x2', '\xA0', '\xA1', '\a', 'k', '\x2', '\x2', '\xA1', 
		'\xA2', '\a', 'v', '\x2', '\x2', '\xA2', '\xA3', '\a', 'g', '\x2', '\x2', 
		'\xA3', '\xA4', '\a', 'u', '\x2', '\x2', '\xA4', '\xA5', '\a', 'v', '\x2', 
		'\x2', '\xA5', '\xA6', '\a', 'g', '\x2', '\x2', '\xA6', '&', '\x3', '\x2', 
		'\x2', '\x2', '\xA7', '\xA8', '\a', 'u', '\x2', '\x2', '\xA8', '\xA9', 
		'\a', '\x65', '\x2', '\x2', '\xA9', '\xAA', '\a', 't', '\x2', '\x2', '\xAA', 
		'\xAB', '\a', 'k', '\x2', '\x2', '\xAB', '\xAC', '\a', 'g', '\x2', '\x2', 
		'\xAC', '(', '\x3', '\x2', '\x2', '\x2', '\xAD', '\xAE', '\a', 'u', '\x2', 
		'\x2', '\xAE', '\xAF', '\a', '\x65', '\x2', '\x2', '\xAF', '\xB0', '\a', 
		't', '\x2', '\x2', '\xB0', '\xB1', '\a', 'k', '\x2', '\x2', '\xB1', '\xB2', 
		'\a', 'g', '\x2', '\x2', '\xB2', '\xB3', '\a', 'n', '\x2', '\x2', '\xB3', 
		'\xB4', '\a', 'p', '\x2', '\x2', '\xB4', '*', '\x3', '\x2', '\x2', '\x2', 
		'\xB5', '\xB6', '\a', '\x66', '\x2', '\x2', '\xB6', '\xB7', '\a', '\x63', 
		'\x2', '\x2', '\xB7', '\xB8', '\a', '\x65', '\x2', '\x2', '\xB8', '\xB9', 
		'\a', '\x63', '\x2', '\x2', '\xB9', ',', '\x3', '\x2', '\x2', '\x2', '\xBA', 
		'\xBB', '\a', '\x63', '\x2', '\x2', '\xBB', '\xBC', '\a', 'v', '\x2', 
		'\x2', '\xBC', '\xBD', '\a', 'w', '\x2', '\x2', '\xBD', '\xBE', '\a', 
		'p', '\x2', '\x2', '\xBE', '\xBF', '\a', '\x65', '\x2', '\x2', '\xBF', 
		'\xC0', '\a', 'k', '\x2', '\x2', '\xC0', '.', '\x3', '\x2', '\x2', '\x2', 
		'\xC1', '\xC2', '\a', '\x63', '\x2', '\x2', '\xC2', '\xC3', '\a', 'n', 
		'\x2', '\x2', '\xC3', '\xC4', '\a', 'v', '\x2', '\x2', '\xC4', '\xC5', 
		'\a', 'h', '\x2', '\x2', '\xC5', '\xC6', '\a', 'g', '\x2', '\x2', '\xC6', 
		'\xC7', '\a', 'n', '\x2', '\x2', '\xC7', '\x30', '\x3', '\x2', '\x2', 
		'\x2', '\xC8', '\xC9', '\a', '\x65', '\x2', '\x2', '\xC9', '\xCA', '\a', 
		'\x63', '\x2', '\x2', '\xCA', '\xCB', '\a', 'v', '\x2', '\x2', '\xCB', 
		'\xCC', '\a', '\"', '\x2', '\x2', '\xCC', '\xCD', '\a', 'v', '\x2', '\x2', 
		'\xCD', '\xCE', '\a', 'k', '\x2', '\x2', '\xCE', '\xCF', '\a', 'o', '\x2', 
		'\x2', '\xCF', '\xD0', '\a', 'r', '\x2', '\x2', '\xD0', '\x32', '\x3', 
		'\x2', '\x2', '\x2', '\xD1', '\xD2', '\a', 'g', '\x2', '\x2', '\xD2', 
		'\xD3', '\a', 'z', '\x2', '\x2', '\xD3', '\xD4', '\a', 'g', '\x2', '\x2', 
		'\xD4', '\xD5', '\a', '\x65', '\x2', '\x2', '\xD5', '\xD6', '\a', 'w', 
		'\x2', '\x2', '\xD6', '\xD7', '\a', 'v', '\x2', '\x2', '\xD7', '\xD8', 
		'\a', '\x63', '\x2', '\x2', '\xD8', '\x34', '\x3', '\x2', '\x2', '\x2', 
		'\xD9', '\xDA', '\a', 't', '\x2', '\x2', '\xDA', '\xDB', '\a', 'g', '\x2', 
		'\x2', '\xDB', '\xDC', '\a', 'r', '\x2', '\x2', '\xDC', '\xDD', '\a', 
		'g', '\x2', '\x2', '\xDD', '\xDE', '\a', 'v', '\x2', '\x2', '\xDE', '\xDF', 
		'\a', '\x63', '\x2', '\x2', '\xDF', '\x36', '\x3', '\x2', '\x2', '\x2', 
		'\xE0', '\xE1', '\a', 'r', '\x2', '\x2', '\xE1', '\xE2', '\a', '\x63', 
		'\x2', '\x2', '\xE2', '\xE3', '\a', 'p', '\x2', '\x2', '\xE3', '\xE4', 
		'\a', '\x63', '\x2', '\x2', '\xE4', '\xE5', '\a', '\"', '\x2', '\x2', 
		'\xE5', '\xE6', '\a', '\x65', '\x2', '\x2', '\xE6', '\xE7', '\a', '\x63', 
		'\x2', '\x2', '\xE7', '\xE8', '\a', 'p', '\x2', '\x2', '\xE8', '\xE9', 
		'\a', '\x66', '\x2', '\x2', '\xE9', '\x38', '\x3', '\x2', '\x2', '\x2', 
		'\xEA', '\xEB', '\a', 'r', '\x2', '\x2', '\xEB', '\xEC', '\a', 'g', '\x2', 
		'\x2', '\xEC', '\xED', '\a', 'p', '\x2', '\x2', '\xED', '\xEE', '\a', 
		'v', '\x2', '\x2', '\xEE', '\xEF', '\a', 't', '\x2', '\x2', '\xEF', '\xF0', 
		'\a', 'w', '\x2', '\x2', '\xF0', ':', '\x3', '\x2', '\x2', '\x2', '\xF1', 
		'\xF2', '\a', 'u', '\x2', '\x2', '\xF2', '\xF3', '\a', 'h', '\x2', '\x2', 
		'\xF3', '\xF4', '\a', '\x63', '\x2', '\x2', '\xF4', '\xF5', '\a', 't', 
		'\x2', '\x2', '\xF5', '\xF6', '\a', 'u', '\x2', '\x2', '\xF6', '\xF7', 
		'\a', 'k', '\x2', '\x2', '\xF7', '\xF8', '\a', 'v', '\x2', '\x2', '\xF8', 
		'<', '\x3', '\x2', '\x2', '\x2', '\xF9', '\xFA', '\a', 'u', '\x2', '\x2', 
		'\xFA', '\xFB', '\a', 'k', '\x2', '\x2', '\xFB', '>', '\x3', '\x2', '\x2', 
		'\x2', '\xFC', '\xFD', '\a', 'u', '\x2', '\x2', '\xFD', '\xFE', '\a', 
		'\x63', '\x2', '\x2', '\xFE', '\xFF', '\a', 'w', '\x2', '\x2', '\xFF', 
		'@', '\x3', '\x2', '\x2', '\x2', '\x100', '\x101', '\a', '#', '\x2', '\x2', 
		'\x101', '\x42', '\x3', '\x2', '\x2', '\x2', '\x102', '\x103', '\a', 'h', 
		'\x2', '\x2', '\x103', '\x104', '\a', 'w', '\x2', '\x2', '\x104', '\x105', 
		'\a', 'p', '\x2', '\x2', '\x105', '\x44', '\x3', '\x2', '\x2', '\x2', 
		'\x106', '\x107', '\a', '*', '\x2', '\x2', '\x107', '\x46', '\x3', '\x2', 
		'\x2', '\x2', '\x108', '\x109', '\a', '+', '\x2', '\x2', '\x109', 'H', 
		'\x3', '\x2', '\x2', '\x2', '\x10A', '\x10B', '\a', '>', '\x2', '\x2', 
		'\x10B', '\x10C', '\a', '/', '\x2', '\x2', '\x10C', 'J', '\x3', '\x2', 
		'\x2', '\x2', '\x10D', '\x10E', '\a', '?', '\x2', '\x2', '\x10E', 'L', 
		'\x3', '\x2', '\x2', '\x2', '\x10F', '\x118', '\a', '\x32', '\x2', '\x2', 
		'\x110', '\x114', '\t', '\x2', '\x2', '\x2', '\x111', '\x113', '\x5', 
		'[', '.', '\x2', '\x112', '\x111', '\x3', '\x2', '\x2', '\x2', '\x113', 
		'\x116', '\x3', '\x2', '\x2', '\x2', '\x114', '\x112', '\x3', '\x2', '\x2', 
		'\x2', '\x114', '\x115', '\x3', '\x2', '\x2', '\x2', '\x115', '\x118', 
		'\x3', '\x2', '\x2', '\x2', '\x116', '\x114', '\x3', '\x2', '\x2', '\x2', 
		'\x117', '\x10F', '\x3', '\x2', '\x2', '\x2', '\x117', '\x110', '\x3', 
		'\x2', '\x2', '\x2', '\x118', 'N', '\x3', '\x2', '\x2', '\x2', '\x119', 
		'\x11B', '\x5', '[', '.', '\x2', '\x11A', '\x119', '\x3', '\x2', '\x2', 
		'\x2', '\x11B', '\x11C', '\x3', '\x2', '\x2', '\x2', '\x11C', '\x11A', 
		'\x3', '\x2', '\x2', '\x2', '\x11C', '\x11D', '\x3', '\x2', '\x2', '\x2', 
		'\x11D', '\x11E', '\x3', '\x2', '\x2', '\x2', '\x11E', '\x122', '\a', 
		'\x30', '\x2', '\x2', '\x11F', '\x121', '\x5', '[', '.', '\x2', '\x120', 
		'\x11F', '\x3', '\x2', '\x2', '\x2', '\x121', '\x124', '\x3', '\x2', '\x2', 
		'\x2', '\x122', '\x120', '\x3', '\x2', '\x2', '\x2', '\x122', '\x123', 
		'\x3', '\x2', '\x2', '\x2', '\x123', '\x12C', '\x3', '\x2', '\x2', '\x2', 
		'\x124', '\x122', '\x3', '\x2', '\x2', '\x2', '\x125', '\x127', '\a', 
		'\x30', '\x2', '\x2', '\x126', '\x128', '\x5', '[', '.', '\x2', '\x127', 
		'\x126', '\x3', '\x2', '\x2', '\x2', '\x128', '\x129', '\x3', '\x2', '\x2', 
		'\x2', '\x129', '\x127', '\x3', '\x2', '\x2', '\x2', '\x129', '\x12A', 
		'\x3', '\x2', '\x2', '\x2', '\x12A', '\x12C', '\x3', '\x2', '\x2', '\x2', 
		'\x12B', '\x11A', '\x3', '\x2', '\x2', '\x2', '\x12B', '\x125', '\x3', 
		'\x2', '\x2', '\x2', '\x12C', 'P', '\x3', '\x2', '\x2', '\x2', '\x12D', 
		'\x132', '\a', '$', '\x2', '\x2', '\x12E', '\x131', '\x5', 'W', ',', '\x2', 
		'\x12F', '\x131', '\v', '\x2', '\x2', '\x2', '\x130', '\x12E', '\x3', 
		'\x2', '\x2', '\x2', '\x130', '\x12F', '\x3', '\x2', '\x2', '\x2', '\x131', 
		'\x134', '\x3', '\x2', '\x2', '\x2', '\x132', '\x133', '\x3', '\x2', '\x2', 
		'\x2', '\x132', '\x130', '\x3', '\x2', '\x2', '\x2', '\x133', '\x135', 
		'\x3', '\x2', '\x2', '\x2', '\x134', '\x132', '\x3', '\x2', '\x2', '\x2', 
		'\x135', '\x136', '\a', '$', '\x2', '\x2', '\x136', 'R', '\x3', '\x2', 
		'\x2', '\x2', '\x137', '\x13A', '\a', '\x61', '\x2', '\x2', '\x138', '\x13A', 
		'\x5', 'Y', '-', '\x2', '\x139', '\x137', '\x3', '\x2', '\x2', '\x2', 
		'\x139', '\x138', '\x3', '\x2', '\x2', '\x2', '\x13A', '\x140', '\x3', 
		'\x2', '\x2', '\x2', '\x13B', '\x13F', '\a', '\x61', '\x2', '\x2', '\x13C', 
		'\x13F', '\x5', 'Y', '-', '\x2', '\x13D', '\x13F', '\x5', '[', '.', '\x2', 
		'\x13E', '\x13B', '\x3', '\x2', '\x2', '\x2', '\x13E', '\x13C', '\x3', 
		'\x2', '\x2', '\x2', '\x13E', '\x13D', '\x3', '\x2', '\x2', '\x2', '\x13F', 
		'\x142', '\x3', '\x2', '\x2', '\x2', '\x140', '\x13E', '\x3', '\x2', '\x2', 
		'\x2', '\x140', '\x141', '\x3', '\x2', '\x2', '\x2', '\x141', 'T', '\x3', 
		'\x2', '\x2', '\x2', '\x142', '\x140', '\x3', '\x2', '\x2', '\x2', '\x143', 
		'\x145', '\a', '\xF', '\x2', '\x2', '\x144', '\x143', '\x3', '\x2', '\x2', 
		'\x2', '\x144', '\x145', '\x3', '\x2', '\x2', '\x2', '\x145', '\x146', 
		'\x3', '\x2', '\x2', '\x2', '\x146', '\x147', '\a', '\f', '\x2', '\x2', 
		'\x147', 'V', '\x3', '\x2', '\x2', '\x2', '\x148', '\x149', '\a', '^', 
		'\x2', '\x2', '\x149', '\x14A', '\t', '\x3', '\x2', '\x2', '\x14A', 'X', 
		'\x3', '\x2', '\x2', '\x2', '\x14B', '\x14C', '\t', '\x4', '\x2', '\x2', 
		'\x14C', 'Z', '\x3', '\x2', '\x2', '\x2', '\x14D', '\x14E', '\t', '\x5', 
		'\x2', '\x2', '\x14E', '\\', '\x3', '\x2', '\x2', '\x2', '\x14F', '\x150', 
		'\a', '\x31', '\x2', '\x2', '\x150', '\x151', '\a', '\x31', '\x2', '\x2', 
		'\x151', '\x155', '\x3', '\x2', '\x2', '\x2', '\x152', '\x154', '\v', 
		'\x2', '\x2', '\x2', '\x153', '\x152', '\x3', '\x2', '\x2', '\x2', '\x154', 
		'\x157', '\x3', '\x2', '\x2', '\x2', '\x155', '\x156', '\x3', '\x2', '\x2', 
		'\x2', '\x155', '\x153', '\x3', '\x2', '\x2', '\x2', '\x156', '\x158', 
		'\x3', '\x2', '\x2', '\x2', '\x157', '\x155', '\x3', '\x2', '\x2', '\x2', 
		'\x158', '\x159', '\a', '\f', '\x2', '\x2', '\x159', '\x15A', '\x3', '\x2', 
		'\x2', '\x2', '\x15A', '\x15B', '\b', '/', '\x2', '\x2', '\x15B', '^', 
		'\x3', '\x2', '\x2', '\x2', '\x15C', '\x15D', '\a', '\x31', '\x2', '\x2', 
		'\x15D', '\x15E', '\a', ',', '\x2', '\x2', '\x15E', '\x162', '\x3', '\x2', 
		'\x2', '\x2', '\x15F', '\x161', '\v', '\x2', '\x2', '\x2', '\x160', '\x15F', 
		'\x3', '\x2', '\x2', '\x2', '\x161', '\x164', '\x3', '\x2', '\x2', '\x2', 
		'\x162', '\x163', '\x3', '\x2', '\x2', '\x2', '\x162', '\x160', '\x3', 
		'\x2', '\x2', '\x2', '\x163', '\x165', '\x3', '\x2', '\x2', '\x2', '\x164', 
		'\x162', '\x3', '\x2', '\x2', '\x2', '\x165', '\x166', '\a', ',', '\x2', 
		'\x2', '\x166', '\x167', '\a', '\x31', '\x2', '\x2', '\x167', '\x168', 
		'\x3', '\x2', '\x2', '\x2', '\x168', '\x169', '\b', '\x30', '\x2', '\x2', 
		'\x169', '`', '\x3', '\x2', '\x2', '\x2', '\x16A', '\x16F', '\t', '\x6', 
		'\x2', '\x2', '\x16B', '\x16C', '\a', '\xF', '\x2', '\x2', '\x16C', '\x16F', 
		'\a', '\f', '\x2', '\x2', '\x16D', '\x16F', '\a', '\f', '\x2', '\x2', 
		'\x16E', '\x16A', '\x3', '\x2', '\x2', '\x2', '\x16E', '\x16B', '\x3', 
		'\x2', '\x2', '\x2', '\x16E', '\x16D', '\x3', '\x2', '\x2', '\x2', '\x16F', 
		'\x170', '\x3', '\x2', '\x2', '\x2', '\x170', '\x171', '\b', '\x31', '\x2', 
		'\x2', '\x171', '\x62', '\x3', '\x2', '\x2', '\x2', '\x12', '\x2', '\x114', 
		'\x117', '\x11C', '\x122', '\x129', '\x12B', '\x130', '\x132', '\x139', 
		'\x13E', '\x140', '\x144', '\x155', '\x162', '\x16E', '\x3', '\b', '\x2', 
		'\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace AntlrGenerated
