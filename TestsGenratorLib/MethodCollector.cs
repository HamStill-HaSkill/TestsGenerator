using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsGeneratorLib
{
    class MethodCollector : CSharpSyntaxWalker
    {
        public ICollection<MethodDeclarationSyntax> Methods { get; } = new List<MethodDeclarationSyntax>();
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (node.Modifiers.Any(x => x.IsKind(SyntaxKind.PublicKeyword)) && !node.Modifiers.Any(x => x.IsKind(SyntaxKind.AbstractKeyword)))
            {
                Methods.Add(node);
            }
        }
    }
}
