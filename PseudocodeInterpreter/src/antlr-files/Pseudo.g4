grammar Pseudo;

file: stat (NL stat)* ;

stat
	: varDecl                                                   #ToVarDecl
	| READ_BUILTIN ID (',' ID)* NL                              #ReadBuiltinStat
	| WRITE_BUILTIN expr (',' expr)*                            #WriteBuiltinStat
	;
	
varDecl
	: type ID (ASSIGN expr)? #VariableDeclaration
	;
	
varAssign
	: ID ASSIGN expr        #VariableAssignment
	;
	
type
	: INT_TYPE 
	| FLOAT_TYPE 
	| STRING_TYPE
	;

expr
	: plusOrMinus		#ToPlusOrMinus
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
	
END     
	: 'sfarsit' 
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
	: [ \t\r\n]+            -> skip 
	;
