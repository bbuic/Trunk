// Type: System.Windows.Forms.DataGridView
// Assembly: System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    [Designer(
        "System.Windows.Forms.Design.DataGridViewDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Docking(DockingBehavior.Ask)]
    [DefaultEvent("CellContentClick")]
    [ComplexBindingProperties("DataSource", "DataMember")]
    [Editor(
        "System.Windows.Forms.Design.DataGridViewComponentEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        , typeof (ComponentEditor))]
    public class DataGridView : Control, ISupportInitialize
    {
        public DataGridView();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual DataGridViewAdvancedBorderStyle AdjustedTopLeftHeaderBorderStyle { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public DataGridViewAdvancedBorderStyle AdvancedCellBorderStyle { get; }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public DataGridViewAdvancedBorderStyle AdvancedColumnHeadersBorderStyle { get; }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public DataGridViewAdvancedBorderStyle AdvancedRowHeadersBorderStyle { get; }

        [DefaultValue(true)]
        public bool AllowUserToAddRows { get; set; }

        [DefaultValue(true)]
        public bool AllowUserToDeleteRows { get; set; }

        [DefaultValue(false)]
        public bool AllowUserToOrderColumns { get; set; }

        [DefaultValue(true)]
        public bool AllowUserToResizeColumns { get; set; }

        [DefaultValue(true)]
        public bool AllowUserToResizeRows { get; set; }

        public DataGridViewCellStyle AlternatingRowsDefaultCellStyle { get; set; }

        [Browsable(false)]
        [DefaultValue(true)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool AutoGenerateColumns { get; set; }

        public override bool AutoSize { get; set; }

        [DefaultValue(1)]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; }

        [DefaultValue(0)]
        public DataGridViewAutoSizeRowsMode AutoSizeRowsMode { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor { get; set; }

        public Color BackgroundColor { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override Image BackgroundImage { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout { get; set; }

        [DefaultValue(1)]
        public BorderStyle BorderStyle { get; set; }

        protected override bool CanEnableIme { get; }

        [DefaultValue(1)]
        [Browsable(true)]
        public DataGridViewCellBorderStyle CellBorderStyle { get; set; }

        [DefaultValue(1)]
        [Browsable(true)]
        public DataGridViewClipboardCopyMode ClipboardCopyMode { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        public int ColumnCount { get; set; }

        [DefaultValue(2)]
        [Browsable(true)]
        public DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle { get; set; }

        [AmbientValue(null)]
        public DataGridViewCellStyle ColumnHeadersDefaultCellStyle { get; set; }

        [Localizable(true)]
        public int ColumnHeadersHeight { get; set; }

        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(0)]
        public DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode { get; set; }

        [DefaultValue(true)]
        public bool ColumnHeadersVisible { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(
            "System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [MergableProperty(false)]
        public DataGridViewColumnCollection Columns { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DataGridViewCell CurrentCell { get; set; }

        [Browsable(false)]
        public Point CurrentCellAddress { get; }

        [Browsable(false)]
        public DataGridViewRow CurrentRow { get; }

        [Editor(
            "System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [DefaultValue("")]
        public string DataMember { get; set; }

        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(null)]
        [AttributeProvider(typeof (IListSource))]
        public object DataSource { get; set; }

        [AmbientValue(null)]
        public DataGridViewCellStyle DefaultCellStyle { get; set; }

        protected override Size DefaultSize { get; }
        public override Rectangle DisplayRectangle { get; }

        [DefaultValue(2)]
        public DataGridViewEditMode EditMode { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Control EditingControl { get; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Panel EditingPanel { get; }

        [DefaultValue(true)]
        public bool EnableHeadersVisualStyles { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DataGridViewCell FirstDisplayedCell { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public int FirstDisplayedScrollingColumnHiddenWidth { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FirstDisplayedScrollingColumnIndex { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FirstDisplayedScrollingRowIndex { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override Color ForeColor { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override Font Font { get; set; }

        public Color GridColor { get; set; }
        protected ScrollBar HorizontalScrollBar { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int HorizontalScrollingOffset { get; set; }

        [Browsable(false)]
        public bool IsCurrentCellDirty { get; }

        [Browsable(false)]
        public bool IsCurrentCellInEditMode { get; }

        [Browsable(false)]
        public bool IsCurrentRowDirty { get; }

        [DefaultValue(true)]
        public bool MultiSelect { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int NewRowIndex { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Padding Padding { get; set; }

        [DefaultValue(false)]
        [Browsable(true)]
        public bool ReadOnly { get; set; }

        [Browsable(false)]
        [DefaultValue(0)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RowCount { get; set; }

        [DefaultValue(2)]
        [Browsable(true)]
        public DataGridViewHeaderBorderStyle RowHeadersBorderStyle { get; set; }

        [AmbientValue(null)]
        public DataGridViewCellStyle RowHeadersDefaultCellStyle { get; set; }

        [DefaultValue(true)]
        public bool RowHeadersVisible { get; set; }

        [Localizable(true)]
        public int RowHeadersWidth { get; set; }

        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode { get; set; }

        [Browsable(false)]
        public DataGridViewRowCollection Rows { get; }

        public DataGridViewCellStyle RowsDefaultCellStyle { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(true)]
        public DataGridViewRow RowTemplate { get; set; }

        [Localizable(true)]
        [DefaultValue(3)]
        public ScrollBars ScrollBars { get; set; }

        [Browsable(false)]
        public DataGridViewSelectedCellCollection SelectedCells { get; }

        [Browsable(false)]
        public DataGridViewSelectedColumnCollection SelectedColumns { get; }

        [Browsable(false)]
        public DataGridViewSelectedRowCollection SelectedRows { get; }

        [DefaultValue(3)]
        [Browsable(true)]
        public DataGridViewSelectionMode SelectionMode { get; set; }

        [DefaultValue(true)]
        public bool ShowCellErrors { get; set; }

        [DefaultValue(true)]
        public bool ShowCellToolTips { get; set; }

        [DefaultValue(true)]
        public bool ShowEditingIcon { get; set; }

        [DefaultValue(true)]
        public bool ShowRowErrors { get; set; }

        [Browsable(false)]
        public DataGridViewColumn SortedColumn { get; }

        [Browsable(false)]
        public SortOrder SortOrder { get; }

        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool StandardTab { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public override string Text { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCell this[int columnIndex, int rowIndex] { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DataGridViewCell this[string columnName, int rowIndex] { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DataGridViewHeaderCell TopLeftHeaderCell { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Cursor UserSetCursor { get; }

        protected ScrollBar VerticalScrollBar { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VerticalScrollingOffset { get; }

        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool VirtualMode { get; set; }

        #region ISupportInitialize Members

        void ISupportInitialize.BeginInit();
        void ISupportInitialize.EndInit();

        #endregion

        protected virtual void AccessibilityNotifyCurrentCellChanged(Point cellAddress);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual DataGridViewAdvancedBorderStyle AdjustColumnHeaderBorderStyle(
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput,
            DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceholder, bool isFirstDisplayedColumn,
            bool isLastVisibleColumn);

        public bool AreAllCellsSelected(bool includeInvisibleCells);
        public void AutoResizeColumn(int columnIndex);
        public void AutoResizeColumn(int columnIndex, DataGridViewAutoSizeColumnMode autoSizeColumnMode);

        protected void AutoResizeColumn(int columnIndex, DataGridViewAutoSizeColumnMode autoSizeColumnMode,
                                        bool fixedHeight);

        public void AutoResizeColumnHeadersHeight();
        public void AutoResizeColumnHeadersHeight(int columnIndex);
        protected void AutoResizeColumnHeadersHeight(bool fixedRowHeadersWidth, bool fixedColumnsWidth);
        protected void AutoResizeColumnHeadersHeight(int columnIndex, bool fixedRowHeadersWidth, bool fixedColumnWidth);
        public void AutoResizeColumns();
        public void AutoResizeColumns(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode);
        protected void AutoResizeColumns(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode, bool fixedHeight);
        public void AutoResizeRow(int rowIndex);
        public void AutoResizeRow(int rowIndex, DataGridViewAutoSizeRowMode autoSizeRowMode);
        protected void AutoResizeRow(int rowIndex, DataGridViewAutoSizeRowMode autoSizeRowMode, bool fixedWidth);
        public void AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode);

        protected void AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode,
                                                 bool fixedColumnHeadersHeight, bool fixedRowsHeight);

        public void AutoResizeRowHeadersWidth(int rowIndex, DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode);

        protected void AutoResizeRowHeadersWidth(int rowIndex,
                                                 DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode,
                                                 bool fixedColumnHeadersHeight, bool fixedRowHeight);

        public void AutoResizeRows();
        public void AutoResizeRows(DataGridViewAutoSizeRowsMode autoSizeRowsMode);
        protected void AutoResizeRows(DataGridViewAutoSizeRowsMode autoSizeRowsMode, bool fixedWidth);

        protected void AutoResizeRows(int rowIndexStart, int rowsCount, DataGridViewAutoSizeRowMode autoSizeRowMode,
                                      bool fixedWidth);

        public virtual bool BeginEdit(bool selectAll);
        public bool CancelEdit();
        public void ClearSelection();
        protected void ClearSelection(int columnIndexException, int rowIndexException, bool selectExceptionElement);
        public bool CommitEdit(DataGridViewDataErrorContexts context);
        protected override AccessibleObject CreateAccessibilityInstance();
        protected override Control.ControlCollection CreateControlsInstance();

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual DataGridViewColumnCollection CreateColumnsInstance();

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual DataGridViewRowCollection CreateRowsInstance();

        public int DisplayedColumnCount(bool includePartialColumns);
        public int DisplayedRowCount(bool includePartialRow);
        protected override void Dispose(bool disposing);
        public bool EndEdit();
        public bool EndEdit(DataGridViewDataErrorContexts context);
        protected override AccessibleObject GetAccessibilityObjectById(int objectId);
        public int GetCellCount(DataGridViewElementStates includeFilter);
        public Rectangle GetCellDisplayRectangle(int columnIndex, int rowIndex, bool cutOverflow);
        public virtual DataObject GetClipboardContent();
        public Rectangle GetColumnDisplayRectangle(int columnIndex, bool cutOverflow);
        public Rectangle GetRowDisplayRectangle(int rowIndex, bool cutOverflow);
        public DataGridView.HitTestInfo HitTest(int x, int y);
        public void InvalidateCell(DataGridViewCell dataGridViewCell);
        public void InvalidateCell(int columnIndex, int rowIndex);
        public void InvalidateColumn(int columnIndex);
        public void InvalidateRow(int rowIndex);
        protected override bool IsInputChar(char charCode);
        protected override bool IsInputKey(Keys keyData);
        public virtual void NotifyCurrentCellDirty(bool dirty);
        protected virtual void OnAllowUserToAddRowsChanged(EventArgs e);
        protected virtual void OnAllowUserToDeleteRowsChanged(EventArgs e);
        protected virtual void OnAllowUserToOrderColumnsChanged(EventArgs e);
        protected virtual void OnAllowUserToResizeColumnsChanged(EventArgs e);
        protected virtual void OnAllowUserToResizeRowsChanged(EventArgs e);
        protected virtual void OnAlternatingRowsDefaultCellStyleChanged(EventArgs e);
        protected virtual void OnAutoGenerateColumnsChanged(EventArgs e);
        protected virtual void OnAutoSizeColumnModeChanged(DataGridViewAutoSizeColumnModeEventArgs e);
        protected virtual void OnAutoSizeColumnsModeChanged(DataGridViewAutoSizeColumnsModeEventArgs e);
        protected virtual void OnAutoSizeRowsModeChanged(DataGridViewAutoSizeModeEventArgs e);
        protected virtual void OnBackgroundColorChanged(EventArgs e);
        protected override void OnBindingContextChanged(EventArgs e);
        protected virtual void OnBorderStyleChanged(EventArgs e);
        protected virtual void OnCancelRowEdit(QuestionEventArgs e);
        protected virtual void OnCellBeginEdit(DataGridViewCellCancelEventArgs e);
        protected virtual void OnCellBorderStyleChanged(EventArgs e);
        protected virtual void OnCellClick(DataGridViewCellEventArgs e);
        protected virtual void OnCellContentClick(DataGridViewCellEventArgs e);
        protected virtual void OnCellContentDoubleClick(DataGridViewCellEventArgs e);
        protected virtual void OnCellContextMenuStripChanged(DataGridViewCellEventArgs e);
        protected virtual void OnCellContextMenuStripNeeded(DataGridViewCellContextMenuStripNeededEventArgs e);
        protected virtual void OnCellDoubleClick(DataGridViewCellEventArgs e);
        protected virtual void OnCellEndEdit(DataGridViewCellEventArgs e);
        protected virtual void OnCellEnter(DataGridViewCellEventArgs e);
        protected virtual void OnCellErrorTextChanged(DataGridViewCellEventArgs e);
        protected virtual void OnCellErrorTextNeeded(DataGridViewCellErrorTextNeededEventArgs e);
        protected virtual void OnCellFormatting(DataGridViewCellFormattingEventArgs e);
        protected virtual void OnCellLeave(DataGridViewCellEventArgs e);
        protected virtual void OnCellMouseClick(DataGridViewCellMouseEventArgs e);
        protected virtual void OnCellMouseDoubleClick(DataGridViewCellMouseEventArgs e);
        protected virtual void OnCellMouseDown(DataGridViewCellMouseEventArgs e);
        protected virtual void OnCellMouseEnter(DataGridViewCellEventArgs e);
        protected virtual void OnCellMouseLeave(DataGridViewCellEventArgs e);
        protected virtual void OnCellMouseMove(DataGridViewCellMouseEventArgs e);
        protected virtual void OnCellMouseUp(DataGridViewCellMouseEventArgs e);
        protected internal virtual void OnCellPainting(DataGridViewCellPaintingEventArgs e);
        protected virtual void OnCellParsing(DataGridViewCellParsingEventArgs e);
        protected virtual void OnCellStateChanged(DataGridViewCellStateChangedEventArgs e);
        protected virtual void OnCellStyleChanged(DataGridViewCellEventArgs e);
        protected virtual void OnCellStyleContentChanged(DataGridViewCellStyleContentChangedEventArgs e);
        protected virtual void OnCellToolTipTextChanged(DataGridViewCellEventArgs e);
        protected virtual void OnCellToolTipTextNeeded(DataGridViewCellToolTipTextNeededEventArgs e);
        protected virtual void OnCellValidated(DataGridViewCellEventArgs e);
        protected virtual void OnCellValidating(DataGridViewCellValidatingEventArgs e);
        protected virtual void OnCellValueChanged(DataGridViewCellEventArgs e);
        protected virtual void OnCellValueNeeded(DataGridViewCellValueEventArgs e);
        protected virtual void OnCellValuePushed(DataGridViewCellValueEventArgs e);
        protected virtual void OnColumnAdded(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnContextMenuStripChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnDataPropertyNameChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnDefaultCellStyleChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnDisplayIndexChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnDividerDoubleClick(DataGridViewColumnDividerDoubleClickEventArgs e);
        protected virtual void OnColumnDividerWidthChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnHeaderCellChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e);
        protected virtual void OnColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e);
        protected virtual void OnColumnHeadersBorderStyleChanged(EventArgs e);
        protected virtual void OnColumnHeadersDefaultCellStyleChanged(EventArgs e);
        protected virtual void OnColumnHeadersHeightChanged(EventArgs e);
        protected virtual void OnColumnHeadersHeightSizeModeChanged(DataGridViewAutoSizeModeEventArgs e);
        protected virtual void OnColumnMinimumWidthChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnNameChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnRemoved(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnSortModeChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e);
        protected virtual void OnColumnToolTipTextChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnColumnWidthChanged(DataGridViewColumnEventArgs e);
        protected virtual void OnCurrentCellChanged(EventArgs e);
        protected virtual void OnCurrentCellDirtyStateChanged(EventArgs e);
        protected override void OnCursorChanged(EventArgs e);
        protected virtual void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e);
        protected virtual void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e);
        protected virtual void OnDataMemberChanged(EventArgs e);
        protected virtual void OnDataSourceChanged(EventArgs e);
        protected virtual void OnDefaultCellStyleChanged(EventArgs e);
        protected virtual void OnDefaultValuesNeeded(DataGridViewRowEventArgs e);
        protected override void OnDoubleClick(EventArgs e);
        protected virtual void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e);
        protected virtual void OnEditModeChanged(EventArgs e);
        protected override void OnEnabledChanged(EventArgs e);
        protected override void OnEnter(EventArgs e);
        protected override void OnFontChanged(EventArgs e);
        protected override void OnForeColorChanged(EventArgs e);
        protected override void OnGotFocus(EventArgs e);
        protected virtual void OnGridColorChanged(EventArgs e);
        protected override void OnHandleCreated(EventArgs e);
        protected override void OnHandleDestroyed(EventArgs e);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnKeyDown(KeyEventArgs e);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnKeyPress(KeyPressEventArgs e);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnKeyUp(KeyEventArgs e);

        protected override void OnLayout(LayoutEventArgs e);
        protected override void OnLeave(EventArgs e);
        protected override void OnLostFocus(EventArgs e);
        protected override void OnMouseClick(MouseEventArgs e);
        protected override void OnMouseDoubleClick(MouseEventArgs e);
        protected override void OnMouseDown(MouseEventArgs e);
        protected override void OnMouseEnter(EventArgs e);
        protected override void OnMouseLeave(EventArgs e);
        protected override void OnMouseMove(MouseEventArgs e);
        protected override void OnMouseUp(MouseEventArgs e);
        protected override void OnMouseWheel(MouseEventArgs e);
        protected virtual void OnMultiSelectChanged(EventArgs e);
        protected virtual void OnNewRowNeeded(DataGridViewRowEventArgs e);
        protected override void OnPaint(PaintEventArgs e);
        protected virtual void OnReadOnlyChanged(EventArgs e);
        protected override void OnResize(EventArgs e);
        protected override void OnRightToLeftChanged(EventArgs e);
        protected virtual void OnRowContextMenuStripChanged(DataGridViewRowEventArgs e);
        protected virtual void OnRowContextMenuStripNeeded(DataGridViewRowContextMenuStripNeededEventArgs e);
        protected virtual void OnRowDefaultCellStyleChanged(DataGridViewRowEventArgs e);
        protected virtual void OnRowDirtyStateNeeded(QuestionEventArgs e);
        protected virtual void OnRowDividerDoubleClick(DataGridViewRowDividerDoubleClickEventArgs e);
        protected virtual void OnRowDividerHeightChanged(DataGridViewRowEventArgs e);
        protected virtual void OnRowEnter(DataGridViewCellEventArgs e);
        protected virtual void OnRowErrorTextChanged(DataGridViewRowEventArgs e);
        protected virtual void OnRowErrorTextNeeded(DataGridViewRowErrorTextNeededEventArgs e);
        protected virtual void OnRowHeaderCellChanged(DataGridViewRowEventArgs e);
        protected virtual void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e);
        protected virtual void OnRowHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e);
        protected virtual void OnRowHeadersBorderStyleChanged(EventArgs e);
        protected virtual void OnRowHeadersDefaultCellStyleChanged(EventArgs e);
        protected virtual void OnRowHeadersWidthChanged(EventArgs e);
        protected virtual void OnRowHeadersWidthSizeModeChanged(DataGridViewAutoSizeModeEventArgs e);
        protected virtual void OnRowHeightChanged(DataGridViewRowEventArgs e);
        protected virtual void OnRowHeightInfoNeeded(DataGridViewRowHeightInfoNeededEventArgs e);
        protected virtual void OnRowHeightInfoPushed(DataGridViewRowHeightInfoPushedEventArgs e);
        protected virtual void OnRowLeave(DataGridViewCellEventArgs e);
        protected virtual void OnRowMinimumHeightChanged(DataGridViewRowEventArgs e);
        protected internal virtual void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e);
        protected internal virtual void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e);
        protected virtual void OnRowsAdded(DataGridViewRowsAddedEventArgs e);
        protected virtual void OnRowsDefaultCellStyleChanged(EventArgs e);
        protected virtual void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e);
        protected virtual void OnRowStateChanged(int rowIndex, DataGridViewRowStateChangedEventArgs e);
        protected virtual void OnRowUnshared(DataGridViewRowEventArgs e);
        protected virtual void OnRowValidating(DataGridViewCellCancelEventArgs e);
        protected virtual void OnRowValidated(DataGridViewCellEventArgs e);
        protected virtual void OnScroll(ScrollEventArgs e);
        protected virtual void OnSelectionChanged(EventArgs e);
        protected virtual void OnSortCompare(DataGridViewSortCompareEventArgs e);
        protected virtual void OnSorted(EventArgs e);
        protected virtual void OnUserAddedRow(DataGridViewRowEventArgs e);
        protected virtual void OnUserDeletedRow(DataGridViewRowEventArgs e);
        protected virtual void OnUserDeletingRow(DataGridViewRowCancelEventArgs e);
        protected override void OnValidating(CancelEventArgs e);
        protected override void OnVisibleChanged(EventArgs e);
        protected virtual void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds);
        protected bool ProcessAKey(Keys keyData);
        protected bool ProcessDeleteKey(Keys keyData);
        protected override bool ProcessDialogKey(Keys keyData);
        protected bool ProcessDownKey(Keys keyData);
        protected bool ProcessEndKey(Keys keyData);
        protected bool ProcessEnterKey(Keys keyData);
        protected bool ProcessEscapeKey(Keys keyData);
        protected bool ProcessF2Key(Keys keyData);
        protected bool ProcessHomeKey(Keys keyData);
        protected bool ProcessInsertKey(Keys keyData);
        protected override bool ProcessKeyEventArgs(ref Message m);
        protected override bool ProcessKeyPreview(ref Message m);
        protected bool ProcessLeftKey(Keys keyData);
        protected bool ProcessNextKey(Keys keyData);
        protected bool ProcessPriorKey(Keys keyData);
        protected bool ProcessRightKey(Keys keyData);
        protected bool ProcessSpaceKey(Keys keyData);
        protected bool ProcessTabKey(Keys keyData);
        protected virtual bool ProcessDataGridViewKey(KeyEventArgs e);
        protected bool ProcessUpKey(Keys keyData);
        protected bool ProcessZeroKey(Keys keyData);
        public bool RefreshEdit();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ResetText();

        public void SelectAll();

        protected virtual bool SetCurrentCellAddressCore(int columnIndex, int rowIndex, bool setAnchorCellAddress,
                                                         bool validateCurrentCell, bool throughMouseClick);

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified);
        protected virtual void SetSelectedCellCore(int columnIndex, int rowIndex, bool selected);
        protected virtual void SetSelectedColumnCore(int columnIndex, bool selected);
        protected virtual void SetSelectedRowCore(int rowIndex, bool selected);
        public virtual void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction);
        public virtual void Sort(IComparer comparer);
        public void UpdateCellErrorText(int columnIndex, int rowIndex);
        public void UpdateCellValue(int columnIndex, int rowIndex);
        public void UpdateRowErrorText(int rowIndex);
        public void UpdateRowErrorText(int rowIndexStart, int rowIndexEnd);
        public void UpdateRowHeightInfo(int rowIndex, bool updateToEnd);
        protected override void WndProc(ref Message m);

        public event EventHandler AllowUserToAddRowsChanged;
        public event EventHandler AllowUserToDeleteRowsChanged;
        public event EventHandler AllowUserToOrderColumnsChanged;
        public event EventHandler AllowUserToResizeColumnsChanged;
        public event EventHandler AllowUserToResizeRowsChanged;
        public event EventHandler AlternatingRowsDefaultCellStyleChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public event EventHandler AutoGenerateColumnsChanged;

        public event DataGridViewAutoSizeColumnsModeEventHandler AutoSizeColumnsModeChanged;
        public event DataGridViewAutoSizeModeEventHandler AutoSizeRowsModeChanged;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new event EventHandler BackColorChanged;

        public event EventHandler BackgroundColorChanged;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageChanged;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new event EventHandler BackgroundImageLayoutChanged;

        public event EventHandler BorderStyleChanged;
        public event EventHandler CellBorderStyleChanged;
        public event EventHandler ColumnHeadersBorderStyleChanged;
        public event EventHandler ColumnHeadersDefaultCellStyleChanged;
        public event EventHandler ColumnHeadersHeightChanged;
        public event DataGridViewAutoSizeModeEventHandler ColumnHeadersHeightSizeModeChanged;
        public event EventHandler DataMemberChanged;
        public event EventHandler DataSourceChanged;
        public event EventHandler DefaultCellStyleChanged;
        public event EventHandler EditModeChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public new event EventHandler ForeColorChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public new event EventHandler FontChanged;

        public event EventHandler GridColorChanged;
        public event EventHandler MultiSelectChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged;

        public event EventHandler ReadOnlyChanged;
        public event EventHandler RowHeadersBorderStyleChanged;
        public event EventHandler RowHeadersDefaultCellStyleChanged;
        public event EventHandler RowHeadersWidthChanged;
        public event DataGridViewAutoSizeModeEventHandler RowHeadersWidthSizeModeChanged;
        public event EventHandler RowsDefaultCellStyleChanged;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new event EventHandler TextChanged;

        public event DataGridViewAutoSizeColumnModeEventHandler AutoSizeColumnModeChanged;
        public event QuestionEventHandler CancelRowEdit;
        public event DataGridViewCellCancelEventHandler CellBeginEdit;
        public event DataGridViewCellEventHandler CellClick;
        public event DataGridViewCellEventHandler CellContentClick;
        public event DataGridViewCellEventHandler CellContentDoubleClick;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewCellEventHandler CellContextMenuStripChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewCellContextMenuStripNeededEventHandler CellContextMenuStripNeeded;

        public event DataGridViewCellEventHandler CellDoubleClick;
        public event DataGridViewCellEventHandler CellEndEdit;
        public event DataGridViewCellEventHandler CellEnter;
        public event DataGridViewCellEventHandler CellErrorTextChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewCellErrorTextNeededEventHandler CellErrorTextNeeded;

        public event DataGridViewCellFormattingEventHandler CellFormatting;
        public event DataGridViewCellEventHandler CellLeave;
        public event DataGridViewCellMouseEventHandler CellMouseClick;
        public event DataGridViewCellMouseEventHandler CellMouseDoubleClick;
        public event DataGridViewCellMouseEventHandler CellMouseDown;
        public event DataGridViewCellEventHandler CellMouseEnter;
        public event DataGridViewCellEventHandler CellMouseLeave;
        public event DataGridViewCellMouseEventHandler CellMouseMove;
        public event DataGridViewCellMouseEventHandler CellMouseUp;
        public event DataGridViewCellPaintingEventHandler CellPainting;
        public event DataGridViewCellParsingEventHandler CellParsing;
        public event DataGridViewCellStateChangedEventHandler CellStateChanged;
        public event DataGridViewCellEventHandler CellStyleChanged;
        public event DataGridViewCellStyleContentChangedEventHandler CellStyleContentChanged;
        public event DataGridViewCellEventHandler CellToolTipTextChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewCellToolTipTextNeededEventHandler CellToolTipTextNeeded;

        public event DataGridViewCellEventHandler CellValidated;
        public event DataGridViewCellValidatingEventHandler CellValidating;
        public event DataGridViewCellEventHandler CellValueChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewCellValueEventHandler CellValueNeeded;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewCellValueEventHandler CellValuePushed;

        public event DataGridViewColumnEventHandler ColumnAdded;
        public event DataGridViewColumnEventHandler ColumnContextMenuStripChanged;
        public event DataGridViewColumnEventHandler ColumnDataPropertyNameChanged;
        public event DataGridViewColumnEventHandler ColumnDefaultCellStyleChanged;
        public event DataGridViewColumnEventHandler ColumnDisplayIndexChanged;
        public event DataGridViewColumnDividerDoubleClickEventHandler ColumnDividerDoubleClick;
        public event DataGridViewColumnEventHandler ColumnDividerWidthChanged;
        public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick;
        public event DataGridViewCellMouseEventHandler ColumnHeaderMouseDoubleClick;
        public event DataGridViewColumnEventHandler ColumnHeaderCellChanged;
        public event DataGridViewColumnEventHandler ColumnMinimumWidthChanged;
        public event DataGridViewColumnEventHandler ColumnNameChanged;
        public event DataGridViewColumnEventHandler ColumnRemoved;
        public event DataGridViewColumnEventHandler ColumnSortModeChanged;
        public event DataGridViewColumnStateChangedEventHandler ColumnStateChanged;
        public event DataGridViewColumnEventHandler ColumnToolTipTextChanged;
        public event DataGridViewColumnEventHandler ColumnWidthChanged;
        public event EventHandler CurrentCellChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler CurrentCellDirtyStateChanged;

        public event DataGridViewBindingCompleteEventHandler DataBindingComplete;
        public event DataGridViewDataErrorEventHandler DataError;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewRowEventHandler DefaultValuesNeeded;

        public event DataGridViewEditingControlShowingEventHandler EditingControlShowing;
        public event DataGridViewRowEventHandler NewRowNeeded;
        public event DataGridViewRowEventHandler RowContextMenuStripChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewRowContextMenuStripNeededEventHandler RowContextMenuStripNeeded;

        public event DataGridViewRowEventHandler RowDefaultCellStyleChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event QuestionEventHandler RowDirtyStateNeeded;

        public event DataGridViewRowDividerDoubleClickEventHandler RowDividerDoubleClick;
        public event DataGridViewRowEventHandler RowDividerHeightChanged;
        public event DataGridViewCellEventHandler RowEnter;
        public event DataGridViewRowEventHandler RowErrorTextChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewRowErrorTextNeededEventHandler RowErrorTextNeeded;

        public event DataGridViewCellMouseEventHandler RowHeaderMouseClick;
        public event DataGridViewCellMouseEventHandler RowHeaderMouseDoubleClick;
        public event DataGridViewRowEventHandler RowHeaderCellChanged;
        public event DataGridViewRowEventHandler RowHeightChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewRowHeightInfoNeededEventHandler RowHeightInfoNeeded;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewRowHeightInfoPushedEventHandler RowHeightInfoPushed;

        public event DataGridViewCellEventHandler RowLeave;
        public event DataGridViewRowEventHandler RowMinimumHeightChanged;
        public event DataGridViewRowPostPaintEventHandler RowPostPaint;
        public event DataGridViewRowPrePaintEventHandler RowPrePaint;
        public event DataGridViewRowsAddedEventHandler RowsAdded;
        public event DataGridViewRowsRemovedEventHandler RowsRemoved;
        public event DataGridViewRowStateChangedEventHandler RowStateChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewRowEventHandler RowUnshared;

        public event DataGridViewCellEventHandler RowValidated;
        public event DataGridViewCellCancelEventHandler RowValidating;
        public event ScrollEventHandler Scroll;
        public event EventHandler SelectionChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event DataGridViewSortCompareEventHandler SortCompare;

        public event EventHandler Sorted;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new event EventHandler StyleChanged;

        public event DataGridViewRowEventHandler UserAddedRow;
        public event DataGridViewRowEventHandler UserDeletedRow;
        public event DataGridViewRowCancelEventHandler UserDeletingRow;

        #region Nested type: DataGridViewAccessibleObject

        [ComVisible(true)]
        protected class DataGridViewAccessibleObject : Control.ControlAccessibleObject
        {
            public DataGridViewAccessibleObject(DataGridView owner);
            public override string Name { get; }
            public override AccessibleRole Role { get; }
            public override AccessibleObject GetChild(int index);
            public override int GetChildCount();
            public override AccessibleObject GetFocused();
            public override AccessibleObject GetSelected();
            public override AccessibleObject HitTest(int x, int y);
            public override AccessibleObject Navigate(AccessibleNavigation navigationDirection);
        }

        #endregion

        #region Nested type: DataGridViewControlCollection

        [ComVisible(false)]
        public class DataGridViewControlCollection : Control.ControlCollection
        {
            public DataGridViewControlCollection(DataGridView owner);
            public void CopyTo(Control[] array, int index);
            public void Insert(int index, Control value);
            public override void Remove(Control value);
            public override void Clear();
        }

        #endregion

        #region Nested type: DataGridViewTopRowAccessibleObject

        [ComVisible(true)]
        protected class DataGridViewTopRowAccessibleObject : AccessibleObject
        {
            public DataGridViewTopRowAccessibleObject();
            public DataGridViewTopRowAccessibleObject(DataGridView owner);
            public override Rectangle Bounds { get; }
            public override string Name { get; }
            public DataGridView Owner { get; set; }
            public override AccessibleObject Parent { get; }
            public override AccessibleRole Role { get; }
            public override string Value { get; }
            public override AccessibleObject GetChild(int index);
            public override int GetChildCount();
            public override AccessibleObject Navigate(AccessibleNavigation navigationDirection);
        }

        #endregion

        #region Nested type: HitTestInfo

        public sealed class HitTestInfo
        {
            public static readonly DataGridView.HitTestInfo Nowhere;
            public int ColumnIndex { get; }
            public int RowIndex { get; }
            public int ColumnX { get; }
            public int RowY { get; }
            public DataGridViewHitTestType Type { get; }
            public override bool Equals(object value);
            public override int GetHashCode();
            public override string ToString();
        }

        #endregion
    }
}
