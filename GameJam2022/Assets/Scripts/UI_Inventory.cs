using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private DiceGuns diceGuns;
    private Transform diceContainer;
    private Transform diceTemplate;
    private Transform textTemplate;

    private float[] xArray = { 0, -1, 1, 2, 0, 2 };
    private float[] yArray = { 0, 0, 0, 0, -1, 1 };
    private float cellSize = 95f;

    private void Awake()
    {
        diceContainer = transform.Find("DiceBorder");
        diceTemplate = diceContainer.Find("DiceTemplate");
        textTemplate = diceContainer.Find("TextTemplate");
    }

    public void setDice(DiceGuns diceGuns)
    {
        this.diceGuns = diceGuns;
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        Gun gun = null;

        do
        {
            gun = new Gun { gunType = GunAssets.Instance.getGun(Random.Range(0, 8)) };
        } while (haveAlready(gun));

        DiceDataBase.Instance.wonGun = gun;

        foreach(Transform child in diceContainer)
        {
            if (child == diceTemplate || child == textTemplate) continue;
            Destroy(child.gameObject);
        }

        int i = 0;
        foreach(Gun it in diceGuns.getList())
        {
            RectTransform itemSlot = Instantiate(diceTemplate, diceContainer).GetComponent<RectTransform>();
            itemSlot.gameObject.SetActive(true);
            itemSlot.anchoredPosition = new Vector2(xArray[i] * cellSize, yArray[i] * (cellSize + 5));
            Image image = itemSlot.GetComponent<Image>();
            image.sprite = it.getSprite();
            i++;
        }

        if(gun != null)
        {
            RectTransform itemSlot = Instantiate(diceTemplate, diceContainer).GetComponent<RectTransform>();
            itemSlot.gameObject.SetActive(true);
            itemSlot.anchoredPosition = new Vector2(4 * (cellSize + 5), 45);
            Image image = itemSlot.GetComponent<Image>();
            image.sprite = gun.getSprite();

            RectTransform atackText = Instantiate(textTemplate, diceContainer).GetComponent<RectTransform>();
            atackText.gameObject.SetActive(true);
            atackText.anchoredPosition = new Vector2(4 * (cellSize), -35);
            TMP_Text text1 = atackText.GetComponent<TMP_Text>();
            text1.text = "Attack: " + gun.getAttack().ToString();

            RectTransform rateText = Instantiate(textTemplate, diceContainer).GetComponent<RectTransform>();
            rateText.gameObject.SetActive(true);
            rateText.anchoredPosition = new Vector2(4 * (cellSize), -85);
            TMP_Text text2 = rateText.GetComponent<TMP_Text>();
            text2.text = "FireRate: " + gun.getFireRate().ToString();
        }
    }

    private bool haveAlready(Gun gun)
    {
        foreach(Gun it in diceGuns.getList())
        {
            if (it.gunType == gun.gunType)
                return true;
        }
        return false;
    }

}
