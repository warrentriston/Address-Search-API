using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationService.Entities
{
    public class Location
    {
        private string Address;
        private string City;
        private string State;
        private int Zip;

        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }
        }

        public string city
        {
            get
            {
                return City;
            }
            set
            {
                City = value;
            }
        }

        public string state
        {
            get
            {
                return State;
            }
            set
            {
                State = value;
            }
        }

        public int zip
        {
            get
            {
                return Zip;
            }
            set
            {
                Zip = value;
            }
        }
    }
}