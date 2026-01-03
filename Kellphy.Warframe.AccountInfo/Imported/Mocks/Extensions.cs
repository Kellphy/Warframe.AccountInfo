using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AlecaFrameClientLib
{
	public static class Extensions
	{
		public static bool GetValueOrDefault(this bool value)
		{
			return value;
		}

		public static bool GetValueOrDefault(this bool? value)
		{
			return value ?? false;
		}
	}
}
