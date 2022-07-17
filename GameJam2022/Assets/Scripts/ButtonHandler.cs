using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void button(int index)
    {
        Debug.Log("UWU");
        CharacterController2D player = GameObject.FindWithTag("Player").GetComponent<CharacterController2D>();
        DiceGuns diceGun = DiceDataBase.Instance.diceGuns;
        diceGun.getList()[index] = DiceDataBase.Instance.wonGun;
        DiceDataBase.Instance.diceGuns = diceGun;
        player.updateDiceGun(diceGun);
        changeExit();
    }

    public void exit()
    {
        Debug.Log("UWU");
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
    }

    public void changeExit()
    {
        Debug.Log("UWU");
        GameObject.FindWithTag("Player").GetComponent<CharacterController2D>().diceAnim();
        //GameObject.FindWithTag("Player").GetComponent<CharacterController2D>().changeGun();
        //exit();
    }
}
