using System.Linq;
using UnityEngine;

/// <summary>
/// Changing equipment at runtime examples.
/// </summary>
public class RuntimeSetup : MonoBehaviour
{
    public Character Character;

    public void Start()
    {
        EquipArmor("Slave");
    }

    /// <summary>
    /// Example call: SetBody("HeadScar", "Basic", "Human", "Basic");
    /// </summary>
    public void SetBody(string headName, string bodyName)
    {
        var head = SpriteCollection.Instance.Head.Single(i => i.cosmeticName == headName);
        var body = SpriteCollection.Instance.Body.Single(i => i.cosmeticName == bodyName);

        Character.SetBody(head.sprites[0], body.sprites);
    }

    public void EquipMeleeWeapon1H(string sname)
    {
        var entry = SpriteCollection.Instance.MeleeWeapon1H.Single(i => i.cosmeticName == sname);

        //1 - Weapon, 2 - Trail
        Character.EquipMeleeWeapon(entry.sprites[0], entry.sprites[1]);
    }

    public void EquipMeleeWeapon2H(string sname)
    {
        var entry = SpriteCollection.Instance.MeleeWeapon2H.Single(i => i.cosmeticName == sname);

        Character.EquipMeleeWeapon(entry.sprites[0], entry.sprites[1], true);
    }

    public void EquipBow(string sname)
    {
        var entry = SpriteCollection.Instance.Bow.Single(i => i.cosmeticName == sname);

        Character.EquipBow(entry.sprites);
    }

    public void EquipShield(string sname)
    {
        var entry = SpriteCollection.Instance.Shield.Single(i => i.cosmeticName == sname);

        Character.EquipShield(entry.sprites[0]);
    }

    public void EquipArmor(string sname)
    {
        var entry = (ArmourSet)SpriteCollection.Instance.Armor.Single(i => i.cosmeticName == sname);

        Character.EquipArmor(entry.sprites, entry.helmet, entry.cape);
    }
}