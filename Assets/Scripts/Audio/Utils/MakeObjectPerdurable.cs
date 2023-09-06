public class MakeObjectPerdurable : Singleton<MakeObjectPerdurable>
{
    private void Start()
    {
        if(FindObjectsOfType<MakeObjectPerdurable>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
