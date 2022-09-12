using System;

using UnityEngine;

[Serializable]
public class Action
{
    //Types of actions available
    public enum ActionTypes
    {
        Damage,
        Heal
    }

    public enum StatScaling
    {
        Flat,
        Attack,
        Defense,
        CurrentHealth,
        MaxHealth
    }

    //the target of the action
    public enum Target
    {
        Single,
        PartyWide,
        Self
    }

    [Tooltip("The stat on which this scales")]
    public StatScaling scaling;

    [Tooltip("The target of the action")]
    public Target target;

    [Tooltip("The type of action to be made")]
    public ActionTypes type;

    [Tooltip("The value of the action (depends on the stats scaling, percentage for stats, flat value otherwise)")]
    public float value;

    //get the value to use for this action depending on the caster
    public float getTrueValue(CharacterData caster)
    {
        //get the true value to use
        float value = 0;
        switch (scaling)
        {
            case Action.StatScaling.Flat:
                return value;

            case Action.StatScaling.Attack:
                return value * caster.currentStats.currentAttack;

            case Action.StatScaling.Defense:
                return value * caster.currentStats.currentDefense;

            case Action.StatScaling.CurrentHealth:
                return value * caster.currentStats.currentHealth;

            case Action.StatScaling.MaxHealth:
                return value * caster.currentStats.currentMaxHealth;

            default:
                Debug.Log("[Action] Action scaling has an unexpected value of (" + scaling + ")");
                return 0;
        }
    }
}