namespace DistantVacantGovUz
{
    partial class frmRptPrintVersionSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPrintVersionSettings));
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.btnEditJobTitle = new System.Windows.Forms.Button();
            this.btnDeleteSelectedJobTitle = new System.Windows.Forms.Button();
            this.btnAddJobTitle = new System.Windows.Forms.Button();
            this.lblVisas = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.clmnSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFooter = new System.Windows.Forms.Label();
            this.lstVisas = new System.Windows.Forms.ListView();
            this.clmnJobTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtWhom = new System.Windows.Forms.TextBox();
            this.lblDocumentName = new System.Windows.Forms.Label();
            this.txtReportHeader = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFooter
            // 
            this.txtFooter.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFooter.Location = new System.Drawing.Point(12, 247);
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFooter.Size = new System.Drawing.Size(753, 66);
            this.txtFooter.TabIndex = 24;
            // 
            // btnEditJobTitle
            // 
            this.btnEditJobTitle.Location = new System.Drawing.Point(154, 332);
            this.btnEditJobTitle.Name = "btnEditJobTitle";
            this.btnEditJobTitle.Size = new System.Drawing.Size(225, 23);
            this.btnEditJobTitle.TabIndex = 23;
            this.btnEditJobTitle.Text = "Редактировать выбранную должность";
            this.btnEditJobTitle.UseVisualStyleBackColor = true;
            this.btnEditJobTitle.Click += new System.EventHandler(this.btnEditJobTitle_Click);
            // 
            // btnDeleteSelectedJobTitle
            // 
            this.btnDeleteSelectedJobTitle.Location = new System.Drawing.Point(576, 332);
            this.btnDeleteSelectedJobTitle.Name = "btnDeleteSelectedJobTitle";
            this.btnDeleteSelectedJobTitle.Size = new System.Drawing.Size(189, 23);
            this.btnDeleteSelectedJobTitle.TabIndex = 22;
            this.btnDeleteSelectedJobTitle.Text = "Удалить выбранную должность";
            this.btnDeleteSelectedJobTitle.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedJobTitle.Click += new System.EventHandler(this.btnDeleteSelectedJobTitle_Click);
            // 
            // btnAddJobTitle
            // 
            this.btnAddJobTitle.Location = new System.Drawing.Point(12, 332);
            this.btnAddJobTitle.Name = "btnAddJobTitle";
            this.btnAddJobTitle.Size = new System.Drawing.Size(136, 23);
            this.btnAddJobTitle.TabIndex = 21;
            this.btnAddJobTitle.Text = "Добавить должность";
            this.btnAddJobTitle.UseVisualStyleBackColor = true;
            this.btnAddJobTitle.Click += new System.EventHandler(this.btnAddJobTitle_Click);
            // 
            // lblVisas
            // 
            this.lblVisas.AutoSize = true;
            this.lblVisas.Location = new System.Drawing.Point(13, 316);
            this.lblVisas.Name = "lblVisas";
            this.lblVisas.Size = new System.Drawing.Size(35, 13);
            this.lblVisas.TabIndex = 20;
            this.lblVisas.Text = "Виза:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(679, 480);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Продолжить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // clmnSubject
            // 
            this.clmnSubject.Text = "Инициалы";
            this.clmnSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmnSubject.Width = 350;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(13, 231);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(48, 13);
            this.lblFooter.TabIndex = 25;
            this.lblFooter.Text = "Подвал:";
            // 
            // lstVisas
            // 
            this.lstVisas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnJobTitle,
            this.clmnSubject});
            this.lstVisas.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstVisas.FullRowSelect = true;
            this.lstVisas.GridLines = true;
            this.lstVisas.LabelWrap = false;
            this.lstVisas.Location = new System.Drawing.Point(12, 361);
            this.lstVisas.MultiSelect = false;
            this.lstVisas.Name = "lstVisas";
            this.lstVisas.Size = new System.Drawing.Size(753, 113);
            this.lstVisas.TabIndex = 19;
            this.lstVisas.UseCompatibleStateImageBehavior = false;
            this.lstVisas.View = System.Windows.Forms.View.Details;
            // 
            // clmnJobTitle
            // 
            this.clmnJobTitle.Text = "Должность";
            this.clmnJobTitle.Width = 390;
            // 
            // txtWhom
            // 
            this.txtWhom.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtWhom.Location = new System.Drawing.Point(393, 13);
            this.txtWhom.Multiline = true;
            this.txtWhom.Name = "txtWhom";
            this.txtWhom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWhom.Size = new System.Drawing.Size(371, 104);
            this.txtWhom.TabIndex = 18;
            this.txtWhom.Text = "И.о. начальника УАП\r\nМаксумов Р. А.\r\n";
            this.txtWhom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDocumentName
            // 
            this.lblDocumentName.AutoSize = true;
            this.lblDocumentName.Location = new System.Drawing.Point(13, 120);
            this.lblDocumentName.Name = "lblDocumentName";
            this.lblDocumentName.Size = new System.Drawing.Size(117, 13);
            this.lblDocumentName.TabIndex = 17;
            this.lblDocumentName.Text = "Название документа:";
            // 
            // txtReportHeader
            // 
            this.txtReportHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtReportHeader.Location = new System.Drawing.Point(12, 136);
            this.txtReportHeader.Multiline = true;
            this.txtReportHeader.Name = "txtReportHeader";
            this.txtReportHeader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReportHeader.Size = new System.Drawing.Size(753, 92);
            this.txtReportHeader.TabIndex = 16;
            this.txtReportHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmRptPrintVersionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 516);
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.btnEditJobTitle);
            this.Controls.Add(this.btnDeleteSelectedJobTitle);
            this.Controls.Add(this.btnAddJobTitle);
            this.Controls.Add(this.lblVisas);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.lstVisas);
            this.Controls.Add(this.txtWhom);
            this.Controls.Add(this.lblDocumentName);
            this.Controls.Add(this.txtReportHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptPrintVersionSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print version report parameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Button btnEditJobTitle;
        private System.Windows.Forms.Button btnDeleteSelectedJobTitle;
        private System.Windows.Forms.Button btnAddJobTitle;
        private System.Windows.Forms.Label lblVisas;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColumnHeader clmnSubject;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.ListView lstVisas;
        private System.Windows.Forms.ColumnHeader clmnJobTitle;
        private System.Windows.Forms.TextBox txtWhom;
        private System.Windows.Forms.Label lblDocumentName;
        private System.Windows.Forms.TextBox txtReportHeader;

    }
}