using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArtSwap : MonoBehaviour
{
    Image myImage;
    Button myButton;

    Sprite OnImage;
    Sprite OffImage;

    private void Awake()
    {
        myImage = gameObject.GetComponent<Image>();
        OnImage = myImage.sprite;
        myButton = gameObject.GetComponent<Button>();
        OffImage = myButton.spriteState.pressedSprite;

        myButton.onClick.AddListener(OnButtonPressSwap);
    }

    public void OnButtonPressSwap() {
        Sprite filler = OnImage;
        OnImage = OffImage;
        OffImage = filler;

        myImage.sprite = OnImage;
    }
}
