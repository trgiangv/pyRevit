using System.Collections.Generic;
using System.Linq;
using pyRevitLabs.Common.Extensions;

namespace pyRevitLabs.PyRevit {
    public class PyRevitDeployment {
        public PyRevitDeployment(string name, IEnumerable<string> paths) {
            Name = name;
            Paths = paths.ToList();
        }

        public override string ToString() {
            return $"PyRevitDeployment Name: \"{Name}\" | Paths: \"{Paths.ConvertToCommaSeparatedString()}\"";
        }

        public string Name { get; private set; }
        public List<string> Paths { get; private set; }
    }
}
