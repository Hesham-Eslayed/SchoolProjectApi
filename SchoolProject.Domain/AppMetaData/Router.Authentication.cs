namespace SchoolProject.Domain.AppMetaData;

public abstract partial class Router
{
	public abstract class Authentication
	{
		private const string Prefix = root + Vergion + "Authentications";

		public const string SignIn = Prefix + "/signin";
	}
}