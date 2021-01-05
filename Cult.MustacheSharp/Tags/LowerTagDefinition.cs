﻿using System.Collections.Generic;
using System.IO;
using Cult.MustacheSharp.Mustache;

// ReSharper disable All 
namespace Cult.MustacheSharp.Tags
{
    public class LowerTagDefinition : InlineTagDefinition
    {
        public LowerTagDefinition()
                    : base("lower")
        {
        }

        protected override IEnumerable<TagParameter> GetParameters()
        {
            return new[] { new TagParameter("param") { IsRequired = true } };
        }

        public override void GetText(TextWriter writer, Dictionary<string, object> arguments, Scope context)
        {
            writer.Write(arguments["param"].ToString().ToLowerInvariant());
        }
    }
}
