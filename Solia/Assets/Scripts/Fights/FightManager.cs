using UnityEngine;

//class that manages a fight between two parties
public class FightManager : MonoBehaviour
{
    public Party partyOne;
    public Party partyTwo;

    //function that will start a fight between the two selected parties
    public void startFight(Party friendlyParty, Party ennemyParty)
    {
        //set the parties
        partyOne = friendlyParty;
        partyTwo = ennemyParty;

        //ask characters to move to their places
        //TODO with pathfinding
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