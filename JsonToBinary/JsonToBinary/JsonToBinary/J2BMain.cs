using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Diagnostics;

namespace JsonToBinary
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        struct Rect
        {
            public int x, y;
            public int w, h;
        }
        Dictionary<string,Rect> rectTable_=new Dictionary<string, Rect>();

        private System.IO.Stream stream_=null;
        

        private void btnLoadTexturePackerJSON_Click(object sender, EventArgs e)
        {
            if(dlgOpenJSON.ShowDialog() == DialogResult.OK)
            {
                stream_=dlgOpenJSON.OpenFile();
            }
        }

        private void ParseFrameForArray(JsonElement frameElement)
        {
            foreach (var obj in frameElement.EnumerateObject())
            {
                if (obj.Name == "filename")
                {
                    Debug.Print(obj.Value.ToString());
                }
            }
        }

        private void ParseFrameForHash(JsonProperty prop)
        {
            Debug.Print(prop.Name);
            Rect rc;
            rc.x = 0;
            rc.y = 0;
            rc.w = 0;   
            rc.h = 0;   
            foreach (var obj in prop.Value.EnumerateObject())
            {
                if (obj.Name == "frame")
                {
                    foreach (var rectJson in obj.Value.EnumerateObject())
                    {
                        if (rectJson.Name == "x")
                        {
                            rc.x = rectJson.Value.GetInt32();
                        }
                        else if (rectJson.Name == "y")
                        {
                            rc.y = rectJson.Value.GetInt32();
                        }
                        else if (rectJson.Name == "w")
                        {
                            rc.w = rectJson.Value.GetInt32();
                        }
                        else if (rectJson.Name == "h")
                        {
                            rc.h = rectJson.Value.GetInt32();
                        }
                    }
                    break;
                }
            }
            rectTable_.Add(prop.Name, rc);  
        }

        private void ParseFrames(JsonElement framesElement)
        {
            //TexturePackerの出力設定がArrayの時は
            //"filename"="ファイル名"になっている
            if (framesElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var elem in framesElement.EnumerateArray())
                {
                    ParseFrameForArray(elem);
                }
            }
            //TexturePackerの出力設定がハッシュの時はファイル名＝オブジェクト名
            else if (framesElement.ValueKind == JsonValueKind.Object)
            {
                foreach (var obj in framesElement.EnumerateObject())
                {
                    ParseFrameForHash(obj);
                }
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (stream_ == null)
            {
                return;
            }
            
            if (stream_.Length <= stream_.Position)
            {
                stream_.Seek(0,System.IO.SeekOrigin.Begin);
            }
            var doc = JsonDocument.Parse(stream_);
            var root = doc.RootElement;
            rectTable_.Clear();
            if(root.ValueKind== JsonValueKind.Object)
            {
                foreach(var obj in root.EnumerateObject())
                {
                    if (obj.Name == "frames")
                    {
                        ParseFrames(obj.Value);
                    }
                }
            }else if (root.ValueKind == JsonValueKind.Array)
            {
                Debug.Print(root.ToString());
            }
        }
    }
}
