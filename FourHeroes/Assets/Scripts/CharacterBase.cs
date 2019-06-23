using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public abstract void Initialize();
    public abstract void UpdateAnimation();

    public void CopyFrom(CharacterBase character)
    {
        if (character == null)
        {
            //throw new ArgumentNullException(92021ECF - BC6D - 4200 - B1D5 - 2DBF42B793BF.B(), 92021ECF - BC6D - 4200 - B1D5 - 2DBF42B793BF.b());
        }
        this.Head = character.Head;
        this.Body = character.Body;
        this.Ears = character.Ears;
        this.Hair = character.Hair;
        this.Expression = character.Expression;
        this.Expressions = character.Expressions;
        this.Beard = character.Beard;
        this.Helmet = character.Helmet;
        this.Glasses = character.Glasses;
        this.Mask = character.Mask;
        this.Armor = character.Armor;
        this.PrimaryMeleeWeapon = character.PrimaryMeleeWeapon;
        this.SecondaryMeleeWeapon = character.SecondaryMeleeWeapon;
        this.Cape = character.Cape;
        this.Back = character.Back;
        this.Shield = character.Shield;
        this.Bow = character.Bow;
        foreach (SpriteRenderer spriteRenderer in base.GetComponentsInChildren<SpriteRenderer>(true)) //.Where(new Func<SpriteRenderer, bool>(CharacterBase.A.SpriteRen)))
        {
            foreach (SpriteRenderer spriteRenderer2 in character.GetComponentsInChildren<SpriteRenderer>(true))
            {
                if (spriteRenderer.name == spriteRenderer2.name && spriteRenderer.transform.parent.name == spriteRenderer2.transform.parent.name)
                {
                    spriteRenderer.color = spriteRenderer2.color;
                    break;
                }
            }
        }
        this.WeaponType = character.WeaponType;
        this.Initialize();
    }

    [Header("Body")]
    public Sprite Head;
    public Sprite HeadMask;
    public Sprite Ears;
    public Sprite Hair;
    public SpriteMask HairMask;
    public Sprite Beard;
    public List<Sprite> Body;

    [Header("Expressions")]
    public string Expression = "Default";
    public List<Expression> Expressions;

    [Header("Equipment")]
    public Sprite Helmet;
    public Sprite Earrings;
    public Sprite Glasses;
    public Sprite Mask;
    public Sprite PrimaryMeleeWeapon;
    public Sprite SecondaryMeleeWeapon;
    public List<Sprite> Armor;
    public Sprite Cape;
    public Sprite Back;
    public Sprite Shield;
    public List<Sprite> Bow;

    [Header("Renderers")]
    public SpriteRenderer HeadRenderer;
    public SpriteRenderer EarsRenderer;
    public SpriteRenderer HairRenderer;
    public SpriteRenderer EyebrowsRenderer;
    public SpriteRenderer EyesRenderer;
    public SpriteRenderer MouthRenderer;
    public SpriteRenderer BeardRenderer;
    public List<SpriteRenderer> BodyRenderers;
    public SpriteRenderer HelmetRenderer;
    public SpriteRenderer GlassesRenderer;
    public SpriteRenderer MaskRenderer;
    public SpriteRenderer EarringsRenderer;
    public SpriteRenderer PrimaryMeleeWeaponRenderer;
    public SpriteRenderer PrimaryMeleeWeaponTrailRenderer;
    public SpriteRenderer SecondaryMeleeWeaponRenderer;
    public SpriteRenderer SecondaryMeleeWeaponTrailRenderer;
    public List<SpriteRenderer> ArmorRenderers;
    public SpriteRenderer CapeRenderer;
    public SpriteRenderer BackRenderer;
    public SpriteRenderer ShieldRenderer;
    public List<SpriteRenderer> BowRenderers;

    [Header("Animation")]
    public Animator Animator;
    public WeaponType WeaponType;

    /*[CompilerGenerated]
    [Serializable]
    private sealed class A
    {
        internal bool CheckSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            return spriteRenderer.sprite != null;
        }

        public static readonly CharacterBase.A CharBase = new CharacterBase.A();

        public static Func<SpriteRenderer, bool> SpriteRen;
    }*/
}