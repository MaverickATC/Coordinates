using System;
using System.Collections.Generic;
using System.Text;

namespace Coordinates
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
