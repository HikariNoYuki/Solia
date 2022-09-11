using System.Collections.Generic;

using UnityEngine;

//class that manages a fight between two parties
public class FightManager : MonoBehaviour
{
    public enum Phase
    {
        PreFight,   //the phase before the fight (characters moving to their places)
        BetweenTurn,  // in between two turn, where everyone is charging it's bar
        WaitingAction  // Somemone is currently taking its turn, everyone else will wait
    }

    public Phase currentPhase { private set; get; } = Phase.PreFight;
    public Party partyOne;

    public Party partyTwo;

    //list of every character in this fight
    private List<CharacterTurnAdvancing> charactersTurn;

    //function used by a character to end its turn
    public void endTurn()
    {
        //check if a party is dead

        //continue turn
        currentPhase = Phase.BetweenTurn;
    }

    //function that will start a fight between the two selected parties
    public void startFight(Party friendlyParty, Party ennemyParty)
    {
        //set the parties
        partyOne = friendlyParty;
        partyTwo = ennemyParty;

        //set the fightManager of the parties
        friendlyParty.party.ForEach(character => character.setFightManager(this));
        ennemyParty.party.ForEach(character => character.setFightManager(this));

        //ask characters to move to their places
        //TODO with pathfinding

        //Start the fight
        currentPhase = Phase.BetweenTurn;
    }

    //function used by a character to take its turn
    public void takeTurn()
    {
        currentPhase = Phase.WaitingAction;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //if between turn, advance the turn orders to figure out whose turn it is
        if (currentPhase == Phase.BetweenTurn)
        {
            charactersTurn.ForEach(character => character.advance());
        }
    }

    private class CharacterTurnAdvancing
    {
        private CharacterFightController character;
        private int currentSpeedCounter;

        public CharacterTurnAdvancing(CharacterFightController toAssign)
        { character = toAssign; currentSpeedCounter = 0; }

        //advance the turn counter and return if it is now this character's turn
        public void advance()
        {
            currentSpeedCounter++;
        }

        //return if this is currently my turn, and reset the counter
        public bool myTurn()
        {
            if (currentSpeedCounter >= character.getCharacterData().currentStats.currentSpeed)
            {
                currentSpeedCounter = 0;
                return true;
            }
            return false;
        }
    }
}