using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationService.Entities
{
    public class ResponseMessage
    {
        private string Action;
        private string ResponseStatus;
        private string Message;

        public string action
        {
            get
            {
                return Action;
            }
            set
            {
                Action = value;
            }
        }

        public string responseStatus
        {
            get
            {
                return ResponseStatus;
            }
            set
            {
                ResponseStatus = value;
            }
        }

        public string message
        {
            get
            {
                return Message;
            }
            set
            {
                Message = value;
            }
        }
    }
}