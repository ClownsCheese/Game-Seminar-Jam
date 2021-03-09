using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text pointsTXT;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePoints(int pointsToAdd)
    {
        points += pointsToAdd;
        pointsTXT.text = $"{points}";
    }
}
