using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsGeneratorLib
{
    class NamespaceCollector : CSharpSyntaxWalker
    {
        public ICollection<NamespaceDeclarationSyntax> Namespaces { get; } = new List<NamespaceDeclarationSyntax>();
        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            Namespaces.Add(node);
        }
    }
}
