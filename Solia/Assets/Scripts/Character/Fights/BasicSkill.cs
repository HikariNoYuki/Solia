using System;
using System.Collections.Generic;

using UnityEngine;

public class BasicSkill
{
    [Tooltip("The actions that will be taken by this skill in order")]
    [SerializeField] protected List<Action> actions;

    [Tooltip("The name of the skill")]
    [SerializeField] protected string name;

    //getter
    public string getName() => name;

    //return if a target is needed to use this skill
    public bool isTargetNeeded() => actions.Exists(action => action.target == Action.Target.Single);

    //use this skill in the current fight
    public void useSkill(CharacterFightController caster, FightData fight, CharacterFightController target = null)
    {
        actions.ForEach(action =>
        {
            switch (action.target)
            {
                case Action.Target.Single:
                    //check if a target is set
                    if (target == null)
                    {
                        Debug.Log("[BasicSkill] Target has not been set on a targeted skill on skill " + name);
                        break;
                    }

                    //get the true value to use
                    float value = action.getTrueValue(caster.getCharacterData());

                    //use the correct action on the target
                    switch (action.type)
                    {
                        case Action.ActionTypes.Damage:
                            target.getCharacterData().takeDamage((int)value);
                            break;

                        case Action.ActionTypes.Heal:
                            target.getCharacterData().heal((int)value);
                            break;
                    }

                    break;

                case Action.Target.Self:
                    //TODO
                    break;

                case Action.Target.PartyWide:
                    //TODO
                    break;

                default:
                    Debug.Log("[BasicSkill] Action has a wrong target type : (" + action.target + "), on skill " + name);
                    break;
            }
        });
    }
}