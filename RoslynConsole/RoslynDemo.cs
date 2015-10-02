using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using NUnit.Framework;
using Shouldly;

namespace RoslynConsole
{
    [TestFixture]
    public class RoslynDemo
    {
        private readonly IList<Document> documents;

        public RoslynDemo()
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "RoslynFun.sln");
            var slnPath =Path.GetFullPath(fullPath);

            var workspace = MSBuildWorkspace.Create();
            var solution = workspace.OpenSolutionAsync(slnPath).Result;

            documents = new List<Document>();

            foreach (var projectId in solution.ProjectIds)
            {
                var project = solution.GetProject(projectId);
                foreach (var documentId in project.DocumentIds)
                {
                    var document = solution.GetDocument(documentId);
                    if (document.SupportsSyntaxTree)
                    {
                        documents.Add(document);
                    }
                }
            }
        }

        [Test]
        public void Interfaces_ShouldBePrefixedWithI()
        {
            var interfaces = this.documents.SelectMany(x => x.GetSyntaxRootAsync().Result.DescendantNodes().OfType<InterfaceDeclarationSyntax>()).ToList();
            interfaces.All(x => x.Identifier.ToString().StartsWith("I")).ShouldBeTrue();
        }

        [Test]
        public void Methods_ShouldNotHaveTooManyParams()
        {
            var methods = this.documents.SelectMany(x => x.GetSyntaxRootAsync().Result.DescendantNodes().OfType<MethodDeclarationSyntax>()).ToList();
            foreach (ParameterListSyntax parameterList in methods.Select(methodDeclarationSyntax => methodDeclarationSyntax.ParameterList))
            {
                parameterList.Parameters.Count.ShouldBeLessThan(3);
            }
        }
    }
}