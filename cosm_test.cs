using KindredCommands.Data;
using ProjectM;
using ProjectM.Shared;
using VampireCommandFramework;

namespace cosmetic.Commands;
internal class CosmeticCommands

     [Command("wolf", description: "Make youself a wolf. Or not one.", adminOnly: false)]
    public static void WolfCommand(ChatCommandContext ctx)
    {
        if (!BuffUtility.TryGetBuff(Core.EntityManager, ctx.Event.SenderCharacterEntity, Prefabs.Buff_General_Shapeshift_Werewolf_Standard, out var buffEntity))
        {
            Buffs.AddBuff(ctx.Event.SenderUserEntity, ctx.Event.SenderCharacterEntity, Prefabs.Buff_General_Shapeshift_Werewolf_Standard, -1, false);
            ctx.Reply("You are now a wolf!");
        }
        else
        {
            DestroyUtility.Destroy(Core.EntityManager, buffEntity, DestroyDebugReason.TryRemoveBuff);
            ctx.Reply("You are no longer a wolf!");
        }
    }
