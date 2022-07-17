using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGuns
{

    List<Gun> gunList;

    // Start is called before the first frame update
    public DiceGuns()
    {
        gunList = new List<Gun>();
    }
    
    public void addGun(Gun gun)
    {
        gunList.Add(gun);
    }

    public void replaceGun(Gun oldGun, Gun newGun)
    {
        int index = gunList.FindIndex(s => s.gunType == oldGun.gunType);
        if(index != -1)
        {
            gunList[index] = newGun;
        }
    }

    public List<Gun> getList()
    {
        return gunList;
    }
}
