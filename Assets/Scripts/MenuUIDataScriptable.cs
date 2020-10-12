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

    public float MenuPopUpSpeed;
    public float MenuHideSpeed;
    
    public Sound music;
    public Sound buttonSound;
}
