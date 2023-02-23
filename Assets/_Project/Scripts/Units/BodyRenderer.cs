using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using Descending.Equipment;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descending.Units
{
    public enum BodyParts
    {
        Head_Cover_Full, Head_Cover_Hair, Head_Cover_No_Hair, Ears,
        Hair, Facial_Hair, Eyebrows, Face, Back, Head_Attachment,  Hip_Attachment,
        Shoulder_Left, Shoulder_Right, Elbow_Left, Elbow_Right, Knee_Left, Knee_Right, 
        Head, Torso, Arm_Left, Arm_Right, Wrist_Left, Wrist_Right, Hand_Left, Hand_Right, Legs, Foot_Left, Foot_Right,
        Number, None
    }

    public enum HeadCoverType
    {
        Full_Head, Hair, No_Hair, No_Facial_Hair,
        Number, None
    }
    
    public class BodyRenderer : MonoBehaviour
    {
        [SerializeField] private Transform _partsRoot = null;
        [SerializeField] private Color _defaultSkinColor = Color.white;
        [SerializeField] private Color _defaultScarColor = Color.white;
        [SerializeField] private Color _defaultStubbleColor = Color.white;
        [SerializeField] private Color _defaultHairColor = Color.white;
        [SerializeField] private Color _defaultEyeColor = Color.white;
        [SerializeField] private Color _defaultTattooColor = Color.black;
        
        [SerializeField] private Transform _closeCameraMount = null;
        [SerializeField] private Transform _farCameraMount = null;
        [SerializeField] private Transform _rightHandMount = null;
        [SerializeField] private Transform _leftHandMount = null;
        
        private List<List<Transform>> _partsList;
        private Genders _gender;
        private int _headIndex = -1;
        private int _hairIndex = -1;
        private int _earIndex = -1;
        private int _facialHairIndex = -1;
        private int _eyebrowIndex = -1;
        private int _skinColorIndex = -1;
        private int _tattooColorIndex = -1;
        private int _hairColorIndex = -1;
        private int _eyeColorIndex = -1;

        public Genders Gender => _gender;
        public int HeadIndex => _headIndex;
        public int HairIndex => _hairIndex;
        public int EarIndex => _earIndex;
        public int FacialHairIndex => _facialHairIndex;
        public int EyebrowIndex => _eyebrowIndex;
        public int SkinColorIndex => _skinColorIndex;
        public int TattooColorIndex => _tattooColorIndex;
        public int HairColorIndex => _hairColorIndex;
        public int EyeColorIndex => _eyeColorIndex;

        public void RandomizeDetails(Genders gender, RaceDefinition race, ProfessionDefinition profession)
        {
            _headIndex = Random.Range(0, _partsList[(int)BodyParts.Head].Count);
            _hairIndex = Random.Range(0, _partsList[(int)BodyParts.Hair].Count);
            _eyebrowIndex = Random.Range(0, _partsList[(int)BodyParts.Eyebrows].Count);
            _facialHairIndex = Random.Range(0, _partsList[(int)BodyParts.Facial_Hair].Count);
            _hairColorIndex = Random.Range(0, race.HairColors.Count);
            _eyeColorIndex = Random.Range(0, race.EyeColors.Count);
            _skinColorIndex = Random.Range(0, race.SkinColors.Count);
            _tattooColorIndex = Random.Range(0, race.TattooColors.Count);
        }
        
        public void SetDetails(BodyRenderer renderer)
        {
            _headIndex = renderer.HeadIndex;
            _hairIndex = renderer.HairIndex;
            _eyebrowIndex = renderer.EyebrowIndex;
            _facialHairIndex = renderer.FacialHairIndex;
            _hairColorIndex = renderer._hairColorIndex;
            _eyeColorIndex = renderer.EyeColorIndex;
            _skinColorIndex = renderer.SkinColorIndex;
            _tattooColorIndex = renderer.TattooColorIndex;
        }

        public void LoadDetails(HeroSaveData saveData)
        {
            _headIndex = saveData.HeadIndex;
            _hairIndex = saveData.HairIndex;
            _eyebrowIndex = saveData.EyebrowIndex;
            _facialHairIndex = saveData.FacialHairIndex;
            _hairColorIndex = saveData.HairColorIndex;
            _eyeColorIndex = saveData.EyeColorIndex;
            _skinColorIndex = saveData.SkinColorIndex;
            _tattooColorIndex = saveData.TattooColorIndex;
        }
        
        public void SetupBody(Genders gender, RaceDefinition race, ProfessionDefinition profession)
        {
            SetupParts();
            HideAll();
            _gender = gender;
            RandomizeDetails(gender, race, profession);
            
            SetPartEnabled(BodyParts.Head, _headIndex, true);
            
            if(race.HairAllowed == true)
                SetPartEnabled(BodyParts.Hair, _hairIndex, true);
            
            if(race.EyebrowsAllowed == true)
                SetPartEnabled(BodyParts.Eyebrows, _eyebrowIndex, true);

            if (gender == Genders.Male && Random.Range(0, 100) < race.MaleBeardChance)
                SetPartEnabled(BodyParts.Facial_Hair, _facialHairIndex, true);
            else if (gender == Genders.Female && Random.Range(0, 100) < race.FemaleBeardChance)
                SetPartEnabled(BodyParts.Facial_Hair, _facialHairIndex, true);

            SetPartEnabled(BodyParts.Torso, 0, true);
            SetPartEnabled(BodyParts.Arm_Left, 0, true);
            SetPartEnabled(BodyParts.Arm_Right, 0, true);
            SetPartEnabled(BodyParts.Wrist_Left, 0, true);
            SetPartEnabled(BodyParts.Wrist_Right, 0, true);
            SetPartEnabled(BodyParts.Hand_Left, 0, true);
            SetPartEnabled(BodyParts.Hand_Right, 0, true);
            SetPartEnabled(BodyParts.Legs, 0, true);
            SetPartEnabled(BodyParts.Foot_Left, 0, true);
            SetPartEnabled(BodyParts.Foot_Right, 0, true);

            if (_gender == Genders.Male)
            {
                SetSkinColorInstance(race.SkinColors[_skinColorIndex], race.ScarColors[_skinColorIndex],
                    race.StubbleColors[_skinColorIndex], race.TattooColors[_tattooColorIndex]);
            }
            else if (_gender == Genders.Female)
            {
                SetSkinColorInstance(race.SkinColors[_skinColorIndex], race.ScarColors[_skinColorIndex],
                    race.SkinColors[_skinColorIndex], race.TattooColors[_tattooColorIndex]);
            }

            SetHairColorInstance(race.HairColors[_hairColorIndex]);
            SetEyeColorInstance(race.EyeColors[_eyeColorIndex]);
            
            if (race.EarIndex > -1)
            {
                _earIndex = race.EarIndex;
                SetPartEnabled(BodyParts.Ears, _earIndex, true);
            }
        }
        
        public void SetupBody(BodyRenderer bodyRenderer, RaceDefinition race, ProfessionDefinition profession)
        {
            SetupParts();
            HideAll();
            _gender = bodyRenderer.Gender;
            SetDetails(bodyRenderer);
            
            SetPartEnabled(BodyParts.Head, _headIndex, true);
            
            if(race.HairAllowed == true)
                SetPartEnabled(BodyParts.Hair, _hairIndex, true);
            
            if(race.EyebrowsAllowed == true)
                SetPartEnabled(BodyParts.Eyebrows, _eyebrowIndex, true);

            if (_gender == Genders.Male && Random.Range(0, 100) < race.MaleBeardChance)
                SetPartEnabled(BodyParts.Facial_Hair, _facialHairIndex, true);
            else if (_gender == Genders.Female && Random.Range(0, 100) < race.FemaleBeardChance)
                SetPartEnabled(BodyParts.Facial_Hair, _facialHairIndex, true);

            SetPartEnabled(BodyParts.Torso, 0, true);
            SetPartEnabled(BodyParts.Arm_Left, 0, true);
            SetPartEnabled(BodyParts.Arm_Right, 0, true);
            SetPartEnabled(BodyParts.Wrist_Left, 0, true);
            SetPartEnabled(BodyParts.Wrist_Right, 0, true);
            SetPartEnabled(BodyParts.Hand_Left, 0, true);
            SetPartEnabled(BodyParts.Hand_Right, 0, true);
            SetPartEnabled(BodyParts.Legs, 0, true);
            SetPartEnabled(BodyParts.Foot_Left, 0, true);
            SetPartEnabled(BodyParts.Foot_Right, 0, true);

            if (_gender == Genders.Male)
            {
                SetSkinColorInstance(race.SkinColors[_skinColorIndex], race.ScarColors[_skinColorIndex],
                    race.StubbleColors[_skinColorIndex], race.TattooColors[_tattooColorIndex]);
            }
            else if (_gender == Genders.Female)
            {
                SetSkinColorInstance(race.SkinColors[_skinColorIndex], race.ScarColors[_skinColorIndex],
                    race.SkinColors[_skinColorIndex], race.TattooColors[_tattooColorIndex]);
            }

            SetHairColorInstance(race.HairColors[_hairColorIndex]);
            SetEyeColorInstance(race.EyeColors[_eyeColorIndex]);
            
            if (race.EarIndex > -1)
            {
                _earIndex = race.EarIndex;
                SetPartEnabled(BodyParts.Ears, _earIndex, true);
            }
        }
        
        public void LoadBody(HeroSaveData saveData)
        {
            RaceDefinition race = Database.instance.Races.GetRace(saveData.RaceKey);
            
            SetupParts();
            HideAll();
            _gender = saveData.Gender;
            LoadDetails(saveData);
            
            SetPartEnabled(BodyParts.Head, _headIndex, true);
            
            if(race.HairAllowed == true)
                SetPartEnabled(BodyParts.Hair, _hairIndex, true);
            
            if(race.EyebrowsAllowed == true)
                SetPartEnabled(BodyParts.Eyebrows, _eyebrowIndex, true);
        
            if (saveData.Gender == Genders.Male)
                SetPartEnabled(BodyParts.Facial_Hair, _facialHairIndex, true);
        
            SetPartEnabled(BodyParts.Torso, 0, true);
            SetPartEnabled(BodyParts.Arm_Left, 0, true);
            SetPartEnabled(BodyParts.Arm_Right, 0, true);
            SetPartEnabled(BodyParts.Wrist_Left, 0, true);
            SetPartEnabled(BodyParts.Wrist_Right, 0, true);
            SetPartEnabled(BodyParts.Hand_Left, 0, true);
            SetPartEnabled(BodyParts.Hand_Right, 0, true);
            SetPartEnabled(BodyParts.Legs, 0, true);
            SetPartEnabled(BodyParts.Foot_Left, 0, true);
            SetPartEnabled(BodyParts.Foot_Right, 0, true);
        
            if (_gender == Genders.Male)
            {
                SetSkinColorInstance(race.SkinColors[_skinColorIndex], race.ScarColors[_skinColorIndex],
                    race.StubbleColors[_skinColorIndex], race.TattooColors[_tattooColorIndex]);
            }
            else if (_gender == Genders.Female)
            {
                SetSkinColorInstance(race.SkinColors[_skinColorIndex], race.ScarColors[_skinColorIndex],
                    race.SkinColors[_skinColorIndex], race.TattooColors[_tattooColorIndex]);
            }
        
            SetHairColorInstance(race.HairColors[_hairColorIndex]);
            SetEyeColorInstance(race.EyeColors[_eyeColorIndex]);
            
            if (race.EarIndex > -1)
            {
                _earIndex = race.EarIndex;
                SetPartEnabled(BodyParts.Ears, _earIndex, true);
            }
        }

        public void SetLeftHandMount(Transform mount)
        {
            _leftHandMount = mount;
        }

        public void SetRightHandMount(Transform mount)
        {
            _rightHandMount = mount;
        }

        public void SetCloseCameraMount(Transform mount)
        {
            _closeCameraMount = mount;
        }

        public void SetFarCameraMount(Transform mount)
        {
            _farCameraMount = mount;
        }

        public void SetPartsRoot(Transform root)
        {
            _partsRoot = root;
        }

        public void SetDefaultColors(Color skinColor, Color scarColor, Color stubbleColor, Color hairColor, Color eyeColor, Color tattooColor)
        {
            _defaultSkinColor = skinColor;
            _defaultEyeColor = eyeColor;
            _defaultHairColor = hairColor;
            _defaultScarColor = scarColor;
            _defaultStubbleColor = stubbleColor;
            _defaultTattooColor = tattooColor;
        }
        
        private void SetupParts()
        {
            _partsList = new List<List<Transform>>();
            
            for (int p = 0; p < _partsRoot.childCount; p++)
            {
                Transform parent = _partsRoot.GetChild(p);
                _partsList.Add(new List<Transform>());
                
                for (int c = 0; c < _partsRoot.GetChild(p).childCount; c++)
                {
                    Transform child = parent.transform.GetChild(c);
                    _partsList[p].Add(child);
                }
            }
        }

        private void SetChildrenEnabled(BodyParts part, bool isEnabled)
        {
            foreach (Transform child in _partsList[(int)part])
            {
                child.gameObject.SetActive(isEnabled);
            }
        }

        private void SetPartEnabled(BodyParts part, int index, bool isEnabled)
        {
            if (_partsList[(int) part].Count > 0)
            {
                _partsList[(int) part][index].gameObject.SetActive(isEnabled);
            }
        }
        
        [Button("Reset Body")]
        public void ResetBody()
        {
            SetupParts();
            HideAll();
            if(_gender == Genders.Male)
            {
                SetSkinColorShared(_defaultSkinColor, _defaultScarColor, _defaultStubbleColor, _defaultTattooColor);
            }
            else if (_gender == Genders.Female)
            {
                SetSkinColorShared(_defaultSkinColor, _defaultScarColor, _defaultSkinColor, _defaultTattooColor);
            }
            
            SetHairColorShared(_defaultHairColor);            
            SetEyeColorShared(_defaultEyeColor);

            SetPartEnabled(BodyParts.Head, 0, true);
            SetPartEnabled(BodyParts.Hair, 0, true);
            SetPartEnabled(BodyParts.Torso, 0, true);
            SetPartEnabled(BodyParts.Arm_Left, 0, true);
            SetPartEnabled(BodyParts.Arm_Right, 0, true);
            SetPartEnabled(BodyParts.Wrist_Left, 0, true);
            SetPartEnabled(BodyParts.Wrist_Right, 0, true);
            SetPartEnabled(BodyParts.Hand_Left, 0, true);
            SetPartEnabled(BodyParts.Hand_Right, 0, true);
            SetPartEnabled(BodyParts.Legs, 0, true);
            SetPartEnabled(BodyParts.Foot_Left, 0, true);
            SetPartEnabled(BodyParts.Foot_Right, 0, true);
        }

        private void HideAll()
        {
            for (int i = 0; i < (int)BodyParts.Number; i++)
            {
                SetChildrenEnabled((BodyParts)i, false);
            }
        }

        private void ShowAll()
        {
            for (int i = 0; i < (int)BodyParts.Number; i++)
            {
                SetChildrenEnabled((BodyParts)i, true);
            }
        }
        private void SetSkinColorInstance(Color skinColor, Color scarColor, Color stubbleColor, Color tattooColor)
        {
            foreach (Transform child in _partsList[(int) BodyParts.Head])
            {
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
                SetColorInstance(child.gameObject, "_Color_Scar", scarColor);
                SetColorInstance(child.gameObject, "_Color_Stubble", stubbleColor);
                SetColorInstance(child.gameObject, "_Color_BodyArt", tattooColor);
            }

            foreach (Transform child in _partsList[(int) BodyParts.Ears])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);

            foreach (Transform child in _partsList[(int)BodyParts.Torso])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Legs])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Arm_Left])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Arm_Right])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Wrist_Left])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Wrist_Right])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Hand_Left])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Hand_Right])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Foot_Left])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Foot_Right])
                SetColorInstance(child.gameObject, "_Color_Skin", skinColor);
        }
        
        private void SetSkinColorShared(Color skinColor, Color scarColor, Color stubbleColor, Color tattooColor)
        {
            foreach (Transform child in _partsList[(int) BodyParts.Head])
            {
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
                SetColorShared(child.gameObject, "_Color_Scar", scarColor);
                SetColorShared(child.gameObject, "_Color_Stubble", stubbleColor);
                SetColorShared(child.gameObject, "_Color_BodyArt", tattooColor);
            }
            
            foreach (Transform child in _partsList[(int)BodyParts.Ears])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);

            foreach (Transform child in _partsList[(int)BodyParts.Torso])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Legs])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Arm_Left])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Arm_Right])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Wrist_Left])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Wrist_Right])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Hand_Left])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Hand_Right])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Foot_Left])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Foot_Right])
                SetColorShared(child.gameObject, "_Color_Skin", skinColor);
        }

        private void SetHairColorInstance(Color hairColor)
        {
            foreach (Transform child in _partsList[(int)BodyParts.Head])
                SetColorInstance(child.gameObject, "_Color_Hair", hairColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Hair])
                SetColorInstance(child.gameObject, "_Color_Hair", hairColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Facial_Hair])
                SetColorInstance(child.gameObject, "_Color_Hair", hairColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Eyebrows])
                SetColorInstance(child.gameObject, "_Color_Hair", hairColor);
        }

        private void SetHairColorShared(Color hairColor)
        {
            foreach (Transform child in _partsList[(int)BodyParts.Head])
                SetColorShared(child.gameObject, "_Color_Hair", hairColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Hair])
                SetColorShared(child.gameObject, "_Color_Hair", hairColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Facial_Hair])
                SetColorShared(child.gameObject, "_Color_Hair", hairColor);
            
            foreach (Transform child in _partsList[(int)BodyParts.Eyebrows])
                SetColorShared(child.gameObject, "_Color_Hair", hairColor);
        }

        private void SetEyeColorInstance(Color eyeColor)
        {
            foreach (Transform child in _partsList[(int)BodyParts.Head])
                SetColorInstance(child.gameObject, "_Color_Eyes", eyeColor);
        }

        private void SetEyeColorShared(Color eyeColor)
        {
            foreach (Transform child in _partsList[(int)BodyParts.Head])
                SetColorShared(child.gameObject, "_Color_Eyes", eyeColor);
        }
        
        private void SetColorInstance(GameObject go, string parameter, Color color)
        {
            go.GetComponent<SkinnedMeshRenderer>().material.SetColor(parameter, color);
        }
        
        private void SetColorShared(GameObject go, string parameter, Color color)
        {
            go.GetComponent<SkinnedMeshRenderer>().sharedMaterial.SetColor(parameter, color);
        }

        public void UnequipItem(Item item, int slot)
        {
            if ((EquipmentSlots)slot == EquipmentSlots.Melee_Weapon)
            {
                _rightHandMount.ClearTransform();
            }
            else if((EquipmentSlots)slot == EquipmentSlots.Ranged_Weapon)
            {
                _leftHandMount.ClearTransform();
            }
            else if((EquipmentSlots)slot == EquipmentSlots.Off_Weapon)
            {
                _leftHandMount.ClearTransform();
            }
            else if((EquipmentSlots)slot == EquipmentSlots.Ammo)
            {
                //_leftHandMount.ClearTransform();
            }
            else
            {
                foreach (var renderSlot in item.RenderSlots)
                {
                    SetChildrenEnabled(renderSlot.BodyPart, false);
                    SetPartEnabled(renderSlot.BodyPart, 0, true);  
                }
            }
        }
        
        public void EquipItem(Item item, bool portrait)
        {
            if (item.ItemDefinition.Category == ItemCategory.Weapons)
            {
                EquipWeapon(item, portrait);
            }
            else if (item.ItemDefinition.Category == ItemCategory.Shields)
            {
                EquipWeapon(item, portrait);
            }
            else if (item.ItemDefinition.Category == ItemCategory.Wearable)
            {
                foreach (var renderSlot in item.RenderSlots)
                {
                    SetChildrenEnabled(renderSlot.BodyPart, false);
                    SetPartEnabled(renderSlot.BodyPart, renderSlot.Index, true);  
                } 
            }
        }
        
        public void EquipWeapon(Item item, bool portrait)
        {
            if (item == null || item.Key == "" || item.GetWeaponData() == null) return;

            //Debug.Log("Equipping");
            if (item.ItemDefinition.Hands == Hands.Right)
            {
                _rightHandMount.ClearTransform();
                GameObject clone = item.SpawnItemModel(_rightHandMount, 0);

                if (portrait == true)
                {
                    var children = clone.GetComponentsInChildren<Transform>(includeInactive: true);
                    foreach (var child in children)
                    {
                        child.gameObject.layer = LayerMask.NameToLayer("Portrait Light");
                    }
                }
                //_animationController.SetOverride(item.GetWeaponData().AnimatorOverride);
                
            }
            else if (item.ItemDefinition.Hands == Hands.Left)
            {
                _leftHandMount.ClearTransform();
                GameObject clone = item.SpawnItemModel(_leftHandMount, 0);
                
                if (portrait == true)
                {
                    var children = clone.GetComponentsInChildren<Transform>(includeInactive: true);
                    foreach (var child in children)
                    {
                        child.gameObject.layer = LayerMask.NameToLayer("Portrait Light");
                    }
                }
                //_animationController.SetOverride(item.GetWeaponData().AnimatorOverride);
            }
        }
        
        public void MountCloseCamera(Camera camera)
        {
            camera.transform.SetParent(_closeCameraMount, false);
            camera.transform.localPosition = Vector3.zero;
            camera.transform.localScale = Vector3.one;
            camera.transform.rotation = _closeCameraMount.transform.rotation;
        }

        public void MountFarCamera(Camera camera)
        {
            camera.transform.SetParent(_farCameraMount, false);
            camera.transform.localPosition = Vector3.zero;
            camera.transform.localScale = Vector3.one;
            camera.transform.rotation = _closeCameraMount.transform.rotation;
        }
    }
}
