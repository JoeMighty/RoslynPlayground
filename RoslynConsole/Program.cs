using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tree = CSharpSyntaxTree.ParseText(@"
            public class MyClass
            {
                public string HelloWorld { get; set; }

                public void MyMethod()
                {
                }

                class MyInnerClass {
                }
            }");

            var syntaxRoot = tree.GetRoot();
            var myClass = syntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var myMethod = syntaxRoot.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            var myProperty = syntaxRoot.DescendantNodes().OfType<PropertyDeclarationSyntax>().First();


            List<ClassDeclarationSyntax> allClasses =
                syntaxRoot.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>().ToList();

            Console.WriteLine(myMethod.ReturnType.ToString());
            /*Console.WriteLine(MyClass.Identifier.ToString());
            Console.WriteLine(MyMethod.Identifier.ToString());
            Console.WriteLine(MyString.Identifier.ToString());*/

            Console.WriteLine("All Classes ----");
            foreach (ClassDeclarationSyntax classDeclarationSyntax in allClasses)
            {
                Console.WriteLine(classDeclarationSyntax.Identifier.ToString());
            }

            Console.ReadLine();
        }
    }
}