using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkManager : MonoBehaviour
{

     public List<PerkData> LockedPerks = new List<PerkData>(); // lista de perks blocate
    public List<PerkData> UnlockedPerks = new List<PerkData>(); // lista de perks blocate
    public List<PerkData> activePerks = new List<PerkData>();

    public List<PerkData> GetActivePerks()
    {
        return activePerks; // returnează lista actuală de perks
    }
}