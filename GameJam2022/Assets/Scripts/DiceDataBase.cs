using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceDataBase : MonoBehaviour
{

    public static DiceDataBase Instance { get; private set; }

    public DiceGuns diceGuns;
    public Gun wonGun;
    public Gun currentGun;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            diceGuns = new DiceGuns();
            wonGun = new Gun { gunType = Gun.GunType.PocketCannon };
            currentGun = wonGun;
            diceGuns.addGun(wonGun);
            diceGuns.addGun(new Gun { gunType = Gun.GunType.Uzi });
            diceGuns.addGun(new Gun { gunType = Gun.GunType.Eggxterminator });
            diceGuns.addGun(new Gun { gunType = Gun.GunType.TheVeryExciteingFlameThrower });
            diceGuns.addGun(new Gun { gunType = Gun.GunType.Leafy });
            diceGuns.addGun(new Gun { gunType = Gun.GunType.CarefulNotTOStepInIt });
            Instance = this;
        }
    }
}
