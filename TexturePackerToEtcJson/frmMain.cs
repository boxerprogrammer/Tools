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
using System.Text.Json.Nodes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace TexturePackerToEtcJson
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        System.IO.Stream originalJSONStream_ = null;
        System.IO.Stream texturePackerJSONStream_ = null;
        string strPackedImagePath_ = "";
        struct Rect{
            public int x;
            public int y;
            public int w;
            public int h;
            public override string ToString()
            {
                string ret="rect:x=";
                ret += x.ToString();
                ret += ",y="+y.ToString();
                ret += ",w="+w.ToString();
                ret += ",h="+h.ToString();
                return ret;
            }
        }
        Dictionary<string,Rect> rectTable_ = new Dictionary<string,Rect>();

        private void btnOpenOriginalJSON_Click(object sender, EventArgs e)
        {
            if(dlgOpenJSON.ShowDialog()!= DialogResult.OK )
            {
                return;
            }
            originalJSONStream_ = null;
            originalJSONStream_ = dlgOpenJSON.OpenFile();

        }

        private void btnOpenTexturePackerJSON_Click(object sender, EventArgs e)
        {
            if (dlgOpenJSON.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            texturePackerJSONStream_ = null;
            texturePackerJSONStream_ = dlgOpenJSON.OpenFile();

        }

        private void Convert(JsonDocument originalJSON , JsonDocument texJSON) {
            var root = originalJSON.RootElement;
            
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
            //Debug.Print(prop.Name);
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
            string name = prop.Name;
            if(txtPrePath.Text.Length > 0)
            {
                name = txtPrePath.Text + "/" + name;
            }
            rectTable_.Add(name, rc);
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

        private List<JsonElement> GetLayoutsFromOriginalJson(JsonDocument doc)
        {
            List < JsonElement > layouts = new List< JsonElement >();
            foreach (var obj in doc.RootElement.EnumerateObject())
            {
                if (obj.Name == "Layout")
                {
                    if(obj.Value.ValueKind == JsonValueKind.Array)
                    {
                        var len = obj.Value.GetArrayLength();
                        for(int i = 0; i < len; i++)
                        {
                            layouts.Add(obj.Value[i]);
                        }
                    }
                }
            }
            return layouts;
        }
        private List<JsonNode> GetLayoutsFromOriginalJson(JsonNode doc)
        {
            List<JsonNode> layouts = new List<JsonNode>();
            var layout = doc.Root["Layout"];
            var layoutNodes = layout.AsArray();
            foreach (var layoutNode in layoutNodes)
            {
                layouts.Add((JsonNode)layoutNode);
            }
            return layouts;
        }
        private Nullable< JsonElement > FindObjectFromJsonElement(JsonElement elem,string name)
        {
            Nullable<JsonElement> retElem = null;
            foreach (var obj in elem.EnumerateObject())
            {
                if(obj.Name== name)
                {
                    retElem= obj.Value;
                }
            }
            return retElem;
        }
        private List<JsonNode> GetImageGUIsFromOriginalJsonLayout(JsonNode layout)
        {
            List<JsonNode> guis = new List<JsonNode>();
            var guiNodeArray=layout["Gui"].AsArray();
            foreach (JsonNode guiNode in guiNodeArray)
            {
                var value = guiNode["Type"].AsValue();
                if(value != null)
                {
                    if(value.ToString() == "image")
                    {
                        guis.Add((JsonNode)guiNode);
                    }else if(value.ToString() == "button")
                    {
                        var paramButton = guiNode["ParamButton"];
                        if(paramButton != null)
                        {
                            var fileName = paramButton["FileName"];
                            if (fileName != null)
                            {
                                guis.Add((JsonNode)guiNode);
                            }
                        }
                    }
                }
            }
            return guis;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (texturePackerJSONStream_ == null)
            {
                return;
            }

            //ストリームの最後に来てたら巻き戻す
            if (texturePackerJSONStream_.Length <= texturePackerJSONStream_.Position)
            {
                texturePackerJSONStream_.Seek(0, System.IO.SeekOrigin.Begin);
            }
            var texPackDoc = JsonDocument.Parse(texturePackerJSONStream_);
            var texPackRoot = texPackDoc.RootElement;
            rectTable_.Clear();
            if (texPackRoot.ValueKind == JsonValueKind.Object)
            {
                foreach (var obj in texPackRoot.EnumerateObject())
                {
                    if (obj.Name == "frames")
                    {
                        ParseFrames(obj.Value);
                    }
                    else if(obj.Name =="meta")
                    {
                        foreach(var metaobj in obj.Value.EnumerateObject())
                        {
                            if(metaobj.Name == "image")
                            {
                                strPackedImagePath_= metaobj.Value.ToString();
                                if(txtPackedImageDir.Text.Length> 0)
                                {
                                    var imageDir = new Uri(txtPackedImageDir.Text);
                                    var baseDir = new Uri(txtBasePath.Text+"/");
                                    var strRelativeImageDir = baseDir.MakeRelativeUri(imageDir).ToString();
                                    strPackedImagePath_ = strRelativeImageDir + "/"+strPackedImagePath_;
                                }
                            }
                        }
                    }
                }
            }
            else if (texPackRoot.ValueKind == JsonValueKind.Array)
            {
                //Debug.Print(texPackRoot.ToString());
            }
            //ここまででTexturePackerJSONの解析が終了
            //パス→RectのDictionaryになっている。
            //では次はオリジナルJSONの解析
            //ストリームの最後に来てたら巻き戻す
            if (originalJSONStream_.Length <= originalJSONStream_.Position)
            {
                originalJSONStream_.Seek(0, System.IO.SeekOrigin.Begin);
            }

            JsonNode orgDoc = JsonNode.Parse(originalJSONStream_);
            var layoutsJson=GetLayoutsFromOriginalJson(orgDoc);
            List<JsonNode> imgElements = new List<JsonNode>();
            foreach (var layout in layoutsJson)
            {
                var elems= GetImageGUIsFromOriginalJsonLayout(layout);
                if (elems != null)
                {
                    foreach (var elem in elems)
                    {
                        imgElements.Add(elem);
                    }
                }
            }
            //一つ一つ置換していきます。
            foreach(var node in imgElements)
            {
                if (node["Type"].ToString() == "image")
                {
                    var paramImage = node["ParamImage"];
                    if (paramImage != null)
                    {
                        var uri = paramImage["Uri"];
                        if(uri != null)
                        {
                            Debug.Print($"{uri.ToString()}");
                            if (rectTable_.ContainsKey(uri.ToString())){
                                var rc = rectTable_[uri.ToString()];
                                Debug.Print(rc.ToString());

                                JsonArray jsonArray = new JsonArray(); 
                                jsonArray.Add(rc.x);
                                jsonArray.Add(rc.y);
                                jsonArray.Add(rc.w);
                                jsonArray.Add(rc.h);
                                paramImage["UVArea"] = jsonArray;
                                uri = strPackedImagePath_;
                                paramImage["Uri"] = uri;
                            }
                        }
                    }
                }else if (node["Type"].ToString() == "button")
                {
                    var paramButton = node["ParamButton"];
                    if (paramButton != null)
                    {
                        var fileName = paramButton["FileName"];
                        if (fileName != null)
                        {
                            Debug.Print($"{fileName.ToString()}");
                            if (rectTable_.ContainsKey(fileName.ToString()))
                            {
                                var rc = rectTable_[fileName.ToString()];

                                Debug.Print(rc.ToString());

                                JsonArray jsonArray = new JsonArray();
                                jsonArray.Add(rc.x);
                                jsonArray.Add(rc.y);
                                jsonArray.Add(rc.w);
                                jsonArray.Add(rc.h);
                                paramButton["UVArea"] = jsonArray;
                                fileName = strPackedImagePath_;
                                paramButton["FileName"] = fileName;
                            }
                            
                        }
                    }
                }
            }
            if(dlgSave.ShowDialog()==DialogResult.OK)
            {
                var strSaveFolderPath = dlgSave.FileName;
                var stream = File.OpenWrite(strSaveFolderPath);
                JsonWriterOptions options = new JsonWriterOptions();
                options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.Indented = true;
                options.MaxDepth = 0;
       
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(stream,options);
                orgDoc.WriteTo(jsonWriter);
                jsonWriter.Flush();
                jsonWriter.Dispose();
                stream.Close();//書き込み先をクローズ
                originalJSONStream_.Close();//
                texturePackerJSONStream_.Close();
                MessageBox.Show("パック画像キャンバスJSONを出力しました。");
            }
        }

        private void txtPrePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPackedImageFolder_Click(object sender, EventArgs e)
        {
            if(dlgPackedImgFolder.ShowDialog()==DialogResult.OK) {
                string strPath = Path.GetDirectoryName(dlgPackedImgFolder.FileName);
                txtPackedImageDir.Text = strPath;
            }
        }

        private void btnBasePath_Click(object sender, EventArgs e)
        {
            if (dlgPackedImgFolder.ShowDialog() == DialogResult.OK)
            {
                string strPath = Path.GetDirectoryName(dlgPackedImgFolder.FileName);
                txtBasePath.Text = strPath;
            }
        }
    }
}
