using UnityEngine;
using TMPro;

public class CharacterNames : MonoBehaviour
{
    [SerializeField]
    int myIndex;

    [SerializeField]
    TextMeshProUGUI myText;

    //characters grab their names from parser by themselves
    private void Start()
    {
        myText.text = ScriptableConfigParser.instance.GetActorName(myIndex);
    }
}
