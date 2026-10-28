using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Spt.Tables;
using SPTarkov.Server.Core.Utils;
using SPTarkov.Server.Core.Utils.Collections;
using SPTarkov.Server.Core.Utils.Json;


namespace SoloOverhaul;

[Injectable(TypePriority = OnLoadOrder.PostLoad + 1)]
public class EditDatabaseValues(
    ISptLogger<EditDatabaseValues> logger,
    GlobalTable globalTable,
    HideoutTable hideoutTable)
    : IOnLoad 
{

    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        RemoveFlea();

        RemoveHideoutTimers();        

        return Task.CompletedTask;
    }
    
    private void RemoveFlea()
    {
        globalTable.Configuration.RagFair.MinUserLevel = 99;
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
