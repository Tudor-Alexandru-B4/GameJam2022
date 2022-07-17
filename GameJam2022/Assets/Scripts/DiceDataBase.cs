using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDataBase : MonoBehaviour
{

    public static DiceDataBase Instance { get; private set; }

    public DiceGuns diceGuns;
    public Gun wonGun;

    private void Awake()
    {
        diceGuns = new DiceGuns();
        diceGuns.addGun(new Gun { gunType = Gun.GunType.PocketCannon });
        diceGuns.addGun(new Gun { gunType = Gun.GunType.Uzi });
        diceGuns.addGun(new Gun { gunType = Gun.GunType.Eggxterminator });
        diceGuns.addGun(new Gun { gunType = Gun.GunType.TheVeryExciteingFlameThrower });
        diceGuns.addGun(new Gun { gunType = Gun.GunType.Leafy });
        diceGuns.addGun(new Gun { gunType = Gun.GunType.CarefulNotTOStepInIt });
        wonGun = null;
        Instance = this;
    }
}
