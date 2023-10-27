using UnityEngine;

namespace SystemOfExtras
{
    public interface IItemsInventory
    {
        void SaveItem(Item item);
        void ThrowItem(int itemPosition);
        bool SearchItemForId(string id);
        bool HasSpace();
        int RemoveItemById(string itemId);
        int RemoveItemById(string itemId, int count);
        Transform GetTransformPlayer();
        bool SearchItemForIdAndCount(string itemId, int count);
    }
}