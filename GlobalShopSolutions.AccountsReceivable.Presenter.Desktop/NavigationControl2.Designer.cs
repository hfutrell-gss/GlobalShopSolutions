using System.ComponentModel;

namespace GlobalShopSolutions.AccountsReceivable.Presenter.Desktop;

partial class NavigationControl2
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        gridControl1 = new DevExpress.XtraGrid.GridControl();
        ((ISupportInitialize)gridControl1).BeginInit();
        SuspendLayout();
        // 
        // gridControl1
        // 
        gridControl1.Location = new Point(0, 0);
        gridControl1.Name = "gridControl1";
        gridControl1.TabIndex = 0;
        // 
        // NavigationControl2
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "NavigationControl2";
        Size = new Size(618, 480);
        ((ISupportInitialize)gridControl1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
}