using Grpc.Core;
using HashService.Application.Core;
using HashService.Grpc.Protos;

namespace HashService.Grpc.Services
{
    public class HashServiceGrpc : Hasher.HasherBase
    {
        private readonly ILogger<HashServiceGrpc> _logger;
        private readonly IHashLogic _hashLogic;

        public HashServiceGrpc(ILogger<HashServiceGrpc> logger, IHashLogic hashLogic)
        {
            _logger = logger;
            _hashLogic = hashLogic;
        }

        public override Task<CalculateHashReply> CalculateSHA256(CalculateHashRequest request, ServerCallContext context)
        {
            var hash = _hashLogic.CalculateSHA256(request.Data);

            return Task.FromResult(new CalculateHashReply
            {
                Hash = hash
            });
        }

        public override Task<CalculateHashReply> CalculateSHA512(CalculateHashRequest request, ServerCallContext context)
        {
            var hash = _hashLogic.CalculateSHA512(request.Data);

            return Task.FromResult(new CalculateHashReply
            {
                Hash = hash
            });
        }

        public override Task<CalculateHashReply> CalculateMD5(CalculateHashRequest request, ServerCallContext context)
        {
            var hash = _hashLogic.CalculateMD5(request.Data);

            return Task.FromResult(new CalculateHashReply
            {
                Hash = hash
            });
        }
    }
}