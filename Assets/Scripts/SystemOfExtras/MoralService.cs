namespace SystemOfExtras
{
    public class MoralService : IMoralService
    {
        private bool _isBad;
        public bool GetIsBad()
        {
            return _isBad;
        }

        public void SetIsBad(bool isBad)
        {
            _isBad = isBad;
        }
    }
}