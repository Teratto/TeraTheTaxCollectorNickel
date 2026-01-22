using Nanoray.PluginManager;
using Nickel;

namespace TeraTaxMod;

internal interface IRegisterable
{
    static abstract void Register(IPluginPackage<IModManifest> package, IModHelper helper);
}