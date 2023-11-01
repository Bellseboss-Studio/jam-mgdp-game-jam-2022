using UnityEngine.SceneManagement;

public class EnterToApartment : InteractiveObjectFather
{
    protected override void ActionEventCustom()
    {
        SceneManager.LoadScene(6);
    }
}
