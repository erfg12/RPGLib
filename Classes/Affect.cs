namespace RPGLib.Classes;
public class Affect // buffs, debuffs
{
    string name {  get; set; }
    Stats stats { get; set; } = new Stats();
    int damageOverTime { get; set; } = 0;
}
