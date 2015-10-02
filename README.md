# RoslynPlayground
Personal project for playing around with Roslyn.


##Random Notes:

Syntax nodes are one of the primary elements of syntax trees. These nodes represent syntactic constructs such as declarations, statements, clauses, and expressions. Each category of syntax nodes is represented by a separate class derived from SyntaxNode.
Syntax tokens are the terminals of the language grammar, representing the smallest syntactic fragments of the code. They are never parents of other nodes or tokens. Syntax tokens consist of keywords, identifiers, literals, and punctuation.
Example: https://joshvarty.wordpress.com/2014/07/11/learn-roslyn-now-part-3-syntax-nodes-and-syntax-tokens/

Syntax Nodes:
	ClassDeclaration
	MethodDeclaration
	ParamteterList
	Block

Syntax Tokens:
	class
	SimpleClass
	Punctuation
	void
	SimpleMethod
	
	
Next: https://joshvarty.wordpress.com/2014/07/26/learn-roslyn-now-part-4-csharpsyntaxwalker/


Roslyn documentation:
https://roslyn.codeplex.com/wikipage?title=Overview&referringTitle=Documentation

Good examples:
http://www.strathweb.com/2015/09/using-roslyn-and-unit-tests-to-enforce-coding-guidelines-and-more/
