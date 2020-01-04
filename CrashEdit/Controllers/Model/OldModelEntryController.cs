using Crash;

namespace CrashEdit
{
    public sealed class OldModelEntryController : EntryController
    {
        public OldModelEntryController(EntryChunkController entrychunkcontroller,OldModelEntry oldmodelentry) : base(entrychunkcontroller,oldmodelentry)
        {
            OldModelEntry = oldmodelentry;
            InvalidateNode();
            InvalidateNodeImage();
        }

        public override void InvalidateNode()
        {
            Node.Text = string.Format("Old Model ({0})",OldModelEntry.EName);
        }

        public override void InvalidateNodeImage()
        {
            Node.ImageKey = "crimsonb";
            Node.SelectedImageKey = "crimsonb";
        }

        public OldModelEntry OldModelEntry { get; }
    }
}
