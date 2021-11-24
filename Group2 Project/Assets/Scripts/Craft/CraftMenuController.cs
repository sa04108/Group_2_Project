using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftMenuController : MonoBehaviour {
    Inventory inven;
    ItemData itemDB;
    CraftEquipmentSlot equipSlot;
    [SerializeField]

    //장비
    //검 버튼
    public Button SwordCraftButton;
    public Button EnchantSwordCraftButton;
    //방패 버튼
    public Button ShieldCraftButton;
    public Button EnchantShieldCraftButton;
    //활 버튼
    public Button BowCraftButton;
    public Button EnchantBowCraftButton;
    //폭탄 버튼
    public Button BombCraftButton;

    //도구
    //망치 버튼
    public Button HammerCraftButton;
    //도끼 버튼
    public Button WoodAxeCraftButton;
    public Button RockAxeCraftButton;
    public Button IronAxeCraftButton;
    //곡괭이 버튼
    public Button WoodPickAxeCraftButton;
    public Button RockPickAxeCraftButton;
    public Button IronPickAxeCraftButton;

    private void Start() {
        inven = Inventory.instance;
        equipSlot = CraftEquipmentSlot.instance;
        itemDB = ItemData.instance;

        SwordCraftButton.onClick.AddListener(() => {
            CraftSword();
        });
        EnchantSwordCraftButton.onClick.AddListener(() => {
            EnchantSword();
        });
        BowCraftButton.onClick.AddListener(() => {
            CraftBow();
        });
        EnchantBowCraftButton.onClick.AddListener(() => {
            EnchantBow();
        });
        HammerCraftButton.onClick.AddListener(() => {
            CraftHammer();
        });
        WoodAxeCraftButton.onClick.AddListener(() => {
            CraftWoodAxe();
        });
        RockAxeCraftButton.onClick.AddListener(() => {
            CraftRockAxe();
        });
        IronAxeCraftButton.onClick.AddListener(() => {
            CraftIronAxe();
        });
        WoodPickAxeCraftButton.onClick.AddListener(() => {
            CraftWoodPickAxe();
        });
        RockPickAxeCraftButton.onClick.AddListener(() => {
            CraftRockPickAxe();
        });
        IronPickAxeCraftButton.onClick.AddListener(() => {
            CraftIronPickAxe();
        });
        BombCraftButton.onClick.AddListener(() => {
            CraftBomb();
        });
        ShieldCraftButton.onClick.AddListener(() => {
            CraftShield();
        });
        EnchantShieldCraftButton.onClick.AddListener(() => {
            EnchantShield();
        });

        initButtonUI();

    }

    public void initButtonUI() {
        //검
        if (equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX] == null) {//등록된 무기가없을때
            SwordCraftButton.gameObject.SetActive(true);
            EnchantSwordCraftButton.gameObject.SetActive(false);
        } else if (equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip.equipTier == 1) {//무기가 있을떄
            SwordCraftButton.gameObject.SetActive(false);
            EnchantSwordCraftButton.gameObject.SetActive(true);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip.equipTier == 2) {//강화된 무기가 있을때
            SwordCraftButton.gameObject.SetActive(false);
            EnchantSwordCraftButton.gameObject.SetActive(false);
        }
        //활
        if (equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX] == null) {
            BowCraftButton.gameObject.SetActive(true);
            EnchantBowCraftButton.gameObject.SetActive(false);
        }else if(equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip.equipTier == 1) {
            BowCraftButton.gameObject.SetActive(false);
            EnchantBowCraftButton.gameObject.SetActive(true);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip.equipTier == 2) {
            BowCraftButton.gameObject.SetActive(false);
            EnchantBowCraftButton.gameObject.SetActive(false);
        }
        //해머
        if (equipSlot.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX] == null) {
            HammerCraftButton.gameObject.SetActive(true);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].equip.equipTier == 1) {
            HammerCraftButton.gameObject.SetActive(false);
        }
        //도끼
        if (equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX] == null) {
            WoodAxeCraftButton.gameObject.SetActive(true);
            RockAxeCraftButton.gameObject.SetActive(false);
            IronAxeCraftButton.gameObject.SetActive(false);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip.equipTier == 1) {
            WoodAxeCraftButton.gameObject.SetActive(false);
            RockAxeCraftButton.gameObject.SetActive(true);
            IronAxeCraftButton.gameObject.SetActive(false);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip.equipTier == 2) {
            WoodAxeCraftButton.gameObject.SetActive(false);
            RockAxeCraftButton.gameObject.SetActive(false);
            IronAxeCraftButton.gameObject.SetActive(true);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip.equipTier == 3) {
            WoodAxeCraftButton.gameObject.SetActive(false);
            RockAxeCraftButton.gameObject.SetActive(false);
            IronAxeCraftButton.gameObject.SetActive(false);
        }
        //곡괭이
        if (equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX] == null) {
            WoodPickAxeCraftButton.gameObject.SetActive(true);
            RockPickAxeCraftButton.gameObject.SetActive(false);
            IronPickAxeCraftButton.gameObject.SetActive(false);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip.equipTier == 1) {
            WoodPickAxeCraftButton.gameObject.SetActive(false);
            RockPickAxeCraftButton.gameObject.SetActive(true);
            IronPickAxeCraftButton.gameObject.SetActive(false);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip.equipTier == 2) {
            WoodPickAxeCraftButton.gameObject.SetActive(false);
            RockPickAxeCraftButton.gameObject.SetActive(false);
            IronPickAxeCraftButton.gameObject.SetActive(true);
        }
        else if (equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip.equipTier == 3) {
            WoodPickAxeCraftButton.gameObject.SetActive(false);
            RockPickAxeCraftButton.gameObject.SetActive(false);
            IronPickAxeCraftButton.gameObject.SetActive(false);
        }
    }

    public void CraftSword() {
        List<Recipes> recipes = SwordCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment sword = itemDB.equipDB[CommonDefine.EQUIPMENT_SWORD];
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip = sword;
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(sword);
            SwordCraftButton.gameObject.SetActive(false);
            EnchantSwordCraftButton.gameObject.SetActive(true);
        }
    }

    public void EnchantSword() {
        List<Recipes> recipes = EnchantSwordCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment sword = itemDB.equipDB[CommonDefine.EQUIPMENT_ENCHANTED_SWORD];
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip = sword;
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(sword);
            EnchantSwordCraftButton.gameObject.SetActive(false);
        }
    }

    public void CraftShield() {
        List<Recipes> recipes = ShieldCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if(CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment shield = itemDB.equipDB[CommonDefine.EQUIPMENT_SHIELD];

            inven.AddEquip(shield);
            ShieldCraftButton.gameObject.SetActive(false);
            EnchantShieldCraftButton.gameObject.SetActive(true);
        }
    }

    public void EnchantShield() {

    }

    public void CraftBow() {
        List<Recipes> recipes = BowCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment bow = itemDB.equipDB[CommonDefine.EQUIPMENT_BOW];
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip = bow;
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(bow);
            BowCraftButton.gameObject.SetActive(false);
            EnchantBowCraftButton.gameObject.SetActive(true);
        }
    }

    public void EnchantBow() {
        List<Recipes> recipes = EnchantBowCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if(CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment bow = itemDB.equipDB[CommonDefine.EQUIPMENT_ENCHANTED_BOW];
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip = bow;
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(bow);
            EnchantBowCraftButton.gameObject.SetActive(false);
        }
    }

    public void CraftHammer() {
        List<Recipes> recipes = HammerCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if(CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment hammer = itemDB.equipDB[CommonDefine.EQUIPMENT_HAMMER];
            equipSlot.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].equip = hammer;
            equipSlot.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(hammer);
            HammerCraftButton.gameObject.SetActive(false);
        }
    }

    public void CraftWoodAxe() {
        List<Recipes> recipes = WoodAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment axe = itemDB.equipDB[CommonDefine.EQUIPMENT_WOOD_AXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip = axe;
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(axe);
            WoodAxeCraftButton.gameObject.SetActive(false);
            RockAxeCraftButton.gameObject.SetActive(true);
        }
    }

    public void CraftRockAxe() {
        List<Recipes> recipes = RockAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment axe = itemDB.equipDB[CommonDefine.EQUIPMENT_ROCK_AXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip = axe;
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(axe);
            RockAxeCraftButton.gameObject.SetActive(false);
            IronAxeCraftButton.gameObject.SetActive(true);
        }
    }

    public void CraftIronAxe() {
        List<Recipes> recipes = IronAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment axe = itemDB.equipDB[CommonDefine.EQUIPMENT_IRON_AXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip = axe;
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(axe);
            IronAxeCraftButton.gameObject.SetActive(false);
        }
    }

    public void CraftWoodPickAxe() {
        List<Recipes> recipes = WoodPickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment pickAxe = itemDB.equipDB[CommonDefine.EQUIPMENT_WOOD_PICKAXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip = pickAxe;
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(pickAxe);
            WoodPickAxeCraftButton.gameObject.SetActive(false);
            RockPickAxeCraftButton.gameObject.SetActive(true);
        }
    }

    public void CraftRockPickAxe() {
        List<Recipes> recipes = RockPickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment pickAxe = itemDB.equipDB[CommonDefine.EQUIPMENT_ROCK_PICKAXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip = pickAxe;
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(pickAxe);
            RockPickAxeCraftButton.gameObject.SetActive(false);
            IronPickAxeCraftButton.gameObject.SetActive(true);
        }
    }

    public void CraftIronPickAxe() {
        List<Recipes> recipes = IronPickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment pickAxe = itemDB.equipDB[CommonDefine.EQUIPMENT_IRON_PICKAXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip = pickAxe;
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(pickAxe);
            IronPickAxeCraftButton.gameObject.SetActive(false);
        }
    }

    public void CraftBomb() {
        List<Recipes> recipes = BombCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment bomb = itemDB.equipDB[CommonDefine.EQUIPMENT_BOMB];
            equipSlot.slot[CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX].equip = bomb;
            equipSlot.slot[CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(bomb);
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
                    //inven.onChangeItem.Invoke();
                    break;
                }
            }
        }
    }

}
