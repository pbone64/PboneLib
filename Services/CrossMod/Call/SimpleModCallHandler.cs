using System;
using System.Collections.Generic;
using System.Linq;

namespace PboneLib.Services.CrossMod.Call
{
    public abstract class SimpleModCallHandler : IModCallHandler
    {
        public Dictionary<string, Func<List<object>, object>> CallFunctions;

        public SimpleModCallHandler()
        {
            CallFunctions = new Dictionary<string, Func<List<object>, object>>();
        }

        public string[] GetMessagesICanHandle() => CallFunctions.Keys.ToArray();

        public object Call(string message, List<object> args) => CallFunctions[message](args);
    }
}