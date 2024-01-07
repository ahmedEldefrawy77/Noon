using B2Net;
using B2Net.Models;
using Microsoft.Extensions.Options;
using Noon.Application.Features.BackBlazeFeatures;

namespace Noon.Infrastructure.CloudServices
{
    public class BackBlaze : IBackBlaze
    {
        //private readonly B2Client _b2Client;
        //private readonly BackBlazeOptions _options;
        //private B2Options _b2Options;
        //public BackBlaze(B2Client b2Client ,IOptions<BackBlazeOptions> options )
        //{
        //    _options = options.Value;
        //    _b2Options = new()
        //    {
        //        KeyId = _options.AccountId,
        //        ApplicationKey = _options.ApplicationKey,
        //    };

        //    _b2Client = new B2Client(new B2AuthorizationProvider(_b2Options));

        //}
        //public async Task<string> UploadPhoto( string fileName, byte[] fileData, Guid productId)
        //{
        //    using var b2Client = new B2Client(new B2AuthorizationProvider(_b2Options));
        //    var bucket = await b2Client.Buckets.GetBucketByIdAsync(_b2Options.BucketId);

        //    // Concatenate the product ID to the file name as a pseudo-folder.
        //    var fullFileName = $"products/{productId}/{fileName}";

        //    // Use the Backblaze B2 SDK to upload the file.
        //    using var stream = new MemoryStream(photoBytes);
        //    await b2Client.Files.UploadFileAsync(bucket, fullFileName, stream);

        //    return fullFileName;
        //}
        //private async Task CreateFolderAsync(string bucketId, string folderName)
        //{
        //    await _b2Client.LargeFiles.
        //}
    }

}
