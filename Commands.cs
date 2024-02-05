using RPGLib.Classes;
using System.Numerics;
using System.Reflection;

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

        character.money.gold += corpse.money.gold;
    }

    public void SellItem(Item item, Character character, Character merchant)
    {
        character.money.gold += item.worthGold;
        item = null;
    }

    public void BuyItem(Item item, Character character, Character merchant)
    {
        if (character.money.gold < item.worthGold)
            return;

        character.money.gold -= item.worthGold;
        character.inventory.items.Add(item);
    }

    public void Equip(Character character, Item item, InventorySlot slot)
    {
        var i = character.inventory.items.Where(x => x.Equals(item)).First();
        UnEquip(character, slot);
        if (i.inventorySlot == slot)
            i.EquipedSlot = slot;
    }

    public void UnEquip(Character character, InventorySlot slot)
    {
        var oldi = character.inventory.items.Where(x => x.EquipedSlot == slot).First();
        if (oldi != null) // unequip old slotted item
        {
            oldi.EquipedSlot = InventorySlot.none;
        }
    }

    public void TradeItems(Character Sender, Character Receiver)
    {

    }
}
