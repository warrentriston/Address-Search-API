using LocationService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationService.Interfaces
{
    public interface IDataBaseAccess
    {
        void setLocation(List<Location> addresses);
        List<Location> getLocation(string searchText);
    }
}