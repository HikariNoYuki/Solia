using System;

//data class for character stats
[Serializable]
public class CharacterData
{
    public CharacterBaseStats baseStats;
    public CharacterCurrentStats currentStats;

    //base stats of the character (does not change during play)
    [Serializable]
    public class CharacterBaseStats
    {
        //attack increase per level
        public int attackIncrease;

        //base attack value
        public int attackValue;

        //defense increase per level
        public int defenseIncrease;

        //base defense
        public int defenseValue;

        //health increase per level
        public int healthIncrease;

        //base max health
        public int maxHealth;
    }

    //current stats of the character
    [Serializable]
    public class CharacterCurrentStats
    {
        public int currentAttack;
        public int currentDefense;
        public int currentHealth;
    }
}