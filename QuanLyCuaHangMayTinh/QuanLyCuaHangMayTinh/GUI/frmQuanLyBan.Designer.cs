namespace QuanLyCuaHangMayTinh
{
    partial class frm_quanlyban
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSoluongghe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTinhtrang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaban = new System.Windows.Forms.TextBox();
            this.datagridBan = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtnXoa = new FontAwesome.Sharp.IconButton();
            this.ibtnSua = new FontAwesome.Sharp.IconButton();
            this.ibtnLuu = new FontAwesome.Sharp.IconButton();
            this.ibtnThem = new FontAwesome.Sharp.IconButton();
            this.ibtnLamoi = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridBan)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtSoluongghe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTinhtrang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaban);
            this.panel1.Location = new System.Drawing.Point(614, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 434);
            this.panel1.TabIndex = 17;
            // 
            // txtSoluongghe
            // 
            this.txtSoluongghe.Location = new System.Drawing.Point(126, 214);
            this.txtSoluongghe.Name = "txtSoluongghe";
            this.txtSoluongghe.Size = new System.Drawing.Size(131, 20);
            this.txtSoluongghe.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã bàn ";
            // 
            // cboTinhtrang
            // 
            this.cboTinhtrang.FormattingEnabled = true;
            this.cboTinhtrang.Location = new System.Drawing.Point(126, 285);
            this.cboTinhtrang.Name = "cboTinhtrang";
            this.cboTinhtrang.Size = new System.Drawing.Size(131, 21);
            this.cboTinhtrang.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng ghế";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tình trạng ";
            // 
            // txtMaban
            // 
            this.txtMaban.Location = new System.Drawing.Point(126, 147);
            this.txtMaban.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaban.Name = "txtMaban";
            this.txtMaban.Size = new System.Drawing.Size(131, 20);
            this.txtMaban.TabIndex = 3;
            // 
            // datagridBan
            // 
            this.datagridBan.BackgroundColor = System.Drawing.Color.White;
            this.datagridBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridBan.Location = new System.Drawing.Point(19, 18);
            this.datagridBan.Margin = new System.Windows.Forms.Padding(2);
            this.datagridBan.Name = "datagridBan";
            this.datagridBan.RowHeadersWidth = 82;
            this.datagridBan.RowTemplate.Height = 33;
            this.datagridBan.Size = new System.Drawing.Size(549, 401);
            this.datagridBan.TabIndex = 16;
            this.datagridBan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridBan_CellContentClick);
            this.datagridBan.Click += new System.EventHandler(this.datagridBan_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Controls.Add(this.datagridBan);
            this.panel2.Location = new System.Drawing.Point(11, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 434);
            this.panel2.TabIndex = 25;
            // 
            // ibtnXoa
            // 
            this.ibtnXoa.BackColor = System.Drawing.Color.Green;
            this.ibtnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnXoa.ForeColor = System.Drawing.Color.White;
            this.ibtnXoa.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.ibtnXoa.IconColor = System.Drawing.Color.White;
            this.ibtnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnXoa.IconSize = 30;
            this.ibtnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnXoa.Location = new System.Drawing.Point(385, 17);
            this.ibtnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.ibtnXoa.Name = "ibtnXoa";
            this.ibtnXoa.Size = new System.Drawing.Size(100, 46);
            this.ibtnXoa.TabIndex = 21;
            this.ibtnXoa.Text = "     Xóa ";
            this.ibtnXoa.UseVisualStyleBackColor = false;
            this.ibtnXoa.Click += new System.EventHandler(this.ibtnXoa_Click);
            // 
            // ibtnSua
            // 
            this.ibtnSua.BackColor = System.Drawing.Color.Green;
            this.ibtnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnSua.ForeColor = System.Drawing.Color.White;
            this.ibtnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.ibtnSua.IconColor = System.Drawing.Color.White;
            this.ibtnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnSua.IconSize = 30;
            this.ibtnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnSua.Location = new System.Drawing.Point(227, 17);
            this.ibtnSua.Margin = new System.Windows.Forms.Padding(2);
            this.ibtnSua.Name = "ibtnSua";
            this.ibtnSua.Size = new System.Drawing.Size(100, 46);
            this.ibtnSua.TabIndex = 20;
            this.ibtnSua.Text = "     Sửa";
            this.ibtnSua.UseVisualStyleBackColor = false;
            this.ibtnSua.Click += new System.EventHandler(this.ibtnSua_Click);
            // 
            // ibtnLuu
            // 
            this.ibtnLuu.BackColor = System.Drawing.Color.Green;
            this.ibtnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnLuu.ForeColor = System.Drawing.Color.White;
            this.ibtnLuu.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.ibtnLuu.IconColor = System.Drawing.Color.White;
            this.ibtnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnLuu.IconSize = 30;
            this.ibtnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnLuu.Location = new System.Drawing.Point(551, 17);
            this.ibtnLuu.Margin = new System.Windows.Forms.Padding(2);
            this.ibtnLuu.Name = "ibtnLuu";
            this.ibtnLuu.Size = new System.Drawing.Size(100, 46);
            this.ibtnLuu.TabIndex = 22;
            this.ibtnLuu.Text = "     Lưu";
            this.ibtnLuu.UseVisualStyleBackColor = false;
            this.ibtnLuu.Click += new System.EventHandler(this.ibtnLuu_Click);
            // 
            // ibtnThem
            // 
            this.ibtnThem.BackColor = System.Drawing.Color.Green;
            this.ibtnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnThem.ForeColor = System.Drawing.Color.White;
            this.ibtnThem.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.ibtnThem.IconColor = System.Drawing.Color.White;
            this.ibtnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnThem.IconSize = 30;
            this.ibtnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnThem.Location = new System.Drawing.Point(57, 17);
            this.ibtnThem.Margin = new System.Windows.Forms.Padding(2);
            this.ibtnThem.Name = "ibtnThem";
            this.ibtnThem.Size = new System.Drawing.Size(100, 46);
            this.ibtnThem.TabIndex = 19;
            this.ibtnThem.Text = "     Thêm ";
            this.ibtnThem.UseVisualStyleBackColor = false;
            this.ibtnThem.Click += new System.EventHandler(this.ibtnThem_Click);
            // 
            // ibtnLamoi
            // 
            this.ibtnLamoi.BackColor = System.Drawing.Color.Green;
            this.ibtnLamoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnLamoi.ForeColor = System.Drawing.Color.White;
            this.ibtnLamoi.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.ibtnLamoi.IconColor = System.Drawing.Color.White;
            this.ibtnLamoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnLamoi.IconSize = 30;
            this.ibtnLamoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnLamoi.Location = new System.Drawing.Point(717, 17);
            this.ibtnLamoi.Margin = new System.Windows.Forms.Padding(2);
            this.ibtnLamoi.Name = "ibtnLamoi";
            this.ibtnLamoi.Size = new System.Drawing.Size(100, 46);
            this.ibtnLamoi.TabIndex = 23;
            this.ibtnLamoi.Text = "     Làm mới ";
            this.ibtnLamoi.UseVisualStyleBackColor = false;
            this.ibtnLamoi.Click += new System.EventHandler(this.ibtnLamoi_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Green;
            this.panel4.Controls.Add(this.ibtnLamoi);
            this.panel4.Controls.Add(this.ibtnThem);
            this.panel4.Controls.Add(this.ibtnLuu);
            this.panel4.Controls.Add(this.ibtnSua);
            this.panel4.Controls.Add(this.ibtnXoa);
            this.panel4.Location = new System.Drawing.Point(11, 451);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(876, 75);
            this.panel4.TabIndex = 26;
            // 
            // frm_quanlyban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(895, 537);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_quanlyban";
            this.Text = "frm_quanlyban";
            this.Load += new System.EventHandler(this.frm_quanlyban_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridBan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSoluongghe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTinhtrang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaban;
        private System.Windows.Forms.DataGridView datagridBan;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtnXoa;
        private FontAwesome.Sharp.IconButton ibtnSua;
        private FontAwesome.Sharp.IconButton ibtnLuu;
        public FontAwesome.Sharp.IconButton ibtnThem;
        private FontAwesome.Sharp.IconButton ibtnLamoi;
        private System.Windows.Forms.Panel panel4;
    }
}