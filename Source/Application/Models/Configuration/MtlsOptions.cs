namespace Application.Models.Configuration
{
	public class MtlsOptions
	{
		#region Properties

		public virtual string HostPrefix { get; set; } = "mtls.";
		public virtual int Port { get; set; } = 5000;

		#endregion
	}
}