using System.Collections.Generic;
using UnityEngine;

namespace SystemOfExtras
{
    public interface IMediatorPlayer
    {
        IInputBellseboss GetInput();
        Vector3 GetPlayerPosition();
        void SetListOfMission(List<MissionDetail> ingredientsDetails);
    }
}