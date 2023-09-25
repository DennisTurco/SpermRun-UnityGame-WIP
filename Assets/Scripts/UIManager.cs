using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;

    //Show and hide the death panel
    public void ToggleDeathPanel()
    {
        Time.timeScale = 0f;
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}