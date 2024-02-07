using RPGLib.Classes;
using System.Numerics;

namespace RPGLib;
public class Commands
{
    public void CharacterMove(Character character, Vector3 direction)
    {
        character.position += direction;
    }

    public void LootCorpse(Character character, Character corpse)
    {
        foreach (Item item in corpse.inventory.GetType().GetProperties()
                            .Where(pi => pi.PropertyType == typeof(int))
                            .Select(pi => (Item)pi.GetValue(corpse))
                            .Where(value => value != null)
        )
        {
            character.inventory.items.Add(item);
        }

        character.money += corpse.money;
    }

    public void SellItem(ref Item item, Character character, Character merchant)
    {
        character.money += item.worthGold;
        merchant.inventory.items.Add(item);
        character.inventory.items.Remove(item);
    }

    public void BuyItem(Item item, Character character, Character merchant)
    {
        if (character.money < item.worthGold)
            return;

        character.money -= item.worthGold;
        character.inventory.items.Add(item);
    }

    public void Equip(Character character, Item item, InventorySlot slot)
    {
        Item i = character.inventory.items.Where(x => x.Equals(item)).First();
        UnEquip(character, slot);
        if (i.inventorySlot == slot)
            i.EquipedSlot = slot;
    }

    public void UnEquip(Character character, InventorySlot slot)
    {
        Item oldi = character.inventory.items.Where(x => x.EquipedSlot == slot).First();
        if (oldi != null) // unequip old slotted item
        {
            oldi.EquipedSlot = InventorySlot.none;
        }
    }

    public void TradeItems(Character Sender, List<Item> SenderItems, int SenderMoney, Character Receiver, List<Item> ReceiverItems, int ReceiverMoney)
    {
        if (SenderItems.Count > 0)
        {
            foreach (Item item in SenderItems)
            {
                Item oldi = Sender.inventory.items.Where(x => x.name == item.name).First();
                if (oldi != null) // unequip old slotted item
                {
                    oldi.EquipedSlot = InventorySlot.none;
                    Receiver.inventory.items.Add(oldi);
                }
            }
        }
        Receiver.money += SenderMoney;

        if (ReceiverItems.Count > 0)
        {
            foreach (Item item in ReceiverItems)
            {
                Item oldi = Receiver.inventory.items.Where(x => x.name == item.name).First();
                if (oldi != null) // unequip old slotted item
                {
                    oldi.EquipedSlot = InventorySlot.none;
                    Sender.inventory.items.Add(oldi);
                }
            }
        }
        Sender.money += ReceiverMoney;
    }
}
