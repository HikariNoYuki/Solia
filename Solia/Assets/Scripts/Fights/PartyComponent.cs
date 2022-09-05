using UnityEngine;

//monobehavior used to define a party in the game
public class PartyComponent : MonoBehaviour
{
    [Tooltip("The composition of the party")]
    [SerializeField] private Party party;

    public void addToParty(CharacterFightController character)
    {
        character.myParty = this;
        party.party.Add(character);
    }

    // Start is called before the first frame update
    private void Start()
    {
        //associate every party member with this
        foreach (CharacterFightController character in party.party)
        {
            character.myParty = this;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}