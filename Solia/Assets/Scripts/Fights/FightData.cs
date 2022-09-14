using UnityEngine;

//data class about an ongoing fight
public class FightData
{
    [Tooltip("Ennemy party")]
    public Party ennemyParty;

    [Tooltip("Friendly party")]
    public Party friendlyParty;

    //return the party of the given character, null if not in any party in this fight
    public Party getPartyOf(CharacterFightController character)
    {
        if (ennemyParty.party.Exists(partyCharacter => partyCharacter == character))
        {
            return ennemyParty;
        }
        if (friendlyParty.party.Exists(partyCharacter => partyCharacter == character))
        {
            return friendlyParty;
        }
        Debug.Log("[FightData] Could not find the party of (" + character.name + ") in this fight");
        return null;
    }
}