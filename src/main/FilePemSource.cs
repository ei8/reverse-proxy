using LettuceEncrypt;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ReverseProxy
{
    public class FilePemSource : ICertificateSource
    {
        public async Task<IEnumerable<X509Certificate2>> GetCertificatesAsync(CancellationToken cancellationToken)
        {
            var c1 = new X509Certificate2(File.ReadAllBytes("staging1.pem"));
            var c2 = new X509Certificate2(File.ReadAllBytes("staging2.pem"));
            return new X509Certificate2[] { c1, c2 };
        }
    }
}
