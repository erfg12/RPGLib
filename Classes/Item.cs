namespace RPGLib.Classes;
public class Item
{
    public string name {  get; set; }
    public string description { get; set; } = string.Empty;
    public Affect affect { get; set; } = new Affect();
    public InventorySlot inventorySlot { get; set; }
    public InventorySlot EquipedSlot { get; set; } = 0;
    public int worthGold { get; set; } = 0;
}
