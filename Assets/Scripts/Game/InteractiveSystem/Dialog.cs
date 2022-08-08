using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Bellseboss/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private string option;
    [TextArea(2,5)][SerializeField] private string dialogText;
    [SerializeField] private List<Dialog> listOfConcat;

    public string Id => id;

    public string DialogText
    {
        get
        {
            var result = dialogText;
            if (HasNextDialog)
            {
                for (int i = 0; i < listOfConcat.Count; i++)
                {
                    result += $"\n -{i+1} {listOfConcat[i].option}";   
                }
            }
            return result;
        }
    }

    public bool HasNextDialog => listOfConcat.Count >= 1;
    public string GetNextDialog(int keyPress)
    {
        return listOfConcat[keyPress - 1].id;
    }
}