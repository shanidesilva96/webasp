public ActionResult SparePartsReportFunction(ModelSparePartsReport model)
        {
            try
            {
                var Partlist = _unitOfWorkExpac.ItemRepository.GetAll(s => (s.CreatedDate >= model.DateFrom && s.CreatedDate <= model.DateTo) && s.StatusId != (int)StatusEnum.Deleted).ToList();
                
                if (model.IDPartCode != null)
                {
                    Partlist = Partlist.Select(s => s).Where(s => s.Id == model.IDPartCode).ToList();
                }

                if (model.IDSupplier != 0)
                {
                    Partlist = Partlist.Select(s => s).Where(s => s.SupplierId == model.IDSupplier).ToList();
                }
                if (model.submitbutton == "Load")
                {

                    var returnResult = new ModelSparePartsReport();
                    returnResult = model;

                    returnResult.ResultList = new List<ModelSparePartsReportTable>();
                    foreach (var item in Partlist)
                    {
                        var obj = new ModelSparePartsReportTable();

                        obj.PartCode = item != null ? item.Code.ToString() : "";

                        returnResult.ResultList.Add(obj);

                    }

                    returnResult.DateFrom = DateTime.Now.AddDays(-30);
                    returnResult.DateTo = DateTime.Now;
                    var CodeName = _unitOfWorkExpac.ItemRepository.GetAll().ToList();
                    foreach (var item in CodeName)
                    {
                        item.Code = item.Code + " - " + item.Description;
                    }
                    returnResult.ListPartCode = CodeName;
                    model.ListSupplier = _unitOfWorkExpac.CompanyRepository.GetAll(s => s.StatusId == (int)StatusEnum.Active).ToList();

                    return View("SparePartsReport", returnResult);
                }


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "crSparePartsReport.rpt"));

                var ds = new dsSparePartsReport();

                foreach (var item in Partlist)
                {
                    var dRow = ds.DT_SpareParts.NewDT_SparePartsRow();


                    dRow[0] = item != null ? item.Code.ToString() : "";

                    ds.DT_SpareParts.AddDT_SparePartsRow(dRow);
                }

                #region pdf / xls
                rd.SetDataSource(ds);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                if (model.submitbutton == "PDF")
                {
                    string name = "Spare Parts Report.pdf";
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    var contentLength = stream.Length;
                    Response.AppendHeader("Content-Length", contentLength.ToString());
                    Response.AppendHeader("Content-Disposition", "inline; filename=" + name + "");
                    return File(stream, "application/pdf");
                }
                else if (model.submitbutton == "XLS")
                {
                    string name = "Spare Parts Report.xls";
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/xls", name);
                }
                return null;
                #endregion
            }
            catch (Exception ex)
            {
                TempData[TempDataEnum.ErrorObject.ToString()] = Functions.GetErrorLogObject(ex);
                return RedirectToAction("Exception", "Common");
            }
        }