using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.UI;

namespace PboneLib.Core.UI
{
    public class UIManager
    {
        public class UserInterfaceInfo
        {
            public UserInterface UserInterface;
            public string LayerToInsertAt;

            public UserInterfaceInfo(UserInterface userInterface, string layerToInsertAt)
            {
                UserInterface = userInterface;
                LayerToInsertAt = layerToInsertAt;
            }
        }
        
        public Mod Mod;

        public Dictionary<Guid, UserInterfaceInfo> UserInterfaces;
        public Dictionary<UIState, Guid> UIStatesToInterfaceIds;

        public GameTime LastUpdateUIGameTime;

        public UIManager(Mod mod)
        {
            Mod = mod;

            UserInterfaces = new Dictionary<Guid, UserInterfaceInfo>();
            UIStatesToInterfaceIds = new Dictionary<UIState, Guid>();
        }

        public void UpdateUI(GameTime gameTime)
        {
            foreach (KeyValuePair<Guid, UserInterfaceInfo> kvp in UserInterfaces)
            {
                if (kvp.Value.UserInterface?.CurrentState != null)
                    kvp.Value.UserInterface?.Update(gameTime);
            }

            LastUpdateUIGameTime = gameTime;
        }

        public void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            foreach (KeyValuePair<Guid, UserInterfaceInfo> kvp in UserInterfaces)
            {
                int index = layers.FindIndex(layer => layer.Name == kvp.Value.LayerToInsertAt);
                if (index != -1)
                {
                    layers.Insert(index, new LegacyGameInterfaceLayer($"{Mod.Name}: Interface " + kvp.Key, delegate
                    {
                        if (LastUpdateUIGameTime != null && kvp.Value.UserInterface?.CurrentState != null)
                            kvp.Value.UserInterface.Draw(Main.spriteBatch, LastUpdateUIGameTime);

                        return true;
                    }, InterfaceScaleType.UI));
                }
            }
        }

        public void CreateInterface(Guid identifier, string layerToInsertAt)
        {
            UserInterfaces.Add(identifier, new UserInterfaceInfo(new UserInterface(), layerToInsertAt));
        }

        public Guid QuickCreateInterface(string layerToInsertAt)
        {
            Guid id = Guid.NewGuid();
            CreateInterface(id, layerToInsertAt);
            return id;
        }

        public void RegisterUI<T>(Guid interfaceId, string name, string layer) where T : UIState, new()
        {
            T t = new T();
            t.Activate();
            UIStatesToInterfaceIds.Add(t, interfaceId);
        }

        public void OpenUI<T>()
        {
            KeyValuePair<UIState, Guid> uiAndInterfaceId = UIStatesToInterfaceIds.First(kvp => kvp.Key.GetType() == typeof(T));
            UserInterfaces[uiAndInterfaceId.Value].UserInterface.SetState(uiAndInterfaceId.Key);
        }

        public void CloseUI<T>()
        {
            KeyValuePair<UIState, Guid> uiAndInterfaceId = UIStatesToInterfaceIds.First(kvp => kvp.Key.GetType() == typeof(T));
            UserInterfaces[uiAndInterfaceId.Value].UserInterface.SetState(null);
        }

        public void CloseInterface(Guid interfaceId)
        {
            UserInterfaces[interfaceId].UserInterface.SetState(null);
        }
    }
}
