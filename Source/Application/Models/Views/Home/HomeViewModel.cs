using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Hosting;

namespace Application.Models.Views.Home
{
	public class HomeViewModel
	{
		#region Properties

		public virtual X509Certificate2 ClientCertificate { get; set; }
		public virtual IHostEnvironment HostEnvironment { get; set; }

		#endregion
	}
}