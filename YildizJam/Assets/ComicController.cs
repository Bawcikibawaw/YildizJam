using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComicController : MonoBehaviour
{
    public Image[] panels; // Panelleri buraya ekleyin
    public float fadeSpeed = 2f; // Solma hızını ayarlar
    private int currentPanel = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentPanel < panels.Length)
            {
                StartCoroutine(FadeIn(panels[currentPanel]));
                currentPanel++;
            }
            else
            {
                // Son panel, yeni sahneye geç
                SceneManager.LoadScene("Ates/Scenes/Main");
            }
        }
    }

    System.Collections.IEnumerator FadeIn(Image panel)
    {
        panel.gameObject.SetActive(true);
        Color color = panel.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime * fadeSpeed;
            panel.color = color;
            yield return null;
        }
    }
}