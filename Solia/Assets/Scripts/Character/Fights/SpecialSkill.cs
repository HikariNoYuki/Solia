using System;

using UnityEngine;

[Serializable]
public class SpecialSkill : SkillBase
{
    [Tooltip("The amount of mana needed to use this skill")]
    [SerializeField] private int manaUse;

    public override void useSkill(CharacterFightController caster, FightData fight, CharacterFightController target = null)
    {
        //try to use the mana of the party
        if (!fight.getPartyOf(caster).useMana(manaUse))
        {
            //not enough mana to cast
            Debug.Log("[SpecialSkill] Not enough mana to cast (" + name + "), need " + manaUse + " has " + fight.getPartyOf(caster).currentMana);
            return;
        }

        base.useSkill(caster, fight, target);
    }
}