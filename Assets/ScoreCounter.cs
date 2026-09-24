using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Enables use of uGUI classes like Text

public class ScoreCounter : MonoBehaviour {
    [Header("Dynamic")]
    public int score = 0;

    private Text uiText;

    void Start() {
        uiText = GetComponent<Text>();
    }

    void Update() {
        uiText.text = score.ToString( "#,0" ); // Formats integer with commas separating every three digits
    }
}