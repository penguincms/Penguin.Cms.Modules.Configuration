﻿using Penguin.Cms.Modules.Core.ComponentProviders;
using Penguin.Cms.Modules.Core.Navigation;
using Penguin.Navigation.Abstractions;
using Penguin.Security.Abstractions;
using Penguin.Security.Abstractions.Interfaces;
using System.Collections.Generic;
using RoleNames = Penguin.Security.Abstractions.Constants.RoleNames;

namespace Penguin.Cms.Modules.Configuration.ComponentProviders
{
    public class AdminNavigationMenuProvider : NavigationMenuProvider
    {
        public override INavigationMenu GenerateMenuTree()
        {
            return new NavigationMenu()
            {
                Name = "Admin",
                Text = "Admin",
                Children = new List<INavigationMenu>() {
                            new NavigationMenu()
                            {
                                Text = "Configuration",
                                Name = "ConfigAdmin",
                                Icon = "settings_applications",
                                Href = "/Admin/Configuration/Index",
                                Permissions = new List<ISecurityGroupPermission>()
                                {
                                    this.CreatePermission(RoleNames.SysAdmin, PermissionTypes.Read | PermissionTypes.Write)
                                }
                            }
                    }
            };
        }
    }
}