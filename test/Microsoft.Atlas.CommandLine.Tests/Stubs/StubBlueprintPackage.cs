// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Atlas.CommandLine.Blueprints;

namespace Microsoft.Atlas.CommandLine.Tests.Stubs
{
    public class StubBlueprintPackage : IBlueprintPackage
    {
        public IDictionary<string, string> Files { get; set; } = new Dictionary<string, string>();

        public string Location { get; set; }

        TextReader IBlueprintPackage.OpenText(string path) => Files.TryGetValue(path, out var text) ? new StringReader(text) : null;

        bool IBlueprintPackage.Exists(string path) => Files.ContainsKey(path);

        public IEnumerable<string> GetGeneratedPaths() => Enumerable.Empty<string>();
    }
}
