namespace Kellphy.Warframe.AccountInfo.Models
{
    public class RelicModel
    {
        public class Drop
        {
            public double chance { get; set; }
            public string? location { get; set; }
            public string? rarity { get; set; }
            public string? type { get; set; }
        }

        public class Item
        {
            public string? name { get; set; }
            public string? uniqueName { get; set; }
            public WarframeMarket? warframeMarket { get; set; }
        }

        public class Location
        {
            public string? rarity { get; set; }
            public double chance { get; set; }
            public string? location { get; set; }
        }

        public class MarketInfo
        {
            public string? id { get; set; }
            public string? urlName { get; set; }
        }

        public class Patchlog
        {
            public string? name { get; set; }
            public DateTime date { get; set; }
            public string? url { get; set; }
            public string? additions { get; set; }
            public string? changes { get; set; }
            public string? fixes { get; set; }
        }

        public class Reward
        {
            public string? rarity { get; set; }
            public double chance { get; set; }
            public Item? item { get; set; }
        }

        public class Root
        {
            public string? category { get; set; }
            public string? description { get; set; }
            public string? imageName { get; set; }
            public List<Location>? locations { get; set; }
            public MarketInfo? marketInfo { get; set; }
            public bool masterable { get; set; }
            public string? name { get; set; }
            public List<Reward>? rewards { get; set; }
            public bool tradable { get; set; }
            public string? type { get; set; }
            public string? uniqueName { get; set; }
            public bool vaulted { get; set; }
            public List<Drop>? drops { get; set; }
            public List<Patchlog>? patchlogs { get; set; }
        }

        public class WarframeMarket
        {
            public string? id { get; set; }
            public string? urlName { get; set; }
        }
    }
}
