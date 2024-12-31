using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    public class User
    {
        public string name;
        public AccessRights rights;

        public User(string name, AccessRights rights)
        {
            this.name = name;
            this.rights = rights;
        }

        public override string ToString()
        {
            return $"{name}: {rights.fileServer}; {rights.databaseServer}; {rights.documentServer}; {rights.webServer}";
        }
    }
}
