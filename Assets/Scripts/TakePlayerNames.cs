using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakePlayerNames : MonoBehaviour
{
    [SerializeField] private TMP_InputField player1Name;
    [SerializeField] private TMP_InputField player2Name;
    [SerializeField] private TMP_InputField player3Name;
    [SerializeField] private TMP_InputField player4Name;
    private static List<string> playerNames = new List<string>();

    public void PlayerNames()
    {
        if(player1Name.text != " Enter name" && player1Name.text != ""){
            playerNames.Add(player1Name.text);
        }
        if(player2Name.text != " Enter name" && player2Name.text != ""){
            playerNames.Add(player2Name.text);
        }
        if(player3Name.text != " Enter name" && player3Name.text != ""){
            playerNames.Add(player3Name.text);
        }
        if(player4Name.text != " Enter name" && player4Name.text != ""){
            playerNames.Add(player4Name.text);
        }
    }

    public static List<string> GetNames()
    {
        return playerNames;
    }
}
