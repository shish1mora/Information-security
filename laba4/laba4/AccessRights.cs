using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    public struct AccessRights
    {
        public Right fileServer;
        public Right databaseServer;
        public Right documentServer;
        public Right webServer;

        public AccessRights(Right fileServer, Right databaseServer, Right documentServer, Right webServer)
        {
            this.fileServer = fileServer;
            this.databaseServer = databaseServer;
            this.documentServer = documentServer;
            this.webServer = webServer;
        }
    }
}
