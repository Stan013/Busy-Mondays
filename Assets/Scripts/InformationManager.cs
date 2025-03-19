using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class InformationManager : MonoBehaviour
{
    [SerializeField] private Image currentImage;
    [SerializeField] private Sprite[] scenarioImages;
    [SerializeField] private TMP_Text pageText;
    [SerializeField] private TMP_Text audioText;
    [SerializeField] private TMP_Text scenarioText;
    [SerializeField] private AudioSource scenarioAudio;
    private int currentPage = 1;
    [SerializeField] private string[] epilepsyInformation;
    [SerializeField] private string[] epilepsySolution;
    [SerializeField] private AudioClip[] epilepsyAudio;
    [SerializeField] private string[] spinalInformation;
    [SerializeField] private string[] spinalSolution;
    [SerializeField] private AudioClip[] spinalAudio;
    [SerializeField] private string[] diabetesInformation;
    [SerializeField] private string[] diabetesSolution;
    [SerializeField] private AudioClip[] diabetesAudio;
    [SerializeField] private string[] allergyInformation;
    [SerializeField] private string[] allergySolution;
    [SerializeField] private AudioClip[] allergyAudio;
    [SerializeField] private string[] chokingInformation;
    [SerializeField] private string[] chokingSolution;
    [SerializeField] private AudioClip[] chokingAudio;
    [SerializeField] private string[] burnInformation;
    [SerializeField] private string[] burnSolution;
    [SerializeField] private AudioClip[] burnAudio;
    [SerializeField] private string[] fractureInformation;
    [SerializeField] private string[] fractureSolution;
    [SerializeField] private AudioClip[] fractureAudio;
    [SerializeField] private string[] strokeInformation;
    [SerializeField] private string[] strokeSolution;
    [SerializeField] private AudioClip[] strokeAudio;
    private static string[] information;
    private static string[] solution;
    private static AudioClip[] audio;
    public static List<string> unlockedInformation = new List<string>();
    public static List<string> unlockedSolution = new List<string>();
    public static List<AudioClip> unlockedAudio = new List<AudioClip>();
    public static List<int> cardInformationCorrect = new List<int>();
    public static List<int> cardInformationIncorrect = new List<int>();
    public static List<int> cardInformationMisplaced = new List<int>();
    [SerializeField] private Button collectButton;
    public static bool clear = false;

    void Start()
    {
        if (unlockedSolution.Count == 0 && unlockedInformation.Count == 0)
        {
            ClearCard();
        }
        if (clear == true)
        {
            SceneReset();
        }

        switch (EventManager.sceneName)
        {
            case "Epilepsy":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(epilepsyInformation[0]);
                        unlockedAudio.Add(epilepsyAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[0];
                    information = epilepsyInformation;
                    solution = epilepsySolution;
                    audio = epilepsyAudio;
                    scenarioText.SetText(epilepsyInformation[0]);
                    scenarioAudio.clip = epilepsyAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 5)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }

                }
                break;
            case "Spinal":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(spinalInformation[0]);
                        unlockedAudio.Add(spinalAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[1];
                    information = spinalInformation;
                    solution = spinalSolution;
                    audio = spinalAudio;
                    scenarioText.SetText(spinalInformation[0]);
                    scenarioAudio.clip = spinalAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 4)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }
                }
                break;
            case "Diabetes":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(diabetesInformation[0]);
                        unlockedAudio.Add(diabetesAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[2];
                    information = diabetesInformation;
                    solution = diabetesSolution;
                    audio = diabetesAudio;
                    scenarioText.SetText(diabetesInformation[0]);
                    scenarioAudio.clip = diabetesAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 3)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }
                }
                break;
            case "Allergy":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(allergyInformation[0]);
                        unlockedAudio.Add(allergyAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[3];
                    information = allergyInformation;
                    solution = allergySolution;
                    audio = allergyAudio;
                    scenarioText.SetText(allergyInformation[0]);
                    scenarioAudio.clip = allergyAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 5)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }
                }
                break;
            case "Choking":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(chokingInformation[0]);
                        unlockedAudio.Add(chokingAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[4];
                    information = chokingInformation;
                    solution = chokingSolution;
                    audio = chokingAudio;
                    scenarioText.SetText(chokingInformation[0]);
                    scenarioAudio.clip = chokingAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 4)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }
                }
                break;
            case "Burn":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(burnInformation[0]);
                        unlockedAudio.Add(burnAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[5];
                    information = burnInformation;
                    solution = burnSolution;
                    audio = burnAudio;
                    scenarioText.SetText(burnInformation[0]);
                    scenarioAudio.clip = burnAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 5)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }
                }
                break;
            case "Stroke":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(strokeInformation[0]);
                        unlockedAudio.Add(strokeAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[6];
                    information = strokeInformation;
                    solution = strokeSolution;
                    audio = strokeAudio;
                    scenarioText.SetText(strokeInformation[0]);
                    scenarioAudio.clip = strokeAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 3)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }
                }
                break;
            case "Fracture":
                if (EventManager.sceneStage == "Identifying" || EventManager.sceneStage == null)
                {
                    if (unlockedInformation.Count == 0)
                    {
                        unlockedInformation.Add(fractureInformation[0]);
                        unlockedAudio.Add(fractureAudio[0]);
                    }
                    currentImage.sprite = scenarioImages[7];
                    information = fractureInformation;
                    solution = fractureSolution;
                    audio = fractureAudio;
                    scenarioText.SetText(fractureInformation[0]);
                    scenarioAudio.clip = fractureAudio[0];
                    pageText.SetText(currentPage + " of " + unlockedInformation.Count);
                    audioText.SetText(currentPage + " of " + unlockedAudio.Count);
                    if (TargetManager.completed == true)
                    {
                        collectButton.interactable = false;
                    }
                    else
                    {
                        collectButton.interactable = true;
                    }
                }
                else
                {
                    if (unlockedSolution.Count != 0)
                    {
                        if (unlockedSolution.Count == 4)
                        {
                            collectButton.interactable = false;
                        }
                        scenarioText.SetText(unlockedSolution[0]);
                        pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    }
                    else
                    {
                        pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                    }
                }
                break;
            default:
                break;
        }
    }

    public void NextPage()
    {
        if (EventManager.sceneStage == "Identifying")
        {
            if (currentPage < unlockedInformation.Count)
            {
                currentPage++;
            }
            else
            {
                currentPage = 1;
            }
            pageText.SetText(currentPage + " of " + unlockedInformation.Count);
            audioText.SetText(currentPage + " of " + unlockedInformation.Count);
            scenarioText.SetText(unlockedInformation[currentPage - 1]);
            scenarioAudio.clip = unlockedAudio[currentPage - 1];
        }
        else
        {
            if (currentPage < unlockedSolution.Count)
            {
                currentPage++;
            }
            else
            {
                currentPage = 1;
            }
            if (unlockedSolution.Count == 0)
            {
                pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
            }
            else
            {
                pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                scenarioText.SetText(unlockedSolution[currentPage - 1]);
            }

        }
    }

    public void PreviousPage()
    {
        if (EventManager.sceneStage == "Identifying")
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            else
            {
                currentPage = unlockedInformation.Count;
            }
            pageText.SetText(currentPage + " of " + unlockedInformation.Count);
            audioText.SetText(currentPage + " of " + unlockedInformation.Count);
            scenarioText.SetText(unlockedInformation[currentPage - 1]);
            scenarioAudio.clip = unlockedAudio[currentPage - 1];
        }
        else
        {
            if (currentPage > 1)
            {
                currentPage--;
                pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                scenarioText.SetText(unlockedSolution[currentPage-1]);
            }
            else
            {
                if (unlockedSolution.Count != 0)
                {
                    currentPage = unlockedSolution.Count;
                    pageText.SetText(currentPage + " of " + unlockedSolution.Count);
                    scenarioText.SetText(unlockedSolution[currentPage-1]);
                }
                else
                {
                    currentPage = (unlockedSolution.Count + 1);
                    pageText.SetText(currentPage + " of " + (unlockedSolution.Count + 1));
                }
            }
        }
    }

    public void SetClear(bool resolved)
    {
         clear = resolved;
    }

    public static string[] GetInformation(string sceneName)
    {
        if(EventManager.sceneStage == "Identifying")
        {
            return information;
        }
        else
        {
            return solution;
        }
    }

    public static AudioClip[] GetAudio(string sceneName)
    {
       return audio;
    }

    public void SetSceneStage(string scene)
    {
        EventManager.sceneStage = scene;
    }

    public static void SceneReset()
    {
        TargetManager.completed = false;
        cardInformationCorrect.Clear();
        cardInformationIncorrect.Clear();
        cardInformationMisplaced.Clear();
        unlockedInformation.Clear();
        unlockedSolution.Clear();
        unlockedAudio.Clear();
    }

    public void ClearCard()
    {
        if(unlockedSolution.Count == 0)
        {
            cardInformationCorrect.Clear();
            cardInformationIncorrect.Clear();
            cardInformationMisplaced.Clear();
            TargetManager.completed = false;
        }
    }
}
