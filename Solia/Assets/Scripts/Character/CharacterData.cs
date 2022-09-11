using System;

//data class for character stats
[Serializable]
public class CharacterData
{
    public CharacterBaseStats baseStats;
    public CharacterCurrentStats currentStats;

    //function that returns the damage given with an attack (parameter is % of damage to deal)
    public int attack(float attackPercent)
    {
        //minimum damage is 1
        return (int)Math.Max(attackPercent * currentStats.currentAttack, 1);
    }

    //function that returns if this character is currently alive
    public bool isAlive()
    {
        return currentStats.currentHealth <= 0;
    }

    //function that compute a damage taken (modulated using defense etc)
    public void takeDamage(int damage)
    {
        currentStats.currentHealth -= damage;
    }

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

        //base speed increase per level
        public int speedIncrease;

        //base speed
        public int speedValue;
    }

    //current stats of the character
    [Serializable]
    public class CharacterCurrentStats
    {
        public int currentAttack;
        public int currentDefense;
        public int currentHealth;
        public int currentSpeed;
    }
}