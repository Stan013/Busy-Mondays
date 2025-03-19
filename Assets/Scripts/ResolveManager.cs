using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolveManager : MonoBehaviour
{
    [SerializeField] private Toggle requirementToggle1;
    [SerializeField] private Toggle requirementToggle2;
    [SerializeField] private Toggle requirementToggle3;
    [SerializeField] private Toggle requirementToggle4;
    [SerializeField] private Toggle requirementToggle5;
    [SerializeField] private Button passButton;

    // Start is called before the first frame update
    void Start()
    {
        CheckRequirements();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.sceneName == "Epilepsy")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && requirementToggle4.isOn && requirementToggle5.isOn && InformationManager.unlockedSolution.Count == 5)
            {
                passButton.interactable = true;
            }
        }
        else if (EventManager.sceneName == "Spinal")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && requirementToggle4.isOn && InformationManager.unlockedSolution.Count == 4)
            {
                passButton.interactable = true;
            }
        }
        else if (EventManager.sceneName == "Diabetes")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && InformationManager.unlockedSolution.Count == 3)
            {
                passButton.interactable = true;
            }
        }
        else if (EventManager.sceneName == "Allergy")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && requirementToggle4.isOn && requirementToggle5.isOn && InformationManager.unlockedSolution.Count == 5)
            {
                passButton.interactable = true;
            }
        }
        else if (EventManager.sceneName == "Choking")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && requirementToggle4.isOn && InformationManager.unlockedSolution.Count == 4)
            {
                passButton.interactable = true;
            }
        }
        else if (EventManager.sceneName == "Burn")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && requirementToggle4.isOn && requirementToggle5.isOn && InformationManager.unlockedSolution.Count == 5)
            {
                passButton.interactable = true;
            }
        }
        else if (EventManager.sceneName == "Stroke")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && InformationManager.unlockedSolution.Count == 3)
            {
                passButton.interactable = true;
            }
        }
        else if (EventManager.sceneName == "Fracture")
        {
            if (requirementToggle1.isOn && requirementToggle2.isOn && requirementToggle3.isOn && requirementToggle4.isOn && InformationManager.unlockedSolution.Count == 4)
            {
                passButton.interactable = true;
            }
        }
    }

    private void CheckRequirements()
    {
        if (EventManager.sceneName == "Epilepsy")
        {
            try {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch {
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try {
                if (InformationManager.unlockedSolution[3] != null)
                {
                    requirementToggle4.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[3];
                }
            }
            catch{
                requirementToggle4.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try {
                if (InformationManager.unlockedSolution[4] != null)
                {
                    requirementToggle5.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[4];
                }
            }
            catch{
                requirementToggle5.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
        }
        else if (EventManager.sceneName == "Spinal")
        {
            try {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch{
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch
            {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch
            {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try {
                if (InformationManager.unlockedSolution[3] != null)
                {
                    requirementToggle4.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[3];
                }
            }
            catch
            {
                requirementToggle4.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            requirementToggle5.GetComponentInChildren<Text>().text = "";
            requirementToggle5.interactable = false;
        }
        else if (EventManager.sceneName == "Diabetes")
        {
            try
            {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch
            {
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch
            {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch
            {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            requirementToggle4.GetComponentInChildren<Text>().text = "";
            requirementToggle4.interactable = false;
            requirementToggle5.GetComponentInChildren<Text>().text = "";
            requirementToggle5.interactable = false;
        }
        else if (EventManager.sceneName == "Allergy")
        {
            try
            {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch
            {
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch
            {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch
            {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[3] != null)
                {
                    requirementToggle4.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[3];
                }
            }
            catch
            {
                requirementToggle4.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[4] != null)
                {
                    requirementToggle5.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[4];
                }
            }
            catch
            {
                requirementToggle5.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
        }
        else if (EventManager.sceneName == "Choking")
        {
            try
            {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch
            {
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch
            {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch
            {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[3] != null)
                {
                    requirementToggle4.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[3];
                }
            }
            catch
            {
                requirementToggle4.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            requirementToggle5.GetComponentInChildren<Text>().text = "";
            requirementToggle5.interactable = false;
        }
        else if (EventManager.sceneName == "Burn")
        {
            try
            {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch
            {
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch
            {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch
            {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[3] != null)
                {
                    requirementToggle4.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[3];
                }
            }
            catch
            {
                requirementToggle4.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[4] != null)
                {
                    requirementToggle5.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[4];
                }
            }
            catch
            {
                requirementToggle5.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
        }
        else if (EventManager.sceneName == "Stroke")
        {
            try
            {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch
            {
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch
            {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch
            {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            requirementToggle4.GetComponentInChildren<Text>().text = "";
            requirementToggle4.interactable = false;
            requirementToggle5.GetComponentInChildren<Text>().text = "";
            requirementToggle5.interactable = false;
        }
        else if (EventManager.sceneName == "Fracture")
        {
            try
            {
                if (InformationManager.unlockedSolution[0] != null)
                {
                    requirementToggle1.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[0];
                }
            }
            catch
            {
                requirementToggle1.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[1] != null)
                {
                    requirementToggle2.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[1];
                }
            }
            catch
            {
                requirementToggle2.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[2] != null)
                {
                    requirementToggle3.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[2];
                }
            }
            catch
            {
                requirementToggle3.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            try
            {
                if (InformationManager.unlockedSolution[3] != null)
                {
                    requirementToggle4.GetComponentInChildren<Text>().text = InformationManager.unlockedSolution[3];
                }
            }
            catch
            {
                requirementToggle4.GetComponentInChildren<Text>().text = "[Locked] Resolve Requirement";
            }
            requirementToggle5.GetComponentInChildren<Text>().text = "";
            requirementToggle5.interactable = false;
        }
    }

    public void SetResult(bool result)
    {
        InformationManager.clear = true;
        if (EventManager.sceneName == "Epilepsy")
        {
            if (result == true)
            {
                TimeManager.result = "EpilepsyPassed";
            }
            else
            {
                TimeManager.result = "EpilepsyFailed";
            }
        }
        else if (EventManager.sceneName == "Spinal")
        {
            if (result == true)
            {
                TimeManager.result = "SpinalPassed";
            }
            else
            {
                TimeManager.result = "SpinalFailed";
            }
        }
        else if (EventManager.sceneName == "Diabetes")
        {
            if (result == true)
            {
                TimeManager.result = "DiabetesPassed";
            }
            else
            {
                TimeManager.result = "DiabetesFailed";
            }
        }
        else if (EventManager.sceneName == "Choking")
        {
            if (result == true)
            {
                TimeManager.result = "ChokingPassed";
            }
            else
            {
                TimeManager.result = "ChokingFailed";
            }
        }
        else if (EventManager.sceneName == "Allergy")
        {
            if (result == true)
            {
                TimeManager.result = "AllergyPassed";
            }
            else
            {
                TimeManager.result = "AllergyFailed";
            }
        }
        else if (EventManager.sceneName == "Burn")
        {
            if (result == true)
            {
                TimeManager.result = "BurnPassed";
            }
            else
            {
                TimeManager.result = "BurnFailed";
            }
        }
        else if (EventManager.sceneName == "Stroke")
        {
            if (result == true)
            {
                TimeManager.result = "StrokePassed";
            }
            else
            {
                TimeManager.result = "StrokeFailed";
            }
        }
        else if (EventManager.sceneName == "Fracture")
        {
            if (result == true)
            {
                TimeManager.result = "FracturePassed";
            }
            else
            {
                TimeManager.result = "FractureFailed";
            }
        }
    }

    public void SetSceneStage(string sceneStage)
    {
        EventManager.sceneStage = sceneStage;
    }

    public void SceneReset()
    {
        InformationManager.SceneReset();
    }
}
