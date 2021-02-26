using CTS.Business.AdminAPP.Interface;
using CTS.DataAccess.AdminAPP.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.Business.AdminAPP
{
    public class DropdownManager : IDropdownManager
    {
        private readonly IConfiguration _config;
        private readonly IDropdownRepository _dropdownRepository;
        public DropdownManager(IConfiguration config, IDropdownRepository dropdownRepository)
        {
            _config = config;
            _dropdownRepository = dropdownRepository;
        }

        public  DataTable GetDropdowns(string spName)
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet =  _dropdownRepository.GetDropdowns(spName);

                dt = gridDataSet.Tables[0];
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable GetMenuOptions()
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet = _dropdownRepository.GetMenuOptions();

                dt = gridDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
