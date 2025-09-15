namespace SchoolProject.Domain.Common;

public abstract class LocalizeEntity
{
	public static string? Localize(string? textAr, string? textEn)
	{
		var culture = Thread.CurrentThread.CurrentCulture;

		return culture.TwoLetterISOLanguageName.Equals("ar", StringComparison.OrdinalIgnoreCase) ? textAr : textEn;

	}
}