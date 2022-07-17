using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAssets : MonoBehaviour
{
    public static GunAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite LeafySprite;
    public Sprite EggxterminatorSprite;
    public Sprite IceStaffSprite;
    public Sprite PocketCannonSprite;
    public Sprite UziSprite;
    public Sprite TotallyOriginalConceptSprite;
    public Sprite TheVeryExciteingFlameThrowerSprite;
    public Sprite CarefulNotTOStepInItSprite;
    public Sprite White;

    public Object LeafyPref;
    public Object EggxterminatorPref;
    public Object IceStaffPref;
    public Object PocketCannonPref;
    public Object UziPref;
    public Object TotallyOriginalConceptPref;
    public Object TheVeryExciteingFlameThrowerPref;
    public Object CarefulNotTOStepInItPref;

    public Gun.GunType getGun(int index)
    {
        switch (index)
        {
            default:
            case 1: return Gun.GunType.Leafy;
            case 2: return Gun.GunType.Eggxterminator;
            case 3: return Gun.GunType.IceStaff;
            case 4: return Gun.GunType.PocketCannon;
            case 5: return Gun.GunType.Uzi;
            case 6: return Gun.GunType.TotallyOriginalConcept;
            case 7: return Gun.GunType.TheVeryExciteingFlameThrower;
            case 8: return Gun.GunType.CarefulNotTOStepInIt;
        }
    } 

}
