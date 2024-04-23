namespace GlobalShopSolutions.Desktop;

sealed partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        barManager1 = new DevExpress.XtraBars.BarManager(components);
        MainFormBar = new DevExpress.XtraBars.Bar();
        launcherButton = new DevExpress.XtraBars.BarButtonItem();
        settingsButton = new DevExpress.XtraBars.BarButtonItem();
        bar3 = new DevExpress.XtraBars.Bar();
        barDockControlTop = new DevExpress.XtraBars.BarDockControl();
        barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
        barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
        barDockControlRight = new DevExpress.XtraBars.BarDockControl();
        accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
        accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
        tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
        tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
        layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
        Root = new DevExpress.XtraLayout.LayoutControlGroup();
        tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
        saveButton = new DevExpress.XtraBars.BarButtonItem();
        ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tabPane1).BeginInit();
        tabPane1.SuspendLayout();
        tabNavigationPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
        SuspendLayout();
        // 
        // barManager1
        // 
        barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { MainFormBar, bar3 });
        barManager1.DockControls.Add(barDockControlTop);
        barManager1.DockControls.Add(barDockControlBottom);
        barManager1.DockControls.Add(barDockControlLeft);
        barManager1.DockControls.Add(barDockControlRight);
        barManager1.Form = this;
        barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { launcherButton, settingsButton, saveButton });
        barManager1.MainMenu = MainFormBar;
        barManager1.MaxItemId = 3;
        barManager1.StatusBar = bar3;
        // 
        // MainFormBar
        // 
        MainFormBar.BarName = "Main Form Bar";
        MainFormBar.DockCol = 0;
        MainFormBar.DockRow = 0;
        MainFormBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
        MainFormBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(launcherButton), new DevExpress.XtraBars.LinkPersistInfo(settingsButton), new DevExpress.XtraBars.LinkPersistInfo(saveButton) });
        MainFormBar.OptionsBar.AllowQuickCustomization = false;
        MainFormBar.OptionsBar.DrawDragBorder = false;
        MainFormBar.OptionsBar.UseWholeRow = true;
        MainFormBar.Text = "Main menu";
        // 
        // launcherButton
        // 
        launcherButton.Caption = "Launch";
        launcherButton.Id = 0;
        launcherButton.Name = "launcherButton";
        launcherButton.ItemClick += LauncherButtonItemClick;
        // 
        // settingsButton
        // 
        settingsButton.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
        settingsButton.Caption = "Settings";
        settingsButton.Id = 1;
        settingsButton.Name = "settingsButton";
        settingsButton.ItemClick += SettingsButtonItemClick;
        // 
        // bar3
        // 
        bar3.BarName = "Status bar";
        bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
        bar3.DockCol = 0;
        bar3.DockRow = 0;
        bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
        bar3.OptionsBar.AllowQuickCustomization = false;
        bar3.OptionsBar.DrawDragBorder = false;
        bar3.OptionsBar.UseWholeRow = true;
        bar3.Text = "Status bar";
        // 
        // barDockControlTop
        // 
        barDockControlTop.CausesValidation = false;
        barDockControlTop.Dock = DockStyle.Top;
        barDockControlTop.Location = new Point(0, 0);
        barDockControlTop.Manager = barManager1;
        barDockControlTop.Size = new Size(1435, 22);
        // 
        // barDockControlBottom
        // 
        barDockControlBottom.CausesValidation = false;
        barDockControlBottom.Dock = DockStyle.Bottom;
        barDockControlBottom.Location = new Point(0, 553);
        barDockControlBottom.Manager = barManager1;
        barDockControlBottom.Size = new Size(1435, 20);
        // 
        // barDockControlLeft
        // 
        barDockControlLeft.CausesValidation = false;
        barDockControlLeft.Dock = DockStyle.Left;
        barDockControlLeft.Location = new Point(0, 22);
        barDockControlLeft.Manager = barManager1;
        barDockControlLeft.Size = new Size(0, 531);
        // 
        // barDockControlRight
        // 
        barDockControlRight.CausesValidation = false;
        barDockControlRight.Dock = DockStyle.Right;
        barDockControlRight.Location = new Point(1435, 22);
        barDockControlRight.Manager = barManager1;
        barDockControlRight.Size = new Size(0, 531);
        // 
        // accordionControl1
        // 
        accordionControl1.Dock = DockStyle.Left;
        accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElement1 });
        accordionControl1.Location = new Point(0, 22);
        accordionControl1.Name = "accordionControl1";
        accordionControl1.Size = new Size(260, 531);
        accordionControl1.TabIndex = 4;
        // 
        // accordionControlElement1
        // 
        accordionControlElement1.Name = "accordionControlElement1";
        accordionControlElement1.Text = "Element1";
        // 
        // tabPane1
        // 
        tabPane1.Controls.Add(tabNavigationPage1);
        tabPane1.Controls.Add(tabNavigationPage2);
        tabPane1.Dock = DockStyle.Fill;
        tabPane1.Location = new Point(260, 22);
        tabPane1.Name = "tabPane1";
        tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { tabNavigationPage1, tabNavigationPage2 });
        tabPane1.RegularSize = new Size(1175, 531);
        tabPane1.SelectedPage = tabNavigationPage1;
        tabPane1.Size = new Size(1175, 531);
        tabPane1.TabIndex = 5;
        tabPane1.Text = "tabPane1";
        // 
        // tabNavigationPage1
        // 
        tabNavigationPage1.Caption = "tabNavigationPage1";
        tabNavigationPage1.Controls.Add(layoutControl1);
        tabNavigationPage1.Name = "tabNavigationPage1";
        tabNavigationPage1.Size = new Size(1175, 498);
        // 
        // layoutControl1
        // 
        layoutControl1.Dock = DockStyle.Fill;
        layoutControl1.Location = new Point(0, 0);
        layoutControl1.Name = "layoutControl1";
        layoutControl1.Root = Root;
        layoutControl1.Size = new Size(1175, 498);
        layoutControl1.TabIndex = 0;
        layoutControl1.Text = "layoutControl1";
        // 
        // Root
        // 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
        Root.GroupBordersVisible = false;
        Root.Name = "Root";
        Root.Size = new Size(1175, 498);
        Root.TextVisible = false;
        // 
        // tabNavigationPage2
        // 
        tabNavigationPage2.Caption = "tabNavigationPage2";
        tabNavigationPage2.Name = "tabNavigationPage2";
        tabNavigationPage2.Size = new Size(75, 23);
        // 
        // saveButton
        // 
        saveButton.Caption = "Save";
        saveButton.Id = 2;
        saveButton.Name = "saveButton";
        saveButton.ItemClick += saveButton_ItemClick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1435, 573);
        Controls.Add(tabPane1);
        Controls.Add(accordionControl1);
        Controls.Add(barDockControlLeft);
        Controls.Add(barDockControlRight);
        Controls.Add(barDockControlBottom);
        Controls.Add(barDockControlTop);
        MinimumSize = new Size(1437, 605);
        Name = "MainForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
        ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
        ((System.ComponentModel.ISupportInitialize)tabPane1).EndInit();
        tabPane1.ResumeLayout(false);
        tabNavigationPage1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
        ((System.ComponentModel.ISupportInitialize)Root).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DevExpress.XtraBars.BarManager barManager1;
    private DevExpress.XtraBars.Bar MainFormBar;
    private DevExpress.XtraBars.Bar bar3;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
    private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
    private DevExpress.XtraBars.Navigation.TabPane tabPane1;
    private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
    private DevExpress.XtraLayout.LayoutControl layoutControl1;
    private DevExpress.XtraLayout.LayoutControlGroup Root;
    private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
    private DevExpress.XtraBars.BarButtonItem launcherButton;
    private DevExpress.XtraBars.BarButtonItem settingsButton;
    private DevExpress.XtraBars.BarButtonItem saveButton;
}