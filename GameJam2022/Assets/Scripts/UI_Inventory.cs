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
    private Transform diceRoll;

    private float[] xArray = { 0, -1, 1, 2, 0, 2 };
    private float[] yArray = { 0, 0, 0, 0, -1, 1 };
    private float cellSize = 95f;

    private void Awake()
    {
        gameObject.GetComponentInParent<Canvas>().enabled = false;
        diceContainer = transform.Find("DiceBorder");
        diceTemplate = diceContainer.Find("DiceTemplate");
        textTemplate = diceContainer.Find("TextTemplate");
        diceRoll = transform.Find("DiceRoll");
    }

    public void setDice(DiceGuns diceGuns)
    {
        Debug.Log("CE");
        this.diceGuns = diceGuns;
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        diceGuns = DiceDataBase.Instance.diceGuns;
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

            RectTransform tutText = Instantiate(textTemplate, diceContainer).GetComponent<RectTransform>();
            tutText.gameObject.SetActive(true);
            tutText.anchoredPosition = new Vector2(4 * (cellSize), 150);
            TMP_Text text3 = tutText.GetComponent<TMP_Text>();
            text3.text = "Exchange Dice Face?";
        }
    }

    public IEnumerator rollAnimation()
    {
        GameObject.Find("Buttons").SetActive(false);
        GameObject.Find("DiceTemplate").SetActive(false);
        GameObject.Find("TextTemplate").SetActive(false);
        int count = 0;
        foreach (Transform child in diceContainer)
        {
            if (count < 8)
            {
                count++;
                continue;
            }
            Destroy(child.gameObject);
        }
        Vector3 temp = diceContainer.localScale;
        for(int i = 1; i < 11; i++)
        {
            diceContainer.localScale = new Vector3(diceContainer.localScale.x - 0.1f, diceContainer.localScale.y - 0.1f, diceContainer.localScale.z);
            yield return new WaitForSeconds(0.05f);
        }
        

        RectTransform itemSlot = Instantiate(diceRoll, diceContainer.parent).GetComponent<RectTransform>();
        itemSlot.gameObject.SetActive(true);
        itemSlot.anchoredPosition = new Vector2(0,0);
        StartCoroutine(exchangeAnim(itemSlot,temp));

        

    }

    private IEnumerator exchangeAnim(Transform dice, Vector3 temp)
    {
        Gun gun = new Gun();

        for (int i = 0; i < 50; i++)
        {
            gun = DiceDataBase.Instance.diceGuns.getList()[Random.Range(0, 6)];
            int index = Random.Range(1, 7);
            bool[] matrix;

            switch (index)
            {
                default:
                case 1: matrix = new bool[] {false, false, false, false, true, false, false, false, false };break;
                case 2: matrix = new bool[] { true, false, false, false, false, false, false, false, true }; break;
                case 3: matrix = new bool[] { true, false, false, false, true, false, false, false, true }; break;
                case 4: matrix = new bool[] { true, false, true, false, false, false, true, false, true }; break;
                case 5: matrix = new bool[] { true, false, true, false, true, false, true, false, true }; break;
                case 6: matrix = new bool[] { true, false, true, true, false, true, true, false, true }; break;
            }
            int counter = -1;
            foreach (Transform child in dice)
            {
                if(counter == -1)
                {
                    counter++;
                    continue;
                }
                if (matrix[counter++])
                {
                    child.GetComponent<Image>().sprite = gun.getSprite();
                }
                else
                {
                    child.GetComponent<Image>().sprite = GunAssets.Instance.White;
                }
            }

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);

        int count = 0;
        foreach (Transform child in diceContainer.parent)
        {
            if (count < 4)
            {
                count++;
                continue;
            }
            Destroy(child.gameObject);
        }

        diceContainer.localScale = temp;
        diceContainer.parent.GetChild(0).gameObject.SetActive(true);
        diceContainer.parent.GetChild(1).gameObject.SetActive(true);
        diceContainer.parent.GetChild(2).gameObject.SetActive(true);
        diceContainer.parent.GetChild(3).gameObject.SetActive(true);
        diceContainer.GetChild(0).gameObject.SetActive(true);
        diceContainer.GetChild(1).gameObject.SetActive(true);

        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

        GameObject.FindWithTag("Player").GetComponent<CharacterController2D>().changeGun(gun);

        yield return new WaitForSeconds(2f);

        GameObject.FindWithTag("Player").GetComponent<CharacterController2D>().loadRandomScene();
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
