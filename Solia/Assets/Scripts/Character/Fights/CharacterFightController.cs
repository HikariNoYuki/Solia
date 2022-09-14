using System;
using System.Collections.Generic;

using UnityEngine;

public class CharacterFightController : MonoBehaviour
{
    private enum Phase
    {
        Loading,
        TakingTurn
    }

    //Party of this instance (auto set)
    public PartyComponent myParty { get; set; }

    public const int SPEED_BAR_MAX = 1000;

    [Tooltip("Data of the character")]
    [SerializeField] protected CharacterData characterData;

    [Tooltip("The basic skills list of this character")]
    [SerializeField] private List<BasicSkill> basicSkills;

    //current phase of this character
    private Phase currentPhase = Phase.Loading;

    //current value of the speed bar
    private int currentSpeedBar = 0;

    //FightManager of the current fight (null if not in a fight)
    private FightManager fightManager = null;

    [Tooltip("The special skills list of this character")]
    [SerializeField] private List<SpecialSkill> specialSkills;

    //getter
    public CharacterData getCharacterData() => characterData;

    public FightManager getFightManager() => fightManager;

    //setter
    public void setFightManager(FightManager value)
    {
        if (fightManager != null)
        {
            Debug.Log("Character is already in a fight ! ");
            return;
        }
        fightManager = value;
    }

    //function that takes a turn (needs to be overriden)
    protected virtual void takeTurn()
    {
        currentPhase = Phase.TakingTurn;
    }

    private void FixedUpdate()
    {
        //if in a fight, load the bar
        if (fightManager != null && fightManager.currentPhase == FightManager.Phase.BetweenTurn && currentPhase == Phase.Loading)
        {
            currentSpeedBar += characterData.currentStats.currentSpeed;

            //if bar is fully loaded
            if (currentSpeedBar >= SPEED_BAR_MAX)
            {
                //take the turn
                fightManager.takeTurn();
                currentSpeedBar -= SPEED_BAR_MAX;
                takeTurn();
            }
        }
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