namespace VP.Algorithm.Search.Array.Extensions;
internal static class Throw
{
	public static void ArgumentException(String message)
		=> throw new ArgumentException(message);

	public static void ArgumentNullException(String paramName)
		=> throw new ArgumentNullException(paramName);

	public static void ArgumentOutOfRangeException(String paramName)
		=> throw new ArgumentOutOfRangeException(paramName);

	public static void NotImplementException()
		=> throw new NotImplementedException();
}
