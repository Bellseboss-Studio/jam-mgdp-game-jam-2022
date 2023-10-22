using UnityEngine;

namespace SystemOfExtras
{
    public interface IMediatorPlayer
    {
        IInputBellseboss GetInput();
        Vector3 GetPlayerPosition();
    }
}