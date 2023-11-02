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
using System.IO;

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
            public int width, height;
            public int offsetX, offsetY;
        }
        Dictionary<string,Rect> rectTable_=new Dictionary<string, Rect>();

        private System.IO.Stream stream_=null;
        

        private void btnLoadTexturePackerJSON_Click(object sender, EventArgs e)
        {
            if(dlgOpenJSON.ShowDialog() == DialogResult.OK)
            {
                stream_ = dlgOpenJSON.OpenFile();
                txtTPJSONPath.Text = dlgOpenJSON.FileName;
            }
        }

        private void ParseFrame(JsonElement frameElement)
        {
            Nullable<JsonElement> fileNameNode = frameElement.GetProperty("filename");
            if(fileNameNode != null)
            {
                var rcElem = frameElement.GetProperty("frame");
                Rect rc;
                rc.x=rcElem.GetProperty("x").GetInt32();
                rc.y = rcElem.GetProperty("y").GetInt32();
                rc.width = rcElem.GetProperty("w").GetInt32();
                rc.height = rcElem.GetProperty("h").GetInt32();
                var isTrimmedNode = frameElement.GetProperty("trimmed");
                if (isTrimmedNode.GetBoolean())
                {
                    var spriteSrcSize = frameElement.GetProperty("spriteSourceSize");

                    rc.offsetX= spriteSrcSize.GetProperty("x").GetInt32();
                    rc.offsetY = spriteSrcSize.GetProperty("y").GetInt32();
                }
                else
                {
                    rc.offsetX = 0;
                    rc.offsetY = 0;
                }
                rectTable_[fileNameNode.Value.ToString()] = rc;
            }
        }

        private void ParseFrames(JsonElement framesElement)
        {
            //TexturePackerの出力設定がArrayの時は
            //"filename"="ファイル名"になっている
            if (framesElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var elem in framesElement.EnumerateArray())
                {
                    ParseFrame(elem);
                }
            }
            //TexturePackerの出力設定がハッシュの時はファイル名＝オブジェクト名
            else if (framesElement.ValueKind == JsonValueKind.Object)
            {
                foreach (var obj in framesElement.EnumerateObject())
                {
                    Debug.Print(obj.ToString());
                    ParseFrame(obj.Value);
                }
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (stream_ == null)
            {
                return;
            }
            if(stream_.Position== stream_.Length)
            {
                stream_.Position = 0;//巻き戻す
            }
            var doc = JsonDocument.Parse(stream_);
            stream_.Close();
            var root = doc.RootElement;
           
            if(root.ValueKind== JsonValueKind.Object)
            {
                foreach(var obj in root.EnumerateObject())
                {
                    if (obj.Name == "frames")
                    {
                        ParseFrames(obj.Value);
                    }
                }
                if(dlgSave.ShowDialog()== DialogResult.OK)
                {
                    var saveStream=dlgSave.OpenFile();
                    if (saveStream != null)
                    {
                        BinaryWriter bw = new BinaryWriter(saveStream);
                        bw.Write(rectTable_.Count());
                        foreach (var keyValue in rectTable_)
                        {
                            bw.Write(keyValue.Key);
                            bw.Write(keyValue.Value.x);
                            bw.Write(keyValue.Value.y);
                            bw.Write(keyValue.Value.width);
                            bw.Write(keyValue.Value.height);
                            bw.Write(keyValue.Value.offsetX);
                            bw.Write(keyValue.Value.offsetY);
                        }
                        bw.Close();
                        saveStream.Close();
                    }

                }
            }
            
        }
    }
}
