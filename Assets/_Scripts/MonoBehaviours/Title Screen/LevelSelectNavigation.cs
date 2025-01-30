using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelectNavigation : MonoBehaviour
{
    public Button[] levelButtons; // Level butonlarını sırayla ekle (Level 1, Level 2, ...)
    public Button backButton;     // Geri butonu
    private int currentIndex = 0;
    private bool isOnBackButton = false;

    void Start()
    {
        SelectLevel(0);  // İlk açılışta Level 1 seçili olacak
    }

    void OnEnable()
    {
        // Menü her açıldığında Level 1 seçili olacak
        currentIndex = 0;
        isOnBackButton = false;
        SelectLevel(currentIndex);
    }

    void Update()
    {
        if (!isOnBackButton)
        {
            // Sağ yön tuşu -> Son seviyeye ulaşana kadar sağa geç
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex < levelButtons.Length - 1)
            {
                currentIndex++;
                SelectLevel(currentIndex);
            }
            // Sol yön tuşu -> İlk seviyeye ulaşana kadar sola geç
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex > 0)
            {
                currentIndex--;
                SelectLevel(currentIndex);
            }
            // Aşağı yön tuşu -> Back butonuna geç
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isOnBackButton = true;
                EventSystem.current.SetSelectedGameObject(backButton.gameObject);
            }
        }
        else
        {
            // Yukarı yön tuşu -> Geri dönüş (Hangi leveldeyse oraya)
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isOnBackButton = false;
                SelectLevel(currentIndex);
            }
        }
    }

    void SelectLevel(int index)
    {
        EventSystem.current.SetSelectedGameObject(levelButtons[index].gameObject);
    }
}