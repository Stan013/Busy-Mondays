using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActorManager : MonoBehaviour
{
    [SerializeField] private TMP_Text actorText;
    [SerializeField] private UnityEngine.UI.Image actorImage;
    private int randomInt;
    private int actor;

    private void Start()
    {
        if (EventManager.sceneStage == "Resolving")
        {
            while (randomInt == actor)
            {
                randomInt = Random.Range(1, TakePlayerNames.GetNames().Count + 1);
            }
        }
        else
        {
            randomInt = Random.Range(1, TakePlayerNames.GetNames().Count + 1);
            actor = randomInt;
        }
        switch (randomInt)
            {
                case 1:
                    actor = 1;
                    actorImage.color = new Color32(255, 255, 0, 255);
                    actorText.SetText(TakePlayerNames.GetNames()[0]);
                    break;
                case 2:
                    actor = 2;
                    actorImage.color = new Color32(0, 255, 0, 255);
                    actorText.SetText(TakePlayerNames.GetNames()[1]);
                    break;
                case 3:
                    actor = 3;
                    actorImage.color = new Color32(255, 0, 255, 255);
                    actorText.SetText(TakePlayerNames.GetNames()[2]);
                    break;
                case 4:
                    actor = 4;
                    actorImage.color = new Color32(0, 255, 255, 255);
                    actorText.SetText(TakePlayerNames.GetNames()[3]);
                    break;
                default:
                    break;
            }
    }
}
