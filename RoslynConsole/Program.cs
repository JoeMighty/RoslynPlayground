using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynConsole
{
    internal class Program
    {

/*
        static void Main(string[] args)
        {
            string solutionFile = @"S:\source\dotnet\SimpleApp\SimpleApp.sln";
            IWorkspace workspace = Workspace.LoadSolution(solutionFile);
            var proj = workspace.CurrentSolution.Projects.First();
            var doc = proj.Documents.First();
            var root = (CompilationUnitSyntax)doc.GetSyntaxRoot();
            var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            foreach (var decl in classes)
            {
                ProcessClass(decl);
            }
            Console.ReadKey();

        }
*/

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
            var MyClass = syntaxRoot.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var MyMethod = syntaxRoot.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            
            var MyString = syntaxRoot.DescendantNodes().OfType<PropertyDeclarationSyntax>().First();


            List<ClassDeclarationSyntax> allClasses = syntaxRoot.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>().ToList();

            Console.WriteLine(MyMethod.ReturnType.ToString());
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
