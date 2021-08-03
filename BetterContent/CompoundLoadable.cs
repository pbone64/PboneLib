using Terraria.ModLoader;

namespace PboneLib.BetterContent
{
    public struct CompoundLoadable
    {
        public ILoadable AsLoadable => Content as ILoadable;
        public IBetterLoadable AsBetterLoadable => Content as IBetterLoadable;

        private object Content;

        public CompoundLoadable(object content)
        {
            Content = content;
        }
    }
}
