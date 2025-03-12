
namespace Persian.Calendar.Library
{
    partial class UICalendar
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
            if (CalendarImage != null)
            {
                CalendarImage.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthView = new FarsiLibrary.Win.Controls.FAMonthView();
            this.SuspendLayout();
            // 
            // monthView
            // 
            this.monthView.Location = new System.Drawing.Point(0, 0);
            this.monthView.Name = "monthView";
            this.monthView.SelectedDateTime = new System.DateTime(2021, 9, 4, 0, 0, 0, 0);
            this.monthView.ShowEmptyButton = false;
            this.monthView.ShowTodayButton = false;
            this.monthView.TabIndex = 0;
            // 
            // UICalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthView);
            this.Name = "UICalendar";
            this.Size = new System.Drawing.Size(166, 167);
            this.ResumeLayout(false);

        }

        #endregion

        private FarsiLibrary.Win.Controls.FAMonthView monthView;
    }
}
