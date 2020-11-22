using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Platform
{
    public enum Types
    {
        NoObsVariant,
        ObsVariant, 
        NoJumpVariant, 
        BonusVariant
    }

    public List<GameObject> NoObsVariant;
    public List<GameObject> ObsVariant;
    public List<GameObject> NoJumpVariant;
    public List<GameObject> BonusVariant;
}
