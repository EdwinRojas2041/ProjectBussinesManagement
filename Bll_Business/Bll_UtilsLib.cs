﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_UtilsLib
    {
        public static Bo_Object bll_GetObjectByName(string pNameObject)
        {
            return Dao_UtilsLib.DaoUtilsLib_getObject(pNameObject);
        }

        public static List<Bo_Unit> bll_GetAllUnit()
        {
            return Dao_UtilsLib.DaoUtilsLib_getAllUnit();
        }

        public static Bo_Status bll_getStatusApproByObject(int pIdObject)
        {
            return Dao_UtilsLib.DaoUtilsLib_getStatusAppro(pIdObject);
        }

        public static string bll_GetValueParameter(string pNameParameter, string pNameParentParameter)
        {
            return Dao_UtilsLib.DaoUtilsLib_getParameterValueConfiguration(pNameParameter, pNameParentParameter);
        }
    }
}
