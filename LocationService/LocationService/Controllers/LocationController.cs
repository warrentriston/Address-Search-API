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
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace LocationService.Controllers
{
    public class LocationController : ApiController
    {
        ResponseMessage response = new ResponseMessage();
        IDataBaseAccess databaseOperations = new DatabaseOperations();
        ResourceManager rmLocationService = new ResourceManager("LocationService.LocationService", Assembly.GetExecutingAssembly());
        /// <summary>
        /// This method will retrieve records from the database based on filter text
        /// </summary>
        /// <param name="searchText">Text based on which the records will be filtered</param>
        /// <param name="sortBy">Records will be sorted based on alphabetical or Frequency</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string searchText, string sortBy = "alpha")
        {
            response.action = rmLocationService.GetString("searchFromDatabase");
            if(searchText?.Length > 2)
            {
                try
                {
                    if(sortBy.ToLower().Equals("alpha"))
                    {
                        response.responseStatus = rmLocationService.GetString("successStatus");
                        response.message = rmLocationService.GetString("noRecordsFound");
                        List<Location> addressedAlphabeticalSorted = databaseOperations.getLocation(searchText);
                        return addressedAlphabeticalSorted.Any() ? ControllerContext.Request.CreateResponse(HttpStatusCode.OK, addressedAlphabeticalSorted) : ControllerContext.Request.CreateResponse(HttpStatusCode.OK, response); ;
                    }
                    else if (sortBy.ToLower().Equals("frequency"))
                    {
                        response.responseStatus = rmLocationService.GetString("successStatus");
                        response.message = rmLocationService.GetString("noRecordsFound");
                        var addressedFrequencySorted = databaseOperations.getLocation(searchText).OrderByDescending(location => Regex.Matches(location.address, searchText).Count * 1 + Regex.Matches(location.city, searchText).Count * 2 + Regex.Matches(location.state, searchText).Count * 3);
                        return addressedFrequencySorted.Any() ? ControllerContext.Request.CreateResponse(HttpStatusCode.OK, addressedFrequencySorted) : ControllerContext.Request.CreateResponse(HttpStatusCode.OK, response); ;
                    }
                    else
                    {
                        response.responseStatus = rmLocationService.GetString("successStatus");
                        response.message = rmLocationService.GetString("incorrectSortingOption");
                        return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, response);
                    }
                }
                catch (Exception exception)
                {
                    response.responseStatus = rmLocationService.GetString("failureStatus");
                    response.message = exception.Message;
                    return ControllerContext.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
                }
            }
            else
            {
                response.responseStatus = rmLocationService.GetString("successStatus");
                response.message = rmLocationService.GetString("IncorrectNumberOfCharacters");
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
            response.action = rmLocationService.GetString("insertToDatabase");
            try
            {
                databaseOperations.setLocation(addresses);
                response.responseStatus = rmLocationService.GetString("successStatus");
                response.message = rmLocationService.GetString("insertedSuccessfully");
                return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception exception)
            {
                response.responseStatus = rmLocationService.GetString("failureStatus");
                response.message = exception.Message;
                return ControllerContext.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
