using UnityEngine;
using System.Collections.Generic;
using Descending.Core;

namespace Descending.Units
{
    public static class FirstName
    {
        public static string[] MaleFirstNames = new string[]
        {
        "Tristan", "Harvord", "Diplo", "Koushik", "Votolado", "Hareck", "Clifton", "Werto", "Exclides", "Mathewn", "Matthorn", "Franz", "Franx", "Logstrom", "Montreno", "Brax", "Sole", "Ajax", "Jquery",
        "Orpheus", "Bane", "Crayton", "Guurgle", "Norax", "Krag", "Gwargong", "Kabar", "Klaver", "Demonstrus", "Krag", "Krashnor", "Strider", "Askold", "Gorm", "Harald", "Svein", "Cnut", "Harthacnut", "Magnus",
        "Olaf", "Erik", "Hakon", "Ragnall", "Ivar", "Bardr", "Sigtryg", "Blacaire", "Eystein", "Sigfrid", "Rurik", "Vladimir", "Yaroslav", "Yaropolk", "Rollo", "Rolando", "Daryen", "Clifton", "Igor", "Guthrum",
        "Ingvar", "Ivar", "Leif", "Skagul", "Thorfinn", "Voltar", "Vultrax", "Frizban", "Rasputin", "Rostor", "Simonexto", "Guurglex"
        };

        public static string[] FemaleFirstNames = new string[]
        {
            "Heron", "Esmee", "Ralia", "Tezani", "Thesra", "Agama", "Lynx",  "Ketra", "Sage", "Elysa", "Palra", "Hagar", "Morwena", "Yelina", "Everen",
            "Maeve", "Soko", "Razra", "Sonali", "Liris", "Yarri", "Beatha", "Xavia", "Pekka", "Vixra", "Basak", "Reslyn", "Antia", "Tamrin", "Semet",
            "Annihya", "Tiv", "Lynorr", "Maarika", "Estyn", "Renalee", "Temy", "Ciscra", "Rei", "Belen", "Jesi", "Zara", "Rhiannon", "Tessel", "Afia",
            "Kory", "Pret", "Herra", "Asralyn", "Krynna", "Desmina", "Aeris", "Magaltie", "Kessa", "Talis", "Yuni", "Wren", "Varin", "Resha", "Syrana"
        };

        public static string[] FirstNamesPart1 = new string[]
        {
        "Strum", "Halo", "Car", "Heva", "Men", "Gre,", "Deca", "Evi", "Hideo", "Sli", "Quici", "Sly", "Miser", "Bra", "Bro", "Gi", "Demo", "Cla", "Clai", "Hee", "Crio", "Die", "Deno", "Con", "Wolf", "Zar",
        "Zer", "War", "Nar", "Thay", "Ard", "Alf", "Fiz", "Risa", "Warran", "Kel", "Wren", "Kan", "Can", "Gy", "Dero", "Ak", "Dall", "Dell", "Mil", "Ward"
        };

        public static string[] FirstNamesPart2 = new string[]
        {
        "bright", "gold", "burnd", "del", "gor", "terous", "nton", "slip", "pask", "gold", "ck", "plone", "plast", "nturous", "nstrus", "x", "lax", "ndor", "ton", "seus", "zzt", "borne", "nan", "run",
        "bald", "ban", "buck", "tor", "van", "gax", "trandor", "thuri", "ben", "baldar", "may", "lam", "mor", "dard", "burg", "whit"
        };

        public static string Generate(FantasyName name, Genders gender, string race)
        {
            string firstName = "";

            if (Random.Range(0, 100) < 50)
            {
                if (gender == Genders.Male)
                {
                    firstName = MaleFirstNames[Random.Range(0, MaleFirstNames.Length)];
                }
                else if (gender == Genders.Female)
                {
                    firstName = FemaleFirstNames[Random.Range(0, FemaleFirstNames.Length)];
                }
            }
            else
            {
                firstName = FirstNamesPart1[Random.Range(0, FirstNamesPart1.Length)] + FirstNamesPart2[Random.Range(0, FirstNamesPart2.Length)];
            }

            return firstName;
        }
    }
}