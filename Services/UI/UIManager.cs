using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.UI;

namespace PboneLib.Services.UI
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
            if (!Main.dedServ)
                UserInterfaces.Add(identifier, new UserInterfaceInfo(new UserInterface(), layerToInsertAt));
        }

        public Guid QuickCreateInterface(string layerToInsertAt)
        {
            if (!Main.dedServ)
            {
                Guid id = Guid.NewGuid();
                CreateInterface(id, layerToInsertAt);
                return id;
            }

            return default;
        }

        public void RegisterUI<T>(Guid interfaceId) where T : UIState, new()
        {
            if (!Main.dedServ)
            {
                T t = new T();
                t.Activate();
                UIStatesToInterfaceIds.Add(t, interfaceId);
            }
        }

        public void OpenUI<T>() where T : UIState
        {
            if (!Main.dedServ)
            {
                KeyValuePair<UIState, Guid> uiAndInterfaceId = GetUIStateAndId<T>();
                UserInterfaces[uiAndInterfaceId.Value].UserInterface.SetState(uiAndInterfaceId.Key);
            }
        }

        public void CloseUI<T>() where T : UIState
        {
            if (!Main.dedServ)
            {
                KeyValuePair<UIState, Guid> uiAndInterfaceId = GetUIStateAndId<T>();
                CloseInterface(uiAndInterfaceId.Value);
            }
        }

        public void CloseInterface(Guid interfaceId)
        {
            if (!Main.dedServ)
            {
                UserInterfaces[interfaceId].UserInterface.SetState(null);
            }
        }

        public void ToggleUI<T>() where T : UIState
        {
            if (!Main.dedServ)
            {
                KeyValuePair<UIState, Guid> uiAndInterfaceId = GetUIStateAndId<T>();
                UserInterface userInterface = UserInterfaces[uiAndInterfaceId.Value].UserInterface;

                if (userInterface.CurrentState == null)
                    OpenUI<T>();
                else
                    CloseUI<T>();
            }
        }

        public KeyValuePair<UIState, Guid> GetUIStateAndId<T>() where T : UIState => UIStatesToInterfaceIds.First(kvp => kvp.Key.GetType() == typeof(T));
        public T GetUIState<T>() where T : UIState => GetUIStateAndId<T>().Key as T;
    }
}
