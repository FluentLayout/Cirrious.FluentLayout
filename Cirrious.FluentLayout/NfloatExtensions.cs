namespace System
{
	internal static class NfloatExtensions
	{
		public static nfloat GetValueOrDefault(this nfloat? value) => value.GetValueOrDefault(0);

		public static nfloat GetValueOrDefault(this nfloat? value, nfloat defaultValue) => null == value ? defaultValue : value.Value;
	}
}

