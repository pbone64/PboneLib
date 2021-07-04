using System.Collections.Generic;

namespace PboneLib.Core.CrossMod.Call
{
    public interface IModCallHandler
    {
        string[] GetMessagesICanHandle();

        object Call(string message, List<object> args);
    }
}
