using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ConsoleExpandingMethodsOfWorkingWithWords_001
{
	static class Extesions
	{
		/// <summary>
		/// Метод, GetValueRefOrNullRef, позволяет обновлять значение по ключу, если оно существует:
		/// </summary>
		public static bool TryUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dict,
															TKey key,
															TValue value)
			where TKey : notnull
		{
			ref var dictVal = ref CollectionsMarshal.GetValueRefOrNullRef(dict, key);
			if (!Unsafe.IsNullRef(ref dictVal))
			{
				dictVal = value;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Метод CollectionsMarshal.GetValueRefOrAddDefault возвращает ссылку на значение, связанное с ключом, 
		/// и логическое значение, указывающее, существует ли ключ. 
		/// Поскольку метод возвращает ссылку, вы можете обновить значение:
		/// </summary>
		public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict,
															TKey key,
															TValue value)
			where TKey : notnull
		{
			ref var dictVal = ref CollectionsMarshal.GetValueRefOrAddDefault(dict, key, out var exists);
			if (exists)
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
				return dictVal;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
			dictVal = value;
			return value;
		}
	}
}
