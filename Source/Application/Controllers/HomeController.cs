using System;
using System.Threading.Tasks;
using Application.Models.Configuration;
using Application.Models.Views.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Controllers
{
	public class HomeController : Controller
	{
		#region Constructors

		public HomeController(IHostEnvironment hostEnvironment, ILoggerFactory loggerFactory, IOptionsMonitor<MtlsOptions> mtlsOptionsMonitor)
		{
			this.HostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
			this.Logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(this.GetType());
			this.MtlsOptionsMonitor = mtlsOptionsMonitor ?? throw new ArgumentNullException(nameof(mtlsOptionsMonitor));
		}

		#endregion

		#region Properties

		protected internal virtual IHostEnvironment HostEnvironment { get; }
		protected internal virtual ILogger Logger { get; }
		protected internal virtual IOptionsMonitor<MtlsOptions> MtlsOptionsMonitor { get; }

		#endregion

		#region Methods

		public virtual async Task<IActionResult> Certificate()
		{
			var mtlsOptions = this.MtlsOptionsMonitor.CurrentValue;

			// ReSharper disable InvertIf
			if(!this.Request.Host.Value.StartsWith(mtlsOptions.HostPrefix, StringComparison.OrdinalIgnoreCase))
			{
				var host = new Uri($"{this.Request.Scheme}{Uri.SchemeDelimiter}{this.Request.Host}").Host;

				return this.Redirect($"{this.Request.Scheme}{Uri.SchemeDelimiter}{mtlsOptions.HostPrefix}{host}:{mtlsOptions.Port}{this.Request.Path}");
			}
			// ReSharper restore InvertIf

			return await Task.FromResult(this.Redirect("~/"));
		}

		public virtual async Task<IActionResult> Index()
		{
			var model = new HomeViewModel
			{
				ClientCertificate = this.HttpContext.Connection.ClientCertificate,
				HostEnvironment = this.HostEnvironment
			};

			return await Task.FromResult(this.View(model));
		}

		#endregion
	}
}