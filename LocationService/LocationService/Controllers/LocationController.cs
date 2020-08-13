using LocationService.Entities;
using LocationService.Interfaces;
using LocationService.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace LocationService.Controllers
{
    public class LocationController : ApiController
    {
        ResponseMessage response = new ResponseMessage();
        IDataBaseAccess databaseOperations = new DatabaseOperations();
        /// <summary>
        /// This method will retrieve records from the database based on filter text
        /// </summary>
        /// <param name="searchText">Text based on which the records will be filtered</param>
        /// <param name="sortBy">Records will be sorted based on alphabetical or Frequency</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string searchText, string sortBy = "alpha")
        {
            response.action = "Search From Database";
            if(searchText?.Length > 2)
            {
                try
                {
                    if(sortBy.ToLower().Equals("alpha"))
                    {
                        response.responseStatus = "Success";
                        response.message = "No records found";
                        List<Location> addressedAlphabeticalSorted = databaseOperations.getLocation(searchText);
                        return addressedAlphabeticalSorted.Any() ? ControllerContext.Request.CreateResponse(HttpStatusCode.OK, addressedAlphabeticalSorted) : ControllerContext.Request.CreateResponse(HttpStatusCode.OK, response); ;
                    }
                    else if (sortBy.ToLower().Equals("frequency"))
                    {
                        response.responseStatus = "Success";
                        response.message = "No records found";
                        var addressedFrequencySorted = databaseOperations.getLocation(searchText).OrderByDescending(x => Regex.Matches(x.address, searchText).Count * 1 + Regex.Matches(x.city, searchText).Count * 2 + Regex.Matches(x.state, searchText).Count * 3);
                        return addressedFrequencySorted.Any() ? ControllerContext.Request.CreateResponse(HttpStatusCode.OK, addressedFrequencySorted) : ControllerContext.Request.CreateResponse(HttpStatusCode.OK, response); ;
                    }
                    else
                    {
                        response.responseStatus = "Success";
                        response.message = "Expecting correct sorting option Alphabetical or Frequency";
                        return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, response);
                    }
                }
                catch (Exception exception)
                {
                    response.responseStatus = "Failure";
                    response.message = exception.Message;
                    return ControllerContext.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
                }
            }
            else
            {
                response.responseStatus = "Success";
                response.message = "Expecting 3 or more characters";
                return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        /// <summary>
        /// This method will add new records into the database
        /// </summary>
        /// <param name="addresses">List of locations</param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] List<Location> addresses)
        {
            response.action = "Insert Into Database";
            try
            {
                databaseOperations.setLocation(addresses);
                response.responseStatus = "Success";
                response.message = "Locations added successfully ";
                return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception exception)
            {
                response.responseStatus = "Failure";
                response.message = exception.Message;
                return ControllerContext.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
