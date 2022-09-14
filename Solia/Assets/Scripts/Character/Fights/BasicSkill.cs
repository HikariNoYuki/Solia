using System;

using UnityEngine;

public class BasicSkill : SkillBase
{
    [Tooltip("The amount of mana regenerated when this skill is used")]
    [SerializeField] private int manaRegen;
}