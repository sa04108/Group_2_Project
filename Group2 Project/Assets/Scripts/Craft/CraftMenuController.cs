using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftMenuController : MonoBehaviour {
    Inventory inven;
    ItemData itemDB;
    CraftEquipmentSlot equipSlot;
    [SerializeField]

    public AudioClip craftSuccessSound;
    public AudioClip craftFailSound;
    AudioSource audioSource;
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


    //가공 버튼
    public Button BranchToWoodButton;
    public Button StoneToRockButton;
    public Button IronOreToIronIngot;
        
    private void Start() {
        inven = Inventory.instance;
        equipSlot = CraftEquipmentSlot.instance;
        itemDB = ItemData.instance;

        audioSource = GetComponent<AudioSource>();
        BranchToWoodButton.onClick.AddListener(() => {
            if (ProcessWood()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        StoneToRockButton.onClick.AddListener(() => {
            if (ProcessRock()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        IronOreToIronIngot.onClick.AddListener(() => {
            if (ProcessIron()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        SwordCraftButton.onClick.AddListener(() => {
            if (CraftSword()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        EnchantSwordCraftButton.onClick.AddListener(() => {
            if (EnchantSword()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        BowCraftButton.onClick.AddListener(() => {
            if (CraftBow()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        EnchantBowCraftButton.onClick.AddListener(() => {
            if (EnchantBow()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        HammerCraftButton.onClick.AddListener(() => {
            if (CraftHammer()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        WoodAxeCraftButton.onClick.AddListener(() => {
            if (CraftWoodAxe()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        RockAxeCraftButton.onClick.AddListener(() => {
            if (CraftRockAxe()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        IronAxeCraftButton.onClick.AddListener(() => {
            if (CraftIronAxe()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        WoodPickAxeCraftButton.onClick.AddListener(() => {
            if (CraftWoodPickAxe()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        RockPickAxeCraftButton.onClick.AddListener(() => {
            if (CraftRockPickAxe()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        IronPickAxeCraftButton.onClick.AddListener(() => {
            if (CraftIronPickAxe()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        BombCraftButton.onClick.AddListener(() => {
            if (CraftBomb()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        ShieldCraftButton.onClick.AddListener(() => {
            if (CraftShield()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
        });
        EnchantShieldCraftButton.onClick.AddListener(() => {
            if (EnchantShield()) {
                audioSource.clip = craftSuccessSound;
                audioSource.Play();
            }
            else {
                audioSource.clip = craftFailSound;
                audioSource.Play();
            }
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

    public bool CheckHammer() {
        foreach(Equipment equip in inven.equipments) {
            if (equip.equipType == EQUIP_TYPE.HAMMER) {
                return true;
            }
        }
        return false;
    }

    public bool CraftSword() {

        if (!CheckHammer()) return false;

        List<Recipes> recipes = SwordCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment sword = itemDB.equipDB[CommonDefine.EQUIPMENT_SWORD];
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip = sword;
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(sword);
            SwordCraftButton.gameObject.SetActive(false);
            EnchantSwordCraftButton.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }

    public bool EnchantSword() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = EnchantSwordCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment sword = itemDB.equipDB[CommonDefine.EQUIPMENT_ENCHANTED_SWORD];
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip = sword;
            equipSlot.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(sword);
            EnchantSwordCraftButton.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public bool CraftShield() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = ShieldCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment shield = itemDB.equipDB[CommonDefine.EQUIPMENT_SHIELD];

            inven.AddEquip(shield);
            inven.shield = true;
            ShieldCraftButton.gameObject.SetActive(false);
            EnchantShieldCraftButton.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }

    public bool EnchantShield() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = ShieldCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment enchantShield = itemDB.equipDB[CommonDefine.EQUIPMENT_ENCHANTED_SHIELD];

            inven.AddEquip(enchantShield);
            inven.enchantShield = true;

            EnchantShieldCraftButton.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public bool CraftBow() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = BowCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment bow = itemDB.equipDB[CommonDefine.EQUIPMENT_BOW];
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip = bow;
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(bow);
            BowCraftButton.gameObject.SetActive(false);
            EnchantBowCraftButton.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }

    public bool EnchantBow() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = EnchantBowCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment bow = itemDB.equipDB[CommonDefine.EQUIPMENT_ENCHANTED_BOW];
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip = bow;
            equipSlot.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(bow);
            EnchantBowCraftButton.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public bool CraftHammer() {

        List<Recipes> recipes = HammerCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment hammer = itemDB.equipDB[CommonDefine.EQUIPMENT_HAMMER];
            equipSlot.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].equip = hammer;
            equipSlot.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(hammer);
            HammerCraftButton.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public bool CraftWoodAxe() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = WoodAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment axe = itemDB.equipDB[CommonDefine.EQUIPMENT_WOOD_AXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip = axe;
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(axe);
            WoodAxeCraftButton.gameObject.SetActive(false);
            RockAxeCraftButton.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }

    public bool CraftRockAxe() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = RockAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment axe = itemDB.equipDB[CommonDefine.EQUIPMENT_ROCK_AXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip = axe;
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(axe);
            RockAxeCraftButton.gameObject.SetActive(false);
            IronAxeCraftButton.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }

    public bool CraftIronAxe() {
        if (!CheckHammer()) return false ;
        List<Recipes> recipes = IronAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment axe = itemDB.equipDB[CommonDefine.EQUIPMENT_IRON_AXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip = axe;
            equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(axe);
            IronAxeCraftButton.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public bool CraftWoodPickAxe() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = WoodPickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment pickAxe = itemDB.equipDB[CommonDefine.EQUIPMENT_WOOD_PICKAXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip = pickAxe;
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(pickAxe);
            WoodPickAxeCraftButton.gameObject.SetActive(false);
            RockPickAxeCraftButton.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }

    public bool CraftRockPickAxe() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = RockPickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment pickAxe = itemDB.equipDB[CommonDefine.EQUIPMENT_ROCK_PICKAXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip = pickAxe;
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(pickAxe);
            RockPickAxeCraftButton.gameObject.SetActive(false);
            IronPickAxeCraftButton.gameObject.SetActive(true);
            return true;
        }
        else return false;
    }

    public bool CraftIronPickAxe() {
        if (!CheckHammer()) return false;
        List<Recipes> recipes = IronPickAxeCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment pickAxe = itemDB.equipDB[CommonDefine.EQUIPMENT_IRON_PICKAXE];
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip = pickAxe;
            equipSlot.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(pickAxe);
            IronPickAxeCraftButton.gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public bool CraftBomb() {
        if (!CheckHammer()) return false; 
        List<Recipes> recipes = BombCraftButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Equipment bomb = itemDB.equipDB[CommonDefine.EQUIPMENT_BOMB];
            equipSlot.slot[CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX].equip = bomb;
            equipSlot.slot[CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX].UpdateSlotUI();
            inven.AddEquip(bomb);
            return true;
        }
        return false;
    }


    public bool ProcessWood() {
        List<Recipes> recipes = BranchToWoodButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Item wood = itemDB.itemDB[CommonDefine.RESOURCE_WOOD];
            inven.AddItem(wood);
            return true;
        }
        else return false;
    }
    public bool ProcessRock() {
        List<Recipes> recipes = StoneToRockButton.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Item rock = itemDB.itemDB[CommonDefine.RESOURCE_ROCK];
            inven.AddItem(rock);
            return true;
        }
        else return false;
    }
    public bool ProcessIron() {
        List<Recipes> recipes = IronOreToIronIngot.gameObject.GetComponent<CraftRecipe>().recipes;
        if (CheckResource(recipes, inven.items)) {
            CraftObject(recipes, inven.items);
            Item iron = itemDB.itemDB[CommonDefine.RESOURCE_IRON_INGOT];
            inven.AddItem(iron);
            return true;
        }
        else return false;
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
