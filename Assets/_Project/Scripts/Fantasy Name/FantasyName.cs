using Descending.Core;
using UnityEngine;

namespace Descending.Units
{
    [System.Serializable]
    public class FantasyName
    {
        [SerializeField] Genders gender;
        [SerializeField] string title;
        [SerializeField] string firstName;
        [SerializeField] string nickName;
        [SerializeField] string lastName;
        [SerializeField] string postfix;
        [SerializeField] string land;

        public Genders Gender { get { return gender; } set { gender = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string NickName { get { return nickName; } set { nickName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Postfix { get { return postfix; } set { postfix = value; } }
        public string Land { get { return land; } set { land = value; } }

        public FantasyName()
        {
            gender = Genders.None;
            title = "";
            firstName = "First";
            nickName = "";
            lastName = "Last";
            postfix = "";
            land = "";
        }

        public FantasyName(string first, string nick, string last)
        {
            firstName = first;
            nickName = nick;
            lastName = last;
        }

        public FantasyName(FantasyName name)
        {
            gender = name.Gender;
            title = name.Title;
            firstName = name.FirstName;
            nickName = name.NickName;
            lastName = name.LastName;
            postfix = name.Postfix;
            land = name.Land;
        }

        public string FullName
        {
            get { return Title + " " + FirstName + " " + LastName + " " + Postfix; }
        }

        public string ShortName
        {
            get { return FirstName + " " + LastName; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Gender, FirstName, LastName, Postfix, Land);
        }
    }
}