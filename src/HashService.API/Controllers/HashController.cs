using HashService.Application.Core;
using HashService.Grpc.Protos;
using Microsoft.AspNetCore.Mvc;

namespace HashService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HashController: ControllerBase
    {
        private readonly IHashLogic _hashLogic;

        public HashController(IHashLogic hashLogic)
        {
            _hashLogic = hashLogic;
        }

        [HttpPost("sha256")]
        public CalculateHashReply CalculateSHA256(CalculateHashRequest request)
        {
            var hash = _hashLogic.CalculateSHA256(request.Data);

            return new CalculateHashReply
            {
                Hash = hash
            };
        }

        [HttpPost("sha512")]
        public CalculateHashReply CalculateSHA512(CalculateHashRequest request)
        {
            var hash = _hashLogic.CalculateSHA512(request.Data);

            return new CalculateHashReply
            {
                Hash = hash
            };
        }

        [HttpPost("md5")]
        public CalculateHashReply CalculateMD5(CalculateHashRequest request)
        {
            var hash = _hashLogic.CalculateMD5(request.Data);

            return new CalculateHashReply
            {
                Hash = hash
            };
        }
    }
}
