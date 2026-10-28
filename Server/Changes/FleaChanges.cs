using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Tables;


namespace SoloOverhaul.Changes;

[Injectable(TypePriority = OnLoadOrder.PostLoad + 1)]
public class FleaChanges(
    ISptLogger<FleaChanges> logger,
    GlobalTable globalTable)
    : IOnLoad
{
    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        globalTable.Configuration.RagFair.MinUserLevel = 99;
        return Task.CompletedTask;
    }

}
