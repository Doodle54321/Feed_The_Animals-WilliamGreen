/*

GameObject: Game Manager

Component: UIManager

Description: Handles UI elements using UI Builder UI Toolkit labels, tracking and displaying score and animals remaining.
*/

using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
public static UIManager Instance { get; private set; }

[SerializeField] private UIDocument uiDocument;

private Label animalsRemainingUI;
private Label scoreUI;
private int animalsRemaining;
private int currentScore;

private void Awake()
{
    Instance = this;
}

private void Start()
{
    if (uiDocument != null && uiDocument.rootVisualElement != null)
    {
        scoreUI = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        animalsRemainingUI = uiDocument.rootVisualElement.Q<Label>("AnimalsRemainingLabel");
    }

    currentScore = 0;
    if (scoreUI != null)
    {
        scoreUI.text = "Score: " + currentScore;
    }

    if (SpawnManager.Instance != null)
    {
        animalsRemaining = SpawnManager.Instance.GetNumberOfAnimalsToFeed();
    }

    if (animalsRemainingUI != null)
    {
        animalsRemainingUI.text = "Animals Remaining: " + animalsRemaining;
    }
}

// Called by: External Scripts
public void ScoreUpdate(int scoreUpdate)
{
    currentScore += scoreUpdate;
    if (scoreUI != null)
    {
        scoreUI.text = "Score: " + currentScore;
    }
}

// Called by: External Scripts
public void AnimalsRemainingUpdate()
{
    if (animalsRemaining > 0)
    {
        animalsRemaining--;
        if (animalsRemainingUI != null)
        {
            animalsRemainingUI.text = "Animals Remaining: " + animalsRemaining;
        }
    }
}
}