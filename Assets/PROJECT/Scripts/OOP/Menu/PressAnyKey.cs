using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    public GameObject menuUI; // Ana menü UI öğesi
    public GameObject pressAnyKeyUI; // "Press Any Key" UI öğesi

    private bool keyPressed = false;

    void Start()
    {
        // Başlangıçta sadece "Press Any Key" ekranını göster
        menuUI.SetActive(false);
        pressAnyKeyUI.SetActive(true);
    }

    void Update()
    {
        if (!keyPressed && Input.anyKeyDown)
        {
            keyPressed = true;
            ShowMenu();
        }
    }

    void ShowMenu()
    {
        // "Press Any Key" ekranını gizle ve menüyü göster
        pressAnyKeyUI.SetActive(false);
        menuUI.SetActive(true);
    }
}