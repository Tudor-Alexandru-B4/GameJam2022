using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{

    public enum GunType
    {
        Leafy,
        Eggxterminator,
        IceStaff,
        PocketCannon,
        Uzi,
        TotallyOriginalConcept,
        TheVeryExciteingFlameThrower,
        CarefulNotTOStepInIt
    }

    public GunType gunType;

    public Sprite getSprite()
    {
        switch (gunType)
        {
            default:
            case GunType.Leafy: return GunAssets.Instance.LeafySprite;
            case GunType.Eggxterminator: return GunAssets.Instance.EggxterminatorSprite;
            case GunType.IceStaff: return GunAssets.Instance.IceStaffSprite;
            case GunType.PocketCannon: return GunAssets.Instance.PocketCannonSprite;
            case GunType.Uzi: return GunAssets.Instance.UziSprite;
            case GunType.TotallyOriginalConcept: return GunAssets.Instance.TotallyOriginalConceptSprite;
            case GunType.TheVeryExciteingFlameThrower: return GunAssets.Instance.TheVeryExciteingFlameThrowerSprite;
            case GunType.CarefulNotTOStepInIt: return GunAssets.Instance.CarefulNotTOStepInItSprite;
        }
    }

    public Object getPrefab()
    {
        switch (gunType)
        {
            default:
            case GunType.Leafy: return GunAssets.Instance.LeafyPref;
            case GunType.Eggxterminator: return GunAssets.Instance.EggxterminatorPref;
            case GunType.IceStaff: return GunAssets.Instance.IceStaffPref;
            case GunType.PocketCannon: return GunAssets.Instance.PocketCannonPref;
            case GunType.Uzi: return GunAssets.Instance.UziPref;
            case GunType.TotallyOriginalConcept: return GunAssets.Instance.TotallyOriginalConceptPref;
            case GunType.TheVeryExciteingFlameThrower: return GunAssets.Instance.TheVeryExciteingFlameThrowerPref;
            case GunType.CarefulNotTOStepInIt: return GunAssets.Instance.CarefulNotTOStepInItPref;
        }
    }

    public float getFireRate()
    {
        switch (gunType)
        {
            default:
            case GunType.Leafy: return 1;
            case GunType.Eggxterminator: return 2;
            case GunType.IceStaff: return 3;
            case GunType.PocketCannon: return 4;
            case GunType.Uzi: return 5;
            case GunType.TotallyOriginalConcept: return 6;
            case GunType.TheVeryExciteingFlameThrower: return 7;
            case GunType.CarefulNotTOStepInIt: return 8;
        }
    }

    public float getAttack()
    {
        switch (gunType)
        {
            default:
            case GunType.Leafy: return 1;
            case GunType.Eggxterminator: return 2;
            case GunType.IceStaff: return 3;
            case GunType.PocketCannon: return 4;
            case GunType.Uzi: return 5;
            case GunType.TotallyOriginalConcept: return 6;
            case GunType.TheVeryExciteingFlameThrower: return 7;
            case GunType.CarefulNotTOStepInIt: return 8;
        }
    }
}
