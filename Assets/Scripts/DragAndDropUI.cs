using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using plyGame;

// перетаскивание скилов на экшн бар и с него
public class DragAndDropUI : MonoBehaviour {

    float offsetX;
    float offsetY;
    public GameObject dragObj;
    Vector3 startPos;


    public void OnPointerDown() {
        if (dragObj == null)
            SetDragObj(this.gameObject);

        startPos = dragObj.GetComponent<RectTransform>().localPosition;
    }


    public void BeginDrag() {
        if (dragObj == null)
            SetDragObj(this.gameObject);

        offsetX = dragObj.transform.position.x - Input.mousePosition.x;
        offsetY = dragObj.transform.position.y - Input.mousePosition.y;      
    }


    public void OnDrag() {
        if (dragObj == null)
            SetDragObj(this.gameObject);
        dragObj.transform.position = new Vector3(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
    }


    public void OnEndDrag() {
        if (dragObj == null)
            SetDragObj(this.gameObject);
        
        if (dragObj.name.IndexOf("skill") != -1) {
            // Определим номер скила в иерархии скилов
            GameObject skillsContent = GameObject.Find("RPG_UI/Skills/Wrapper/Skills/Content");
            int skillBtnNum = 0;
            for (int i = 0; i < skillsContent.transform.childCount; ++i) {
                if (dragObj.name == skillsContent.transform.GetChild(i).name) {
                    skillBtnNum = i;
                }
            }


            // Определяем на какой слот в actionBar'е кинули скил
            GameObject actionBar = GameObject.Find("RPG_UI/ActionBar");            
            var oPosition = dragObj.transform.position;
            
            // Ставим значение кнопки, на которую кидаем скилл в -1, чтобы если никуда не кинули - то только обновили бы панель скилов
            // Иначе же, установили бы скил куда надо и обновили бы панель скилов для того, чтобы значок вернулся на место
            int dropBtnNum = -1;
            int skillNumOnActionBar = -1;
            string clearSkillName = dragObj.name.Replace("skill", "").Trim();            
            

            for (int i = 0; i < actionBar.transform.childCount; ++i) {

                // Узнаем приземлился ли скил куда надо и выведываем номер слота
                var oBarPosition = actionBar.transform.GetChild(i).transform.position;
                if ( ((oPosition.y <= oBarPosition.y && oPosition.y >= oBarPosition.y - 24) || (oPosition.y - 32 <= oBarPosition.y - 8 && oPosition.y - 32 >= oBarPosition.y - 32)) &&
                     ((oPosition.x >= oBarPosition.x && oPosition.x <= oPosition.x + 24) || (oPosition.x + 32 >= oBarPosition.x + 8 && oPosition.x + 32 <= oPosition.x + 32)) )  {

                    dropBtnNum = int.Parse(actionBar.transform.GetChild(i).name.Replace("Button ", "").Trim());
                } 

                // Определяем был ли в ActionBar'е уже этот скил и если да - то заносим его номер в переменную для удаления                
                RawImage img = actionBar.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<RawImage>();
                if (img.texture.name == clearSkillName) {
                    skillNumOnActionBar = i;
                }
            }

            
            // Устанавливаем скил в новую ячейку
            if (dropBtnNum >= 0) {
                // Удаляем лишний скил с ActionBar'a
                if (skillNumOnActionBar >= 0) {
                    plyRPG.plyRPG_UI.Instance.RemoveFromActionBar(skillNumOnActionBar);
                }

                plyRPG.plyRPG_UI.Instance.OnSkillButton(skillBtnNum);
                plyRPG.plyRPG_UI.Instance.SetSkillToSlot(dropBtnNum);                
            }

            plyRPG.plyRPG_UI.Instance.UpdateSkillsPanel();
        }
    }


    public void SetDragObj(GameObject target) {
        dragObj = target;
    }


    public void RemoveFromActionBar(int slotNum) {
        if (dragObj == null)
            SetDragObj(this.gameObject);

        GameObject actionBar = GameObject.Find("RPG_UI/ActionBar");

        if (dragObj.transform.position.y - 32 > actionBar.transform.position.y || dragObj.transform.position.y < actionBar.transform.position.y - 32 ||
            dragObj.transform.position.x + 32 < actionBar.transform.position.x - 240 || dragObj.transform.position.x > actionBar.transform.position.x + 250) {
            //Debug.Log(dragObj.transform.position.x + "-" + actionBar.transform.position.x + "; " + dragObj.transform.position.y + "-" + actionBar.transform.position.y);
            plyRPG.plyRPG_UI.Instance.RemoveFromActionBar(slotNum);            
        }
        dragObj.GetComponent<RectTransform>().localPosition = startPos;
    }


    public void RemoveFromActionBarWithoutDrag(int slotNum) {
        if (dragObj == null)
            SetDragObj(this.gameObject);
        
        plyRPG.plyRPG_UI.Instance.RemoveFromActionBar(slotNum);      
    }
}
