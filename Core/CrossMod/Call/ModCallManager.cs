using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace PboneLib.Core.CrossMod.Call
{
    public class ModCallManager
    {
        public Mod Mod;

        public Dictionary<Type, IModCallHandler> ModCallHandlersByType;
        public Dictionary<string, Type> ModCallHandlerTypesByMessage;

        public ModCallManager(Mod mod)
        {
            Mod = mod;

            ModCallHandlersByType = new Dictionary<Type, IModCallHandler>();
            ModCallHandlerTypesByMessage = new Dictionary<string, Type>();
        }

        public void RegisterHandler<T>() where T : IModCallHandler, new() => ModCallHandlersByType.Add(typeof(T), new T());

        public void MapModCallHandlersToMessages()
        {
            string[] messages;

            foreach (KeyValuePair<Type, IModCallHandler> handler in ModCallHandlersByType)
            {
                messages = handler.Value.GetMessagesICanHandle();

                foreach (string s in messages)
                {
                    ModCallHandlerTypesByMessage.Add(s, handler.Key);
                }
            }
        }

        public object HandleCall(object[] args)
        {
            ParseArgs(args, out string message, out List<object> parsedArgs);

            IModCallHandler handler = ModCallHandlersByType[ModCallHandlerTypesByMessage[message]];

            return handler.Call(message, parsedArgs);
        }

        public void ParseArgs(object[] args, out string message, out List<object> parsedArgs)
        {
            if (!(args[0] is string s))
            {
                throw new ArgumentException("The first parameter of Mod.Call must be a string for all " + Mod.Name + " calls.");
            }
            else
            {
                message = s;
                parsedArgs = args.ToList();
                parsedArgs.RemoveAt(0);
            }
        }

        public IModCallHandler GetCallHandler<T>() => GetCallHandler(typeof(T));
        public IModCallHandler GetCallHandler(Type t) => ModCallHandlersByType[t];
    }
}
