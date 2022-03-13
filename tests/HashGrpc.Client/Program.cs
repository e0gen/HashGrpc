using Grpc.Net.Client;
using HashServices.Grpc.Protos;

using var channel = GrpcChannel.ForAddress("https://localhost:7135");

var client = new Hasher.HasherClient(channel);
Console.Write("Type string you want to hash: ");
string data = Console.ReadLine();

var sha256 = await client.CalculateSHA256Async(new CalculateHashRequest { Data = data });
var sha512 = await client.CalculateSHA512Async(new CalculateHashRequest { Data = data });
var md5    = await client.CalculateMD5Async(new CalculateHashRequest { Data = data });
Console.WriteLine("SHA256: " + sha256.Hash);
Console.WriteLine("SHA512: " + sha512.Hash);
Console.WriteLine("MD5:    " + md5.Hash);
Console.ReadKey();