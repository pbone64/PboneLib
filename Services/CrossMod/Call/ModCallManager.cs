using System;
using System.Collections.Generic;
using System.Linq;

namespace PboneLib.Services.CrossMod.Call
{
    public class ModCallManager
    {
        public Dictionary<Type, IModCallHandler> ModCallHandlersByType;
        public Dictionary<string, Type> ModCallHandlerTypesByMessage;

        public ModCallManager()
        {
            ModCallHandlersByType = new Dictionary<Type, IModCallHandler>();
            ModCallHandlerTypesByMessage = new Dictionary<string, Type>();
        }

        public void RegisterHandler<T>() where T : IModCallHandler, new()
        {
            T handler = new T();
            ModCallHandlersByType.Add(typeof(T), handler);

            string[] messages = handler.GetMessagesICanHandle();

            foreach (string s in messages)
            {
                ModCallHandlerTypesByMessage.Add(s, typeof(T));
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
            if (args[0] is not string s)
            {
                throw new ArgumentException("The first parameter of Mod.Call must be a string for all PboneLib powered calls.");
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
