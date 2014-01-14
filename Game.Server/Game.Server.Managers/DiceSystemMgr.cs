﻿using System;
using System.Collections.Generic;
using System.Threading;
namespace Game.Server.Managers
{
    public class DiceSystemMgr
    {
        public static readonly int MoneyLamMS = 10000;
        public static readonly int MoneyMacDinh = 10000;
        public static readonly int MoneyXUDoi = 10000;
        public static readonly int MoneyXULon = 10000;
        public static readonly int MoneyXUNho = 10000;
        private static Dictionary<int, DiceSystemInfo> m_item;
        private static List<DiceSystemItem> List;
        public static bool Init()
        {
            DiceSystemMgr.m_item = new Dictionary<int, DiceSystemInfo>();
            DiceSystemMgr.List = new List<DiceSystemItem>();
            DiceSystemItem diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 200018;
            diceSystemItem.Position = 3;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 2;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 200017;
            diceSystemItem.Position = 7;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 3;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 35100401;
            diceSystemItem.Position = 8;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 311325;
            diceSystemItem.Position = 9;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 200494;
            diceSystemItem.Position = 11;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 70411;
            diceSystemItem.Position = 13;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7026;
            diceSystemItem.Position = 0;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 9325;
            diceSystemItem.Position = 3;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 8504;
            diceSystemItem.Position = 4;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 35150101;
            diceSystemItem.Position = 8;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11905;
            diceSystemItem.Position = 10;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 5;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 13300;
            diceSystemItem.Position = 15;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11025;
            diceSystemItem.Position = 0;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 5;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 15071;
            diceSystemItem.Position = 2;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 332114;
            diceSystemItem.Position = 3;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 2;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 9222;
            diceSystemItem.Position = 6;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 14009;
            diceSystemItem.Position = 7;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 112268;
            diceSystemItem.Position = 12;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7032;
            diceSystemItem.Position = 14;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11101;
            diceSystemItem.Position = 15;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 3;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 13529;
            diceSystemItem.Position = 17;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 8214;
            diceSystemItem.Position = 0;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 14015;
            diceSystemItem.Position = 2;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 8314;
            diceSystemItem.Position = 6;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 311425;
            diceSystemItem.Position = 7;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7047;
            diceSystemItem.Position = 8;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 35140401;
            diceSystemItem.Position = 16;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 112270;
            diceSystemItem.Position = 17;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 9506;
            diceSystemItem.Position = 0;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 8014;
            diceSystemItem.Position = 1;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 17001;
            diceSystemItem.Position = 2;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 112108;
            diceSystemItem.Position = 4;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 3;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 17004;
            diceSystemItem.Position = 7;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11036;
            diceSystemItem.Position = 9;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 35110401;
            diceSystemItem.Position = 10;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 332113;
            diceSystemItem.Position = 13;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 2;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7059;
            diceSystemItem.Position = 14;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 3;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 40001;
            diceSystemItem.Position = 15;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 3;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7024;
            diceSystemItem.Position = 16;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 17002;
            diceSystemItem.Position = 0;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 5307;
            diceSystemItem.Position = 1;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11102;
            diceSystemItem.Position = 2;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 2;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11035;
            diceSystemItem.Position = 4;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 3;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 332112;
            diceSystemItem.Position = 5;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 2;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11570;
            diceSystemItem.Position = 7;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 9122;
            diceSystemItem.Position = 8;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7069;
            diceSystemItem.Position = 9;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11032;
            diceSystemItem.Position = 12;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 10;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 112272;
            diceSystemItem.Position = 13;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 9223;
            diceSystemItem.Position = 15;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 20150;
            diceSystemItem.Position = 16;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 2;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 334107;
            diceSystemItem.Position = 17;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 3;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 200493;
            diceSystemItem.Position = 18;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7027;
            diceSystemItem.Position = 0;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 5156;
            diceSystemItem.Position = 1;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11033;
            diceSystemItem.Position = 2;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 10;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 9324;
            diceSystemItem.Position = 3;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 15074;
            diceSystemItem.Position = 4;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 200549;
            diceSystemItem.Position = 5;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 201014;
            diceSystemItem.Position = 6;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11996;
            diceSystemItem.Position = 7;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 35120401;
            diceSystemItem.Position = 8;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 313311;
            diceSystemItem.Position = 9;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 9023;
            diceSystemItem.Position = 10;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 112150;
            diceSystemItem.Position = 11;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 3;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11030;
            diceSystemItem.Position = 12;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 10;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 7031;
            diceSystemItem.Position = 13;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11026;
            diceSystemItem.Position = 14;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 11031;
            diceSystemItem.Position = 15;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 10;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 40002;
            diceSystemItem.Position = 16;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 8506;
            diceSystemItem.Position = 17;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 1;
            diceSystemItem.Validate = 7;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            diceSystemItem = new DiceSystemItem();
            diceSystemItem.TemplateID = 332111;
            diceSystemItem.Position = 18;
            diceSystemItem.StrengthLevel = 0;
            diceSystemItem.Count = 4;
            diceSystemItem.Validate = 0;
            diceSystemItem.IsBind = false;
            DiceSystemMgr.List.Add(diceSystemItem);
            return true;
        }
        public static DiceSystemInfo GetDiceByUserID(int UserID)
        {
            DiceSystemInfo result = null;
            Dictionary<int, DiceSystemInfo> item;
            Monitor.Enter(item = DiceSystemMgr.m_item);
            try
            {
                if (DiceSystemMgr.m_item.ContainsKey(UserID))
                {
                    result = DiceSystemMgr.m_item[UserID];
                }
                else
                {
                    DiceSystemInfo diceSystemInfo = new DiceSystemInfo();
                    diceSystemInfo.UserID = UserID;
                    diceSystemInfo.UserFirstCell = false;
                    diceSystemInfo.CurrentPosition = -1;
                    diceSystemInfo.LuckIntegralLevel = -1;
                    diceSystemInfo.LuckIntegral = 0;
                    diceSystemInfo.ItemDice = DiceSystemMgr.TaoMoidiem();
                    DiceSystemMgr.m_item.Add(UserID, diceSystemInfo);
                    result = DiceSystemMgr.m_item[UserID];
                }
            }
            finally
            {
                Monitor.Exit(item);
            }
            return result;
        }
        public static List<DiceSystemItem> TaoMoidiem()
        {
            List<DiceSystemItem> list = new List<DiceSystemItem>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < DiceSystemMgr.List.Count; i++)
            {
                list2.Add(i);
            }
            Random random = new Random();
            List<DiceSystemItem> list3;
            Monitor.Enter(list3 = DiceSystemMgr.List);
            try
            {
                for (int j = 0; j < 19; j++)
                {
                    int index = random.Next(0, list2.Count);
                    DiceSystemItem diceSystemItem = DiceSystemMgr.List[list2[index]];
                    diceSystemItem.Position = j;
                    list.Add(diceSystemItem);
                    list2.RemoveAt(index);
                }
            }
            finally
            {
                Monitor.Exit(list3);
            }
            return list;
        }
    }
}