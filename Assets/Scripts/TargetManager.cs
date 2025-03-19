using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;
using TMPro;
public class TargetManager : MonoBehaviour
{
    [SerializeField] private Sprite[] cardSprites;
    [SerializeField] private GameObject[] cardSlots;
    [SerializeField] private GameObject[] imageTargets;
    [SerializeField] private TMP_Text detectionText;
    [SerializeField] private UnityEngine.UI.Image detectionImage;
    private float delayTimer = 3;
    public static bool completed = false;
    [SerializeField] private GameObject vuforiaObject;

    private void Start()
    {
        if (vuforiaObject.GetComponent<VuforiaBehaviour>().enabled == false)
        {
            vuforiaObject.GetComponent<VuforiaBehaviour>().enabled = true;
        }

        CheckCards();

        switch (EventManager.sceneName)
        {
            case "Spinal":
                if (EventManager.sceneStage == "Identifying")
                {
                    cardSlots[3].SetActive(false);
                }
                else
                {
                    cardSlots[4].SetActive(false);
                }
                break;
            case "Diabetes":
                if (EventManager.sceneStage == "Identifying")
                {
                    cardSlots[3].SetActive(false);
                }
                else
                {
                    cardSlots[3].SetActive(false);
                    cardSlots[4].SetActive(false);
                }
                break;
            case "Allergy":
                if (EventManager.sceneStage == "Identifying")
                {
                    cardSlots[3].SetActive(false);
                }
                break;
            case "Choking":
                if (EventManager.sceneStage == "Identifying")
                {
                    cardSlots[3].SetActive(false);
                }
                else
                {
                    cardSlots[4].SetActive(false);
                }
                break;
            case "Burn":
                if (EventManager.sceneStage == "Identifying")
                {
                    cardSlots[3].SetActive(false);
                }
                break;
            case "Stroke":
                if (EventManager.sceneStage == "Identifying")
                {
                    cardSlots[3].SetActive(false);
                }
                else
                {
                    cardSlots[3].SetActive(false);
                    cardSlots[4].SetActive(false);
                }
                break;
            case "Fracture":
                if (EventManager.sceneStage == "Identifying")
                {
                    cardSlots[3].SetActive(false);
                }
                else
                {
                    cardSlots[4].SetActive(false);
                }
                break;
        }
    }

