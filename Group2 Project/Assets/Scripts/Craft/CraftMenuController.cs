using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftMenuController : MonoBehaviour
{
    Inventory inven;
    CraftEquipmentSlot equipSlot;
    [SerializeField]
    public Button HammerCraftButton;
    public Button AxeCraftButton;
    public Button PickAxeCraftButton;

    private void Start() {
        inven = Inventory.instance;
        equipSlot = CraftEquipmentSlot.instance;
        HammerCraftButton.onClick.AddListener(() => {
            CraftHammer();
        });
        AxeCraftButton.onClick.AddListener(() => {
            CraftAxe();
        });
        HammerCraftButton.onClick.AddListener(() => {
            CraftPickAxe();
        });
    }

    public void CraftHammer() {
        List<Recipes> recipes = HammerCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if(CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
        }
        //equipSlot.slot[equipSlot.slot.Length] = ;
    }

    public void CraftAxe() {
        List<Recipes> recipes = AxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
        }
    }
    public void CraftPickAxe() {
        List<Recipes> recipes = PickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
        }
    }

    public bool CheckResource(List<Recipes> recipes, List<Item> items) {
        int nameCheck = 0;
        int quantityCheck = 0;

        foreach(Recipes recipe in recipes) {
            foreach(Item item in items) {
                if(recipe.resourceName == item.itemName) {
                    nameCheck++;
                    if(recipe.resourceCount <= item.itemCount)
                        quantityCheck++;
                    break;
                }
            }
        }

        if(nameCheck == recipes.Count && quantityCheck == recipes.Count) {
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
