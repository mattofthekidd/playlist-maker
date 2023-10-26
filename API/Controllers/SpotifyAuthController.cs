using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers {
    public class SpotifyAuthController : BaseApiController {
        interface Response {
            string Code { get; set; }
            string State { get; set; }
        }
        private readonly ILogger<SpotifyAuthController> _logger;

        public SpotifyAuthController(ILogger<SpotifyAuthController> logger) {
            _logger = logger;
        }

        public void StoreUserToken(string s) {

        }

    }
}