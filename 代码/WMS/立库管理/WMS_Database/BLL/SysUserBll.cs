﻿/**  版本信息模板在安装目录下，可自行修改。
* User.cs
*
* 功 能： N/A
* 类 名： User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018-06-10 6:28:13 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;


namespace WMS_Database
{
    /// <summary>
    /// SysUserBll
    /// </summary>
    public partial class SysUserBll
    {
        private readonly SysUserDal dal = new SysUserDal();
        public SysUserBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SysUser_Name)
        {
            return dal.Exists(SysUser_Name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SysUserModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SysUserModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SysUser_Name)
        {

            return dal.Delete(SysUser_Name);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SysUser_Namelist)
        {
            return dal.DeleteList(SysUser_Namelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SysUserModel GetModel(string SysUser_Name)
        {

            return dal.GetModel(SysUser_Name);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SysUserModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SysUserModel> DataTableToList(DataTable dt)
        {
            List<SysUserModel> modelList = new List<SysUserModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SysUserModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public List<SysUserModel> GetModelListByRoleName(string oldRoleName)
        {
            string strWhere = "SysUser_Name = '" + oldRoleName + "'";
            return GetModelList(strWhere);

        }

        public List<SysUserModel> GetModelByUserInfo(string userInfor)
        {
            if (userInfor.Trim() == "")
            {
                return GetModelList("");
            }
            string sqlStr = "SysUser_Name like '%" + userInfor + "%' or SysRole_Name like '%" + userInfor + "%'";
            List<SysUserModel> userList = GetModelList(sqlStr);
            if (userList != null && userList.Count != 0)
            {
                return userList;
            }
            else
            {
                return null;
            }

        }
        #endregion  ExtensionMethod
    }
}

