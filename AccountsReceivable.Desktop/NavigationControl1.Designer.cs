using System.ComponentModel;

namespace AccountsReceivable.Desktop;

partial class NavigationControl1
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
        layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
        Root = new DevExpress.XtraLayout.LayoutControlGroup();
        splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
        layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
        calendarControl1 = new DevExpress.XtraEditors.Controls.CalendarControl();
        layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
        layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
        textEdit1 = new DevExpress.XtraEditors.TextEdit();
        layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
        emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
        ((ISupportInitialize)layoutControl1).BeginInit();
        layoutControl1.SuspendLayout();
        ((ISupportInitialize)Root).BeginInit();
        ((ISupportInitialize)splitContainerControl1).BeginInit();
        ((ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
        splitContainerControl1.Panel1.SuspendLayout();
        ((ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
        splitContainerControl1.Panel2.SuspendLayout();
        splitContainerControl1.SuspendLayout();
        ((ISupportInitialize)layoutControlItem1).BeginInit();
        ((ISupportInitialize)calendarControl1.CalendarTimeProperties).BeginInit();
        ((ISupportInitialize)layoutControl2).BeginInit();
        layoutControl2.SuspendLayout();
        ((ISupportInitialize)layoutControlGroup1).BeginInit();
        ((ISupportInitialize)textEdit1.Properties).BeginInit();
        ((ISupportInitialize)layoutControlItem2).BeginInit();
        ((ISupportInitialize)emptySpaceItem1).BeginInit();
        SuspendLayout();
        // 
        // layoutControl1
        // 
        layoutControl1.Controls.Add(splitContainerControl1);
        layoutControl1.Dock = DockStyle.Fill;
        layoutControl1.Location = new Point(0, 0);
        layoutControl1.Name = "layoutControl1";
        layoutControl1.Root = Root;
        layoutControl1.Size = new Size(226, 374);
        layoutControl1.TabIndex = 0;
        layoutControl1.Text = "layoutControl1";
        // 
        // Root
        // 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
        Root.GroupBordersVisible = false;
        Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
        Root.Name = "Root";
        Root.Size = new Size(226, 374);
        Root.TextVisible = false;
        // 
        // splitContainerControl1
        // 
        splitContainerControl1.Horizontal = false;
        splitContainerControl1.Location = new Point(12, 12);
        splitContainerControl1.Name = "splitContainerControl1";
        // 
        // splitContainerControl1.Panel1
        // 
        splitContainerControl1.Panel1.Controls.Add(layoutControl2);
        splitContainerControl1.Panel1.Text = "Panel1";
        // 
        // splitContainerControl1.Panel2
        // 
        splitContainerControl1.Panel2.Controls.Add(calendarControl1);
        splitContainerControl1.Panel2.Text = "Panel2";
        splitContainerControl1.Size = new Size(202, 350);
        splitContainerControl1.TabIndex = 4;
        // 
        // layoutControlItem1
        // 
        layoutControlItem1.Control = splitContainerControl1;
        layoutControlItem1.Location = new Point(0, 0);
        layoutControlItem1.Name = "layoutControlItem1";
        layoutControlItem1.Size = new Size(206, 354);
        layoutControlItem1.TextSize = new Size(0, 0);
        layoutControlItem1.TextVisible = false;
        // 
        // calendarControl1
        // 
        calendarControl1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
        calendarControl1.Dock = DockStyle.Fill;
        calendarControl1.Location = new Point(0, 0);
        calendarControl1.Name = "calendarControl1";
        calendarControl1.Size = new Size(202, 240);
        calendarControl1.TabIndex = 0;
        // 
        // layoutControl2
        // 
        layoutControl2.Controls.Add(textEdit1);
        layoutControl2.Dock = DockStyle.Fill;
        layoutControl2.Location = new Point(0, 0);
        layoutControl2.Name = "layoutControl2";
        layoutControl2.Root = layoutControlGroup1;
        layoutControl2.Size = new Size(202, 100);
        layoutControl2.TabIndex = 0;
        layoutControl2.Text = "layoutControl2";
        // 
        // layoutControlGroup1
        // 
        layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
        layoutControlGroup1.GroupBordersVisible = false;
        layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem2, emptySpaceItem1 });
        layoutControlGroup1.Name = "layoutControlGroup1";
        layoutControlGroup1.Size = new Size(202, 100);
        layoutControlGroup1.TextVisible = false;
        // 
        // textEdit1
        // 
        textEdit1.Location = new Point(117, 12);
        textEdit1.Name = "textEdit1";
        textEdit1.Size = new Size(73, 20);
        textEdit1.StyleController = layoutControl2;
        textEdit1.TabIndex = 4;
        // 
        // layoutControlItem2
        // 
        layoutControlItem2.Control = textEdit1;
        layoutControlItem2.Location = new Point(0, 0);
        layoutControlItem2.Name = "layoutControlItem2";
        layoutControlItem2.Size = new Size(182, 24);
        layoutControlItem2.TextSize = new Size(93, 13);
        // 
        // emptySpaceItem1
        // 
        emptySpaceItem1.AllowHotTrack = false;
        emptySpaceItem1.Location = new Point(0, 24);
        emptySpaceItem1.Name = "emptySpaceItem1";
        emptySpaceItem1.Size = new Size(182, 56);
        emptySpaceItem1.TextSize = new Size(0, 0);
        // 
        // NavigationControl1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(layoutControl1);
        Name = "NavigationControl1";
        Size = new Size(226, 374);
        ((ISupportInitialize)layoutControl1).EndInit();
        layoutControl1.ResumeLayout(false);
        ((ISupportInitialize)Root).EndInit();
        ((ISupportInitialize)splitContainerControl1.Panel1).EndInit();
        splitContainerControl1.Panel1.ResumeLayout(false);
        ((ISupportInitialize)splitContainerControl1.Panel2).EndInit();
        splitContainerControl1.Panel2.ResumeLayout(false);
        splitContainerControl1.Panel2.PerformLayout();
        ((ISupportInitialize)splitContainerControl1).EndInit();
        splitContainerControl1.ResumeLayout(false);
        ((ISupportInitialize)layoutControlItem1).EndInit();
        ((ISupportInitialize)calendarControl1.CalendarTimeProperties).EndInit();
        ((ISupportInitialize)layoutControl2).EndInit();
        layoutControl2.ResumeLayout(false);
        ((ISupportInitialize)layoutControlGroup1).EndInit();
        ((ISupportInitialize)textEdit1.Properties).EndInit();
        ((ISupportInitialize)layoutControlItem2).EndInit();
        ((ISupportInitialize)emptySpaceItem1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DevExpress.XtraLayout.LayoutControl layoutControl1;
    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private DevExpress.XtraLayout.LayoutControl layoutControl2;
    private DevExpress.XtraEditors.TextEdit textEdit1;
    private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    private DevExpress.XtraEditors.Controls.CalendarControl calendarControl1;
    private DevExpress.XtraLayout.LayoutControlGroup Root;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
}