using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject pressAnyKeyUI;

    private bool _keyPressed = false;

    void Start()
    {
        menuUI.SetActive(false);
        pressAnyKeyUI.SetActive(true);
    }

    void Update()
    {
        if (!_keyPressed && Input.anyKeyDown)
        {
            _keyPressed = true;
            ShowMenu();
        }
    }

    void ShowMenu()
    {
        pressAnyKeyUI.SetActive(false);
        menuUI.SetActive(true);
    }
}