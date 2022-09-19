using System;

using UnityEngine;

[Serializable]
public class BasicSkill : SkillBase
{
    [Tooltip("The amount of mana regenerated when this skill is used")]
    [SerializeField] private int manaRegen;

    public override void useSkill(CharacterFightController caster, FightData fight, CharacterFightController target = null)
    {
        base.useSkill(caster, fight, target);
        //regen the mana of the party of the caster
        fight.getPartyOf(caster).regenMana(manaRegen);
    }
}