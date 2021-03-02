using EPiServer.DataAnnotations;
using EPiServer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Business
{
    [GroupDefinitions]
    public class SiteTabNames
    {
        [Display(Order = 100)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Metadata = "Metadata";

        [Display(Order = 110)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string SiteOptions = "Site Options";

        [Display(Order = 120)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string EmployeeDetails = "Employee Details";

        [Display(Order = 130)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string YourCustomTabName3 = "Your Custom Tab Name 3";
    }
}