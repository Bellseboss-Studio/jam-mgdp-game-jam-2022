namespace SystemOfExtras
{
    public interface IItemsInventory
    {
        void SaveItem(Item item);
        public void ThrowItem(int itemPosition);
    }
}