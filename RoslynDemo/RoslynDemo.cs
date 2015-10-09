using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using Shouldly;

namespace RoslynConsole
{
    [TestFixture]
    public class RoslynDemo
    {
        private readonly IEnumerable<Document> documents;

        public RoslynDemo()
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "RoslynFun.sln");
            documents = WorkspaceSolution.LoadSolution(fullPath);
        }

        [TestCase(2)]
        public void Methods_ShouldNotHaveTooManyParams(int totalParams)
        {
            List<MethodDeclarationSyntax> methods = this.documents.SelectMany(x => x.GetSyntaxRootAsync().Result.DescendantNodes().OfType<MethodDeclarationSyntax>()).ToList();
            foreach (MethodDeclarationSyntax methodDeclarationSyntax in methods)
            {
                ParameterListSyntax parameterList = methodDeclarationSyntax.ParameterList;

                // Assert
                parameterList.Parameters.Count.ShouldBeLessThanOrEqualTo(totalParams, "File Location: " + methodDeclarationSyntax.Identifier.SyntaxTree.FilePath);
            }
        }
    }
}