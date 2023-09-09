<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128626544/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1127)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Data Grid - Create a custom button for the embedded navigator

This example demonstrates how to create a custom button and display it in the grid's [data navigator](https://docs.devexpress.com/WindowsForms/522/controls-and-libraries/data-grid/visual-elements/grid-control-elements/data-navigator).

```csharp
private void Form1_Load(object sender, EventArgs e) {
    // ...
    gridControl1.UseEmbeddedNavigator = true;
    gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(gridControl1_EmbeddedNavigator_ButtonClick);
    gridControl1.EmbeddedNavigator.Buttons.ImageList = imageCollection1;
    DevExpress.XtraEditors.NavigatorCustomButton button = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
    button.Tag = "copy";
    button.Hint = "Copy to clipboard";
    button.ImageIndex = 0;
}
private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
    if("copy".Equals(e.Button.Tag)) {
        if(gridControl1.FocusedView != null) {
            gridControl1.FocusedView.CopyToClipboard();
            MessageBox.Show("Selected data has been copied to the Clipboard");
            e.Handled = true;
        }
    }
}
```


## Files to Review

* [Form1.cs](./CS/CustomButton/Form1.cs) (VB: [Form1.vb](./VB/CustomButton/Form1.vb))


## Documentation

* [Data Navigator - WinForms Data Grid](https://docs.devexpress.com/WindowsForms/522/controls-and-libraries/data-grid/visual-elements/grid-control-elements/data-navigator)
* [How to: Hide Specific Buttons in the Embedded Navigator](https://docs.devexpress.com/WindowsForms/3057/controls-and-libraries/data-grid/examples/navigation-and-selection/how-to-hide-specific-buttons-in-the-embedded-navigator)
