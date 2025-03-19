using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private TimeManager tm;
    [SerializeField] private TMP_Text displayText;

    // Update is called once per frame
    void Update()
    {
        displayText.text = tm.Clock24Hour();
    }
}
