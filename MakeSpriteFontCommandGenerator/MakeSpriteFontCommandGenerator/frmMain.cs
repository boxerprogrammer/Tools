using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeSpriteFontCommandGenerator
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 入力された文字列の中で無視する文字コード群
        /// </summary>
        HashSet<char> _ignoreCharacters;

        /// <summary>
        /// 使用している文字数カウンタ
        /// </summary>
        int _numChars;

        public frmMain()
        {
            
            InitializeComponent();
            UpdateIgnoreCharacters();
        }

        private void fontDialog_Apply(object sender, EventArgs e)
        {

        }

        private void btnFontSearch_Click(object sender, EventArgs e)
        {
            Font font = GetCurrentFont((float)txtFontSize.Value);
            fontDialog.Font = font;
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            txtFontName.Text = fontDialog.Font.Name;
            txtFontSize.Value = (Decimal)(fontDialog.Font.Size);
            chkBold.Checked = fontDialog.Font.Bold;
            chkItalic.Checked = fontDialog.Font.Italic;
        }
        /// <summary>
        /// 現在のフォントをスタイル込みで返す
        /// </summary>
        /// <returns>現在のフォント</returns>
        private Font GetCurrentFont(float fontsize=11)
        {
            FontStyle fontStyle = new FontStyle();
            if (chkBold.Checked)
            {
                fontStyle |= FontStyle.Bold;
            }
            if (chkItalic.Checked)
            {
                fontStyle |= FontStyle.Italic;
            }
            var font = new Font(txtFontName.Text, fontsize, fontStyle);
            return font;
        }

        private void txtFontName_TextChanged(object sender, EventArgs e)
        {
            txtUseString.Font = new Font(txtFontName.Text, 11);
        }

        /// <summary>
        /// 入力文字列内で無視するコードを追加する
        /// </summary>
        void UpdateIgnoreCharacters()
        {
            // 無視する文字コード、タブや改行コードなど
            _ignoreCharacters = new HashSet<char> { '\0', '\n', '\r', '\t' };

            AddIgnoreCharacters('\u3000', '\u3000');
            // デフォルトで追加する文字種が選択されている場合はそれらを無視文字として追加する
            if (chkLatin.Checked)
            {
                AddIgnoreCharacters('\u0020', '\u007e');
            }

            if (chkHiragana.Checked)
            {
                AddIgnoreCharacters('\u3041', '\u3096');
                AddIgnoreCharacters('\u3099', '\u309f');
            }

            if (chkKatakana.Checked)
            {
                AddIgnoreCharacters('\u30a0', '\u30ff');
            }
            if (chkWideLatin.Checked)
            {
                AddIgnoreCharacters('\uff01', '\uff65');
            }
        }

        /// <summary>
        /// 指定した文字コード範囲をignoreCharactersハッシュへ追加する
        /// </summary>
        /// <param name="beginChar">開始文字コード</param>
        /// <param name="endChar">終了文字コード</param>
        void AddIgnoreCharacters(char beginChar, char endChar)
        {
            for (char c = beginChar; c <= endChar; c++)
                _ignoreCharacters.Add(c);
        }
        /// <summary>
        /// RegionElement文字列を生成する
        /// </summary>
        /// <param name="startChar">領域開始文字コード</param>
        /// <param name="endChar">領域終了文字コード</param>
        /// <returns>生成された文字列</returns>
        string GenerateRegionElement(char startChar, char endChar)
        {
            _numChars += (int)endChar - (int)startChar + 1;
            return String.Format(
                "/CharacterRegion:0x{0:x4}-0x{1:x4} ",
                (int)startChar, (int)endChar);
        }
        /// <summary>
        /// CharacterRegions宣言文字列を生成する
        /// </summary>
        void GenerateCharacterRegions()
        {
            string text = "MakeSpriteFont.exe \"" + txtFontName.Text +
                "\" " + txtOutFileName.Text +
                " /FontSize:" + txtFontSize.Value.ToString() + " ";
            if (chkBold.Checked)
            {
                if (chkItalic.Checked)
                {
                    text += " /FontStyle:Bold,Italic ";
                }
                else
                {
                    text += " /FontStyle:Bold ";
                }
                
            }else if (chkItalic.Checked)
            {
                text += " /FontStyle:Italic ";
            }
             
            // デフォルト追加文字種のCharacterRegionエレメントを生成する
            _numChars = 0;
            text+= GenerateRegionElement('\u3000', '\u3000');
            if (chkLatin.Checked)
            {
                text += GenerateRegionElement('\u0020', '\u007e');
            }
            if (chkHiragana.Checked)
            {
                text += GenerateRegionElement('\u3041', '\u3096');
                text += GenerateRegionElement('\u3099', '\u309f');
            }
            if (chkKatakana.Checked)
            {
                text += GenerateRegionElement('\u30a0', '\u30ff');
            }
            if (chkWideLatin.Checked)
            {
                text += GenerateRegionElement('\uff01', '\uff65');
            }

            // 入力文字列の文字コードの中から一意な文字コードを抽出、無視文字を除外、ソートする
            var uniqueChars = from c in txtUseString.Text.Distinct()
                              where !_ignoreCharacters.Contains(c)
                              orderby c
                              select c;

            // ソートされた一意な文字コード群からCharacterRegionエレメント文字列を生成する
            char regionStart = char.MinValue;
            char prevChar = char.MinValue;
            foreach (char c in uniqueChars)
            {
                // 使用する文字コードの連続性が途切れたか？
                if (c != prevChar + 1)
                {
                    // CharacterRegionエレメント文字列の生成
                    if (prevChar != char.MinValue)
                        text += GenerateRegionElement(regionStart, prevChar);

                    regionStart = c;
                }

                prevChar = c;
            }

            // CharacterRegionエレメント文字列の生成
            if (prevChar != char.MinValue)
                text += GenerateRegionElement(regionStart, prevChar);

            // text += "    </CharacterRegions>\r\n";

            // 生成した文字列を出力用テキストボックスへ設定する
            txtCommandLine.Text = text;

            // ステータス文字列の更新
            lblStatus.Text = String.Format("全体文字数: {0}文字 使用文字数: {1}文字",
                txtUseString.Text.Length, _numChars);
        }
        private void txtUseString_TextChanged(object sender, EventArgs e)
        {
            GenerateCharacterRegions();
        }

        private void Checkbox_Click(object sender, EventArgs e)
        {
            UpdateIgnoreCharacters();
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCommandLine.Text);
        }

        private void FontCheckbox_Clicked(object sender, EventArgs e)
        {
            txtUseString.Font= GetCurrentFont();
            txtUseString.Refresh();
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtOutFileName_TextChanged(object sender, EventArgs e)
        {
            GenerateCharacterRegions();
        }
    }
}
