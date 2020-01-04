using Crash;

namespace CrashEdit
{
    public sealed class PaletteEntryController : MysteryMultiItemEntryController
    {
        public PaletteEntryController(EntryChunkController entrychunkcontroller,PaletteEntry t18entry) : base(entrychunkcontroller,t18entry)
        {
            PaletteEntry = t18entry;
            InvalidateNode();
            InvalidateNodeImage();
        }

        public override void InvalidateNode()
        {
            Node.Text = string.Format("Palette ({0})",PaletteEntry.EName);
        }

        public override void InvalidateNodeImage()
        {
            Node.ImageKey = "thing";
            Node.SelectedImageKey = "thing";
        }

        public PaletteEntry PaletteEntry { get; }
    }
}
