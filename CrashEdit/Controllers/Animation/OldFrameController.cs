using Crash;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrashEdit
{
    public sealed class OldFrameController : Controller
    {
        public OldFrameController(OldAnimationEntryController oldanimationentrycontroller,OldFrame oldframe)
        {
            OldAnimationEntryController = oldanimationentrycontroller;
            OldFrame = oldframe;
            AddMenu("Export as OBJ", Menu_Export_OBJ);
            InvalidateNode();
            InvalidateNodeImage();
        }

        public override void InvalidateNode()
        {
            Node.Text = Crash.UI.Properties.Resources.FrameController_Text;
        }

        public override void InvalidateNodeImage()
        {
            Node.ImageKey = "arrow";
            Node.SelectedImageKey = "arrow";
        }

        protected override Control CreateEditor()
        {
            TabControl tbcTabs = new TabControl() { Dock = DockStyle.Fill };
            OldModelEntry modelentry = OldAnimationEntryController.EntryChunkController.NSFController.NSF.FindEID<OldModelEntry>(OldFrame.ModelEID);

            OldFrameBox framebox = new OldFrameBox(this);
            framebox.Dock = DockStyle.Fill;
            Dictionary<int,TextureChunk> textures = new Dictionary<int,TextureChunk>();
            foreach (OldModelStruct str in modelentry.Structs)
                if (str is OldModelTexture tex && !textures.ContainsKey(tex.EID))
                    textures.Add(tex.EID,OldAnimationEntryController.EntryChunkController.NSFController.NSF.FindEID<TextureChunk>(tex.EID));
            OldAnimationEntryViewer viewerbox = new OldAnimationEntryViewer(OldFrame,false,modelentry,textures) { Dock = DockStyle.Fill };

            TabPage edittab = new TabPage("Editor");
            edittab.Controls.Add(framebox);
            TabPage viewertab = new TabPage("Viewer");
            viewertab.Controls.Add(new UndockableControl(viewerbox));

            tbcTabs.TabPages.Add(viewertab);
            tbcTabs.TabPages.Add(edittab);
            tbcTabs.SelectedTab = viewertab;

            return tbcTabs;
        }

        public OldAnimationEntryController OldAnimationEntryController { get; }
        public OldFrame OldFrame { get; }

        private void Menu_Export_OBJ()
        {
            OldModelEntry modelentry = OldAnimationEntryController.EntryChunkController.NSFController.NSF.FindEID<OldModelEntry>(OldFrame.ModelEID);
            if (modelentry == null)
            {
                throw new GUIException("The linked model entry could not be found.");
            }
            if (MessageBox.Show("Texture and color information will not be exported.\n\nContinue anyway?","Export as OBJ",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            FileUtil.SaveFile(OldFrame.ToOBJ(modelentry),FileFilters.OBJ,FileFilters.Any);
        }
    }
}
