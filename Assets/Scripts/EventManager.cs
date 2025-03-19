using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject[] eventObjects;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private TMP_Text eventText;
    [SerializeField] private Sprite[] eventSprites;
    [SerializeField] private GameObject[] NPC00;
    [SerializeField] private GameObject[] NPC15;
    [SerializeField] private GameObject[] NPC30;
    [SerializeField] private GameObject[] NPC45;
    private static List<Vector3> NPCPositions00 = new List<Vector3>();
    private static List<Vector3> NPCPositions15 = new List<Vector3>();
    private static List<Vector3> NPCPositions30 = new List<Vector3>();
    private static List<Vector3> NPCPositions45 = new List<Vector3>();
    public static string sceneName;
    public static string sceneStage;
    private static int randomInt = 0;
    public static float time;
    public static bool newNPCPath = true;

    void Start()
    {
        switch (TimeManager.result)
        {
            case "EpilepsyPassed":
                eventObjects[2].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[2].GetComponent<Button>().interactable = false;
                break;
            case "EpilepsyFailed":
                eventObjects[2].GetComponent<Image>().sprite = eventSprites[2];
                break;
            case "SpinalPassed":
                eventObjects[1].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[1].GetComponent<Button>().interactable = false;
                break;
            case "SpinalFailed":
                eventObjects[1].GetComponent<Image>().sprite = eventSprites[2];
                break;
            case "DiabetesPassed":
                eventObjects[0].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[0].GetComponent<Button>().interactable = false;
                break;
            case "DiabetesFailed":
                eventObjects[0].GetComponent<Image>().sprite = eventSprites[2];
                break;
            case "ChokingPassed":
                eventObjects[3].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[3].GetComponent<Button>().interactable = false;
                break;
            case "ChokingFailed":
                eventObjects[3].GetComponent<Image>().sprite = eventSprites[2];
                break;
            case "BurnPassed":
                eventObjects[4].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[4].GetComponent<Button>().interactable = false;
                break;
            case "BurnFailed":
                eventObjects[4].GetComponent<Image>().sprite = eventSprites[2];
                break;
            case "AllergyPassed":
                eventObjects[5].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[5].GetComponent<Button>().interactable = false;
                break;
            case "AllergyFailed":
                eventObjects[5].GetComponent<Image>().sprite = eventSprites[2];
                break;
            case "StrokePassed":
                eventObjects[6].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[6].GetComponent<Button>().interactable = false;
                break;
            case "StrokeFailed":
                eventObjects[6].GetComponent<Image>().sprite = eventSprites[2];
                break;
            case "FracturePassed":
                eventObjects[7].GetComponent<Image>().sprite = eventSprites[1];
                eventObjects[7].GetComponent<Button>().interactable = false;
                break;
            case "FractureFailed":
                eventObjects[7].GetComponent<Image>().sprite = eventSprites[2];
                break;
            default:
                break;
        }

        foreach (GameObject incident in eventObjects)
        {
            if (incident.activeSelf == false && incident.GetComponent<Image>().sprite == eventSprites[1])
            {
                incident.SetActive(true);
            }
            else if (incident.activeSelf == false && incident.GetComponent<Image>().sprite == eventSprites[2])
            {
                incident.SetActive(true);
            }
        }

        if (NPCPositions00.Count != 0 || NPCPositions15.Count != 0 || NPCPositions30.Count != 0 || NPCPositions45.Count != 0)
        {
            SetPositions();
        }
    }

    void Update()
    {
        if (timeManager.GetMinutes() == 30)
        {
            CheckResolvedIncidents();
        }

        switch (timeManager.GetHour())
        {
            case 8: //Morning event
                if (timeManager.GetMinutes() == 0)
                {
                    foreach (GameObject npc in NPC15)
                    {
                        npc.SetActive(false);
                    }
                    foreach (GameObject npc in NPC30)
                    {
                        npc.SetActive(false);
                    }
                    foreach (GameObject npc in NPC45)
                    {
                        npc.SetActive(false);
                    }
                }
                if (timeManager.GetMinutes() == 15)
                {
                    foreach (GameObject npc in NPC15)
                    {
                        npc.SetActive(true);
                    }
                    eventText.SetText("The early birds");
                    eventText.color = new Color32(51, 176, 27, 255);

                }
                if (timeManager.GetMinutes() == 30)
                {
                    foreach (GameObject npc in NPC30)
                    {
                        npc.SetActive(true);
                    }
                    eventText.SetText("The morning rush");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    foreach (GameObject npc in NPC45)
                    {
                        npc.SetActive(true);
                    }
                    eventText.SetText("The latecomers");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 9:
                if (timeManager.GetMinutes() == 0)
                {
                    if (randomInt == 0)
                    {
                        randomInt = Random.Range(1, 4);
                    }
                    switch (randomInt)
                    {
                        case 1: //Epilepsy
                            eventObjects[2].SetActive(true);
                            eventText.SetText("Accident at the bike shed!");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        case 2: //Spinal
                            eventObjects[1].SetActive(true);
                            eventText.SetText("Injury at the parking lot!");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        case 3: //Diabetes
                            eventObjects[0].SetActive(true);
                            eventText.SetText("Help at the reception requested!");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        default:
                            break;
                    }
                }
                if (timeManager.GetMinutes() == 30)
                {
                    eventText.SetText("Everybody checking their emails");
                    eventText.color = new Color32(51, 176, 27, 255);

                }
                if (timeManager.GetMinutes() == 45)
                {
                    eventText.SetText("All the daily stand-up meetings");
                    eventText.color = new Color32(51, 176, 27, 255);

                }

                break;
            case 10:
                if (timeManager.GetMinutes() == 0)
                {
                    eventText.SetText("Getting some work in");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 15)
                {
                    eventText.SetText("Restroom break");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    eventText.SetText("Coffee time");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    eventText.SetText("Keep up the productivity");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 11:
                if (timeManager.GetMinutes() == 0)
                {
                    eventText.SetText("Getting some more work done");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 15)
                {
                    eventText.SetText("Smoke break");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    eventText.SetText("First round of meetings");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    eventText.SetText("After meeting socializing");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 12:
                if (timeManager.GetMinutes() == 0)
                {
                    eventText.SetText("The early lunchers");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 15)
                {
                    eventText.SetText("The cafetaria is filling up");
                    eventText.color = new Color32(51, 176, 27, 255);
                    randomInt = 0;
                }
                if (timeManager.GetMinutes() == 30)
                {
                    if (randomInt == 0)
                    {
                        randomInt = Random.Range(1, 4);
                    }
                    switch (randomInt)
                    {
                        case 1:
                            eventObjects[5].SetActive(true);
                            eventText.SetText("Assistant needed at the cafeteria");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        case 2:
                            eventObjects[3].SetActive(true);
                            eventText.SetText("Incident during lunch time");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        case 3:
                            eventObjects[4].SetActive(true);
                            eventText.SetText("Injury in the kitchen");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        default:
                            break;
                    }
                }
                if (timeManager.GetMinutes() == 15)
                {
                    eventText.SetText("The late lunchers are hungry");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 13: //Midday event
                if (timeManager.GetMinutes() == 0)
                {
                    eventText.SetText("Back at it again");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 15)
                {
                    eventText.SetText("Some more working hours");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    eventText.SetText("Everybody is being productive");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    eventText.SetText("Next round of meetings start");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 14:
                if (timeManager.GetMinutes() == 0)
                {
                    eventText.SetText("Restroom round two");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 15)
                {
                    eventText.SetText("Checking in with the team");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    eventText.SetText("Another smoke break");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    eventText.SetText("Work is on the way again");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 15:
                if (timeManager.GetMinutes() == 0)
                {
                    eventText.SetText("Going to need more coffee");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    eventText.SetText("Catching up with some more colleague");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    eventText.SetText("Getting more working hours in");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    eventText.SetText("Everybody is keeping at it");
                    eventText.color = new Color32(51, 176, 27, 255);
                    randomInt = 0;
                }
                break;
            case 16: //Afternoon event
                if (timeManager.GetMinutes() == 0)
                {
                    if (randomInt == 0)
                    {
                        randomInt = Random.Range(1, 3);
                    }
                    switch (randomInt)
                    {
                        case 1:
                            eventObjects[6].SetActive(true);
                            eventText.SetText("Strange acting colleague");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        case 2:
                            eventObjects[7].SetActive(true);
                            eventText.SetText("Emergency in the stairway");
                            eventText.color = new Color32(207, 22, 18, 255);
                            break;
                        default:
                            break;
                    }
                }
                if (timeManager.GetMinutes() == 31)
                {
                    eventText.SetText("It is time for a snack");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    eventText.SetText("Finishing up for the day");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 17:
                if (timeManager.GetMinutes() == 0)
                {
                    foreach (GameObject npc in NPC00)
                    {
                        npc.SetActive(true);
                        npc.GetComponent<PathMovement>().SetPath("Depart");
                    }
                    eventText.SetText("The earlybirds go home");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 15)
                {
                    foreach (GameObject npc in NPC15)
                    {
                        npc.SetActive(true);
                        npc.GetComponent<PathMovement>().SetPath("Depart");
                    }
                    eventText.SetText("Everybody is leaving");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    foreach (GameObject npc in NPC30)
                    {
                        npc.SetActive(true);
                        npc.GetComponent<PathMovement>().SetPath("Depart");
                    }
                    eventText.SetText("The latecomers are packing up");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 45)
                {
                    foreach (GameObject npc in NPC45)
                    {
                        npc.SetActive(true);
                        npc.GetComponent<PathMovement>().SetPath("Depart");
                    }
                    eventText.SetText("The last few stragglers");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                break;
            case 18:
                if (timeManager.GetMinutes() == 0)
                {
                    eventText.SetText("Closing up the office");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 15)
                {
                    eventText.SetText("Another BUSY MONDAY!");
                    eventText.color = new Color32(51, 176, 27, 255);
                }
                if (timeManager.GetMinutes() == 30)
                {
                    ChangeScene.MoveToScene(0);
                }
                break;
            default:
                break;
        }
    }

    public void SetSceneName(string scene)
    {
        sceneName = scene;
    }

    public void SetSceneStage(string scene)
    {
        randomInt = 0;
        sceneStage = scene;
    }

    private void CheckResolvedIncidents()
    {
        foreach (GameObject incident in eventObjects)
        {
            if (incident.GetComponent<Image>().sprite == eventSprites[1])
            {
                incident.SetActive(false);
            }
        }
    }

    public void SavePositions()
    {
        foreach (GameObject NPC in NPC00)
        {
            NPCPositions00.Add(NPC.transform.position);
        }
        foreach (GameObject NPC in NPC15)
        {
            NPCPositions15.Add(NPC.transform.position);
        }
        foreach (GameObject NPC in NPC30)
        {
            NPCPositions30.Add(NPC.transform.position);
        }
        foreach (GameObject NPC in NPC45)
        {
            NPCPositions45.Add(NPC.transform.position);
        }
    }

    private void SetPositions()
    {
        var i = 0;
        foreach (GameObject NPC in NPC00)
        {
            NPC.transform.position = NPCPositions00[i];
            i++;
        }
        i = 0;
        foreach (GameObject NPC in NPC15)
        {
            NPC.transform.position = NPCPositions15[i];
            i++;
        }
        i = 0;
        foreach (GameObject NPC in NPC30)
        {
            NPC.transform.position = NPCPositions30[i];
            i++;
        }
        i = 0;
        foreach (GameObject NPC in NPC45)
        {
            NPC.transform.position = NPCPositions45[i];
            i++;
        }
    }

    public static void GenerateNewPath(bool needNewPath)
    {
        if (needNewPath == true)
        {
            newNPCPath = true;
        }
        else
        {
            newNPCPath = false;
        }
    }
}