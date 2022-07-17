using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void button(int index)
    {
        CharacterController2D player = GameObject.FindWithTag("Player").GetComponent<CharacterController2D>();
        DiceGuns diceGun = DiceDataBase.Instance.diceGuns;
        diceGun.getList()[index] = DiceDataBase.Instance.wonGun;
        player.updateDiceGun(diceGun);
    }

    public void exit()
    {
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
    }
}
