using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftMenuController : MonoBehaviour
{
    Inventory inven;
    ItemData itemDB;
    CraftEquipmentSlot equipSlot;
    [SerializeField]
    public Button SwordCraftButton;
    public Button HammerCraftButton;
    public Button AxeCraftButton;
    public Button PickAxeCraftButton;

    private void Start() {
        inven = Inventory.instance;
        equipSlot = CraftEquipmentSlot.instance;
        itemDB = ItemData.instance;
        SwordCraftButton.onClick.AddListener(() => {
            CraftSword();
        });
        HammerCraftButton.onClick.AddListener(() => {
            CraftHammer();
        });
        AxeCraftButton.onClick.AddListener(() => {
            CraftAxe();
        });
        PickAxeCraftButton.onClick.AddListener(() => {
            CraftPickAxe();
        });
    }

    public void CraftSword() {
        List<Recipes> recipes = SwordCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment sword = itemDB.equipDB[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX];
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].UpdateSlotUI(sword);
        }
    }

    public void CraftHammer() {
        List<Recipes> recipes = HammerCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if(CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment hammer = itemDB.equipDB[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX];
            equipSlot.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].UpdateSlotUI(hammer);
        }

    }

    public void CraftAxe() {
        List<Recipes> recipes = AxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment axe = itemDB.equipDB[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX];
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].UpdateSlotUI(axe);
        }
    }
    public void CraftPickAxe() {
        List<Recipes> recipes = PickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment pickAxe = itemDB.equipDB[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX];
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].UpdateSlotUI(pickAxe);
        }
    }

    public bool CheckResource(List<Recipes> recipes, List<Item> items) {
        int nameCheck = 0;
        int quantityCheck = 0;

  
        foreach(Recipes recipe in recipes) {
            foreach(Item item in items) {
                if (recipe.resourceName == item.itemName) {
                    nameCheck++;
                    if(recipe.resourceCount <= item.itemCount)
                        quantityCheck++;
                    break;
                }
            }
        }
        if((nameCheck == recipes.Count) && (quantityCheck == recipes.Count)) {
            return true;
        }

        return false;
    }

    public void CraftObject(List<Recipes> recipes, List<Item> items) {
        foreach (Recipes recipe in recipes) {
            foreach (Item item in items) {
                if (recipe.resourceName == item.itemName) {
                    item.itemCount -= recipe.resourceCount;
                    inven.onChangeItem.Invoke();
                    break;
                }
            }
        }
    }

}
