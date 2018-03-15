using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shopVendor : MonoBehaviour
{
    public GameObject shopCanvas;
    public Image shopItemImg;
    GameObject gm;
    string shopitemnametemp;
    bool allowBuy = false;
    public itemsInShop[] canvasButtons;
    public int itemToBuyINT=10;

	void Start ()
    {
        gm = GameObject.FindWithTag("GameManagementTag");
    }
	void Update ()
    {

	}
    #region vendorButtons
    public void v1() { itemToBuyINT = 0; itemPictures(); }
    public void v2() { itemToBuyINT = 1; itemPictures(); }
    public void v3() { itemToBuyINT = 2; itemPictures(); }
    public void v4() { itemToBuyINT = 3; itemPictures(); }
    public void v5() { itemToBuyINT = 4; itemPictures(); }
    public void v6() { itemToBuyINT = 5; itemPictures(); }
    public void v7() { itemToBuyINT = 6; itemPictures(); }
    public void v8() { itemToBuyINT = 7; itemPictures(); }
    public void v9() { itemToBuyINT = 8; itemPictures(); }
    public void v10() { itemToBuyINT = 9; itemPictures(); }

    public void Buy()
    {
        allowBuy = true;
        wendorItemBuying();
    }
    public void exit()
    {
        shopCanvas.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    #endregion
    public void wendorItemBuying()
    {
        for (int p = 0; p < 10; p++)
        {//valittu tuote listalta
            if (p == itemToBuyINT)
            {
                for (int y=0;y< gm.GetComponent<gamemanagement>().AllItems.Length; y++)
                {
                    //saman niminen item allitems listalta
                    if (gm.GetComponent<gamemanagement>().AllItems[y].name == canvasButtons[p].itemNameHolder.text)
                    {
                        for (int u = 0; u < gm.GetComponent<gamemanagement>().playersBackpack.Length; u++)
                        {//space in backpack
                            if (gm.GetComponent<gamemanagement>().playersBackpack[u].name == "" && gm.GetComponent<gamemanagement>().money > canvasButtons[p].cost && allowBuy == true)
                            {
                                gm.GetComponent<gamemanagement>().playersBackpack[u] = gm.GetComponent<gamemanagement>().AllItems[y];
                                gm.GetComponent<gamemanagement>().money = gm.GetComponent<gamemanagement>().money - canvasButtons[p].cost;
                                allowBuy = false;
                                return;
                            }
                            else if (allowBuy == true && gm.GetComponent<gamemanagement>().money < canvasButtons[p].cost)
                            {
                                Debug.Log("NOT ENOUGH MONEY");
                                shopCanvas.SetActive(false);
                                Cursor.visible = false;
                                Time.timeScale = 1;
                            }
                        }
                    }
                }
            }
        }
        itemToBuyINT = 10;
    }
    public void itemPictures()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "s1") { shopitemnametemp = canvasButtons[0].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s2") { shopitemnametemp = canvasButtons[1].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s3") { shopitemnametemp = canvasButtons[2].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s4") { shopitemnametemp = canvasButtons[3].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s5") { shopitemnametemp = canvasButtons[4].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s6") { shopitemnametemp = canvasButtons[5].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s7") { shopitemnametemp = canvasButtons[6].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s8") { shopitemnametemp = canvasButtons[7].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s9") { shopitemnametemp = canvasButtons[8].itemNameHolder.text; }
            if (EventSystem.current.currentSelectedGameObject.name == "s10") { shopitemnametemp = canvasButtons[9].itemNameHolder.text; }

            for (int g = 0; g < 10; g++)
            {
                for (int r = 0; r < gm.GetComponent<gamemanagement>().AllItems.Length; r++)
                {
                    if (gm.GetComponent<gamemanagement>().AllItems[g].name == shopitemnametemp)
                    {
                        shopItemImg.sprite = gm.GetComponent<gamemanagement>().AllItems[g].itemImage;
                    }
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        shopCanvas.SetActive(true);
        Cursor.visible=true;
        Time.timeScale = 0;
    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
}
[System.Serializable]
public class itemsInShop
{
    public Text itemNameHolder;
    public int cost;
}
