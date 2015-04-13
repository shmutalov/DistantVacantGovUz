using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DistantVacantGovUz
{
    public partial class frmLocalDocument : Form
    {
        private string documentName;
        private string documentFileName = "";
        private string documentFileNameWithOutExtension = "";

        private bool isNewDocument = false;
        private bool bIsDirty = false;

        public string GetDocumentFileName()
        {
            return documentFileName;
        }

        private bool isDirty
        {
            get
            {
                return bIsDirty;
            }

            set
            {
                bIsDirty = value;

                this.Text = ((bIsDirty)?"*":"") + this.documentName + " - " + "Local Vacancies";
            }
        }

        private List<CVacancyItem> workingVacancyList;
        private List<CVacancyItem> oldVacancyList;

        public frmLocalDocument()
        {
            InitializeComponent();

            oldVacancyList = new List<CVacancyItem>();
        }

        private void UpdateVacancyList()
        {
            lstVacancies.Items.Clear();

            bool c = true;

            for (int i = 0; i < workingVacancyList.Count; i++)
            {
                workingVacancyList[i].seqNum = (i + 1).ToString();

                ListViewItem li = lstVacancies.Items.Add("");
                li.SubItems.Add(workingVacancyList[i].seqNum);
                li.SubItems.Add((workingVacancyList[i].i_portal_vacancy_id == 0) ? "" : workingVacancyList[i].portal_vacancy_id);
                li.SubItems.Add(workingVacancyList[i].description_ru);
                li.SubItems.Add(workingVacancyList[i].description_uz);
                li.SubItems.Add((workingVacancyList[i].i_category_id == -1) ? "" : workingVacancyList[i].category);
                li.SubItems.Add(workingVacancyList[i].salary);
                li.SubItems.Add((workingVacancyList[i].i_employment_id == -1) ? "" : workingVacancyList[i].employment);
                li.SubItems.Add((workingVacancyList[i].i_gender_id == -1) ? "" : workingVacancyList[i].gender);
                li.SubItems.Add((workingVacancyList[i].i_experience_id == -1) ? "" : workingVacancyList[i].experience);
                li.SubItems.Add((workingVacancyList[i].i_education_id == -1) ? "" : workingVacancyList[i].education);
                li.SubItems.Add(workingVacancyList[i].expire_date);
                li.SubItems.Add(workingVacancyList[i].department_ru);
                li.SubItems.Add(workingVacancyList[i].specialization_ru);
                li.SubItems.Add(workingVacancyList[i].requirements_ru);
                li.SubItems.Add(workingVacancyList[i].information_ru);
                li.SubItems.Add(workingVacancyList[i].department_uz);
                li.SubItems.Add(workingVacancyList[i].specialization_uz);
                li.SubItems.Add(workingVacancyList[i].requirements_uz);
                li.SubItems.Add(workingVacancyList[i].information_uz);

                c = !c;

                if (workingVacancyList[i].IsValid())
                    li.BackColor = (c) ? Color.White : Color.AliceBlue;
                else
                    li.BackColor = Color.LightCoral;
            }

            foreach (ColumnHeader clmn in lstVacancies.Columns)
            {
                clmn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        public void SetDocument(string documentName)
        {
            isDirty = false;
            isNewDocument = true;

            this.documentName = documentName;
            this.documentFileName = documentName;
            this.documentFileNameWithOutExtension = documentName;

            workingVacancyList = new List<CVacancyItem>();

            this.Text = this.documentName + " - " + "Local Vacancies";

            UpdateVacancyList();
        }

        public void SetDocument(string documentFileName, List<CVacancyItem> vacancyList)
        {
            isDirty = false;
            isNewDocument = false;

            this.documentFileName = documentFileName;
            this.documentName = Path.GetFileName(documentFileName);
            this.documentFileNameWithOutExtension = documentFileName.Substring(0, documentFileName.Length - 4);

            this.workingVacancyList = vacancyList;

            this.Text = this.documentName + " - " + "Local Vacancies";

            UpdateVacancyList();
        }

        // Сохранение документа (по-умолчанию версия файла = 3)
        private void SaveDocument()
        {
            if (!isNewDocument)
            {
                if (!CVacancyFileType.SaveFile(documentFileName, workingVacancyList))
                {
                    MessageBox.Show("Не удалось сохранить документ", "Сохранение документа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    isDirty = false;
                    isNewDocument = false;
                }
            }
            else
            {
                SaveDocumentAs();
            }
        }

        // Сохранение документа как...
        private void SaveDocumentAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файл Вакансий (*.vacx)|*.vacx" + "|" + "Файл Вакансий (Старая версия, *.vac)|*.vac";

            if (documentFileName == "")
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + documentName;
            else
                sfd.InitialDirectory = Path.GetDirectoryName(documentFileName);

            sfd.FileName = documentFileNameWithOutExtension;

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VACANCY_FILE_VERSION version = (sfd.FilterIndex == 1) ? VACANCY_FILE_VERSION.VERSION_3 : VACANCY_FILE_VERSION.VERSION_2;

                if (!CVacancyFileType.SaveFileAs(sfd.FileName, workingVacancyList, version))
                {
                    MessageBox.Show("Не удалось сохранить документ", "Сохранение документа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    documentFileName = sfd.FileName;
                    documentName = Path.GetFileName(documentFileName);
                    documentFileNameWithOutExtension = documentFileName.Substring(0, documentFileName.Length - 4);

                    isDirty = false;
                    isNewDocument = false;
                }
            }
        }

        private void lstVacancies_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            stsSelectedItems.Text = "Selected: " + lstVacancies.CheckedItems.Count;

            toolBtnDeleteChecked.Enabled = (lstVacancies.CheckedItems.Count > 0) ? true : false;
            toolBtnUncheckAll.Enabled = (lstVacancies.CheckedItems.Count > 0) ? true : false;
            toolBtnCheckAll.Enabled = (lstVacancies.CheckedItems.Count != lstVacancies.Items.Count) ? true : false;
        }

        private void toolBtnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = true;
            }
        }

        private void toolBtnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = false;
            }
        }

        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void ReportPrintVersion(CVacancyReports.REPORT_TYPE reportType, string language)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = documentFileNameWithOutExtension + "_" + language;
            sfd.CheckPathExists = true;
            sfd.AddExtension = true;
            sfd.OverwritePrompt = true;
            sfd.Title = "Сохранить версию для печати как...";

            switch (reportType)
            {
                case CVacancyReports.REPORT_TYPE.PDF:
                    sfd.Filter = "Документ PDF (*.pdf) | *.pdf";
                    break;
                case CVacancyReports.REPORT_TYPE.XLS:
                    sfd.Filter = "Документ XLS (*.xls) | *.xls";
                    break;
                default:
                    return;
            }


            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                byte[] bytes;

                using (frmRptPrintVersionSettings fRptSettings = new frmRptPrintVersionSettings())
                {
                    Dictionary<String, Object> parameters = new Dictionary<String, Object>();
                    
                    // language specific default header
                    switch (language)
                    {
                        case "ru":
                            fRptSettings.headerText = "Вакантные должности инженерно-технических работников и рабочих по " + "АО \"Алмалыкский ГМК\"" + " для размещения в Едином портале интерактивных государственных услуг на " + DateTime.Now.ToString("dd.MM.yyyy") + " г." + "\n";
                            break;
                        case "uz":
                            fRptSettings.headerText = "Yagona interaktiv davlat xizmatlari portalida joylashtirish uchun " + "\n" + "AJ \"Olmaliq KMK\"" + " bo'yicha " + DateTime.Now.ToString("dd.MM.yyyy") + " y. muhandis-texnik ishchilar va ishchilarning bo'sh ish o'rinlari" + "\n";
                            break;
                        case "en":
                        default:
                            fRptSettings.headerText = "Vacancies for publishing on Portal of JS \"Almalyk MMC\"" + " from " + DateTime.Now.ToString("dd.MM.yyyy") + " y." + "\n";
                            break;
                    }

                    if (fRptSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // report parameters
                        parameters.Add("whom", fRptSettings.whomText);
                        parameters.Add("header", fRptSettings.headerText);
                        parameters.Add("footer", fRptSettings.footerText);
                        parameters.Add("visas", fRptSettings.visas);
                    }

                    //bytes = CVacancyReports.GenerateReport(CVacancyReports.REPORT_TYPE.PDF, "PRINT_VERSION", language, parameters, initialVacancyList);
                    bytes = CVacancyReports.GenerateReport(reportType, "PRINT_VERSION", language, parameters, workingVacancyList);
                }

                if (bytes != null)
                {
                    if (CVacancyUtil.SaveBytesToFile(sfd.FileName, bytes))
                    {
                        DialogResult dr = System.Windows.Forms.DialogResult.No;

                        switch (reportType)
                        {
                            case CVacancyReports.REPORT_TYPE.PDF:
                                dr = MessageBox.Show("Версия для печати подготовлена. Открыть?", "Версия для печати (PDF)", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                break;
                            case CVacancyReports.REPORT_TYPE.XLS:
                                dr = MessageBox.Show("Версия для печати подготовлена. Открыть?", "Версия для печати (XLS)", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                break;
                        }

                        switch (dr)
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                string p = '"' + sfd.FileName + '"';
                                try
                                {
                                    System.Diagnostics.Process.Start(p);
                                }
                                catch (Exception ex)
                                {
                                }
                                break;
                            case System.Windows.Forms.DialogResult.No:
                                break;
                        }
                    }
                }
            }
        }

        private void toolBtnReportPdfPrintVersionRu_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.PDF, "ru");
        }

        private void toolBtnReportPdfPrintVersionUz_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.PDF, "uz");
        }

        private void lstVacancies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedItems.Count == 1)
                toolBtnEditSelected.Enabled = true;
            else
                toolBtnEditSelected.Enabled = false;
        }

        private void toolBtnDeleteChecked_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete selected rows?", "Deleting rows...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                // сохраним текущий список
                CVacancyUtil.CopyVacancyItemList(workingVacancyList, oldVacancyList);
                toolBtnUndo.Enabled = true;
                toolBtnUndo.Enabled = false;

                List<CVacancyItem> itemsToDelete = new List<CVacancyItem>();

                foreach (int checkedIdx in lstVacancies.CheckedIndices)
                {
                    itemsToDelete.Add(workingVacancyList[checkedIdx]);
                }

                foreach (CVacancyItem v in itemsToDelete)
                {
                    try
                    {
                        workingVacancyList.Remove(v);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                isDirty = true;

                UpdateVacancyList();
            }

            if (lstVacancies.Items.Count == 0)
            {
                toolBtnCheckAll.Enabled = false;
                toolBtnUncheckAll.Enabled = false;
                toolBtnDeleteChecked.Enabled = false;
                toolBtnEditSelected.Enabled = false;
            }
        }

        private void toolBtnAdd_Click(object sender, EventArgs e)
        {
            List<CVacancyItem> tempList = new List<CVacancyItem>();
            CVacancyUtil.CopyVacancyItemList(workingVacancyList, tempList);

            int beforeAddVacancyCount = workingVacancyList.Count;

            frmAddLocalVacancy fAdd = new frmAddLocalVacancy();
            fAdd.vacs = workingVacancyList;
            fAdd.ShowDialog();

            if (beforeAddVacancyCount - workingVacancyList.Count != 0)
            {
                oldVacancyList = tempList;
                toolBtnUndo.Enabled = true;
                toolBtnUndo.Enabled = false;

                isDirty = true;

                UpdateVacancyList();

                lstVacancies.Items[lstVacancies.Items.Count - 1].Selected = true;
            }
        }

        private void toolBtnImportFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckPathExists = true;
            ofd.Title = "Выберите документ для импорта...";
            ofd.CheckFileExists = true;
            ofd.Filter = "Файл Вакансий (*.vac, *.vacx) | *.vac;*.vacx";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<CVacancyItem> importedVacancies = CVacancyFileType.OpenFile(ofd.FileName);

                if (importedVacancies != null && importedVacancies.Count > 0)
                {
                    // сохраним текущий список
                    CVacancyUtil.CopyVacancyItemList(workingVacancyList, oldVacancyList);
                    toolBtnUndo.Enabled = true;
                    toolBtnUndo.Enabled = false;

                    foreach (CVacancyItem imp_v in importedVacancies)
                    {
                        workingVacancyList.Add(imp_v);
                    }

                    isDirty = true;

                    UpdateVacancyList();
                }
            }
        }

        private void toolBtnReportXlsPrintVersionRu_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.XLS, "ru");
        }

        private void toolBtnReportXlsPrintVersionUz_Click(object sender, EventArgs e)
        {
            ReportPrintVersion(CVacancyReports.REPORT_TYPE.XLS, "uz");
        }

        private void lstVacancies_DoubleClick(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedIndices.Count == 1)
            {
                List<CVacancyItem> tempList = new List<CVacancyItem>();
                CVacancyUtil.CopyVacancyItemList(workingVacancyList, tempList);

                int selectedIdx = lstVacancies.SelectedIndices[0];

                lstVacancies.Items[selectedIdx].Checked = !lstVacancies.Items[selectedIdx].Checked;

                frmEditLocalVacancy fEdit = new frmEditLocalVacancy();
                fEdit.vac = workingVacancyList[selectedIdx];

                if (fEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    oldVacancyList = tempList;
                    toolBtnUndo.Enabled = true;

                    isDirty = true;
                    UpdateVacancyList();

                    lstVacancies.Items[selectedIdx].Selected = true;
                }
            }
        }

        private void toolBtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveDocumentAs();
        }

        private void toolBtnEditSelected_Click(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedIndices.Count == 1)
            {
                List<CVacancyItem> tempList = new List<CVacancyItem>();
                CVacancyUtil.CopyVacancyItemList(workingVacancyList, tempList);

                frmEditLocalVacancy fEdit = new frmEditLocalVacancy();
                int selectedIdx = lstVacancies.SelectedIndices[0];
                fEdit.vac = workingVacancyList[selectedIdx];

                if (fEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    oldVacancyList = tempList;
                    toolBtnUndo.Enabled = true;
                    toolBtnUndo.Enabled = false;

                    isDirty = true;
                    UpdateVacancyList();

                    lstVacancies.Items[selectedIdx].Selected = true;
                }
            }
        }

        private void toolBtnUndo_Click(object sender, EventArgs e)
        {
            CVacancyUtil.Swap(ref workingVacancyList, ref oldVacancyList);

            toolBtnUndo.Enabled = false;
            toolBtnRedo.Enabled = true;

            UpdateVacancyList();
        }

        private void toolBtnRedo_Click(object sender, EventArgs e)
        {
            CVacancyUtil.Swap(ref workingVacancyList, ref oldVacancyList);

            toolBtnUndo.Enabled = true;
            toolBtnRedo.Enabled = false;

            //UpdateVacancyList();
        }

        private void lstVacancies_BeforeRowReorder(object sender, EventArgs e)
        {
            CVacancyUtil.CopyVacancyItemList(workingVacancyList, oldVacancyList);

            toolBtnUndo.Enabled = true;
            toolBtnRedo.Enabled = false;
            isDirty = true;
        }

        private void RebuildWorkingVacancyList()
        {
            for (int i = 0; i < workingVacancyList.Count; i++)
            {
                //workingVacancyList[i].seqNum = lstVacancies.Items[i].SubItems[1].Text;

                workingVacancyList[int.Parse(lstVacancies.Items[i].SubItems[1].Text) - 1].seqNum = (i + 1).ToString();
            }

            CVacancyUtil.SortBySeqNum(workingVacancyList);

            UpdateVacancyList();
        }

        private void lstVacancies_AfterRowReorder(object sender, EventArgs e)
        {
            RebuildWorkingVacancyList();
        }
    }
}
