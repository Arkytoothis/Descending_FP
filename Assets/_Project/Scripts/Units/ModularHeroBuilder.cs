using System.Collections;
using System.Collections.Generic;
using Descending.Units;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Descending.Core
{
    public class ModularHeroBuilder : MonoBehaviour
    {
        [SerializeField] private Transform _root = null;
        [SerializeField] private GameObject _partsContainer = null;
        [SerializeField] private HeroBuilderParameters _parameters;

        private Animator _animator = null;
        
        private Transform _headCoverFull = null;
        private Transform _headCoverHair = null;
        private Transform _headCoverNoHair = null;
        private Transform _ears = null;
        private Transform _hair = null;
        private Transform _facialHair = null;
        private Transform _eyebrows = null;
        private Transform _face = null;
        private Transform _back = null;
        private Transform _headAttachment = null;
        private Transform _hipAttachment = null;
        private Transform _shoulderLeft = null;
        private Transform _shoulderRight = null;
        private Transform _elbowLeft = null;
        private Transform _elbowRight = null;
        private Transform _kneeLeft = null;
        private Transform _kneeRight = null;
        private Transform _head = null;
        private Transform _torso = null;
        private Transform _armLeft = null;
        private Transform _armRight = null;
        private Transform _wristLeft = null;
        private Transform _wristRight = null;
        private Transform _handLeft = null;
        private Transform _handRight = null;
        private Transform _legs = null;
        private Transform _footLeft = null;
        private Transform _footRight = null;

        private AnimationEvents _animationEvents = null;
        private BodyRenderer _bodyRenderer = null;

        private GameObject _leftHandMount = null;
        private GameObject _rightHandMount = null;
        private GameObject _closeCameraMount = null;
        private GameObject _farCameraMount = null;
        
        private void SetupPartsParent()
        {
            if (_partsContainer == null)
            {
                _partsContainer = new GameObject
                {
                    name = "Parts"
                };
                
                _partsContainer.transform.SetParent(transform);
                _partsContainer.transform.SetAsFirstSibling();
            }
        }

        private void SetupComponents()
        {
            PrefabUtility.UnpackPrefabInstance(gameObject, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            _animator = gameObject.GetComponent<Animator>();
            
            if (_animator == null)
            {
                _animator = gameObject.AddComponent<Animator>();
            }
            
            _animator.applyRootMotion = false; 
            
            _animationEvents = gameObject.GetComponent<AnimationEvents>();

            if (_animationEvents == null)
            {
                _animationEvents = gameObject.AddComponent<AnimationEvents>();
            }
            
            _bodyRenderer = gameObject.GetComponent<BodyRenderer>();

            if (_bodyRenderer == null)
            {
                _bodyRenderer = gameObject.AddComponent<BodyRenderer>();
            }
            
            _bodyRenderer.SetPartsRoot(_partsContainer.transform);
            _bodyRenderer.SetDefaultColors(_parameters.SkinColor, _parameters.ScarColor, _parameters.StubbleColor, _parameters.HairColor, _parameters.EyeColor, _parameters.TattooColor);
            
            _root = RecursiveFindChild(transform, "Root");
            
            Transform leftHandBone = RecursiveFindChild(_root, "Hand_L");

            if (leftHandBone != null)
            {
                Transform existingMount = RecursiveFindChild(_root, "Left Hand Mount");
                
                if (existingMount == null)
                {
                    _leftHandMount = new GameObject();
                    _leftHandMount.name = "Left Hand Mount";
                }
                
                _leftHandMount.transform.SetParent(leftHandBone, false);
            }

            _bodyRenderer.SetLeftHandMount(_leftHandMount.transform);
            
            Transform rightHandBone = RecursiveFindChild(_root, "Hand_R");
            if (rightHandBone != null)
            {
                Transform existingMount = RecursiveFindChild(_root, "Right Hand Mount");
                
                if (existingMount == null)
                {
                    _rightHandMount = new GameObject();
                    _rightHandMount.name = "Right Hand Mount";
                }
                
                _rightHandMount.transform.SetParent(rightHandBone, false);
            }
            
            _bodyRenderer.SetRightHandMount(_rightHandMount.transform);

            if (_closeCameraMount == null)
            {
                _closeCameraMount = new GameObject();
                _closeCameraMount.name = "Close Camera Mount";
                _closeCameraMount.transform.SetParent(transform);
            }
            _bodyRenderer.SetCloseCameraMount(_closeCameraMount.transform);
            
            if (_farCameraMount == null)
            {
                _farCameraMount = new GameObject();
                _farCameraMount.name = "Far Camera Mount";
                _farCameraMount.transform.SetParent(transform);
            }
            _bodyRenderer.SetFarCameraMount(_farCameraMount.transform);
        }

        [Button]
        public void BuildMale()
        {
            SetupPartsParent();
            SetupComponents();
            
            Transform emptyPartsParent = RecursiveFindChild(transform, _parameters.EmptyPartsFilename);

            if (emptyPartsParent != null)
            {
                DestroyImmediate(emptyPartsParent.gameObject);
            }

            _footRight = CreatePartParent(_partsContainer.transform, "Foot Right");
            MoveParts(_parameters.FootSlots, transform, _footRight, _parameters.MaleRightFootFilename);
            RemoveParts(_parameters.FootSlots, transform, _parameters.FemaleRightFootFilename);
            _footLeft = CreatePartParent(_partsContainer.transform, "Foot Left");
            MoveParts(_parameters.FootSlots, transform, _footLeft, _parameters.MaleLeftFootFilename);
            RemoveParts(_parameters.FootSlots, transform, _parameters.FemaleLeftFootFilename);
            
            _legs = CreatePartParent(_partsContainer.transform, "Legs");
            MoveParts(_parameters.LegSlots, transform, _legs, _parameters.MaleLegFilename);
            RemoveParts(_parameters.LegSlots, transform, _parameters.FemaleLegFilename);
            
            _handRight = CreatePartParent(_partsContainer.transform, "Hand Right");
            MoveParts(_parameters.HandSlots, transform, _handRight, _parameters.MaleRightHandFilename);
            RemoveParts(_parameters.HandSlots, transform, _parameters.FemaleRightHandFilename);
            _handLeft = CreatePartParent(_partsContainer.transform, "Hand Left");
            MoveParts(_parameters.HandSlots, transform, _handLeft, _parameters.MaleLeftHandFilename);
            RemoveParts(_parameters.HandSlots, transform, _parameters.FemaleLeftHandFilename);
            
            _wristRight = CreatePartParent(_partsContainer.transform, "Wrist Right");
            MoveParts(_parameters.WristSlots, transform, _wristRight, _parameters.MaleRightWristFilename);
            RemoveParts(_parameters.WristSlots, transform, _parameters.FemaleRightWristFilename);
            _wristLeft = CreatePartParent(_partsContainer.transform, "Wrist Left");
            MoveParts(_parameters.WristSlots, transform, _wristLeft, _parameters.MaleLeftWristFilename);
            RemoveParts(_parameters.WristSlots, transform, _parameters.FemaleLeftWristFilename);
            
            _armRight = CreatePartParent(_partsContainer.transform, "Arm Right");
            MoveParts(_parameters.ArmSlots, transform, _armRight, _parameters.MaleRightArmFilename);
            RemoveParts(_parameters.ArmSlots, transform, _parameters.FemaleRightArmFilename);
            _armLeft = CreatePartParent(_partsContainer.transform, "Arm Left");
            MoveParts(_parameters.ArmSlots, transform, _armLeft, _parameters.MaleLeftArmFilename);
            RemoveParts(_parameters.ArmSlots, transform, _parameters.FemaleLeftArmFilename);
            
            _torso = CreatePartParent(_partsContainer.transform, "Torso");
            MoveParts(_parameters.TorsoSlots, transform, _torso, _parameters.MaleTorsoFilename);
            RemoveParts(_parameters.TorsoSlots, transform, _parameters.FemaleTorsoFilename);
            
            _head = CreatePartParent(_partsContainer.transform, "Head");
            MoveParts(_parameters.HeadSlots, transform, _head, _parameters.MaleHeadFilename);
            RemoveParts(_parameters.HeadSlots, transform, _parameters.FemaleHeadFilename);
            
            
            
            _kneeRight = CreatePartParent(_partsContainer.transform, "Knee Right");
            MoveParts(_parameters.KneeSlots, transform, _kneeRight, _parameters.RightKneeFilename);
            _kneeLeft = CreatePartParent(_partsContainer.transform, "Knee Left");
            MoveParts(_parameters.KneeSlots, transform, _kneeLeft, _parameters.LeftKneeFilename);
            
            _elbowRight = CreatePartParent(_partsContainer.transform, "Elbow Right");
            MoveParts(_parameters.ElbowSlots, transform, _elbowRight, _parameters.RightElbowFilename);
            _elbowLeft = CreatePartParent(_partsContainer.transform, "Elbow Left");
            MoveParts(_parameters.ElbowSlots, transform, _elbowLeft, _parameters.LeftElbowFilename);
            
            _shoulderRight = CreatePartParent(_partsContainer.transform, "Shoulder Right");
            MoveParts(_parameters.ShoulderSlots, transform, _shoulderRight, _parameters.RightShoulderFilename);
            _shoulderLeft = CreatePartParent(_partsContainer.transform, "Shoulder Left");
            MoveParts(_parameters.ShoulderSlots, transform, _shoulderLeft, _parameters.LeftShoulderFilename);
            
            _hipAttachment = CreatePartParent(_partsContainer.transform, "Hip Attachment");
            MoveParts(_parameters.HipAttachmentSlots, transform, _hipAttachment, _parameters.HipAttachmentFilename);
            
            _headAttachment = CreatePartParent(_partsContainer.transform, "Head Attachment");
            MoveParts(_parameters.HeadAttachmentSlots, transform, _headAttachment, _parameters.HeadAttachmentFilename);
            
            _back = CreatePartParent(_partsContainer.transform, "Back");
            MoveParts(_parameters.BackSlots, transform, _back, _parameters.BackFilename);
            
            _face = CreatePartParent(_partsContainer.transform, "Face");
            MoveParts(_parameters.FaceSlots, transform, _face, _parameters.FaceFilename);
            
            _eyebrows = CreatePartParent(_partsContainer.transform, "Eyebrows");
            MoveParts(_parameters.EyebrowsSlots, transform, _eyebrows, _parameters.MaleEyebrowFilename);
            RemoveParts(_parameters.EyebrowsSlots, transform, _parameters.FemaleEyebrowFilename);
            
            _facialHair = CreatePartParent(_partsContainer.transform, "Facial Hair");
            MoveParts(_parameters.FacialHairSlots, transform, _facialHair, _parameters.FacialHairFilename);
            
            _hair = CreatePartParent(_partsContainer.transform, "Hair");
            MoveParts(_parameters.HairSlots, transform, _hair, _parameters.HairFilename);
            
            _ears = CreatePartParent(_partsContainer.transform, "Ears");
            MoveParts(_parameters.EarSlots, transform, _ears, _parameters.EarFilename);
            
            _headCoverNoHair = CreatePartParent(_partsContainer.transform, "Head Cover No Hair");
            MoveParts(_parameters.HeadCoverNoHairSlots, transform, _headCoverNoHair, _parameters.HeadCoverNoHairFilename);
            
            _headCoverHair = CreatePartParent(_partsContainer.transform, "Head Cover Hair");
            MoveParts(_parameters.HeadCoverHairSlots, transform, _headCoverHair, _parameters.HeadCoverHairFilename);
            
            _headCoverFull = CreatePartParent(_partsContainer.transform, "Head Cover Full");
            MoveParts(_parameters.HeadCoverFullSlots, transform, _headCoverFull, _parameters.MaleHeadCoverFullFilename);
            RemoveParts(_parameters.HeadCoverFullSlots, transform, _parameters.FemaleHeadCoverFullFilename);
            
            
            Debug.Log("Male Build Complete");
        }
        
        [Button]
        public void BuildFemale()
        {
            SetupPartsParent();
            SetupComponents();
            
            Transform emptyPartsParent = RecursiveFindChild(transform, _parameters.EmptyPartsFilename);

            if (emptyPartsParent != null)
            {
                DestroyImmediate(emptyPartsParent.gameObject);
            }

            _footRight = CreatePartParent(_partsContainer.transform, "Foot Right");
            MoveParts(_parameters.FootSlots, transform, _footRight, _parameters.FemaleRightFootFilename);
            RemoveParts(_parameters.FootSlots, transform, _parameters.MaleRightFootFilename);
            _footLeft = CreatePartParent(_partsContainer.transform, "Foot Left");
            MoveParts(_parameters.FootSlots, transform, _footLeft, _parameters.FemaleLeftFootFilename);
            RemoveParts(_parameters.FootSlots, transform, _parameters.MaleLeftFootFilename);
            
            _legs = CreatePartParent(_partsContainer.transform, "Legs");
            MoveParts(_parameters.LegSlots, transform, _legs, _parameters.FemaleLegFilename);
            RemoveParts(_parameters.LegSlots, transform, _parameters.MaleLegFilename);
            
            _handRight = CreatePartParent(_partsContainer.transform, "Hand Right");
            MoveParts(_parameters.HandSlots, transform, _handRight, _parameters.FemaleRightHandFilename);
            RemoveParts(_parameters.HandSlots, transform, _parameters.MaleRightHandFilename);
            _handLeft = CreatePartParent(_partsContainer.transform, "Hand Left");
            MoveParts(_parameters.HandSlots, transform, _handLeft, _parameters.FemaleLeftHandFilename);
            RemoveParts(_parameters.HandSlots, transform, _parameters.MaleLeftHandFilename);
            
            _wristRight = CreatePartParent(_partsContainer.transform, "Wrist Right");
            MoveParts(_parameters.WristSlots, transform, _wristRight, _parameters.FemaleRightWristFilename);
            RemoveParts(_parameters.WristSlots, transform, _parameters.MaleRightWristFilename);
            _wristLeft = CreatePartParent(_partsContainer.transform, "Wrist Left");
            MoveParts(_parameters.WristSlots, transform, _wristLeft, _parameters.FemaleLeftWristFilename);
            RemoveParts(_parameters.WristSlots, transform, _parameters.MaleLeftWristFilename);
            
            _armRight = CreatePartParent(_partsContainer.transform, "Arm Right");
            MoveParts(_parameters.ArmSlots, transform, _armRight, _parameters.FemaleRightArmFilename);
            RemoveParts(_parameters.ArmSlots, transform, _parameters.MaleRightArmFilename);
            _armLeft = CreatePartParent(_partsContainer.transform, "Arm Left");
            MoveParts(_parameters.ArmSlots, transform, _armLeft, _parameters.FemaleLeftArmFilename);
            RemoveParts(_parameters.ArmSlots, transform, _parameters.MaleLeftArmFilename);
            
            _torso = CreatePartParent(_partsContainer.transform, "Torso");
            MoveParts(_parameters.TorsoSlots, transform, _torso, _parameters.FemaleTorsoFilename);
            RemoveParts(_parameters.TorsoSlots, transform, _parameters.MaleTorsoFilename);
            
            _head = CreatePartParent(_partsContainer.transform, "Head");
            MoveParts(_parameters.HeadSlots, transform, _head, _parameters.FemaleHeadFilename);
            RemoveParts(_parameters.HeadSlots, transform, _parameters.MaleHeadFilename);
            
            
            
            _kneeRight = CreatePartParent(_partsContainer.transform, "Knee Right");
            MoveParts(_parameters.KneeSlots, transform, _kneeRight, _parameters.RightKneeFilename);
            _kneeLeft = CreatePartParent(_partsContainer.transform, "Knee Left");
            MoveParts(_parameters.KneeSlots, transform, _kneeLeft, _parameters.LeftKneeFilename);
            
            _elbowRight = CreatePartParent(_partsContainer.transform, "Elbow Right");
            MoveParts(_parameters.ElbowSlots, transform, _elbowRight, _parameters.RightElbowFilename);
            _elbowLeft = CreatePartParent(_partsContainer.transform, "Elbow Left");
            MoveParts(_parameters.ElbowSlots, transform, _elbowLeft, _parameters.LeftElbowFilename);
            
            _shoulderRight = CreatePartParent(_partsContainer.transform, "Shoulder Right");
            MoveParts(_parameters.ShoulderSlots, transform, _shoulderRight, _parameters.RightShoulderFilename);
            _shoulderLeft = CreatePartParent(_partsContainer.transform, "Shoulder Left");
            MoveParts(_parameters.ShoulderSlots, transform, _shoulderLeft, _parameters.LeftShoulderFilename);
            
            _hipAttachment = CreatePartParent(_partsContainer.transform, "Hip Attachment");
            MoveParts(_parameters.HipAttachmentSlots, transform, _hipAttachment, _parameters.HipAttachmentFilename);
            
            _headAttachment = CreatePartParent(_partsContainer.transform, "Head Attachment");
            MoveParts(_parameters.HeadAttachmentSlots, transform, _headAttachment, _parameters.HeadAttachmentFilename);
            
            _back = CreatePartParent(_partsContainer.transform, "Back");
            MoveParts(_parameters.BackSlots, transform, _back, _parameters.BackFilename);
            
            _face = CreatePartParent(_partsContainer.transform, "Face");
            MoveParts(_parameters.FaceSlots, transform, _face, _parameters.FaceFilename);
            
            _eyebrows = CreatePartParent(_partsContainer.transform, "Eyebrows");
            MoveParts(_parameters.EyebrowsSlots, transform, _eyebrows, _parameters.FemaleEyebrowFilename);
            RemoveParts(_parameters.EyebrowsSlots, transform, _parameters.MaleEyebrowFilename);
            
            _facialHair = CreatePartParent(_partsContainer.transform, "Facial Hair");
            RemoveParts(_parameters.FacialHairSlots, transform,_parameters.FacialHairFilename);
            
            _hair = CreatePartParent(_partsContainer.transform, "Hair");
            MoveParts(_parameters.HairSlots, transform, _hair, _parameters.HairFilename);
            
            _ears = CreatePartParent(_partsContainer.transform, "Ears");
            MoveParts(_parameters.EarSlots, transform, _ears, _parameters.EarFilename);
            
            _headCoverNoHair = CreatePartParent(_partsContainer.transform, "Head Cover No Hair");
            MoveParts(_parameters.HeadCoverNoHairSlots, transform, _headCoverNoHair, _parameters.HeadCoverNoHairFilename);
            
            _headCoverHair = CreatePartParent(_partsContainer.transform, "Head Cover Hair");
            MoveParts(_parameters.HeadCoverHairSlots, transform, _headCoverHair, _parameters.HeadCoverHairFilename);
            
            _headCoverFull = CreatePartParent(_partsContainer.transform, "Head Cover Full");
            MoveParts(_parameters.HeadCoverFullSlots, transform, _headCoverFull, _parameters.FemaleHeadCoverFullFilename);
            RemoveParts(_parameters.HeadCoverFullSlots, transform, _parameters.MaleHeadCoverFullFilename);
            
            
            Debug.Log("Female Build Complete");
        }

        private Transform CreatePartParent(Transform transformToSearch, string newName)
        {
            Transform part = transformToSearch.Find(newName);
            
            if (part == null)
            {
                GameObject parent = new GameObject
                {
                    name = newName
                };
                
                parent.transform.SetParent(_partsContainer.transform);
                parent.transform.SetAsFirstSibling();

                return parent.transform;
            }
            else
            {
                part.SetParent(_partsContainer.transform);
                part.SetAsFirstSibling();

                return part;
            }
        }
        
        private void MoveParts(int numParts, Transform transformToSearch, Transform newParent, string nameToFind)
        {
            for (int i = 0; i < numParts; i++)
            {
                string finalName = nameToFind;
                if (i < 10)
                {
                    finalName += "0" + i;
                }
                else
                {
                    finalName += i;
                }
                
                //Debug.Log("Searching for: " + finalName);
                
                Transform part = RecursiveFindChild(transformToSearch, finalName);

                if (part != null)
                {
                    //Debug.Log(part.name + " found");
                    part.SetParent(newParent);
                    part.GetComponent<Renderer>().material = _parameters.HeroMaterial;
                    part.gameObject.SetActive(false);
                }
                else
                {
                    if (i > 0)
                    {
                        Debug.Log(finalName + " not found");
                    }
                }
            }
        }

        private void RemoveParts(int numParts, Transform transformToSearch, string nameToFind)
        {
            for (int i = 0; i < numParts; i++)
            {
                string finalName = nameToFind;
                if (i < 10)
                {
                    finalName += "0" + i;
                }
                else
                {
                    finalName += i;
                }
                
                Transform part = RecursiveFindChild(transformToSearch, finalName);

                if (part != null)
                {
                    Debug.Log("Destroying: " + part.name);
                    DestroyImmediate(part.gameObject);
                }
            }
        }
        
        Transform RecursiveFindChild(Transform parent, string childName)
        {
            foreach (Transform child in parent)
            {
                if(child.name == childName)
                {
                    return child;
                }
                else
                {
                    Transform found = RecursiveFindChild(child, childName);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }
            return null;
        }
    }
}