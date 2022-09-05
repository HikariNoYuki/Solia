using System;
using System.Collections.Generic;

using UnityEngine;

//data class that contains a party of character
[Serializable]
public class Party
{
    [Tooltip("The list of characters in the party")]
    [SerializeField] public List<CharacterFightController> party;
}