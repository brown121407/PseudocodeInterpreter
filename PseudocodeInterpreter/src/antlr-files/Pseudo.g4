grammar Pseudo;

file: (stat NL)* stat ;

stat
	: varDecl                                                   #ToVarDecl
	| READ_BUILTIN ID (',' ID)* NL                              #ReadBuiltinStat
	| WRITE_BUILTIN expr (',' expr)*    #WriteBuiltinStat
	;
	
varDecl
	: type ID (ASSIGN expr)? #VariableDeclaration
	;
	
type
	: INT_TYPE 
	| FLOAT_TYPE 
	;

expr
	: INT       #Integer
	| FLOAT     #FloatingPoint
	;
	

INT_TYPE    
	: 'intreg'  
	;
	
FLOAT_TYPE  
	: 'real'    
	;
	
STRING_TYPE 
	: 'sir'     
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