    private void Update()
    {
        vuforiaObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        vuforiaObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        if (completed != true)
        {
            if (imageTargets[0].activeSelf == false)
            {
                delayTimer -= Time.deltaTime;
                if (delayTimer < 0)
                {
                    MakeImageTargets(true);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangeScene.MoveToScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void SceneGenerator(string cardName)
    {
        if (cardName != null){
            switch (EventManager.sceneName){
                case "Epilepsy":
                    if(EventManager.sceneStage == "Identifying")
                    {
                        if(cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon"){ //First slot check
                            if(cardName == "AssessIncident")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            } 
                            else{
                                if(cardName == "Responsiveness" || cardName == "OddMotions" || cardName == "BreathingCheck")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else{
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if(cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon"){ //Second slot check
                            if (cardName == "Responsiveness")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else{
                                if(cardName == "AssessIncident" || cardName == "OddMotions" || cardName == "BreathingCheck")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else{
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon"){ //Third slot check
                            if (cardName == "OddMotions")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else{
                                if(cardName == "AssessIncident" || cardName == "Responsiveness" || cardName == "BreathingCheck")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else{
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                        else if (cardSlots[3].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon"){ //Fourth slot check
                            if (cardName == "BreathingCheck")
                            {
                                InformationManager.cardInformationCorrect.Add(3);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[4]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[4]);
                            }
                            else{
                                if(cardName == "AssessIncident" || cardName == "Responsiveness" || cardName == "OddMotions")
                                {
                                    InformationManager.cardInformationMisplaced.Add(3);
                                }
                                else{
                                    InformationManager.cardInformationIncorrect.Add(3);
                                }
                            }
                        }
                    }
                    else if(EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "EmergencyServices")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "InjuryPrevention" || cardName == "HeadProtection" || cardName == "OptimizeBreathing" || cardName == "InformVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "InjuryPrevention")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "HeadProtection" || cardName == "OptimizeBreathing" || cardName == "InformVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "HeadProtection")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "InjuryPrevention" || cardName == "OptimizeBreathing" || cardName == "InformVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                        else if (cardSlots[3].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fourth slot check
                            if (cardName == "OptimizeBreathing")
                            {
                                InformationManager.cardInformationCorrect.Add(3);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "InjuryPrevention" || cardName == "HeadProtection" || cardName == "InformVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(3);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(3);
                                }
                            }
                        }
                        else if (cardSlots[4].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fourth slot check
                            if (cardName == "InformVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(4);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[4]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "InjuryPrevention" || cardName == "HeadProtection" || cardName == "OptimizeBreathing")
                                {
                                    InformationManager.cardInformationMisplaced.Add(4);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(4);
                                }
                            }
                        }
                    }
                break;
                case "Spinal":
                    if (EventManager.sceneStage == "Identifying")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "CheckImpact")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "EvaluateVictim" || cardName == "LocateInjuries")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "EvaluateVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "CheckImpact" || cardName == "LocateInjuries")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "LocateInjuries")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "CheckImpact" || cardName == "EvaluateVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    else if (EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "EmergencyServices")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "PreventMovement" || cardName == "HoldSteady" || cardName == "ApplyPressure")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "PreventMovement")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "HoldSteady" || cardName == "ApplyPressure")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "HoldSteady")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "PreventMovement" || cardName == "ApplyPressure")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                        else if (cardSlots[3].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "ApplyPressure")
                            {
                                InformationManager.cardInformationCorrect.Add(3);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "PreventMovement" || cardName == "HoldSteady")
                                {
                                    InformationManager.cardInformationMisplaced.Add(3);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(3);
                                }
                            }
                        }
                    }
                    break;
                case "Diabetes":
                    if (EventManager.sceneStage == "Identifying")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "CheckVitals")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "SurveyVictim" || cardName == "InspectVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "SurveyVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "CheckVitals" || cardName == "InspectVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "InspectVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "CheckVitals" || cardName == "SurveyVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    else if (EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "MinimizeActivity")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "SugaryDrink" || cardName == "ProvideMeal")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "SugaryDrink")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "MinimizeActivity" || cardName == "ProvideMeal")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "ProvideMeal")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "MinimizeActivity" || cardName == "SugaryDrink")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    break;
                case "Allergy":
                    if (EventManager.sceneStage == "Identifying")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "BreathingCheck")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "SurveyVictim" || cardName == "InspectVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "SurveyVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "BreathingCheck" || cardName == "InspectVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "InspectVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "BreathingCheck" || cardName == "SurveyVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    else if (EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "EmergencyServices")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "EpiPenInjection" || cardName == "LayFlat" || cardName == "PreventChoking" || cardName == "PerformCPR")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "EpiPenInjection")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "LayFlat" || cardName == "PreventChoking" || cardName == "PerformCPR")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "LayFlat")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "EpiPenInjection" || cardName == "PreventChoking" || cardName == "PerformCPR")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                        else if (cardSlots[3].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fourth slot check
                            if (cardName == "PreventChoking")
                            {
                                InformationManager.cardInformationCorrect.Add(3);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "EpiPenInjection" || cardName == "LayFlat" || cardName == "PerformCPR")
                                {
                                    InformationManager.cardInformationMisplaced.Add(3);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(3);
                                }
                            }
                        }
                        else if (cardSlots[4].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fifth slot check
                            if (cardName == "PerformCPR")
                            {
                                InformationManager.cardInformationCorrect.Add(4);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[4]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "EpiPenInjection" || cardName == "LayFlat" || cardName == "PreventChoking")
                                {
                                    InformationManager.cardInformationMisplaced.Add(4);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(4);
                                }
                            }
                        }
                    }
                    break;
                case "Choking":
                    if (EventManager.sceneStage == "Identifying")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "IdentifySituation")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "SurveyVictim" || cardName == "InspectVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "SurveyVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "IdentifySituation" || cardName == "InspectVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "InspectVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "IdentifySituation" || cardName == "SurveyVictim")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    else if (EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "StimulateCoughing")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "BackBlows" || cardName == "StomachThrusts" || cardName == "EmergencyServices")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "BackBlows")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "StimulateCoughing" || cardName == "StomachThrusts" || cardName == "EmergencyServices")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "StomachThrusts")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "StimulateCoughing" || cardName == "BackBlows" || cardName == "EmergencyServices")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                        else if (cardSlots[3].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fourth slot check
                            if (cardName == "EmergencyServices")
                            {
                                InformationManager.cardInformationCorrect.Add(3);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "StimulateCoughing" || cardName == "BackBlows" || cardName == "StomachThrusts")
                                {
                                    InformationManager.cardInformationMisplaced.Add(3);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(3);
                                }
                            }
                        }
                    }
                    break;
                case "Burn":
                    if (EventManager.sceneStage == "Identifying")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "SurveyVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "ObserveWound" || cardName == "DetermineSeverity")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "ObserveWound")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "SurveyVictim" || cardName == "DetermineSeverity")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "DetermineSeverity")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "SurveyVictim" || cardName == "ObserveWound")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    else if (EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "CoolSkin")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "CleanBurn" || cardName == "CoverArea" || cardName == "Painkillers" || cardName == "AntibioticOintment")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "CleanBurn")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "CoolSkin" || cardName == "CoverArea" || cardName == "Painkillers" || cardName == "AntibioticOintment")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "CoverArea")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "CoolSkin" || cardName == "CleanBurn" || cardName == "Painkillers" || cardName == "AntibioticOintment")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                        else if (cardSlots[3].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fourth slot check
                            if (cardName == "Painkillers")
                            {
                                InformationManager.cardInformationCorrect.Add(3);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "CoolSkin" || cardName == "CleanBurn" || cardName == "CoverArea" || cardName == "AntibioticOintment")
                                {
                                    InformationManager.cardInformationMisplaced.Add(3);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(3);
                                }
                            }
                        }
                        else if (cardSlots[4].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fourth slot check
                            if (cardName == "AntibioticOintment")
                            {
                                InformationManager.cardInformationCorrect.Add(4);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[4]);
                            }
                            else
                            {
                                if (cardName == "CoolSkin" || cardName == "CleanBurn" || cardName == "CoverArea" || cardName == "Painkillers")
                                {
                                    InformationManager.cardInformationMisplaced.Add(4);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(4);
                                }
                            }
                        }
                    }
                    break;
                case "Stroke":
                    if (EventManager.sceneStage == "Identifying")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "VerbalCheck")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "FaceInspection" || cardName == "MovementAbility")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "FaceInspection")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "VerbalCheck" || cardName == "MovementAbility")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "MovementAbility")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "VerbalCheck" || cardName == "FaceInspection")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);

                                }
                            }
                        }
                    }
                    else if (EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "EmergencyServices")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "VictimInteraction" || cardName == "OptimizeBreathing")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "VictimInteraction")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "OptimizeBreathing")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "OptimizeBreathing")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "EmergencyServices" || cardName == "VictimInteraction")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    break;
                case "Fracture":
                    if (EventManager.sceneStage == "Identifying")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "EvaluateVictim")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "LocateInjuries" || cardName == "ExaminePain")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "LocateInjuries")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "EvaluateVictim" || cardName == "ExaminePain")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "ExaminePain")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedInformation.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                                InformationManager.unlockedAudio.Add(InformationManager.GetAudio(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "EvaluateVictim" || cardName == "LocateInjuries")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                    }
                    else if (EventManager.sceneStage == "Resolving")
                    {
                        if (cardSlots[0].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //First slot check
                            if (cardName == "ContactHospital")
                            {
                                InformationManager.cardInformationCorrect.Add(0);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[0]);
                            }
                            else
                            {
                                if (cardName == "StabilizeLimb" || cardName == "Elevate" || cardName == "IcePack")
                                {
                                    InformationManager.cardInformationMisplaced.Add(0);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(0);
                                }
                            }
                        }
                        else if (cardSlots[1].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Second slot check
                            if (cardName == "StabilizeLimb")
                            {
                                InformationManager.cardInformationCorrect.Add(1);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[1]);
                            }
                            else
                            {
                                if (cardName == "ContactHospital" || cardName == "Elevate" || cardName == "IcePack")
                                {
                                    InformationManager.cardInformationMisplaced.Add(1);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(1);
                                }
                            }
                        }
                        else if (cardSlots[2].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Third slot check
                            if (cardName == "Elevate")
                            {
                                InformationManager.cardInformationCorrect.Add(2);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[2]);
                            }
                            else
                            {
                                if (cardName == "ContactHospital" || cardName == "StabilizeLimb" || cardName == "IcePack")
                                {
                                    InformationManager.cardInformationMisplaced.Add(2);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(2);
                                }
                            }
                        }
                        else if (cardSlots[3].GetComponent<UnityEngine.UI.Image>().sprite.name == "CollectCardIcon")
                        { //Fourth slot check
                            if (cardName == "IcePack")
                            {
                                InformationManager.cardInformationCorrect.Add(3);
                                InformationManager.unlockedSolution.Add(InformationManager.GetInformation(EventManager.sceneName)[3]);
                            }
                            else
                            {
                                if (cardName == "ContactHospital" || cardName == "StabilizeLimb" || cardName == "Elevate")
                                {
                                    InformationManager.cardInformationMisplaced.Add(3);
                                }
                                else
                                {
                                    InformationManager.cardInformationIncorrect.Add(3);
                                }
                            }
                        }
                    }
                    break;
                default:
                break;
            }
        }
        CheckCards();
    }

    public void CheckCards()
    {

        if (InformationManager.clear == true && InformationManager.unlockedSolution.Count == 0)
        {

            ClearCardSlots();
            InformationManager.clear = false;
        }

        if (EventManager.sceneStage == "Identifying")
        {
            if (InformationManager.cardInformationCorrect.Count == InformationManager.GetInformation(EventManager.sceneName).Length - 1)
            {
                completed = true;
                ChangeScene.MoveToScene(6);
            }
        }
        else
        {
            if (InformationManager.cardInformationCorrect.Count == InformationManager.GetInformation(EventManager.sceneName).Length)
            {
                completed = true;
                ChangeScene.MoveToScene(8);
            }
        }

        foreach (int cardCheck in InformationManager.cardInformationCorrect){
            cardSlots[cardCheck].GetComponent<UnityEngine.UI.Image>().sprite = cardSprites[0];
        }
        foreach (int cardCheck in InformationManager.cardInformationIncorrect){
            cardSlots[cardCheck].GetComponent<UnityEngine.UI.Image>().sprite = cardSprites[1];
        }
        foreach (int cardCheck in InformationManager.cardInformationMisplaced){
            cardSlots[cardCheck].GetComponent<UnityEngine.UI.Image>().sprite = cardSprites[2];
        }
    }

    public void CardDetected()
    {
        detectionText.SetText("Card detected");
        detectionImage.color = new Color32(155,255,68,100);
        delayTimer = 3;
    }

    public void CardLost()
    {
        detectionText.SetText("No card detected");
        detectionImage.color = new Color32(255,43,28,100);
    }

    public void ClearCardSlots()
    {
        foreach (GameObject card in cardSlots){
            card.GetComponent<UnityEngine.UI.Image>().sprite = cardSprites[3];
        }
        InformationManager.cardInformationCorrect.Clear();
        InformationManager.cardInformationIncorrect.Clear();
        InformationManager.cardInformationMisplaced.Clear();
        if (EventManager.sceneStage != "Resolving" || completed == true)
        {
            var basicText = InformationManager.unlockedInformation[0];
            var basicAudio = InformationManager.unlockedAudio[0];
            InformationManager.unlockedInformation.Clear();
            InformationManager.unlockedInformation.Add(basicText);
            InformationManager.unlockedAudio.Clear();
            InformationManager.unlockedAudio.Add(basicAudio);

        }
        InformationManager.unlockedSolution.Clear();
    }

    public void MakeImageTargets(bool active)
    {
        foreach (GameObject imageTarget in imageTargets)
        {
            imageTarget.SetActive(active);
        }
    }
}
