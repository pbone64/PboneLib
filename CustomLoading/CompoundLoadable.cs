using Terraria.ModLoader;

namespace PboneLib.CustomLoading
{
    public struct CompoundLoadable
    {
        public ILoadable AsLoadable => Content as ILoadable;
        public ICustomLoadable AsBetterLoadable => Content as ICustomLoadable;

        private object Content;

        public CompoundLoadable(object content)
        {
            Content = content;
        }
    }
}
