grammar Pseudo;

file
	: statList;

statList
	: stat (NL stat)*;

stat
	: varDecl                                                   
	| varAssign													
	| ifStat
	| whileStat                                           
	| forStat
	| writeBuiltin
	| readBuiltin									
	;
	
ifStat
	: IF boolOp THEN NL statList NL (elseIfStat)* elseStat? END
	;

elseIfStat
	: ELSE IF boolOp THEN NL statList NL
	;

elseStat
	: ELSE NL statList NL
	;
	
whileStat
	: WHILE boolOp EXEC NL statList NL END
	;

forStat
	: FOR varAssign ',' expr EXEC NL statList NL END
	;

readBuiltin
	: READ_BUILTIN ID (',' ID)*
	;
	
writeBuiltin
	: (WRITE_BUILTIN | WRITELN_BUILTIN) expr (',' expr)*
	;
	
varDecl
	: type optionalAssign (',' optionalAssign)* #VariableDeclaration
	;

optionalAssign
	: ID (ASSIGN expr)?		
	;
	
varAssign
	: ID ASSIGN expr 
	;
	
type
	: INT_TYPE 
	| FLOAT_TYPE 
	| STRING_TYPE
	;

boolOp
	: LP boolOp RP			#ParanBoolOp
	| NOT LP boolOp RP		#NegateBoolOp
	| boolOp AND boolOp		#AndOp
	| boolOp OR  boolOp		#OrOp
	| plusOrMinus (NOT)? EQUAL plusOrMinus	#AreEqual
	| plusOrMinus '<'  plusOrMinus	#LessThan
	| plusOrMinus '<=' plusOrMinus	#LessOrEqual
	| plusOrMinus '>'  plusOrMinus	#GreaterThan
	| plusOrMinus '>=' plusOrMinus	#GreaterOrEqual
	;

expr
	: plusOrMinus		#ToPlusOrMinus
	| '[' plusOrMinus ']' #WholePart
	| STRING			#String
	;
	
plusOrMinus 
    : plusOrMinus '+' multOrDiv   # Add
    | plusOrMinus '-' multOrDiv   # Sub
    | multOrDiv                   # ToMultOrDiv
    ;

multOrDiv
    : multOrDiv '*' unarySign   # Mult
    | multOrDiv '/' unarySign   # Div
    | multOrDiv '%' unarySign   # Modulo
    | unarySign                 # ToUnarySign
    ;

	
unarySign
	: '+' unarySign    #UnaryPlus
	| '-' unarySign    #UnaryMinus
	| atom             #ToAtom
	;	

atom
	: INT                   #Integer
	| FLOAT                 #FloatingPoint
	| ID                    #GetVariable
	| LP plusOrMinus RP     #ToParenPlusOrMinus
	;

INT_TYPE    
	: 'intreg'  
	;
	
FLOAT_TYPE  
	: 'real'    
	;
	
STRING_TYPE 
	: 'text'     
	;
	
CHAR_TYPE   
	: 'caracter'
	;
	
BOOL_TYPE   
	: 'boolean' 
	;

READ_BUILTIN    
	: 'citeste' 
	;
	
WRITE_BUILTIN   
	: 'scrie'   
	;
	
WRITELN_BUILTIN
	: 'scrieln'
	;

IF      
	: 'daca' 
	;
	
THEN    
	: 'atunci' 
	;
	
ELSE    
	: 'altfel' 
	;
	
WHILE   
	: 'cat timp' 
	;
	
EXEC    
	: 'executa' 
	;
	
REPEAT  
	: 'repeta' 
	;
	
UNTIL   
	: 'pana cand' 
	;

FOR
	: 'pentru'
	;
	
END     
	: 'sfarsit' 
	;

AND
	: 'si'
	;

OR
	: 'sau'
	;

NOT
	: '!'
	;
	
FUNCTION
	: 'fun' 
	;
	
LP      
	: '(' 
	;
	
RP      
	: ')' 
	;

ASSIGN
	: '<-'
	;
	
EQUAL
	: '='
	;

INT 
	: '0' 
	| [1-9] DIGIT*
	;
	
FLOAT   
	: DIGIT+ '.' DIGIT* 
	| '.' DIGIT+
	;
	
STRING 
	: '"' ( ESC | . )*? '"' 
	;
	
ID  
	: ('_' | LETTER) ('_' | LETTER | DIGIT)* 
	;
	
NL  
	: ('\r')? '\n'
	;

fragment 
ESC 
	: '\\' [btnr"\\] 
	;
	
fragment 
LETTER 
	: [a-zA-Z] 
	;
	
fragment 
DIGIT  
	: [0-9] 
	;

LINE_COMMENT
	: '//' .*? '\n'   -> skip 
	;
	
COMMENT     
	: '/*' .*? '*/'         -> skip 
	;
	
WS          
	: (' ' | '\t' | '\r\n' | '\n')            -> skip 
	;
