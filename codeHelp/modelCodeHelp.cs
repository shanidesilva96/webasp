using ERP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DnW_Enterprices_CMMS.Models.Report
{
    public class ModelWarrantySummary
    {
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }
        
        [Display(Name = "Asset Code")]
        public int? IDAssetCode { get; set; }
        public List<Asset> ListAsset { get; set; }

        public string submitbutton { get; set; }
        public List<ModelWarrantySummaryTable> ResultList { get; set; }
		
    }
    public class ModelWarrantySummaryTable
    {
        public string AssetCode { get; set; }
    }
}