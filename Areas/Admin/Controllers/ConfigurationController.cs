using Microsoft.AspNetCore.Mvc;
using Penguin.Cms.Configuration;
using Penguin.Cms.Configuration.Extensions;
using Penguin.Cms.Modules.Dynamic.Areas.Admin.Controllers;
using Penguin.Configuration.Abstractions.Interfaces;
using Penguin.Persistence.Abstractions.Interfaces;
using Penguin.Security.Abstractions.Constants;
using Penguin.Web.Security.Attributes;
using System;

namespace Penguin.Cms.Modules.Configuration.Areas.Admin.Controllers
{
    [RequiresRole(RoleNames.SysAdmin)]
    public class ConfigurationController : ObjectManagementController<CmsConfiguration>
    {
        protected IRepository<CmsConfiguration> ConfigurationRepository { get; set; }
        protected IProvideConfigurations ConfigurationService { get; set; }

        public ConfigurationController(IRepository<CmsConfiguration> configurationRepository, IProvideConfigurations configurationService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.ConfigurationService = configurationService;
            this.ConfigurationRepository = configurationRepository;
        }

        public ActionResult EditByName(string Name)
        {
            CmsConfiguration config = this.ConfigurationRepository.GetByName(Name) ??
                new CmsConfiguration()
                {
                    Name = Name,
                    Value = this.ConfigurationService.GetConfiguration(Name)
                };

            return this.Edit(config);
        }
    }
}