using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Tables;
using SPTarkov.Server.Core.Services.Commerce;


namespace SoloOverhaul.Changes;

[Injectable(TypePriority = OnLoadOrder.PostLoad + 1)]
public class QuestChanges(
    ISptLogger<QuestChanges> logger,
    GlobalTable globalTable)
    : IOnLoad
{
    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        
        return Task.CompletedTask;
    }

}
