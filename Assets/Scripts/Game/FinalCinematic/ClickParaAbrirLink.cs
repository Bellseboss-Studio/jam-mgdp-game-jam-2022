using UnityEngine;
using UnityEngine.UI;

public class ClickParaAbrirLink : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private string link;

    private void Start()
    {
        button.onClick.AddListener(OpenLink);
    }

    private void OpenLink()
    {
        Application.OpenURL(link);
    }
}
