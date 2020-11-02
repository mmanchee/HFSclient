using System.Collections.Generic;
using HFSclient.Models;

namespace HFSclient.ViewModels
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }

        public ApplicationUser[] Everyone { get; set;}
    }
}