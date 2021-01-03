 public ActionResult getTaskList(string TemplateIdPView)
        {
            int Id = 0;

            if (TemplateIdPView != null && TemplateIdPView != "")
            {
                Id = Convert.ToInt32(TemplateIdPView);
            }

            DB_CMMS2020Entities db = new DB_CMMS2020Entities();

            return Json(db.WorkOrderTaskTemplateDetails.Where(x => x.WorkOrderTaskTemplateID == Id && x.StatusId != (int)TypeMasterDetailsEnum.statusDelete).Select(r => new
            {
                id = r.WorkOrderTaskTemplateDetailId,
                Name = r.Name,
                Description = r.Description,
                hh = r.Hours,
                mm = r.Minutes
            }).ToList(), JsonRequestBehavior.AllowGet);

        }
		
		
		public JsonResult mestodName(string pp)
        {
			   return Json(new { status = "text", Amount = result.Amount}, JsonRequestBehavior.AllowGet);
            
            return Json(null, JsonRequestBehavior.AllowGet);
        }