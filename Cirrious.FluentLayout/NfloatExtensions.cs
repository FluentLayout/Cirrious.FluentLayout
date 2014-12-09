namespace System
{
	internal static class NfloatExtensions
	{
		public static nfloat GetValueOrDefault(this nfloat? value)
		{
			return value.GetValueOrDefault(0);
		}

		public static nfloat GetValueOrDefault(this nfloat? value, nfloat defaultValue)
		{
			return null == value ? defaultValue : value.Value;
		}
	}
}

