using SoloOverhaul.Patches;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;

namespace SoloOverhaul;

[Injectable(TypePriority = OnLoadOrder.Preload)]
public class PatchLoader : IOnLoad
{
    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        new RemoveMailClaimTimer().Enable();
        return Task.CompletedTask;
    }
}