using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecaFrameClientLib
{
	public class ExtendedCraftingRemoteDataItemComponent
	{
		public ComponentType componentType;
		public bool tradeable;
		public List<ExtendedCraftingRemoteDataItemComponent> components;
	}
}
