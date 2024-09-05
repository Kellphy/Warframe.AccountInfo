using AlecaFrameClientLib.Data.Types;

namespace AlecaFrameClientLib
{
	public class DataHandler
	{
		public WarframeRootObject warframeRootObject;
		public Dictionary<string, List<ExtendedCraftingRemoteDataItemComponent>> tradeableCraftingPartsByUID = new Dictionary<string, List<ExtendedCraftingRemoteDataItemComponent>>();
		public Dictionary<string, List<ExtendedCraftingRemoteDataItemComponent>> nonTradeableCraftingPartsByUID = new Dictionary<string, List<ExtendedCraftingRemoteDataItemComponent>>();
	}
}
