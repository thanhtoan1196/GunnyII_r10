using Game.Server.GameObjects;
using SqlDataProvider.Data;
using System;
namespace Game.Server.Quests
{
	public class ItemFusionCondition : BaseCondition
	{
		public ItemFusionCondition(BaseQuest quest, QuestConditionInfo info, int value) : base(quest, info, value)
		{
		}
		public override void AddTrigger(GamePlayer player)
		{
			player.ItemFusion += new GamePlayer.PlayerItemFusionEventHandle(this.player_ItemFusion);
		}
		private void player_ItemFusion(int fusionType)
		{
			if (fusionType == this.m_info.Para1 && base.Value > 0)
			{
				base.Value--;
			}
		}
		public override void RemoveTrigger(GamePlayer player)
		{
			player.ItemFusion -= new GamePlayer.PlayerItemFusionEventHandle(this.player_ItemFusion);
		}
		public override bool IsCompleted(GamePlayer player)
		{
			return base.Value <= 0;
		}
	}
}
