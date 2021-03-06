﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace ApplicationCore.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<LoggingBehaviour<TRequest>> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var claimName = _currentUserService.UserName;
            var userName = string.Empty;

            if (!string.IsNullOrEmpty(claimName))
            {
                userName = await _identityService.GetUserNameAsync(claimName);
            }

            _logger.LogInformation("MonolithicArchitectureWeb Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userName, userName, request);
        }
    }
}
