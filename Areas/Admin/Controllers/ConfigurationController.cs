using Microsoft.AspNetCore.Mvc;
using Penguin.Cms.Configuration;
using Penguin.Cms.Configuration.Extensions;
using Penguin.Cms.Modules.Dynamic.Areas.Admin.Controllers;
using Penguin.Configuration.Abstractions.Interfaces;
using Penguin.Persistence.Abstractions.Interfaces;
using Penguin.Security.Abstractions.Constants;
using Penguin.Security.Abstractions.Interfaces;
using Penguin.Web.Security.Attributes;
using System;

namespace Penguin.Cms.Modules.Configuration.Areas.Admin.Controllers
{
    /// <summary>
    /// Administration controller used to manage CmsConfiguration objects
    /// </summary>
    [RequiresRole(RoleNames.SYS_ADMIN)]
    public class ConfigurationController : ObjectManagementController<CmsConfiguration>
    {
        /// <summary>
        /// A repository used to persist configurations
        /// </summary>
        protected IRepository<CmsConfiguration> ConfigurationRepository { get; set; }

        /// <summary>
        /// An IProvideConfigurations implementation used as a configuration source
        /// </summary>
        protected IProvideConfigurations ConfigurationService { get; set; }

        /// <summary>
        /// Constructs a new instance of the ConfigurationController
        /// </summary>
        /// <param name="configurationRepository">A repository used to persist configurations</param>
        /// <param name="configurationService">An IProvideConfigurations implementation used as a configuration source</param>
        /// <param name="serviceProvider">A ServiceProvider instance used for dependency injection</param>
        public ConfigurationController(IRepository<CmsConfiguration> configurationRepository, IProvideConfigurations configurationService, IServiceProvider serviceProvider, IUserSession userSession) : base(serviceProvider, userSession)
        {
            this.ConfigurationService = configurationService;
            this.ConfigurationRepository = configurationRepository;
        }

        /// <summary>
        /// Returns an editor for the requested configuration
        /// </summary>
        /// <param name="Name">The name of the configuration to edit</param>
        /// <param name="Value">Override the value displayed in the editor. Useful for defaults</param>
        /// <returns>The editor view</returns>
        public ActionResult EditByName(string Name, string? Value = null)
        {
            CmsConfiguration config = this.ConfigurationRepository.GetByName(Name) ??
                new CmsConfiguration()
                {
                    Name = Name,
                    Value = Value ?? this.ConfigurationService.GetConfiguration(Name)
                };

            return this.Edit(config);
        }
    }
}