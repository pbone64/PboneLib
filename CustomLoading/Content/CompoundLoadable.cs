using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content
{
    public struct CompoundLoadable
    {
        public ILoadable AsLoadable => Content as ILoadable;
        public ICustomLoadable AsBetterLoadable => Content as ICustomLoadable;

        public readonly object Content;

        public CompoundLoadable(object content)
        {
            Content = content;
        }
    }
}
