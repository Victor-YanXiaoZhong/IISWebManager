﻿using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;

namespace IISWebManager.Infrastructure.Handlers.Query.Applications
{
    public class GetApplicationHandler : IQueryHandler<GetApplication, ApplicationGetDto>
    {
        private readonly ISiteFacade _siteFacade;
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;

        public GetApplicationHandler(ISiteFacade siteFacade, IApplicationFacade applicationFacade, IMapper mapper)
        {
            _siteFacade = siteFacade;
            _applicationFacade = applicationFacade;
            _mapper = mapper;
        }
        public ApplicationGetDto Handle(GetApplication query)
        {
            query.ThrowIfNull(GetType().Name);
            var site = _siteFacade.GetSite(query.SiteName);
            site.ThrowIfNull(query.SiteName);
            var application = _applicationFacade.GetApplication(query.ApplicationName, site);
            application.ThrowIfNull(query.ApplicationName);
            var applicationDto = _mapper.Map<ApplicationGetDto>(application);

            return applicationDto;
        }
    }
}