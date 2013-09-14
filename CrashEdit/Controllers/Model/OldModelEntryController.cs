using Crash;

namespace CrashEdit
{
    public sealed class OldModelEntryController : MysteryMultiItemEntryController
    {
        private OldModelEntry oldmodelentry;

        public OldModelEntryController(EntryChunkController entrychunkcontroller,OldModelEntry oldmodelentry) : base(entrychunkcontroller,oldmodelentry)
        {
            this.oldmodelentry = oldmodelentry;
            Node.Text = "Old Model Entry";
            Node.ImageKey = "oldmodelentry";
            Node.SelectedImageKey = "oldmodelentry";
        }

        public OldModelEntry OldModelEntry
        {
            get { return oldmodelentry; }
        }
    }
}