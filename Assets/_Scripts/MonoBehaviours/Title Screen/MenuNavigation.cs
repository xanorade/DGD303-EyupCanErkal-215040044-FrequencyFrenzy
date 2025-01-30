using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public Button[] menuButtons;
    private GameObject _lastSelectedButton;

    void Start()
    {
        _lastSelectedButton = menuButtons[0].gameObject;
        EventSystem.current.SetSelectedGameObject(_lastSelectedButton);
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(_lastSelectedButton);
    }

    void Update()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        if (selected != null && selected != _lastSelectedButton)
        {
            _lastSelectedButton = selected;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            int index = System.Array.IndexOf(menuButtons, selected?.GetComponent<Button>());

            if (index >= 0)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    int nextIndex = (index + 1) % menuButtons.Length;
                    EventSystem.current.SetSelectedGameObject(menuButtons[nextIndex].gameObject);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    int prevIndex = (index - 1 + menuButtons.Length) % menuButtons.Length;
                    EventSystem.current.SetSelectedGameObject(menuButtons[prevIndex].gameObject);
                }
            }
        }
    }
}