using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public RectTransform content; // Text'lerin bağlı olduğu Content.
    public float scrollSpeed = 10f; // Scroll hızı.
    private int selectedIndex = 0; // Seçili menü indeksi.
    private Vector2 targetPosition; // Hedef pozisyon.
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = content.GetChild(0).GetComponent<RectTransform>();
    }

    void Start()
    {
        UpdateTargetPosition();
    }

    void Update()
    {
        // Klavye girişlerini kontrol et
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex = Mathf.Max(0, selectedIndex - 1);
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex = Mathf.Min(content.childCount - 1, selectedIndex + 1);
            UpdateTargetPosition();
        }

        // İçeriği hareket ettir
        content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, targetPosition, Time.deltaTime * scrollSpeed);
    }

    void UpdateTargetPosition()
    {
        // Hedef pozisyonu ayarla
        float elementHeight = _rectTransform.sizeDelta.y;
        targetPosition = new Vector2(content.anchoredPosition.x, selectedIndex * elementHeight);
    }
}
