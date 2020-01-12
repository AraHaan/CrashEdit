using Crash;
using System.Drawing;
using System.Windows.Forms;

namespace CrashEdit
{
    public sealed class ModelEntryController : EntryController
    {
        public ModelEntryController(EntryChunkController entrychunkcontroller,ModelEntry modelentry) : base(entrychunkcontroller,modelentry)
        {
            ModelEntry = modelentry;
            InvalidateNode();
            InvalidateNodeImage();
        }

        public override void InvalidateNode()
        {
            if (ModelEntry.Positions == null)
            {
                Node.Text = string.Format(Crash.UI.Properties.Resources.ModelEntryController_Text,ModelEntry.EName);
            }
            else
            {
                Node.Text = string.Format(Crash.UI.Properties.Resources.ModelEntryController_Compressed_Text,ModelEntry.EName);
            }
        }

        public override void InvalidateNodeImage()
        {
            if (ModelEntry.Positions == null)
            {
                Node.ImageKey = "crimsonb";
                Node.SelectedImageKey = "crimsonb";
            }
            else
            {
                Node.ImageKey = "redb";
                Node.SelectedImageKey = "redb";
            }
        }

        protected override Control CreateEditor()
        {
            if (ModelEntry.Positions == null)
                return base.CreateEditor();
            else
            {
                int totalbits = ModelEntry.Positions.Count * 8 * 3;
                int bits = 0;
                foreach (ModelPosition pos in ModelEntry.Positions)
                {
                    bits += 1+pos.XBits;
                    bits += 1+pos.YBits;
                    bits += 1+pos.ZBits;
                }
                return new Label { Text = string.Format("Compression ratio: {0:0.0}%",(double)bits/totalbits * 100.0), TextAlign = ContentAlignment.MiddleCenter };
            }
        }

        public ModelEntry ModelEntry { get; }
    }
}
