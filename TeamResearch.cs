namespace Oxide.Plugins
{
    [Info("Team Research", "johnytoxic", "0.1.0")]
    [Description("Shares research across your team")]
    class TeamResearch : CovalencePlugin
    {
        private RelationshipManager _relationshipManager;
        private void Init()
        {
            _relationshipManager = RelationshipManager.Instance;
        }

        void OnTechTreeNodeUnlocked(Workbench workbench, TechTreeData.NodeInstance node, BasePlayer player)
        {
            var team = _relationshipManager.FindPlayersTeam(player.userID);
            if (null != team)
            {
                foreach (ulong member in team.members)
                {
                    BasePlayer memberPlayer = BasePlayer.FindByID(member);
                    memberPlayer.blueprints.Unlock(node.itemDef);
                }
            }
        }
    }
}
