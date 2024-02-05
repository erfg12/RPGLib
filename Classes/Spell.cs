namespace RPGLib.Classes;
public class Spell
{
    string name {  get; set; }
    string description { get; set; } = string.Empty;
    Affect affect { get; set; } = new Affect();
    int directDamage { get; set; } = 0;
}
