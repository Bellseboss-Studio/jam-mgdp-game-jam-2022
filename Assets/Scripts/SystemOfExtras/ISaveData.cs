using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemOfExtras
{
    public interface ISaveData
    {
        Task<bool> HasData();
        List<IExtra> CreateData();
        List<IExtra> LoadData();
        void SaveData(List<IExtra> listOfExtras);
        void SaveData();
    }
}