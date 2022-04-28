using Microsoft.Xna.Framework;
using PboneLib.CustomLoading.Content;
using System.Reflection;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace PboneLib.CustomModTypes
{
    public abstract class ModChatTag : ModType, ITagHandler
    {
        private static MethodInfo ChatManager_Register = typeof(ChatManager).GetMethod(nameof(ChatManager.Register));

        public abstract string[] Names { get; }

        public abstract TextSnippet Parse(string text, Color baseColor = default, string options = null);

        public sealed override void SetupContent()
        {   
            ChatManager_Register.MakeGenericMethod(GetType()).Invoke(null, new object[] { Names });

            base.SetupContent();
        }

        protected sealed override void Register()
        {
            ModTypeLookup<ModChatTag>.Register(this);
        }
    }
}
    