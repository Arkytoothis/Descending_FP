using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Units
{
    [CreateAssetMenu(fileName = "Hero Builder Parameters", menuName = "Descending/Definition/Hero Builder Parameters")]
    public class HeroBuilderParameters : ScriptableObject
    {
        [SerializeField] private Material _heroMaterial = null;
     
        [SerializeField] private string _emptyPartsFilename = "Modular_Character";
        
        [SerializeField] private int _headCoverFullSlots = 14;
        [SerializeField] private string _maleHeadCoverFullFilename = "Chr_Head_No_Elements_Male_";
        [SerializeField] private string _femaleHeadCoverFullFilename = "Chr_Head_No_Elements_Female_";
        
        [SerializeField] private int _headCoverHairSlots = 12;
        [SerializeField] private string _headCoverHairFilename = "Chr_HeadCoverings_Base_Hair_";
        
        [SerializeField] private int _headCoverNoHairSlots = 14;
        [SerializeField] private string _headCoverNoHairFilename = "Chr_HeadCoverings_No_Hair_";
        
        [SerializeField] private int _earSlots = 4;
        [SerializeField] private string _earFilename = "Chr_Ear_Ear_";
        
        [SerializeField] private int _hairSlots = 39;
        [SerializeField] private string _hairFilename = "Chr_Hair_";
        
        [SerializeField] private int _facialHairSlots = 19;
        [SerializeField] private string _facialHairFilename = "Chr_FacialHair_Male_";
        
        [SerializeField] private int _eyebrowsSlots = 11;
        [SerializeField] private string _maleEyebrowFilename = "Chr_Eyebrow_Male_";
        [SerializeField] private string _femaleEyebrowFilename = "Chr_Eyebrow_Female_";
        
        [SerializeField] private int _faceSlots = 4;
        [SerializeField] private string _faceFilename = "Chr_HeadCoverings_No_FacialHair_";
        
        [SerializeField] private int _backSlots = 16;
        [SerializeField] private string _backFilename = "Chr_BackAttachment_";
        
        [SerializeField] private int _headAttachmentSlots = 14;
        [SerializeField] private string _headAttachmentFilename = "Chr_HelmetAttachment_";
        
        [SerializeField] private int _hipAttachmentSlots = 13;
        [SerializeField] private string _hipAttachmentFilename = "Chr_HipsAttachment_01";

        [SerializeField] private int _shoulderSlots = 22;
        [SerializeField] private string _leftShoulderFilename = "Chr_ShoulderAttachLeft_";
        [SerializeField] private string _rightShoulderFilename = "Chr_ShoulderAttachRight_";
        
        [SerializeField] private int _elbowSlots = 7;
        [SerializeField] private string _leftElbowFilename = "Chr_ElbowAttachLeft_";
        [SerializeField] private string _rightElbowFilename = "Chr_ElbowAttachRight_";
        
        [SerializeField] private int _kneeSlots = 12;
        [SerializeField] private string _leftKneeFilename = "Chr_KneeAttachLeft_";
        [SerializeField] private string _rightKneeFilename = "Chr_KneeAttachRight_";
        
        [SerializeField] private int _headSlots = 23;
        [SerializeField] private string _maleHeadFilename = "Chr_Head_Male_";
        [SerializeField] private string _femaleHeadFilename = "Chr_Head_Female_";
        
        [SerializeField] private int _torsoSlots = 29;
        [SerializeField] private string _maleTorsoFilename = "Chr_Torso_Male_";
        [SerializeField] private string _femaleTorsoFilename = "Chr_Torso_Female_";
        
        [SerializeField] private int _armSlots = 21;
        [SerializeField] private string _maleLeftArmFilename = "Chr_ArmUpperLeft_Male_";
        [SerializeField] private string _maleRightArmFilename = "Chr_ArmUpperRight_Male_";
        [SerializeField] private string _femaleLeftArmFilename = "Chr_ArmUpperLeft_Female_";
        [SerializeField] private string _femaleRightArmFilename = "Chr_ArmUpperRight_Female_";
        
        [SerializeField] private int _wristSlots = 19;
        [SerializeField] private string _maleLeftWristFilename = "Chr_ArmLowerLeft_Male_";
        [SerializeField] private string _maleRightWristFilename = "Chr_ArmLowerRight_Male_";
        [SerializeField] private string _femaleLeftWristFilename = "Chr_ArmLowerLeft_Female_";
        [SerializeField] private string _femaleRightWristFilename = "Chr_ArmLowerRight_Female_";
        
        [SerializeField] private int _handSlots = 18;
        [SerializeField] private string _maleLeftHandFilename = "Chr_HandLeft_Male_";
        [SerializeField] private string _maleRightHandFilename = "Chr_HandRight_Male_";
        [SerializeField] private string _femaleLeftHandFilename = "Chr_HandLeft_Female_";
        [SerializeField] private string _femaleRightHandFilename = "Chr_HandRight_Female_";
        
        [SerializeField] private int _legSlots = 29;
        [SerializeField] private string _maleLegFilename = "Chr_Hips_Male_";
        [SerializeField] private string _femaleLegFilename = "Chr_Hips_Female_";
        
        [SerializeField] private int _footSlots = 20;
        [SerializeField] private string _maleLeftFootFilename = "Chr_LegLeft_Male_";
        [SerializeField] private string _maleRightFootFilename = "Chr_LegRight_Male_";
        [SerializeField] private string _femaleLeftFootFilename = "Chr_LegLeft_Female_";
        [SerializeField] private string _femaleRightFootFilename = "Chr_LegRight_Female_";
        
        [SerializeField] private Color _skinColor = Color.white;
        [SerializeField] private Color _scarColor = Color.white;
        [SerializeField] private Color _stubbleColor = Color.white;
        [SerializeField] private Color _hairColor = Color.white;
        [SerializeField] private Color _eyeColor = Color.white;
        [SerializeField] private Color _tattooColor = Color.black;

        public Material HeroMaterial => _heroMaterial;

        public string EmptyPartsFilename => _emptyPartsFilename;
        
        public int HeadCoverFullSlots => _headCoverFullSlots;
        public string MaleHeadCoverFullFilename => _maleHeadCoverFullFilename;
        public string FemaleHeadCoverFullFilename => _femaleHeadCoverFullFilename;

        public int HeadCoverHairSlots => _headCoverHairSlots;
        public string HeadCoverHairFilename => _headCoverHairFilename;

        public int HeadCoverNoHairSlots => _headCoverNoHairSlots;
        public string HeadCoverNoHairFilename => _headCoverNoHairFilename;

        public int EarSlots => _earSlots;
        public string EarFilename => _earFilename;

        public int HairSlots => _hairSlots;
        public string HairFilename => _hairFilename;

        public int FacialHairSlots => _facialHairSlots;
        public string FacialHairFilename => _facialHairFilename;

        public int EyebrowsSlots => _eyebrowsSlots;
        public string MaleEyebrowFilename => _maleEyebrowFilename;
        public string FemaleEyebrowFilename => _femaleEyebrowFilename;

        public int FaceSlots => _faceSlots;
        public string FaceFilename => _faceFilename;

        public int BackSlots => _backSlots;
        public string BackFilename => _backFilename;

        public int HeadAttachmentSlots => _headAttachmentSlots;
        public string HeadAttachmentFilename => _headAttachmentFilename;

        public int HipAttachmentSlots => _hipAttachmentSlots;
        public string HipAttachmentFilename => _hipAttachmentFilename;

        public int ShoulderSlots => _shoulderSlots;
        public string LeftShoulderFilename => _leftShoulderFilename;
        public string RightShoulderFilename => _rightShoulderFilename;

        public int ElbowSlots => _elbowSlots;
        public string LeftElbowFilename => _leftElbowFilename;
        public string RightElbowFilename => _rightElbowFilename;

        public int KneeSlots => _kneeSlots;
        public string LeftKneeFilename => _leftKneeFilename;
        public string RightKneeFilename => _rightKneeFilename;

        public int HeadSlots => _headSlots;
        public string MaleHeadFilename => _maleHeadFilename;
        public string FemaleHeadFilename => _femaleHeadFilename;

        public int TorsoSlots => _torsoSlots;
        public string MaleTorsoFilename => _maleTorsoFilename;
        public string FemaleTorsoFilename => _femaleTorsoFilename;

        public int ArmSlots => _armSlots;
        public string MaleLeftArmFilename => _maleLeftArmFilename;
        public string MaleRightArmFilename => _maleRightArmFilename;
        public string FemaleLeftArmFilename => _femaleLeftArmFilename;
        public string FemaleRightArmFilename => _femaleRightArmFilename;

        public int WristSlots => _wristSlots;
        public string MaleLeftWristFilename => _maleLeftWristFilename;
        public string MaleRightWristFilename => _maleRightWristFilename;
        public string FemaleLeftWristFilename => _femaleLeftWristFilename;
        public string FemaleRightWristFilename => _femaleRightWristFilename;

        public int HandSlots => _handSlots;
        public string MaleLeftHandFilename => _maleLeftHandFilename;
        public string MaleRightHandFilename => _maleRightHandFilename;
        public string FemaleLeftHandFilename => _femaleLeftHandFilename;
        public string FemaleRightHandFilename => _femaleRightHandFilename;

        public int LegSlots => _legSlots;
        public string MaleLegFilename => _maleLegFilename;
        public string FemaleLegFilename => _femaleLegFilename;

        public int FootSlots => _footSlots;
        public string MaleLeftFootFilename => _maleLeftFootFilename;
        public string MaleRightFootFilename => _maleRightFootFilename;
        public string FemaleLeftFootFilename => _femaleLeftFootFilename;
        public string FemaleRightFootFilename => _femaleRightFootFilename;
        
        public Color SkinColor => _skinColor;
        public Color ScarColor => _scarColor;
        public Color StubbleColor => _stubbleColor;
        public Color HairColor => _hairColor;
        public Color EyeColor => _eyeColor;
        public Color TattooColor => _tattooColor;
    }
}