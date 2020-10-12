using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sciptables/MenuUIconfig", fileName = "New UI Config")]
public class MenuUIDataScriptable : ScriptableObject
{
    //blueprint for UI scriptables

    public string[] playerNames;

    public float FadeOutTime;
    public float FadeInTime;

    [Tooltip("Less is faster")]
    public float MenuPopUpTime;
    public float MenuHideTime;
    
    public Sound music;
    public Sound buttonSound;
}
