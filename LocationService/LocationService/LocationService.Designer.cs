﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocationService {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LocationService {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocationService() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LocationService.LocationService", typeof(LocationService).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failure.
        /// </summary>
        internal static string failureStatus {
            get {
                return ResourceManager.GetString("failureStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expecting 3 or more characters.
        /// </summary>
        internal static string IncorrectNumberOfCharacters {
            get {
                return ResourceManager.GetString("IncorrectNumberOfCharacters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expecting correct sorting option (Alphabetical or Frequency).
        /// </summary>
        internal static string incorrectSortingOption {
            get {
                return ResourceManager.GetString("incorrectSortingOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Locations added successfully.
        /// </summary>
        internal static string insertedSuccessfully {
            get {
                return ResourceManager.GetString("insertedSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert Into Database.
        /// </summary>
        internal static string insertToDatabase {
            get {
                return ResourceManager.GetString("insertToDatabase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Records Found.
        /// </summary>
        internal static string noRecordsFound {
            get {
                return ResourceManager.GetString("noRecordsFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search From Database.
        /// </summary>
        internal static string searchFromDatabase {
            get {
                return ResourceManager.GetString("searchFromDatabase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Success.
        /// </summary>
        internal static string successStatus {
            get {
                return ResourceManager.GetString("successStatus", resourceCulture);
            }
        }
    }
}
