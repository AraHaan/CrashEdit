using Crash;

namespace CrashEdit
{
    public sealed class NormalChunkController : EntryChunkController
    {
        public NormalChunkController(NSFController nsfcontroller,NormalChunk normalchunk) : base(nsfcontroller,normalchunk)
        {
            NormalChunk = normalchunk;
            InvalidateNode();
            InvalidateNodeImage();
        }

        public override void InvalidateNode()
        {
            Node.Text = string.Format("Normal Chunk {0}", NSFController.NSF.Chunks.IndexOf(NormalChunk) * 2 + 1);
        }

        public override void InvalidateNodeImage()
        {
            Node.ImageKey = "yellowj";
            Node.SelectedImageKey = "yellowj";
        }

        public NormalChunk NormalChunk { get; }
    }
}
