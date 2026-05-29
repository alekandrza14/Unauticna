using UnrealBuildTool;

public class UnauticnaCastleTarget : TargetRules
{
	public UnauticnaCastleTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		ExtraModuleNames.Add("UnauticnaCastle");
	}
}
