using UnityEngine;

public class CharacterFightController : MonoBehaviour
{
    //Party of this instance (auto set)
    public PartyComponent myParty { get; set; }

    [Tooltip("Data of the character")]
    [SerializeField] protected CharacterData characterData;

    //getter
    public CharacterData getCharacterData() => characterData;

    //ask the character to play its round
    public virtual void play(FightData fight)
    {
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}