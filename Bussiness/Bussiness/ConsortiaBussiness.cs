using SqlDataProvider.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bussiness
{
    public class ConsortiaBussiness : BaseBussiness
    {
        public bool RenameConsortiaName(string userName, string nickName, string consortiaName, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@UserName", (object) userName),
          new SqlParameter("@NickName", (object) nickName),
          new SqlParameter("@ConsortiaName", (object) consortiaName),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_Users_RenameConsortiaName", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                switch (num)
                {
                    case 4:
                    case 5:
                        msg = LanguageMgr.GetTranslation("PlayerBussiness.SP_Users_RenameConsortiaName.Msg4", new object[0]);
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"RenameNick", ex);
            }
            return flag;
        }

        public bool RenameConsortia(int ConsortiaID, string nickName, string newNickName)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@ConsortiaID", (object) ConsortiaID),
          new SqlParameter("@NickName", (object) nickName),
          new SqlParameter("@NewNickName", (object) newNickName),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_Users_RenameConsortia", SqlParameters);
                flag = (int)SqlParameters[3].Value == 0;
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"RenameNick", ex);
            }
            return flag;
        }

        public bool AddConsortia(ConsortiaInfo info, ref string msg, ref ConsortiaDutyInfo dutyInfo)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[23];
                SqlParameters[0] = new SqlParameter("@ConsortiaID", (object)info.ConsortiaID);
                SqlParameters[0].Direction = ParameterDirection.InputOutput;
                SqlParameters[1] = new SqlParameter("@BuildDate", (object)info.BuildDate);
                SqlParameters[2] = new SqlParameter("@CelebCount", (object)info.CelebCount);
                SqlParameters[3] = new SqlParameter("@ChairmanID", (object)info.ChairmanID);
                SqlParameters[4] = new SqlParameter("@ChairmanName", info.ChairmanName == null ? (object)"" : (object)info.ChairmanName);
                SqlParameters[5] = new SqlParameter("@ConsortiaName", info.ConsortiaName == null ? (object)"" : (object)info.ConsortiaName);
                SqlParameters[6] = new SqlParameter("@CreatorID", (object)info.CreatorID);
                SqlParameters[7] = new SqlParameter("@CreatorName", info.CreatorName == null ? (object)"" : (object)info.CreatorName);
                SqlParameters[8] = new SqlParameter("@Description", (object)info.Description);
                SqlParameters[9] = new SqlParameter("@Honor", (object)info.Honor);
                SqlParameters[10] = new SqlParameter("@IP", (object)info.IP);
                SqlParameters[11] = new SqlParameter("@IsExist", (object)(int)(info.IsExist ? 1 : 0));
                SqlParameters[12] = new SqlParameter("@Level", (object)info.Level);
                SqlParameters[13] = new SqlParameter("@MaxCount", (object)info.MaxCount);
                SqlParameters[14] = new SqlParameter("@Placard", (object)info.Placard);
                SqlParameters[15] = new SqlParameter("@Port", (object)info.Port);
                SqlParameters[16] = new SqlParameter("@Repute", (object)info.Repute);
                SqlParameters[17] = new SqlParameter("@Count", (object)info.Count);
                SqlParameters[18] = new SqlParameter("@Riches", (object)info.Riches);
                SqlParameters[19] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[19].Direction = ParameterDirection.ReturnValue;
                SqlParameters[20] = new SqlParameter("@tempDutyLevel", SqlDbType.Int);
                SqlParameters[20].Direction = ParameterDirection.InputOutput;
                SqlParameters[20].Value = (object)dutyInfo.Level;
                SqlParameters[21] = new SqlParameter("@tempDutyName", SqlDbType.VarChar, 100);
                SqlParameters[21].Direction = ParameterDirection.InputOutput;
                SqlParameters[21].Value = (object)"";
                SqlParameters[22] = new SqlParameter("@tempRight", SqlDbType.Int);
                SqlParameters[22].Direction = ParameterDirection.InputOutput;
                SqlParameters[22].Value = (object)dutyInfo.Right;
                flag = this.db.RunProcedure("SP_Consortia_Add", SqlParameters);
                int num = (int)SqlParameters[19].Value;
                flag = num == 0;
                if (flag)
                {
                    info.ConsortiaID = (int)SqlParameters[0].Value;
                    dutyInfo.Level = (int)SqlParameters[20].Value;
                    dutyInfo.DutyName = SqlParameters[21].Value.ToString();
                    dutyInfo.Right = (int)SqlParameters[22].Value;
                }
                if (num == 2)
                    msg = "ConsortiaBussiness.AddConsortia.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool DeleteConsortia(int consortiaID, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_Consortia_Delete", SqlParameters);
                int num = (int)SqlParameters[2].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.DeleteConsortia.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.DeleteConsortia.Msg3";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaInfo[] GetConsortiaPage(int page, int size, ref int total, int order, string name, int consortiaID, int level, int openApply)
        {
            List<ConsortiaInfo> list = new List<ConsortiaInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (!string.IsNullOrEmpty(name))
                    queryWhere = queryWhere + " and ConsortiaName like '%" + name + "%' ";
                if (consortiaID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ConsortiaID =",
            (object) consortiaID,
            (object) " "
          });
                if (level != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and Level =",
            (object) level,
            (object) " "
          });
                if (openApply != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and OpenApply =",
            (object) openApply,
            (object) " "
          });
                string str = "ConsortiaName";
                switch (order)
                {
                    case 1:
                        str = "ReputeSort";
                        break;
                    case 2:
                        str = "ChairmanName";
                        break;
                    case 3:
                        str = "Count desc";
                        break;
                    case 4:
                        str = "Level desc";
                        break;
                    case 5:
                        str = "Honor desc";
                        break;
                    case 10:
                        str = "LastDayRiches desc";
                        break;
                    case 11:
                        str = "AddDayRiches desc";
                        break;
                    case 12:
                        str = "AddWeekRiches desc";
                        break;
                    case 13:
                        str = "LastDayHonor desc";
                        break;
                    case 14:
                        str = "AddDayHonor desc";
                        break;
                    case 15:
                        str = "AddWeekHonor desc";
                        break;
                    case 16:
                        str = "level desc,LastDayRiches desc";
                        break;
                }
                string fdOreder = str + ",ConsortiaID ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("V_Consortia", queryWhere, page, size, "*", fdOreder, "ConsortiaID", ref total).Rows)
                    list.Add(new ConsortiaInfo()
                    {
                        ConsortiaID = (int)dataRow["ConsortiaID"],
                        BuildDate = (DateTime)dataRow["BuildDate"],
                        CelebCount = (int)dataRow["CelebCount"],
                        ChairmanID = (int)dataRow["ChairmanID"],
                        ChairmanName = dataRow["ChairmanName"].ToString(),
                        ChairmanTypeVIP = Convert.ToByte(dataRow["typeVIP"]),
                        ChairmanVIPLevel = (int)dataRow["VIPLevel"],
                        ConsortiaName = dataRow["ConsortiaName"].ToString(),
                        CreatorID = (int)dataRow["CreatorID"],
                        CreatorName = dataRow["CreatorName"].ToString(),
                        Description = dataRow["Description"].ToString(),
                        Honor = (int)dataRow["Honor"],
                        IsExist = (bool)dataRow["IsExist"],
                        Level = (int)dataRow["Level"],
                        MaxCount = (int)dataRow["MaxCount"],
                        Placard = dataRow["Placard"].ToString(),
                        IP = dataRow["IP"].ToString(),
                        Port = (int)dataRow["Port"],
                        Repute = (int)dataRow["Repute"],
                        Count = (int)dataRow["Count"],
                        Riches = (int)dataRow["Riches"],
                        DeductDate = (DateTime)dataRow["DeductDate"],
                        AddDayHonor = (int)dataRow["AddDayHonor"],
                        AddDayRiches = (int)dataRow["AddDayRiches"],
                        AddWeekHonor = (int)dataRow["AddWeekHonor"],
                        AddWeekRiches = (int)dataRow["AddWeekRiches"],
                        LastDayRiches = (int)dataRow["LastDayRiches"],
                        OpenApply = (bool)dataRow["OpenApply"],
                        StoreLevel = (int)dataRow["StoreLevel"],
                        SmithLevel = (int)dataRow["SmithLevel"],
                        ShopLevel = (int)dataRow["ShopLevel"],
                        SkillLevel = (int)dataRow["SkillLevel"]
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }

        public bool BuyBadge(int consortiaID, int userID, ConsortiaInfo info, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[6]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@BadgeID", (object) info.BadgeID),
          new SqlParameter("@ValidDate", (object) info.ValidDate),
          new SqlParameter("@BadgeBuyTime", (object) info.BadgeBuyTime),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[5].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaBadge_Update", SqlParameters);
                int num = (int)SqlParameters[5].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.BuyBadge.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaRiches(int consortiaID, int userID, int Riches, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Riches", (object) Riches),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaRiches_Update", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.UpdateConsortiaRiches.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaDescription(int consortiaID, int userID, string description, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Description", (object) description),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaDescription_Update", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.UpdateConsortiaDescription.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaPlacard(int consortiaID, int userID, string placard, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Placard", (object) placard),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaPlacard_Update", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.UpdateConsortiaPlacard.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaChairman(string nickName, int consortiaID, int userID, ref string msg, ref ConsortiaDutyInfo info, ref int tempUserID, ref string tempUserName)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[9];
                SqlParameters[0] = new SqlParameter("@NickName", (object)nickName);
                SqlParameters[1] = new SqlParameter("@ConsortiaID", (object)consortiaID);
                SqlParameters[2] = new SqlParameter("@UserID", (object)userID);
                SqlParameters[3] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                SqlParameters[4] = new SqlParameter("@tempUserID", SqlDbType.Int);
                SqlParameters[4].Direction = ParameterDirection.InputOutput;
                SqlParameters[4].Value = (object)tempUserID;
                SqlParameters[5] = new SqlParameter("@tempUserName", SqlDbType.VarChar, 100);
                SqlParameters[5].Direction = ParameterDirection.InputOutput;
                SqlParameters[5].Value = (object)tempUserName;
                SqlParameters[6] = new SqlParameter("@tempDutyLevel", SqlDbType.Int);
                SqlParameters[6].Direction = ParameterDirection.InputOutput;
                SqlParameters[6].Value = (object)info.Level;
                SqlParameters[7] = new SqlParameter("@tempDutyName", SqlDbType.VarChar, 100);
                SqlParameters[7].Direction = ParameterDirection.InputOutput;
                SqlParameters[7].Value = (object)"";
                SqlParameters[8] = new SqlParameter("@tempRight", SqlDbType.Int);
                SqlParameters[8].Direction = ParameterDirection.InputOutput;
                SqlParameters[8].Value = (object)info.Right;
                flag = this.db.RunProcedure("SP_ConsortiaChangeChairman", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                if (flag)
                {
                    tempUserID = (int)SqlParameters[4].Value;
                    tempUserName = SqlParameters[5].Value.ToString();
                    info.Level = (int)SqlParameters[6].Value;
                    info.DutyName = SqlParameters[7].Value.ToString();
                    info.Right = (int)SqlParameters[8].Value;
                }
                switch (num)
                {
                    case 1:
                        msg = "ConsortiaBussiness.UpdateConsortiaChairman.Msg3";
                        break;
                    case 2:
                        msg = "ConsortiaBussiness.UpdateConsortiaChairman.Msg2";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaInfo GetConsortiaSingleByName(string ConsortiaName)
        {
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[1]
        {
          new SqlParameter("@ConsortiaName", SqlDbType.VarChar, 200)
        };
                SqlParameters[0].Value = (object)ConsortiaName;
                this.db.GetReader(ref ResultDataReader, "SP_Consortia_CheckByName", SqlParameters);
                if (ResultDataReader.Read())
                    return new ConsortiaInfo()
                    {
                        ConsortiaID = (int)ResultDataReader["ConsortiaID"],
                        BuildDate = (DateTime)ResultDataReader["BuildDate"],
                        CelebCount = (int)ResultDataReader["CelebCount"],
                        ChairmanID = (int)ResultDataReader["ChairmanID"],
                        ChairmanName = ResultDataReader["ChairmanName"].ToString(),
                        ConsortiaName = ResultDataReader["ConsortiaName"].ToString(),
                        CreatorID = (int)ResultDataReader["CreatorID"],
                        CreatorName = ResultDataReader["CreatorName"].ToString(),
                        Description = ResultDataReader["Description"].ToString(),
                        Honor = (int)ResultDataReader["Honor"],
                        IsExist = (bool)ResultDataReader["IsExist"],
                        Level = (int)ResultDataReader["Level"],
                        MaxCount = (int)ResultDataReader["MaxCount"],
                        Placard = ResultDataReader["Placard"].ToString(),
                        IP = ResultDataReader["IP"].ToString(),
                        Port = (int)ResultDataReader["Port"],
                        Repute = (int)ResultDataReader["Repute"],
                        Count = (int)ResultDataReader["Count"],
                        Riches = (int)ResultDataReader["Riches"],
                        DeductDate = (DateTime)ResultDataReader["DeductDate"],
                        StoreLevel = (int)ResultDataReader["StoreLevel"],
                        SmithLevel = (int)ResultDataReader["SmithLevel"],
                        ShopLevel = (int)ResultDataReader["ShopLevel"],
                        SkillLevel = (int)ResultDataReader["SkillLevel"]
                    };
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            return (ConsortiaInfo)null;
        }

        public bool UpGradeConsortia(int consortiaID, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_Consortia_UpGrade", SqlParameters);
                int num = (int)SqlParameters[2].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpGradeConsortia.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.UpGradeConsortia.Msg3";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.UpGradeConsortia.Msg4";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpGradeSkillConsortia(int consortiaID, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_Consortia_Skill_UpGrade", SqlParameters);
                int num = (int)SqlParameters[2].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpGradeSkillConsortia.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.UpGradeSkillConsortia.Msg3";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.UpGradeSkillConsortia.Msg4";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpGradeShopConsortia(int consortiaID, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_Consortia_Shop_UpGrade", SqlParameters);
                int num = (int)SqlParameters[2].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpGradeShopConsortia.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.UpGradeShopConsortia.Msg3";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.UpGradeShopConsortia.Msg4";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpGradeStoreConsortia(int consortiaID, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_Consortia_Store_UpGrade", SqlParameters);
                int num = (int)SqlParameters[2].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpGradeStoreConsortia.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.UpGradeStoreConsortia.Msg3";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.UpGradeStoreConsortia.Msg4";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpGradeSmithConsortia(int consortiaID, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_Consortia_Smith_UpGrade", SqlParameters);
                int num = (int)SqlParameters[2].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpGradeSmithConsortia.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.UpGradeSmithConsortia.Msg3";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.UpGradeSmithConsortia.Msg4";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaInfo[] GetConsortiaAll()
        {
            List<ConsortiaInfo> list1 = new List<ConsortiaInfo>();
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                this.db.GetReader(ref ResultDataReader, "SP_Consortia_All");
                while (ResultDataReader.Read())
                {
                    List<ConsortiaInfo> list2 = list1;
                    ConsortiaInfo consortiaInfo1 = new ConsortiaInfo();
                    consortiaInfo1.ConsortiaID = (int)ResultDataReader["ConsortiaID"];
                    consortiaInfo1.Honor = (int)ResultDataReader["Honor"];
                    consortiaInfo1.Level = (int)ResultDataReader["Level"];
                    consortiaInfo1.Riches = (int)ResultDataReader["Riches"];
                    consortiaInfo1.MaxCount = (int)ResultDataReader["MaxCount"];
                    consortiaInfo1.BuildDate = (DateTime)ResultDataReader["BuildDate"];
                    consortiaInfo1.IsExist = (bool)ResultDataReader["IsExist"];
                    consortiaInfo1.DeductDate = (DateTime)ResultDataReader["DeductDate"];
                    consortiaInfo1.StoreLevel = (int)ResultDataReader["StoreLevel"];
                    consortiaInfo1.SmithLevel = (int)ResultDataReader["SmithLevel"];
                    consortiaInfo1.ShopLevel = (int)ResultDataReader["ShopLevel"];
                    consortiaInfo1.SkillLevel = (int)ResultDataReader["SkillLevel"];
                    consortiaInfo1.ConsortiaName = ResultDataReader["ConsortiaName"] == null ? "" : ResultDataReader["ConsortiaName"].ToString();
                    consortiaInfo1.IsDirty = false;
                    ConsortiaInfo consortiaInfo2 = consortiaInfo1;
                    list2.Add(consortiaInfo2);
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            return list1.ToArray();
        }

        public ConsortiaInfo GetConsortiaSingle(int id)
        {
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[1]
        {
          new SqlParameter("@ID", (object) id)
        };
                this.db.GetReader(ref ResultDataReader, "SP_Consortia_Single", SqlParameters);
                if (ResultDataReader.Read())
                    return new ConsortiaInfo()
                    {
                        ConsortiaID = (int)ResultDataReader["ConsortiaID"],
                        BuildDate = (DateTime)ResultDataReader["BuildDate"],
                        CelebCount = (int)ResultDataReader["CelebCount"],
                        ChairmanID = (int)ResultDataReader["ChairmanID"],
                        ChairmanName = ResultDataReader["ChairmanName"].ToString(),
                        ChairmanTypeVIP = Convert.ToByte(ResultDataReader["typeVIP"]),
                        ChairmanVIPLevel = (int)ResultDataReader["VIPLevel"],
                        ConsortiaName = ResultDataReader["ConsortiaName"].ToString(),
                        CreatorID = (int)ResultDataReader["CreatorID"],
                        CreatorName = ResultDataReader["CreatorName"].ToString(),
                        Description = ResultDataReader["Description"].ToString(),
                        Honor = (int)ResultDataReader["Honor"],
                        IsExist = (bool)ResultDataReader["IsExist"],
                        Level = (int)ResultDataReader["Level"],
                        MaxCount = (int)ResultDataReader["MaxCount"],
                        Placard = ResultDataReader["Placard"].ToString(),
                        IP = ResultDataReader["IP"].ToString(),
                        Port = (int)ResultDataReader["Port"],
                        Repute = (int)ResultDataReader["Repute"],
                        Count = (int)ResultDataReader["Count"],
                        Riches = (int)ResultDataReader["Riches"],
                        DeductDate = (DateTime)ResultDataReader["DeductDate"],
                        StoreLevel = (int)ResultDataReader["StoreLevel"],
                        SmithLevel = (int)ResultDataReader["SmithLevel"],
                        ShopLevel = (int)ResultDataReader["ShopLevel"],
                        SkillLevel = (int)ResultDataReader["SkillLevel"]
                    };
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            return (ConsortiaInfo)null;
        }

        public bool ConsortiaFight(int consortiWin, int consortiaLose, int playerCount, out int riches, int state, int totalKillHealth, float richesRate)
        {
            bool flag = false;
            riches = 0;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[8]
        {
          new SqlParameter("@ConsortiaWin", (object) consortiWin),
          new SqlParameter("@ConsortiaLose", (object) consortiaLose),
          new SqlParameter("@PlayerCount", (object) playerCount),
          new SqlParameter("@Riches", SqlDbType.Int),
          null,
          null,
          null,
          null
        };
                SqlParameters[3].Direction = ParameterDirection.InputOutput;
                SqlParameters[3].Value = (object)riches;
                SqlParameters[4] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[4].Direction = ParameterDirection.ReturnValue;
                SqlParameters[5] = new SqlParameter("@State", (object)state);
                SqlParameters[6] = new SqlParameter("@TotalKillHealth", (object)totalKillHealth);
                SqlParameters[7] = new SqlParameter("@RichesRate", (object)richesRate);
                flag = this.db.RunProcedure("SP_Consortia_Fight", SqlParameters);
                riches = (int)SqlParameters[3].Value;
                flag = (int)SqlParameters[4].Value == 0;
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"ConsortiaFight", ex);
            }
            return flag;
        }

        public bool ConsortiaRichAdd(int consortiID, ref int riches)
        {
            return this.ConsortiaRichAdd(consortiID, ref riches, 0, "");
        }

        public bool ConsortiaRichAdd(int consortiID, ref int riches, int type, string username)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[5];
                SqlParameters[0] = new SqlParameter("@ConsortiaID", (object)consortiID);
                SqlParameters[1] = new SqlParameter("@Riches", SqlDbType.Int);
                SqlParameters[1].Direction = ParameterDirection.InputOutput;
                SqlParameters[1].Value = (object)riches;
                SqlParameters[2] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                SqlParameters[3] = new SqlParameter("@Type", (object)type);
                SqlParameters[4] = new SqlParameter("@UserName", (object)username);
                flag = this.db.RunProcedure("SP_Consortia_Riches_Add", SqlParameters);
                riches = (int)SqlParameters[1].Value;
                flag = (int)SqlParameters[2].Value == 0;
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"ConsortiaRichAdd", ex);
            }
            return flag;
        }

        public bool ScanConsortia(ref string noticeID)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[2]
        {
          new SqlParameter("@NoticeID", SqlDbType.NVarChar, 4000),
          null
        };
                SqlParameters[0].Direction = ParameterDirection.Output;
                SqlParameters[1] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[1].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_Consortia_Scan", SqlParameters);
                flag = (int)SqlParameters[1].Value == 0;
                if (flag)
                    noticeID = SqlParameters[0].Value.ToString();
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsotiaApplyState(int consortiaID, int userID, bool state, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@State", (object) (int) (state ? 1 : 0)),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_Consortia_Apply_State", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.UpdateConsotiaApplyState.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool AddConsortiaApplyUsers(ConsortiaApplyUserInfo info, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[9];
                SqlParameters[0] = new SqlParameter("@ID", (object)info.ID);
                SqlParameters[0].Direction = ParameterDirection.InputOutput;
                SqlParameters[1] = new SqlParameter("@ApplyDate", (object)info.ApplyDate);
                SqlParameters[2] = new SqlParameter("@ConsortiaID", (object)info.ConsortiaID);
                SqlParameters[3] = new SqlParameter("@ConsortiaName", info.ConsortiaName == null ? (object)"" : (object)info.ConsortiaName);
                SqlParameters[4] = new SqlParameter("@IsExist", (object)(int)(info.IsExist ? 1 : 0));
                SqlParameters[5] = new SqlParameter("@Remark", info.Remark == null ? (object)"" : (object)info.Remark);
                SqlParameters[6] = new SqlParameter("@UserID", (object)info.UserID);
                SqlParameters[7] = new SqlParameter("@UserName", info.UserName == null ? (object)"" : (object)info.UserName);
                SqlParameters[8] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[8].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaApplyUser_Add", SqlParameters);
                info.ID = (int)SqlParameters[0].Value;
                int num = (int)SqlParameters[8].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.AddConsortiaApplyUsers.Msg2";
                        break;
                    case 6:
                        msg = "ConsortiaBussiness.AddConsortiaApplyUsers.Msg6";
                        break;
                    case 7:
                        msg = "ConsortiaBussiness.AddConsortiaApplyUsers.Msg7";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool DeleteConsortiaApplyUsers(int applyID, int userID, int consortiaID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@ID", (object) applyID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_ConsortiaApplyUser_Delete", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0 || num == 3;
                if (num == 2)
                    msg = "ConsortiaBussiness.DeleteConsortiaApplyUsers.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool PassConsortiaApplyUsers(int applyID, int userID, string userName, int consortiaID, ref string msg, ConsortiaUserInfo info, ref int consortiaRepute)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[24];
                SqlParameters[0] = new SqlParameter("@ID", (object)applyID);
                SqlParameters[1] = new SqlParameter("@UserID", (object)userID);
                SqlParameters[2] = new SqlParameter("@UserName", (object)userName);
                SqlParameters[3] = new SqlParameter("@ConsortiaID", (object)consortiaID);
                SqlParameters[4] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[4].Direction = ParameterDirection.ReturnValue;
                SqlParameters[5] = new SqlParameter("@tempID", SqlDbType.Int);
                SqlParameters[5].Direction = ParameterDirection.InputOutput;
                SqlParameters[5].Value = (object)info.UserID;
                SqlParameters[6] = new SqlParameter("@tempName", SqlDbType.NVarChar, 100);
                SqlParameters[6].Direction = ParameterDirection.InputOutput;
                SqlParameters[6].Value = (object)"";
                SqlParameters[7] = new SqlParameter("@tempDutyID", SqlDbType.Int);
                SqlParameters[7].Direction = ParameterDirection.InputOutput;
                SqlParameters[7].Value = (object)info.DutyID;
                SqlParameters[8] = new SqlParameter("@tempDutyName", SqlDbType.NVarChar, 100);
                SqlParameters[8].Direction = ParameterDirection.InputOutput;
                SqlParameters[8].Value = (object)"";
                SqlParameters[9] = new SqlParameter("@tempOffer", SqlDbType.Int);
                SqlParameters[9].Direction = ParameterDirection.InputOutput;
                SqlParameters[9].Value = (object)info.Offer;
                SqlParameters[10] = new SqlParameter("@tempRichesOffer", SqlDbType.Int);
                SqlParameters[10].Direction = ParameterDirection.InputOutput;
                SqlParameters[10].Value = (object)info.RichesOffer;
                SqlParameters[11] = new SqlParameter("@tempRichesRob", SqlDbType.Int);
                SqlParameters[11].Direction = ParameterDirection.InputOutput;
                SqlParameters[11].Value = (object)info.RichesRob;
                SqlParameters[12] = new SqlParameter("@tempLastDate", SqlDbType.DateTime);
                SqlParameters[12].Direction = ParameterDirection.InputOutput;
                SqlParameters[12].Value = (object)DateTime.Now;
                SqlParameters[13] = new SqlParameter("@tempWin", SqlDbType.Int);
                SqlParameters[13].Direction = ParameterDirection.InputOutput;
                SqlParameters[13].Value = (object)info.Win;
                SqlParameters[14] = new SqlParameter("@tempTotal", SqlDbType.Int);
                SqlParameters[14].Direction = ParameterDirection.InputOutput;
                SqlParameters[14].Value = (object)info.Total;
                SqlParameters[15] = new SqlParameter("@tempEscape", SqlDbType.Int);
                SqlParameters[15].Direction = ParameterDirection.InputOutput;
                SqlParameters[15].Value = (object)info.Escape;
                SqlParameters[16] = new SqlParameter("@tempGrade", SqlDbType.Int);
                SqlParameters[16].Direction = ParameterDirection.InputOutput;
                SqlParameters[16].Value = (object)info.Grade;
                SqlParameters[17] = new SqlParameter("@tempLevel", SqlDbType.Int);
                SqlParameters[17].Direction = ParameterDirection.InputOutput;
                SqlParameters[17].Value = (object)info.Level;
                SqlParameters[18] = new SqlParameter("@tempCUID", SqlDbType.Int);
                SqlParameters[18].Direction = ParameterDirection.InputOutput;
                SqlParameters[18].Value = (object)info.ID;
                SqlParameters[19] = new SqlParameter("@tempState", SqlDbType.Int);
                SqlParameters[19].Direction = ParameterDirection.InputOutput;
                SqlParameters[19].Value = (object)info.State;
                SqlParameters[20] = new SqlParameter("@tempSex", SqlDbType.Bit);
                SqlParameters[20].Direction = ParameterDirection.InputOutput;
                SqlParameters[20].Value = (object)(int)(info.Sex ? 1 : 0);
                SqlParameters[21] = new SqlParameter("@tempDutyRight", SqlDbType.Int);
                SqlParameters[21].Direction = ParameterDirection.InputOutput;
                SqlParameters[21].Value = (object)info.Right;
                SqlParameters[22] = new SqlParameter("@tempConsortiaRepute", SqlDbType.Int);
                SqlParameters[22].Direction = ParameterDirection.InputOutput;
                SqlParameters[22].Value = (object)consortiaRepute;
                SqlParameters[23] = new SqlParameter("@tempLoginName", SqlDbType.NVarChar, 200);
                SqlParameters[23].Direction = ParameterDirection.InputOutput;
                SqlParameters[23].Value = (object)consortiaRepute;
                this.db.RunProcedure("SP_ConsortiaApplyUser_Pass", SqlParameters);
                int num = (int)SqlParameters[4].Value;
                flag = num == 0;
                if (flag)
                {
                    info.UserID = (int)SqlParameters[5].Value;
                    info.UserName = SqlParameters[6].Value.ToString();
                    info.DutyID = (int)SqlParameters[7].Value;
                    info.DutyName = SqlParameters[8].Value.ToString();
                    info.Offer = (int)SqlParameters[9].Value;
                    info.RichesOffer = (int)SqlParameters[10].Value;
                    info.RichesRob = (int)SqlParameters[11].Value;
                    info.LastDate = (DateTime)SqlParameters[12].Value;
                    info.Win = (int)SqlParameters[13].Value;
                    info.Total = (int)SqlParameters[14].Value;
                    info.Escape = (int)SqlParameters[15].Value;
                    info.Grade = (int)SqlParameters[16].Value;
                    info.Level = (int)SqlParameters[17].Value;
                    info.ID = (int)SqlParameters[18].Value;
                    info.State = (int)SqlParameters[19].Value;
                    info.Sex = (bool)SqlParameters[20].Value;
                    info.Right = (int)SqlParameters[21].Value;
                    consortiaRepute = (int)SqlParameters[22].Value;
                    info.LoginName = SqlParameters[23].Value.ToString();
                }
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.PassConsortiaApplyUsers.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.PassConsortiaApplyUsers.Msg3";
                        break;
                    case 6:
                        msg = "ConsortiaBussiness.PassConsortiaApplyUsers.Msg6";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaApplyUserInfo[] GetConsortiaApplyUserPage(int page, int size, ref int total, int order, int consortiaID, int applyID, int userID)
        {
            List<ConsortiaApplyUserInfo> list = new List<ConsortiaApplyUserInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (consortiaID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ConsortiaID =",
            (object) consortiaID,
            (object) " "
          });
                if (applyID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ID =",
            (object) applyID,
            (object) " "
          });
                if (userID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and UserID ='",
            (object) userID,
            (object) "' "
          });
                string fdOreder = "ID";
                switch (order)
                {
                    case 1:
                        fdOreder = "UserName,ID";
                        break;
                    case 2:
                        fdOreder = "ApplyDate,ID";
                        break;
                }
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("V_Consortia_Apply_Users", queryWhere, page, size, "*", fdOreder, "ID", ref total).Rows)
                    list.Add(new ConsortiaApplyUserInfo()
                    {
                        ID = (int)dataRow["ID"],
                        ApplyDate = (DateTime)dataRow["ApplyDate"],
                        ConsortiaID = (int)dataRow["ConsortiaID"],
                        ConsortiaName = dataRow["ConsortiaName"].ToString(),
                        ChairmanID = (int)dataRow["ChairmanID"],
                        ChairmanName = dataRow["ChairmanName"].ToString(),
                        IsExist = (bool)dataRow["IsExist"],
                        Remark = dataRow["Remark"].ToString(),
                        UserID = (int)dataRow["UserID"],
                        UserName = dataRow["UserName"].ToString(),
                        UserLevel = (int)dataRow["Grade"],
                        typeVIP = (int)dataRow["typeVIP"],
                        Win = (int)dataRow["Win"],
                        Total = (int)dataRow["Total"],
                        Repute = (int)dataRow["Repute"],
                        FightPower = (int)dataRow["FightPower"],
                        IsOld = (bool)dataRow["IsOldPlayer"],
                        Offer = (int)dataRow["Offer"]
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }

        public bool AddConsortiaInviteUsers(ConsortiaInviteUserInfo info, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[11];
                SqlParameters[0] = new SqlParameter("@ID", (object)info.ID);
                SqlParameters[0].Direction = ParameterDirection.InputOutput;
                SqlParameters[1] = new SqlParameter("@ConsortiaID", (object)info.ConsortiaID);
                SqlParameters[2] = new SqlParameter("@ConsortiaName", info.ConsortiaName == null ? (object)"" : (object)info.ConsortiaName);
                SqlParameters[3] = new SqlParameter("@InviteDate", (object)info.InviteDate);
                SqlParameters[4] = new SqlParameter("@InviteID", (object)info.InviteID);
                SqlParameters[5] = new SqlParameter("@InviteName", info.InviteName == null ? (object)"" : (object)info.InviteName);
                SqlParameters[6] = new SqlParameter("@IsExist", (object)(int)(info.IsExist ? 1 : 0));
                SqlParameters[7] = new SqlParameter("@Remark", info.Remark == null ? (object)"" : (object)info.Remark);
                SqlParameters[8] = new SqlParameter("@UserID", (object)info.UserID);
                SqlParameters[8].Direction = ParameterDirection.InputOutput;
                SqlParameters[9] = new SqlParameter("@UserName", info.UserName == null ? (object)"" : (object)info.UserName);
                SqlParameters[10] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[10].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaInviteUser_Add", SqlParameters);
                info.ID = (int)SqlParameters[0].Value;
                info.UserID = (int)SqlParameters[8].Value;
                int num = (int)SqlParameters[10].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg2";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg4";
                        break;
                    case 5:
                        msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg5";
                        break;
                    case 6:
                        msg = "ConsortiaBussiness.AddConsortiaInviteUsers.Msg6";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool DeleteConsortiaInviteUsers(int intiveID, int userID)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ID", (object) intiveID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[2].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_ConsortiaInviteUser_Delete", SqlParameters);
                flag = (int)SqlParameters[2].Value == 0;
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool PassConsortiaInviteUsers(int inviteID, int userID, string userName, ref int consortiaID, ref string consortiaName, ref string msg, ConsortiaUserInfo info, ref int tempID, ref string tempName, ref int consortiaRepute)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[24];
                SqlParameters[0] = new SqlParameter("@ID", (object)inviteID);
                SqlParameters[1] = new SqlParameter("@UserID", (object)userID);
                SqlParameters[2] = new SqlParameter("@UserName", (object)userName);
                SqlParameters[3] = new SqlParameter("@ConsortiaID", (object)consortiaID);
                SqlParameters[3].Direction = ParameterDirection.InputOutput;
                SqlParameters[4] = new SqlParameter("@ConsortiaName", SqlDbType.NVarChar, 100);
                SqlParameters[4].Value = (object)consortiaName;
                SqlParameters[4].Direction = ParameterDirection.InputOutput;
                SqlParameters[5] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[5].Direction = ParameterDirection.ReturnValue;
                SqlParameters[6] = new SqlParameter("@tempName", SqlDbType.NVarChar, 100);
                SqlParameters[6].Direction = ParameterDirection.InputOutput;
                SqlParameters[6].Value = (object)tempName;
                SqlParameters[7] = new SqlParameter("@tempDutyID", SqlDbType.Int);
                SqlParameters[7].Direction = ParameterDirection.InputOutput;
                SqlParameters[7].Value = (object)info.DutyID;
                SqlParameters[8] = new SqlParameter("@tempDutyName", SqlDbType.NVarChar, 100);
                SqlParameters[8].Direction = ParameterDirection.InputOutput;
                SqlParameters[8].Value = (object)"";
                SqlParameters[9] = new SqlParameter("@tempOffer", SqlDbType.Int);
                SqlParameters[9].Direction = ParameterDirection.InputOutput;
                SqlParameters[9].Value = (object)info.Offer;
                SqlParameters[10] = new SqlParameter("@tempRichesOffer", SqlDbType.Int);
                SqlParameters[10].Direction = ParameterDirection.InputOutput;
                SqlParameters[10].Value = (object)info.RichesOffer;
                SqlParameters[11] = new SqlParameter("@tempRichesRob", SqlDbType.Int);
                SqlParameters[11].Direction = ParameterDirection.InputOutput;
                SqlParameters[11].Value = (object)info.RichesRob;
                SqlParameters[12] = new SqlParameter("@tempLastDate", SqlDbType.DateTime);
                SqlParameters[12].Direction = ParameterDirection.InputOutput;
                SqlParameters[12].Value = (object)DateTime.Now;
                SqlParameters[13] = new SqlParameter("@tempWin", SqlDbType.Int);
                SqlParameters[13].Direction = ParameterDirection.InputOutput;
                SqlParameters[13].Value = (object)info.Win;
                SqlParameters[14] = new SqlParameter("@tempTotal", SqlDbType.Int);
                SqlParameters[14].Direction = ParameterDirection.InputOutput;
                SqlParameters[14].Value = (object)info.Total;
                SqlParameters[15] = new SqlParameter("@tempEscape", SqlDbType.Int);
                SqlParameters[15].Direction = ParameterDirection.InputOutput;
                SqlParameters[15].Value = (object)info.Escape;
                SqlParameters[16] = new SqlParameter("@tempID", SqlDbType.Int);
                SqlParameters[16].Direction = ParameterDirection.InputOutput;
                SqlParameters[16].Value = (object)tempID;
                SqlParameters[17] = new SqlParameter("@tempGrade", SqlDbType.Int);
                SqlParameters[17].Direction = ParameterDirection.InputOutput;
                SqlParameters[17].Value = (object)info.Level;
                SqlParameters[18] = new SqlParameter("@tempLevel", SqlDbType.Int);
                SqlParameters[18].Direction = ParameterDirection.InputOutput;
                SqlParameters[18].Value = (object)info.Level;
                SqlParameters[19] = new SqlParameter("@tempCUID", SqlDbType.Int);
                SqlParameters[19].Direction = ParameterDirection.InputOutput;
                SqlParameters[19].Value = (object)info.ID;
                SqlParameters[20] = new SqlParameter("@tempState", SqlDbType.Int);
                SqlParameters[20].Direction = ParameterDirection.InputOutput;
                SqlParameters[20].Value = (object)info.State;
                SqlParameters[21] = new SqlParameter("@tempSex", SqlDbType.Bit);
                SqlParameters[21].Direction = ParameterDirection.InputOutput;
                SqlParameters[21].Value = (object)(int)(info.Sex ? 1 : 0);
                SqlParameters[22] = new SqlParameter("@tempRight", SqlDbType.Int);
                SqlParameters[22].Direction = ParameterDirection.InputOutput;
                SqlParameters[22].Value = (object)info.Right;
                SqlParameters[23] = new SqlParameter("@tempConsortiaRepute", SqlDbType.Int);
                SqlParameters[23].Direction = ParameterDirection.InputOutput;
                SqlParameters[23].Value = (object)consortiaRepute;
                this.db.RunProcedure("SP_ConsortiaInviteUser_Pass", SqlParameters);
                int num = (int)SqlParameters[5].Value;
                flag = num == 0;
                if (flag)
                {
                    consortiaID = (int)SqlParameters[3].Value;
                    consortiaName = SqlParameters[4].Value.ToString();
                    tempName = SqlParameters[6].Value.ToString();
                    info.DutyID = (int)SqlParameters[7].Value;
                    info.DutyName = SqlParameters[8].Value.ToString();
                    info.Offer = (int)SqlParameters[9].Value;
                    info.RichesOffer = (int)SqlParameters[10].Value;
                    info.RichesRob = (int)SqlParameters[11].Value;
                    info.LastDate = (DateTime)SqlParameters[12].Value;
                    info.Win = (int)SqlParameters[13].Value;
                    info.Total = (int)SqlParameters[14].Value;
                    info.Escape = (int)SqlParameters[15].Value;
                    tempID = (int)SqlParameters[16].Value;
                    info.Grade = (int)SqlParameters[17].Value;
                    info.Level = (int)SqlParameters[18].Value;
                    info.ID = (int)SqlParameters[19].Value;
                    info.State = (int)SqlParameters[20].Value;
                    info.Sex = (bool)SqlParameters[21].Value;
                    info.Right = (int)SqlParameters[22].Value;
                    consortiaRepute = (int)SqlParameters[23].Value;
                }
                switch (num)
                {
                    case 3:
                        msg = "ConsortiaBussiness.PassConsortiaInviteUsers.Msg3";
                        break;
                    case 6:
                        msg = "ConsortiaBussiness.PassConsortiaInviteUsers.Msg6";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaInviteUserInfo[] GetConsortiaInviteUserPage(int page, int size, ref int total, int order, int userID, int inviteID)
        {
            List<ConsortiaInviteUserInfo> list = new List<ConsortiaInviteUserInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (userID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and UserID =",
            (object) userID,
            (object) " "
          });
                if (inviteID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and UserID =",
            (object) inviteID,
            (object) " "
          });
                string str = "ConsortiaName";
                switch (order)
                {
                    case 1:
                        str = "Repute";
                        break;
                    case 2:
                        str = "ChairmanName";
                        break;
                    case 3:
                        str = "Count";
                        break;
                    case 4:
                        str = "CelebCount";
                        break;
                    case 5:
                        str = "Honor";
                        break;
                }
                string fdOreder = str + ",ID ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("V_Consortia_Invite", queryWhere, page, size, "*", fdOreder, "ID", ref total).Rows)
                    list.Add(new ConsortiaInviteUserInfo()
                    {
                        ID = (int)dataRow["ID"],
                        CelebCount = (int)dataRow["CelebCount"],
                        ChairmanName = dataRow["ChairmanName"].ToString(),
                        ConsortiaID = (int)dataRow["ConsortiaID"],
                        ConsortiaName = dataRow["ConsortiaName"].ToString(),
                        Count = (int)dataRow["Count"],
                        Honor = (int)dataRow["Honor"],
                        InviteDate = (DateTime)dataRow["InviteDate"],
                        InviteID = (int)dataRow["InviteID"],
                        InviteName = dataRow["InviteName"].ToString(),
                        IsExist = (bool)dataRow["IsExist"],
                        Remark = dataRow["Remark"].ToString(),
                        Repute = (int)dataRow["Repute"],
                        UserID = (int)dataRow["UserID"],
                        UserName = dataRow["UserName"].ToString()
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }

        public bool DeleteConsortiaUser(int userID, int kickUserID, int consortiaID, ref string msg, ref string nickName)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[5]
        {
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@KickUserID", (object) kickUserID),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@Result", SqlDbType.Int),
          null
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                SqlParameters[4] = new SqlParameter("@NickName", SqlDbType.VarChar, 200);
                SqlParameters[4].Direction = ParameterDirection.InputOutput;
                SqlParameters[4].Value = (object)nickName;
                this.db.RunProcedure("SP_ConsortiaUser_Delete", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                if (num == 0)
                {
                    flag = true;
                    nickName = SqlParameters[4].Value.ToString();
                }
                switch (num - 2)
                {
                    case 0:
                        msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg2";
                        break;
                    case 1:
                        msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg3";
                        break;
                    case 2:
                        msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg4";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.DeleteConsortiaUser.Msg5";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaIsBanChat(int banUserID, int consortiaID, int userID, bool isBanChat, ref int tempID, ref string tempName, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[7]
        {
          new SqlParameter("@ID", (object) banUserID),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@IsBanChat", (object) (int) (isBanChat ? 1 : 0)),
          new SqlParameter("@TempID", (object) tempID),
          null,
          null
        };
                SqlParameters[4].Direction = ParameterDirection.InputOutput;
                SqlParameters[5] = new SqlParameter("@TempName", SqlDbType.NVarChar, 100);
                SqlParameters[5].Value = (object)tempName;
                SqlParameters[5].Direction = ParameterDirection.InputOutput;
                SqlParameters[6] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[6].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaIsBanChat_Update", SqlParameters);
                int num = (int)SqlParameters[6].Value;
                tempID = (int)SqlParameters[4].Value;
                tempName = SqlParameters[5].Value.ToString();
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpdateConsortiaIsBanChat.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.UpdateConsortiaIsBanChat.Msg3";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaUserRemark(int id, int consortiaID, int userID, string remark, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[5]
        {
          new SqlParameter("@ID", (object) id),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Remark", (object) remark),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[4].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaUserRemark_Update", SqlParameters);
                int num = (int)SqlParameters[4].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.UpdateConsortiaUserRemark.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaUserGrade(int id, int consortiaID, int userID, bool upGrade, ref string msg, ref ConsortiaDutyInfo info, ref string tempUserName)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[9]
        {
          new SqlParameter("@ID", (object) id),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@UpGrade", (object) (int) (upGrade ? 1 : 0)),
          new SqlParameter("@Result", SqlDbType.Int),
          null,
          null,
          null,
          null
        };
                SqlParameters[4].Direction = ParameterDirection.ReturnValue;
                SqlParameters[5] = new SqlParameter("@tempUserName", SqlDbType.VarChar, 100);
                SqlParameters[5].Direction = ParameterDirection.InputOutput;
                SqlParameters[5].Value = (object)tempUserName;
                SqlParameters[6] = new SqlParameter("@tempDutyLevel", SqlDbType.Int);
                SqlParameters[6].Direction = ParameterDirection.InputOutput;
                SqlParameters[6].Value = (object)info.Level;
                SqlParameters[7] = new SqlParameter("@tempDutyName", SqlDbType.VarChar, 100);
                SqlParameters[7].Direction = ParameterDirection.InputOutput;
                SqlParameters[7].Value = (object)"";
                SqlParameters[8] = new SqlParameter("@tempRight", SqlDbType.Int);
                SqlParameters[8].Direction = ParameterDirection.InputOutput;
                SqlParameters[8].Value = (object)info.Right;
                flag = this.db.RunProcedure("SP_ConsortiaUserGrade_Update", SqlParameters);
                int num = (int)SqlParameters[4].Value;
                flag = num == 0;
                if (flag)
                {
                    tempUserName = SqlParameters[5].Value.ToString();
                    info.Level = (int)SqlParameters[6].Value;
                    info.DutyName = SqlParameters[7].Value.ToString();
                    info.Right = (int)SqlParameters[8].Value;
                }
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg2";
                        break;
                    case 3:
                        msg = upGrade ? "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg3" : "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg10";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg4";
                        break;
                    case 5:
                        msg = "ConsortiaBussiness.UpdateConsortiaUserGrade.Msg5";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaUserInfo[] GetConsortiaUsersPage(int page, int size, ref int total, int order, int consortiaID, int userID, int state)
        {
            List<ConsortiaUserInfo> list = new List<ConsortiaUserInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (consortiaID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ConsortiaID =",
            (object) consortiaID,
            (object) " "
          });
                if (userID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and UserID =",
            (object) userID,
            (object) " "
          });
                if (state != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and state =",
            (object) state,
            (object) " "
          });
                string str = "UserName";
                switch (order)
                {
                    case 1:
                        str = "DutyID";
                        break;
                    case 2:
                        str = "Grade";
                        break;
                    case 3:
                        str = "Repute";
                        break;
                    case 4:
                        str = "GP";
                        break;
                    case 5:
                        str = "State";
                        break;
                    case 6:
                        str = "Offer";
                        break;
                }
                string fdOreder = str + ",ID ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("V_Consortia_Users", queryWhere, page, size, "*", fdOreder, "ID", ref total).Rows)
                {
                    ConsortiaUserInfo consortiaUserInfo = new ConsortiaUserInfo();
                    consortiaUserInfo.ID = (int)dataRow["ID"];
                    consortiaUserInfo.ConsortiaID = (int)dataRow["ConsortiaID"];
                    consortiaUserInfo.DutyID = (int)dataRow["DutyID"];
                    consortiaUserInfo.DutyName = dataRow["DutyName"].ToString();
                    consortiaUserInfo.IsExist = (bool)dataRow["IsExist"];
                    consortiaUserInfo.RatifierID = (int)dataRow["RatifierID"];
                    consortiaUserInfo.RatifierName = dataRow["RatifierName"].ToString();
                    consortiaUserInfo.Remark = dataRow["Remark"].ToString();
                    consortiaUserInfo.UserID = (int)dataRow["UserID"];
                    consortiaUserInfo.UserName = dataRow["UserName"].ToString();
                    consortiaUserInfo.Grade = (int)dataRow["Grade"];
                    consortiaUserInfo.GP = (int)dataRow["GP"];
                    consortiaUserInfo.Repute = (int)dataRow["Repute"];
                    consortiaUserInfo.State = (int)dataRow["State"];
                    consortiaUserInfo.Right = (int)dataRow["Right"];
                    consortiaUserInfo.Offer = (int)dataRow["Offer"];
                    consortiaUserInfo.Colors = dataRow["Colors"].ToString();
                    consortiaUserInfo.Style = dataRow["Style"].ToString();
                    consortiaUserInfo.Hide = (int)dataRow["Hide"];
                    consortiaUserInfo.Skin = dataRow["Skin"] == null ? "" : consortiaUserInfo.Skin;
                    consortiaUserInfo.Level = (int)dataRow["Level"];
                    consortiaUserInfo.LastDate = (DateTime)dataRow["LastDate"];
                    consortiaUserInfo.Sex = (bool)dataRow["Sex"];
                    consortiaUserInfo.IsBanChat = (bool)dataRow["IsBanChat"];
                    consortiaUserInfo.Win = (int)dataRow["Win"];
                    consortiaUserInfo.Total = (int)dataRow["Total"];
                    consortiaUserInfo.Escape = (int)dataRow["Escape"];
                    consortiaUserInfo.RichesOffer = (int)dataRow["RichesOffer"];
                    consortiaUserInfo.RichesRob = (int)dataRow["RichesRob"];
                    consortiaUserInfo.LoginName = dataRow["LoginName"] == null ? "" : dataRow["LoginName"].ToString();
                    consortiaUserInfo.Nimbus = (int)dataRow["Nimbus"];
                    consortiaUserInfo.FightPower = (int)dataRow["FightPower"];
                    consortiaUserInfo.typeVIP = Convert.ToByte(dataRow["typeVIP"]);
                    consortiaUserInfo.VIPLevel = (int)dataRow["VIPLevel"];
                    list.Add(consortiaUserInfo);
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }

        public ConsortiaUserInfo GetConsortiaUsersByUserID(int userID)
        {
            int total = 0;
            ConsortiaUserInfo[] consortiaUsersPage = this.GetConsortiaUsersPage(1, 1, ref total, -1, -1, userID, -1);
            if (consortiaUsersPage.Length == 1)
                return consortiaUsersPage[0];
            else
                return (ConsortiaUserInfo)null;
        }

        public bool AddConsortiaDuty(ConsortiaDutyInfo info, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[7];
                SqlParameters[0] = new SqlParameter("@DutyID", (object)info.DutyID);
                SqlParameters[0].Direction = ParameterDirection.InputOutput;
                SqlParameters[1] = new SqlParameter("@ConsortiaID", (object)info.ConsortiaID);
                SqlParameters[2] = new SqlParameter("@DutyName", (object)info.DutyName);
                SqlParameters[3] = new SqlParameter("@Level", (object)info.Level);
                SqlParameters[4] = new SqlParameter("@UserID", (object)userID);
                SqlParameters[5] = new SqlParameter("@Right", (object)info.Right);
                SqlParameters[6] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[6].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaDuty_Add", SqlParameters);
                info.DutyID = (int)SqlParameters[0].Value;
                int num = (int)SqlParameters[6].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.AddConsortiaDuty.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.AddConsortiaDuty.Msg3";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool DeleteConsortiaDuty(int dutyID, int userID, int consortiaID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@DutyID", (object) dutyID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_ConsortiaDuty_Delete", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.DeleteConsortiaDuty.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.DeleteConsortiaDuty.Msg3";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool UpdateConsortiaDuty(ConsortiaDutyInfo info, int userID, int updateType, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[8];
                SqlParameters[0] = new SqlParameter("@DutyID", (object)info.DutyID);
                SqlParameters[0].Direction = ParameterDirection.InputOutput;
                SqlParameters[1] = new SqlParameter("@ConsortiaID", (object)info.ConsortiaID);
                SqlParameters[2] = new SqlParameter("@DutyName", SqlDbType.NVarChar, 100);
                SqlParameters[2].Direction = ParameterDirection.InputOutput;
                SqlParameters[2].Value = (object)info.DutyName;
                SqlParameters[3] = new SqlParameter("@Right", SqlDbType.Int);
                SqlParameters[3].Direction = ParameterDirection.InputOutput;
                SqlParameters[3].Value = (object)info.Right;
                SqlParameters[4] = new SqlParameter("@Level", SqlDbType.Int);
                SqlParameters[4].Direction = ParameterDirection.InputOutput;
                SqlParameters[4].Value = (object)info.Level;
                SqlParameters[5] = new SqlParameter("@UserID", (object)userID);
                SqlParameters[6] = new SqlParameter("@UpdateType", (object)updateType);
                SqlParameters[7] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[7].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaDuty_Update", SqlParameters);
                int num = (int)SqlParameters[7].Value;
                flag = num == 0;
                if (flag)
                {
                    info.DutyID = (int)SqlParameters[0].Value;
                    info.DutyName = SqlParameters[2].Value == null ? "" : SqlParameters[2].Value.ToString();
                    info.Right = (int)SqlParameters[3].Value;
                    info.Level = (int)SqlParameters[4].Value;
                }
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.UpdateConsortiaDuty.Msg2";
                        break;
                    case 3:
                    case 4:
                        msg = "ConsortiaBussiness.UpdateConsortiaDuty.Msg3";
                        break;
                    case 5:
                        msg = "ConsortiaBussiness.DeleteConsortiaDuty.Msg5";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaDutyInfo[] GetConsortiaDutyPage(int page, int size, ref int total, int order, int consortiaID, int dutyID)
        {
            List<ConsortiaDutyInfo> list = new List<ConsortiaDutyInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (consortiaID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ConsortiaID =",
            (object) consortiaID,
            (object) " "
          });
                if (dutyID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and DutyID =",
            (object) dutyID,
            (object) " "
          });
                string str = "Level";
                if (order == 1)
                    str = "DutyName";
                string fdOreder = str + ",DutyID ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("Consortia_Duty", queryWhere, page, size, "*", fdOreder, "DutyID", ref total).Rows)
                    list.Add(new ConsortiaDutyInfo()
                    {
                        DutyID = (int)dataRow["DutyID"],
                        ConsortiaID = (int)dataRow["ConsortiaID"],
                        DutyName = dataRow["DutyName"].ToString(),
                        IsExist = (bool)dataRow["IsExist"],
                        Right = (int)dataRow["Right"],
                        Level = (int)dataRow["Level"]
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }

        public int[] GetConsortiaByAllyByState(int consortiaID, int state)
        {
            List<int> list = new List<int>();
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[2]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@State", (object) state)
        };
                this.db.GetReader(ref ResultDataReader, "SP_Consortia_AllyByState", SqlParameters);
                while (ResultDataReader.Read())
                    list.Add((int)ResultDataReader["Consortia2ID"]);
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            return list.ToArray();
        }

        public bool AddConsortiaApplyAlly(ConsortiaApplyAllyInfo info, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[9];
                SqlParameters[0] = new SqlParameter("@ID", (object)info.ID);
                SqlParameters[0].Direction = ParameterDirection.InputOutput;
                SqlParameters[1] = new SqlParameter("@Consortia1ID", (object)info.Consortia1ID);
                SqlParameters[2] = new SqlParameter("@Consortia2ID", (object)info.Consortia2ID);
                SqlParameters[3] = new SqlParameter("@Date", (object)info.Date);
                SqlParameters[4] = new SqlParameter("@Remark", (object)info.Remark);
                SqlParameters[5] = new SqlParameter("@IsExist", (object)(int)(info.IsExist ? 1 : 0));
                SqlParameters[6] = new SqlParameter("@UserID", (object)userID);
                SqlParameters[7] = new SqlParameter("@State", (object)info.State);
                SqlParameters[8] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[8].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_ConsortiaApplyAlly_Add", SqlParameters);
                info.ID = (int)SqlParameters[0].Value;
                int num = (int)SqlParameters[8].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.AddConsortiaApplyAlly.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.AddConsortiaApplyAlly.Msg3";
                        break;
                    case 4:
                        msg = "ConsortiaBussiness.AddConsortiaApplyAlly.Msg4";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool DeleteConsortiaApplyAlly(int applyID, int userID, int consortiaID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[4]
        {
          new SqlParameter("@ID", (object) applyID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[3].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_ConsortiaApplyAlly_Delete", SqlParameters);
                int num = (int)SqlParameters[3].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.DeleteConsortiaApplyAlly.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public bool PassConsortiaApplyAlly(int applyID, int userID, int consortiaID, ref int tempID, ref int state, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[6]
        {
          new SqlParameter("@ID", (object) applyID),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@tempID", (object) tempID),
          null,
          null
        };
                SqlParameters[3].Direction = ParameterDirection.InputOutput;
                SqlParameters[4] = new SqlParameter("@State", (object)state);
                SqlParameters[4].Direction = ParameterDirection.InputOutput;
                SqlParameters[5] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[5].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_ConsortiaApplyAlly_Pass", SqlParameters);
                int num = (int)SqlParameters[5].Value;
                if (num == 0)
                {
                    flag = true;
                    tempID = (int)SqlParameters[3].Value;
                    state = (int)SqlParameters[4].Value;
                }
                switch (num - 2)
                {
                    case 0:
                        msg = "ConsortiaBussiness.PassConsortiaApplyAlly.Msg2";
                        break;
                    case 1:
                        msg = "ConsortiaBussiness.PassConsortiaApplyAlly.Msg3";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaApplyAllyInfo[] GetConsortiaApplyAllyPage(int page, int size, ref int total, int order, int consortiaID, int applyID, int state)
        {
            List<ConsortiaApplyAllyInfo> list = new List<ConsortiaApplyAllyInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (consortiaID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and Consortia2ID =",
            (object) consortiaID,
            (object) " "
          });
                if (applyID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ID =",
            (object) applyID,
            (object) " "
          });
                if (state != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and State =",
            (object) state,
            (object) " "
          });
                string str = "ConsortiaName";
                switch (order)
                {
                    case 1:
                        str = "Repute";
                        break;
                    case 2:
                        str = "ChairmanName";
                        break;
                    case 3:
                        str = "Count";
                        break;
                    case 4:
                        str = "Level";
                        break;
                    case 5:
                        str = "Honor";
                        break;
                }
                string fdOreder = str + ",ID ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("V_Consortia_Apply_Ally", queryWhere, page, size, "*", fdOreder, "ID", ref total).Rows)
                    list.Add(new ConsortiaApplyAllyInfo()
                    {
                        ID = (int)dataRow["ID"],
                        CelebCount = (int)dataRow["CelebCount"],
                        ChairmanName = dataRow["ChairmanName"].ToString(),
                        Consortia1ID = (int)dataRow["Consortia1ID"],
                        Consortia2ID = (int)dataRow["Consortia2ID"],
                        ConsortiaName = dataRow["ConsortiaName"].ToString(),
                        Count = (int)dataRow["Count"],
                        Date = (DateTime)dataRow["Date"],
                        Honor = (int)dataRow["Honor"],
                        IsExist = (bool)dataRow["IsExist"],
                        Remark = dataRow["Remark"].ToString(),
                        Repute = (int)dataRow["Repute"],
                        State = (int)dataRow["State"],
                        Level = (int)dataRow["Level"],
                        Description = dataRow["Description"] == null ? "" : dataRow["Description"].ToString()
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }

        public Dictionary<int, int> GetConsortiaByAlly(int consortiaID)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[1]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID)
        };
                this.db.GetReader(ref ResultDataReader, "SP_Consortia_Ally_Neutral", SqlParameters);
                while (ResultDataReader.Read())
                {
                    if ((int)ResultDataReader["Consortia1ID"] != consortiaID)
                        dictionary.Add((int)ResultDataReader["Consortia1ID"], (int)ResultDataReader["State"]);
                    else
                        dictionary.Add((int)ResultDataReader["Consortia2ID"], (int)ResultDataReader["State"]);
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"GetConsortiaByAlly", ex);
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            return dictionary;
        }

        public bool AddConsortiaAlly(ConsortiaAllyInfo info, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[9];
                SqlParameters[0] = new SqlParameter("@ID", (object)info.ID);
                SqlParameters[0].Direction = ParameterDirection.InputOutput;
                SqlParameters[1] = new SqlParameter("@Consortia1ID", (object)info.Consortia1ID);
                SqlParameters[2] = new SqlParameter("@Consortia2ID", (object)info.Consortia2ID);
                SqlParameters[3] = new SqlParameter("@State", (object)info.State);
                SqlParameters[4] = new SqlParameter("@Date", (object)info.Date);
                SqlParameters[5] = new SqlParameter("@ValidDate", (object)info.ValidDate);
                SqlParameters[6] = new SqlParameter("@IsExist", (object)(int)(info.IsExist ? 1 : 0));
                SqlParameters[7] = new SqlParameter("@UserID", (object)userID);
                SqlParameters[8] = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameters[8].Direction = ParameterDirection.ReturnValue;
                this.db.RunProcedure("SP_ConsortiaAlly_Add", SqlParameters);
                int num = (int)SqlParameters[8].Value;
                flag = num == 0;
                switch (num)
                {
                    case 2:
                        msg = "ConsortiaBussiness.AddConsortiaAlly.Msg2";
                        break;
                    case 3:
                        msg = "ConsortiaBussiness.AddConsortiaAlly.Msg3";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaAllyInfo[] GetConsortiaAllyPage(int page, int size, ref int total, int order, int consortiaID, int state, string name)
        {
            List<ConsortiaAllyInfo> list = new List<ConsortiaAllyInfo>();
            string queryWhere = " IsExist=1 and ConsortiaID<>" + (object)consortiaID;
            Dictionary<int, int> consortiaByAlly = this.GetConsortiaByAlly(consortiaID);
            try
            {
                if (state != -1)
                {
                    string str1 = string.Empty;
                    foreach (int num in consortiaByAlly.Keys)
                        str1 = str1 + (object)num + ",";
                    string str2 = str1 + (object)0;
                    queryWhere = state != 0 ? queryWhere + " and ConsortiaID in (" + str2 + ") " : queryWhere + " and ConsortiaID not in (" + str2 + ") ";
                }
                if (!string.IsNullOrEmpty(name))
                    queryWhere = queryWhere + " and ConsortiaName like '%" + name + "%' ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("Consortia", queryWhere, page, size, "*", "ConsortiaID", "ConsortiaID", ref total).Rows)
                {
                    ConsortiaAllyInfo consortiaAllyInfo = new ConsortiaAllyInfo();
                    consortiaAllyInfo.Consortia1ID = (int)dataRow["ConsortiaID"];
                    consortiaAllyInfo.ConsortiaName1 = dataRow["ConsortiaName"] == null ? "" : dataRow["ConsortiaName"].ToString();
                    consortiaAllyInfo.ConsortiaName2 = "";
                    consortiaAllyInfo.Count1 = (int)dataRow["Count"];
                    consortiaAllyInfo.Repute1 = (int)dataRow["Repute"];
                    consortiaAllyInfo.ChairmanName1 = dataRow["ChairmanName"] == null ? "" : dataRow["ChairmanName"].ToString();
                    consortiaAllyInfo.ChairmanName2 = "";
                    consortiaAllyInfo.Level1 = (int)dataRow["Level"];
                    consortiaAllyInfo.Honor1 = (int)dataRow["Honor"];
                    consortiaAllyInfo.Description1 = dataRow["Description"] == null ? "" : dataRow["Description"].ToString();
                    consortiaAllyInfo.Description2 = "";
                    consortiaAllyInfo.Riches1 = (int)dataRow["Riches"];
                    consortiaAllyInfo.Date = DateTime.Now;
                    consortiaAllyInfo.IsExist = true;
                    if (consortiaByAlly.ContainsKey(consortiaAllyInfo.Consortia1ID))
                        consortiaAllyInfo.State = consortiaByAlly[consortiaAllyInfo.Consortia1ID];
                    consortiaAllyInfo.ValidDate = 0;
                    list.Add(consortiaAllyInfo);
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"GetConsortiaAllyPage", ex);
            }
            return list.ToArray();
        }

        public ConsortiaAllyInfo[] GetConsortiaAllyAll()
        {
            List<ConsortiaAllyInfo> list = new List<ConsortiaAllyInfo>();
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                this.db.GetReader(ref ResultDataReader, "SP_ConsortiaAlly_All");
                while (ResultDataReader.Read())
                    list.Add(new ConsortiaAllyInfo()
                    {
                        Consortia1ID = (int)ResultDataReader["Consortia1ID"],
                        Consortia2ID = (int)ResultDataReader["Consortia2ID"],
                        Date = (DateTime)ResultDataReader["Date"],
                        ID = (int)ResultDataReader["ID"],
                        State = (int)ResultDataReader["State"],
                        ValidDate = (int)ResultDataReader["ValidDate"],
                        IsExist = (bool)ResultDataReader["IsExist"]
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            return list.ToArray();
        }

        public ConsortiaEventInfo[] GetConsortiaEventPage(int page, int size, ref int total, int order, int consortiaID)
        {
            List<ConsortiaEventInfo> list = new List<ConsortiaEventInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (consortiaID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ConsortiaID =",
            (object) consortiaID,
            (object) " "
          });
                string fdOreder = "Date desc,ID ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("Consortia_Event", queryWhere, page, size, "*", fdOreder, "ID", ref total).Rows)
                    list.Add(new ConsortiaEventInfo()
                    {
                        ID = (int)dataRow["ID"],
                        ConsortiaID = (int)dataRow["ConsortiaID"],
                        Date = (DateTime)dataRow["Date"],
                        IsExist = (bool)dataRow["IsExist"],
                        Remark = dataRow["Remark"].ToString(),
                        Type = (int)dataRow["Type"]
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }

        public ConsortiaLevelInfo[] GetAllConsortiaLevel()
        {
            List<ConsortiaLevelInfo> list = new List<ConsortiaLevelInfo>();
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                this.db.GetReader(ref ResultDataReader, "SP_Consortia_Level_All");
                while (ResultDataReader.Read())
                    list.Add(new ConsortiaLevelInfo()
                    {
                        Count = (int)ResultDataReader["Count"],
                        Deduct = (int)ResultDataReader["Deduct"],
                        Level = (int)ResultDataReader["Level"],
                        NeedGold = (int)ResultDataReader["NeedGold"],
                        NeedItem = (int)ResultDataReader["NeedItem"],
                        Reward = (int)ResultDataReader["Reward"],
                        Riches = (int)ResultDataReader["Riches"],
                        ShopRiches = (int)ResultDataReader["ShopRiches"],
                        SmithRiches = (int)ResultDataReader["SmithRiches"],
                        StoreRiches = (int)ResultDataReader["StoreRiches"],
                        BufferRiches = (int)ResultDataReader["BufferRiches"]
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"GetAllConsortiaLevel", ex);
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            return list.ToArray();
        }

        public bool AddAndUpdateConsortiaEuqipControl(ConsortiaEquipControlInfo info, int userID, ref string msg)
        {
            bool flag = false;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[6]
        {
          new SqlParameter("@ConsortiaID", (object) info.ConsortiaID),
          new SqlParameter("@Level", (object) info.Level),
          new SqlParameter("@Type", (object) info.Type),
          new SqlParameter("@Riches", (object) info.Riches),
          new SqlParameter("@UserID", (object) userID),
          new SqlParameter("@Result", SqlDbType.Int)
        };
                SqlParameters[5].Direction = ParameterDirection.ReturnValue;
                flag = this.db.RunProcedure("SP_Consortia_Equip_Control_Add", SqlParameters);
                int num = (int)SqlParameters[2].Value;
                flag = num == 0;
                if (num == 2)
                    msg = "ConsortiaBussiness.AddAndUpdateConsortiaEuqipControl.Msg2";
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return flag;
        }

        public ConsortiaEquipControlInfo GetConsortiaEuqipRiches(int consortiaID, int Level, int type)
        {
            ConsortiaEquipControlInfo equipControlInfo = (ConsortiaEquipControlInfo)null;
            SqlDataReader ResultDataReader = (SqlDataReader)null;
            try
            {
                SqlParameter[] SqlParameters = new SqlParameter[3]
        {
          new SqlParameter("@ConsortiaID", (object) consortiaID),
          new SqlParameter("@Level", (object) Level),
          new SqlParameter("@Type", (object) type)
        };
                this.db.GetReader(ref ResultDataReader, "SP_Consortia_Equip_Control_Single", SqlParameters);
                if (ResultDataReader.Read())
                {
                    equipControlInfo = new ConsortiaEquipControlInfo();
                    equipControlInfo.ConsortiaID = (int)ResultDataReader["ConsortiaID"];
                    equipControlInfo.Level = (int)ResultDataReader["Level"];
                    equipControlInfo.Riches = (int)ResultDataReader["Riches"];
                    equipControlInfo.Type = (int)ResultDataReader["Type"];
                    return equipControlInfo;
                }
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"GetAllConsortiaLevel", ex);
            }
            finally
            {
                if (ResultDataReader != null && !ResultDataReader.IsClosed)
                    ResultDataReader.Close();
            }
            if (equipControlInfo != null)
                return equipControlInfo;
            return new ConsortiaEquipControlInfo()
            {
                ConsortiaID = consortiaID,
                Level = Level,
                Riches = 100,
                Type = type
            };
        }

        public ConsortiaEquipControlInfo[] GetConsortiaEquipControlPage(int page, int size, ref int total, int order, int consortiaID, int level, int type)
        {
            List<ConsortiaEquipControlInfo> list = new List<ConsortiaEquipControlInfo>();
            try
            {
                string queryWhere = " IsExist=1 ";
                if (consortiaID != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and ConsortiaID =",
            (object) consortiaID,
            (object) " "
          });
                if (level != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and Level =",
            (object) level,
            (object) " "
          });
                if (type != -1)
                    queryWhere = string.Concat(new object[4]
          {
            (object) queryWhere,
            (object) " and Type =",
            (object) type,
            (object) " "
          });
                string fdOreder = "ConsortiaID ";
                foreach (DataRow dataRow in (InternalDataCollectionBase)this.GetPage("Consortia_Equip_Control", queryWhere, page, size, "*", fdOreder, "ConsortiaID", ref total).Rows)
                    list.Add(new ConsortiaEquipControlInfo()
                    {
                        ConsortiaID = (int)dataRow["ConsortiaID"],
                        Level = (int)dataRow["Level"],
                        Riches = (int)dataRow["Riches"],
                        Type = (int)dataRow["Type"]
                    });
            }
            catch (Exception ex)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                    BaseBussiness.log.Error((object)"Init", ex);
            }
            return list.ToArray();
        }
    }
}
