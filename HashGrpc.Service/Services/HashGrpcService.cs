using Grpc.Core;
using HashGrpc.Proto.Services;
using System.Security.Cryptography;
using System.Text;

namespace HashGrpc.Services
{
    public class HashGrpcService : Hasher.HasherBase
    {
        private readonly ILogger<HashGrpcService> _logger;
        public HashGrpcService(ILogger<HashGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<CalculateHashReply> CalculateSHA256(CalculateHashRequest request, ServerCallContext context)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(request.Data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return Task.FromResult(new CalculateHashReply
                {
                    Hash = builder.ToString()
                });
            }
        }

        public override Task<CalculateHashReply> CalculateSHA512(CalculateHashRequest request, ServerCallContext context)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(request.Data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return Task.FromResult(new CalculateHashReply
                {
                    Hash = builder.ToString()
                });
            }
        }

        public override Task<CalculateHashReply> CalculateMD5(CalculateHashRequest request, ServerCallContext context)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(request.Data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return Task.FromResult(new CalculateHashReply
                {
                    Hash = builder.ToString()
                });
            }
        }
    }
}