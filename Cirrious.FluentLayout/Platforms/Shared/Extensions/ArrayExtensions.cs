namespace Cirrious.FluentLayouts.Touch.Extensions
{
	internal static class ArrayExtensions
	{
		public static bool TryGetElement<T>(this T[] array, int index, out T element)
		{
			if (array == null)
			{
				element = default(T);

				return false;
			}

			if (index < array.Length)
			{
				element = array[index];

				return true;
			}

			element = default(T);

			return false;
		}
	}
}