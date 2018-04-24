using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dotlib.Parser
{
    public partial class RoleParser : IParsable<List<string>>
    {
        public string ApplicationName { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

        protected Regex Regex = new Regex(@"^[A-Za-z].*:[A-Za-z].*$");
    }

    public partial class RoleParser : IParsable<List<string>>
    {
        public RoleParser(string roles = "")
        {
            if (string.IsNullOrEmpty(roles) || !Regex.IsMatch(roles))
            {
                return;
            }

            var splitted = roles.Split(':');
            ApplicationName = splitted[0];
            ParseRoles(splitted[1]);
        }

        protected void ParseRoles(string roles)
        {
            var splitted = roles.Split(',');
            foreach (var role in splitted)
            {
                if (!string.IsNullOrEmpty(role))
                {
                    Roles.Add(role);
                }
            }
        }

        public bool IsParsed() => !string.IsNullOrEmpty(ApplicationName) && !Roles.Count.Equals(0);

        public List<string> GetParsed() => Roles;
    }
}
