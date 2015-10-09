using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace RoslynConsole
{
    public static class WorkspaceSolution
    {
        public static IEnumerable<Document> LoadSolution(string solutionDir)
        {
            var solutionFilePath = Path.GetFullPath(solutionDir);

            MSBuildWorkspace workspace = MSBuildWorkspace.Create();
            Solution solution = workspace.OpenSolutionAsync(solutionFilePath).Result;

            var documents = new List<Document>();
            foreach (var projectId in solution.ProjectIds)
            {
                var project = solution.GetProject(projectId);
                foreach (var documentId in project.DocumentIds)
                {
                    Document document = solution.GetDocument(documentId);
                    if (document.SupportsSyntaxTree) documents.Add(document);
                }
            }

            return documents;
        }
    }
}