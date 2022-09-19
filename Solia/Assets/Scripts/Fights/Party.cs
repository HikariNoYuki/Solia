using System;
using System.Collections.Generic;

using UnityEngine;

//data class that contains a party of character
[Serializable]
public class Party
{
    public int currentMana;

    [Tooltip("The maximum mana of the party")]
    [SerializeField] public int maxMana;

    [Tooltip("The list of characters in the party")]
    [SerializeField] public List<CharacterFightController> party;

    public Party()
    {
        currentMana = maxMana;
    }

    //regen the mana of the party by a certain amount
    public void regenMana(int amount)
    {
        currentMana = Math.Min(maxMana, currentMana + amount);
    }

    //try to use a certain amount of mana, return is succesful (return false if not enough mana to cast)
    public bool useMana(int amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            return true;
        }
        return false;
    }
}