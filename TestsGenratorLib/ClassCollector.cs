using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsGeneratorLib
{
    class ClassCollector : CSharpSyntaxWalker
    {
        public ICollection<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            if ((node.Modifiers.Any(x => x.IsKind(SyntaxKind.PublicKeyword)) && !node.Modifiers.Any(x => x.IsKind(SyntaxKind.AbstractKeyword))) || node.Modifiers.Count == 0)
            {
                Classes.Add(node);
            }
        }
    }
}
