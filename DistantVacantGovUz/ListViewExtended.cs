using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace DistantVacantGovUz
{
    public class ListViewExtended : ListView
    {
        public bool AllowRowReorder { get; set; }

        public string REORDER;

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            base.OnItemDrag(e);
            if (!this.AllowRowReorder)
            {
                return;
            }
            base.DoDragDrop(REORDER, DragDropEffects.Move);
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            if (!this.AllowRowReorder)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            String text = (String)e.Data.GetData(REORDER.GetType());

            if (text.CompareTo(REORDER) == 0)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            if (!this.AllowRowReorder)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            Point cp = base.PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = base.GetItemAt(cp.X, cp.Y);

            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            foreach (ListViewItem moveItem in base.SelectedItems)
            {
                if (moveItem.Index == hoverItem.Index)
                {
                    e.Effect = DragDropEffects.None;
                    hoverItem.EnsureVisible();
                    return;
                }
            }

            base.OnDragOver(e);

            String text = (String)e.Data.GetData(REORDER.GetType());
            if (text.CompareTo(REORDER) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (!this.AllowRowReorder)
            {
                return;
            }

            if (base.SelectedItems.Count == 0)
            {
                return;
            }

            Point cp = base.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = base.GetItemAt(cp.X, cp.Y);

            if (dragToItem == null)
            {
                return;
            }

            int dropIndex = dragToItem.Index;

            if (dropIndex > base.SelectedItems[0].Index)
            {
                dropIndex++;
            }

            ArrayList insertItems = new ArrayList(base.SelectedItems.Count);

            foreach (ListViewItem item in base.SelectedItems)
            {
                insertItems.Add(item.Clone());
            }

            for (int i = insertItems.Count - 1; i >= 0; i--)
            {
                ListViewItem insertItem = (ListViewItem)insertItems[i];

                base.Items.Insert(dropIndex, insertItem);
            }

            foreach (ListViewItem removeItem in base.SelectedItems)
            {
                base.Items.Remove(removeItem);
            }
        }
    }
}
