namespace RPGLib.Classes
{
    public class Quest
    {
        public string title {  get; set; }
        public string information { get; set; }
        public int rewardGold { get; set; }
        public List<Item> rewardItems {  get; set; }
        public int rewardExperience { get; set; }
    }
}
