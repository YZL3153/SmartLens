﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SmartLens.Client;

namespace SmartLens.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageDetectedController : ControllerBase
    {

        private readonly IClient _client;

        private const int Port = 11000;

        private const string Ip = "127.0.0.1";

        public ImageDetectedController(IClient client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("Detected")]
        public async Task<IActionResult> Detected(string image)
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Parse(Ip), Port);

            var result = await _client.SendData(ipEndPoint,image);

            var encodingToString = Encoding.UTF7.GetString(result);

            return Ok(encodingToString);
        }
    }
}
