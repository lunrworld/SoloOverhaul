using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Tables;


namespace SoloOverhaul.Changes;

[Injectable(TypePriority = OnLoadOrder.PostLoad + 1)]
public class HideoutChanges(
    ISptLogger<HideoutChanges> logger,
    HideoutTable hideoutTable)
    : IOnLoad 
{
    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        RemoveHideoutTimers();        
        return Task.CompletedTask;
    }
    
    private void RemoveHideoutTimers()
    {
        foreach (var area in hideoutTable.Areas)
        {
            foreach (var stageKvP in area.Stages)
            {
                stageKvP.Value.ConstructionTime = 0;
            }
        }
        foreach (var recipe in hideoutTable.Production.Recipes)
        {
            recipe.ProductionTime = 0;
        }
    }
}
