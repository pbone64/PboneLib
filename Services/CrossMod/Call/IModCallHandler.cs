using System.Collections.Generic;

namespace PboneLib.Services.CrossMod.Call
{
    public interface IModCallHandler
    {
        string[] GetMessagesICanHandle();

        object Call(string message, List<object> args);
    }
}
