using System.Numerics;

namespace RPGLib.Classes;

public enum InventorySlot
{
    none,
    head,
    face,
    ears,
    neck,
    shoulders,
    arms,
    chest,
    hands,
    wrist,
    finger,
    legs,
    feet
}

public class Character
{
    public string name { get; set; }
    public int level { get; set; } = 1;
    public int experience { get; set; } = 0;
    public Vector3 position { get; set; } = new Vector3();
    public Stats stats { get; set; } = new Stats();
    public Race race { get; set; } = new Race();
    public Bag inventory { get; set; } = new Bag();
    public int money { get; set; } = 0;
}
