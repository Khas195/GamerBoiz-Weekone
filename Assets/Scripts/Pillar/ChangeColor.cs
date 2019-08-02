using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer hostSprite;

    [SerializeField]
    Color highlightedColor;
    [SerializeField]
    Color normalColor;    // Start is called before the first frame update
    Color targetColor;
    [SerializeField]
    float followPercentage;
    void Start()
    {
        targetColor = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        var currentColor = hostSprite.color;
        currentColor.r = Ultilities.CalculateAsymptoticAverage(currentColor.r, targetColor.r, followPercentage);
        currentColor.b = Ultilities.CalculateAsymptoticAverage(currentColor.b, targetColor.b, followPercentage);
        currentColor.g = Ultilities.CalculateAsymptoticAverage(currentColor.g, targetColor.g, followPercentage);
        hostSprite.color = currentColor;
    }
    public void Highlight() {
        targetColor = highlightedColor;
    }
    public void UnHighlight(){
        targetColor = normalColor;
    }
    
}
