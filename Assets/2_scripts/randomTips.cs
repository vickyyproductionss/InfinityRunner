using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class randomTips : MonoBehaviour
{
    public Text tips;
    string[] Alltips;
    int totalAddedTips;

    private void Start()
    {
        totalAddedTips = 8;
        Alltips = new string[totalAddedTips];
        Alltips[0] = "Arrange sensitivity for better gameplay experience.";
        Alltips[1] = "Complete missions available in pause menu.";
        Alltips[2] = "See your position among every player under RANK tab.";
        Alltips[3] = "You can collect more diamonds in easy level.";
        Alltips[4] = "Complete speed mission in hard level to complete them quick.";
        Alltips[5] = "If no missions available, kindly update game from play store";
        Alltips[6] = "Score more by hitting wooden boxes.";
        Alltips[7] = "Score more by staying more time in air.";

        
        
        assignRandomValue();
    }

    public void assignRandomValue()
    {
        int randomNo = Random.Range(0, totalAddedTips);
        tips.text = Alltips[randomNo];
    }
}
